﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KLibrary.Linq
{
    /// <summary>
    /// Provides a set of methods to extend LINQ to Objects.
    /// </summary>
    public static class EnumerableHelper
    {
        /// <summary>
        /// Creates an <see cref="IEnumerable{TResult}"/> from a single object.
        /// </summary>
        /// <typeparam name="TResult">The type of the object.</typeparam>
        /// <param name="element">An object.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains the input object.</returns>
        [DebuggerHidden]
        public static IEnumerable<TResult> MakeEnumerable<TResult>(this TResult element)
        {
            yield return element;
        }

        /// <summary>
        /// Creates an array from a single object.
        /// </summary>
        /// <typeparam name="TResult">The type of the object.</typeparam>
        /// <param name="element">An object.</param>
        /// <returns>An array that contains the input object.</returns>
        [DebuggerHidden]
        public static TResult[] MakeArray<TResult>(this TResult element)
        {
            return new[] { element };
        }

        /// <summary>
        /// Generates an infinite sequence that contains one repeated value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence.</typeparam>
        /// <param name="element">The value to be repeated.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains a repeated value.</returns>
        [DebuggerHidden]
        public static IEnumerable<TResult> Repeat<TResult>(TResult element)
        {
            while (true)
                yield return element;
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence.</typeparam>
        /// <param name="element">The value to be repeated.</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence. <see langword="null"/> if the value is repeated infinitely.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains a repeated value.</returns>
        [DebuggerHidden]
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int? count)
        {
            return count.HasValue ? Enumerable.Repeat(element, count.Value) : Repeat(element);
        }
    }
}
