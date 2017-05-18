﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// An implementation of the Adal token cache that stores the cache items
    /// in the DPAPI-protected file.
    /// </summary>
    public class ProtectedFileTokenCache : TokenCache
    {
        private static readonly string CacheFileName = Path.Combine(AzureSession.ProfileDirectory, AzureSession.TokenCacheFile);

        private static readonly object fileLock = new object();

        private static readonly Lazy<ProtectedFileTokenCache> instance = new Lazy<ProtectedFileTokenCache>(() => new ProtectedFileTokenCache());

        // Initializes the cache against a local file.
        // If the file is already present, it loads its content in the ADAL cache
        private ProtectedFileTokenCache()
        {
            Initialize(CacheFileName);
        }

        private void Initialize(string fileName)
        {
            AfterAccess = AfterAccessNotification;
            BeforeAccess = BeforeAccessNotification;
            lock (fileLock)
            {
                if (AzureSession.DataStore.FileExists(fileName))
                {
                    var existingData = AzureSession.DataStore.ReadFileAsBytes(fileName);
                    if (existingData != null)
                    {
                        try
                        {
                            Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
                        }
                        catch (CryptographicException)
                        {
                            AzureSession.DataStore.DeleteFile(fileName);
                        }
                    }
                }
            }
        }

        public ProtectedFileTokenCache(string cacheFile)
        {
            Initialize(cacheFile);
        }

        // Empties the persistent store.
        public override void Clear()
        {
            base.Clear();
            if (AzureSession.DataStore.FileExists(CacheFileName))
            {
                AzureSession.DataStore.DeleteFile(CacheFileName);
            }
        }

        // Triggered right before ADAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (fileLock)
            {
                if (AzureSession.DataStore.FileExists(CacheFileName))
                {
                    var existingData = AzureSession.DataStore.ReadFileAsBytes(CacheFileName);
                    if (existingData != null)
                    {
                        try
                        {
                            Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
                        }
                        catch (CryptographicException)
                        {
                            AzureSession.DataStore.DeleteFile(CacheFileName);
                        }
                    }
                }
            }
        }

        // Triggered right after ADAL accessed the cache.
        void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (HasStateChanged)
            {
                lock (fileLock)
                {
                    // reflect changes in the persistent store
                    AzureSession.DataStore.WriteFile(CacheFileName,
                        ProtectedData.Protect(Serialize(), null, DataProtectionScope.CurrentUser));
                    // once the write operation took place, restore the HasStateChanged bit to false
                    HasStateChanged = false;
                }
            }
        }
    }
}
