// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> Configuration options for call summarization. </summary>
    public class SummarizationOptions
    {
        /// <summary> Indicating whether end call summary should be enabled. </summary>
        public bool? EnableEndCallSummary { get; set; }
        /// <summary> Locale for summarization (e.g., en-US). </summary>
        public string Locale { get; set; }
    }
}
