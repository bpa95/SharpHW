using System;

namespace RationalNumbers
{
	public struct Rational
	{
		int num;
		int den;

		public Rational(int num, int den)
		{
			if (den == 0)
			{
				Console.WriteLine (String.Format("Division by zero exception. Rational {0}/{1} is now 0/1", num, den));
				num = 0;
				den = 1;
			}
			this.num = Math.Abs (num) * ((num ^ den) >= 0 ? 1 : -1);
			this.den = Math.Abs (den);
			simplify ();
		}

		public Rational(int integ, int num, int den):this(integ * den + num, den)
		{
		}

		public static int gcd(int a, int b)
		{
			while (b != 0)
				b = a % (a = b);
			return a;
		}

		void simplify()
		{
			int g = gcd (Math.Abs(num), den);
			num = num / g;
			den = den / g;
		}

		public static Rational operator +(Rational a, Rational b)
		{
			int g = gcd (a.den, b.den);
			int aa = b.den / g;
			int bb = a.den / g;
			return new Rational (a.num * aa + b.num * bb, a.den * aa);
		}

		public static Rational operator -(Rational a)
		{
			return new Rational (-a.num, a.den);
		}

		public static Rational operator -(Rational a, Rational b)
		{
			return a + (-b);
		}

		public static Rational operator *(Rational a, Rational b)
		{
			int g1 = gcd (a.num, b.den);
			int g2 = gcd (a.den, b.num);
			return new Rational((a.num / g1) * (b.num / g2), (a.den / g2) * (b.den / g1));
		}

		public static Rational operator /(Rational a, Rational b)
		{
			return a * new Rational (b.den, b.num);
		}

		public static explicit operator double(Rational a)
		{
			return (double) a.num / a.den;
		}

		public static explicit operator decimal(Rational a)
		{
			return (decimal) a.num / (decimal) a.den;
		}

		public override bool Equals (object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			Rational r = (Rational)obj;
			return (num == r.num) && (den == r.den);
		}

		public override int GetHashCode ()
		{
			return (int) (num ^ den);
		}

		public override string ToString ()
		{
			return num + "/" + den;
		}

		public string ToMixedFraction()
		{
			return (num / den) + "#" + new Rational (num % den, den);
		}
	}
}

