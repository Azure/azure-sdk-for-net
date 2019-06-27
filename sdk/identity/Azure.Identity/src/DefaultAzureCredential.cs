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
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    public class DefaultAzureCredential : ChainedTokenCredential
    {
        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        public DefaultAzureCredential()
            :this(null)
        {

        }

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        public DefaultAzureCredential(IdentityClientOptions options)
            : base(new EnvironmentCredential(options), new ManagedIdentityCredential(options: options), new CredentialNotFoundGuard())
        {

        }

        private class CredentialNotFoundGuard : TokenCredential
        {
            private const string CredentialNotFoundMessage = @"Failed to find a credential to use for authentication.  If running in an environment where a managed identity is not available ensure AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are set.";

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
