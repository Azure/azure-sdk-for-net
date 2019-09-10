// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a default <see cref="ChainedTokenCredential"/> configuration for applications that will be deployed to Azure.  The following credential
    /// types will be tried, in order:
    /// - <see cref="EnvironmentCredential"/>
    /// - <see cref="ManagedIdentityCredential"/>
    /// - <see cref="SharedTokenCacheCredential"/>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    public class DefaultAzureCredential : ChainedTokenCredential
    {
        // TODO: Currently this is piggybacking off the Azure CLI client ID, but needs to be switched once the Developer Sign On application is available
        private const string DeveloperSignOnClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private static readonly string AzureUsername = Environment.GetEnvironmentVariable("AZURE_USERNAME");
        private static TokenCredential[] s_defaultCredentialChain = GetDefaultAzureCredentialChain();

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        public DefaultAzureCredential()
            : base(s_defaultCredentialChain)
        {

        }

        private static TokenCredential[] GetDefaultAzureCredentialChain()
        {
            if (!string.IsNullOrEmpty(AzureUsername))
            {
                return new TokenCredential[] {
                    new EnvironmentCredential(),
                    new ManagedIdentityCredential(),
                    new SharedTokenCacheCredential(DeveloperSignOnClientId, AzureUsername),
                    new CredentialNotFoundGuard()
                };
            }
            else
            {
                return new TokenCredential[] {
                    new EnvironmentCredential(),
                    new ManagedIdentityCredential(),
                    new CredentialNotFoundGuard()
                };
            }
        }

        private class CredentialNotFoundGuard : TokenCredential
        {
            private const string CredentialNotFoundMessage = @"Failed to find a credential to use for authentication.  If running in an environment where a managed identity is not available ensure the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are set.";

            public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken)
            {
                throw new AuthenticationFailedException(CredentialNotFoundMessage);
            }

            public override Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
            {
                throw new AuthenticationFailedException(CredentialNotFoundMessage);
            }
        }
    }
}
