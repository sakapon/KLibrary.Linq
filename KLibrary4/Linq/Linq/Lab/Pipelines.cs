using System;
using System.Collections.Generic;
using System.Linq;

namespace KLibrary.Linq.Lab
{
    public static class Pipelines
    {
        public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource, IList<TSource>> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var history = new List<TSource>();
            foreach (var item in source)
            {
                action(item, history);
                history.Add(item);
                yield return item;
            }
        }

        public static IEnumerable<Tuple<TSource, int>> WithIndex<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var i = -1;
            foreach (var item in source)
                yield return Tuple.Create(item, ++i);
        }

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

        public static TSource FirstArgMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (valueSelector == null) throw new ArgumentNullException(nameof(valueSelector));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v <= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource FirstArgMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (valueSelector == null) throw new ArgumentNullException(nameof(valueSelector));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v >= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastArgMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (valueSelector == null) throw new ArgumentNullException(nameof(valueSelector));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v < o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastArgMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> valueSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (valueSelector == null) throw new ArgumentNullException(nameof(valueSelector));

            var o = source
                .Select(e => new { e, v = valueSelector(e) })
                .Aggregate((o1, o2) => o1.v > o2.v ? o1 : o2);
            return o.e;
        }
    }
}
