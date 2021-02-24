// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable enable

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents a token credential that can be used to access a Mixed Reality service.
    /// Implements <see cref="TokenCredential" />.
    /// </summary>
    /// <seealso cref="TokenCredential" />
    internal class MixedRealityTokenCredential : TokenCredential
    {
        private readonly MixedRealityStsClient _stsClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityTokenCredential" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        private MixedRealityTokenCredential(Guid accountId, Uri endpoint, TokenCredential credential, MixedRealityStsClientOptions? options = null)
        {
            _stsClient = new MixedRealityStsClient(accountId, endpoint, credential, options);
        }

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _stsClient.GetToken(cancellationToken);

        /// <summary>
        /// get token as an asynchronous operation.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await _stsClient.GetTokenAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a Mixed Reality credential using the specified <paramref name="credential"/>.
        /// Azure credentials are exchanged with the Mixed Reality STS service for Mixed Reality access tokens.
        /// In the case of a <see cref="StaticAccessTokenCredential"/>, the credential is assumed to be a Mixed Reality
        /// access token previously retrieved from the Mixed Reality STS service, so it is simply returned.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        /// <returns><see cref="TokenCredential"/>.</returns>
        public static TokenCredential GetMixedRealityCredential(Guid accountId, Uri endpoint, TokenCredential credential, MixedRealityStsClientOptions? options = null)
        {
            if (credential is StaticAccessTokenCredential)
            {
                // Static access tokens are assumed to be Mixed Reality access tokens already, so we don't need to exchange
                // them using the MixedRealityTokenCredential.
                return credential;
            }

            return new MixedRealityTokenCredential(accountId, endpoint, credential, options);
        }
    }
}
