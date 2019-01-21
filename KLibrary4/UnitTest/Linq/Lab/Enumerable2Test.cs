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
            Assert.IsTrue(Enumerable.Range(0, 10).SequenceEqual(Range().Take(10)));
            Assert.IsTrue(Enumerable.Range(3, 10).SequenceEqual(Range(3).Take(10)));
            Assert.IsTrue(Enumerable.Range(0, 10).SequenceEqual(Range(0, 10)));
            Assert.IsTrue(Enumerable.Range(3, 10).SequenceEqual(Range(3, 10)));
            Assert.IsTrue(Enumerable.Empty<int>().SequenceEqual(Range(3, 0)));
            Assert.IsTrue(Enumerable.Range(0, 10).Select(i => 2 * i).SequenceEqual(Range(0, null, 2).Take(10)));
            Assert.IsTrue(Enumerable.Range(0, 10).Select(i => 2 * i + 3).SequenceEqual(Range(3, 10, 2)));
            Assert.IsTrue(Enumerable.Range(-6, 10).Reverse().SequenceEqual(Range(3, 10, -1)));
        }
    }
}
