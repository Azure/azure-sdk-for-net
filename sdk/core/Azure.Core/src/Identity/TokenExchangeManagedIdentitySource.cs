// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    [UnsupportedOSPlatform("browser")]
    internal class TokenExchangeManagedIdentitySource : ManagedIdentitySource
    {
        private FileContentsCache _tokenFileCache;
        private ClientAssertionCredential _clientAssertionCredential;

        private TokenExchangeManagedIdentitySource(CredentialPipeline pipeline, string tenantId, string clientId, string tokenFilePath)
            : base(pipeline)
        {
            _tokenFileCache = new FileContentsCache(tokenFilePath);
            _clientAssertionCredential = new ClientAssertionCredential(tenantId, clientId, _tokenFileCache.GetTokenFileContentsAsync, new ClientAssertionCredentialOptions { Pipeline = pipeline });
        }

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            string tokenFilePath = EnvironmentVariables.AzureFederatedTokenFile;
            string tenantId = EnvironmentVariables.TenantId;
            string clientId = options.ManagedIdentityId?._userAssignedId ?? EnvironmentVariables.ClientId;

            if (options.ExcludeTokenExchangeManagedIdentitySource || string.IsNullOrEmpty(tokenFilePath) || string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId))
            {
                AzureIdentityEventSource.Singleton.ManagedIdentitySourceAttempted("TokenExchangeManagedIdentitySource", false);
                return default;
            }

            AzureIdentityEventSource.Singleton.ManagedIdentitySourceAttempted("TokenExchangeManagedIdentitySource", true);
            return new TokenExchangeManagedIdentitySource(options.Pipeline, tenantId, clientId, tokenFilePath);
        }

        public async override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            return async ? await _clientAssertionCredential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false) : _clientAssertionCredential.GetToken(context, cancellationToken);
        }

        protected override Request CreateRequest(string[] scopes)
        {
            throw new NotImplementedException();
        }
    }
}
