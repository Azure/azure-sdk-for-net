// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Model factory for read-only models. </summary>
    [CodeGenModel("AzureCommunicationServicesModelFactory")]
    public static partial class CommunicationCallAutomationModelFactory
    {
        /// <summary> Initializes a new instance of AddParticipantsResult. </summary>
        /// <param name="participant"> Participant of the call. </param>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.AddParticipantResult"/> instance for mocking. </returns>
        public static AddParticipantResult AddParticipantsResult(CallParticipant participant = default, string operationContext = default)
        {
            return new AddParticipantResult(participant, operationContext);
        }

        /// <summary> Initializes a new instance of AnswerCallResult. </summary>
        /// <param name="callConnection"> CallConnection Client. </param>
        /// <param name="callConnectionProperties"> Properties of the call. </param>
        /// <returns> A new <see cref="CallAutomation.AnswerCallResult"/> instance for mocking. </returns>
        public static AnswerCallResult AnswerCallResult(CallConnection callConnection = default, CallConnectionProperties callConnectionProperties = default)
        {
            return new AnswerCallResult(callConnection, callConnectionProperties);
        }

        /// <summary> Initializes a new instance of CallConnectionProperties. </summary>
        /// <param name="callConnectionId">The call connection id.</param>
        /// <param name="serverCallId">The server call id.</param>
        /// <param name="targets">The targets of the call.</param>
        /// <param name="callConnectionState">The state of the call connection.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <param name="sourceIdentity">Source identity.</param>
        /// <param name="sourceCallerIdNumber">Caller ID phone number to appear on the invitee.</param>
        /// <param name="sourceDisplayName">Display name to appear on the invitee.</param>
        /// <param name="answeredBy">AnsweredBy identity.</param>
        /// <returns> A new <see cref="CallAutomation.CallConnectionProperties"/> instance for mocking. </returns>
        public static CallConnectionProperties CallConnectionProperties(
            string callConnectionId = default,
            string serverCallId = default,
            IEnumerable<CommunicationIdentifier> targets = default,
            CallConnectionState callConnectionState = default,
            Uri callbackUri = default,
            CommunicationIdentifier sourceIdentity = default,
            PhoneNumberIdentifier sourceCallerIdNumber = default,
            string sourceDisplayName = default,
            CommunicationIdentifier answeredBy = default)
        {
            return new CallConnectionProperties(callConnectionId, serverCallId, targets, callConnectionState, callbackUri, sourceIdentity, sourceCallerIdNumber, sourceDisplayName, answeredBy);
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        /// <returns> A new <see cref="CallAutomation.CallParticipant"/> instance for mocking. </returns>
        public static CallParticipant CallParticipant(CommunicationIdentifier identifier = default, bool isMuted = default)
        {
            return new CallParticipant(identifier, isMuted);
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="callConnection">The instance of callConnection.</param>
        /// <param name="callConnectionProperties">The properties of the call.</param>
        /// <returns> A new <see cref="CallAutomation.CreateCallResult"/> instance for mocking. </returns>
        public static CreateCallResult CreateCallResult(CallConnection callConnection = default, CallConnectionProperties callConnectionProperties = default)
        {
            return new CreateCallResult(callConnection, callConnectionProperties);
        }

        /// <summary> Initializes a new instance of RemoveParticipantResult. </summary>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.RemoveParticipantResult"/> instance for mocking. </returns>
        public static RemoveParticipantResult RemoveParticipantResult(string operationContext = default)
        {
            return new RemoveParticipantResult(operationContext);
        }

        /// <summary> Create an EventSource. </summary>
        /// <param name="callConnectionId"> Call connection id for the event. </param>
        /// <param name="eventName"> Optional event name; used for events related to content. </param>
        /// <returns> A new <see cref="CallAutomation.CreateCallResult"/> instance for mocking. </returns>
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
        public static AddParticipantFailed AddParticipantFailed(string callConnectionId = default, string serverCallId = default, string correlationId = default, string operationContext = default, ResultInformation resultInformation = default, CommunicationIdentifier participant = default)
        {
            var internalObject = new AddParticipantFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                participant: CommunicationIdentifierSerializer.Serialize(participant)
                );

            return new AddParticipantFailed(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of add participant success event.
        /// </summary>
        public static AddParticipantSucceeded AddParticipantSucceeded(string callConnectionId = default, string serverCallId = default, string correlationId = default, string operationContext = default, ResultInformation resultInformation = default, CommunicationIdentifier participant = default)
        {
            var internalObject = new AddParticipantSucceededInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                participant: CommunicationIdentifierSerializer.Serialize(participant)
                );

            return new AddParticipantSucceeded(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of Participants Updated event.
        /// </summary>
        public static ParticipantsUpdated ParticipantsUpdated(string callConnectionId = default, string serverCallId = default, string correlationId = default, IEnumerable<CallParticipant> participants = default, int sequenceNumber = default)
        {
            var internalObject = new ParticipantsUpdatedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                sequenceNumber,
                participants == null
                    ? new List<CallParticipantInternal>()
                    : participants.Select(p => new CallParticipantInternal(CommunicationIdentifierSerializer.Serialize(p.Identifier), p.IsMuted)).ToList()
                );

            return new ParticipantsUpdated(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of remove participant failed event.
        /// </summary>
        public static RemoveParticipantFailed RemoveParticipantFailed(string callConnectionId = default, string serverCallId = default, string correlationId = default, string operationContext = default, ResultInformation resultInformation = default, CommunicationIdentifier participant = default)
        {
            var internalObject = new RemoveParticipantFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                participant: CommunicationIdentifierSerializer.Serialize(participant)
                );

            return new RemoveParticipantFailed(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of remove participant success event.
        /// </summary>
        public static RemoveParticipantSucceeded RemoveParticipantSucceeded(string callConnectionId = default, string serverCallId = default, string correlationId = default, string operationContext = default, ResultInformation resultInformation = default, CommunicationIdentifier participant = default)
        {
            var internalObject = new RemoveParticipantSucceededInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                participant: CommunicationIdentifierSerializer.Serialize(participant)
                );

            return new RemoveParticipantSucceeded(internalObject);
        }

        /// <summary> Initializes a new instance of RecognizeCompletedInternal. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call corre lation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="recognizeResult"> Defines the result for RecognitionType = Dtmf. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeCompleted"/> instance for mocking. </returns>
        public static RecognizeCompleted RecognizeCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, CallMediaRecognitionType recognitionType = default, RecognizeResult recognizeResult = null)
        {
            return new RecognizeCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation, recognitionType, recognizeResult);
        }

        /// <summary>
        /// Initializes a new instance of SendDtmfTonesCompleted.
        /// </summary>
        /// <param name="callConnectionId"></param>
        /// <param name="serverCallId"></param>
        /// <param name="correlationId"></param>
        /// <param name="operationContext"></param>
        /// <param name="resultInformation"></param>
        /// <returns></returns>
        public static SendDtmfTonesCompleted SendDtmfTonesCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesCompletedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesCompleted(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of SendDtmfTonesFailed.
        /// </summary>
        /// <param name="callConnectionId"></param>
        /// <param name="serverCallId"></param>
        /// <param name="correlationId"></param>
        /// <param name="operationContext"></param>
        /// <param name="resultInformation"></param>
        /// <returns></returns>
        public static SendDtmfTonesFailed SendDtmfTonesFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesFailed(internalObject);
        }
    }
}
