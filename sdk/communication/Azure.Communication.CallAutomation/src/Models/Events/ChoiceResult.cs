// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("ChoiceResult", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ChoiceResult : RecognizeResult
    {
        /// <summary>
        /// The RecognizeResultType of this RecognizeResult.
        /// </summary>
        public override RecognizeResultType ResultType => RecognizeResultType.ChoiceResult;
    }
}
