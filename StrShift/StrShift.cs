using System;

namespace StrShift
{
	/// <summary>
	/// Immutable value object that encapsulates string with shift left/right operations.
	/// </summary>
	public class StrShift
	{
		private readonly string text;

		// --- ctor -------------------------------------------------------------

		public StrShift(string text)
		{
			if (text == null) {
				throw new ArgumentNullException();
			}
			this.text = text;
		}

		// --- operators --------------------------------------------------------

		/// <param name="text">Cast string to StrShift.</param>
		public static implicit operator StrShift(string text)
		{
			return new StrShift(text);
		}

		/// <param name="strShift">StrShift to be shifted left.</param>
		/// <param name="positions">Number of shift positions.</param>
		public static StrShift operator >>(StrShift strShift, int positions) 
		{
			return strShift.shiftRight(positions);
		}

		/// <param name="strShift">StrShift to be shifted right.</param>
		/// <param name="positions">Number of shift positions.</param>
		public static StrShift operator <<(StrShift strShift, int positions) 
		{
			return strShift.shiftRight(-positions);
		}

		// --- object ------------------------------------------------------------

		public static bool operator ==(StrShift s1, StrShift s2)
		{
			return (object) s1 != null && s1.Equals(s2) || (object) s2 == null; 
		}

		public static bool operator !=(StrShift s1, StrShift s2)
		{
			return !(s1 == s2);
		}

		public override bool Equals(Object other)
		{
			return (other is StrShift) && Equals((StrShift) other);
		}

		public bool Equals(StrShift other)
		{
			return text == other.ToString();
		}

		public override int GetHashCode()
		{
			return text.GetHashCode();
		}

		public override string ToString()
		{
			return text;
		}

		// ----------------------------------------------------------------------

		private StrShift shiftRight(int pos)
		{
			if (text.Length == 0) {
				return text;
			}
			pos = mod(pos, text.Length);
			return new StrShift(textTail(pos) + textHead(pos)); 
		}

		private string textHead(int pos)
		{
			return text.Substring(0, pos);
		}

		private string textTail(int pos)
		{
			return text.Substring(pos, text.Length - pos);
		}

		/// <summary>
		/// Properly handle negative modulus operation.
		/// </summary>
		private int mod(int num, int mod)
		{
			int remainder = num % mod;
			return (remainder < 0) ? (mod + remainder) : remainder;
		}
	}
}
