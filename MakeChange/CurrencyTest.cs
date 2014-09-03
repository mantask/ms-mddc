using System;
using NUnit.Framework;

namespace MakeChange
{
	[TestFixture]
	public class CurrencyTest
	{
		int[,] cases = new int[,] {
			{ 0, 0 },
			{ 1, 1 },
			{ 5, 1 },
			{ 10, 1 },
			{ 20, 1 },
			{ 50, 1 },
			{ 100, 1 },
			{ 500, 5 },
			{ 1000, 10 },
			{ 1086, 15 }, // 10×100, 1×50, 1×20, 1×10, 1×5, 1×1
			{ 135, 4 },
			{ -135, 4 },
			{ -1086, 15 }, // 10×100, 1×50, 1×20, 1×10, 1×5, 1×1
		};

		[Test]
		public void ShouldHandleAllTestCases()
		{
			for (int i = 0; i < cases.GetLength(0); i++) {
				Assert.AreEqual(cases[i, 1], Currency.MakeChange(cases[i, 0]));
			}
		}

	}
}

