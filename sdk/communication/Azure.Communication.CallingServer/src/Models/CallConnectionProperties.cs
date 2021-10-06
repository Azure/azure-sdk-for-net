// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> The call connection properties. </summary>
    public class CallConnectionProperties
    {
        /// <summary> Initializes a new instance of CallConnectionPropertiesInternal. </summary>
        /// <param name="callConnectionPropertiesInternal">The call connection properties internal.</param>
        internal CallConnectionProperties(CallConnectionPropertiesInternal callConnectionPropertiesInternal)
        {
            CallConnectionId = callConnectionPropertiesInternal.CallConnectionId;
            Source = CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesInternal.Source);
            Targets = callConnectionPropertiesInternal.Targets.Select(t => CommunicationIdentifierSerializer.Deserialize(t));
            AlternateCallerId = callConnectionPropertiesInternal.AlternateCallerId == null ? null : new PhoneNumberIdentifier(callConnectionPropertiesInternal.AlternateCallerId.Value);
            CallConnectionState = callConnectionPropertiesInternal.CallConnectionState;
            Subject = callConnectionPropertiesInternal.Subject;
            CallbackUri = new Uri(callConnectionPropertiesInternal.CallbackUri);
            RequestedMediaTypes = callConnectionPropertiesInternal.RequestedMediaTypes;
            RequestedCallEvents = callConnectionPropertiesInternal.RequestedCallEvents;
            CallLocator = CallLocatorModelSerializer.Deserialize(callConnectionPropertiesInternal.CallLocator);
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }
        /// <summary> The source of the call. </summary>
        public CommunicationIdentifier Source { get; }
        /// <summary> The alternate identity of the source of the call if dialing out to a pstn number. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; }
        /// <summary> The targets of the call. </summary>
        public IEnumerable<CommunicationIdentifier> Targets { get; }
        /// <summary> The state of the call connection. </summary>
        public CallConnectionState? CallConnectionState { get; }
        /// <summary> The subject. </summary>
        public string Subject { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; }
        /// <summary> The requested modalities. </summary>
        public IEnumerable<CallMediaType> RequestedMediaTypes { get; }
        /// <summary> The requested call events to subscribe to. </summary>
        public IEnumerable<CallingEventSubscriptionType> RequestedCallEvents { get; }
        /// <summary> The server call id. </summary>
        public CallLocator CallLocator { get; }
    }
}
