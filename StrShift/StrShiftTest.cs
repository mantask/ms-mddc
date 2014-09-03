using System;
using NUnit.Framework;

namespace StrShift
{
	[TestFixture]
	public class StrShiftTest
	{
		// --- conversion tests -------------------------------------------------

		[Test]
		public void ShouldAssignNonEmptyStringToStrShift()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("Microsoft", example.ToString());
		}

		[Test]
		public void ShouldAssignEmptyStringToStrShift()
		{
			StrShift example = "";
			Assert.AreEqual("", example.ToString());
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldThrowExceptionOnNullString()
		{
			new StrShift(null);
		}

		// --- equals tests -------------------------------------------------

		[Test]
		public void ShouldCompareTwoEqualStrShiftsByValue()
		{
			StrShift s1 = "Microsoft";
			StrShift s2 = "Microsoft";
			Assert.IsTrue(s1 == s2);
		}

		// --- shifting tests -------------------------------------------------

		[Test]
		public void ShouldHandleSingleShift()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("ftMicroso", (example << 2).ToString());
		}

		[Test]
		public void ShouldHandleZeroShift()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("Microsoft", (example << 0).ToString());
			Assert.AreEqual("Microsoft", (example >> 0).ToString());
		}

		[Test]
		public void ShouldHandleSingleLargeShift()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("ftMicroso", (example << (9 * 11111 + 2)).ToString());
		}

		[Test]
		public void ShouldHandleTwoShifts()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("ftMicroso", (example << 1 << 1).ToString());
		}
		
		[Test]
		public void ShouldShiftBackAndForward()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("Microsoft", (example << 7 >> 7).ToString());
		}
		
		[Test]
		public void ShouldShiftAroundInBothDirections()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("Microsoft", (example << 7 * "Microsoft".Length).ToString());
			Assert.AreEqual("Microsoft", (example >> "Microsoft".Length).ToString());
		}
		
		[Test]
		public void ShouldHandleEmptyString()
		{
			StrShift example = "";
			Assert.AreEqual("", (example << 3).ToString());
		}
		
		[Test]
		public void ShouldShiftToOppositeDirectionWhenNegative()
		{
			StrShift example = "Microsoft";
			Assert.AreEqual("ftMicroso", (example >> -2).ToString());
		}

	}
}
