using System;
using System.Collections.Generic;
using System.Linq;

namespace KLibrary.Linq.Lab
{
    public static class EnumerableHelper
    {
        public static IEnumerable<int> Range2(int minValue, int maxValue)
        {
            for (var i = minValue; i <= maxValue; i++)
                yield return i;
        }
    }
}
