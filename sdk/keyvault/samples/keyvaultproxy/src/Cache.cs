// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AzureSamples.Security.KeyVault.Proxy
{
    /// <summary>
    /// Maintains a cache of <see cref="CachedResponse"/> items.
    /// </summary>
    internal class Cache : IDisposable
    {
        private readonly Dictionary<string, CachedResponse> _cache = new Dictionary<string, CachedResponse>(StringComparer.OrdinalIgnoreCase);
        private SemaphoreSlim? _lock = new SemaphoreSlim(1, 1);

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_lock is {})
            {
                _lock.Dispose();
                _lock = null;
            }
        }

        /// <summary>
        /// Gets a valid <see cref="Response"/> or requests and caches a <see cref="CachedResponse"/>.
        /// </summary>
        /// <param name="isAsync">Whether certain operations should be performed asynchronously.</param>
        /// <param name="uri">The URI sans query parameters to cache.</param>
        /// <param name="ttl">The amount of time for which the cached item is valid.</param>
        /// <param name="action">The action to request a response.</param>
        /// <returns>A new <see cref="Response"/>.</returns>
        internal async ValueTask<Response> GetOrAddAsync(bool isAsync, string uri, TimeSpan ttl, Func<ValueTask<Response>> action)
        {
            ThrowIfDisposed();

            if (isAsync)
            {
                await _lock!.WaitAsync().ConfigureAwait(false);
            }
            else
            {
                _lock!.Wait();
            }

            try
            {
                // Try to get a valid cached response inside the lock before fetching.
                if (_cache.TryGetValue(uri, out CachedResponse cachedResponse) && cachedResponse.IsValid)
                {
                    return await cachedResponse.CloneAsync(isAsync).ConfigureAwait(false);
                }

                Response response = await action().ConfigureAwait(false);
                if (response.Status == 200 && response.ContentStream is { })
                {
                    cachedResponse = await CachedResponse.CreateAsync(isAsync, response, ttl).ConfigureAwait(false);
                    _cache[uri] = cachedResponse;
                }

                return response;
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Clears the cache.
        /// </summary>
        internal void Clear()
        {
            ThrowIfDisposed();

            _lock!.Wait();
            try
            {
                _cache.Clear();
            }
            finally
            {
                _lock.Release();
            }
        }

        private void ThrowIfDisposed()
        {
            if (_lock is null)
            {
                throw new ObjectDisposedException(nameof(_lock));
            }
        }
    }
}
