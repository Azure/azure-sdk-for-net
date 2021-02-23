// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// A cache for Tokens.
    /// </summary>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    // SemaphoreSlim only needs to be disposed when AvailableWaitHandle is called.
    public class TokenCache
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private DateTimeOffset _lastUpdated;
        private ConditionalWeakTable<object, CacheTimestamp> _cacheAccessMap;
        internal Func<IPublicClientApplication> _publicClientApplicationFactory;

        /// <summary>
        /// The internal state of the cache.
        /// </summary>
        internal byte[] Data { get; private set; }

        private class CacheTimestamp
        {
            private DateTimeOffset _timestamp;

            public CacheTimestamp()
            {
                Update();
            }

            public DateTimeOffset Update()
            {
                _timestamp = DateTimeOffset.UtcNow;
                return _timestamp;
            }

            public DateTimeOffset Value { get { return _timestamp; } }
        }

        /// <summary>
        /// Instantiates a new <see cref="TokenCache"/>.
        /// </summary>
        public TokenCache()
            : this(Array.Empty<byte>())
        {
        }

        internal TokenCache(byte[] data, Func<IPublicClientApplication> publicApplicationFactory = null)
        {
            Data = data;
            _lastUpdated = DateTimeOffset.UtcNow;
            _cacheAccessMap = new ConditionalWeakTable<object, CacheTimestamp>();
            _publicClientApplicationFactory = publicApplicationFactory ?? new Func<IPublicClientApplication>(() => PublicClientApplicationBuilder.Create(Guid.NewGuid().ToString()).Build());
        }

        /// <summary>
        /// An event notifying the subscriber that the underlying <see cref="TokenCache"/> has been updated. This event can be handled to persist the updated cache data.
        /// </summary>
        public event SyncAsyncEventHandler<TokenCacheUpdatedArgs> Updated;

        internal virtual async Task RegisterCache(bool async, ITokenCache tokenCache, CancellationToken cancellationToken)
        {
            if (async)
            {
                await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _lock.Wait(cancellationToken);
            }

            try
            {
                if (!_cacheAccessMap.TryGetValue(tokenCache, out _))
                {
                    tokenCache.SetBeforeAccessAsync(OnBeforeCacheAccessAsync);

                    tokenCache.SetAfterAccessAsync(OnAfterCacheAccessAsync);

                    _cacheAccessMap.Add(tokenCache, new CacheTimestamp());
                }
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnBeforeCacheAccessAsync(TokenCacheNotificationArgs args)
        {
            await _lock.WaitAsync().ConfigureAwait(false);

            try
            {
                args.TokenCache.DeserializeMsalV3(Data, true);

                _cacheAccessMap.GetOrCreateValue(args.TokenCache).Update();
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnAfterCacheAccessAsync(TokenCacheNotificationArgs args)
        {
            if (args.HasStateChanged)
            {
                await UpdateCacheDataAsync(args.TokenCache).ConfigureAwait(false);
            }
        }

        private async Task UpdateCacheDataAsync(ITokenCacheSerializer tokenCache)
        {
            await _lock.WaitAsync().ConfigureAwait(false);

            try
            {
                if (!_cacheAccessMap.TryGetValue(tokenCache, out CacheTimestamp lastRead) || lastRead.Value < _lastUpdated)
                {
                    Data = await MergeCacheData(Data, tokenCache.SerializeMsalV3()).ConfigureAwait(false);
                }
                else
                {
                    Data = tokenCache.SerializeMsalV3();
                }

                _lastUpdated = _cacheAccessMap.GetOrCreateValue(tokenCache).Update();
            }
            finally
            {
                _lock.Release();
            }

            if (Updated != null)
            {
                // Collect any exceptions raised by handlers
                List<Exception> failures = null;

                foreach (SyncAsyncEventHandler<TokenCacheUpdatedArgs> handler in Updated.GetInvocationList())
                {
                    try
                    {
                        await handler(new TokenCacheUpdatedArgs(this, true, default)).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        failures ??= new List<Exception>();
                        failures.Add(ex);
                    }
                    await handler(new TokenCacheUpdatedArgs(this, true)).ConfigureAwait(false);
                }

                // Wrap any exceptions in an AggregateException
                if (failures?.Count > 0)
                {
                    // Include the event name in the exception for easier debugging
                    throw new AggregateException("Unhandled exception(s) thrown when raising the Updated event.", failures);
                }
            }
        }

        private async Task<byte[]> MergeCacheData(byte[] cacheA, byte[] cacheB)
        {
            byte[] merged = null;

            IPublicClientApplication client = _publicClientApplicationFactory();

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheA));

            await client.GetAccountsAsync().ConfigureAwait(false);

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheB, shouldClearExistingCache: false));

            client.UserTokenCache.SetAfterAccess(args => merged = args.TokenCache.SerializeMsalV3());

            await client.GetAccountsAsync().ConfigureAwait(false);

            return merged;
        }
    }
}
