// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The call connection properties. </summary>
    public class CallConnectionProperties
    {
        internal CallConnectionProperties(string callConnectionId, string serverCallId, CallSource callSource, IEnumerable<CommunicationIdentifier> targets, CallConnectionState callConnectionState, Uri callbackEndpoint, string mediaSubscriptionId)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CallSource = callSource;
            Targets = targets == null ? new List<CommunicationIdentifier>() : targets.ToList();
            CallConnectionState = callConnectionState == default(CallConnectionState) ? CallConnectionState.Unknown : callConnectionState;
            CallbackEndpoint = callbackEndpoint;
            MediaSubscriptionId = mediaSubscriptionId;
        }

        internal CallConnectionProperties(CallConnectionPropertiesInternal callConnectionPropertiesDtoInternal)
        {
            CallConnectionId = callConnectionPropertiesDtoInternal.CallConnectionId;
            ServerCallId = callConnectionPropertiesDtoInternal.ServerCallId;
            CallSource = new CallSource(CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesDtoInternal.Source.Identifier))
            {
                CallerId = callConnectionPropertiesDtoInternal.Source.CallerId == null ? null : new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.Source.CallerId.Value),
                DisplayName = callConnectionPropertiesDtoInternal.Source.DisplayName,
            };
            Targets = callConnectionPropertiesDtoInternal.Targets.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();

            if (callConnectionPropertiesDtoInternal.CallConnectionState == null || callConnectionPropertiesDtoInternal.CallConnectionState ==  default(CallConnectionState))
            {
                CallConnectionState = CallConnectionState.Unknown;
            }
            else
            {
                CallConnectionState = callConnectionPropertiesDtoInternal.CallConnectionState.Value;
            }

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
        public CallConnectionState CallConnectionState { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackEndpoint { get; }
        /// <summary> SubscriptionId for media streaming. </summary>
        public string MediaSubscriptionId { get; }
    }
}
