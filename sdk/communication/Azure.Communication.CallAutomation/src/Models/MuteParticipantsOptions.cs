// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Mute Participant Request.
    /// </summary>
    public class MuteParticipantsOptions
    {
        /// <summary>
        /// Creates a new MuteParticipantOptions object.
        /// </summary>
        public MuteParticipantsOptions(IEnumerable<CommunicationIdentifier> targetParticipants)
        {
            TargetParticipants = targetParticipants.ToList<CommunicationIdentifier>();
        }

        /// <summary>
        /// The identity of participants to be muted from the call.
        /// Only one participant is currently supported.
        /// Only ACS Users are currently supported.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> TargetParticipants { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
