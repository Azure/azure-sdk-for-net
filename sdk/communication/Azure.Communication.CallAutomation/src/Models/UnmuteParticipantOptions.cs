// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Unmute Participant Request.
    /// </summary>
    public class UnmuteParticipantOptions
    {
        /// <summary>
        /// Creates a new UnmuteParticipantOptions object.
        /// </summary>
        public UnmuteParticipantOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// The identity of participants to be unmuted from the call.
        /// Only ACS Users are currently supported.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
