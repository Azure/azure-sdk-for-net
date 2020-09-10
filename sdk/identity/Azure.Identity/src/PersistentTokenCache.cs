using System;
using System.Collections.Generic;
using System.Text;
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

        private AsyncLockWithValue<MsalCacheHelper> _cacheHelperLock = new AsyncLockWithValue<MsalCacheHelper>();
        private bool _allowUnencryptedStorage;

        /// <summary>
        /// Creation.
        /// </summary>
        /// <param name="allowUnencryptedStorage"></param>
        public PersistentTokenCache(bool allowUnencryptedStorage)
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

        protected override void Dispose(bool disposing)
        {
            MsalCacheHelper helper;
            base.Dispose(disposing);
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
