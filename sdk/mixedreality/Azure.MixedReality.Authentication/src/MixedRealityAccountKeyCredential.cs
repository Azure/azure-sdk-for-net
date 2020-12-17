// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents an object used for Mixed Reality account key authentication.
    /// </summary>
    /// <seealso cref="TokenCredential" />
    internal class MixedRealityAccountKeyCredential : TokenCredential
    {
        private readonly string _accountId;

        private readonly AzureKeyCredential _accountKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityAccountKeyCredential" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountKey">The Mixed Reality service account primary or secondary key.</param>
        public MixedRealityAccountKeyCredential(string accountId, string accountKey)
            : this(accountId, new AzureKeyCredential(accountKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityAccountKeyCredential" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        public MixedRealityAccountKeyCredential(string accountId, AzureKeyCredential keyCredential)
        {
            Argument.AssertNotNullOrWhiteSpace(accountId, nameof(accountId));
            Argument.AssertNotNull(keyCredential, nameof(keyCredential));

            _accountId = accountId;
            _accountKey = keyCredential;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new AccessToken($"{_accountId}:{_accountKey.Key}", DateTimeOffset.MaxValue);

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
    }
}
