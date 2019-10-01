// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   Performs the actions needed to generate <see cref="CbsToken" /> instances for
    ///   authorization within an AMQP scope.
    /// </summary>
    ///
    /// <seealso cref="Microsoft.Azure.Amqp.ICbsTokenProvider" />
    ///
    internal sealed class CbsTokenProvider : ICbsTokenProvider
    {
        /// <summary>The type to consider a token if it is based on an Event Hubs shared access signature.</summary>
        private const string SharedAccessSignatureTokenType = "servicebus.windows.net:sastoken";

        /// <summary>The type to consider a token if not based on a shared access signature.</summary>
        private const string JsonWebTokenType = "jwt";

        /// <summary>The type to consider a token generated from the associated <see cref="_credential" />.</summary>
        private readonly string _tokenType;

        /// <summary>The credential used to generate access tokens.</summary>
        private readonly EventHubTokenCredential _credential;

        /// <summary>The cancellation token to consider when making requests.</summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        ///   Initializes a new instance of the <see cref="CbsTokenProvider"/> class.
        /// </summary>
        ///
        /// <param name="credential">The credential to use for access token generation.</param>
        /// <param name="cancellationToken">The cancellation token to consider when making requests.</param>
        ///
        public CbsTokenProvider(EventHubTokenCredential credential,
                                CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            _credential = credential;
            _cancellationToken = cancellationToken;

            _tokenType = (credential.IsSharedAccessSignatureCredential)
                ? SharedAccessSignatureTokenType
                : JsonWebTokenType;
        }

        /// <summary>
        ///   Asynchronously requests a CBS token to be used for authorization within an AMQP
        ///   scope.
        /// </summary>
        ///
        /// <param name="namespaceAddress">The address of the namespace to be authorized.</param>
        /// <param name="appliesTo">The resource to which the token should apply.</param>
        /// <param name="requiredClaims">The set of claims that are required for authorization.</param>
        /// <returns>The token to use for authorization.</returns>
        ///
        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
        {
            AccessToken token = await _credential.GetTokenAsync(new TokenRequest(requiredClaims), _cancellationToken);
            return new CbsToken(token.Token, _tokenType, token.ExpiresOn.UtcDateTime);
        }
    }
}
