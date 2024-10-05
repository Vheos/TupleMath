namespace TupleMath;

public static class Extensions_g4
{
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) NewX<g>(this (g X, g Y, g Z, g W) @this, g x)
		=> (x, @this.Y, @this.Z, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) NewY<g>(this (g X, g Y, g Z, g W) @this, g y)
		=> (@this.X, y, @this.Z, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) NewZ<g>(this (g X, g Y, g Z, g W) @this, g z)
		=> (@this.X, @this.Y, z, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) NewW<g>(this (g X, g Y, g Z, g W) @this, g w)
		=> (@this.X, @this.Y, @this.Z, w);

	[MethodImpl(Inline)]
	public static g To1<g>(this (g X, g Y, g Z, g W) @this)
		=> @this.X;
	[MethodImpl(Inline)]
	public static (g X, g Y) To2<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) To3<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.Y, @this.Z);
	[MethodImpl(Inline)]
	static (g X, g Y, g Z, g W) To4<g>(this (g X, g Y, g Z, g W) @this)
		=> @this;

	#region Components

	// 4^2 = 16
	[MethodImpl(Inline)]
	public static (g X, g Y) XX<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) XY<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) XZ<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) XW<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.X, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y) YX<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Y, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) YY<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Y, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) YZ<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Y, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) YW<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Y, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZX<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Z, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZY<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Z, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZZ<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Z, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZW<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.Z, @this.W);
	[MethodImpl(Inline)]
	public static (g X, g Y) WX<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.W, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) WY<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.W, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) WZ<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.W, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) WW<g>(this (g X, g Y, g Z, g W) @this)
		=> (@this.W, @this.W);

	// 4^3 = 64
	// TODO

	// 4^4 = 256
	// TODO

	#endregion
}