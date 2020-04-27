// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    sealed class ConcurrentExpiringSet<TKey>
    {
        readonly ConcurrentDictionary<TKey, DateTime> dictionary;
        readonly ICollection<KeyValuePair<TKey, DateTime>> dictionaryAsCollection;
        readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
        volatile TaskCompletionSource<bool> cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        int closeSignaled;
        bool closed;
        static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            dictionary = new ConcurrentDictionary<TKey, DateTime>();
            dictionaryAsCollection = dictionary;
            _ = CollectExpiredEntriesAsync(tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            ThrowIfClosed();

            dictionary[key] = expiration;
            cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            ThrowIfClosed();

            return dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Close()
        {
            if (Interlocked.Exchange(ref closeSignaled, 1) != 0)
            {
                return;
            }

            closed = true;

            tokenSource.Cancel();
            cleanupTaskCompletionSource.TrySetCanceled();
            dictionary.Clear();
            tokenSource.Dispose();
        }

        async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    await Task.Delay(delayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                var isEmpty = true;
                var utcNow = DateTime.UtcNow;
                foreach (var kvp in dictionary)
                {
                    isEmpty = false;
                    var expiration = kvp.Value;
                    if (utcNow > expiration)
                    {
                        dictionaryAsCollection.Remove(kvp);
                    }
                }

                if (isEmpty)
                {
                    cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                }
            }
        }

        void ThrowIfClosed()
        {
            if (closed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}