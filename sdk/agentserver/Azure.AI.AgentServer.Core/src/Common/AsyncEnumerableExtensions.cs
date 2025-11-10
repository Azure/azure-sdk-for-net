// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Azure.AI.AgentServer.Core.Common;

/// <summary>
/// Provides extension methods for <see cref="IAsyncEnumerable{T}"/> to enable advanced streaming operations.
/// </summary>
public static class AsyncEnumerableExtensions
{
    /// <summary>
    /// Chunks the async enumerable sequence into groups based on when consecutive elements change.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source async enumerable sequence.</param>
    /// <param name="isChanged">A function to determine if an element has changed from the previous one. If null, uses default equality comparison.</param>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating the sequence.</param>
    /// <returns>An async enumerable of async enumerable chunks, where each chunk contains consecutive elements that are considered equal.</returns>
    public static IAsyncEnumerable<IAsyncEnumerable<TSource>> ChunkOnChange<TSource>(
        this IAsyncEnumerable<TSource> source,
        Func<TSource?, TSource?, bool>? isChanged = null,
        CancellationToken cancellationToken = default)
    {
        var c = isChanged == null
            ? EqualityComparer<TSource>.Default
            : EqualityComparer<TSource>.Create((x, y) => !isChanged(x, y), t => t?.GetHashCode() ?? 0);

        return source.ChunkByKey(x => x, c, cancellationToken);
    }

    /// <summary>
    /// Chunks the async enumerable sequence into groups based on a key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key used for grouping.</typeparam>
    /// <param name="source">The source async enumerable sequence.</param>
    /// <param name="keySelector">A function to extract the key from each element.</param>
    /// <param name="comparer">An equality comparer to compare keys. If null, uses the default equality comparer.</param>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating the sequence.</param>
    /// <returns>An async enumerable of async enumerable chunks, where each chunk contains consecutive elements with the same key.</returns>
    public static async IAsyncEnumerable<IAsyncEnumerable<TSource>> ChunkByKey<TSource, TKey>(
        this IAsyncEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        comparer ??= EqualityComparer<TKey>.Default;

        var e = source.GetAsyncEnumerator(cancellationToken);
        await using var _ = e.ConfigureAwait(false);
        if (!await e.MoveNextAsync().ConfigureAwait(false))
        {
            yield break;
        }

        var pending = e.Current;
        var pendingKey = keySelector(pending);
        var hasPending = true;

        while (hasPending)
        {
            var currentKey = pendingKey;

            yield return Inner(cancellationToken);
            continue;

            [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
            async IAsyncEnumerable<TSource> Inner([EnumeratorCancellation] CancellationToken ct = default)
            {
                ct.ThrowIfCancellationRequested();
                yield return pending; // first of the group

                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    ct.ThrowIfCancellationRequested();

                    var item = e.Current;
                    var k = keySelector(item);

                    if (!comparer.Equals(k, currentKey))
                    {
                        // Hand the first item of the next group back to the outer loop
                        pending = item;
                        pendingKey = k;
                        yield break;
                    }

                    yield return item;
                }

                // source ended; tell the outer loop to stop after this group
                hasPending = false;
            }
        }
    }

    /// <summary>
    /// Peeks at the first element of an async enumerable sequence without consuming the sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <param name="source">The source async enumerable sequence.</param>
    /// <param name="cancellationToken">A cancellation token to observe while peeking at the sequence.</param>
    /// <returns>A tuple containing a flag indicating if the sequence has a value, the first element, and the complete sequence including the peeked element.</returns>
    public static async ValueTask<(bool HasValue, T First, IAsyncEnumerable<T> Source)> Peek<T>(
        this IAsyncEnumerable<T> source,
        CancellationToken cancellationToken = default)
    {
        var e = source.GetAsyncEnumerator(cancellationToken);
        var moveNextSucceeded = false;
        try
        {
            moveNextSucceeded = await e.MoveNextAsync().ConfigureAwait(false);
            if (!moveNextSucceeded)
            {
                return (false, default!, Empty<T>());
            }
        }
        finally
        {
            if (!moveNextSucceeded)
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }
        }

        var first = e.Current;

        return (true, first, Sequence(first, e));

        static async IAsyncEnumerable<T> Sequence(T first, IAsyncEnumerator<T> e)
        {
            try
            {
                yield return first;
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    yield return e.Current;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }
        }
    }

#pragma warning disable CS1998
    private static async IAsyncEnumerable<T> Empty<T>()
    {
        yield break;
    }
#pragma warning restore CS1998
}
