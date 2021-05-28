// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Calling.Server
{
    /// <summary> The options for inviting participants. </summary>
    public class InviteParticipantsOptions
    {
        /// <summary> The alternate identity of source participant. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }
        /// <summary> The list of participants to be added to the call. </summary>
        public IList<CommunicationIdentifier> Participants { get; }
        /// <summary> The operation context. </summary>
        public string OperationContext { get; set; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; set; }

        /// <summary> Initializes a new instance of InviteParticipantsOptions. </summary>
        /// <param name="participants"> The list of participants to be added to the call. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="participants"/> is null. </exception>
        public InviteParticipantsOptions(IEnumerable<CommunicationIdentifier> participants)
        {
            if (participants == null)
            {
                throw new ArgumentNullException(nameof(participants));
            }

            Participants = participants.ToList();
        }
    }
}
