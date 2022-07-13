// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services CallContent client.
    /// </summary>
    public class CallContentClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient RestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        /// <summary> Content Capabilities for the call. </summary>
        internal ContentCapabilities ContentCapabilities { get; }

        internal CallContentClient(string callConnectionId, ContentRestClient callContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            RestClient = callContentRestClient;
            _clientDiagnostics = clientDiagnostics;
            ContentCapabilities = new ContentCapabilities(CallConnectionId, callContentRestClient);
        }

        /// <summary>Initializes a new instance of <see cref="CallContentClient"/> for mocking.</summary>
        protected CallContentClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
            CallConnectionId = null;
            ContentCapabilities = null;
        }
    }
}
