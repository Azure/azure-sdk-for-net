// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Stop Media Streaming Request.
    /// </summary>
    public class StopMediaStreamingOptions
    {
        /// <summary>
        /// Creates a new StopMediaStreamingOptions object.
        /// </summary>
        public StopMediaStreamingOptions()
        {
        }

        /// <summary>
        /// Creates a new StopMediaStreamingOptions object.
        /// </summary>
        /// <param name="operationCallbackUri"> </param>
        public StopMediaStreamingOptions(string operationCallbackUri)
        {
            OperationCallbackUri = operationCallbackUri;
        }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public string OperationCallbackUri { get; set; }
    }
}
