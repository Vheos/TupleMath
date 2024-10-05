namespace TupleMath.Generators.Retype;

[Flags]
public enum ConversionTargets
{
	None = 0,
	All = ~0,

	This = 1 << 1,
	Params = 1 << 2,

	ThisAndParams = This | Params,
}