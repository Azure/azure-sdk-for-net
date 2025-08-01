// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Extension methods for <see cref="IAsyncEnumerable{T}"/> to support testing scenarios.
/// Provides utilities for converting async enumerables to synchronous collections for easier testing and validation.
/// </summary>
public static class TestAsyncEnumerableExtensions
{
    /// <summary>
    /// Converts an <see cref="IAsyncEnumerable{T}"/> to a <see cref="List{T}"/> by asynchronously enumerating all items.
    /// This method is useful in test scenarios where you need to convert async enumerable results to a synchronous collection for assertions.
    /// </summary>
    /// <typeparam name="T">The type of elements in the async enumerable.</typeparam>
    /// <param name="asyncEnumerable">The async enumerable to convert to a list.</param>
    /// <returns>A <see cref="Task{List}"/> containing all items from the async enumerable.</returns>
    public static async Task<List<T>> ToEnumerableAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
    {
        List<T> list = new List<T>();
        await foreach (T item in asyncEnumerable.ConfigureAwait(false))
        {
            list.Add(item);
        }
        return list;
    }
}
