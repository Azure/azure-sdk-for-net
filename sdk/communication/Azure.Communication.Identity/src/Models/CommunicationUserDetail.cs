// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Identity.Models
{
    /// <summary>
    /// Represents the details of a Communication User.
    /// </summary>
    public class CommunicationUserDetail
    {
        /// <summary> Initializes a new instance of <see cref="CommunicationUserDetail"/>. </summary>
        /// <param name="customId"> The custom Id if one has been associated with the identity. </param>
        /// <param name="lastTokenIssuedAt"> Last time a token has been issued for the identity. </param>
        /// <param name="id"> Identifier of the identity. </param>
        internal CommunicationUserDetail(string customId, DateTimeOffset? lastTokenIssuedAt, string id)
        {
            CustomId = customId;
            LastTokenIssuedAt = lastTokenIssuedAt;
            User = new CommunicationUserIdentifier(id);
        }

        /// <summary> The custom Id if one has been associated with the identity. </summary>
        public string CustomId { get; }

        /// <summary> Last time a token has been issued for the identity. </summary>
        public DateTimeOffset? LastTokenIssuedAt { get; }

        /// <summary>
        /// Identifier of the identity.
        /// </summary>
        public CommunicationUserIdentifier User { get; }
    }
}
