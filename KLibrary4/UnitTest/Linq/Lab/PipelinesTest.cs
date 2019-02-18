using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq.Lab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq.Lab
{
    [TestClass]
    public class PipelinesTest
    {
        [TestMethod]
        public void WithIndex()
        {
            var actual = Enumerable.Range(1, 10).WithIndex().ToArray();

            Assert.IsTrue(Enumerable.Range(1, 10).SequenceEqual(actual.Select(x => x.Item1)));
            Assert.IsTrue(Enumerable.Range(0, 10).SequenceEqual(actual.Select(x => x.Item2)));
        }

        [TestMethod]
        public void FirstArg()
        {
            Assert.AreEqual(1, new[] { 2, 5, 1, 4, 3 }.FirstArg());
            Assert.AreEqual(5, new[] { 2, 5, 1, 4, 3 }.FirstArg((i, j) => -i.CompareTo(j)));
            Assert.AreEqual(6, new[] { 5, 2, 1, 6, 4, 3 }.FirstArg(i => i % 3));
            Assert.AreEqual(5, new[] { 5, 2, 1, 6, 4, 3 }.FirstArg(i => i % 3, (i, j) => -i.CompareTo(j)));
        }

        [TestMethod]
        public void FirstArg_Last()
        {
            Assert.AreEqual(3, new[] { 5, 2, 1, 6, 4, 3 }.FirstArg(i => i % 3, (i, j) => i.CompareTo(j) < 0 ? -1 : 1));
            Assert.AreEqual(2, new[] { 5, 2, 1, 6, 4, 3 }.FirstArg(i => i % 3, (i, j) => i.CompareTo(j) > 0 ? -1 : 1));
        }
    }
}
