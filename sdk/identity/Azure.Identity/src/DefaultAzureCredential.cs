﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a default <see cref="ChainedTokenCredential"/> configuration for applications that will be deployed to Azure.  The following credential
    /// types if enabled will be tried, in order:
    /// - <see cref="EnvironmentCredential"/>
    /// - <see cref="ManagedIdentityCredential"/>
    /// - <see cref="SharedTokenCacheCredential"/>
    /// - <see cref="InteractiveBrowserCredential"/>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    public class DefaultAzureCredential : ChainedTokenCredential
    {
        private static readonly ReadOnlyMemory<TokenCredential> s_defaultCredentialChain = GetDefaultAzureCredentialChain(new DefaultAzureCredentialOptions());

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="includeInteractiveCredentials">Specifies whether credentials requiring user interaction will be included in the default authentication flow.</param>
        public DefaultAzureCredential(bool includeInteractiveCredentials = false)
            : this(new DefaultAzureCredentialOptions { ExcludeInteractiveBrowserCredential = !includeInteractiveCredentials })
        {

        }

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="options"></param>
        public DefaultAzureCredential(DefaultAzureCredentialOptions options)
            : base(GetDefaultAzureCredentialChain(options))
        {

        }

        private static ReadOnlyMemory<TokenCredential> GetDefaultAzureCredentialChain(DefaultAzureCredentialOptions options)
        {
            if (options is null)
            {
                return s_defaultCredentialChain;
            }

            int i = 0;
            TokenCredential[] chain = new TokenCredential[5];

            if (!options.ExcludeEnvironmentCredential)
            {
                chain[i++] = new EnvironmentCredential(options);
            }

            if (!options.ExcludeManagedIdentityCredential)
            {
                chain[i++] = new ManagedIdentityCredential(options.ManagedIdentityClientId, options);
            }

            if (!options.ExcludeSharedTokenCacheCredential)
            {
                chain[i++] = new SharedTokenCacheCredential(options.SharedTokenCacheUsername);
            }

            if (!options.ExcludeInteractiveBrowserCredential)
            {
                chain[i++] = new InteractiveBrowserCredential(null, Constants.DeveloperSignOnClientId, options);
            }

            chain[i++] = new CredentialNotFoundGuard();

            return new ReadOnlyMemory<TokenCredential>(chain, 0, i);
        }

        private class CredentialNotFoundGuard : TokenCredential
        {
            private const string CredentialNotFoundMessage = @"Failed to find a credential to use for authentication.  If running in an environment where a managed identity is not available ensure the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are set.";

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new AuthenticationFailedException(CredentialNotFoundMessage);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new AuthenticationFailedException(CredentialNotFoundMessage);
            }
        }
    }
}
