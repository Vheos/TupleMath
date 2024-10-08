﻿namespace TupleMath;

public static class Extensions_d
{
	[MethodImpl(Inline)]
	public static d Inv(this d @this)
		=> 1d / @this;

	[MethodImpl(Inline)]
	public static d Pow(this d @this, d a)
		=> Math.Pow(@this, a);
	[MethodImpl(Inline)]
	public static d Root(this d @this, d a)
		=> @this.Pow(a.Inv());
	[MethodImpl(Inline)]
	public static d Sqrt(this d @this)
		=> Math.Sqrt(@this);
	[MethodImpl(Inline)]
	public static d Sqrd(this d @this)
		=> @this * @this;

	#region Round

	[MethodImpl(Inline), Vectorize]
	public static i RoundToNearest(this d @this)
		=> (i)Math.Round(@this, MidpointRounding.AwayFromZero);
	[MethodImpl(Inline), Vectorize]
	public static i RoundDown(this d @this)
		=> (i)Math.Floor(@this);
	[MethodImpl(Inline), Vectorize]
	public static i RoundUp(this d @this)
		=> (i)Math.Ceiling(@this);
	[MethodImpl(Inline), Vectorize]
	public static i RoundTowardsZero(this d @this)
		=> @this > 0d ? @this.RoundDown() : @this.RoundUp();
	[MethodImpl(Inline), Vectorize]
	public static i RoundAwayFromZero(this d @this)
		=> @this > 0d ? @this.RoundUp() : @this.RoundDown();
	[Vectorize]
	public static i Round(this d @this, [Ignore] RoundingDirection direction)
		=> direction switch
		{
			RoundingDirection.ToNearest => @this.RoundToNearest(),
			RoundingDirection.Down => @this.RoundDown(),
			RoundingDirection.Up => @this.RoundUp(),
			RoundingDirection.TowardsZero => @this.RoundTowardsZero(),
			RoundingDirection.AwayFromZero => @this.RoundAwayFromZero(),
			_ => throw new ArgumentException(),
		};

	[MethodImpl(Inline), Vectorize]
	public static i RoundToNearestMultiple(this d @this, i a)
		=> (@this / a).RoundToNearest() * a;
	[MethodImpl(Inline), Vectorize]
	public static i RoundDownToMultiple(this d @this, i a)
		=> (@this / a).RoundDown() * a;
	[MethodImpl(Inline), Vectorize]
	public static i RoundUpToMultiple(this d @this, i a)
		=> (@this / a).RoundUp() * a;
	[MethodImpl(Inline), Vectorize]
	public static i RoundTowardsZeroToMultiple(this d @this, i a)
		=> (@this / a).RoundTowardsZero() * a;
	[MethodImpl(Inline), Vectorize]
	public static i RoundAwayFromZeroToMultiple(this d @this, i a)
		=> (@this / a).RoundAwayFromZero() * a;
	[Vectorize]
	public static i RoundToMultiple(this d @this, i a, [Ignore] RoundingDirection direction)
		=> direction switch
		{
			RoundingDirection.ToNearest => @this.RoundToNearestMultiple(a),
			RoundingDirection.Down => @this.RoundDownToMultiple(a),
			RoundingDirection.Up => @this.RoundUpToMultiple(a),
			RoundingDirection.TowardsZero => @this.RoundTowardsZeroToMultiple(a),
			RoundingDirection.AwayFromZero => @this.RoundAwayFromZeroToMultiple(a),
			_ => throw new ArgumentException(),
		};

	/*
	[MethodImpl(Inline), Vectorize]
	public static d RoundToNearestMultiple(this d @this, d a)
		=> (@this / a).RoundToNearest() * a;
	[MethodImpl(Inline), Vectorize]
	public static d RoundDownToMultiple(this d @this, d a)
		=> (@this / a).RoundDown() * a;
	[MethodImpl(Inline), Vectorize]
	public static d RoundUpToMultiple(this d @this, d a)
		=> (@this / a).RoundUp() * a;
	[MethodImpl(Inline), Vectorize]
	public static d RoundTowardsZeroToMultiple(this d @this, d a)
		=> (@this / a).RoundTowardsZero() * a;
	[MethodImpl(Inline), Vectorize]
	public static d RoundAwayFromZeroToMultiple(this d @this, d a)
		=> (@this / a).RoundAwayFromZero() * a;
	[Vectorize]
	public static d RoundToMultiple(this d @this, d a, RoundingDirection direction)
		=> direction switch
		{
			RoundingDirection.ToNearest => @this.RoundToNearestMultiple(a),
			RoundingDirection.Down => @this.RoundDownToMultiple(a),
			RoundingDirection.Up => @this.RoundUpToMultiple(a),
			RoundingDirection.TowardsZero => @this.RoundTowardsZeroToMultiple(a),
			RoundingDirection.AwayFromZero => @this.RoundAwayFromZeroToMultiple(a),
			_ => throw new ArgumentException(),
		};
	*/

	#endregion

	#region Conversion

	[MethodImpl(Inline)]
	public static b ToBool(this d @this)
		=> @this > 0d;
	[MethodImpl(Inline)]
	public static i ToInt(this d @this)
		=> (i)@this;
	[MethodImpl(Inline)]
	public static l ToLong(this d @this)
		=> (l)@this;
	[MethodImpl(Inline)]
	public static f ToFloat(this d @this)
		=> (f)@this;
	[MethodImpl(Inline)]
	static d ToDouble(this d @this)
		=> @this;

	#endregion
}