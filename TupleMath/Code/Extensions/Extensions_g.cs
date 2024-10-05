namespace TupleMath;

public static class Extensions_g
{
	[MethodImpl(Inline)]
	public static (g X, g Y) Append<g>(this g @this)
		=> (@this, default);
	[MethodImpl(Inline)]
	public static (g X, g Y) Append<g>(this g @this, g a)
		=> (@this, a);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Append<g>(this g @this, (g X, g Y) a)
		=> (@this, a.X, a.Y);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Append<g>(this g @this, (g X, g Y, g Z) a)
		=> (@this, a.X, a.Y, a.Z);

	[MethodImpl(Inline)]
	public static (g X, g Y) Prepend<g>(this g @this)
		=> (default, @this);
	[MethodImpl(Inline)]
	public static (g X, g Y) Prepend<g>(this g @this, g a)
		=> (a, @this);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) Prepend<g>(this g @this, (g X, g Y) a)
		=> (a.X, a.Y, @this);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) Prepend<g>(this g @this, (g X, g Y, g Z) a)
		=> (a.X, a.Y, a.Z, @this);

	[MethodImpl(Inline)]
	private static g To1<g>(this g @this)
		=> @this;
	[MethodImpl(Inline)]
	public static (g X, g Y) To2<g>(this g @this)
		=> (@this, default);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) To3<g>(this g @this)
		=> (@this, default, default);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) To4<g>(this g @this)
		=> (@this, default, default, default);

	[MethodImpl(Inline)]
	public static (g X, g Y) ToSame2<g>(this g @this)
		=> (@this, @this);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z) ToSame3<g>(this g @this)
		=> (@this, @this, @this);
	[MethodImpl(Inline)]
	public static (g X, g Y, g Z, g W) ToSame4<g>(this g @this)
		=> (@this, @this, @this, @this);
}