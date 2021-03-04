// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal class MsalCacheHelperWrapper
    {
        private MsalCacheHelper _helper;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MsalCacheHelperWrapper()
        {
        }

        /// <summary>
        /// Creates a new instance of Microsoft.Identity.Client.Extensions.Msal.MsalCacheHelper.
        /// To configure MSAL to use this cache persistence, call Microsoft.Identity.Client.Extensions.Msal.MsalCacheHelper.RegisterCache(Microsoft.Identity.Client.ITokenCache)
        /// </summary>
        /// <param name="storageCreationProperties"></param>
        /// <param name="logger">Passing null uses a default logger</param>
        /// <returns>A new instance of Microsoft.Identity.Client.Extensions.Msal.MsalCacheHelper.</returns>
        public virtual async Task InitializeAsync(StorageCreationProperties storageCreationProperties, TraceSource logger = null)
        {
            _helper = await MsalCacheHelper.CreateAsync(storageCreationProperties, logger).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs a write -> read -> clear using the underlying persistence mechanism
        /// and throws an Microsoft.Identity.Client.Extensions.Msal.MsalCachePersistenceException
        /// if something goes wrong.
        /// </summary>
        /// <remarks>
        /// Does not overwrite the token cache. Should never fail on Windows and Mac where
        /// the cache accessors are guaranteed to exist by the OS.
        /// </remarks>
        public virtual void VerifyPersistence()
        {
            _helper.VerifyPersistence();
        }

        /// <summary>
        /// Registers a token cache to synchronize with on disk storage.
        /// </summary>
        /// <param name="tokenCache"></param>
        public virtual void RegisterCache(ITokenCache tokenCache)
        {
            _helper.RegisterCache(tokenCache);
        }

        /// <summary>
        /// Unregisters a token cache so it no longer synchronizes with on disk storage.
        /// </summary>
        /// <param name="tokenCache"></param>
        public virtual void UnregisterCache(ITokenCache tokenCache)
        {
            _helper.UnregisterCache(tokenCache);
        }

        /// <summary>
        /// Clears the token store.
        /// </summary>
        public virtual void Clear()
        {
            _helper.Clear();
        }

        /// <summary>
        /// Extracts the token cache data from the persistent store
        /// </summary>
        /// <remarks>
        /// This method should be used with care. The data returned is unencrypted.
        /// </remarks>
        /// <returns>UTF-8 byte array of the unencrypted token cache</returns>
        public virtual byte[] LoadUnencryptedTokenCache()
        {
            return _helper.LoadUnencryptedTokenCache();
        }

        /// <summary>
        /// Saves an unencrypted, UTF-8 encoded byte array representing an MSAL token cache.
        /// The save operation will persist the data in a secure location, as configured
        /// in Microsoft.Identity.Client.Extensions.Msal.StorageCreationProperties
        /// </summary>
        public virtual void SaveUnencryptedTokenCache(byte[] tokenCache)
        {
            _helper.SaveUnencryptedTokenCache(tokenCache);
        }
    }
}
