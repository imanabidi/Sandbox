using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox
{
    [TestClass]
    public class ArrayAdditionUnitTests
    {
        [DataRow(new[] { 1, 2, 3 }, new[] { 2, 3, 4 }, new[] { 3, 5, 7 })]
        [DataRow(new[] { 2, 3, 8 }, new[] { 1, 3, 8 }, new[] { 3, 7, 6 })]
        [DataRow(new[] { 3, 2, 5 }, new[] { 1, 6, 9, 6 }, new[] { 2, 0, 2, 1 })]
        [DataRow(new[] { 2, 5 }, new[] { 9, 9, 9, 6 }, new[] { 1, 0, 0, 2, 1 })]
        [DataRow(new[] { 2, 5 }, new[] { 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9, 9, 6 }, new[] { 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 1 })]
        [DataRow(new[] { 9, 9, 9 }, new[] { 9, 9, 9 }, new[] { 1, 9, 9, 8 })]
        [DataRow(new[] { 9, 9, 0 }, new[] { 1, 0 }, new[] { 1, 0, 0, 0 })]
        [DataTestMethod]
        public void ArrayAdditionShouldSucceed(int[] a, int[] b, int[] expectedOutputArray)
        {
            var aIndex = a.Length - 1;
            var bIndex = b.Length - 1;
            var carrierDigit = 0;
            var finalArray = new List<int>();

            while (bIndex >= 0 || aIndex >= 0)
            {
                var aValue = 0 <= aIndex ? a[aIndex--] : 0;
                var bValue = 0 <= bIndex ? b[bIndex--] : 0;

                var additionResult = aValue + bValue + carrierDigit;
                carrierDigit = additionResult / 10;
                finalArray.Add(additionResult % 10);
            }

            if (carrierDigit > 0)
            {
                finalArray.Add(carrierDigit);
            }

            finalArray.Reverse();

            Assert.IsTrue(string.Join("", finalArray) == string.Join("", expectedOutputArray));
        }
    }
}
