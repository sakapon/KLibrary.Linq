using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLibrary.Linq
{
    public static class EnumerableHelper
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var element in source)
            {
                if (action != null) action(element);
                yield return element;
            }
        }

        public static void ForEachExecute<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException("source");

            foreach (var element in source)
            {
                if (action != null) action(element);
            }
        }

        /// <summary>
        /// Creates a <see cref="Collection&lt;TSource&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable&lt;TSource&gt;"/>.</param>
        /// <returns>A <see cref="Collection&lt;TSource&gt;"/> that contains elements from the input sequence.</returns>
        public static Collection<TSource> ToCollection<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return new Collection<TSource>((source as IList<TSource>) ?? source.ToList());
        }

        /// <summary>
        /// Creates an <see cref="ObservableCollection&lt;TSource&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable&lt;TSource&gt;"/>.</param>
        /// <returns>An <see cref="ObservableCollection&lt;TSource&gt;"/> that contains elements from the input sequence.</returns>
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

#if !SILVERLIGHT
            return new ObservableCollection<TSource>(source);
#else
            var collection = new ObservableCollection<TSource>();
            source.ForEachExecute(collection.Add);
            return collection;
#endif
        }
    }
}
