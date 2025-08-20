// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Stop Hold Music Request.
    /// </summary>
    public class StopHoldMusicOptions
    {
        /// <summary>
        /// Creates a new StopHoldMusicOptions object.
        /// </summary>
        public StopHoldMusicOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// The participant that is currently on hold.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
