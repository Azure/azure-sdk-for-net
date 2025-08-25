// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The SentimentAnalysisResult. </summary>
    [CodeGenModel("SentimentAnalysisResult", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SentimentAnalysisResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentAnalysisResult"/> class.
        /// This constructor is needed for the CodeGenModel attribute to work correctly.
        /// </summary>
        public SentimentAnalysisResult()
        {
        }
    }
}
