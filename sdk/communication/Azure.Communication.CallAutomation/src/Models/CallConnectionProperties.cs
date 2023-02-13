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
        internal CallConnectionProperties(
            string callConnectionId,
            string serverCallId,
            IEnumerable<CommunicationIdentifier> targets,
            CallConnectionState callConnectionState,
            Uri callbackEndpoint,
            CommunicationIdentifier sourceIdentity,
            PhoneNumberIdentifier sourceCallerIdNumber,
            string sourceDisplayName,
            string mediaSubscriptionId
            )
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            Targets = targets == null ? new List<CommunicationIdentifier>() : targets.ToList();
            CallConnectionState = callConnectionState == default ? CallConnectionState.Unknown : callConnectionState;
            CallbackEndpoint = callbackEndpoint;
            SourceIdentity = sourceIdentity;
            SourceCallerIdNumber = sourceCallerIdNumber;
            SourceDisplayName = sourceDisplayName;
            MediaSubscriptionId = mediaSubscriptionId;
        }

        internal CallConnectionProperties(CallConnectionPropertiesInternal callConnectionPropertiesDtoInternal)
        {
            CallConnectionId = callConnectionPropertiesDtoInternal.CallConnectionId;
            ServerCallId = callConnectionPropertiesDtoInternal.ServerCallId;
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
            SourceIdentity = CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesDtoInternal.SourceIdentity);
            SourceDisplayName = callConnectionPropertiesDtoInternal.SourceDisplayName;

            if (callConnectionPropertiesDtoInternal.SourceCallerIdNumber != null)
            {
                var communicationIdentifierModel = new CommunicationIdentifierModel
                {
                    PhoneNumber = callConnectionPropertiesDtoInternal.SourceCallerIdNumber,
                };
                SourceCallerIdNumber = (PhoneNumberIdentifier)CommunicationIdentifierSerializer.Deserialize(communicationIdentifierModel);
            }
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }
        /// <summary> The server call id. </summary>
        public string ServerCallId { get; }
        /// <summary> The targets of the call. </summary>
        public IReadOnlyList<CommunicationIdentifier> Targets { get; }
        /// <summary> The state of the call connection. </summary>
        public CallConnectionState CallConnectionState { get; }
        /// <summary> The callback URI. </summary>
        public Uri CallbackEndpoint { get; }
        /// <summary> SubscriptionId for media streaming. </summary>
        public string MediaSubscriptionId { get; }
        /// <summary>
        /// Caller ID phone number to appear on the invitee.
        /// </summary>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; }
        /// <summary>
        /// Display name to appear on the invitee.
        /// </summary>
        public string SourceDisplayName { get; }
        /// <summary>
        /// Source identity.
        /// </summary>
        public CommunicationIdentifier SourceIdentity { get; }
    }
}
