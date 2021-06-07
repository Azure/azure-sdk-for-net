// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call connection details.
    /// </summary>
    public class CallConnectionDetails
    {
        /// <summary> Initializes a new instance of CallConnectionsDetailsResponseInternal. </summary>
        internal CallConnectionDetails(CallConnectionsDetailsResponseInternal callConnectionsDetailsResponseInternal)
        {
            CallConnectionId = callConnectionsDetailsResponseInternal.CallConnectionId;
            Source = CommunicationIdentifierSerializer.Deserialize(callConnectionsDetailsResponseInternal.Source);
            Targets = callConnectionsDetailsResponseInternal.Targets?.Select(t => CommunicationIdentifierSerializer.Deserialize(t));
            CallState = callConnectionsDetailsResponseInternal.CallState;
            Subject = callConnectionsDetailsResponseInternal.Subject;
            CallbackUri = new Uri(callConnectionsDetailsResponseInternal.CallbackUri);
            RequestedMediaTypes = callConnectionsDetailsResponseInternal.RequestedMediaTypes;
            RequestedCallEvents = callConnectionsDetailsResponseInternal.RequestedCallEvents;
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }
        /// <summary> The source of the call. </summary>
        public CommunicationIdentifier Source { get; }
        /// <summary> The targets of the call. </summary>
        public IEnumerable<CommunicationIdentifier> Targets { get; }
        /// <summary> The state of the call. </summary>
        public CallState? CallState { get; }
        /// <summary> The subject. </summary>
        public string Subject { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; }
        /// <summary> The requested modalities. </summary>
        public IEnumerable<CallModality> RequestedMediaTypes { get; }
        /// <summary> The requested call events to subscribe to. </summary>
        public IEnumerable<EventSubscriptionType> RequestedCallEvents { get; }
    }
}
