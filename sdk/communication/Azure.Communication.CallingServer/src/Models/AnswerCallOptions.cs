// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The answer call operation options.
    /// </summary>
    public class AnswerCallOptions
    {
        /// <summary>
        /// Creates a new AnswerCallOptions object.
        /// </summary>
        /// <param name="incomingCallContext"></param>
        /// <param name="callbackUri"></param>
        public AnswerCallOptions(string incomingCallContext, Uri callbackUri)
        {
            IncomingCallContext = incomingCallContext;
            CallbackUri = callbackUri;
        }

        /// <summary>
        /// The context associated with the call.
        /// </summary>
        public string IncomingCallContext { get; }

        /// <summary>
        /// The callback uri.
        /// </summary>
        public Uri CallbackUri { get; }

        /// <summary>
        /// Media Streaming Configuration.
        /// </summary>
        public MediaStreamingOptions MediaStreamingOptions { get; set; }
    }
}
