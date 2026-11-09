// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// Extensions for IAsyncEnumerable.
/// </summary>
public static partial class AsyncEnumerableExtensions
{
    /// <summary>
    /// Convert the IAsyncEnumerable to IEnumerable.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> ToEnumerable<TSource>(this IAsyncEnumerable<TSource> asyncEnumerable)
    {
#if NET6_0_OR_GREATER
        return asyncEnumerable.ToBlockingEnumerable();
#else
        IAsyncEnumerator<TSource> enumerator = asyncEnumerable.GetAsyncEnumerator();
        try
        {
#pragma warning disable AZC0102
            while (enumerator.MoveNextAsync().AsTask().GetAwaiter().GetResult())
            {
#pragma warning restore AZC0102
                yield return enumerator.Current;
            }
        }
        finally
        {
            ValueTask disposeTask = enumerator.DisposeAsync();
#pragma warning disable AZC0102 // Use EnsureCompleted() directly on asynchronous method return value.
            disposeTask.AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }
#endif
    }
}
