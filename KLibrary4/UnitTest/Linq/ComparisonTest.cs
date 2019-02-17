using System;
using System.Collections.Generic;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq
{
    [TestClass]
    public class ComparisonTest
    {
        [TestMethod]
        public void CreateComparer()
        {
            Assert.AreEqual(-1, Comparer<int>.Default.Compare(1, 2));
            Assert.AreEqual(-1, Comparer<int>.Create((x, y) => x.CompareTo(y)).Compare(1, 2));
            Assert.AreEqual(1, Comparer<int>.Create((x, y) => -x.CompareTo(y)).Compare(1, 2));

            Assert.AreEqual(-1, Comparison.CreateComparer<int>((x, y) => x.CompareTo(y)).Compare(1, 2));
            Assert.AreEqual(1, Comparison.CreateComparer<int>((x, y) => -x.CompareTo(y)).Compare(1, 2));
        }

        [TestMethod]
        public void CreateEqualityComparer()
        {
            Assert.AreEqual(true, EqualityComparer<int>.Default.Equals(2, 2));
            Assert.AreEqual(false, EqualityComparer<int>.Default.Equals(1, 2));

            var comparer = Comparison.CreateEqualityComparer<string>((x, y) => string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(true, comparer.Equals("abc", "ABC"));
            Assert.AreEqual(false, comparer.Equals("abcd", "ABC"));
        }
    }
}
