﻿using System;
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
        public void Repeat_1()
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
        public void Repeat_NotNull()
        {
            var o = new object();
            var expected = Enumerable.Repeat(o, 10).ToArray();
            var target = Repeat(o, 10).ToArray();

            CollectionAssert.AreEqual(expected, target);
        }
    }
}
