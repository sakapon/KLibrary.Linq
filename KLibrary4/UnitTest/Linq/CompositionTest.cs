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

            var actual2 = range2.ZipForShort(range1).ToArray();
            Assert.AreEqual(length1, actual2.Length);
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
            Assert.AreEqual(0, actual1[length2 - 1].Item1);

            var actual2 = range2.ZipForLong(range1).ToArray();
            Assert.AreEqual(length2, actual2.Length);
            Assert.AreEqual(0, actual2[length2 - 1].Item2);
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

            var actual2 = range2.ZipForFirst(range1).ToArray();
            Assert.AreEqual(length2, actual2.Length);
            Assert.AreEqual(0, actual2[length2 - 1].Item2);
        }
    }
}
