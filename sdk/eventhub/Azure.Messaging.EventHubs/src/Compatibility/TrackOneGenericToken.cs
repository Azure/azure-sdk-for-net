// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A compatibility shim allowing a token credential to be used as a
    ///   generic JWT security token with the Track One types.
    /// </summary>
    ///
    /// <seealso cref="Azure.Core.TokenCredential"/>
    /// <seealso cref="TrackOne.SecurityToken" />
    ///
    internal class TrackOneGenericToken : SecurityToken
    {
        /// <summary>
        ///   The <see cref="TokenCredential" /> that forms the basis of this security token.
        /// </summary>
        ///
        public TokenCredential Credential { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneGenericToken"/> class.
        /// </summary>
        ///
        /// <param name="tokenCredential">The <see cref="TokenCredential" /> on which to base the token.</param>
        /// <param name="jwtTokenString">The raw JWT token value from the <paramref name="tokenCredential" /></param>
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        /// <param name="tokenExpirationUtc">The date and time that the token expires, in UTC.</param>
        ///
        public TrackOneGenericToken(TokenCredential tokenCredential,
                                    string jwtTokenString,
                                    string eventHubResource,
                                    DateTime tokenExpirationUtc) :
            base(jwtTokenString, tokenExpirationUtc, eventHubResource, ClientConstants.JsonWebTokenType)
        {
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
            Credential = tokenCredential;
        }
    }
}
