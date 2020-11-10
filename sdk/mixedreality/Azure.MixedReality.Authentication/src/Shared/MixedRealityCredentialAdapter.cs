// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents an object used to adapt a <see cref="MixedRealityCredential"/> to a <see cref="TokenCredential"/>
    /// that can be used by Mixed Reality client libraries to authenticate requests.
    /// Implements <see cref="TokenCredential" />.
    /// </summary>
    /// <seealso cref="TokenCredential" />
    internal class MixedRealityCredentialAdapter : TokenCredential
    {
        private readonly MixedRealityCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredentialAdapter"/> class.
        /// </summary>
        /// <param name="credential">The credential.</param>
        public MixedRealityCredentialAdapter(MixedRealityCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            _credential = credential;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _credential.GetToken(requestContext, cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _credential.GetTokenAsync(requestContext, cancellationToken);
    }
}
