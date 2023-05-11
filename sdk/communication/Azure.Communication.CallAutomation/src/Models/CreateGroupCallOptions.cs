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
        /// The endpoint URL of the Azure Cognitive Services resource attached
        /// </summary>
        public Uri AzureCognitiveServicesEndpointUrl { get; set; }

        /// <summary>
        /// Custom Context for PSTN targets.
        /// </summary>
        public IDictionary<string, string> SipHeaders { get; set; }

        /// <summary>
        /// Custom Context for Voip targets.
        /// </summary>
        public IDictionary<string, string> VoipHeaders { get; set; }
    }
}
