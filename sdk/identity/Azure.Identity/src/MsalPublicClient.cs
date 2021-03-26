// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class MsalPublicClient : MsalClientBase<IPublicClientApplication>
    {
        internal string RedirectUrl { get; }

        protected MsalPublicClient()
        {
        }

        public MsalPublicClient(CredentialPipeline pipeline, string tenantId, string clientId, string redirectUrl, ITokenCacheOptions cacheOptions)
            : base(pipeline, tenantId, clientId, cacheOptions)
        {
            RedirectUrl = redirectUrl;
        }

        protected override ValueTask<IPublicClientApplication> CreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            var authorityHost = Pipeline.AuthorityHost;

            var authorityUri = new UriBuilder(authorityHost.Scheme, authorityHost.Host, authorityHost.Port, TenantId ?? Constants.OrganizationsTenantId).Uri;

            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder.Create(ClientId).WithAuthority(authorityUri).WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline)).WithLogging(AzureIdentityEventSource.Singleton.LogMsal);

            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                pubAppBuilder = pubAppBuilder.WithRedirectUri(RedirectUrl);
            }

            pubAppBuilder.WithClientCapabilities(new string[] { "CP1" });

            return new ValueTask<IPublicClientApplication>(pubAppBuilder.Build());
        }

        public virtual async ValueTask<List<IAccount>> GetAccountsAsync(bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await GetAccountsAsync(client, async).ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, IAccount account, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await client.AcquireTokenSilent(scopes, account)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }
        public virtual async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, AuthenticationRecord record, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            // if the user specified a TenantId when they created the client we want to authenticate to that tenant.
            // otherwise we should authenticate with the tenant specified by the authentication record since that's the tenant the
            // user authenticated to originally.
            return await client.AcquireTokenSilent(scopes, (AuthenticationAccount)record)
                .WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, TenantId ?? record.TenantId)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, string claims, Prompt prompt, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await client.AcquireTokenInteractive(scopes)
                .WithPrompt(prompt)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string claims, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await client.AcquireTokenByUsernamePassword(scopes, username, password)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, string claims, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenByRefreshToken(string[] scopes, string claims, string refreshToken, AzureCloudInstance azureCloudInstance, string tenant, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);
            return await ((IByRefreshToken)client).AcquireTokenByRefreshToken(scopes, refreshToken)
                .WithAuthority(azureCloudInstance, tenant)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        private static async ValueTask<List<IAccount>> GetAccountsAsync(IPublicClientApplication client, bool async)
        {
            var result = async
                ? await client.GetAccountsAsync().ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : client.GetAccountsAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            return result.ToList();
        }
    }
}
