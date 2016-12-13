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
    }
}
