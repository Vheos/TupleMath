namespace TupleMath.Test;

using System;

internal static class Test
{
	#region Const

	private const b b = true;
	private static readonly b2 b2 = b.ToSame2();
	private static readonly b3 b3 = b.ToSame3();
	private static readonly b4 b4 = b.ToSame4();
	private const i i = 1;
	private static readonly i2 i2 = i.ToSame2();
	private static readonly i3 i3 = i.ToSame3();
	private static readonly i4 i4 = i.ToSame4();
	private const l l = 1L;
	private static readonly l2 l2 = l.ToSame2();
	private static readonly l3 l3 = l.ToSame3();
	private static readonly l4 l4 = l.ToSame4();
	private const f f = 1f;
	private static readonly f2 f2 = f.ToSame2();
	private static readonly f3 f3 = f.ToSame3();
	private static readonly f4 f4 = f.ToSame4();
	private const d d = 1d;
	private static readonly d2 d2 = d.ToSame2();
	private static readonly d3 d3 = d.ToSame3();
	private static readonly d4 d4 = d.ToSame4();
	private const c c = 1m;
	private static readonly c2 c2 = c.ToSame2();
	private static readonly c3 c3 = c.ToSame3();
	private static readonly c4 c4 = c.ToSame4();

	#endregion

	public static void Run()
	{
		#region Assert Consts

		Assert(b, true);
		Assert(b2, (true, true));
		Assert(b3, (true, true, true));
		Assert(b4, (true, true, true, true));

		Assert(i, 1);
		Assert(i2, (1, 1));
		Assert(i3, (1, 1, 1));
		Assert(i4, (1, 1, 1, 1));

		Assert(l, 1L);
		Assert(l2, (1L, 1L));
		Assert(l3, (1L, 1L, 1L));
		Assert(l4, (1L, 1L, 1L, 1L));

		Assert(f, 1f);
		Assert(f2, (1f, 1f));
		Assert(f3, (1f, 1f, 1f));
		Assert(f4, (1f, 1f, 1f, 1f));

		Assert(d, 1d);
		Assert(d2, (1d, 1d));
		Assert(d3, (1d, 1d, 1d));
		Assert(d4, (1d, 1d, 1d, 1d));

		Assert(c, 1m);
		Assert(c2, (1m, 1m));
		Assert(c3, (1m, 1m, 1m));
		Assert(c4, (1m, 1m, 1m, 1m));

		#endregion


		#region i <> ...

		// i
		Assert(i.Add(i), 2);
		Assert(i.Add(i2), (2, 1));
		Assert(i.Add(i3), (2, 1, 1));
		Assert(i.Add(i4), (2, 1, 1, 1));
		// l
		Assert(i.Add(l), 2L);
		Assert(i.Add(l2), (2L, 1L));
		Assert(i.Add(l3), (2L, 1L, 1L));
		Assert(i.Add(l4), (2L, 1L, 1L, 1L));
		// f
		Assert(i.Add(f), 2f);
		Assert(i.Add(f2), (2f, 1f));
		Assert(i.Add(f3), (2f, 1f, 1f));
		Assert(i.Add(f4), (2f, 1f, 1f, 1f));
		// d
		Assert(i.Add(d), 2d);
		Assert(i.Add(d2), (2d, 1d));
		Assert(i.Add(d3), (2d, 1d, 1d));
		Assert(i.Add(d4), (2d, 1d, 1d, 1d));
		// c
		Assert(i.Add(c), 2m);
		Assert(i.Add(c2), (2m, 1m));
		Assert(i.Add(c3), (2m, 1m, 1m));
		Assert(i.Add(c4), (2m, 1m, 1m, 1m));

		#endregion

		#region l <> ...

		// i
		Assert(l.Add(i), 2L);
		Assert(l.Add(i2), (2L, 1L));
		Assert(l.Add(i3), (2L, 1L, 1L));
		Assert(l.Add(i4), (2L, 1L, 1L, 1L));
		// l
		Assert(l.Add(l), 2L);
		Assert(l.Add(l2), (2L, 1L));
		Assert(l.Add(l3), (2L, 1L, 1L));
		Assert(l.Add(l4), (2L, 1L, 1L, 1L));
		// f
		Assert(l.Add(f), 2f);
		Assert(l.Add(f2), (2f, 1f));
		Assert(l.Add(f3), (2f, 1f, 1f));
		Assert(l.Add(f4), (2f, 1f, 1f, 1f));
		// d
		Assert(l.Add(d), 2d);
		Assert(l.Add(d2), (2d, 1d));
		Assert(l.Add(d3), (2d, 1d, 1d));
		Assert(l.Add(d4), (2d, 1d, 1d, 1d));
		// c
		Assert(l.Add(c), 2m);
		Assert(l.Add(c2), (2m, 1m));
		Assert(l.Add(c3), (2m, 1m, 1m));
		Assert(l.Add(c4), (2m, 1m, 1m, 1m));

		#endregion

		#region f <> ...

		// i
		Assert(f.Add(i), 2f);
		Assert(f.Add(i2), (2f, 1f));
		Assert(f.Add(i3), (2f, 1f, 1f));
		Assert(f.Add(i3), (2f, 1f, 1f));
		Assert(f.Add(i4), (2f, 1f, 1f, 1f));
		// l
		Assert(f.Add(l), 2f);
		Assert(f.Add(l2), (2f, 1f));
		Assert(f.Add(l3), (2f, 1f, 1f));
		Assert(f.Add(l4), (2f, 1f, 1f, 1f));
		// f
		Assert(f.Add(f), 2f);
		Assert(f.Add(f2), (2f, 1f));
		Assert(f.Add(f3), (2f, 1f, 1f));
		Assert(f.Add(f4), (2f, 1f, 1f, 1f));
		// d
		Assert(f.Add(d), 2d);
		Assert(f.Add(d2), (2d, 1d));
		Assert(f.Add(d3), (2d, 1d, 1d));
		Assert(f.Add(d4), (2d, 1d, 1d, 1d));
		// c
		Assert(f.Add(c), 2m);
		Assert(f.Add(c2), (2m, 1m));
		Assert(f.Add(c3), (2m, 1m, 1m));
		Assert(f.Add(c4), (2m, 1m, 1m, 1m));

		#endregion

		#region d <> ...

		// i
		Assert(d.Add(i), 2d);
		Assert(d.Add(i2), (2d, 1d));
		Assert(d.Add(i3), (2d, 1d, 1d));
		Assert(d.Add(i4), (2d, 1d, 1d, 1d));
		// l
		Assert(d.Add(l), 2d);
		Assert(d.Add(l2), (2d, 1d));
		Assert(d.Add(l3), (2d, 1d, 1d));
		Assert(d.Add(l4), (2d, 1d, 1d, 1d));
		// f
		Assert(d.Add(f), 2d);
		Assert(d.Add(f2), (2d, 1d));
		Assert(d.Add(f3), (2d, 1d, 1d));
		Assert(d.Add(f4), (2d, 1d, 1d, 1d));
		// d
		Assert(d.Add(d), 2d);
		Assert(d.Add(d2), (2d, 1d));
		Assert(d.Add(d3), (2d, 1d, 1d));
		Assert(d.Add(d4), (2d, 1d, 1d, 1d));
		// c
		Assert(d.Add(c), 2m);
		Assert(d.Add(c2), (2m, 1m));
		Assert(d.Add(c3), (2m, 1m, 1m));
		Assert(d.Add(c4), (2m, 1m, 1m, 1m));

		#endregion


		#region i2 <> ...

		// i
		Assert(i2.Add(i), (2, 1));
		Assert(i2.Add(i2), (2, 2));
		Assert(i2.Add(i3), (2, 2, 1));
		Assert(i2.Add(i4), (2, 2, 1, 1));
		// l
		Assert(i2.Add(l), (2L, 1L));
		Assert(i2.Add(l2), (2L, 2L));
		Assert(i2.Add(l3), (2L, 2L, 1L));
		Assert(i2.Add(l4), (2L, 2L, 1L, 1L));
		// f
		Assert(i2.Add(f), (2f, 1f));
		Assert(i2.Add(f2), (2f, 2f));
		Assert(i2.Add(f3), (2f, 2f, 1f));
		Assert(i2.Add(f4), (2f, 2f, 1f, 1f));
		// d
		Assert(i2.Add(d), (2d, 1d));
		Assert(i2.Add(d2), (2d, 2d));
		Assert(i2.Add(d3), (2d, 2d, 1d));
		Assert(i2.Add(d4), (2d, 2d, 1d, 1d));
		// c
		Assert(i2.Add(c), (2m, 1m));
		Assert(i2.Add(c2), (2m, 2m));
		Assert(i2.Add(c3), (2m, 2m, 1m));
		Assert(i2.Add(c4), (2m, 2m, 1m, 1m));

		#endregion

		#region l2 <> ...

		// i
		Assert(l2.Add(i), (2L, 1L));
		Assert(l2.Add(i2), (2L, 2L));
		Assert(l2.Add(i3), (2L, 2L, 1L));
		Assert(l2.Add(i4), (2L, 2L, 1L, 1L));
		// l
		Assert(l2.Add(l), (2L, 1L));
		Assert(l2.Add(l2), (2L, 2L));
		Assert(l2.Add(l3), (2L, 2L, 1L));
		Assert(l2.Add(l4), (2L, 2L, 1L, 1L));
		// f
		Assert(l2.Add(f), (2f, 1f));
		Assert(l2.Add(f2), (2f, 2f));
		Assert(l2.Add(f3), (2f, 2f, 1f));
		Assert(l2.Add(f4), (2f, 2f, 1f, 1f));
		// d
		Assert(l2.Add(d), (2d, 1d));
		Assert(l2.Add(d2), (2d, 2d));
		Assert(l2.Add(d3), (2d, 2d, 1d));
		Assert(l2.Add(d4), (2d, 2d, 1d, 1d));
		// c
		Assert(l2.Add(c), (2m, 1m));
		Assert(l2.Add(c2), (2m, 2m));
		Assert(l2.Add(c3), (2m, 2m, 1m));
		Assert(l2.Add(c4), (2m, 2m, 1m, 1m));

		#endregion

		#region f2 <> ...

		// i
		Assert(f2.Add(i), (2f, 1f));
		Assert(f2.Add(i2), (2f, 2f));
		Assert(f2.Add(i3), (2f, 2f, 1f));
		Assert(f2.Add(i3), (2f, 2f, 1f));
		Assert(f2.Add(i4), (2f, 2f, 1f, 1f));
		// l
		Assert(f2.Add(l), (2f, 1f));
		Assert(f2.Add(l2), (2f, 2f));
		Assert(f2.Add(l3), (2f, 2f, 1f));
		Assert(f2.Add(l4), (2f, 2f, 1f, 1f));
		// f
		Assert(f2.Add(f), (2f, 1f));
		Assert(f2.Add(f2), (2f, 2f));
		Assert(f2.Add(f3), (2f, 2f, 1f));
		Assert(f2.Add(f4), (2f, 2f, 1f, 1f));
		// d
		Assert(f2.Add(d), (2d, 1d));
		Assert(f2.Add(d2), (2d, 2d));
		Assert(f2.Add(d3), (2d, 2d, 1d));
		Assert(f2.Add(d4), (2d, 2d, 1d, 1d));
		// c
		Assert(f2.Add(c), (2m, 1m));
		Assert(f2.Add(c2), (2m, 2m));
		Assert(f2.Add(c3), (2m, 2m, 1m));
		Assert(f2.Add(c4), (2m, 2m, 1m, 1m));

		#endregion

		#region d2 <> ...

		// i
		Assert(d2.Add(i), (2d, 1d));
		Assert(d2.Add(i2), (2d, 2d));
		Assert(d2.Add(i3), (2d, 2d, 1d));
		Assert(d2.Add(i4), (2d, 2d, 1d, 1d));
		// l
		Assert(d2.Add(l), (2d, 1d));
		Assert(d2.Add(l2), (2d, 2d));
		Assert(d2.Add(l3), (2d, 2d, 1d));
		Assert(d2.Add(l4), (2d, 2d, 1d, 1d));
		// f
		Assert(d2.Add(f), (2d, 1d));
		Assert(d2.Add(f2), (2d, 2d));
		Assert(d2.Add(f3), (2d, 2d, 1d));
		Assert(d2.Add(f4), (2d, 2d, 1d, 1d));
		// d
		Assert(d2.Add(d), (2d, 1d));
		Assert(d2.Add(d2), (2d, 2d));
		Assert(d2.Add(d3), (2d, 2d, 1d));
		Assert(d2.Add(d4), (2d, 2d, 1d, 1d));
		// c
		Assert(d2.Add(c), (2m, 1m));
		Assert(d2.Add(c2), (2m, 2m));
		Assert(d2.Add(c3), (2m, 2m, 1m));
		Assert(d2.Add(c4), (2m, 2m, 1m, 1m));

		#endregion
	}

	private static void Assert<T>(T a, T b)
		where T : IEquatable<T>
	{
		if (!a.Equals(b))
			throw new($"Value comparison failed!\nType: {typeof(T).Name}\nValue A: {a}\nValue B: {b}");
	}
}
