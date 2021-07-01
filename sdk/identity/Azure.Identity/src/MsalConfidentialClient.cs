// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal class MsalConfidentialClient : MsalClientBase<IConfidentialClientApplication>
    {
        private readonly string _clientSecret;
        private readonly bool _includeX5CClaimHeader;
        private readonly ClientCertificateCredential.IX509Certificate2Provider _certificateProvider;

        /// <summary>
        /// For mocking purposes only.
        /// </summary>
        protected MsalConfidentialClient()
            : base()
        { }

        public MsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, string clientSecret, ITokenCacheOptions cacheOptions)
            : base(pipeline, tenantId, clientId, cacheOptions)
        {
            _clientSecret = clientSecret;
        }

        public MsalConfidentialClient(
            CredentialPipeline pipeline,
            string tenantId,
            string clientId,
            ClientCertificateCredential.IX509Certificate2Provider certificateProvider,
            bool includeX5CClaimHeader,
            ITokenCacheOptions cacheOptions)
            : base(pipeline, tenantId, clientId, cacheOptions)
        {
            _includeX5CClaimHeader = includeX5CClaimHeader;
            _certificateProvider = certificateProvider;
        }

        protected override async ValueTask<IConfidentialClientApplication> CreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            ConfidentialClientApplicationBuilder confClientBuilder = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithAuthority(Pipeline.AuthorityHost.AbsoluteUri, TenantId)
                .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline));

            if (_clientSecret != null)
            {
                confClientBuilder.WithClientSecret(_clientSecret);
            }

            if (_certificateProvider != null)
            {
                X509Certificate2 clientCertificate = await _certificateProvider.GetCertificateAsync(async, cancellationToken).ConfigureAwait(false);
                confClientBuilder.WithCertificate(clientCertificate);
            }

            return confClientBuilder.Build();
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            IConfidentialClientApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            return await client.AcquireTokenForClient(scopes).WithSendX5C(_includeX5CClaimHeader).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
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
    }
}
