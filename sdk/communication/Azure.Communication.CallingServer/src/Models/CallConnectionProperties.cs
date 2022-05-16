// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary> The Details of the call. </summary>
    public class CallConnectionProperties
    {
        /// <summary> Initializes a new instance of CallConnectionProperties. </summary>
        /// <param name="callConnectionPropertiesInternal">The call connection properties internal.</param>
        internal CallConnectionProperties(CallConnectionPropertiesInternal callConnectionPropertiesInternal)
        {
            CallLegId = callConnectionPropertiesInternal.CallLegId;
            Source = CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesInternal.Source);
            Target = CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesInternal.Target);
            AlternateCallerId = callConnectionPropertiesInternal.AlternateCallerId == null ? null : new PhoneNumberIdentifier(callConnectionPropertiesInternal.AlternateCallerId.Value);
            CallConnectionState = callConnectionPropertiesInternal.CallConnectionState;
            Subject = callConnectionPropertiesInternal.Subject;
            CallbackUri = new Uri(callConnectionPropertiesInternal.CallbackUri);
        }

        /// <summary> The call connection id. </summary>
        public string CallLegId { get; }
        /// <summary> The source of the call. </summary>
        public CommunicationIdentifier Source { get; }
        /// <summary> The alternate identity of the source of the call if dialing out to a pstn number. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; }
        /// <summary> The targets of the call. </summary>
        public CommunicationIdentifier Target { get; }
        /// <summary> The state of the call connection. </summary>
        public CallConnectionState? CallConnectionState { get; }
        /// <summary> The subject. </summary>
        public string Subject { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; }
    }
}
