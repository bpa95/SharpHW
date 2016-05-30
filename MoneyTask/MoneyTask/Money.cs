using System;

namespace MoneyTask
{
	public struct Money
	{
		decimal val {
			get;
			set;
		}
		public int currencyType {
			get;
			set;
		}

		public Money(decimal value, int currencyType)
		{
			this.val = value;
			this.currencyType = currencyType;
		}

		public Money(Money a):this(a.val, a.currencyType)
		{
		}

		public static Money operator +(Money a, Money b)
		{
			int type = a.currencyType;
			if (b.currencyType != type) {
				Console.WriteLine ("Can't perform operation on " + a + " and " + b);
				Console.WriteLine ("Operands have different types.");
				Console.WriteLine ("First operant is returned.");
				return new Money (a);
			}
			return new Money (a.val + b.val, type);
		}

		public static Money operator -(Money a, Money b)
		{
			return a + (-b);
		}

		public static Money operator -(Money a)
		{
			return new Money (-a.val, a.currencyType);
		}

		public static Money operator *(Money a, decimal b)
		{
			return new Money (a.val * b, a.currencyType);
		}

		public static Money operator /(Money a, decimal b)
		{
			return new Money (a.val / b, a.currencyType);
		}

		public override string ToString ()
		{
			return "[" + val + " " + Currency.getByNum(currencyType).Code + "]";
		}

		public override bool Equals (object obj)
		{
			if (obj == null || GetType () != obj.GetType ()) {
				return false;
			}

			Money a = (Money)obj;
			return (currencyType == a.currencyType) && (val == a.val);
		}

		public override int GetHashCode ()
		{
			return ((int) val) ^ currencyType;
		}
	}
}

