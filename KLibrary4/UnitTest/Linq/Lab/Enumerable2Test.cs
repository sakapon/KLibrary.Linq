using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KLibrary.Linq.Lab.Enumerable2;

namespace UnitTest.Linq.Lab
{
    [TestClass]
    public class Enumerable2Test
    {
        [TestMethod]
        public void Range_1()
        {
            CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), Range().Take(10).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(3, 10).ToArray(), Range(3).Take(10).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), Range(0, 10).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(3, 10).ToArray(), Range(3, 10).ToArray());
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToArray(), Range(3, 0).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(0, 10).Select(i => 2 * i).ToArray(), Range(0, null, 2).Take(10).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(0, 10).Select(i => 2 * i + 3).ToArray(), Range(3, 10, 2).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(-6, 10).Reverse().ToArray(), Range(3, 10, -1).ToArray());
        }
    }
}
