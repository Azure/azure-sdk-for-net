// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class ConcurrentExpiringSet<TKey>
    {
        private readonly ConcurrentDictionary<TKey, DateTime> dictionary;

        private readonly ICollection<KeyValuePair<TKey, DateTime>> dictionaryAsCollection;

        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        private volatile TaskCompletionSource<bool> cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        private int closeSignaled;

        private bool closed;

        private static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            this.dictionary = new ConcurrentDictionary<TKey, DateTime>();
            this.dictionaryAsCollection = dictionary;
            _ = CollectExpiredEntriesAsync(tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            this.ThrowIfClosed();

            this.dictionary[key] = expiration;
            this.cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            this.ThrowIfClosed();

            return this.dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Close()
        {
            if (Interlocked.Exchange(ref this.closeSignaled, 1) != 0)
            {
                return;
            }

            this.closed = true;

            this.tokenSource.Cancel();
            this.cleanupTaskCompletionSource.TrySetCanceled();
            this.dictionary.Clear();
            this.tokenSource.Dispose();
        }

        private async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await this.cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    await Task.Delay(delayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                var isEmpty = true;
                var utcNow = DateTime.UtcNow;
                foreach (var kvp in this.dictionary)
                {
                    isEmpty = false;
                    var expiration = kvp.Value;
                    if (utcNow > expiration)
                    {
                        this.dictionaryAsCollection.Remove(kvp);
                    }
                }

                if (isEmpty)
                {
                    this.cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                }
            }
        }

        private void ThrowIfClosed()
        {
            if (closed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}