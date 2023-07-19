// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class MsalPublicClient : MsalClientBase<IPublicClientApplication>
    {
        private Action<PublicClientApplicationBuilder> _beforeBuildClient;

        internal string RedirectUrl { get; }

        protected MsalPublicClient()
        { }

        public MsalPublicClient(CredentialPipeline pipeline, string tenantId, string clientId, string redirectUrl, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            RedirectUrl = redirectUrl;

            _beforeBuildClient = (options as IMsalPublicClientInitializerOptions)?.BeforeBuildClient;
        }

        protected override ValueTask<IPublicClientApplication> CreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return CreateClientCoreAsync(enableCae, async, cancellationToken);
        }

        protected virtual ValueTask<IPublicClientApplication> CreateClientCoreAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            string[] clientCapabilities =
                enableCae ? cp1Capabilities : Array.Empty<string>();

            var authorityUri = new UriBuilder(AuthorityHost.Scheme, AuthorityHost.Host, AuthorityHost.Port, TenantId ?? Constants.OrganizationsTenantId).Uri;

            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(authorityUri)
                .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline))
                .WithLogging(LogMsal, enablePiiLogging: IsSupportLoggingEnabled);

            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                pubAppBuilder = pubAppBuilder.WithRedirectUri(RedirectUrl);
            }

            if (clientCapabilities.Length > 0)
            {
                pubAppBuilder.WithClientCapabilities(clientCapabilities);
            }

            if (_beforeBuildClient != null)
            {
                _beforeBuildClient(pubAppBuilder);
            }

            if (DisableInstanceDiscovery)
            {
                pubAppBuilder.WithInstanceDiscovery(false);
            }

            return new ValueTask<IPublicClientApplication>(pubAppBuilder.Build());
        }

        public async ValueTask<List<IAccount>> GetAccountsAsync(bool async, bool enableCae, CancellationToken cancellationToken)
        {
            return await GetAccountsCoreAsync(async, enableCae, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async ValueTask<List<IAccount>> GetAccountsCoreAsync(bool async, bool enableCae, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
            return await GetAccountsAsync(client, async).ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, IAccount account, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            var result = await AcquireTokenSilentCoreAsync(scopes, claims, account, tenantId, enableCae, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(string[] scopes, string claims, IAccount account, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
            var builder = client.AcquireTokenSilent(scopes, account)
                .WithClaims(claims);

            if (tenantId != null)
            {
                builder.WithAuthority(AuthorityHost.AbsoluteUri, tenantId);
            }

            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, AuthenticationRecord record, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            var result = await AcquireTokenSilentCoreAsync(scopes, claims, record, tenantId, enableCae, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(string[] scopes, string claims, AuthenticationRecord record, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);

            // if the user specified a TenantId when they created the client we want to authenticate to that tenant.
            // otherwise we should authenticate with the tenant specified by the authentication record since that's the tenant the
            // user authenticated to originally.
            return await client.AcquireTokenSilent(scopes, (AuthenticationAccount)record)
                .WithAuthority(AuthorityHost.AbsoluteUri, TenantId ?? record.TenantId)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, string claims, Prompt prompt, string loginHint, string tenantId, bool enableCae, BrowserCustomizationOptions browserOptions, bool async, CancellationToken cancellationToken)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA && !IdentityCompatSwitches.DisableInteractiveBrowserThreadpoolExecution)
            {
                // In the case we are called in an STA apartment thread, we need to use Task.Run to execute on the call to MSAL on the threadpool.
                // On certain platforms MSAL will use the embedded browser instead of launching the browser as a separate
                // process. Executing with Task.Run prevents possibly deadlocking the UI thread in these cases.
                // This workaround can be disabled by using the "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution" app switch
                // or setting the AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION environment variable to true
                AzureIdentityEventSource.Singleton.InteractiveAuthenticationExecutingOnThreadPool();

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                return Task.Run(async () =>
                {
                    var result = await AcquireTokenInteractiveCoreAsync(scopes, claims, prompt, loginHint, tenantId, enableCae, browserOptions, true, cancellationToken).ConfigureAwait(false);
                    LogAccountDetails(result);
                    return result;
                }).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            AzureIdentityEventSource.Singleton.InteractiveAuthenticationExecutingInline();

            var result = await AcquireTokenInteractiveCoreAsync(scopes, claims, prompt, loginHint, tenantId, enableCae, browserOptions, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenInteractiveCoreAsync(string[] scopes, string claims, Prompt prompt, string loginHint, string tenantId, bool enableCae, BrowserCustomizationOptions browserOptions, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);

            var builder = client.AcquireTokenInteractive(scopes)
                .WithPrompt(prompt)
                .WithClaims(claims)
                .WithPrompt(prompt)
                .WithClaims(claims);
            if (loginHint != null)
            {
                builder.WithLoginHint(loginHint);
            }
            if (tenantId != null)
            {
                builder.WithAuthority(AuthorityHost.AbsoluteUri, tenantId);
            }
            if (browserOptions != null)
            {
                if (browserOptions.UseEmbeddedWebView.HasValue)
                {
                    builder.WithUseEmbeddedWebView(browserOptions.UseEmbeddedWebView.Value);
                }
                if (browserOptions.SystemBrowserOptions != null)
                {
                    builder.WithSystemWebViewOptions(browserOptions.SystemBrowserOptions);
                }
            }
            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string claims, string username, string password, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            var result = await AcquireTokenByUsernamePasswordCoreAsync(scopes, claims, username, password, tenantId, enableCae, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordCoreAsync(string[] scopes, string claims, string username, string password, string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
            var builder = client
                .AcquireTokenByUsernamePassword(scopes, username, password)
                .WithClaims(claims);
            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithAuthority(AuthorityHost.AbsoluteUri, tenantId);
            }
            return await builder.ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, string claims, Func<DeviceCodeResult, Task> deviceCodeCallback, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            var result = await AcquireTokenWithDeviceCodeCoreAsync(scopes, claims, deviceCodeCallback, enableCae, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeCoreAsync(string[] scopes, string claims, Func<DeviceCodeResult, Task> deviceCodeCallback, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
            return await client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback)
                .WithClaims(claims)
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenByRefreshTokenAsync(string[] scopes, string claims, string refreshToken, AzureCloudInstance azureCloudInstance, string tenant, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            var result = await AcquireTokenByRefreshTokenCoreAsync(scopes, claims, refreshToken, azureCloudInstance, tenant, enableCae, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenByRefreshTokenCoreAsync(string[] scopes, string claims, string refreshToken, AzureCloudInstance azureCloudInstance, string tenant, bool enableCae, bool async, CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
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
