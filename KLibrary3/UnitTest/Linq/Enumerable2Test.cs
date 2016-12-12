using System;
using System.Collections.Generic;
using System.Linq;
using KLibrary.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Linq
{
    [TestClass]
    public class Enumerable2Test
    {
        [TestMethod]
        public void Linq_0()
        {
            var result = Enumerable.Range(1, int.MaxValue)
                .Where(i => i % 2 == 1)
                .Select(i => i * i)
                .Take(10)
                .OrderBy(Convert.ToString)
                .ToArray();
            Console.WriteLine(string.Join(", ", result));
        }

        [TestMethod]
        public void Do_1()
        {
            var target1 = new List<int>();
            var target2 = new List<int>();
            var target3 = new List<int>();

            var result = Enumerable.Range(1, 100)
                .Do(target1.Add)
                .Where(i => i % 2 == 1)
                .Do(target2.Add)
                .Select(i => i * i)
                .Do(target3.Add)
                .Take(10)
                .ToArray();

            var expected1 = Enumerable.Range(1, 19)
                .ToArray();
            var expected2 = Enumerable.Range(1, 19)
                .Where(i => i % 2 == 1)
                .ToArray();
            var expected3 = Enumerable.Range(1, 19)
                .Where(i => i % 2 == 1)
                .Select(i => i * i)
                .ToArray();

            CollectionAssert.AreEqual(expected1, target1);
            CollectionAssert.AreEqual(expected2, target2);
            CollectionAssert.AreEqual(expected3, target3);
        }

        [TestMethod]
        public void Execute_1()
        {
            var sum = 0;
            Enumerable.Range(1, 10)
                .Execute(i => sum += i);
            Assert.AreEqual(55, sum);

            var expected = Enumerable.Range(1, 10).ToArray();
            var target = new List<int>();
            Enumerable.Range(1, 10)
                .Execute(target.Add);
            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void Between()
        {
            // 1, 4, 9, 16, ..., 100
            var n_2 = Enumerable.Range(1, 10).Select(x => x * x).ToArray();
            // 3, 5, 7, 9, ..., 19
            var expected = Enumerable.Range(1, 9).Select(x => 2 * x + 1).ToArray();

            var actual = n_2.Between((x1, x2) => x2 - x1).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Successive()
        {
            // 3, 5, 7, 9, ..., 19
            var deltas = Enumerable.Range(1, 9).Select(x => 2 * x + 1).ToArray();
            // 1, 4, 9, 16, ..., 100
            var expected = Enumerable.Range(1, 10).Select(x => x * x).ToArray();

            var actual = deltas.Successive(1, (x, d) => x + d).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
