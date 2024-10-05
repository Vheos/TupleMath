namespace TupleMath.Generators.Retype;

[Flags]
public enum RetypeTargets
{
	None = 0,
	All = ~0,

	Return = 1 << 0,
	This = 1 << 1,
	Params = 1 << 2,

	ReturnAndThis = Return | This,
	ReturnAndParams = Return | Params,
	ThisAndParams = This | Params,
}