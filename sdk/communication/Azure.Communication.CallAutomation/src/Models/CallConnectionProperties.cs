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
            Uri callbackUri,
            CommunicationIdentifier source,
            PhoneNumberIdentifier sourceCallerIdNumber,
            string sourceDisplayName,
            string mediaSubscriptionId,
            string dataSubscriptionId,
            CommunicationUserIdentifier answeredBy
            )
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            Targets = targets == null ? new List<CommunicationIdentifier>() : targets.ToList();
            CallConnectionState = callConnectionState == default ? CallConnectionState.Unknown : callConnectionState;
            CallbackUri = callbackUri;
            Source = source;
            SourceCallerIdNumber = sourceCallerIdNumber;
            SourceDisplayName = sourceDisplayName;
            MediaSubscriptionId = mediaSubscriptionId;
            DataSubscriptionId = dataSubscriptionId;
            AnsweredBy = answeredBy;
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

            CallbackUri = new Uri(callConnectionPropertiesDtoInternal.CallbackUri);
            MediaSubscriptionId = callConnectionPropertiesDtoInternal.MediaSubscriptionId;
            DataSubscriptionId = callConnectionPropertiesDtoInternal.DataSubscriptionId;
            Source = callConnectionPropertiesDtoInternal.Source == null? null : CommunicationIdentifierSerializer.Deserialize(callConnectionPropertiesDtoInternal.Source);
            SourceDisplayName = callConnectionPropertiesDtoInternal.SourceDisplayName;
            CorrelationId = callConnectionPropertiesDtoInternal.CorrelationId;
            AnsweredBy = callConnectionPropertiesDtoInternal.AnsweredBy == null? null : new CommunicationUserIdentifier(callConnectionPropertiesDtoInternal.AnsweredBy.Id);

            if (callConnectionPropertiesDtoInternal.SourceCallerIdNumber != null)
            {
                SourceCallerIdNumber = new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.SourceCallerIdNumber.Value);
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
        public Uri CallbackUri { get; }
        /// <summary> SubscriptionId for media streaming. </summary>
        public string MediaSubscriptionId { get; }
        /// <summary> SubscriptionId for transcription. </summary>
        public string DataSubscriptionId { get; }
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
        public CommunicationIdentifier Source { get; }

        /// <summary>
        /// The correlation ID.
        /// </summary>
        public string CorrelationId { get; }

        /// <summary>
        /// Identity of the answering entity. Only populated when identity is provided in the request.
        /// </summary>
        public CommunicationUserIdentifier AnsweredBy { get; }
    }
}
