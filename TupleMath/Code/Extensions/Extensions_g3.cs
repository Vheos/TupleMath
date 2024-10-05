namespace TupleMath;

public static class Extensions_g3
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
	static (g X, g Y, g Z) To3<g>(this (g X, g Y, g Z) @this)
		=> @this;
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) To4<g>(this (g X, g Y, g Z) @this)
		=> (@this.X, @this.Y, @this.Z, default);

	#region Components


	#endregion
}