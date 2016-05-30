using System;

namespace MoneyTask
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Money a = new Money (10, 643);
			Money b = new Money (21, 643);
			Money c = new Money (15, 978);
			Console.WriteLine (a + " + " + b + " = " + (a + b));
			Console.WriteLine (a + " - " + b + " = " + (a - b));
			Console.WriteLine (a + " + " + c + " = " + (a + c));
			Console.WriteLine (a + " * " + 3.5m + " = " + (a * 3.5m));
			Console.WriteLine (c + " / " + 2m + " = " + (c / 2m));
			Console.WriteLine (a + " == " + (b - new Money(1, 643) / 2) + " = " + a.Equals ((b - new Money(1, 643)) / 2));
			Payment pa = new Payment (a);
			Payment pb = new Payment (b);
			Payment pc = new Payment (c);
			Console.WriteLine ("(" + pa + " + " + pb + " - " + pc + " * " + 2m + ")" + " / " + 3m + " = " + ((pa + pb - pc * 2m) / 3m));
		}
	}
}
