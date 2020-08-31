// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal abstract class MsalClientBase<TClient>
        where TClient : IClientApplicationBase
    {
        // we are creating the MsalCacheHelper with a random guid based clientId to work around issue https://github.com/AzureAD/microsoft-authentication-extensions-for-dotnet/issues/98
        // This does not impact the functionality of the cacheHelper as the ClientId is only used to iterate accounts in the cache not for authentication purposes.
        private static readonly string s_msalCacheClientId = Guid.NewGuid().ToString();

        private readonly AsyncLockWithValue<TClient> _clientAsyncLock;

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

            _clientAsyncLock = new AsyncLockWithValue<TClient>();
        }

        internal string TenantId { get; }

        internal string ClientId { get; }

        internal bool EnablePersistentCache { get; }

        internal bool AllowUnencryptedCache { get; }

        protected CredentialPipeline Pipeline { get; }

        protected abstract ValueTask<TClient> CreateClientAsync(bool async, CancellationToken cancellationToken);

        protected async ValueTask<TClient> GetClientAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _clientAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            var client = await CreateClientAsync(async, cancellationToken).ConfigureAwait(false);

            if (EnablePersistentCache)
            {
                MsalCacheHelper cacheHelper;

                StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                    .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                    .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, Constants.DefaultMsalTokenCacheKeyringLabel, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                    .Build();

                try
                {
                    cacheHelper = await CreateCacheHelper(storageProperties, async).ConfigureAwait(false);

                    cacheHelper.VerifyPersistence();
                }
                catch (MsalCachePersistenceException)
                {
                    if (AllowUnencryptedCache)
                    {
                        storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, s_msalCacheClientId)
                            .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                            .WithLinuxUnprotectedFile()
                            .Build();

                        cacheHelper = await CreateCacheHelper(storageProperties, async).ConfigureAwait(false);

                        cacheHelper.VerifyPersistence();
                    }
                    else
                    {
                        throw;
                    }
                }

                cacheHelper.RegisterCache(client.UserTokenCache);
            }

            asyncLock.SetValue(client);
            return client;
        }

        private static async ValueTask<MsalCacheHelper> CreateCacheHelper(StorageCreationProperties storageProperties, bool async)
        {
            return async
                ? await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : MsalCacheHelper.CreateAsync(storageProperties).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }
    }
}
