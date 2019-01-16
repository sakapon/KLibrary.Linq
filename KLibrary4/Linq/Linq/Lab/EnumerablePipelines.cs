using System;
using System.Collections.Generic;
using System.Linq;

namespace KLibrary.Linq.Lab
{
    public static class EnumerablePipelines
    {
        public static IEnumerable<TSource> CopyTo<TSource>(this IEnumerable<TSource> source, TSource[] array)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (array == null) throw new ArgumentNullException(nameof(array));

            using (var enumerator = source.GetEnumerator())
            {
                for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
                    array[i] = enumerator.Current;
            }

            return source;
        }

        public static TSource FirstToMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v <= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource FirstToMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v >= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastToMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v < o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastToMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v > o2.v ? o1 : o2);
            return o.e;
        }
    }
}
