// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class TestExtensions
    {
        /// <summary>
        /// Convert an IAsyncEnumerable into a List to make test verification
        /// easier.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="items">The seqeuence of items.</param>
        /// <returns>A list of all the items in the sequence.</returns>
        public static async Task<IList<T>> ToListAsync<T>(this IAsyncEnumerable<T> items)
        {
            var all = new List<T>();
            await foreach (T item in items)
            {
                all.Add(item);
            }
            return all;
        }

        /// <summary>
        /// Get the first item in an IAsyncEnumerable.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="items">The seqeuence of items.</param>
        /// <returns>
        /// The first item in the sequence or an
        /// <see cref="InvalidOperationException"/>.
        /// </returns>
        public static async Task<T> FirstAsync<T>(this IAsyncEnumerable<T> items)
        {
            await foreach (T item in items)
            {
                return item;
            }
            throw new InvalidOperationException();
        }
    }
}
