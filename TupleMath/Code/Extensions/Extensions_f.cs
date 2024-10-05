namespace TupleMath;

public static class Extensions_f
{
	#region Arithmetic

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Add(this f @this, f a)
		=> @this + a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Sub(this f @this, f a)
		=> @this - a;
	[MethodImpl(Inline), Vectorize]
	public static f Neg(this f @this)
		=> -@this;

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Mul(this f @this, f a)
		=> @this * a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Div(this f @this, f a)
		=> @this / a;
	[MethodImpl(Inline), Vectorize]
	public static f Inv(this f @this)
		=> 1f / @this;

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Pow(this f @this, f a)
		=> Extensions_d.Pow(@this.ToDouble(), a.ToDouble()).ToFloat();
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Root(this f @this, f a)
		=> Extensions_d.Root(@this.ToDouble(), a.ToDouble()).ToFloat();
	[MethodImpl(Inline), Vectorize]
	public static f Sqrd(this f @this)
		=> @this * @this;
	[MethodImpl(Inline), Vectorize]
	public static f Sqrt(this f @this)
		=> Extensions_d.Sqrt(@this.ToDouble()).ToFloat();

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Rem(this f @this, f a)
		=> @this % a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f ModEuclid(this f @this, f a)
		=> @this - a.Abs() * (@this / a.Abs()).RoundDown();
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f ModRound(this f @this, f a)
		=> @this - a * (@this / a).RoundToNearest();

	[MethodImpl(Inline), Vectorize]
	public static f Abs(this f @this)
		=> @this < 0f ? -@this : @this;
	[MethodImpl(Inline), Vectorize]
	public static i Sig(this f @this)
		=> @this.Compare(0f);

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Avg(this f @this, f a)
		=> (@this + a) / 2f;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Lerp(this f @this, f a, [Ignore] f alpha)
		=> @this + (a - @this) * alpha;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f LerpClamp(this f @this, f a, [Ignore] f alpha)
		=> alpha <= 0f ? @this : alpha >= 1f ? a : @this.Lerp(a, alpha);
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f Map(this f @this, f a, f b, f c, f d)
		=> (@this - a) * (d - c) / (b - a) + c;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static f MapClamp(this f @this, f a, f b, f c, f d)
		=> @this <= a ? c : @this >= b ? d : @this.Map(a, b, c, d);

	#endregion

