// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> The call connection properties. </summary>
    public class CallConnectionProperties
    {
        /// <summary> Initializes a new instance of CallConnectionProperties. </summary>
        /// <param name="callConnectionPropertiesDtoInternal">The call connection properties internal.</param>
        internal CallConnectionProperties(CallConnectionPropertiesDtoInternal callConnectionPropertiesDtoInternal)
        {
            CallConnectionId = callConnectionPropertiesDtoInternal.CallConnectionId;
            ServerCallId = callConnectionPropertiesDtoInternal.ServerCallId;
            Source = CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesDtoInternal.Source);
            AlternateCallerId = callConnectionPropertiesDtoInternal.AlternateCallerId == null ? null : new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.AlternateCallerId.Value);
            Targets = callConnectionPropertiesDtoInternal.Targets.Select(t => CommunicationIdentifierSerializer.Deserialize(t));
            CallConnectionState = callConnectionPropertiesDtoInternal.CallConnectionState;
            Subject = callConnectionPropertiesDtoInternal.Subject;
            CallbackUri = new Uri(callConnectionPropertiesDtoInternal.CallbackUri);
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }
        /// <summary> The server call id. </summary>
        public string ServerCallId { get; }
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
    }
}
