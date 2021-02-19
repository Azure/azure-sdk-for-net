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
        internal static readonly string s_msalCacheClientId = Guid.NewGuid().ToString();
        private readonly bool _allowUnencryptedStorage;
        private readonly string _name;
        private static AsyncLockWithValue<MsalCacheHelperWrapper> cacheHelperLock = new AsyncLockWithValue<MsalCacheHelperWrapper>();
        private readonly MsalCacheHelperWrapper _cacheHelperWrapper;

        /// <summary>
        /// Creates a new instance of <see cref="PersistentTokenCache"/> with the specified options.
        /// </summary>
        /// <param name="options">Options controlling the storage of the <see cref="PersistentTokenCache"/>.</param>
        public PersistentTokenCache(PersistentTokenCacheOptions options = null)
        {
            _allowUnencryptedStorage = options?.AllowUnencryptedStorage ?? false;
            _name = options?.Name ?? Constants.DefaultMsalTokenCacheName;
            _cacheHelperWrapper = new MsalCacheHelperWrapper();
        }

        internal PersistentTokenCache(PersistentTokenCacheOptions options, MsalCacheHelperWrapper cacheHelperWrapper)
        {
            _allowUnencryptedStorage = options?.AllowUnencryptedStorage ?? false;
            _name = options?.Name ?? Constants.DefaultMsalTokenCacheName;
            _cacheHelperWrapper = cacheHelperWrapper;
        }

        internal override async Task RegisterCache(bool async, ITokenCache tokenCache, CancellationToken cancellationToken)
        {
            MsalCacheHelperWrapper cacheHelper = await GetCacheHelperAsync(async, cancellationToken).ConfigureAwait(false);

            cacheHelper.RegisterCache(tokenCache);

            await base.RegisterCache(async, tokenCache, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Resets the <see cref="cacheHelperLock"/> so that tests can validate multiple calls to <see cref="RegisterCache"/>
        /// This should only be used for testing.
        /// </summary>
        internal static void ResetWrapperCache()
        {
            cacheHelperLock = new AsyncLockWithValue<MsalCacheHelperWrapper>();
        }

        private async Task<MsalCacheHelperWrapper> GetCacheHelperAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await cacheHelperLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            MsalCacheHelperWrapper cacheHelper;

            try
            {
                cacheHelper = await GetProtectedCacheHelperAsync(async, _name).ConfigureAwait(false);

                cacheHelper.VerifyPersistence();
            }
            catch (MsalCachePersistenceException)
            {
                if (_allowUnencryptedStorage)
                {
                    cacheHelper = await GetFallbackCacheHelperAsync(async, _name).ConfigureAwait(false);

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

        private async Task<MsalCacheHelperWrapper> GetProtectedCacheHelperAsync(bool async, string name)
        {
            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(name, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, name)
                .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, name, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                .Build();

            MsalCacheHelperWrapper cacheHelper = await InitializeCacheHelper(async, storageProperties).ConfigureAwait(false);

            return cacheHelper;
        }

        private async Task<MsalCacheHelperWrapper> GetFallbackCacheHelperAsync(bool async, string name = Constants.DefaultMsalTokenCacheName)
        {
            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(name, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, name)
                .WithLinuxUnprotectedFile()
                .Build();

            MsalCacheHelperWrapper cacheHelper = await InitializeCacheHelper(async, storageProperties).ConfigureAwait(false);

            return cacheHelper;
        }

        private async Task<MsalCacheHelperWrapper> InitializeCacheHelper(bool async, StorageCreationProperties storageProperties)
        {
            if (async)
            {
                await _cacheHelperWrapper.InitializeAsync(storageProperties).ConfigureAwait(false);
            }
            else
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                _cacheHelperWrapper.InitializeAsync(storageProperties).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            }
            return _cacheHelperWrapper;
        }
    }
}
