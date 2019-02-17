using System;

namespace KLibrary.Linq.Lab
{
    public static class Array2
    {
        public static Tuple<T[], T[]> Split<T>(this T[] source, int index)
        {
            var a1 = source.Subarray(0, index);
            var a2 = source.Subarray(index, source.Length - index);
            return Tuple.Create(a1, a2);
        }
    }
}
