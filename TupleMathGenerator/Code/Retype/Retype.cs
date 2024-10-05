namespace TupleMath.Generators.Retype;
using System.Collections.Immutable;
using System.IO;
using System.Threading;
using TupleMath.Generators.Extensions;
using TupleMath.Generators.Shared;

[Generator]
public class Retype : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		// Debugger.Launch();

		context.RegisterPostInitializationOutput(GeneratePublics);

		var methodsToRetype = context.SyntaxProvider
			 .ForAttributeWithMetadataName(AttributeNameFull, Extensions.IsExtensionMethod, GetDtos)
			 .SelectMany((dtos, _) => dtos)
			 .Collect();

		context.RegisterSourceOutput(methodsToRetype, ProcessSource);
	}
	private static IEnumerable<RetypeDto> GetDtos(GeneratorAttributeSyntaxContext context, CancellationToken token)
		=> context.Attributes.Select(attribute => new RetypeDto(context.TargetNode as MethodDeclarationSyntax)
		{
			NewType = attribute.GetConstructorParameter<string>(0),
			RetypeTargets = attribute.GetConstructorParameter<RetypeTargets>(1),
			ConversionMethod = attribute.GetConstructorParameter<string>(2),
			ConversionTargets = attribute.GetConstructorParameter<ConversionTargets>(3),
		});
	private static void GeneratePublics(IncrementalGeneratorPostInitializationContext context)
	{
		$@"namespace {Shared.AttributesNamespace};
using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class RetypeAttribute(
	string newType, 
	RetypeTargets retypeTargets, 
	string conversionMethod,
	ConversionTargets conversionTargets) 
	: Attribute
{{ }}"
		.AddAsSource($"{nameof(RetypeAttribute)}", context);

		$@"namespace {Shared.AttributesNamespace};
using System;

[Flags]
public enum RetypeTargets
{{
	None = 0,
	All = ~0,

	Return = 1 << 0,
	This = 1 << 1,
	Params = 1 << 2,

	ReturnAndThis = Return | This,
	ReturnAndParams = Return | Params,
}}"
		.AddAsSource(nameof(RetypeTargets), context);

		$@"namespace {Shared.AttributesNamespace};
using System;

[Flags]
public enum ConversionTargets
{{
	None = 0,
	All = ~0,

	This = 1 << 1,
	Params = 1 << 2,

	ThisAndParams = This | Params,
}}"
		.AddAsSource(nameof(ConversionTargets), context);
	}

	private const string AttributeNameFull = $"{Shared.AttributesNamespace}.{nameof(RetypeAttribute)}";
	private static string Suffix(string type)
		=> $"_{nameof(Retype)}_{type}";
	private static string FilePath(string type, string originalFilePath)
	{
		var name = Path.GetFileNameWithoutExtension(originalFilePath);
		var extension = Path.GetExtension(originalFilePath);
		return $"{name}{Suffix(type)}{extension}";
	}

	private static SyntaxNode ProcessType(TypeSyntax original, string type)
		=> original.ReplaceNode(original, SyntaxFactory.IdentifierName(type));
	private static ArrowExpressionClauseSyntax ProcessMethodBody(MethodDeclarationSyntax method, RetypeDto dto)
	{
		var allParameters = method.ParameterList.Parameters;//.Select(parameter => parameter.Identifier.ToString());
		var methodName = method.Identifier.ToString();

		static string Rename(ParameterSyntax parameter, string postfix)
			=> parameter.HasIgnoreAttribute()
			? $"{parameter.Identifier}"
			: $"{parameter.Identifier}{postfix}";

		var thisParameterName = allParameters.First().Identifier.ToString();
		if (dto.ConversionTargets.HasFlag(ConversionTargets.This))
			thisParameterName += $".{dto.ConversionMethod}()";

		var otherParameters = allParameters.Skip(1);
		var otherParameterNames = dto.ConversionTargets.HasFlag(ConversionTargets.Params)
			? otherParameters.Select(parameter => Rename(parameter, $".{dto.ConversionMethod}()"))
			: otherParameters.Select(parameter => parameter.Identifier.ToString());

		var expressionText = $"{thisParameterName}.{methodName}({string.Join(", ", otherParameterNames)})";

		var expression = SyntaxFactory.ParseExpression(expressionText);
		return SyntaxFactory.ArrowExpressionClause(expression);
	}
	private static ClassDeclarationSyntax ProcessClass(ClassDeclarationSyntax original, string type)
	{
		var newName = original.Identifier + Suffix(type);
		return original.WithIdentifier(SyntaxFactory.Identifier(newName));
	}
	private static MethodDeclarationSyntax ProcessMethod(MethodDeclarationSyntax original, IReadOnlyDictionary<MethodSignature, RetypeDto> dtosLookup)
	{
		if (!dtosLookup.TryGetValue(original.Signature(), out var dto))
			return default;

		var parameterTypes = original.ParameterList.Parameters
			.Where(parameter => !parameter.HasIgnoreAttribute())
			.Select(parameter => parameter.Type);

		var typesToRetype = Enumerable.Empty<TypeSyntax>();
		if (dto.RetypeTargets.HasFlag(RetypeTargets.Return))
			typesToRetype = typesToRetype.Append(original.ReturnType);
		if (dto.RetypeTargets.HasFlag(RetypeTargets.This))
			typesToRetype = typesToRetype.Append(parameterTypes.First());
		if (dto.RetypeTargets.HasFlag(RetypeTargets.Params))
			typesToRetype = typesToRetype.Concat(parameterTypes.Skip(1));

		var retypedBody = ProcessMethodBody(original, dto);

		return original
			.ReplaceNodes(typesToRetype, (original, _) => ProcessType(original, dto.NewType))
			.WithExpressionBody(retypedBody)
			.RemoveAttributes(nameof(Retype));
	}
	internal static void ProcessSource(SourceProductionContext context, ImmutableArray<RetypeDto> dtos)
	{
		foreach (var (tree, dtosByTree) in dtos.GroupBy(dto => dto.Tree))
			foreach (var (type, dtosByTreeByType) in dtosByTree.GroupBy(dto => dto.NewType))
			{
				var filePath = FilePath(type, tree.FilePath);
				var dtosLookup = dtosByTreeByType.ToDictionary(dto => dto.MethodSignature);
				tree.GetRoot()
					.ReplaceDescendantNodes((MethodDeclarationSyntax method) => ProcessMethod(method, dtosLookup))
					.ReplaceDescendantNodes((ClassDeclarationSyntax @class) => ProcessClass(@class, type))
					.RemoveDescendantTrivia()
					.NormalizeWhitespace()
					.AddAsSource(filePath, context);
			}
	}
}