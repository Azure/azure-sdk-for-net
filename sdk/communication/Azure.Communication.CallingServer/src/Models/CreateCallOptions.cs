// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.CallingServer
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
        /// <param name="source"></param>
        /// <param name="callbackEndpoint"></param>
        public CreateCallOptions(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackEndpoint)
        {
            Targets = targets;
            Source = source;
            CallbackEndpoint = callbackEndpoint;
        }

        /// <summary>
        /// The targets of the call.
        /// </summary>
        public IEnumerable<CommunicationIdentifier> Targets { get; }

        /// <summary>
        /// The source of the call.
        /// </summary>
        public CallSource Source { get; }

        /// <summary>
        /// The callback URI.
        /// </summary>
        public Uri CallbackEndpoint { get; }

        /// <summary>
        /// The subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Media Streaming Configuration.
        /// </summary>
        public MediaStreamingConfiguration MediaStreamingConfiguration { get; set; }
    }
}
