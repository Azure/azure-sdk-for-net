// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Create Call Request.
    /// </summary>
    public class CreateSimRingCallOptions
    {
        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="callbackUri"></param>
        public CreateSimRingCallOptions(IEnumerable<CommunicationIdentifier> targets, Uri callbackUri)
        {
            Targets = (IReadOnlyList<CommunicationIdentifier>)targets;
            CallbackUri = callbackUri;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The targets of the call.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> Targets { get; }

        /// <summary>
        /// The callback Uri.
        /// </summary>
        public Uri CallbackUri { get; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string SourceDisplayName { get; set; }

        /// <summary>
        /// TCommunicationUserIdentifier
        /// </summary>
        /// <value></value>
        public CommunicationUserIdentifier SourceUserIdentifier { get; set; }

        /// <summary>
        /// (Optional) The identifier of the source of the call for this invite operation. If SourceDisplayName
        /// is not set, the display name of the source will be used by default when adding a PSTN participant or teams user.
        /// </summary>
        public MicrosoftTeamsUserIdentifier SourceTeamsUserIdentifier { get; set; }

        /// <summary>
        /// TODO: Combine this with SourceIdentifier
        /// </summary>
        /// <value></value>
        public PhoneNumberIdentifier SourcePhoneNumberIdentifier { get; set; }

        /// <summary> Used by customer to pass in context to targets. </summary>
        public CustomContext CustomContext { get; set; }

        /// <summary>
        /// The Operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Media Streaming Configuration.
        /// </summary>
        public MediaStreamingOptions MediaStreamingOptions { get; set; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }

        /// <summary>
        /// The endpoint URL of the Azure Cognitive Services resource attached
        /// </summary>
        public Uri AzureCognitiveServicesEndpointUrl { get; set; }
    }
}
