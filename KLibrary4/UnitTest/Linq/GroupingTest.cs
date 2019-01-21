using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq
{
    [TestClass]
    public class GroupingTest
    {
        [TestMethod]
        public void GroupBySequentially_1()
        {
            var target = Enumerable.Range(0, 9)
                .GroupBySequentially(i => i % 4 == 0)
                .ToArray();

            CollectionAssert.AreEqual(new[] { true, false, true, false, true }, target.Select(g => g.Key).ToArray());
            CollectionAssert.AreEqual(new[] { 1, 3, 1, 3, 1 }, target.Select(g => g.ToArray().Length).ToArray());
        }

        [TestMethod]
        public void GroupBySequentially_2()
        {
            var target = Enumerable.Range(1, 10)
                .GroupBySequentially(i => i % 4 == 0)
                .ToArray();

            CollectionAssert.AreEqual(new[] { false, true, false, true, false }, target.Select(g => g.Key).ToArray());
            CollectionAssert.AreEqual(new[] { 3, 1, 3, 1, 2 }, target.Select(g => g.ToArray().Length).ToArray());
        }

        [TestMethod]
        public void GroupBySequentially_Empty()
        {
            var empty = new int[0];

            CollectionAssert.AreEqual(empty, empty.GroupBySequentially(i => i).ToArray());
        }
    }
}
