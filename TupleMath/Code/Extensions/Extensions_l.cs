namespace TupleMath;

public static partial class Extensions_l
{
	#region Arithmetic

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToLong), ConversionTargets.Params)]
	[Retype(nameof(f), RetypeTargets.ReturnAndParams, nameof(ToFloat), ConversionTargets.This)]
	[Retype(nameof(d), RetypeTargets.ReturnAndParams, nameof(ToDouble), ConversionTargets.This)]
	[Retype(nameof(c), RetypeTargets.ReturnAndParams, nameof(ToDecimal), ConversionTargets.This)]
	public static l Add(this l @this, l a)
		=> @this + a;
	[MethodImpl(Inline), Vectorize]
	public static l Sub(this l @this, l a)
		=> @this - a;
	[MethodImpl(Inline), Vectorize]
	public static l Neg(this l @this)
		=> -@this;

	[MethodImpl(Inline), Vectorize]
	public static l Mul(this l @this, l a)
		=> @this * a;
	[MethodImpl(Inline), Vectorize]
	public static l Div(this l @this, l a)
		=> @this / a;
	[MethodImpl(Inline), Vectorize]
	public static d Inv(this l @this)
		=> Extensions_d.Inv(@this.ToDouble());

	[MethodImpl(Inline), Vectorize]
	public static d Pow(this l @this, l a)
		=> Extensions_d.Pow(@this.ToDouble(), a.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static d Root(this l @this, l a)
		=> Extensions_d.Root(@this.ToDouble(), a.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static l Sqrd(this l @this)
		=> @this * @this;
	[MethodImpl(Inline), Vectorize]
	public static d Sqrt(this l @this)
		=> Extensions_d.Sqrt(@this.ToDouble());

	#endregion

	#region Conversion
#pragma warning disable IDE0004   // Remove unnecessary cast

	[MethodImpl(Inline), Vectorize]
	public static b ToBool(this l @this)
		=> @this >= 1L;
	[MethodImpl(Inline), Vectorize]
	public static i ToInt(this l @this)
		=> (i)@this;
	private static l ToLong(this l @this)
		=> @this;
	[MethodImpl(Inline), Vectorize]
	public static f ToFloat(this l @this)
		=> (f)@this;
	[MethodImpl(Inline), Vectorize]
	public static d ToDouble(this l @this)
		=> (d)@this;
	[MethodImpl(Inline), Vectorize]
	public static c ToDecimal(this l @this)
		=> (c)@this;

#pragma warning restore
	#endregion
}