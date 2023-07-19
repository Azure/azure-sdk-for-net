// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class TokenExchangeManagedIdentitySource : ManagedIdentitySource
    {
        private TokenFileCache _tokenFileCache;
        private ClientAssertionCredential _clientAssertionCredential;

        private TokenExchangeManagedIdentitySource(CredentialPipeline pipeline, string tenantId, string clientId, string tokenFilePath)
            : base(pipeline)
        {
            _tokenFileCache = new TokenFileCache(tokenFilePath);
            _clientAssertionCredential = new ClientAssertionCredential(tenantId, clientId, _tokenFileCache.GetTokenFileContents, new ClientAssertionCredentialOptions { Pipeline = pipeline });
        }

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            string tokenFilePath = EnvironmentVariables.AzureFederatedTokenFile;
            string tenantId = EnvironmentVariables.TenantId;
            string clientId = options.ClientId ?? EnvironmentVariables.ClientId;

            if (options.ExcludeTokenExchangeManagedIdentitySource || string.IsNullOrEmpty(tokenFilePath) || string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId))
            {
                return default;
            }

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

        // Ideally this class should handle I/O asynchronously, and have a design similar to AccessTokenCache in BearerTokenAuthenticationPolicy.
        // However, MSAL currently only accepts sync callbacks for client assertions so this has been radically simplified in light of this. If MSAL
        // were to add support for an async callback we should update this accordingly.
        // See, https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/issues/2863
        private class TokenFileCache
        {
            private readonly object _lock = new object();
            private readonly string _tokenFilePath;
            private string _tokenFileContents;
            private DateTimeOffset _refreshOn = DateTimeOffset.MinValue;

            public TokenFileCache(string tokenFilePath)
            {
                _tokenFilePath = tokenFilePath;
            }

            public string GetTokenFileContents()
            {
                if (_refreshOn <= DateTimeOffset.UtcNow)
                {
                    lock (_lock)
                    {
                        if (_refreshOn <= DateTimeOffset.UtcNow)
                        {
                            _tokenFileContents = File.ReadAllText(_tokenFilePath);

                            _refreshOn = DateTimeOffset.UtcNow.AddMinutes(5);
                        }
                    }
                }

                return _tokenFileContents;
            }
        }
    }
}
