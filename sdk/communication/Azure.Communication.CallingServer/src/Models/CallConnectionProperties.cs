// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallingServer
{
    /// <summary> The call connection properties. </summary>
    public class CallConnectionProperties
    {
        internal CallConnectionProperties(string callConnectionId, string serverCallId, CallSource callSource, IEnumerable<CommunicationIdentifier> targets, CallConnectionState callConnectionState, string subject, Uri callbackEndpoint, string mediaSubscriptionId)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CallSource = callSource;
            Targets = targets.ToList();
            CallConnectionState = callConnectionState;
            Subject = subject;
            CallbackEndpoint = callbackEndpoint;
            MediaSubscriptionId = mediaSubscriptionId;
        }

        internal CallConnectionProperties(CallConnectionPropertiesDtoInternal callConnectionPropertiesDtoInternal)
        {
            CallConnectionId = callConnectionPropertiesDtoInternal.CallConnectionId;
            ServerCallId = callConnectionPropertiesDtoInternal.ServerCallId;
            CallSource = new CallSource(CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesDtoInternal.Source.Identifier));
            CallSource.CallerId = callConnectionPropertiesDtoInternal.Source.CallerId == null ? null : new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.Source.CallerId.Value);
            Targets = callConnectionPropertiesDtoInternal.Targets.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            CallConnectionState = callConnectionPropertiesDtoInternal.CallConnectionState;
            Subject = callConnectionPropertiesDtoInternal.Subject;
            CallbackEndpoint = new Uri(callConnectionPropertiesDtoInternal.CallbackUri);
            MediaSubscriptionId = callConnectionPropertiesDtoInternal.MediaSubscriptionId;
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }
        /// <summary> The server call id. </summary>
        public string ServerCallId { get; }
        /// <summary> The source of the call. </summary>
        public CallSource CallSource { get; }
        /// <summary> The targets of the call. </summary>
        public IReadOnlyList<CommunicationIdentifier> Targets { get; }
        /// <summary> The state of the call connection. </summary>
        public CallConnectionState? CallConnectionState { get; }
        /// <summary> The subject. </summary>
        public string Subject { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackEndpoint { get; }
        /// <summary> SubscriptionId for media streaming. </summary>
        public string MediaSubscriptionId { get; }
    }
}
