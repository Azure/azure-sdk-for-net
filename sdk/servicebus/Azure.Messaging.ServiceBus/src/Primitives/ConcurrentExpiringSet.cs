// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class ConcurrentExpiringSet<TKey>
    {
        private readonly ConcurrentDictionary<TKey, DateTime> _dictionary;
        private readonly ICollection<KeyValuePair<TKey, DateTime>> _dictionaryAsCollection;
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private TaskCompletionSource<bool> _cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _closeSignaled;
        private bool _closed;
        private static readonly TimeSpan s_delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            this._dictionary = new ConcurrentDictionary<TKey, DateTime>();
            this._dictionaryAsCollection = _dictionary;
            _ = CollectExpiredEntriesAsync(_tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            this.ThrowIfClosed();

            this._dictionary[key] = expiration;
            this._cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            this.ThrowIfClosed();

            return this._dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Close()
        {
            if (Interlocked.Exchange(ref this._closeSignaled, 1) != 0)
            {
                return;
            }

            this._closed = true;

            this._tokenSource.Cancel();
            this._cleanupTaskCompletionSource.TrySetCanceled();
            this._dictionary.Clear();
            this._tokenSource.Dispose();
        }

        private async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await this._cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    await Task.Delay(s_delayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                var isEmpty = true;
                var utcNow = DateTime.UtcNow;
                foreach (var kvp in this._dictionary)
                {
                    isEmpty = false;
                    var expiration = kvp.Value;
                    if (utcNow > expiration)
                    {
                        this._dictionaryAsCollection.Remove(kvp);
                    }
                }

                if (isEmpty)
                {
                    this._cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                }
            }
        }

        private void ThrowIfClosed()
        {
            if (_closed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}
