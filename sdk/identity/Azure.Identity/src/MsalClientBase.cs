// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal abstract class MsalClientBase<TClient>
        where TClient : IClientApplicationBase
    {
        private readonly Lazy<Task> _ensureInitAsync;

        /// <summary>
        /// For mocking purposes only.
        /// </summary>
        protected MsalClientBase()
        {
        }

        protected MsalClientBase(CredentialPipeline pipeline, string tenantId, string clientId, ITokenCacheOptions cacheOptions)
        {
            Pipeline = pipeline;

            TenantId = tenantId;

            ClientId = clientId;

            EnablePersistentCache = cacheOptions?.EnablePersistentCache ?? false;

            AllowUnencryptedCache = cacheOptions?.AllowUnencryptedCache ?? false;

            _ensureInitAsync = new Lazy<Task>(InitializeAsync);
        }

        protected string TenantId { get; }

        protected string ClientId { get; }

        protected bool EnablePersistentCache { get; }

        protected bool AllowUnencryptedCache { get; }

        protected CredentialPipeline Pipeline { get; }

        protected TClient Client { get; private set; }

        protected abstract Task<TClient> CreateClientAsync();

        protected async Task EnsureInitializedAsync(bool async)
        {
            if (async)
            {
                await _ensureInitAsync.Value.ConfigureAwait(false);
            }
            else
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _ensureInitAsync.Value.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }
        }

        private async Task InitializeAsync()
        {
            Client = await CreateClientAsync().ConfigureAwait(false);

            if (EnablePersistentCache)
            {
                MsalCacheHelper cacheHelper;

                StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, ClientId)
                    .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                    .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, Constants.DefaultMsalTokenCacheKeyringLabel, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                    .Build();

                try
                {
                    cacheHelper = await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false);

                    cacheHelper.VerifyPersistence();
                }
                catch (MsalCachePersistenceException)
                {
                    if (AllowUnencryptedCache)
                    {
                        storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, ClientId)
                            .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                            .WithLinuxUnprotectedFile()
                            .Build();

                        cacheHelper = await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false);

                        cacheHelper.VerifyPersistence();
                    }
                    else
                    {
                        throw;
                    }
                }

                cacheHelper.RegisterCache(Client.UserTokenCache);
            }
        }
    }
}
