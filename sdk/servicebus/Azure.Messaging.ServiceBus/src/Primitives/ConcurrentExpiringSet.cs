// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal sealed class ConcurrentExpiringSet<TKey> : IDisposable
    {
        private readonly ConcurrentDictionary<TKey, DateTimeOffset> _dictionary;

        private readonly ICollection<KeyValuePair<TKey, DateTimeOffset>> _dictionaryAsCollection;

        private readonly CancellationTokenSource _tokenSource = new();

        private volatile TaskCompletionSource<bool> _cleanupTaskCompletionSource = new(TaskCreationOptions.RunContinuationsAsynchronously);

        private int _disposeSignaled;

        public bool IsDisposed { get; private set; }

        private static readonly TimeSpan DelayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            _dictionary = new ConcurrentDictionary<TKey, DateTimeOffset>();
            _dictionaryAsCollection = _dictionary;
            _ = CollectExpiredEntriesAsync(_tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTimeOffset expiration)
        {
            ThrowIfDisposed();

            _dictionary[key] = expiration;
            _cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            ThrowIfDisposed();

            return _dictionary.TryGetValue(key, out var expiration) && expiration > DateTimeOffset.UtcNow;
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposeSignaled, 1) != 0)
            {
                return;
            }

            IsDisposed = true;

            _tokenSource.Cancel();
            _cleanupTaskCompletionSource.TrySetCanceled();
            _dictionary.Clear();
            _tokenSource.Dispose();
        }

        public async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await _cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    await Task.Delay(DelayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                var isEmpty = true;
                var utcNow = DateTimeOffset.UtcNow;
                foreach (var kvp in _dictionary)
                {
                    isEmpty = false;
                    var expiration = kvp.Value;
                    if (utcNow > expiration)
                    {
                        _dictionaryAsCollection.Remove(kvp);
                    }
                }

                if (isEmpty)
                {
                    _cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                }
            }
        }

        private void ThrowIfDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}
