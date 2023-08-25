// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Unmute Participant Request.
    /// </summary>
    public class UnmuteParticipantsOptions
    {
        /// <summary>
        /// Creates a new UnmuteParticipantOptions object.
        /// </summary>
        public UnmuteParticipantsOptions(IEnumerable<CommunicationIdentifier> targetParticipant)
        {
            TargetParticipants = targetParticipant.ToList<CommunicationIdentifier>();
        }

        /// <summary>
        /// The identity of participants to be unmuted from the call.
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
