// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class EnvironmentCredentialProvider : TokenCredential
    {
        private static readonly string s_AzureClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");

        private static readonly string s_AzureTenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

        private static readonly string s_AzureClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

        private TokenCredential _credential = null;


        public EnvironmentCredentialProvider()
        {
            if (s_AzureClientId != null && s_AzureTenantId != null && s_AzureClientSecret != null)
            {
                _credential = new ClientSecretCredential(s_AzureTenantId, s_AzureClientId, s_AzureClientSecret);
            }
        }

        public override string GetToken(string[] scopes, CancellationToken cancellationToken)
        {
            return (_credential != null) ? _credential.GetToken(scopes, cancellationToken) : null;
        }

        public async override ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
        {
            return (_credential != null) ? await _credential.GetTokenAsync(scopes, cancellationToken) : null;
        }

    }
}
