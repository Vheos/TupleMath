namespace TupleMath;

public static partial class EntryPoint
{
    private static void Main()
    {		
        i i = default;
        i2 i2 = default;
        i3 i3 = default;
        i4 i4 = default;
        f f = default;
        f2 f2 = default;
        f3 f3 = default;
        f4 f4 = default;

		f myFloat = 1f;
		f2 myFloat2 = (1f, 0f);

		Console.WriteLine(myFloat.IsEqual(myFloat2));
    }
}