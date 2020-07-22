// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Primitives
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal sealed class ConcurrentExpiringSet<TKey>
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        public readonly ConcurrentDictionary<TKey, DateTimeOffset> dictionary;

        public readonly ICollection<KeyValuePair<TKey, DateTimeOffset>> dictionaryAsCollection;

        public readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        public volatile TaskCompletionSource<bool> cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        public int closeSignaled;

        public bool closed;

        public static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            dictionary = new ConcurrentDictionary<TKey, DateTimeOffset>();
            dictionaryAsCollection = dictionary;
            _ = CollectExpiredEntriesAsync(tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTimeOffset expiration)
        {
            ThrowIfClosed();

            dictionary[key] = expiration;
            cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            ThrowIfClosed();

            return dictionary.TryGetValue(key, out var expiration) && expiration > DateTimeOffset.UtcNow;
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

        public async Task CollectExpiredEntriesAsync(CancellationToken token)
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
                var utcNow = DateTimeOffset.UtcNow;
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

        public void ThrowIfClosed()
        {
            if (closed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}
