// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal class MsalPublicClient
    {
        private readonly IPublicClientApplication _client;
        private readonly bool _attachSharedCache;
        private readonly string _clientId;
        private readonly Lazy<Task> _ensureInitAsync;

        protected MsalPublicClient()
        {
        }

        public MsalPublicClient(HttpPipeline pipeline, Uri authorityHost, string clientId, string tenantId = default, string redirectUrl = default, bool attachSharedCache = false)
        {
            tenantId ??= Constants.OrganizationsTenantId;

            var authorityUri = new UriBuilder(authorityHost.Scheme, authorityHost.Host, authorityHost.Port, tenantId).Uri;

            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder.Create(clientId).WithAuthority(authorityUri).WithHttpClientFactory(new HttpPipelineClientFactory(pipeline));

            pubAppBuilder = pubAppBuilder.WithTenantId(tenantId);

            if (!string.IsNullOrEmpty(redirectUrl))
            {
                pubAppBuilder = pubAppBuilder.WithRedirectUri(redirectUrl);
            }

            _client = pubAppBuilder.Build();

            _clientId = clientId;

            _ensureInitAsync = new Lazy<Task>(InitializeAsync);

            _attachSharedCache = attachSharedCache;
        }

        private async Task InitializeAsync()
        {
            if (_attachSharedCache)
            {
                StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, _clientId)
                    .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                    .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, Constants.DefaultMsalTokenCacheKeyringLabel, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                    .Build();

                MsalCacheHelper cacheHelper = await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false);

                cacheHelper.RegisterCache(_client.UserTokenCache);
            }
        }

        private async ValueTask EnsureInitializedAsync(bool async)
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

        public virtual async Task<IEnumerable<IAccount>> GetAccountsAsync()
        {
            await EnsureInitializedAsync(true).ConfigureAwait(false);

            return await _client.GetAccountsAsync().ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, IAccount account, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await _client.AcquireTokenSilent(scopes, account).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, Prompt prompt, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await _client.AcquireTokenInteractive(scopes).WithPrompt(prompt).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await _client.AcquireTokenByUsernamePassword(scopes, username, password).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await _client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenByRefreshToken(string[] scopes, string refreshToken, AzureCloudInstance azureCloudInstance, string tenant, bool async, CancellationToken cancellationToken)
        {
            return await ((IByRefreshToken)_client).AcquireTokenByRefreshToken(scopes, refreshToken).WithAuthority(azureCloudInstance, tenant).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }
    }
}
