// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Start Media Streaming Request.
    /// </summary>
    public class StartMediaStreamingOptions
    {
        /// <summary>
        /// Creates a new StartMediaStreamingOptions object.
        /// </summary>
        public StartMediaStreamingOptions()
        {
        }

        /// <summary>
        /// Creates a new StartMediaStreamingOptions object.
        /// </summary>
        /// <param name="operationCallbackUri"> </param>
        /// <param name="operationContext"> The value to identify context of the operation. </param>
        public StartMediaStreamingOptions(string operationCallbackUri, string operationContext)
        {
            OperationCallbackUri = operationCallbackUri;
            OperationContext = operationContext;
        }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public string OperationCallbackUri { get; set; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
