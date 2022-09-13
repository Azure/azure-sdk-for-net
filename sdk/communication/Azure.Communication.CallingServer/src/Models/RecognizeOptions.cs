// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Recognize Options
    /// </summary>
    public class RecognizeOptions
    {
        /// <summary>
        /// Initializes Recognize Options.
        /// </summary>
        /// <param name="targetParticipant"></param>
        public RecognizeOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }
        /// <summary> Determines if we interrupt the prompt and start recognizing. </summary>
        public bool? InterruptPrompt { get; set; }
        /// <summary> Time to wait for first input after prompt (if any). </summary>
        public TimeSpan? InitialSilenceTimeoutInSeconds { get; set; }
        /// <summary> Target participant of DTFM tone recognition. </summary>
        public CommunicationIdentifier TargetParticipant { get; }
        /// <summary> Defines configurations for DTMF. </summary>
        public DtmfOptions DtmfOptions { get; set; }
    }
}
