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
            while (true)
            {
                //enumerator.MoveNextAsync().EnsureCompleted()
                ValueTask<bool> moveNextTask = enumerator.MoveNextAsync();
                if (!moveNextTask.IsCompleted)
                {
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                    moveNextTask.EnsureCompleted();
#pragma warning restore AZC0104
                    yield return enumerator.Current;
                }
                if (!moveNextTask.Result)
                {
                    yield break;
                }
            }
        }
        finally
        {
            ValueTask disposeTask = enumerator.DisposeAsync();
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
            disposeTask.EnsureCompleted();
#pragma warning restore AZC0104
        }
#endif
    }
}
