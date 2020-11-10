// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    internal class MixedRealityTokenProvider : MixedRealityTokenCredential
    {
        private readonly MixedRealityStsClient _stsClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityTokenProvider" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public MixedRealityTokenProvider(string accountId, Uri endpoint, AzureKeyCredential keyCredential, MixedRealityStsClientOptions options)
            : this(accountId, endpoint, new MixedRealityAccountKeyCredential(accountId, keyCredential), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityTokenProvider" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public MixedRealityTokenProvider(string accountId, Uri endpoint, TokenCredential credential, MixedRealityStsClientOptions options)
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
    }
}
