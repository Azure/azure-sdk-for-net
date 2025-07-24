// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for summarizing a call.
    /// </summary>
    public class SummarizeCallOptions
    {
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
        /// <summary>
        /// Set a callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public string OperationCallbackUri { get; set; }

        /// <summary>
        /// SummarizationOptions contains the configuration options for summarizing a call.
        /// </summary>
        public SummarizationOptions SummarizationOptions { get; set; }
    }
}
