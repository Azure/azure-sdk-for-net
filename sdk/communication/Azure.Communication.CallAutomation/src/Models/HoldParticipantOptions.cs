// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Unmute Participant Request.
    /// </summary>
    public class HoldParticipantOptions
    {
        /// <summary>
        /// Creates a new UnmuteParticipantOptions object.
        /// </summary>
        public HoldParticipantOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// The identity of participants to be held from the call.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// Prompt to play while in hold.
        /// </summary>
        public PlaySource PlaySourceInfo { get; set; }

        /// <summary>
        /// If the prompt will be looped or not.
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        /// The operation context to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
