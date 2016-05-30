using System;

namespace RationalNumbers
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Rational a = new Rational (-5, 9);
			Rational b = new Rational (5, 6);
			Rational c = new Rational (3, 7);
			Rational d = new Rational (1, 5, 9);
			Console.WriteLine (a + b);
			Console.WriteLine (a - b);
			Console.WriteLine (c * d);
			Console.WriteLine (c / d);
			Rational z = new Rational (3, 0);
			Console.WriteLine (z);
			Console.WriteLine ((double)c);
			Console.WriteLine ((decimal)(d / c));
			Console.WriteLine ((d / c).ToMixedFraction ());
		}
	}
}
