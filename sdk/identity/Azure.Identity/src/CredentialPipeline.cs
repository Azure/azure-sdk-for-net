// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
   internal class CredentialPipeline
    {
        private static readonly Lazy<CredentialPipeline> s_Singleton = new Lazy<CredentialPipeline>(() => new CredentialPipeline(new TokenCredentialOptions()));

        private CredentialPipeline(TokenCredentialOptions options)
        {
            AuthorityHost = options.AuthorityHost;

            HttpPipeline = HttpPipelineBuilder.Build(options);

            Diagnostics = new ClientDiagnostics(options);
        }

        private CredentialPipeline(Uri authorityHost, HttpPipeline httpPipeline, ClientDiagnostics diagnostics)
        {
            AuthorityHost = authorityHost ?? throw new ArgumentNullException(nameof(authorityHost));
            HttpPipeline = httpPipeline ?? throw new ArgumentNullException(nameof(httpPipeline));
            Diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }

        public static CredentialPipeline GetInstance(TokenCredentialOptions options)
        {
            return (options is null) ? s_Singleton.Value : new CredentialPipeline(options);
        }

        public Uri AuthorityHost { get; }

        public HttpPipeline HttpPipeline { get; }

        public ClientDiagnostics Diagnostics { get; }

        public IConfidentialClientApplication CreateMsalConfidentialClient(string tenantId, string clientId, string clientSecret)
        {
            return ConfidentialClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(HttpPipeline)).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();
        }

        public MsalPublicClient CreateMsalPublicClient(string clientId, string tenantId = default, string redirectUrl = default, bool attachSharedCache = false)
        {
            return new MsalPublicClient(HttpPipeline, clientId, tenantId, redirectUrl, attachSharedCache);
        }

        public CredentialDiagnosticScope StartGetTokenScope(string fullyQualifiedMethod, TokenRequestContext context)
        {
            AzureIdentityEventSource.Singleton.GetToken(fullyQualifiedMethod, context);

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(fullyQualifiedMethod, Diagnostics.CreateScope(fullyQualifiedMethod), context);

            scope.Start();

            return scope;
        }

        /// <summary>
        /// Creates a new CredentialPipeline from an existing pipeline while replacing the AuthorityHost with a new value.
        /// </summary>
        /// <returns></returns>
        public CredentialPipeline WithAuthorityHost(Uri authorityHost)
        {
            return new CredentialPipeline(authorityHost, HttpPipeline, Diagnostics);
        }
    }
}
