// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for creating a call.
    /// </summary>
    public class ConnectCallOptions
    {
        /// <summary>
        /// Creates a new instance of ConnectOptions.
        /// </summary>
        /// <param name="callLocator"></param>
        /// <param name="callbackUri"></param>
        public ConnectCallOptions(CallLocator callLocator, Uri callbackUri)
        {
            CallLocator = callLocator;
            CallbackUri = callbackUri;
        }

        /// <summary>
        /// Either a GroupCallLocator or ServerCallLocator or RoomCallLocator for locating the call.
        /// </summary>
        public CallLocator CallLocator { get; }

        /// <summary>
        /// The callback URL.
        /// </summary>
        public Uri CallbackUri { get; }

        /// <summary>
        /// Used by customers to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Media Streaming Configuration.
        /// </summary>
        public MediaStreamingOptions MediaStreamingOptions { get; set; }

        /// <summary>
        /// Live Transcription Configuration.
        /// </summary>
        public TranscriptionOptions TranscriptionOptions { get; set; }

        /// <summary>
        /// AI options for the call.
        /// </summary>
        public CallIntelligenceOptions CallIntelligenceOptions { get; set; }
    }
}
