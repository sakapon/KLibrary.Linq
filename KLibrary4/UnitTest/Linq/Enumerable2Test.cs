using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KLibrary.Linq.Enumerable2;

namespace UnitTest.Linq
{
    [TestClass]
    public class Enumerable2Test
    {
        [TestMethod]
        public void CreateEnumerable()
        {
            var o = new object();
            var expected = new[] { o };
            var actual = o.CreateEnumerable().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateArray()
        {
            var o = new object();
            var expected = new[] { o };
            var actual = o.CreateArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToCollection_IEnumerable()
        {
            var expected = Enumerable.Range(1, 10).ToArray();
            var target = Enumerable.Range(1, 10).ToCollection();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void ToCollection_IList()
        {
            var expected = Enumerable.Range(1, 10).ToArray();
            var target = expected.ToCollection();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void ToObservableCollection_1()
        {
            var expected = Enumerable.Range(1, 10).ToArray();
            var target = Enumerable.Range(1, 10).ToObservableCollection();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void Repeat_Default()
        {
            var o = new object();
            var expected = Enumerable.Repeat(o, 10).ToArray();
            var target = Repeat(o).Take(10).ToArray();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void Repeat_Null()
        {
            var o = new object();
            var expected = Enumerable.Repeat(o, 10).ToArray();
            var target = Repeat(o, null).Take(10).ToArray();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void Repeat_Number()
        {
            var o = new object();
            var expected = Enumerable.Repeat(o, 10).ToArray();
            var target = Repeat(o, 10).ToArray();

            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void FirstOrNull_1()
        {
            Assert.AreEqual(null, Enumerable.Empty<int>().FirstOrNull());
            Assert.AreEqual(3, Enumerable.Range(3, 5).FirstOrNull());
            Assert.AreEqual(4, Enumerable.Range(3, 5).FirstOrNull(i => i % 2 == 0));
            Assert.AreEqual(null, Enumerable.Range(3, 5).FirstOrNull(i => i > 10));
        }

        [TestMethod]
        public void LastOrNull_1()
        {
            Assert.AreEqual(null, Enumerable.Empty<int>().LastOrNull());
            Assert.AreEqual(7, Enumerable.Range(3, 5).LastOrNull());
            Assert.AreEqual(6, Enumerable.Range(3, 5).LastOrNull(i => i % 2 == 0));
            Assert.AreEqual(null, Enumerable.Range(3, 5).LastOrNull(i => i > 10));
        }

        [TestMethod]
        public void SequenceEqual_1()
        {
            Assert.AreEqual(true, new int[0].SequenceEqual(new string[0], (i, s) => false));
            Assert.AreEqual(false, new int[2].SequenceEqual(new int[3], (i, j) => true));
            Assert.AreEqual(false, new int[3].SequenceEqual(new int[2], (i, j) => true));
            Assert.AreEqual(true, new[] { 1.23, 2, -3 }.SequenceEqual(new[] { "1.23", "2", "-3" }, (d, s) => d.ToString() == s));
            Assert.AreEqual(false, new[] { 1.23, 2, -3 }.SequenceEqual(new[] { "1.23", "2", "-3.0" }, (d, s) => d.ToString() == s));
        }
    }
}
