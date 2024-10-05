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


	#endregion
}