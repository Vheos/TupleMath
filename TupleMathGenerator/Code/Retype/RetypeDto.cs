namespace TupleMathGenerator.Retype;
using TupleMathGenerator.Shared;

public struct RetypeDto(MethodDeclarationSyntax method) : IEquatable<RetypeDto>
{
	// Fields
	public readonly MethodSignature MethodSignature = new(method);
	public string NewType { get; set; }
	public RetypeTargets RetypeTargets { get; set; }
	public string ConversionMethod { get; set; }
	public ConversionTargets ConversionTargets { get; set; }
	public readonly SyntaxTree Tree = method.SyntaxTree;

	// Methods
	public readonly bool Equals(RetypeDto other)
		=> MethodSignature == other.MethodSignature
		&& NewType == other.NewType
		&& RetypeTargets == other.RetypeTargets
		&& ConversionMethod == other.ConversionMethod
		&& ConversionTargets == other.ConversionTargets;
}
