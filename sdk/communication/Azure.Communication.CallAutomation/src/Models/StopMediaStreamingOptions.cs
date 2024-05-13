// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Stop Media Streaming Request.
    /// </summary>
    public class StopMediaStreamingOptions
    {
        /// <summary>
        /// Set a callback URL that overrides the default callback URL set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public string OperationCallbackUrl { get; set; }
    }
}
