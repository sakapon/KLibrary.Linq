using System;
using System.Collections.Generic;

namespace KLibrary.Linq
{
    public static class Composition
    {
        public static IEnumerable<Tuple<TFirst, TSecond>> ZipForShort<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var enumerator1 = first.GetEnumerator();
            var enumerator2 = second.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                yield return Tuple.Create(enumerator1.Current, enumerator2.Current);
            }
        }

        public static IEnumerable<Tuple<TFirst, TSecond>> ZipForLong<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var enumerator1 = first.GetEnumerator();
            var enumerator2 = second.GetEnumerator();

            while (true)
            {
                var hasNext1 = enumerator1.MoveNext();
                var hasNext2 = enumerator2.MoveNext();
                if (!(hasNext1 || hasNext2)) break;

                yield return Tuple.Create(hasNext1 ? enumerator1.Current : default(TFirst), hasNext2 ? enumerator2.Current : default(TSecond));
            }
        }

        public static IEnumerable<Tuple<TFirst, TSecond>> ZipForFirst<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var enumerator1 = first.GetEnumerator();
            var enumerator2 = second.GetEnumerator();

            while (enumerator1.MoveNext())
            {
                yield return Tuple.Create(enumerator1.Current, enumerator2.MoveNext() ? enumerator2.Current : default(TSecond));
            }
        }
    }
}