	#region Comparisons

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsEqual(this f @this, f a)
		=> @this == a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsGreater(this f @this, f a)
		=> @this > a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsGreaterOrEqual(this f @this, f a)
		=> @this >= a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsLess(this f @this, f a)
		=> @this < a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsLessOrEqual(this f @this, f a)
		=> @this <= a;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static b IsBetween(this f @this, f a, f b)
		=> @this >= a && @this <= b;
	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(i), RetypeTargets.Params, nameof(ToFloat), ConversionTargets.Params)]
	public static i Compare(this f @this, f a)
		=> @this > a ? +1 : @this < a ? -1 : 0;

	[MethodImpl(Inline), Vectorize]
	public static b IsEven(this f @this)
		=> @this % 2f == 0f;
	[MethodImpl(Inline), Vectorize]
	public static b IsZero(this f @this)
		=> @this == 0f;
	[MethodImpl(Inline), Vectorize]
	public static b IsPositive(this f @this)
		=> @this > 0f;
	[MethodImpl(Inline), Vectorize]
	public static b IsNegative(this f @this)
		=> @this < 0f;

	#endregion

	#region Round

	[MethodImpl(Inline), Vectorize]
	public static i RoundToNearest(this f @this)
		=> Extensions_d.RoundToNearest(@this.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static i RoundDown(this f @this)
		=> Extensions_d.RoundDown(@this.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static i RoundUp(this f @this)
		=> Extensions_d.RoundUp(@this.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static i RoundTowardsZero(this f @this)
		=> Extensions_d.RoundTowardsZero(@this.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static i RoundAwayFromZero(this f @this)
		=> Extensions_d.RoundAwayFromZero(@this.ToDouble());
	[MethodImpl(Inline), Vectorize]
	public static i Round(this f @this, [Ignore] RoundingDirection direction)
		=> Extensions_d.Round(@this.ToDouble(), direction);

	[MethodImpl(Inline), Vectorize]
	public static i RoundToNearestMultiple(this f @this, i a)
		=> Extensions_d.RoundToNearestMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundDownToMultiple(this f @this, i a)
		=> Extensions_d.RoundDownToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundUpToMultiple(this f @this, i a)
		=> Extensions_d.RoundUpToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundTowardsZeroToMultiple(this f @this, i a)
		=> Extensions_d.RoundTowardsZeroToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundAwayFromZeroToMultiple(this f @this, i a)
		=> Extensions_d.RoundAwayFromZeroToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundToMultiple(this f @this, i a, [Ignore] RoundingDirection direction)
		=> Extensions_d.RoundToMultiple(@this, a, direction);

	#endregion

	#region Trigonometric

	[MethodImpl(Inline), Vectorize]
	public static f DegToRad(this f @this)
		=> @this * FloatDegToRad;
	[MethodImpl(Inline), Vectorize]
	public static f RadToDeg(this f @this)
		=> @this / FloatDegToRad;

	[MethodImpl(Inline), Vectorize]
	public static f Sin(this f @this)
		=> (f)Math.Sin(@this);
	[MethodImpl(Inline), Vectorize]
	public static f Cos(this f @this)
		=> (f)Math.Cos(@this);
	[MethodImpl(Inline), Vectorize]
	public static f Tan(this f @this)
		=> (f)Math.Tan(@this);
	[MethodImpl(Inline), Vectorize]
	public static f Cot(this f @this)
		=> @this.Tan().Inv();
	[MethodImpl(Inline), Vectorize]
	public static f Sec(this f @this)
		=> @this.Cos().Inv();
	[MethodImpl(Inline), Vectorize]
	public static f Csc(this f @this)
		=> @this.Sin().Inv();

	[MethodImpl(Inline), Vectorize]
	public static f ArcSin(this f @this)
		=> (f)Math.Asin(@this);
	[MethodImpl(Inline), Vectorize]
	public static f ArcCos(this f @this)
		=> (f)Math.Acos(@this);
	[MethodImpl(Inline), Vectorize]
	public static f ArcTan(this f @this)
		=> (f)Math.Atan(@this);
	[MethodImpl(Inline), Vectorize]
	public static f ArcCot(this f @this)
		=> @this.Inv().ArcTan();
	[MethodImpl(Inline), Vectorize]
	public static f ArcSec(this f @this)
		=> @this.Inv().ArcCos();
	[MethodImpl(Inline), Vectorize]
	public static f ArcCsc(this f @this)
		=> @this.Inv().ArcSin();

	#endregion

	#region Comparison

	[MethodImpl(Inline), Vectorize]
	public static f Min(this f @this, f a)
		=> @this <= a ? @this : a;
	[MethodImpl(Inline), Vectorize]
	public static f Max(this f @this, f a)
		=> @this >= a ? @this : a;
	[MethodImpl(Inline), Vectorize]
	public static f Clamp(this f @this, f a, f b)
		=> @this < a ? a : @this > b ? b : @this;
	[MethodImpl(Inline), Vectorize]
	public static f ClampMin(this f @this, f a)
		=> @this.Max(a);
	[MethodImpl(Inline), Vectorize]
	public static f ClampMax(this f @this, f a)
		=> @this.Min(a);

	#endregion

	#region Conversion
	[MethodImpl(Inline)]
	public static b ToBool(this f @this)
		=> @this > 0f;
	[MethodImpl(Inline)]
	public static i ToInt(this f @this)
		=> (i)@this;
	[MethodImpl(Inline)]
	public static l ToLong(this f @this)
		=> (l)@this;
	[MethodImpl(Inline)]
	private static f ToFloat(this f @this)
		=> @this;
	[MethodImpl(Inline)]
	public static d ToDouble(this f @this)
		=> (d)@this;

	#endregion
}