// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Hold Request.
    /// </summary>
    public class HoldOptions
    {
        /// <summary>
        /// Creates a new HoldOptions object.
        /// </summary>
        public HoldOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// The participant that is going to be put on hold.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// Prompt to play while on hold.
        /// </summary>
        public PlaySource PlaySource { get; set; }

        /// <summary>
        /// The operation context to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
