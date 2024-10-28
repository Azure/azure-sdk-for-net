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
    [CodeGenModel("CommunicationCallAutomationModelFactory")]
    public static partial class CallAutomationModelFactory
    {
        /// <summary> Initializes a new instance of CallConnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.CallConnected"/> instance for mocking. </returns>
        public static CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new CallConnected(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of CallDisconnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.CallConnected"/> instance for mocking. </returns>
        public static CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new CallDisconnected(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of CallTransferFailed. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferFailed"/> instance for mocking. </returns>
        public static CallTransferFailed CallTransferFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallTransferFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionStopped. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionStopped"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionStopped ContinuousDtmfRecognitionStopped(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new ContinuousDtmfRecognitionStopped(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionToneFailed. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionToneFailed"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionToneFailed ContinuousDtmfRecognitionToneFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, ResultInformation resultInformation = null, string operationContext = null)
        {
            return new ContinuousDtmfRecognitionToneFailed(callConnectionId, serverCallId, correlationId, resultInformation, operationContext);
        }

        /// <summary> Initializes a new instance of PlayCompleted. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCompleted"/> instance for mocking. </returns>
        public static PlayCompleted PlayCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayFailed. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayFailed"/> instance for mocking. </returns>
        public static PlayFailed PlayFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayCanceled. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCanceled"/> instance for mocking. </returns>
        public static PlayCanceled PlayCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new PlayCanceled(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of RecognizeCanceled. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeCanceled"/> instance for mocking. </returns>
        public static RecognizeCanceled RecognizeCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new RecognizeCanceled(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of RecognizeFailed. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeFailed"/> instance for mocking. </returns>
        public static RecognizeFailed RecognizeFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new RecognizeFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of AddParticipantsResult. </summary>
        /// <param name="participant"> Participant of the call. </param>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <param name="invitationId">The Invitation ID used to cancel the add participant action</param>
        /// <returns> A new <see cref="CallAutomation.AddParticipantResult"/> instance for mocking. </returns>
        public static AddParticipantResult AddParticipantsResult(CallParticipant participant = default, string operationContext = default, string invitationId = default)
        {
            return new AddParticipantResult(participant, operationContext, invitationId);
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
        /// <param name="dataSubscriptionId">The subscriptionId for transcription.</param>
        /// <param name="answeredBy">Identifier that answered the call.</param>
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
            CommunicationUserIdentifier answeredBy = default,
            string dataSubscriptionId = default)
        {
            return new CallConnectionProperties(callConnectionId, serverCallId, targets, callConnectionState, callbackUri, sourceIdentity, sourceCallerIdNumber, sourceDisplayName, dataSubscriptionId, answeredBy);
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

        /// <summary> Initializes a new instance of CancelAddParticipantResult. </summary>
        /// <param name="invitationId"> Invitation ID used to cancel the request. </param>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.CancelAddParticipantOperationResult"/> instance for mocking. </returns>
        public static CancelAddParticipantOperationResult CancelAddParticipantResult(string invitationId = default, string operationContext = default)
        {
            return new CancelAddParticipantOperationResult(invitationId, operationContext);
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
        /// Initializes a new instance of cancel add participant failed event.
        /// </summary>
        public static CancelAddParticipantFailed CancelAddParticipantFailed(string callConnectionId = default, string serverCallId = default, string correlationId = default, string invitationId = default, ResultInformation resultInformation = default, string operationContext = default)
        {
            var internalObject = new CancelAddParticipantFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                invitationId
                );

            return new CancelAddParticipantFailed(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of cancel add participant success event.
        /// </summary>
        public static CancelAddParticipantSucceeded CancelAddParticipantSucceeded(string callConnectionId = default, string serverCallId = default, string correlationId = default, string invitationId = default, string operationContext = default)
        {
            var internalObject = new CancelAddParticipantSucceededInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                invitationId
                );

            return new CancelAddParticipantSucceeded(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of create call failed event.
        /// </summary>
        public static CreateCallFailed CreateCallFailed(
            string callConnectionId = default,
            string serverCallId = default,
            string correlationId = default,
            ResultInformation resultInformation = default,
            string operationContext = default)
        {
            var internalObject = new CreateCallFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation);

            return new CreateCallFailed(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of answer failed event.
        /// </summary>
        public static AnswerFailed AnswerFailed(
            string callConnectionId = default,
            string serverCallId = default,
            string correlationId = default,
            ResultInformation resultInformation = default,
            string operationContext = default)
        {
            var internalObject = new AnswerFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation);

            return new AnswerFailed(internalObject);
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
                    : participants.Select(p => new CallParticipantInternal(CommunicationIdentifierSerializer.Serialize(p.Identifier), p.IsMuted, null)).ToList()
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
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="recognizeResult"> Defines the result for RecognitionType = Dtmf, Choice, Speech. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeCompleted"/> instance for mocking. </returns>
        public static RecognizeCompleted RecognizeCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, CallMediaRecognitionType recognitionType = default, RecognizeResult recognizeResult = null)
        {
            return new RecognizeCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation, recognitionType, recognizeResult);
        }

        /// <summary> Initializes a new instance of CallTransferAccepted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="transferee"> Transferee is the participant who is transferring the call.  </param>
        /// <param name="transferTarget"> The identity of the target where call should be transferred to. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferAccepted"/> instance for mocking. </returns>
        public static CallTransferAccepted CallTransferAccepted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, CommunicationIdentifier transferee = null, CommunicationIdentifier transferTarget = null)
        {
            var internalEvent = new CallTransferAcceptedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                transferTarget == null ? null : CommunicationIdentifierSerializer.Serialize(transferTarget),
                transferee == null ? null : CommunicationIdentifierSerializer.Serialize(transferee)
                );
            return new CallTransferAccepted(internalEvent);
        }

        /// <summary>
        /// Initializes a new instance of SendDtmfTonesCompleted.
        /// </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call corre lation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfTonesCompleted"/> instance for mocking. </returns>
        public static SendDtmfTonesCompleted SendDtmfTonesCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesCompletedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesCompleted(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of SendDtmfTonesFailed.
        /// </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call corre lation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfTonesFailed"/> instance for mocking. </returns>
        public static SendDtmfTonesFailed SendDtmfTonesFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesFailed(internalObject);
        }
    }
}
