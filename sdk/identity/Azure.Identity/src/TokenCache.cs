// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    /// <summary>
    /// A cache for Tokens.
    /// </summary>
    public class TokenCache : IDisposable
    {
        private SemaphoreSlim _lock = new SemaphoreSlim(1,1);
        private byte[] _serialized;
        private DateTimeOffset _lastUpdated;
        private Dictionary<object, DateTimeOffset> _cacheAccessMap;
        private bool _disposedValue;

        private static Lazy<TokenCache> s_SharedCache = new Lazy<TokenCache>(() => new SharedTokenCache(true), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Instantiates a new <see cref="TokenCache"/>.
        /// </summary>
        public TokenCache()
        {
            _serialized = Array.Empty<byte>();
            _lastUpdated = DateTimeOffset.UtcNow;
            _cacheAccessMap = new Dictionary<object, DateTimeOffset>();
        }

        /// <summary>
        /// The shared token cache.
        /// </summary>
        public static TokenCache SharedCache => s_SharedCache.Value;

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
                if (!_cacheAccessMap.ContainsKey(tokenCache))
                {
                    tokenCache.SetBeforeAccessAsync(OnBeforeCacheAccessAsync);

                    tokenCache.SetAfterAccessAsync(OnAfterCacheAccessAsync);

                    _cacheAccessMap.Add(tokenCache, DateTimeOffset.MinValue);
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
                args.TokenCache.DeserializeMsalV3(_serialized, true);

                _cacheAccessMap[args.TokenCache] = DateTimeOffset.UtcNow;
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
                await _lock.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (!_cacheAccessMap.TryGetValue(args.TokenCache, out DateTimeOffset lastRead) || lastRead < _lastUpdated)
                    {
                        _serialized = await MergeCacheData(_serialized, args.TokenCache.SerializeMsalV3()).ConfigureAwait(false);
                    }
                    else
                    {
                        _serialized = args.TokenCache.SerializeMsalV3();
                    }
                }
                finally
                {
                    _lock.Release();
                }
            }
        }

        private static async Task<byte[]> MergeCacheData(byte[] cacheA, byte[] cacheB)
        {
            byte[] merged = null;

            var client = PublicClientApplicationBuilder.Create(Guid.NewGuid().ToString()).Build();

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheA));

            await client.GetAccountsAsync().ConfigureAwait(false);

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheB, shouldClearExistingCache: false));

            client.UserTokenCache.SetAfterAccess(args => merged = args.TokenCache.SerializeMsalV3());

            await client.GetAccountsAsync().ConfigureAwait(false);

            return merged;
        }

        /// <summary>
        /// Disposes of the <see cref="TokenCache"/>.
        /// </summary>
        /// <param name="disposing">Flag to indicate whether managed resources should be disposed of.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _lock.Dispose();
                }

                _cacheAccessMap = null;

                _serialized = null;

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes of the <see cref="TokenCache"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private class SharedTokenCache : TokenCache
        {
            // we are creating the MsalCacheHelper with a random guid based clientId to work around issue https://github.com/AzureAD/microsoft-authentication-extensions-for-dotnet/issues/98
            // This does not impact the functionality of the cacheHelper as the ClientId is only used to iterate accounts in the cache not for authentication purposes.
            private static readonly string s_msalCacheClientId = Guid.NewGuid().ToString();

            private AsyncLockWithValue<MsalCacheHelper> _cacheHelperLock = new AsyncLockWithValue<MsalCacheHelper>();
            private bool _allowUnencryptedStorage;

            public SharedTokenCache(bool allowUnencryptedStorage)
            {
                _allowUnencryptedStorage = allowUnencryptedStorage;
            }

            internal override async Task RegisterCache(bool async, ITokenCache tokenCache, CancellationToken cancellationToken)
            {
                MsalCacheHelper cacheHelper = await GetCacheHelperAsync(async, cancellationToken).ConfigureAwait(false);

                cacheHelper.RegisterCache(tokenCache);

                await base.RegisterCache(async, tokenCache, cancellationToken).ConfigureAwait(false);
            }

            private async Task<MsalCacheHelper> GetCacheHelperAsync(bool async, CancellationToken cancellationToken)
            {
                using var asyncLock = await _cacheHelperLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

                if (asyncLock.HasValue)
                {
                    return asyncLock.Value;
                }

                MsalCacheHelper cacheHelper;

                StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                    .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                    .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, Constants.DefaultMsalTokenCacheKeyringLabel, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                    .Build();

                try
                {
                    cacheHelper = await CreateCacheHelper(async, storageProperties).ConfigureAwait(false);

                    cacheHelper.VerifyPersistence();
                }
                catch (MsalCachePersistenceException)
                {
                    if (_allowUnencryptedStorage)
                    {
                        storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                            .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                            .WithLinuxUnprotectedFile()
                            .Build();

                        cacheHelper = await CreateCacheHelper(async, storageProperties).ConfigureAwait(false);

                        cacheHelper.VerifyPersistence();
                    }
                    else
                    {
                        throw;
                    }
                }

                asyncLock.SetValue(cacheHelper);

                return cacheHelper;
            }

            private static async Task<MsalCacheHelper> CreateCacheHelper(bool async, StorageCreationProperties storageProperties)
            {
                return async
                    ? await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : MsalCacheHelper.CreateAsync(storageProperties).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            }
        }
    }
}
