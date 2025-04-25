// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Stop Media Streaming Request.
    /// </summary>
    public class StopMediaStreamingOptions
    {
        /// <summary>
        /// Set a callback Uri that overrides the default callback Uri set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
    }
}
