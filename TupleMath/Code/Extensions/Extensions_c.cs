namespace TupleMath;

public static partial class Extensions_c
{
	#region Arithmetic

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToDecimal), ConversionTargets.Params)]
	[Retype(nameof(l), RetypeTargets.Params, nameof(ToDecimal), ConversionTargets.Params)]
	[Retype(nameof(f), RetypeTargets.Params, nameof(ToDecimal), ConversionTargets.Params)]
	[Retype(nameof(d), RetypeTargets.Params, nameof(ToDecimal), ConversionTargets.Params)]
	public static c Add(this c @this, c a)
		=> @this + a;
	[MethodImpl(Inline), Vectorize]
	public static c Sub(this c @this, c a)
		=> @this - a;
	[MethodImpl(Inline), Vectorize]
	public static c Neg(this c @this)
		=> -@this;

	[MethodImpl(Inline), Vectorize]
	public static c Mul(this c @this, c a)
		=> @this * a;
	[MethodImpl(Inline), Vectorize]
	public static c Div(this c @this, c a)
		=> @this / a;
	[MethodImpl(Inline), Vectorize]
	public static c Inv(this c @this)
		=> 1m / @this;

	[MethodImpl(Inline), Vectorize]
	public static c Pow(this c @this, c a)
		=> Extensions_d.Pow(@this.ToDouble(), a.ToDouble()).ToDecimal();
	[MethodImpl(Inline), Vectorize]
	public static c Root(this c @this, c a)
		=> Extensions_d.Root(@this.ToDouble(), a.ToDouble()).ToDecimal();
	[MethodImpl(Inline), Vectorize]
	public static c Sqrd(this c @this)
		=> @this * @this;
	[MethodImpl(Inline), Vectorize]
	public static c Sqrt(this c @this)
		=> Extensions_d.Sqrt(@this.ToDouble()).ToDecimal();

	#endregion

	#region Conversion

	[MethodImpl(Inline), Vectorize]
	public static b ToBool(this c @this)
		=> @this >= 1m;
	[MethodImpl(Inline), Vectorize]
	public static i ToInt(this c @this)
		=> (i)@this;
	[MethodImpl(Inline), Vectorize]
	public static l ToLong(this c @this)
		=> (l)@this;
	[MethodImpl(Inline), Vectorize]
	public static f ToFloat(this c @this)
		=> (f)@this;
	[MethodImpl(Inline), Vectorize]
	public static d ToDouble(this c @this)
		=> (d)@this;
	private static c ToDecimal(this c @this)
		=> @this;

	#endregion
}