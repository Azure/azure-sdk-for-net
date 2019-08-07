// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   A read-only subscription to a channel, exposed as an
    ///   asynchronous enumerator.
    /// </summary>
    ///
    /// <typeparam name="T">The type of data contained in the channel.</typeparam>
    ///
    /// <seealso cref="IAsyncEnumerable{T}" />
    ///
    internal class ChannelEnumerableSubscription<T> : IAsyncEnumerable<T>, IAsyncDisposable
    {
        /// <summary>The reader for the channel associated with the subscription.</summary>
        private readonly ChannelReader<T> ChannelReader;

        /// <summary>The callback function to invoke to unsubscribe.</summary>
        private readonly Func<Task> UnsubscribeCallbackAsync;

        /// <summary>The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be published.</summary>
        private readonly TimeSpan? MaximumWaitTime;

        /// <summary>The <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel reading from the channel for enumeration.</summary>
        private readonly CancellationToken CancellationToken;

        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private bool _disposed = false;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ChannelEnumerableSubscription{T}"/> class.
        /// </summary>
        ///
        /// <param name="reader">The reader for the channel associated with the subscription.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be emitted.</param>
        /// <param name="unsubscribeCallbackAsync">The callback function to invoke to unsubscribe.</param>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel reading from the channel for enumeration.</param>
        ///
        public ChannelEnumerableSubscription(ChannelReader<T> reader,
                                             TimeSpan? maximumWaitTime,
                                             Func<Task> unsubscribeCallbackAsync,
                                             CancellationToken cancellationToken)
        {
            Guard.ArgumentNotNull(nameof(reader), reader);
            Guard.ArgumentNotNull(nameof(unsubscribeCallbackAsync), unsubscribeCallbackAsync);

            if (maximumWaitTime.HasValue)
            {
                Guard.ArgumentNotNegative(nameof(maximumWaitTime), maximumWaitTime.Value);
            }

            ChannelReader = reader;
            MaximumWaitTime = maximumWaitTime;
            UnsubscribeCallbackAsync = unsubscribeCallbackAsync;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        ///   Builds an asynchronous enumerator based on the event channel.
        /// </summary>
        ///
        /// <param name="cancellationToken">The cancellation token.</param>
        ///
        /// <returns>The asynchronous enumerator to use for iterating over events.</returns>
        ///
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(ChannelEnumerableSubscription<T>));
            }

            return new ChannelEnumerator(EnumerateChannel(ChannelReader, MaximumWaitTime, CancellationToken)
                .GetAsyncEnumerator(cancellationToken), DisposeAsync);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the enumerable, including
        ///   attempting to unsubscribe from the associated subscription.
        /// </summary>
        ///
        ///
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            await UnsubscribeCallbackAsync().ConfigureAwait(false);
            _disposed = true;
        }

        /// <summary>
        ///   Enumerates the events as they become available in the associated channel.
        /// </summary>
        ///
        /// <param name="reader">The reader for the channel from which events are to be sourced.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be emitted.</param>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel enumeration.</param>
        ///
        /// <returns>An asynchronous enumerator that can be used to iterate over events as they are available.</returns>
        ///
        private static async IAsyncEnumerable<T> EnumerateChannel(ChannelReader<T> reader,
                                                                  TimeSpan? maximumWaitTime,
                                                                  CancellationToken cancellationToken)
        {
            T result;
            int delayMilliseconds;

            var waitTime = maximumWaitTime?.TotalMilliseconds;
            var timer = (waitTime.HasValue) ? Stopwatch.StartNew() : default;

            while (!cancellationToken.IsCancellationRequested)
            {
                // Attempt to read events from the channel.

                if (reader.TryRead(out result))
                {
                    yield return result;
                    timer?.Restart();
                }
                else if ((waitTime.HasValue) && (timer.ElapsedMilliseconds > waitTime.Value))
                {
                    // If there was no event and the wait time has expired, emit an empty event to return control to
                    // the calling iterator.

                    yield return default;
                    timer.Restart();
                }
                else if (reader.Completion.IsCompleted)
                {
                    // If the channel was marked as final, then await the completion task to surface any exceptions.

                    try
                    {
                        await reader.Completion.ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        // This is an expected case when the cancellation token was
                        // triggered during an operation; no action is needed.
                    }

                    break;
                }
                else
                {
                    // TODO (P1//squire): Determine a better approach to prevent a tight loop that consumes resources or
                    // has excessive allocations.  (see: https://github.com/Azure/azure-sdk-for-net/issues/7094)

                    try
                    {
                        delayMilliseconds = 50;

                        if (waitTime.HasValue)
                        {
                            delayMilliseconds = (int)Math.Min(delayMilliseconds, (waitTime.Value - timer.ElapsedMilliseconds));
                        }

                        if (delayMilliseconds > 0)
                        {
                            await Task.Delay(delayMilliseconds, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // This is an expected case when the cancellation token was
                        // triggered during an operation; no action is needed.
                    }
                }
            }

            yield break;
        }

        /// <summary>
        ///   An asynchronous enumerator associated with a channel-reading source enumerable that will
        ///   attempt to unsubscribe when disposed.
        /// </summary>
        ///
        /// <seealso cref="IAsyncEnumerator{T}" />
        ///
        private class ChannelEnumerator : IAsyncEnumerator<T>
        {
            /// <summary>The callback function to invoke on disposal.</summary>
            private readonly Func<ValueTask> DisposeCallbackAsync;

            /// <summary>The enumerator instance to use as the source of events.</summary>
            private readonly IAsyncEnumerator<T> Source;

            /// <summary>
            ///   The current event in the set being enumerated.
            /// </summary>
            ///
            public T Current => Source.Current;

            /// <summary>
            ///   Initializes a new instance of the <see cref="ChannelEnumerator"/> class.
            /// </summary>
            ///
            /// <param name="source">The enumerator instance to use as the source of events.</param>
            /// <param name="disposeCallbackAsync">The callback function to invoke on disposal.</param>
            ///
            public ChannelEnumerator(IAsyncEnumerator<T> source,
                                     Func<ValueTask> disposeCallbackAsync)
            {
                Source = source;
                DisposeCallbackAsync = disposeCallbackAsync;
            }

            /// <summary>
            ///   Moves to the next event in the set being enumerated.
            /// </summary>
            ///
            /// <returns><c>true</c> if there was an event to move to; otherwise, <c>false</c>.</returns>
            ///
            public ValueTask<bool> MoveNextAsync() => Source.MoveNextAsync();

            /// <summary>
            ///   Performs the tasks needed to clean up the enumerator, including
            ///   attempting to unsubscribe from the associated subscription.
            /// </summary>
            ///
            ///
            public async ValueTask DisposeAsync()
            {
                try
                {
                    await Source.DisposeAsync().ConfigureAwait(false);
                }
                finally
                {
                    await DisposeCallbackAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
