// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a <see cref="TokenCredential"/> implementation which chains the <see cref="EnvironmentCredential"/> and <see cref="ManagedIdentityCredential"/> implementations to be tried in order
    /// until one of the getToken methods returns a non-default <see cref="AccessToken"/>.
    /// </summary>
    /// <remarks>
    /// This credential is designed for applications deployed to Azure <see cref="DefaultAzureCredential"/> is
    /// better suited to local development). It authenticates service principals and managed identities..
    /// </remarks>
    internal class AzureApplicationCredential : TokenCredential
    {
        private readonly ChainedTokenCredential _credential;

        /// <summary>
        /// Initializes an instance of the <see cref="AzureApplicationCredential"/>.
        /// </summary>
        public AzureApplicationCredential() : this(new AzureApplicationCredentialOptions(), null, null)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="AzureApplicationCredential"/>.
        /// </summary>
        /// <param name="options">The <see cref="TokenCredentialOptions"/> to configure this credential.</param>
        public AzureApplicationCredential(AzureApplicationCredentialOptions options) : this(options ?? new AzureApplicationCredentialOptions(), null, null)
        { }

        internal AzureApplicationCredential(AzureApplicationCredentialOptions options, EnvironmentCredential environmentCredential = null, ManagedIdentityCredential managedIdentityCredential = null)
        {
            _credential = new ChainedTokenCredential(
                environmentCredential ?? new EnvironmentCredential(options),
                managedIdentityCredential ?? new ManagedIdentityCredential(options.ManagedIdentityClientId)
            );
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully obtained
        /// <see cref="AccessToken"/>. Acquired tokens are cached by the credential instance. Token lifetime and refreshing is handled
        /// automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully obtained
        /// <see cref="AccessToken"/>. Acquired tokens are cached by the credential instance. Token lifetime and refreshing is handled
        /// automatically. Where possible,reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        => async ?
            await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
            : _credential.GetToken(requestContext, cancellationToken);
    }
}
