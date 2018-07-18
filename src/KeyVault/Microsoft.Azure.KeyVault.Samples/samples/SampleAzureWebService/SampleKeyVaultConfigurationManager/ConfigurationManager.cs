// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.KeyVault;

namespace SampleKeyVaultConfigurationManager
{
    /// <summary>
    /// This class manages service configuration settings.
    /// </summary>
    public static class ConfigurationManager
    {
        #region public

        /// <summary>
        /// Initializes settings for authentication to Key Vault 
        /// </summary>
        /// <param name="authenticationCallback"> Key Vault authentication callback </param>
        /// <param name="defaultCacheLifespanSettingName">Default cache's lifespan setting name </param>
        public static void Initialize(KeyVaultClient.AuthenticationCallback authenticationCallback, string defaultCacheLifespanSettingName = null)
        {

            keyVaultClient = new KeyVaultClient(authenticationCallback);
            defaultCacheExpirationSettingName = defaultCacheLifespanSettingName;
            SetDefaultCacheExpirationTimeSpan();
        }

        /// <summary>
        /// Retrieves a configuration value or resolves the settings to its corresponding object
        /// Uses an in-memory cache in which throws away content after a certain time.
        /// </summary>
        /// <param name="settingName"> The setting name to get resolved or retrieved </param>
        /// <param name="cachedExpirationTimeSpan"> The cache expiration time span </param>
        /// <returns> The retrieved or resolved setting </returns>
        public static async Task<string> GetSettingAsync(string settingName, TimeSpan? cachedExpirationTimeSpan = null)
        {
            var settingValue = GetConfigurationSetting(settingName);

            // The secret value is cached along with the secret URL as a seperate cached entry because otherwise each time the secret URL would be 
            // retrieved from configuration file and if the secret value overwrites the secret URL, from different threads, the secret could be retrieved multiple times
            if (SecretIdentifier.IsSecretIdentifier(settingValue))
                return await ResolveSecretSettingAsync(settingValue, cachedExpirationTimeSpan).ConfigureAwait(false);

            // this could be extended to other types of resolution

            return settingValue;
        }

        /// <summary>
        /// Removes all the cache entries.
        /// </summary>
        public static void Reset()
        {
            var oldCache = memoryCache;

            memoryCache = new MemoryCache(cacheName);

            oldCache.Dispose();

            SetDefaultCacheExpirationTimeSpan();
        }

        #endregion

        #region private

        /// <summary>
        /// Get the configuration setting from cache or if not available from cloud configuration
        /// </summary>
        /// <param name="settingName"> the setting name </param>
        /// <returns> the configuration value</returns>
        private static string GetConfigurationSetting(string settingName)
        {
            var configurationSettingFactory = new Lazy<string>(
                    () => CloudConfigurationManager.GetSetting(settingName));

            return CacheAddOrGet(settingName, configurationSettingFactory, ObjectCache.InfiniteAbsoluteExpiration);
        }

        /// <summary>
        /// Resolves secret setting by calling Key Vault
        /// </summary>
        /// <param name="secretUrl"> The secret URL </param>
        /// <param name="cachedExpirationTimeSpan"> the time span to keep the secret value in the cache </param>
        /// <returns> the secret value </returns>
        private static async Task<string> ResolveSecretSettingAsync(string secretUrl, TimeSpan? cachedExpirationTimeSpan)
        {
            if (keyVaultClient == null)
                throw new Exception("ConfigurationManager.Initialize need to be called to retrieve secrets.");

            // set the expiry time to infinity if not specified
            var absoluteExpiration = DateTimeOffset.Now + (cachedExpirationTimeSpan ?? defaultCacheExpirationTimeSpan);

            var keyvaultSettingFactory = new Lazy<Task<string>>(
                async () =>
                    {
                        var secret = await keyVaultClient.GetSecretAsync(secretUrl).ConfigureAwait(false);
                        return secret.Value;
                    });

            //Resolve the value
            return await CacheAddOrGet(secretUrl, keyvaultSettingFactory, absoluteExpiration).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a cache value. If the value does not exists add that to the cache and then return
        /// </summary>
        /// <typeparam name="T"> The type of the cached value </typeparam>
        /// <param name="settingName"> The setting name </param>
        /// <param name="newValueFactory"> A factory method to resolve the setting name to its value </param>
        /// <param name="policy"> The caching policy </param>
        /// <returns> Cached value corresponds to the setting </returns>
        private static T CacheAddOrGet<T>(string settingName, Lazy<T> newValueFactory, DateTimeOffset absoluteExpiration)
        {
            // Get the existing cache member or if not available add new value. 
            // AddOrGetExisting is a thread-safe atomic operation which handles the locking mechanism for thread safty. 
            // To use the operation, the value is passes in as Lazy initialization to only be calculated when the key is not in the cache and to be atomic and thread-safe.
            Lazy<T> cachedValue = memoryCache.AddOrGetExisting(
                               settingName,
                               newValueFactory,
                               absoluteExpiration) as Lazy<T>;
            try
            {
                // For the first time adding the cache entry, cachedValue is set to null so the lazy object will be initialized
                return (cachedValue ?? newValueFactory).Value;
            }
            catch
            {
                // Evict from cache the secret that caused the exception to throw
                memoryCache.Remove(settingName);
                throw;
            }
        }

        private static void SetDefaultCacheExpirationTimeSpan()
        {
            if (defaultCacheExpirationSettingName == null)
                defaultCacheExpirationTimeSpan = TimeSpan.Zero;
            var timeSpanValue = GetConfigurationSetting(defaultCacheExpirationSettingName);
            TimeSpan.TryParse(timeSpanValue, out defaultCacheExpirationTimeSpan);
        }

        private const string cacheName = "ConfigManagerCache";

        // The cache will store both the role setting value and Key Vault secret value
        private static MemoryCache memoryCache = new MemoryCache(cacheName);

        private static KeyVaultClient keyVaultClient;
        private static string defaultCacheExpirationSettingName;
        private static TimeSpan defaultCacheExpirationTimeSpan;

        #endregion
    }
}
