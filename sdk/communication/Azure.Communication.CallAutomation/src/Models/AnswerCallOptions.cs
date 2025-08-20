// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
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
            CustomCallingContext = new CustomCallingContext(sipHeaders: new Dictionary<string, string>(), voipHeaders: new Dictionary<string, string>(), teamsPhoneCallDetails: null);
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

        /// <summary>
        /// Live Transcription Configuration.
        /// </summary>
        public TranscriptionOptions TranscriptionOptions { get; set; }

        /// <summary>
        /// AI options for the call such as endpoint URI of the Azure Cognitive Services resource
        /// </summary>
        public CallIntelligenceOptions CallIntelligenceOptions { get; set; }

        /// <summary>
        /// The identifier of the call automation entity which answers the call.
        /// </summary>
        public CommunicationUserIdentifier AnsweredBy { get; set; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The Custom Context which contains SIP and voip headers.
        /// </summary>
        public CustomCallingContext CustomCallingContext { get; }
    }
}
