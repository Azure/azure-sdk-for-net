// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
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
	    private volatile TaskCompletionSource<bool> _cleanupTaskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
	    private int _closeSignaled;
	    private bool _closed;
	    private static readonly TimeSpan delayBetweenCleanups = TimeSpan.FromSeconds(30);

        public ConcurrentExpiringSet()
        {
            _dictionary = new ConcurrentDictionary<TKey, DateTime>();
            _dictionaryAsCollection = _dictionary;
            _ = CollectExpiredEntriesAsync(_tokenSource.Token);
        }

        public void AddOrUpdate(TKey key, DateTime expiration)
        {
            ThrowIfClosed();

            _dictionary[key] = expiration;
            _cleanupTaskCompletionSource.TrySetResult(true);
        }

        public bool Contains(TKey key)
        {
            ThrowIfClosed();

            return _dictionary.TryGetValue(key, out var expiration) && expiration > DateTime.UtcNow;
        }

        public void Close()
        {
            if (Interlocked.Exchange(ref _closeSignaled, 1) != 0)
            {
                return;
            }

            _closed = true;

            _tokenSource.Cancel();
            _cleanupTaskCompletionSource.TrySetCanceled();
            _dictionary.Clear();
            _tokenSource.Dispose();
        }

        private async Task CollectExpiredEntriesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await _cleanupTaskCompletionSource.Task.ConfigureAwait(false);
                    await Task.Delay(delayBetweenCleanups, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                var isEmpty = true;
                var utcNow = DateTime.UtcNow;
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

        private void ThrowIfClosed()
        {
            if (_closed)
            {
                throw new ObjectDisposedException($"ConcurrentExpiringSet has already been closed. Please create a new set instead.");
            }
        }
    }
}