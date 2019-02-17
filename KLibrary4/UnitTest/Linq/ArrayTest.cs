using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KLibrary.Linq.Array2;

namespace UnitTest.Linq
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void Chain()
        {
            var result = Range(1, 15, 2)
                .Filter(i => i % 3 != 0)
                .Map(i => i * i)
                .Sort(Convert.ToString);
            Console.WriteLine(string.Join(", ", result));
        }

        [TestMethod]
        public void Range_1()
        {
            Assert.IsTrue(Enumerable.Range(0, 10).SequenceEqual(Range(0, 10)));
            Assert.IsTrue(Enumerable.Range(3, 10).SequenceEqual(Range(3, 10)));
            Assert.IsTrue(Enumerable.Empty<int>().SequenceEqual(Range(3, 0)));
            Assert.IsTrue(Enumerable.Range(0, 10).Select(i => 2 * i + 3).SequenceEqual(Range(3, 10, 2)));
            Assert.IsTrue(Enumerable.Range(-6, 10).Reverse().SequenceEqual(Range(3, 10, -1)));
        }
    }
}
