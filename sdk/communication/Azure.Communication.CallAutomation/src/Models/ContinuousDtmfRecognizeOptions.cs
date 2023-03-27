// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for Continuous Dtmf.
    /// </summary>
    public class ContinuousDtmfRecognizeOptions
    {
        /// <summary> Initializes a new instance of ContinuousDtmfRecognizeOptions. </summary>
        public ContinuousDtmfRecognizeOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// Target participant of Continuous Dtmf recognition.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }
    }
}
