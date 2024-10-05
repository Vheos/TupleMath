namespace TupleMathGenerator.Shared;
using System.Text;
using TupleMathGenerator.Extensions;

[Generator]
internal class Shared : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		context.RegisterPostInitializationOutput(GenerateTypeAliases);
		context.RegisterPostInitializationOutput(GenerateIgnoreAttribute);
	}

	// Settings
	internal const string IgnoreAttributeShortName = "Ignore"; 
	internal const string AttributesFilePath = "Attributes";
	internal const string AttributesNamespace = $"{nameof(TupleMathGenerator)}.{AttributesFilePath}";
	internal const string TypeAliasesFilePath = "TypeAliases";
	internal static readonly IReadOnlyDictionary<string, Type> TypesByAlias = new Dictionary<string, Type>()
	{
		{ "b", typeof(bool) },
		{ "i", typeof(int) },
		{ "l", typeof(long) },
		{ "f", typeof(float) },
		{ "d", typeof(double) },
	};
	internal static string GetAttributeMetadataName(string attributeShortName)
		=> $"{AttributesNamespace}.{attributeShortName}Attribute";
	private static void GenerateTypeAliases(IncrementalGeneratorPostInitializationContext context)
	{
		StringBuilder stringBuilder = new();
		foreach (var (alias, type) in TypesByAlias)
			stringBuilder.AppendLine($"global using {alias} = {type};");

		stringBuilder.AddAsSource(TypeAliasesFilePath, context);
	}
	private static void GenerateIgnoreAttribute(IncrementalGeneratorPostInitializationContext context)
	{
		$@"namespace {AttributesNamespace};
using System;

[AttributeUsage(AttributeTargets.Parameter)]
public class IgnoreAttribute : Attribute
{{ }}"
			.AddAsSource(nameof(IgnoreAttribute), context);
	}
}