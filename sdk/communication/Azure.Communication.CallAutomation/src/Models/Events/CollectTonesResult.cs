// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Communication.CallAutomation.Models;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("CollectTonesResult", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CollectTonesResult : RecognizeResult
    {
        /// <summary>
        /// The Tones colelcted.
        /// </summary>
        [CodeGenMember("Tones")]
        public IReadOnlyList<DtmfTone> Tones { get; }

        /// <summary>
        /// The RecognizeResultType of this RecognizeResult.
        /// </summary>
        public override RecognizeResultType ResultType => RecognizeResultType.CollectTonesResult;
    }
}
