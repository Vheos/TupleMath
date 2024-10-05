namespace TupleMath.Generators.ExtraPass;
using System.IO;
using System.Threading;
using TupleMath.Generators.Extensions;
using TupleMath.Generators.Retype;
using TupleMath.Generators.Vectorize;

[Generator]
public class ExtraPass : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		return;

		// Vectorize retyped methods
		var retypedMethodsToVectorize = context.AdditionalTextsProvider
			.Where(file => Path.GetFileNameWithoutExtension(file.Path).Contains(nameof(Retype)))
			.SelectMany(GetAttributedMethodsFromFile)
			.Collect();
		context.RegisterSourceOutput(retypedMethodsToVectorize, Vectorize.ProcessSource);
	}

	private static IEnumerable<MethodDeclarationSyntax> GetAttributedMethodsFromFile(AdditionalText file, CancellationToken cancellationToken)
		=> CSharpSyntaxTree.ParseText(
			text: file.GetText(cancellationToken).ToString(),
			path: file.Path)
		.GetRoot()
		.DescendantsOfType<MethodDeclarationSyntax>()
		.Where(method => method.GetAttributes(nameof(Vectorize)).Any());
}