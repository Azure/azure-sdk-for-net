// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// Options used to get a Communication Identity access token for a <see cref="CommunicationUserIdentifier"/>.
    /// </summary>
    public class GetTokenOptions
    {
        /// <summary>
        /// The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.
        /// </summary>
        public CommunicationUserIdentifier CommunicationUser { get; }

        /// <summary>
        /// List of <see cref="CommunicationTokenScope"/> scopes for the Communication Identity access token.
        /// </summary>
        public IEnumerable<CommunicationTokenScope> Scopes { get; }

        /// <summary>
        /// Optional custom validity period of the Communiction Identity access token within &lt;60,1440&gt; minutes range. If not provided, the default value of 1440 minutes (24 hours) will be used.
        /// </summary>
        public TimeSpan? ExpiresInMinutes { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="GetTokenOptions"/>.
        /// </summary>
        /// <param name="communicationUserIdentifier">The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the Communication Identity access token.</param>
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
