using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace KLibrary.Linq
{
    /// <summary>
    /// Provides a set of methods to extend LINQ to Objects.
    /// </summary>
    [DebuggerStepThrough]
    public static class Enumerable2
    {
        /// <summary>
        /// Creates an <see cref="IEnumerable{TResult}"/> from a single object.
        /// </summary>
        /// <typeparam name="TResult">The type of the object.</typeparam>
        /// <param name="element">An object.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains the input object.</returns>
        public static IEnumerable<TResult> CreateEnumerable<TResult>(this TResult element)
        {
            yield return element;
        }

        /// <summary>
        /// Creates an array from a single object.
        /// </summary>
        /// <typeparam name="TResult">The type of the object.</typeparam>
        /// <param name="element">An object.</param>
        /// <returns>An array that contains the input object.</returns>
        public static TResult[] CreateArray<TResult>(this TResult element)
        {
            return new[] { element };
        }

        /// <summary>
        /// Creates a <see cref="Collection{TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>A <see cref="Collection{TSource}"/> that contains elements from the input sequence.</returns>
        public static Collection<TSource> ToCollection<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new Collection<TSource>((source as IList<TSource>) ?? source.ToArray());
        }

        /// <summary>
        /// Creates an <see cref="ObservableCollection{TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>An <see cref="ObservableCollection{TSource}"/> that contains elements from the input sequence.</returns>
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new ObservableCollection<TSource>(source);
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence.</typeparam>
        /// <param name="element">The value to be repeated.</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence. <see langword="null"/> if the value is repeated forever.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains a repeated value.</returns>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int? count = null)
        {
            return count.HasValue ? Enumerable.Repeat(element, count.Value) : RepeatForever();

            IEnumerable<TResult> RepeatForever()
            {
                while (true)
                    yield return element;
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null) where TSource : struct
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) predicate = o => true;

            foreach (var item in source)
                if (predicate(item)) return item;

            return null;
        }

        public static TSource? LastOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate = null) where TSource : struct
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) predicate = o => true;

            foreach (var item in source.Reverse())
                if (predicate(item)) return item;

            return null;
        }

        public static bool SequenceEqual<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            {
                while (true)
                {
                    var hasNext1 = e1.MoveNext();
                    var hasNext2 = e2.MoveNext();

                    if (hasNext1 && hasNext2)
                    {
                        if (!comparer(e1.Current, e2.Current))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return !hasNext1 && !hasNext2;
                    }
                }
            }
        }
    }
}
