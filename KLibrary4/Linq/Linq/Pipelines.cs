using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KLibrary.Linq
{
    /// <summary>
    /// Provides a set of methods to extend LINQ to Objects.
    /// </summary>
    public static class Pipelines
    {
        /// <summary>
        /// Does an action for each element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">An action to apply to each element.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the same elements as the input sequence.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }

        /// <summary>
        /// Does an action for each element of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">An action to apply to each element; the second parameter of the function represents the index of the source element.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains the same elements as the input sequence.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var i = -1;
            foreach (var item in source)
            {
                action(item, ++i);
                yield return item;
            }
        }

        /// <summary>
        /// Executes enumeration of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        [DebuggerStepThrough]
        public static void Execute<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source) ;
        }

        /// <summary>
        /// Executes enumeration of a sequence, and does an action for each element of the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">An action to apply to each element.</param>
        [DebuggerStepThrough]
        public static void Execute<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Executes enumeration of a sequence, and does an action for each element of the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">An action to apply to each element; the second parameter of the function represents the index of the source element.</param>
        [DebuggerStepThrough]
        public static void Execute<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var i = -1;
            foreach (var item in source)
                action(item, ++i);
        }

#if NET40
        /// <summary>
        /// Prepends an element to the head of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="element">The value to be prepended.</param>
        /// <returns>A concatenated <see cref="IEnumerable{TSource}"/>.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            yield return element;

            foreach (var item in source)
                yield return item;
        }

        /// <summary>
        /// Appends an element to the tail of a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="element">The value to be appended.</param>
        /// <returns>A concatenated <see cref="IEnumerable{TSource}"/>.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
                yield return item;

            yield return element;
        }
#endif

        /// <summary>
        /// Returns distinct elements from a sequence by using the keys to compare values.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains distinct elements from the input sequence.</returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var keySet = new HashSet<TKey>();

            foreach (var item in source)
            {
                var key = keySelector(item);
                if (!keySet.Add(key)) continue;
                yield return item;
            }
        }

        /// <summary>
        /// Segments a sequence by the specified length.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="lengthOfSegment">The length of a segment.</param>
        /// <returns>A sequence of segments of values.</returns>
        public static IEnumerable<TSource[]> Segment<TSource>(this IEnumerable<TSource> source, int lengthOfSegment)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (lengthOfSegment <= 0) throw new ArgumentOutOfRangeException(nameof(lengthOfSegment), lengthOfSegment, "The value must be positive.");

            var l = new List<TSource>();

            foreach (var item in source)
            {
                l.Add(item);

                if (l.Count == lengthOfSegment)
                {
                    yield return l.ToArray();
                    l.Clear();
                }
            }

            if (l.Count > 0)
                yield return l.ToArray();
        }

        /// <summary>
        /// Creates a new sequence by getting values from two elements next to each other in the source sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="func">A function to get a new value from two elements next to each other.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/>.</returns>
        public static IEnumerable<TResult> Between<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));

            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext()) yield break;

            TSource e1;
            TSource e2 = enumerator.Current;

            while (enumerator.MoveNext())
            {
                e1 = e2;
                e2 = enumerator.Current;
                yield return func(e1, e2);
            }
        }

        /// <summary>
        /// Creates a new sequence by applying an accumulator function over a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="seed">The initial value.</param>
        /// <param name="func">A function to get a next value from a pair of a previous value and an element of source.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/>.</returns>
        public static IEnumerable<TResult> Successive<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TResult, TSource, TResult> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));

            var current = seed;
            yield return current;

            foreach (var item in source)
            {
                current = func(current, item);
                yield return current;
            }
        }
    }
}
