namespace TupleMath;

public static class Extensions_g2
{
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Append<g>(this (g X, g Y) @this)
		=> (@this.X, @this.Y, default);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Append<g>(this (g X, g Y) @this, g a)
		=> (@this.X, @this.Y, a);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Append<g>(this (g X, g Y) @this, (g X, g Y) a)
		=> (@this.X, @this.Y, a.X, a.Y);

	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Prepend<g>(this (g X, g Y) @this)
		=> (default, @this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Prepend<g>(this (g X, g Y) @this, g a)
		=> (a, @this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Prepend<g>(this (g X, g Y) @this, (g X, g Y) a)
		=> (a.X, a.Y, @this.X, @this.Y);

	[MethodImpl(Inline)]
	public static (g X, g Y) NewX<g>(this (g X, g Y) @this, g x)
		=> (x, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) NewY<g>(this (g X, g Y) @this, g y)
		=> (@this.X, y);

	[MethodImpl(Inline)]
	public static g To1<g>(this (g X, g Y) @this)
		=> @this.X;
	[MethodImpl(Inline)]
	static (g X, g Y) To2<g>(this (g X, g Y) @this)
		=> @this;
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) To3<g>(this (g X, g Y) @this)
		=> (@this.X, @this.Y, default);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) To4<g>(this (g X, g Y) @this)
		=> (@this.X, @this.Y, default, default);

	#region Components

	[MethodImpl(Inline)]
	public static (g X, g Y) XX<g>(this (g X, g Y) @this)
		=> (@this.X, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) XY<g>(this (g X, g Y) @this)
		=> (@this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) YX<g>(this (g X, g Y) @this)
		=> (@this.Y, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) YY<g>(this (g X, g Y) @this)
		=> (@this.Y, @this.Y);

	#endregion
}