// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The identity of participants to be unmuted from the call.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }
    }
}
