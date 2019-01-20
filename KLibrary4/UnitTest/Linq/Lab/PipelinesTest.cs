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

            CollectionAssert.AreEqual(Enumerable.Range(1, 10).ToArray(), actual.Select(x => x.Item1).ToArray());
            CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), actual.Select(x => x.Item2).ToArray());
        }
    }
}
