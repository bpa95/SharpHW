using System;
using System.Collections.Generic;

namespace MoneyTask
{
	public class Payment
	{
		Dictionary<int, Money> p;

		public Payment ()
		{
			p = new Dictionary<int, Money> ();
		}

		private Payment(Dictionary<int, Money> p)
		{
			this.p = p;
		}

		public Payment (Money a)
		{
			p = new Dictionary<int, Money> ();
			p.Add (a.currencyType, a);
		}

		public static Payment operator +(Payment a, Payment b)
		{
			Dictionary<int, Money> p = new Dictionary<int, Money> (a.p);
			foreach (KeyValuePair<int, Money> pair in b.p) {
				if (p.ContainsKey (pair.Key)) {
					Money pv = p[pair.Key];
					p.Remove (pair.Key);
					p.Add (pair.Key, pair.Value + pv);
				} else {
					p.Add (pair.Key, pair.Value);
				}
			}
			return new Payment(p);
		}

		public static Payment operator -(Payment a, Payment b)
		{
			return a + (-b);
		}

		public static Payment operator -(Payment a)
		{
			Dictionary<int, Money> p = new Dictionary<int, Money> ();
			foreach (KeyValuePair<int, Money> pair in a.p) {
				p.Add (pair.Key, -pair.Value);
			}
			return new Payment(p);
		}

		public static Payment operator *(Payment a, decimal b)
		{
			Dictionary<int, Money> p = new Dictionary<int, Money> ();
			foreach (KeyValuePair<int, Money> pair in a.p) {
				p.Add (pair.Key, pair.Value * b);
			}
			return new Payment(p);
		}

		public static Payment operator /(Payment a, decimal b)
		{
			Dictionary<int, Money> p = new Dictionary<int, Money> ();
			foreach (KeyValuePair<int, Money> pair in a.p) {
				p.Add (pair.Key, pair.Value / b);
			}
			return new Payment(p);
		}

		public override string ToString ()
		{
			string s = "{";
			foreach (KeyValuePair<int, Money> pair in p) {
				s += pair.Value + ", ";
			}
			s += "}";
			return s;
		}

		public override bool Equals (object obj)
		{
			if (obj == null || GetType () != obj.GetType ()) {
				return false;
			}

			Dictionary<int, Money> a = p;
			Dictionary<int, Money> b = ((Payment)obj).p;
			if (a.Count != b.Count) {
				return false;
			}
			foreach (KeyValuePair<int, Money> pair in a) {
				if (!b.ContainsKey (pair.Key)) {
					return false;
				}
				if (!pair.Value.Equals(b[pair.Key])) {
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode ()
		{
			int hash = 0;
			foreach (KeyValuePair<int, Money> pair in p) {
				hash ^= pair.Key;
				hash ^= pair.GetHashCode();
			}
			return base.GetHashCode ();
		}
	}
}

