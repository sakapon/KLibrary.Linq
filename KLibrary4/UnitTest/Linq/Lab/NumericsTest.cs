using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KLibrary.Linq.Lab.Enumerable2;

namespace UnitTest.Linq.Lab
{
    [TestClass]
    public class NumericsTest
    {
        static void AssertNearlyEqual(double expected, double actual) =>
            Assert.AreEqual(0.0, Math.Round(expected - actual, 12));

        [TestMethod]
        public void GetPi()
        {
            var p = 1.0;
            var sum = 0.0;

            Range(1, null, 2)
                .Select(i => 1 / (i * p))
                .Select(a => sum + a)
                .TakeWhile(s => sum != s)
                .Do(s => sum = s)
                .Execute(_ => p *= -3);
            var r = Math.Sqrt(12) * sum;

            AssertNearlyEqual(Math.PI, r);
        }

        [TestMethod]
        public void Sqrt()
        {
            var x = 5.0;
            var r = x;

            Enumerable2.Repeat(false)
                .Select(_ => (r + x / r) / 2)
                .TakeWhile(a => r != a)
                .Execute(a => r = a);

            AssertNearlyEqual(Math.Sqrt(x), r);
        }
    }
}
