// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Identity
{
    public class EnvironmentCredentialProvider : TokenCredentialProvider
    {
        private static readonly string s_AzureClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");

        private static readonly string s_AzureTenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

        private static readonly string s_AzureClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

        private ValueTask<TokenCredential> _credential = default;

        public EnvironmentCredentialProvider()
        {
            if (s_AzureClientId != null && s_AzureTenantId != null && s_AzureClientSecret != null)
            {
                _credential = new ValueTask<TokenCredential>(new ClientSecretCredential());
            }
        }

        protected override ValueTask<TokenCredential> GetCredentialAsync(IEnumerable<string> scopes, CancellationToken cancellationToken)
        {
            return _credential;
        }
    }
}
