using System;

namespace KLibrary.Linq
{
    public static class Array2
    {
        public static T[] Subarray<T>(this T[] source, int start, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var a = new T[count];
            Array.Copy(source, start, a, 0, count);
            return a;
        }

        public static Tuple<T[], T[]> Split<T>(this T[] source, int index)
        {
            var a1 = source.Subarray(0, index);
            var a2 = source.Subarray(index, source.Length - index);
            return Tuple.Create(a1, a2);
        }

        public static bool ArrayEqual<T>(this T[] first, T[] second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            if (first.Length != second.Length) return false;
            for (var i = 0; i < first.Length; i++)
                if (!Equals(first[i], second[i])) return false;
            return true;
        }
    }
}
