// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// TeamsPhoneCallDetails.
    /// </summary>
    public class TeamsPhoneCallDetails
    {
        /// <summary> Initializes a new instance of <see cref="TeamsPhoneCallDetailsInternal"/>. </summary>
        public TeamsPhoneCallDetails()
        {
        }

        /// <summary> Container for details relating to the original caller of the call. </summary>
        public TeamsPhoneCallerDetails TeamsPhoneCallerDetails { get; set; }
        /// <summary> Container for details relating to the entity responsible for the creation of these call details. </summary>
        public TeamsPhoneSourceDetails TeamsPhoneSourceDetails { get; set; }
        /// <summary> Id to exclusively identify this call session. IVR will use this for their telemetry/reporting. </summary>
        public string SessionId { get; set; }
        /// <summary> The intent of the call. </summary>
        public string Intent { get; set; }
        /// <summary> A very short description (max 48 chars) of the reason for the call. To be displayed in Teams CallNotification. </summary>
        public string CallTopic { get; set; }
        /// <summary> A summary of the call thus far. It will be displayed on a side panel in the Teams UI. </summary>
        public string CallContext { get; set; }
        /// <summary> Url for fetching the transcript of the call. </summary>
        public string TranscriptUrl { get; set; }
        /// <summary> Sentiment of the call thus far. </summary>
        public string CallSentiment { get; set; }
        /// <summary> Recommendations for resolving the issue based on the customer’s intent and interaction history. </summary>
        public string SuggestedActions { get; set; }
    }
}
