namespace TupleMath.Generators.Shared;

public readonly struct MethodSignature : IEquatable<MethodSignature>
{
	// Fields
	private readonly string[] tokens;

	// Constructors
	public MethodSignature(MethodDeclarationSyntax method)
	{
		var parameters = method.ParameterList.Parameters;
		tokens = new string[parameters.Count + 1];

		tokens[0] = method.Identifier.ToString();
		for (var i = 0; i < parameters.Count; i++)
			tokens[i + 1] = parameters[i].Type.ToString();
	}

	// Methods
	public string Name
		=> tokens[0];
	public IEnumerable<string> ParameterTypes
		=> tokens.Skip(1);
	public bool Equals(MethodSignature other)
		=> tokens.SequenceEqual(other.tokens);
	public override bool Equals(object other)
		=> other is MethodSignature otherMethodSignature
		&& Equals(otherMethodSignature);
	public override int GetHashCode()
	{
		var hashCode = 0;
		if (tokens != null)
			foreach (var token in tokens)
				hashCode ^= token.GetHashCode();

		return hashCode;
	}
	public override string ToString()
		=> $"{Name}({string.Join(", ", ParameterTypes)})";

	// Operators
	public static bool operator ==(MethodSignature a, MethodSignature b)
		=> a.Equals(b);
	public static bool operator !=(MethodSignature a, MethodSignature b)
		=> !a.Equals(b);
}