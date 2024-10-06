namespace TupleMathGenerator.Extensions;
using System;
using System.IO;
using System.Threading;
using TupleMathGenerator.Shared;

internal static class Extensions
{
	public static T GetConstructorParameter<T>(this AttributeData @this, int index)
		=> index >= 0 && index < @this.ConstructorArguments.Length
		? (T)@this.ConstructorArguments[index].Value
		: default;
	public static string GetFileNameWithSuffix(this string @this, string text)
	{
		var fileName = Path.GetFileNameWithoutExtension(@this);
		var fileExtension = Path.GetExtension(@this);
		return Path.Combine(fileName + text + fileExtension);
	}
	public static IEnumerable<T> DescendantsOfType<T>(this SyntaxNode @this, bool descendIntoSameType = false)
		where T : SyntaxNode
	{
		Func<SyntaxNode, bool> descendSelector =
			!descendIntoSameType
			? node => node is not T
			: null;

		return @this
			.DescendantNodes(descendSelector, false)
			.OfType<T>();
	}
	public static bool HasIgnoreAttribute(this ParameterSyntax @this)
		=> @this.AttributeLists.TryGetAttribute(out _, Shared.IgnoreAttributeShortName);
	public static bool TryGetAttribute(this SyntaxList<AttributeListSyntax> @this, out AttributeSyntax attributeSyntax, string attributeName)
	{
		attributeSyntax = @this
			.SelectMany(attributeList => attributeList.Attributes)
			.FirstOrDefault(attribute => attribute.Name.ToString() == attributeName);

		return attributeSyntax != null;
	}
	public static bool TryGetAttribute(this MemberDeclarationSyntax @this, out AttributeSyntax attributeSyntax, string attributeName)
		=> @this.AttributeLists.TryGetAttribute(out attributeSyntax, attributeName);
	public static IEnumerable<AttributeSyntax> GetAttributes(this MemberDeclarationSyntax @this, params string[] attributeShortNames)
		=> @this.AttributeLists
		.SelectMany(attributeList => attributeList.Attributes)
		.Where(attribute => attributeShortNames.Contains(attribute.Name.ToString()));
	public static T RemoveAttributes<T>(this T @this, params string[] attributeShortName)
		where T : MemberDeclarationSyntax
	{
		var attributesToRemove = @this.GetAttributes(attributeShortName);
		var newNode = @this.RemoveNodes(attributesToRemove, SyntaxRemoveOptions.KeepNoTrivia);
		newNode = newNode.RemoveEmptyAttributeLists();

		return newNode;
	}
	public static T RemoveEmptyAttributeLists<T>(this T @this)
		where T : MemberDeclarationSyntax
	{
		var emptyAttributeLists = @this.AttributeLists.Where(attributeList => attributeList.Attributes.Count == 0);
		return @this.RemoveNodes(emptyAttributeLists, SyntaxRemoveOptions.KeepNoTrivia);
	}
	public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> @this, out T1 key, out T2 value)
	{
		key = @this.Key;
		value = @this.Value;
	}
	public static void Deconstruct<T1, T2>(this IGrouping<T1, T2> @this, out T1 key, out IEnumerable<T2> value)
	{
		key = @this.Key;
		value = @this;
	}
	public static MethodSignature Signature(this MethodDeclarationSyntax @this)
		=> new(@this);
	public static string Namespace(this string @this, string @namespace)
		=> $"namespace {@namespace};\r\n{@this}";
	public static string Using(this string @this, string @using)
		=> $"using {@using};\r\n{@this}";
	public static void AddAsSource(this object @this, string filePath, IncrementalGeneratorPostInitializationContext context)
		=> context.AddSource(filePath, @this.ToString());
	public static void AddAsSource(this object @this, string filePath, SourceProductionContext context)
		=> context.AddSource(filePath, @this.ToString());
	public static BaseNamespaceDeclarationSyntax Namespace(this SyntaxNode node)
	{
		while (node != null)
			if (node is BaseNamespaceDeclarationSyntax namespaceSyntaxNode)
				return namespaceSyntaxNode;
			else
				node = node.Parent;

		return null;
	}
	public static bool IsPartial(this ClassDeclarationSyntax @this)
		=> @this.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword));

	public static TRoot ReplaceDescendantNodes<TRoot, TNode>(this TRoot @this, Func<TNode, TNode> selector)
		where TRoot : SyntaxNode
		where TNode : SyntaxNode
		=> @this.ReplaceNodes(@this.DescendantNodes().OfType<TNode>(), (original, rewritten) => selector(original));
	public static TRoot RemoveDescendantTrivia<TRoot>(this TRoot @this)
		where TRoot : SyntaxNode
		=> @this.ReplaceTrivia(@this.DescendantTrivia(), (_, _) => default);

	public static bool IsExtensionMethod(this SyntaxNode @this, CancellationToken _)
		=> @this is MethodDeclarationSyntax method
		&& method.ParameterList.Parameters.Count > 0
		&& method.ParameterList.Parameters[0].Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.ThisKeyword));
}
