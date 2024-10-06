namespace TupleMath;

public static partial class Extensions_g3
{
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Append<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Y, @this.Z, default);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Append<g>(this (g X, g Y, g Z) @this, g a)
		=> (@this.X, @this.Y, @this.Z, a);

	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Prepend<g>(this (g X, g Y, g Z) @this)
		=> (default, @this.X, @this.Y, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Prepend<g>(this (g X, g Y, g Z) @this, g a)
		=> (a, @this.X, @this.Y, @this.Z);

	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) NewX<g>(this (g X, g Y, g Z) @this, g x)
		=> (x, @this.Y, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) NewY<g>(this (g X, g Y, g Z) @this, g y)
		=> (@this.X, y, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Newz<g>(this (g X, g Y, g Z) @this, g z)
		=> (@this.X, @this.Y, z);

	[MethodImpl(Inline)]
	public static g To1<g>(this (g X, g Y, g Z) @this)
		=> @this.X;
	[MethodImpl(Inline)]
	public static (g X, g Y) To2<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) To4<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Y, @this.Z, default);

	#region Components

	// 3^2 = 9
	[MethodImpl(Inline)]
	public static (g X, g Y) XX<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) XY<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) XZ<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) YX<g>(this (g X, g Y, g Z) @this)
		=> (@this.Y, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) YY<g>(this (g X, g Y, g Z) @this)
		=> (@this.Y, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) YZ<g>(this (g X, g Y, g Z) @this)
		=> (@this.Y, @this.Z);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZX<g>(this (g X, g Y, g Z) @this)
		=> (@this.Z, @this.X);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZY<g>(this (g X, g Y, g Z) @this)
		=> (@this.Z, @this.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y) ZZ<g>(this (g X, g Y, g Z) @this)
		=> (@this.Z, @this.Z);

	// 3^3 = 27
	// TODO

	// 3^4 = 81
	// TODO

	#endregion
}