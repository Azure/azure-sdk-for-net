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
        readonly object cleanupSynObject = new object();
        CancellationTokenSource tokenSource = new CancellationTokenSource(); // doesn't need to be disposed because it doesn't own a timer
        bool cleanupScheduled;
        static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            this.dictionary = new ConcurrentDictionary<TKey, DateTime>();
            this.dictionaryAsCollection = dictionary;
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            this.dictionary[key] = expiration;
            this.ScheduleCleanup(tokenSource.Token);
        }

        public bool Contains(TKey key)
        {
            return this.dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Clear()
        {
            this.tokenSource.Cancel();
            this.dictionary.Clear();
            this.tokenSource = new CancellationTokenSource();
        }

        void ScheduleCleanup(CancellationToken token)
        {
            lock (this.cleanupSynObject)
            {
                if (this.cleanupScheduled || this.dictionary.Count <= 0)
                {
                    return;
                }

                this.cleanupScheduled = true;
                _ = this.CollectExpiredEntriesAsync(token);
            }
        }

        async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            try
            {
                await Task.Delay(delayBetweenCleanups, token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            finally
            {
                lock (this.cleanupSynObject)
                {
                    this.cleanupScheduled = false;
                }
            }

            foreach (var kvp in this.dictionary)
            {
                var expiration = kvp.Value;
                if (DateTime.UtcNow > expiration)
                {
                    this.dictionaryAsCollection.Remove(kvp);
                }
            }

            this.ScheduleCleanup(token);
        }
    }
}