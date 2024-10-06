namespace TupleMath;

public static partial class Extensions_i
{
	#region Arithmetic

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(l), RetypeTargets.ReturnAndParams, nameof(ToLong), ConversionTargets.This)]
	[Retype(nameof(f), RetypeTargets.ReturnAndParams, nameof(ToFloat), ConversionTargets.This)]
	[Retype(nameof(d), RetypeTargets.ReturnAndParams, nameof(ToDouble), ConversionTargets.This)]
	[Retype(nameof(c), RetypeTargets.ReturnAndParams, nameof(ToDecimal), ConversionTargets.This)]
	public static i Add(this i @this, i a)
		=> @this + a;

	[MethodImpl(Inline), Vectorize]
	public static i Sub(this i @this, i a)
		=> @this - a;

	[MethodImpl(Inline), Vectorize]
	public static i Neg(this i @this)
		=> -@this;

	[MethodImpl(Inline), Vectorize]
	public static i Mul(this i @this, i a)
		=> @this * a;

	[MethodImpl(Inline), Vectorize]
	[Retype(nameof(f), RetypeTargets.ReturnAndParams, nameof(ToFloat), ConversionTargets.This)]
	[Retype(nameof(d), RetypeTargets.ReturnAndParams, nameof(ToDouble), ConversionTargets.This)]
	public static f Div(this i @this, i a)
		=> Extensions_f.Div(@this.ToFloat(), a.ToFloat());
	[MethodImpl(Inline), Vectorize]
	public static d Div(this i @this, l a)
		=> Extensions_d.Div(@this.ToDouble(), a.ToDouble());

	[MethodImpl(Inline), Vectorize]
	public static f Inv(this i @this)
		=> Extensions_f.Inv(@this.ToFloat());

	[MethodImpl(Inline), Vectorize]
	public static f Pow(this i @this, i a)
		=> Extensions_f.Pow(@this.ToFloat(), a.ToFloat());
	[MethodImpl(Inline), Vectorize]
	public static f Root(this i @this, i a)
		=> Extensions_f.Root(@this.ToFloat(), a.ToFloat());
	[MethodImpl(Inline), Vectorize]
	public static i Sqrd(this i @this)
		=> @this * @this;
	[MethodImpl(Inline), Vectorize]
	public static f Sqrt(this i @this)
		=> Extensions_f.Sqrt(@this.ToFloat());

	[MethodImpl(Inline), Vectorize]
	public static i Rem(this i @this, i a)
		=> @this % a;
	[MethodImpl(Inline), Vectorize]
	public static i ModEuclid(this i @this, i a)
		=> @this - a.Abs() * (@this.ToFloat() / a.Abs()).RoundDown();
	[MethodImpl(Inline), Vectorize]
	public static i ModRound(this i @this, i a)
		=> @this - a * (@this.ToFloat() / a).RoundToNearest();

	[MethodImpl(Inline), Vectorize]
	public static i Abs(this i @this)
		=> @this < 0 ? -@this : @this;
	[MethodImpl(Inline), Vectorize]
	public static i Sig(this i @this)
		=> @this.Compare(0);

	[MethodImpl(Inline), Vectorize]
	public static f Avg(this i @this, i a)
		=> Extensions_f.Avg(@this.ToFloat(), a.ToFloat());
	[MethodImpl(Inline), Vectorize]
	public static f Lerp(this i @this, i a, [Ignore] f alpha)
		=> Extensions_f.Lerp(@this.ToFloat(), a.ToFloat(), alpha);
	[MethodImpl(Inline), Vectorize]
	public static f LerpClamp(this i @this, i a, [Ignore] f alpha)
		=> Extensions_f.LerpClamp(@this.ToFloat(), a.ToFloat(), alpha);
	[MethodImpl(Inline), Vectorize]
	public static f Map(this i @this, i a, i b, i c, i d)
		=> Extensions_f.Map(@this.ToFloat(), a.ToFloat(), b.ToFloat(), c.ToFloat(), d.ToFloat());
	[MethodImpl(Inline), Vectorize]
	public static f MapClamp(this i @this, i a, i b, i c, i d)
		=> Extensions_f.MapClamp(@this.ToFloat(), a.ToFloat(), b.ToFloat(), c.ToFloat(), d.ToFloat());

	#endregion

	#region Comparisons

	[MethodImpl(Inline), Vectorize]
	public static b IsEqual(this i @this, i a)
		=> @this == a;
	[MethodImpl(Inline), Vectorize]
	public static b IsGreater(this i @this, i a)
		=> @this > a;
	[MethodImpl(Inline), Vectorize]
	public static b IsGreaterOrEqual(this i @this, i a)
		=> @this >= a;
	[MethodImpl(Inline), Vectorize]
	public static b IsLess(this i @this, i a)
		=> @this < a;
	[MethodImpl(Inline), Vectorize]
	public static b IsLessOrEqual(this i @this, i a)
		=> @this <= a;
	[MethodImpl(Inline), Vectorize]
	public static b IsBetween(this i @this, i a, i b)
		=> @this >= a && @this <= b;
	[MethodImpl(Inline), Vectorize]
	public static i Compare(this i @this, i a)
		=> @this > a ? +1 : @this < a ? -1 : 0;

	[MethodImpl(Inline), Vectorize]
	public static b IsEven(this i @this)
		=> @this % 2 == 0;
	[MethodImpl(Inline), Vectorize]
	public static b IsZero(this i @this)
		=> @this == 0;
	[MethodImpl(Inline), Vectorize]
	public static b IsPositive(this i @this)
		=> @this > 0;
	[MethodImpl(Inline), Vectorize]
	public static b IsNegative(this i @this)
		=> @this < 0;

	#endregion

	#region Bitwise operations

	[MethodImpl(Inline), Vectorize]
	public static i BitAnd(this i @this, i a)
		=> @this & a;
	[MethodImpl(Inline), Vectorize]
	public static i BitOr(this i @this, i a)
		=> @this | a;
	[MethodImpl(Inline), Vectorize]
	public static i BitXor(this i @this, i a)
		=> @this ^ a;
	[MethodImpl(Inline), Vectorize]
	public static i BitShiftLeft(this i @this, i a)
		=> @this << a;
	[MethodImpl(Inline), Vectorize]
	public static i BitShiftRight(this i @this, i a)
		=> @this >> a;

	#endregion

	#region Round

	[MethodImpl(Inline), Vectorize]
	public static i RoundToNearestMultiple(this i @this, i a)
		=> Extensions_f.RoundToNearestMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundDownToMultiple(this i @this, i a)
		=> Extensions_f.RoundDownToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundUpToMultiple(this i @this, i a)
		=> Extensions_f.RoundUpToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundTowardsZeroToMultiple(this i @this, i a)
		=> Extensions_f.RoundTowardsZeroToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundAwayFromZeroToMultiple(this i @this, i a)
		=> Extensions_f.RoundAwayFromZeroToMultiple(@this, a);
	[MethodImpl(Inline), Vectorize]
	public static i RoundToMultiple(this i @this, i a, [Ignore] RoundingDirection direction)
		=> Extensions_f.RoundToMultiple(@this, a, direction);

	/*
	[MethodImpl(Inline), Vectorize]
	public static f RoundToMultiple(this i @this, f a)
		=> @this.ToFloat().RoundToMultiple(a);
	[MethodImpl(Inline), Vectorize]
	public static f RoundDownToMultiple(this i @this, f a)
		=> @this.ToFloat().RoundDownToMultiple(a);
	[MethodImpl(Inline), Vectorize]
	public static f RoundUpToMultiple(this i @this, f a)
		=> @this.ToFloat().RoundUpToMultiple(a);
	[MethodImpl(Inline), Vectorize]
	public static f RoundTowardsZeroToMultiple(this i @this, f a)
		=> @this.ToFloat().RoundTowardsZeroToMultiple(a);
	[MethodImpl(Inline), Vectorize]
	public static f RoundAwayFromZeroToMultiple(this i @this, f a)
		=> @this.ToFloat().RoundAwayFromZeroToMultiple(a);
	*/

	#endregion

	#region Trigonometric

	[MethodImpl(Inline), Vectorize]
	public static f DegToRad(this i @this)
		=> @this.ToFloat().DegToRad();
	[MethodImpl(Inline), Vectorize]
	public static f RadToDeg(this i @this)
		=> @this.ToFloat().RadToDeg();

	[MethodImpl(Inline), Vectorize]
	public static f Sin(this i @this)
		=> @this.ToFloat().Sin();
	[MethodImpl(Inline), Vectorize]
	public static f Cos(this i @this)
		=> @this.ToFloat().Cos();
	[MethodImpl(Inline), Vectorize]
	public static f Tan(this i @this)
		=> @this.ToFloat().Tan();
	[MethodImpl(Inline), Vectorize]
	public static f Cot(this i @this)
		=> @this.ToFloat().Cot();
	[MethodImpl(Inline), Vectorize]
	public static f Sec(this i @this)
		=> @this.ToFloat().Sec();
	[MethodImpl(Inline), Vectorize]
	public static f Csc(this i @this)
		=> @this.ToFloat().Csc();

	[MethodImpl(Inline), Vectorize]
	public static f ArcSin(this i @this)
		=> @this.ToFloat().ArcSin();
	[MethodImpl(Inline), Vectorize]
	public static f ArcCos(this i @this)
		=> @this.ToFloat().ArcCos();
	[MethodImpl(Inline), Vectorize]
	public static f ArcTan(this i @this)
		=> @this.ToFloat().ArcTan();
	[MethodImpl(Inline), Vectorize]
	public static f ArcCot(this i @this)
		=> @this.ToFloat().ArcCot();
	[MethodImpl(Inline), Vectorize]
	public static f ArcSec(this i @this)
		=> @this.ToFloat().ArcSec();
	[MethodImpl(Inline), Vectorize]
	public static f ArcCsc(this i @this)
		=> @this.ToFloat().ArcCsc();

	#endregion

	#region Comparison

	[MethodImpl(Inline), Vectorize]
	public static i Min(this i @this, i a)
		=> @this <= a ? @this : a;
	[MethodImpl(Inline), Vectorize]
	public static i Max(this i @this, i a)
		=> @this >= a ? @this : a;
	[MethodImpl(Inline), Vectorize]
	public static i Clamp(this i @this, i a, i b)
		=> @this < a ? a : @this > b ? b : @this;
	[MethodImpl(Inline), Vectorize]
	public static i ClampMin(this i @this, i a)
		=> @this.Max(a);
	[MethodImpl(Inline), Vectorize]
	public static i ClampMax(this i @this, i a)
		=> @this.Min(a);

	#endregion

	#region Conversion
#pragma warning disable IDE0004   // Remove unnecessary cast

	[MethodImpl(Inline), Vectorize]
	public static b ToBool(this i @this)
		=> @this >= 1;
	private static i ToInt(this i @this)
		=> @this;
	[MethodImpl(Inline), Vectorize]
	public static l ToLong(this i @this)
		=> (l)@this;
	[MethodImpl(Inline), Vectorize]
	public static f ToFloat(this i @this)
		=> (f)@this;
	[MethodImpl(Inline), Vectorize]
	public static d ToDouble(this i @this)
		=> (d)@this;
	[MethodImpl(Inline), Vectorize]
	public static c ToDecimal(this i @this)
		=> (c)@this;

#pragma warning restore
	#endregion
}