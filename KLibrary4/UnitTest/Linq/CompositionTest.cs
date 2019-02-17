using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq
{
    [TestClass]
    public class CompositionTest
    {
        [TestMethod]
        public void ZipForShort_1()
        {
            var length1 = 9;
            var length2 = 10;
            var range1 = Enumerable.Range(1, length1);
            var range2 = Enumerable.Range(1, length2);

            var actual0 = range1.ZipForShort(range1).ToArray();
            Assert.AreEqual(length1, actual0.Length);

            var actual1 = range1.ZipForShort(range2).ToArray();
            Assert.AreEqual(length1, actual1.Length);
            Assert.AreEqual(Tuple.Create(length1, length1), actual1.Last());

            var actual2 = range2.ZipForShort(range1).ToArray();
            Assert.AreEqual(length1, actual2.Length);
            Assert.AreEqual(Tuple.Create(length1, length1), actual2.Last());
        }

        [TestMethod]
        public void ZipForLong_1()
        {
            var length1 = 9;
            var length2 = 10;
            var range1 = Enumerable.Range(1, length1);
            var range2 = Enumerable.Range(1, length2);

            var actual0 = range1.ZipForLong(range1).ToArray();
            Assert.AreEqual(length1, actual0.Length);

            var actual1 = range1.ZipForLong(range2).ToArray();
            Assert.AreEqual(length2, actual1.Length);
            Assert.AreEqual(Tuple.Create(0, length2), actual1.Last());

            var actual2 = range2.ZipForLong(range1).ToArray();
            Assert.AreEqual(length2, actual2.Length);
            Assert.AreEqual(Tuple.Create(length2, 0), actual2.Last());
        }

        [TestMethod]
        public void ZipForFirst_1()
        {
            var length1 = 9;
            var length2 = 10;
            var range1 = Enumerable.Range(1, length1);
            var range2 = Enumerable.Range(1, length2);

            var actual0 = range1.ZipForFirst(range1).ToArray();
            Assert.AreEqual(length1, actual0.Length);

            var actual1 = range1.ZipForFirst(range2).ToArray();
            Assert.AreEqual(length1, actual1.Length);
            Assert.AreEqual(Tuple.Create(length1, length1), actual1.Last());

            var actual2 = range2.ZipForFirst(range1).ToArray();
            Assert.AreEqual(length2, actual2.Length);
            Assert.AreEqual(Tuple.Create(length2, 0), actual2.Last());
        }

        [TestMethod]
        public void ZipToDictionary_1()
        {
            var length1 = 10;
            var length2 = 9;
            var range1 = Enumerable.Range(11, length1);
            var range2 = Enumerable.Range(21, length2);

            var actual = range1.ZipToDictionary(range2);
            Assert.AreEqual(length2, actual.Count);
            Assert.AreEqual(29, actual[19]);
        }
    }
}
