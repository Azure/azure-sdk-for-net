// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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

            if (options is IMsalPublicClientInitializerOptions initializerOptions)
            {
                _beforeBuildClient = initializerOptions.BeforeBuildClient;
            }
            else if (options is IMsalSettablePublicClientInitializerOptions settableInitializerOptions)
            {
                _beforeBuildClient = settableInitializerOptions.BeforeBuildClient;
            }
        }

        protected override ValueTask<IPublicClientApplication> CreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return CreateClientCoreAsync(enableCae, async, cancellationToken);
        }

        protected virtual ValueTask<IPublicClientApplication> CreateClientCoreAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            string[] clientCapabilities =
                enableCae ? cp1Capabilities : Array.Empty<string>();

            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(AuthorityHost.AbsoluteUri, TenantId ?? Constants.OrganizationsTenantId, false)
                .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline))
                .WithLogging(AzureIdentityEventSource.Singleton, enablePiiLogging: IsSupportLoggingEnabled);

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

        public async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
            string[] scopes,
            string claims,
            IAccount account,
            string tenantId,
            bool enableCae,
            TokenRequestContext context,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenSilentCoreAsync(
                scopes,
                claims,
                account,
                tenantId,
                enableCae,
                context,
                async,
                cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            string claims,
            IAccount account,
            string tenantId,
            bool enableCae,
            TokenRequestContext context,
            bool async,
            CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);
            var builder = client.AcquireTokenSilent(scopes, account);

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }
            if (tenantId != null)
            {
                builder.WithTenantId(tenantId);
            }

            if (context.IsProofOfPossessionEnabled)
            {
                builder.WithProofOfPossession(context.ProofOfPossessionNonce, new(context.ResourceRequestMethod), context.ResourceRequestUri);
            }

            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
            string[] scopes,
            string claims,
            AuthenticationRecord record,
            string tenantId,
            bool enableCae,
            TokenRequestContext tokenRequestContext,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenSilentCoreAsync(
                scopes,
                claims,
                record,
                tenantId,
                enableCae,
                tokenRequestContext,
                async,
                cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            string claims,
            AuthenticationRecord record,
            string tenantId,
            bool enableCae,
            TokenRequestContext context,
            bool async,
            CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);

            // if the user specified a TenantId when they created the client we want to authenticate to that tenant.
            // otherwise we should authenticate with the tenant specified by the authentication record since that's the tenant the
            // user authenticated to originally.
            var builder = client.AcquireTokenSilent(scopes, (AuthenticationAccount)record);

            if (tenantId != null || record.TenantId != null)
            {
                builder.WithTenantId(tenantId ?? record.TenantId);
            }

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }
            if (context.IsProofOfPossessionEnabled)
            {
                builder.WithProofOfPossession(context.ProofOfPossessionNonce, new(context.ResourceRequestMethod), context.ResourceRequestUri);
            }

            return await builder.ExecuteAsync(async, cancellationToken)
                           .ConfigureAwait(false);
        }

        public async ValueTask<AuthenticationResult> AcquireTokenInteractiveAsync(
            string[] scopes,
            string claims,
            Prompt prompt,
            string loginHint,
            string tenantId,
            bool enableCae,
            BrowserCustomizationOptions browserOptions,
            TokenRequestContext tokenRequestContext,
            bool async,
            CancellationToken cancellationToken)
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
                    var result = await AcquireTokenInteractiveCoreAsync(
                        scopes,
                        claims,
                        prompt,
                        loginHint,
                        tenantId,
                        enableCae,
                        browserOptions,
                        tokenRequestContext,
                        true,
                        cancellationToken).ConfigureAwait(false);
                    LogAccountDetails(result);
                    return result;
                }).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            AzureIdentityEventSource.Singleton.InteractiveAuthenticationExecutingInline();

            var result = await AcquireTokenInteractiveCoreAsync(
                scopes,
                claims,
                prompt,
                loginHint,
                tenantId,
                enableCae,
                browserOptions,
                tokenRequestContext,
                async,
                cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        protected virtual async ValueTask<AuthenticationResult> AcquireTokenInteractiveCoreAsync(
            string[] scopes,
            string claims,
            Prompt prompt,
            string loginHint,
            string tenantId,
            bool enableCae,
            BrowserCustomizationOptions browserOptions,
            TokenRequestContext tokenRequestContext,
            bool async,
            CancellationToken cancellationToken)
        {
            IPublicClientApplication client = await GetClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);

            var builder = client.AcquireTokenInteractive(scopes)
                .WithPrompt(prompt);

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }
            if (loginHint != null)
            {
                builder.WithLoginHint(loginHint);
            }
            if (tenantId != null)
            {
                builder.WithTenantId(tenantId);
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
            if (tokenRequestContext.IsProofOfPossessionEnabled)
            {
                builder.WithProofOfPossession(tokenRequestContext.ProofOfPossessionNonce, new(tokenRequestContext.ResourceRequestMethod), tokenRequestContext.ResourceRequestUri);
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
#pragma warning disable CS0618 // Type or member is obsolete
            var builder = client
                .AcquireTokenByUsernamePassword(scopes, username, password);
#pragma warning restore CS0618 // Type or member is obsolete

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }
            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithTenantId(tenantId);
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
            var builder = client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback);

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }
            if (!string.IsNullOrEmpty(TenantId))
            {
                builder.WithTenantId(TenantId);
            }

            return await builder.ExecuteAsync(async, cancellationToken)
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
            var builder = ((IByRefreshToken)client).AcquireTokenByRefreshToken(scopes, refreshToken);

            if (!string.IsNullOrEmpty(claims))
            {
                builder.WithClaims(claims);
            }

            if (!string.IsNullOrEmpty(TenantId))
            {
                builder.WithTenantId(TenantId);
            }

            return await builder.ExecuteAsync(async, cancellationToken)
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
