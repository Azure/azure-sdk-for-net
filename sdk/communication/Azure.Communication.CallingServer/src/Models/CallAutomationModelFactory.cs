// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> Model factory for read-only models. </summary>
    [CodeGenModel("ServerCallingModelFactory")]
    public static partial class CallAutomationModelFactory
    {
        /// <summary> Initializes a new instance of AddParticipantsResult. </summary>
        /// <param name="participants"> Participants of the call. </param>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallingServer.AddParticipantsResult"/> instance for mocking. </returns>
        public static AddParticipantsResult AddParticipantsResult(IEnumerable<CallParticipant> participants = default, string operationContext = default)
        {
            return new AddParticipantsResult(participants == null ? new List<CallParticipant>() : participants.ToList(), operationContext);
        }

        /// <summary> Initializes a new instance of AnswerCallResult. </summary>
        /// <param name="callConnection"> CallConnection Client. </param>
        /// <param name="callConnectionProperties"> Properties of the call. </param>
        /// <returns> A new <see cref="CallingServer.AnswerCallResult"/> instance for mocking. </returns>
        public static AnswerCallResult AnswerCallResult(CallConnection callConnection = default, CallConnectionProperties callConnectionProperties = default)
        {
            return new AnswerCallResult(callConnection, callConnectionProperties);
        }

        /// <summary> Initializes a new instance of CallConnectionProperties. </summary>
        /// <param name="callConnectionId">The call connection id.</param>
        /// <param name="serverCallId">The server call id.</param>
        /// <param name="callSource">The source of the call.</param>
        /// <param name="targets">The targets of the call.</param>
        /// <param name="callConnectionState">The state of the call connection.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="callbackEndpoint">The callback URI.</param>
        /// <param name="mediaSubscriptionId">The subscriptionId for Media Streaming.</param>
        /// <returns> A new <see cref="CallingServer.CallConnectionProperties"/> instance for mocking. </returns>
        public static CallConnectionProperties CallConnectionProperties(string callConnectionId = default, string serverCallId = default, CallSource callSource = default, IEnumerable<CommunicationIdentifier> targets = default, CallConnectionState callConnectionState = default, string subject = default, Uri callbackEndpoint = default, string mediaSubscriptionId = default)
        {
            return new CallConnectionProperties(callConnectionId, serverCallId, callSource, targets, callConnectionState, subject, callbackEndpoint, mediaSubscriptionId);
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        /// <returns> A new <see cref="CallingServer.CallParticipant"/> instance for mocking. </returns>
        public static CallParticipant CallParticipant(CommunicationIdentifier identifier = default, bool isMuted = default)
        {
            return new CallParticipant(identifier, isMuted);
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="callConnection">The instance of callConnection.</param>
        /// <param name="callConnectionProperties">The properties of the call.</param>
        /// <returns> A new <see cref="CallingServer.CreateCallResult"/> instance for mocking. </returns>
        public static CreateCallResult CreateCallResult(CallConnection callConnection = default, CallConnectionProperties callConnectionProperties = default)
        {
            return new CreateCallResult(callConnection, callConnectionProperties);
        }

        /// <summary> Create an EventSource. </summary>
        /// <param name="callConnectionId"> Call connection id for the event. </param>
        /// <param name="eventName"> Optional event name; used for events related to content. </param>
        /// <returns> A new <see cref="CallingServer.CreateCallResult"/> instance for mocking. </returns>
        private static string CreateEventSource(string callConnectionId, string eventName = "")
        {
            var eventSourcePrefix = "calling/callConnections/";
            StringBuilder eventSource = new StringBuilder();
            eventSource.Append(eventSourcePrefix + "/" + callConnectionId);
            if (eventName.Length > 0)
            {
                eventSource.Append("/" + eventName);
            }
            return eventSource.ToString();
        }

        /// <summary>
        /// Initializes a new instance of add participant failed event.
        /// </summary>
        public static AddParticipantsFailed AddParticipantsFailed(string operationContext = default, ResultInformation resultInformation = default, IEnumerable<CommunicationIdentifier> participants = default, string version = default, string callConnectionId = default, string serverCallId = default, string correlationId = default)
        {
            var internalObject = new AddParticipantsFailedInternal(
                CreateEventSource(callConnectionId),
                operationContext,
                resultInformation,
                participants == null ? new List<CommunicationIdentifierModel>() : participants.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList(),
                version,
                callConnectionId,
                serverCallId,
                correlationId,
                CallAutomationEventParser.EventPrefix + nameof(AddParticipantsFailed)
                );

            return new AddParticipantsFailed(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of add participant success event.
        /// </summary>
        public static AddParticipantsSucceeded AddParticipantsSucceeded(string operationContext = default, ResultInformation resultInformation = default, IEnumerable<CommunicationIdentifier> participants = default, string version = default, string callConnectionId = default, string serverCallId = default, string correlationId = default)
        {
            var internalObject = new AddParticipantsSucceededInternal(
                CreateEventSource(callConnectionId),
                operationContext,
                resultInformation,
                participants == null ? new List<CommunicationIdentifierModel>() : participants.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList(),
                version,
                callConnectionId,
                serverCallId,
                correlationId,
                CallAutomationEventParser.EventPrefix + nameof(AddParticipantsFailed)
                );

            return new AddParticipantsSucceeded(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of Participants Updated event.
        /// </summary>
        public static ParticipantsUpdated ParticipantsUpdated(IEnumerable<CommunicationIdentifier> participants = default, string version = default, string operationContext = default, ResultInformation resultInformation = default, string callConnectionId = default, string serverCallId = default, string correlationId = default)
        {
            var internalObject = new ParticipantsUpdatedInternal(
                CreateEventSource(callConnectionId),
                participants == null ? new List<CommunicationIdentifierModel>() : participants.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList(),
                version,
                operationContext,
                resultInformation,
                callConnectionId,
                serverCallId,
                correlationId,
                CallAutomationEventParser.EventPrefix + nameof(ParticipantsUpdated)
                );

            return new ParticipantsUpdated(internalObject);
        }
    }
}
