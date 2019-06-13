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
        CancellationTokenSource tokenSource = new CancellationTokenSource(); // doesn't need to be disposed because it doesn't own a timer
        volatile TaskCompletionSource<bool> cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            this.dictionary = new ConcurrentDictionary<TKey, DateTime>();
            this.dictionaryAsCollection = dictionary;
            _ = CollectExpiredEntriesAsync(tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            this.dictionary[key] = expiration;
            this.cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            return this.dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Clear()
        {
            this.tokenSource.Cancel();
            this.dictionary.Clear();
            this.cleanupTaskCompletionSource.TrySetCanceled();
            this.ResetTaskCompletionSource();
            this.tokenSource = new CancellationTokenSource();
            _ = CollectExpiredEntriesAsync(tokenSource.Token);
        }

        void ResetTaskCompletionSource()
        {
            while (true)
            {
                var tcs = this.cleanupTaskCompletionSource;
                if (!tcs.Task.IsCompleted || Interlocked.CompareExchange(ref this.cleanupTaskCompletionSource, new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously), tcs) == tcs)
                {
                    return;
                }
            }
        }

        async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    ResetTaskCompletionSource();
                    await Task.Delay(delayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                foreach (var kvp in this.dictionary)
                {
                    var expiration = kvp.Value;
                    if (DateTime.UtcNow > expiration)
                    {
                        this.dictionaryAsCollection.Remove(kvp);
                    }
                }
            }
        }
    }
}