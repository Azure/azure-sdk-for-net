// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class EnvironmentCredentialProvider : TokenCredential
    {
        private TokenCredential _credential = null;

        public EnvironmentCredentialProvider()
            : this(null)
        {
        }

        public EnvironmentCredentialProvider(IdentityClientOptions options)
        {
            string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

            if (tenantId != null && clientId != null && clientSecret != null)
            {
                _credential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            }
        }

        public override string GetToken(string[] scopes, CancellationToken cancellationToken)
        {
            return _credential?.GetToken(scopes, cancellationToken);
        }

        public async override ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
        {
            return (_credential != null) ? await _credential.GetTokenAsync(scopes, cancellationToken) : null;
        }
    }
}
