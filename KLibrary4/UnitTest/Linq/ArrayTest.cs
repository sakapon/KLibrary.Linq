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
            Range(1, 15, 2)
                .Filter(i => i % 3 != 0)
                .Map(i => i * i)
                .Sort(i => Convert.ToString(i))
                .ForEach(Console.WriteLine);
        }

        [TestMethod]
        public void Sort_1()
        {
            Assert.IsTrue(Enumerable.Range(0, 10).Reverse().SequenceEqual(Range(0, 10).Sort((x, y) => -x.CompareTo(y))));
            Assert.IsTrue(Enumerable.Range(0, 10).Reverse().SequenceEqual(Range(0, 10).Sort(x => (double)x, (x, y) => -x.CompareTo(y))));
        }

        [TestMethod]
        public void Reverse_1()
        {
            Assert.IsTrue(Enumerable.Range(3, 10).Reverse().SequenceEqual(Range(3, 10).Reverse()));
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

        [TestMethod]
        public void Subarray_1()
        {
            Assert.IsTrue(Enumerable.Range(0, 5).SequenceEqual(Range(0, 10).Subarray(0, 5)));
            Assert.IsTrue(Enumerable.Range(3, 5).SequenceEqual(Range(0, 10).Subarray(3, 5)));
            Assert.IsTrue(Enumerable.Range(5, 5).SequenceEqual(Range(0, 10).Subarray(5, 5)));
        }

        [TestMethod]
        public void ArrayEqual_1()
        {
            Assert.AreEqual(true, Array.Empty<int>().ArrayEqual(Array.Empty<int>()));
            Assert.AreEqual(false, new int[2].ArrayEqual(new int[3]));
            Assert.AreEqual(false, new int[3].ArrayEqual(new int[2], (i, j) => true));
            Assert.AreEqual(true, Range(0, 10).ArrayEqual(Range(0, 10)));
            Assert.AreEqual(false, Range(0, 10).ArrayEqual(Range(1, 10)));
            Assert.AreEqual(true, new[] { 1.23, 2, -3 }.ArrayEqual(new[] { "1.23", "2", "-3" }, (d, s) => d.ToString() == s));
            Assert.AreEqual(false, new[] { 1.23, 2, -3 }.ArrayEqual(new[] { "1.23", "2", "-3.0" }, (d, s) => d.ToString() == s));
        }
    }
}
