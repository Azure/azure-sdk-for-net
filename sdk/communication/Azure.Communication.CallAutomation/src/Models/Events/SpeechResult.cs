// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("SpeechResult", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SpeechResult : RecognizeResult
    {
        /// <summary>
        /// The RecognizeResultType of this RecognizeResult.
        /// </summary>
        public override RecognizeResultType ResultType => RecognizeResultType.SpeechResult;
    }
}
