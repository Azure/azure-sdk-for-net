// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Start Hold Music Request.
    /// </summary>
    public class StartHoldMusicOptions
    {
        /// <summary>
        /// Creates a new StartHoldMusicOptions object.
        /// </summary>
        public StartHoldMusicOptions(CommunicationIdentifier targetParticipant, PlaySource playSourceInfo)
        {
            TargetParticipant = targetParticipant;
            PlaySourceInfo = playSourceInfo;
            Loop = true;
        }

        /// <summary>
        /// The participant that is going to be put on hold.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// Prompt to play while on hold.
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
