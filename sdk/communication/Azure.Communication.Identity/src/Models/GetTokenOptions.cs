// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// Options used to get a token for a <see cref="CommunicationUserIdentifier"/>.
    /// </summary>
    public class GetTokenOptions
    {
        /// <summary>
        /// The <see cref="CommunicationUserIdentifier"/> for whom to get a token.
        /// </summary>
        public CommunicationUserIdentifier CommunicationUser { get; }

        /// <summary>
        /// The scopes that the token should have.
        /// </summary>
        public IEnumerable<CommunicationTokenScope> Scopes { get; }

        /// <summary>
        /// Optional custom validity period of the token within [60,1440] minutes range. If not provided, the default value of 1440 minutes (24 hours) will be used.
        /// </summary>
        public TimeSpan? ExpiresInMinutes { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="GetTokenOptions"/>.
        /// </summary>
        /// <param name="communicationUserIdentifier">The <see cref="CommunicationUserIdentifier"/> for whom to get a token.</param>
        /// <param name="scopes">The scopes that the token should have.</param>
        public GetTokenOptions(
            CommunicationUserIdentifier communicationUserIdentifier,
            IEnumerable<CommunicationTokenScope> scopes
            )
        {
            CommunicationUser = communicationUserIdentifier;
            Scopes = scopes;
        }
    }
}
