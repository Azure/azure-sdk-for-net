// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents a Mixed Reality credential.
    /// </summary>
    public class MixedRealityCredential
    {
        private readonly MixedRealityTokenCredential _tokenCredential;

        /// <summary>
        /// Gets the Mixed Reality service account domain.
        /// </summary>
        public string AccountDomain { get; }

        /// <summary>
        /// Gets the Mixed Reality service account identifier.
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="accountKey">The Mixed Reality service account primary or secondary key.</param>
        public MixedRealityCredential(string accountId, string accountDomain, string accountKey)
            : this(accountId, accountDomain, accountKey, MixedRealityStsClient.ConstructStsEndpointUrl(accountDomain))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="accountKey">The Mixed Reality service account primary or secondary key.</param>
        /// <param name="authenticationEndpoint">The Mixed Reality service authentication endpoint.</param>
        public MixedRealityCredential(string accountId, string accountDomain, string accountKey, Uri authenticationEndpoint)
            : this(accountId, accountDomain, new AzureKeyCredential(accountKey), authenticationEndpoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        public MixedRealityCredential(string accountId, string accountDomain, AzureKeyCredential keyCredential)
            : this(accountId, accountDomain, new MixedRealityTokenProvider(
                accountId, MixedRealityStsClient.ConstructStsEndpointUrl(accountDomain), keyCredential, new MixedRealityStsClientOptions()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        /// <param name="authenticationEndpoint">The Mixed Reality service authentication endpoint.</param>
        public MixedRealityCredential(string accountId, string accountDomain, AzureKeyCredential keyCredential, Uri authenticationEndpoint)
            : this(accountId, accountDomain, new MixedRealityTokenProvider(accountId, authenticationEndpoint, keyCredential, new MixedRealityStsClientOptions()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="accessToken">The Mixed Reality service access token.</param>
        public MixedRealityCredential(string accountId, string accountDomain, AccessToken accessToken)
            : this(accountId, accountDomain, new StaticAccessTokenCredential(accessToken))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="tokenCredential">The token credential used to access the Mixed Reality service.</param>
        public MixedRealityCredential(string accountId, string accountDomain, TokenCredential tokenCredential)
            : this(accountId, accountDomain, tokenCredential, MixedRealityStsClient.ConstructStsEndpointUrl(accountDomain))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="tokenCredential">The token credential used to access the Mixed Reality service.</param>
        /// <param name="authenticationEndpoint">The Mixed Reality service authentication endpoint.</param>
        public MixedRealityCredential(string accountId, string accountDomain, TokenCredential tokenCredential, Uri authenticationEndpoint)
            : this(accountId, accountDomain, new MixedRealityTokenProvider(accountId, authenticationEndpoint, tokenCredential, new MixedRealityStsClientOptions()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityCredential"/> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="tokenCredential">The Mixed Reality token credential.</param>
        private MixedRealityCredential(string accountId, string accountDomain, MixedRealityTokenCredential tokenCredential)
        {
            Argument.AssertNotNullOrWhiteSpace(accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            AccountId = accountId;
            AccountDomain = accountDomain;
            _tokenCredential = tokenCredential;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        public AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _tokenCredential.GetToken(requestContext, cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A <see cref="ValueTask{AccessToken}"/> containing a valid <see cref="AccessToken"/>.</returns>
        public ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _tokenCredential.GetTokenAsync(requestContext, cancellationToken);
    }
}
