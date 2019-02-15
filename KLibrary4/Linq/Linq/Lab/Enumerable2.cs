using System;
using System.Collections.Generic;
using System.Linq;

namespace KLibrary.Linq.Lab
{
    public static class Enumerable2
    {
        public static IEnumerable<int> Range(int start = 0, int? count = null, int step = 1)
        {
            if (count.HasValue)
            {
                var n = start;
                for (var i = 0; i < count; i++)
                {
                    yield return n;
                    n += step;
                }
            }
            else
            {
                for (var i = start; ; i += step)
                    yield return i;
            }
        }

        public static IEnumerable<int> Range2(int minValue, int maxValue)
        {
            for (var i = minValue; i <= maxValue; i++)
                yield return i;
        }

        // This will be no longer needed because we can use the Any method.
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (comparer == null) return source.Contains(value);

            return source.Any(e => comparer(e, value));
        }
    }
}
