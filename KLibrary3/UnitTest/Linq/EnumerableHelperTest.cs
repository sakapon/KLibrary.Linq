using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq
{
    [TestClass]
    public class EnumerableHelperTest
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
    }
}
