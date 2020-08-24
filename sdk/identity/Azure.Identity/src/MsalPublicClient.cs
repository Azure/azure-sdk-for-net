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
    internal class MsalPublicClient : MsalClientBase<IPublicClientApplication>
    {
        private readonly string _redirectUrl;

        protected MsalPublicClient()
        {
        }

        public MsalPublicClient(CredentialPipeline pipeline, string tenantId, string clientId, string redirectUrl, ITokenCacheOptions cacheOptions)
            : base(pipeline, tenantId, clientId, cacheOptions)
        {
            _redirectUrl = redirectUrl;
        }

        protected override Task<IPublicClientApplication> CreateClientAsync()
        {
            var authorityHost = Pipeline.AuthorityHost;

            var authorityUri = new UriBuilder(authorityHost.Scheme, authorityHost.Host, authorityHost.Port, TenantId ?? Constants.OrganizationsTenantId).Uri;

            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder.Create(ClientId).WithAuthority(authorityUri).WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline));

            if (!string.IsNullOrEmpty(_redirectUrl))
            {
                pubAppBuilder = pubAppBuilder.WithRedirectUri(_redirectUrl);
            }

            return Task.FromResult(pubAppBuilder.Build());
        }

        public virtual async Task<IEnumerable<IAccount>> GetAccountsAsync()
        {
            await EnsureInitializedAsync(true).ConfigureAwait(false);

            return await Client.GetAccountsAsync().ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, IAccount account, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await Client.AcquireTokenSilent(scopes, account).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, Prompt prompt, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await Client.AcquireTokenInteractive(scopes).WithPrompt(prompt).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await Client.AcquireTokenByUsernamePassword(scopes, username, password).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await Client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenByRefreshToken(string[] scopes, string refreshToken, AzureCloudInstance azureCloudInstance, string tenant, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await ((IByRefreshToken)Client).AcquireTokenByRefreshToken(scopes, refreshToken).WithAuthority(azureCloudInstance, tenant).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }
    }
}
