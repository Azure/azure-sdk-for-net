// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared;

internal static class EnumerableExtensions
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public static async IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IEnumerable<T> enumerable)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        foreach (T elem in enumerable)
        {
            yield return elem;
        }
    }

    public static async IAsyncEnumerable<T> Concat<T>(this IAsyncEnumerable<T> first, params IAsyncEnumerable<T>[] next)
    {
        await foreach (T elem in first.ConfigureAwait(false))
        {
            yield return elem;
        }
        foreach (IAsyncEnumerable<T> enumerable in next)
        {
            await foreach (T elem in enumerable.ConfigureAwait(false))
            {
                yield return elem;
            }
        }
    }

    /// <summary>
    /// Provides an async switch for <see cref="IAsyncEnumerator{T}.MoveNextAsync"/> to either
    /// await it or <c>.EnsureCompleted()</c>.
    /// </summary>
    public static async ValueTask<bool> MoveNextInternal<T>(this IAsyncEnumerator<T> enumerator, bool async)
    {
        if (async)
        {
            return await enumerator.MoveNextAsync().ConfigureAwait(false);
        }
        else
        {
#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
            return enumerator.MoveNextAsync().EnsureCompleted();
#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.
        }
    }

    /// <summary>
    /// Preserves a stateful enumerator in the form of an enumerable.
    /// </summary>
    /// <returns>
    /// IAsyncEnumerable whose <see cref="IAsyncEnumerable{T}.GetAsyncEnumerator(CancellationToken)"/>
    /// implementation returns a reference to the provided enumerable.
    /// </returns>
    public static IAsyncEnumerable<T> EnumerableWrap<T>(this IAsyncEnumerator<T> enumerator)
        => new WrappedAsyncEnumerator<T>(enumerator);

    private struct WrappedAsyncEnumerator<T>(IAsyncEnumerator<T> inner) : IAsyncEnumerable<T>
    {
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => inner;
    }
}
