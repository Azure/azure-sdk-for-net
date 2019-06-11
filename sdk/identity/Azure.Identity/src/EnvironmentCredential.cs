// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class EnvironmentCredential : TokenCredential
    {
        private TokenCredential _credential = null;

        public EnvironmentCredential()
            : this(null)
        {
        }

        public EnvironmentCredential(IdentityClientOptions options)
        {
            string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

            if (tenantId != null && clientId != null && clientSecret != null)
            {
                _credential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            }
        }

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? _credential.GetToken(scopes, cancellationToken) : default;
        }

        public async override Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? await _credential.GetTokenAsync(scopes, cancellationToken) : default;
        }
    }
}
