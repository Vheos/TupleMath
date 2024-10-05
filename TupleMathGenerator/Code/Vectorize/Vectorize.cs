namespace TupleMath.Generators.Vectorize;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using TupleMath.Generators.Extensions;
using TupleMath.Generators.Shared;

[Generator]
public class Vectorize : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		context.RegisterPostInitializationOutput(GenerateAttribute);
		context.RegisterPostInitializationOutput(GenerateVectorizedTypeAliases);

		var methods = context.SyntaxProvider
			 .ForAttributeWithMetadataName(AttributeNameFull, Extensions.IsExtensionMethod, NodeAsMethod)
			 .Collect();

		context.RegisterSourceOutput(methods, ProcessSource);
	}

	private static MethodDeclarationSyntax NodeAsMethod(GeneratorAttributeSyntaxContext context, CancellationToken token)
		=> context.TargetNode as MethodDeclarationSyntax;
	private static void GenerateAttribute(IncrementalGeneratorPostInitializationContext context)
	{
		$@"namespace {Shared.AttributesNamespace};
using System;

[AttributeUsage(AttributeTargets.Method)]
public class VectorizeAttribute : Attribute
{{ }}"
			.AddAsSource(nameof(VectorizeAttribute), context);
	}
	private static void GenerateVectorizedTypeAliases(IncrementalGeneratorPostInitializationContext context)
	{
		static IEnumerable<string> Pairs(Type type, int leftSize)
		{
			for (var i = 0; i < leftSize; i++)
				yield return $"{type} {GetComponentName(i)}";
		}

		StringBuilder stringBuilder = new();
		foreach (var (alias, type) in Shared.TypesByAlias)
			for (var i = 2; i <= 4; i++)
				stringBuilder.AppendLine($"global using {alias}{i} = ({string.Join(", ", Pairs(type, i))});");

		stringBuilder.AddAsSource(TypeAliasesFilePath, context);


	}

	private const string AttributeNameFull = $"{Shared.AttributesNamespace}.{nameof(VectorizeAttribute)}";
	private const string TypeAliasesFilePath = "VectorizedTypeAliases";
	private const string TupleItemDefaultPrefix = "Item";
	private const string SizeConversionMethodPrefix = "To";
	private const int MaxSize = 4;
	private static readonly IReadOnlyList<string> VectorComponentNames = ["X", "Y", "Z", "W"];
	private static string Suffix(int leftSize, int rightSize)
		=> $"_{nameof(Vectorize)}{leftSize}{rightSize}";
	private static string FilePath(string originalFilePath, int leftSize, int rightSize)
	{
		var name = Path.GetFileNameWithoutExtension(originalFilePath);
		var extension = Path.GetExtension(originalFilePath);
		return $"{name}{Suffix(leftSize, rightSize)}{extension}";
	}
	private static string GetComponentName(int index)
		=> index < 0 ? throw new IndexOutOfRangeException()
		: index < VectorComponentNames.Count ? VectorComponentNames[index]
		: $"{TupleItemDefaultPrefix}{index}";

	private static SyntaxNode ProcessClassName(ClassDeclarationSyntax original, int leftSize, int rightSize)
	{
		var newName = original.Identifier + Suffix(leftSize, rightSize);
		return original.WithIdentifier(SyntaxFactory.Identifier(newName));
	}
	private static SyntaxNode ResizeType(SyntaxNode original, int size)
	{
		var newName = original.ToString();
		if (size > 1)
			newName += size.ToString();

		return original.ReplaceNode(original, SyntaxFactory.IdentifierName(newName));
	}
	private static ArrowExpressionClauseSyntax ProcessMethodBody(MethodDeclarationSyntax method, int leftSize, int rightSize)
	{
		var perComponentMethodCalls = string.Join(", ", ListMethodCallForEachComponent(method, leftSize, rightSize));

		var expressionText = perComponentMethodCalls;
		if (leftSize == rightSize)
			expressionText = $"({expressionText})";

		var expression = SyntaxFactory.ParseExpression($"{expressionText}");
		return SyntaxFactory.ArrowExpressionClause(expression);
	}
	private static SyntaxNode ProcessMethod(MethodDeclarationSyntax original, int leftSize, int rightSize)
	{
		var nonIgnoredParametersCount = original.ParameterList.Parameters.Count(parameter => !parameter.HasIgnoreAttribute());
		if (nonIgnoredParametersCount <= 1 && leftSize != rightSize)
			return default;

		var newNode = original;

		var returnType = newNode.ReturnType;
		newNode = newNode.ReplaceNode(returnType, ResizeType(returnType, Math.Max(leftSize, rightSize)));

		var leftType = newNode.ParameterList.Parameters.First().Type;
		newNode = newNode.ReplaceNode(leftType, ResizeType(leftType, leftSize));

		var rightTypes = newNode.ParameterList.Parameters
			.Skip(1)
			.Where(parameter => !parameter.HasIgnoreAttribute())
			.Select(parameter => parameter.Type);
		newNode = newNode.ReplaceNodes(rightTypes, (from, to) => ResizeType(from, rightSize));

		var vectorizedBody = ProcessMethodBody(newNode, leftSize, rightSize);
		newNode = newNode.WithExpressionBody(vectorizedBody);

		newNode = newNode.RemoveAttributes(nameof(Vectorize), nameof(Retype.Retype));

		return newNode;
	}
	private static IEnumerable<string> ListMethodCallForEachComponent(MethodDeclarationSyntax methodSyntax, int leftSize, int rightSize)
	{
		var method = methodSyntax.Identifier.ToString();
		var allParameters = methodSyntax.ParameterList.Parameters;
		var thisParameter = allParameters.First();
		var otherParameters = allParameters.Skip(1);

		static string Rename(ParameterSyntax parameter, string postfix)
			=> parameter.HasIgnoreAttribute()
			? $"{parameter.Identifier}"
			: $"{parameter.Identifier}{postfix}";

		if (leftSize < rightSize)
		{
			var parameters = string.Join(", ", otherParameters.Select(parameter => parameter.Identifier));
			yield return $"{thisParameter.Identifier}.{SizeConversionMethodPrefix}{rightSize}().{method}({parameters})";
		}
		else if (leftSize == rightSize)
		{
			var components = Enumerable.Range(0, leftSize).Select(GetComponentName);
			foreach (var component in components)
			{
				var perComponentParameters = string.Join(", ", otherParameters.Select(parameter => Rename(parameter, $".{component}")));
				yield return $"{thisParameter.Identifier}.{component}.{method}({perComponentParameters})";
			}
		}
		else if (leftSize > rightSize)
		{
			var parameters = string.Join(", ", otherParameters.Select(parameter => Rename(parameter, $".{SizeConversionMethodPrefix}{leftSize}()")));
			yield return $"{thisParameter.Identifier}.{method}({parameters})";
		}
	}
	internal static void ProcessSource(SourceProductionContext context, ImmutableArray<MethodDeclarationSyntax> methodsToVectorize)
	{
		foreach (var (root, methodsToVectorizeInRoot) in methodsToVectorize.GroupBy(method => method.SyntaxTree.GetCompilationUnitRoot()))
		{
			var commonRoot = root;
			var methodsToRemoveInRoot = commonRoot
				.DescendantsOfType<MethodDeclarationSyntax>()
				.Except(methodsToVectorizeInRoot);

			commonRoot = commonRoot.RemoveNodes(methodsToRemoveInRoot, SyntaxRemoveOptions.KeepNoTrivia);
			commonRoot = commonRoot.ReplaceTrivia(commonRoot.DescendantTrivia(), (_, _) => default);
			var remainingMethods = commonRoot.DescendantsOfType<MethodDeclarationSyntax>();

			for (var leftSize = 1; leftSize <= MaxSize; leftSize++)
				for (var rightSize = 1; rightSize <= MaxSize; rightSize++)
				{
					if (leftSize == 1 && rightSize == 1)
						continue;

					var newRoot = commonRoot;
					newRoot = newRoot.ReplaceNodes(remainingMethods, (original, _) => ProcessMethod(original, leftSize, rightSize));

					var classesInRoot = newRoot.DescendantsOfType<ClassDeclarationSyntax>();
					newRoot = newRoot.ReplaceNodes(classesInRoot, (original, _) => ProcessClassName(original, leftSize, rightSize));

					var filePath = FilePath(commonRoot.SyntaxTree.FilePath, leftSize, rightSize);
					newRoot.NormalizeWhitespace().ToString()
						.AddAsSource(filePath, context);
				}
		}
	}
}