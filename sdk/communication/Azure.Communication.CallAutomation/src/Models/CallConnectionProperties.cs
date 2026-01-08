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
            MediaStreamingSubscription mediaStreamingSubscription,
            TranscriptionSubscription transcriptionSubscription,
            CommunicationUserIdentifier answeredBy,
            PhoneNumberIdentifier answeredFor
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
            MediaStreamingSubscription = mediaStreamingSubscription;
            TranscriptionSubscription = transcriptionSubscription;
            AnsweredBy = answeredBy;
            AnsweredFor = answeredFor;
        }

        internal CallConnectionProperties(CallConnectionPropertiesInternal callConnectionPropertiesDtoInternal)
        {
            CallConnectionId = callConnectionPropertiesDtoInternal.CallConnectionId;
            ServerCallId = callConnectionPropertiesDtoInternal.ServerCallId;
            Targets = callConnectionPropertiesDtoInternal.Targets.Select(t => CommunicationIdentifierSerializer_2025_06_30.Deserialize(t)).ToList();

            if (callConnectionPropertiesDtoInternal.CallConnectionState == null || callConnectionPropertiesDtoInternal.CallConnectionState == default(CallConnectionState))
            {
                CallConnectionState = CallConnectionState.Unknown;
            }
            else
            {
                CallConnectionState = callConnectionPropertiesDtoInternal.CallConnectionState.Value;
            }

            CallbackUri = new Uri(callConnectionPropertiesDtoInternal.CallbackUri);
            MediaStreamingSubscription = callConnectionPropertiesDtoInternal.MediaStreamingSubscription != null ?
               new MediaStreamingSubscription(
                   callConnectionPropertiesDtoInternal.MediaStreamingSubscription.Id,
                   callConnectionPropertiesDtoInternal.MediaStreamingSubscription.State,
                   callConnectionPropertiesDtoInternal.MediaStreamingSubscription.SubscribedContentTypes)
               : null;
            TranscriptionSubscription = callConnectionPropertiesDtoInternal.TranscriptionSubscription != null ?
                new TranscriptionSubscription(
                    callConnectionPropertiesDtoInternal.TranscriptionSubscription.Id,
                    callConnectionPropertiesDtoInternal.TranscriptionSubscription.State,
                    callConnectionPropertiesDtoInternal.TranscriptionSubscription.SubscribedResultTypes,
                    callConnectionPropertiesDtoInternal.TranscriptionSubscription.Locale)
                : null;
            Source = callConnectionPropertiesDtoInternal.Source == null ? null : CommunicationIdentifierSerializer_2025_06_30.Deserialize(callConnectionPropertiesDtoInternal.Source);
            SourceDisplayName = callConnectionPropertiesDtoInternal.SourceDisplayName;
            CorrelationId = callConnectionPropertiesDtoInternal.CorrelationId;
            AnsweredBy = callConnectionPropertiesDtoInternal.AnsweredBy == null ? null : new CommunicationUserIdentifier(callConnectionPropertiesDtoInternal.AnsweredBy.Id);

            if (callConnectionPropertiesDtoInternal.SourceCallerIdNumber != null)
            {
                SourceCallerIdNumber = new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.SourceCallerIdNumber.Value);
            }

            if (callConnectionPropertiesDtoInternal.AnsweredFor != null)
            {
                AnsweredFor = new PhoneNumberIdentifier(callConnectionPropertiesDtoInternal.AnsweredFor.Value);
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
        public MediaStreamingSubscription MediaStreamingSubscription { get; }
        /// <summary> SubscriptionId for transcription. </summary>
        public TranscriptionSubscription TranscriptionSubscription { get; }
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

        /// <summary>
        /// Identity of the original Pstn target of an incoming Call. Only populated when the original target is a Pstn number.
        /// </summary>
        public PhoneNumberIdentifier AnsweredFor { get; }
    }
}
