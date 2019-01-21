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
    }
}
