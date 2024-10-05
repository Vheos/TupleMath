namespace TupleMath;

public static partial class EntryPoint
{
	private static void Main()
	{
		var myFloat = 1f;
		f2 myFloat2 = (1f, 0f);

		Console.WriteLine(myFloat.IsEqual(myFloat2));
	}
}