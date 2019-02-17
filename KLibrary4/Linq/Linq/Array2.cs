using System;
using System.Collections.Generic;

namespace KLibrary.Linq
{
    public static class Array2
    {
        public static TSource[] Filter<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var l = new List<TSource>();
            for (var i = 0; i < source.Length; i++)
                if (predicate(source[i]))
                    l.Add(source[i]);
            return l.ToArray();
        }

        public static TSource[] Filter<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var l = new List<TSource>();
            for (var i = 0; i < source.Length; i++)
                if (predicate(source[i], i))
                    l.Add(source[i]);
            return l.ToArray();
        }

        public static TResult[] Map<TSource, TResult>(this TSource[] source, Func<TSource, TResult> map)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (map == null) throw new ArgumentNullException(nameof(map));

            var a = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
                a[i] = map(source[i]);
            return a;
        }

        public static TResult[] Map<TSource, TResult>(this TSource[] source, Func<TSource, int, TResult> map)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (map == null) throw new ArgumentNullException(nameof(map));

            var a = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
                a[i] = map(source[i], i);
            return a;
        }

        public static T[] Subarray<T>(this T[] source, int start, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var a = new T[count];
            Array.Copy(source, start, a, 0, count);
            return a;
        }

        public static bool ArrayEqual<T1, T2>(this T1[] first, T2[] second, Func<T1, T2, bool> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            if (first.Length != second.Length) return false;
            for (var i = 0; i < first.Length; i++)
                if (!comparer(first[i], second[i])) return false;
            return true;
        }

        public static bool ArrayEqual<T>(this T[] first, T[] second) =>
            ArrayEqual(first, second, (o1, o2) => Equals(o1, o2));
    }
}
