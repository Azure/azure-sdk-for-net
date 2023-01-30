// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Mute Participant Request.
    /// </summary>
    public class MuteParticipantOptions
    {
        /// <summary>
        /// Creates a new MuteParticipantOptions object.
        /// </summary>
        public MuteParticipantOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The identity of participants to be muted from the call.
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
