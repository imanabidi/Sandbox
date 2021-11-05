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
        [DataTestMethod]
        public void TestMethod2(int[] a, int[] b, int[] expectedOutputArray)
        {
            var finalArray = new List<int>();
            var carrierDigit = 0;
            var i = a.Length - 1;
            var j = b.Length - 1;

            while (j >= 0 || i >= 0)
            {
                var aValue = 0 <= i ? a[i--] : 0;
                var bValue = 0 <= j ? b[j--] : 0;

                var additionResult = aValue + bValue + carrierDigit;
                carrierDigit = additionResult / 10;
                finalArray.Add(additionResult % 10);
            }

            if (carrierDigit > 0)
            {
                finalArray.Add(carrierDigit);
            }

            finalArray.Reverse();

            var resultArrayCsv = string.Join(",", finalArray);
            var expectedResultArrayCsv = string.Join(",", expectedOutputArray);

            Assert.IsTrue(resultArrayCsv == expectedResultArrayCsv);
        }
    }
}
