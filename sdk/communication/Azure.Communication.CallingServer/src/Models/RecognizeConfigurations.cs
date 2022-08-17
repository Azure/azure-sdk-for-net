// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The RecognizeConfigurations.
    /// </summary>
    public class RecognizeConfigurations
    {
        /// <summary> Initializes a new instance of RecognizeConfigurationsInternal. </summary>
        public RecognizeConfigurations()
        {
        }

        /// <summary> Determines if we interrupt the prompt and start recognizing. </summary>
        public bool? InterruptPromptAndStartRecognition { get; set; }
        /// <summary> Time to wait for first input after prompt (if any). </summary>
        public TimeSpan InitialSilenceTimeoutInSeconds { get; set; }
        /// <summary> Target participant of DTFM tone recognition. </summary>
        public CommunicationIdentifier TargetParticipant { get; set; }
        /// <summary> Defines configurations for DTMF. </summary>
        public DtmfConfigurations DtmfConfigurations { get; set; }
    }
}
