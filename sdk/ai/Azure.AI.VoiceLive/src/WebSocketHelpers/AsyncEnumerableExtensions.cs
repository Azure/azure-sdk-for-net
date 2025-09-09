// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Provides extension methods for asynchronous enumerables.
    /// </summary>
    internal static class AsyncEnumerableExtensions
    {
        /// <summary>
        /// Converts an IAsyncEnumerable to a blocking enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="asyncEnumerable">The async enumerable to convert.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A blocking enumerable that will consume the async enumerable.</returns>
        public static IEnumerable<T> ToBlockingEnumerable<T>(this IAsyncEnumerable<T> asyncEnumerable, CancellationToken cancellationToken = default)
        {
            return new BlockingEnumerable<T>(asyncEnumerable, cancellationToken);
        }

        private sealed class BlockingEnumerable<T> : IEnumerable<T>
        {
            private readonly IAsyncEnumerable<T> _asyncEnumerable;
            private readonly CancellationToken _cancellationToken;

            public BlockingEnumerable(IAsyncEnumerable<T> asyncEnumerable, CancellationToken cancellationToken)
            {
                _asyncEnumerable = asyncEnumerable ?? throw new ArgumentNullException(nameof(asyncEnumerable));
                _cancellationToken = cancellationToken;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new BlockingEnumerator<T>(_asyncEnumerable, _cancellationToken);
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private sealed class BlockingEnumerator<T> : IEnumerator<T>
        {
            private readonly IAsyncEnumerator<T> _asyncEnumerator;
            private readonly CancellationToken _cancellationToken;
            private bool _disposed;

            public BlockingEnumerator(IAsyncEnumerable<T> asyncEnumerable, CancellationToken cancellationToken)
            {
                _asyncEnumerator = asyncEnumerable.GetAsyncEnumerator(cancellationToken);
                _cancellationToken = cancellationToken;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                try
                {
                    var moveNextTask = _asyncEnumerator.MoveNextAsync();
#pragma warning disable AZC0107
                    bool hasNext = moveNextTask.AsTask().EnsureCompleted();
#pragma warning restore AZC0107
                    if (hasNext)
                    {
                        Current = _asyncEnumerator.Current;
                        return true;
                    }

                    Current = default(T);
                    return false;
                }
                catch (OperationCanceledException)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                    throw;
                }
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _disposed = true;
#pragma warning disable AZC0107
                    _asyncEnumerator?.DisposeAsync().AsTask().EnsureCompleted();
#pragma warning restore AZC0107
                }
            }
        }
    }
}
