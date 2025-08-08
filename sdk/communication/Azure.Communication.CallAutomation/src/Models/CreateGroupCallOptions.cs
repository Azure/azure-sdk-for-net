// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Create Call Request.
    /// </summary>
    public class CreateGroupCallOptions
    {
        /// <summary>
        /// Creates a new CreateCallOptions object.
        /// </summary>
        public CreateGroupCallOptions(IEnumerable<CommunicationIdentifier> targets, Uri callbackUri)
        {
            Targets = targets;
            CallbackUri = callbackUri;
        }

        /// <summary>
        /// Call invitee information.
        /// </summary>
        /// <value></value>
        public IEnumerable<CommunicationIdentifier> Targets { get; }

        /// <summary>
        /// The callback Uri.
        /// </summary>
        public Uri CallbackUri { get; }

        /// <summary>
        /// The display caller ID number to appear for target PSTN callee.
        /// </summary>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; set; }

        /// <summary>
        /// The display name to appear for target callee.
        /// </summary>
        public string SourceDisplayName { get; set; }

        /// <summary>
        /// The Operation context.
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
        /// AI options for the call such as endpoint URI of the Azure Cognitive Services resource
        /// </summary>
        public CallIntelligenceOptions CallIntelligenceOptions { get; set; }

        /// <summary>
        /// Overrides default client source by a MicrosoftTeamsAppIdentifier type source.
        /// Required for creating call with Teams resource account ID.
        /// This is per-operation setting and does not change the client's default source.
        /// </summary>
        public MicrosoftTeamsAppIdentifier TeamsAppSource { get; set; }
    }
}
