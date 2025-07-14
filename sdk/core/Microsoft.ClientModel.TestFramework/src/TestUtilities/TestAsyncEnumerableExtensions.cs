// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public static class TestAsyncEnumerableExtensions
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="asyncEnumerable"></param>
    /// <returns></returns>
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
