// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for IVR Choices.
    /// </summary>
    public class CallMediaRecognizeChoiceOptions : CallMediaRecognizeOptions
    {
        /// <summary> Initializes a new instance of CallMediaRecognizeChoiceOptions. </summary>
        public CallMediaRecognizeChoiceOptions(CommunicationIdentifier targetParticipant, List<RecognizeChoice> recognizeChoices) : base(RecognizeInputType.Choices, targetParticipant)
        {
            RecognizeChoices = recognizeChoices;
        }

        /// <summary>
        /// The IvR choices for recognize
        /// </summary>
        public IList<RecognizeChoice> RecognizeChoices { get; }

        /// <summary> Speech language to be recognized, If not set default is en-US. </summary>
        public string SpeechLanguage { get; set; }
    }
}
