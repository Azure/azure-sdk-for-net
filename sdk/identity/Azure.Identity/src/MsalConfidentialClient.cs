﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

namespace Azure.Identity
{
    internal class MsalConfidentialClient : MsalClientBase<IConfidentialClientApplication>
    {
        private const string s_instanceMetadata = "{\"tenant_discovery_endpoint\":\"https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration\",\"api-version\":\"1.1\",\"metadata\":[{\"preferred_network\":\"login.microsoftonline.com\",\"preferred_cache\":\"login.windows.net\",\"aliases\":[\"login.microsoftonline.com\",\"login.windows.net\",\"login.microsoft.com\",\"sts.windows.net\"]}]}";
        internal readonly string _clientSecret;
        internal readonly bool _includeX5CClaimHeader;
        internal readonly IX509Certificate2Provider _certificateProvider;
        private readonly Func<string> _assertionCallback;
        private readonly Func<CancellationToken, Task<string>> _asyncAssertionCallback;
        private readonly Func<AppTokenProviderParameters, Task<AppTokenProviderResult>> _appTokenProviderCallback;

        internal string RedirectUrl { get; }

        /// <summary>
        /// For mocking purposes only.
        /// </summary>
        protected MsalConfidentialClient()
        { }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, string clientSecret, string redirectUrl, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            _clientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, IX509Certificate2Provider certificateProvider, bool includeX5CClaimHeader, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            _includeX5CClaimHeader = includeX5CClaimHeader;
            _certificateProvider = certificateProvider;
        }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, Func<string> assertionCallback, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            _assertionCallback = assertionCallback;
        }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, Func<CancellationToken, Task<string>> assertionCallback, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            _asyncAssertionCallback = assertionCallback;
        }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, Func<AppTokenProviderParameters, Task<AppTokenProviderResult>> appTokenProviderCallback, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, options)
        {
            _appTokenProviderCallback = appTokenProviderCallback;
        }

        internal string RegionalAuthority { get; } = EnvironmentVariables.AzureRegionalAuthorityName;

        protected override async ValueTask<IConfidentialClientApplication> CreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            ConfidentialClientApplicationBuilder confClientBuilder = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline))
                .WithLogging(LogMsal, enablePiiLogging: IsPiiLoggingEnabled);

            //special case for using appTokenProviderCallback, authority validation and instance metadata discovery should be disabled since we're not calling the STS
            if (_appTokenProviderCallback != null)
            {
                confClientBuilder.WithAppTokenProvider(_appTokenProviderCallback)
                    .WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, TenantId, false)
                    .WithInstanceDiscoveryMetadata(s_instanceMetadata);
            }
            else
            {
                confClientBuilder.WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, TenantId);
            }

            if (_clientSecret != null)
            {
                confClientBuilder.WithClientSecret(_clientSecret);
            }

            if (_assertionCallback != null)
            {
                confClientBuilder.WithClientAssertion(_assertionCallback);
            }

            if (_asyncAssertionCallback != null)
            {
                confClientBuilder.WithClientAssertion(_asyncAssertionCallback);
            }

            if (_certificateProvider != null)
            {
                X509Certificate2 clientCertificate = await _certificateProvider.GetCertificateAsync(async, cancellationToken).ConfigureAwait(false);
                confClientBuilder.WithCertificate(clientCertificate);
            }

            if (!string.IsNullOrEmpty(RegionalAuthority))
            {
                confClientBuilder.WithAzureRegion(RegionalAuthority);
            }

            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                confClientBuilder.WithRedirectUri(RedirectUrl);
            }

            return confClientBuilder.Build();
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForClientAsync(
            string[] scopes,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenForClientCoreAsync(scopes, tenantId, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForClientCoreAsync(
            string[] scopes,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            IConfidentialClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            var builder = client
                .AcquireTokenForClient(scopes)
                .WithSendX5C(_includeX5CClaimHeader);

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, tenantId);
            }
            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
            string[] scopes,
            AuthenticationAccount account,
            string tenantId,
            string redirectUri,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenSilentCoreAsync(scopes, account, tenantId, redirectUri, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            AuthenticationAccount account,
            string tenantId,
            string redirectUri,
            bool async,
            CancellationToken cancellationToken)
        {
            IConfidentialClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            var builder = client.AcquireTokenSilent(scopes, account);
            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, tenantId);
            }
            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenByAuthorizationCodeAsync(
            string[] scopes,
            string code,
            string tenantId,
            string redirectUri,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenByAuthorizationCodeCoreAsync(scopes, code, tenantId, redirectUri, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenByAuthorizationCodeCoreAsync(
            string[] scopes,
            string code,
            string tenantId,
            string redirectUri,
            bool async,
            CancellationToken cancellationToken)
        {
            IConfidentialClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            var builder = client.AcquireTokenByAuthorizationCode(scopes, code);

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, tenantId);
            }
            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenOnBehalfOfAsync(
            string[] scopes,
            string tenantId,
            UserAssertion userAssertionValue,
            bool async,
            CancellationToken cancellationToken)
        {
            var result = await AcquireTokenOnBehalfOfCoreAsync(scopes, tenantId, userAssertionValue, async, cancellationToken).ConfigureAwait(false);
            LogAccountDetails(result);
            return result;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenOnBehalfOfCoreAsync(
            string[] scopes,
            string tenantId,
            UserAssertion userAssertionValue,
            bool async,
            CancellationToken cancellationToken)
        {
            IConfidentialClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            var builder = client
                .AcquireTokenOnBehalfOf(scopes, userAssertionValue)
                .WithSendX5C(_includeX5CClaimHeader);

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder.WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, tenantId);
            }
            return await builder
                .ExecuteAsync(async, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
