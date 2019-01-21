using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KLibrary.Linq
{
    /// <summary>
    /// Provides a set of methods to group elements of a sequence.
    /// </summary>
    public static class Grouping
    {
        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function sequentially.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="source">A sequence whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>An <see cref="IEnumerable{IGrouping{TKey, TSource}}"/> where each element contains a sequence of objects and a key.</returns>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBySequentially<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var queue = new Queue<TSource>();
            var currentKey = default(TKey);
            var comparer = EqualityComparer<TKey>.Default;

            foreach (var item in source)
            {
                var key = keySelector(item);

                if (!comparer.Equals(key, currentKey))
                {
                    if (queue.Count != 0)
                    {
                        yield return new Grouping<TKey, TSource>(currentKey, queue.ToArray());
                        queue.Clear();
                    }
                    currentKey = key;
                }
                queue.Enqueue(item);
            }

            if (queue.Count != 0)
            {
                yield return new Grouping<TKey, TSource>(currentKey, queue.ToArray());
            }
        }
    }

    /// <summary>
    /// Represents a collection of objects that have a common key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TElement">The type of the values.</typeparam>
    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        public TKey Key { get; }

        /// <summary>
        /// Gets the values.
        /// </summary>
        protected IEnumerable<TElement> Values { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grouping{TKey, TElement}"/> class.
        /// </summary>
        /// <param name="key">A key.</param>
        /// <param name="values">Values.</param>
        public Grouping(TKey key, IEnumerable<TElement> values)
        {
            Key = key;
            Values = values;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<TElement> GetEnumerator() => Values.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
