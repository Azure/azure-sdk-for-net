// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="targets"></param>
        /// <param name="callSource"></param>
        /// <param name="callbackUri"></param>
        public CreateCallOptions(CallSource callSource, IEnumerable<CommunicationIdentifier> targets, Uri callbackUri)
        {
            Targets = (IReadOnlyList<CommunicationIdentifier>)targets;
            CallSource = callSource;
            CallbackUri = callbackUri;
        }

        /// <summary>
        /// The targets of the call.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> Targets { get; }

        /// <summary>
        /// The source of the call.
        /// </summary>
        public CallSource CallSource { get; }

        /// <summary>
        /// The callback Uri.
        /// </summary>
        public Uri CallbackUri { get; }

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
    }
}
