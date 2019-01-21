using System;
using System.Collections.Generic;

namespace KLibrary.Linq
{
    /// <summary>
    /// Provides a set of methods to compose sequences.
    /// </summary>
    public static class Composition
    {
        /// <summary>
        /// Creates a tuple from the corresponding elements of two sequences, producing a sequence of the results.
        /// This merges sequences until it reaches the end of one of them.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <returns>An <see cref="IEnumerable{Tuple{TFirst, TSecond}}"/> that contains merged elements of two input sequences.</returns>
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

        /// <summary>
        /// Creates a tuple from the corresponding elements of two sequences, producing a sequence of the results.
        /// This merges sequences until it reaches the end of both of them.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <returns>An <see cref="IEnumerable{Tuple{TFirst, TSecond}}"/> that contains merged elements of two input sequences.</returns>
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

        /// <summary>
        /// Creates a tuple from the corresponding elements of two sequences, producing a sequence of the results.
        /// This merges sequences until it reaches the end of the first.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <returns>An <see cref="IEnumerable{Tuple{TFirst, TSecond}}"/> that contains merged elements of two input sequences.</returns>
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
