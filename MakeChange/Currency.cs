using System;

namespace MakeChange
{
	public class Currency
	{
		public static int[] DENOMINATIONS = new int[] {
			100,
            50,
            20,
            10,
            5,
            1
		};

		/// <summary>
		/// Given a currency with denominations of 100, 50, 20, 10, 5 and 1 write 
		/// a method MakeChange that takes an integer amount representing the 
		/// total change to make and return an integer representing the smallest 
		/// possible number of bills to return. Greedy works just fine.
		/// </summary>
		/// <returns>Smallest possible number of bills to return.</returns>
		/// <param name="amount">Total change to make.</param>
		public static int MakeChange(int amount)
		{
			amount = Math.Abs(amount);
			int numberOfBills = 0;
			foreach (int denomination in DENOMINATIONS) {
				numberOfBills += amount / denomination;
				amount %= denomination;
			}
			return numberOfBills;
		}
	}
}

