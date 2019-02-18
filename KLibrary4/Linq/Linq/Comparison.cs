using System;
using System.Collections.Generic;

namespace KLibrary.Linq
{
    public static class Comparison
    {
        public static IComparer<T> CreateComparer<T>(Func<T, T, int> compare) =>
            new DelegateComparer<T>(compare);

        public static IEqualityComparer<T> CreateEqualityComparer<T>(Func<T, T, bool> equals) =>
            new DelegateEqualityComparer<T>(equals);
    }

    class DelegateComparer<T> : Comparer<T>
    {
        Func<T, T, int> _compare;

        public DelegateComparer(Func<T, T, int> compare)
        {
            _compare = compare ?? throw new ArgumentNullException(nameof(compare));
        }

        public override int Compare(T x, T y) => _compare(x, y);
    }

    class DelegateEqualityComparer<T> : EqualityComparer<T>
    {
        Func<T, T, bool> _equals;

        public DelegateEqualityComparer(Func<T, T, bool> equals)
        {
            _equals = equals ?? throw new ArgumentNullException(nameof(equals));
        }

        public override bool Equals(T x, T y) => _equals(x, y);

        public override int GetHashCode(T obj) =>
            obj?.GetHashCode() ?? throw new ArgumentNullException(nameof(obj));
    }
}
