// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    /// <summary>
    /// Persistent token cache.
    /// </summary>
    public class PersistentTokenCache : TokenCache
    {
        // we are creating the MsalCacheHelper with a random guid based clientId to work around issue https://github.com/AzureAD/microsoft-authentication-extensions-for-dotnet/issues/98
        // This does not impact the functionality of the cacheHelper as the ClientId is only used to iterate accounts in the cache not for authentication purposes.
        private static readonly string s_msalCacheClientId = Guid.NewGuid().ToString();

        private static AsyncLockWithValue<MsalCacheHelper> cacheHelperLock = new AsyncLockWithValue<MsalCacheHelper>();
        private static AsyncLockWithValue<MsalCacheHelper> s_ProtectedCacheHelperLock = new AsyncLockWithValue<MsalCacheHelper>();
        private static AsyncLockWithValue<MsalCacheHelper> s_FallbackCacheHelperLock = new AsyncLockWithValue<MsalCacheHelper>();
        private readonly bool _allowUnencryptedStorage;
        private readonly string _name;

        /// <summary>
        /// Creates a new instance of <see cref="PersistentTokenCache"/>.
        /// </summary>
        /// <param name="allowUnencryptedStorage"></param>
        public PersistentTokenCache(bool allowUnencryptedStorage = true)
        {
            _allowUnencryptedStorage = allowUnencryptedStorage;
        }

        /// <summary>
        /// Creates a new instance of <see cref="PersistentTokenCache"/> with the specified options.
        /// </summary>
        /// <param name="options">Options controlling the storage of the <see cref="PersistentTokenCache"/>.</param>
        public PersistentTokenCache(PersistentTokenCacheOptions options)
        {
            _allowUnencryptedStorage = options?.AllowUnencryptedStorage ?? false;

            _name = options?.Name;
        }

        internal override async Task RegisterCache(bool async, ITokenCache tokenCache, CancellationToken cancellationToken)
        {
            MsalCacheHelper cacheHelper = await GetCacheHelperAsync(async, cancellationToken).ConfigureAwait(false);

            cacheHelper.RegisterCache(tokenCache);

            await base.RegisterCache(async, tokenCache, cancellationToken).ConfigureAwait(false);
        }

        private async Task<MsalCacheHelper> GetCacheHelperAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await cacheHelperLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            MsalCacheHelper cacheHelper;

            try
            {
                cacheHelper = string.IsNullOrEmpty(_name) ? await GetProtectedCacheHelperAsync(async, cancellationToken).ConfigureAwait(false) : await GetProtectedCacheHelperAsync(async, _name).ConfigureAwait(false);

                cacheHelper.VerifyPersistence();
            }
            catch (MsalCachePersistenceException)
            {
                if (_allowUnencryptedStorage)
                {
                    cacheHelper = string.IsNullOrEmpty(_name) ? await GetFallbackCacheHelperAsync(async, cancellationToken).ConfigureAwait(false) : await GetFallbackCacheHelperAsync(async, _name).ConfigureAwait(false);

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

        private static async Task<MsalCacheHelper> GetProtectedCacheHelperAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await s_ProtectedCacheHelperLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            MsalCacheHelper cacheHelper = await GetProtectedCacheHelperAsync(async, Constants.DefaultMsalTokenCacheName).ConfigureAwait(false);

            asyncLock.SetValue(cacheHelper);

            return cacheHelper;
        }

        private static async Task<MsalCacheHelper> GetProtectedCacheHelperAsync(bool async, string name)
        {
            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(name, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, name)
                .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, name, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                .Build();

            MsalCacheHelper cacheHelper = await CreateCacheHelper(async, storageProperties).ConfigureAwait(false);

            return cacheHelper;
        }

        private static async Task<MsalCacheHelper> GetFallbackCacheHelperAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await s_FallbackCacheHelperLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            MsalCacheHelper cacheHelper = await GetFallbackCacheHelperAsync(async, Constants.DefaultMsalTokenCacheName).ConfigureAwait(false);

            asyncLock.SetValue(cacheHelper);

            return cacheHelper;
        }

        private static async Task<MsalCacheHelper> GetFallbackCacheHelperAsync(bool async, string name)
        {
            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(name, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, name)
                .WithLinuxUnprotectedFile()
                .Build();

            MsalCacheHelper cacheHelper = await CreateCacheHelper(async, storageProperties).ConfigureAwait(false);

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
