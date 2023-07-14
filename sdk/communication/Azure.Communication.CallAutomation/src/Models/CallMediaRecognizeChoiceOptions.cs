// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for IVR Choices.
    /// </summary>
    public class CallMediaRecognizeChoiceOptions : CallMediaRecognizeOptions
    {
        /// <summary> Initializes a new instance of CallMediaRecognizeChoiceOptions. </summary>
        public CallMediaRecognizeChoiceOptions(CommunicationIdentifier targetParticipant, IEnumerable<RecognizeChoice> recognizeChoices) : base(RecognizeInputType.Choices, targetParticipant)
        {
            RecognizeChoices = recognizeChoices.ToList().AsReadOnly();
        }

        /// <summary>
        /// The IvR choices for recognize
        /// </summary>
        public IReadOnlyList<RecognizeChoice> RecognizeChoices { get; }
    }
}
