
namespace TupleMath;

public static class Extensions_b
{
	#region Operators

	[MethodImpl(Inline)]
	public static b Not(this b @this)
		=> !@this;
	[MethodImpl(Inline)]
	public static b And(this b @this, b a)
		=> @this && a;
	[MethodImpl(Inline)]
	public static b Or(this b @this, b a)
		=> @this || a;
	[MethodImpl(Inline)]
	public static b Xor(this b @this, b a)
		=> @this ^ a;

	[MethodImpl(Inline)]
	public static b IsEqual(this b @this, b a)
		=> @this == a;

	#endregion

	[MethodImpl(Inline)]
	public static g Choose<g>(this b @this, g a, g b)
		=> @this ? a : b;
	[MethodImpl(Inline)]
	public static g Choose<g>(this b @this, Func<g> a, Func<g> b)
		=> @this ? a() : b();

	#region Conversion

	[MethodImpl(Inline)]
	private static b ToBool(this b @this)
		=> @this;
	[MethodImpl(Inline)]
	public static i ToInt(this b @this)
		=> @this ? 1 : 0;
	[MethodImpl(Inline)]
	public static l ToLong(this b @this)
		=> @this ? 1L : 0L;
	[MethodImpl(Inline)]
	public static f ToFloat(this b @this)
		=> @this ? 1f : 0f;
	[MethodImpl(Inline)]
	public static d ToDouble(this b @this)
		=> @this ? 1d : 0d;

	#endregion
}