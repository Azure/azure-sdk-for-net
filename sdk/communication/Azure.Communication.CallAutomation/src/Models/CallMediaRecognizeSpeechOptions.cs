// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for IVR Continuouse Speech Recognition.
    /// </summary>
    public class CallMediaRecognizeSpeechOptions : CallMediaRecognizeOptions
    {
        /// <summary> Initializes a new instance of CallMediaRecognizeSpeechOptions. </summary>
        public CallMediaRecognizeSpeechOptions(RecognizeInputType recognizeInputType, CommunicationIdentifier targetParticipant, long endSilenceTimeoutInMs = default) : base(recognizeInputType, targetParticipant)
        {
            EndSilenceTimeoutInMs = endSilenceTimeoutInMs;
        }

        /// <summary> The length of end silence when user stops speaking and cogservice send response. </summary>
        public long? EndSilenceTimeoutInMs { get; set; }
    }
}