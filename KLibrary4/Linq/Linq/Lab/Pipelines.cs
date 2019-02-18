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

        public static TSource FirstArg<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, int> comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (comparer == null) comparer = Comparer<TSource>.Default.Compare;

            return source
                .Aggregate((o1, o2) => comparer(o1, o2) <= 0 ? o1 : o2);
        }

        public static TSource FirstArg<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null) comparer = Comparer<TKey>.Default.Compare;

            var o = source
                .Select(e => new { e, v = keySelector(e) })
                .Aggregate((o1, o2) => comparer(o1.v, o2.v) <= 0 ? o1 : o2);
            return o.e;
        }

        public static TSource FirstArgMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select(e => new { e, v = selector(e) })
                .Aggregate((o1, o2) => o1.v <= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource FirstArgMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select(e => new { e, v = selector(e) })
                .Aggregate((o1, o2) => o1.v >= o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastArgMin<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select(e => new { e, v = selector(e) })
                .Aggregate((o1, o2) => o1.v < o2.v ? o1 : o2);
            return o.e;
        }

        public static TSource LastArgMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select(e => new { e, v = selector(e) })
                .Aggregate((o1, o2) => o1.v > o2.v ? o1 : o2);
            return o.e;
        }

        public static int FirstMinIndex<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select((e, i) => new { i, v = selector(e) })
                .Aggregate((o1, o2) => o1.v <= o2.v ? o1 : o2);
            return o.i;
        }

        public static Tuple<TSource, int, double> FirstMinInfo<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var o = source
                .Select((e, i) => Tuple.Create(e, i, selector(e)))
                .Aggregate((o1, o2) => o1.Item3 <= o2.Item3 ? o1 : o2);
            return o;
        }
    }
}
