﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Create Call Request.
    /// </summary>
    public class CreateCallOptions
    {
        /// <summary>
        /// Creates a new CreateCallOptions object.
        /// </summary>
        public CreateCallOptions(CallInvite callInvite, Uri callbackUri)
        {
            CallInvite = callInvite;
            CallbackUri = callbackUri;
        }

        /// <summary>
        /// Call invitee information.
        /// </summary>
        /// <value></value>
        public CallInvite CallInvite { get; }

        /// <summary>
        /// The callback Uri.
        /// </summary>
        public Uri CallbackUri { get; }

        /// <summary>
        /// The Operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Live Transcription Configuration.
        /// </summary>
        public TranscriptionOptions TranscriptionOptions { get; set; }

        /// <summary>
        /// AI options for the call such as endpoint URI of the Azure Cognitive Services resource
        /// </summary>
        public CallIntelligenceOptions CallIntelligenceOptions { get; set; }

        /// <summary>
        /// If passed true, the call will start in an escalated state. (i.e. GroupCall).
        /// </summary>
        public bool StartInConferenceMode { get; set; }
    }
}
