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
    [CodeGenSuppress("CallTransferFailed", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("ContinuousDtmfRecognitionStopped", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("ContinuousDtmfRecognitionToneFailed", typeof(ResultInformation), typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("ContinuousDtmfRecognitionToneReceived", typeof(int?), typeof(DtmfTone?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ResultInformation))]
    [CodeGenSuppress("PlayCompleted", typeof(ResultInformation), typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("PlayFailed", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("RecognizeFailed", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("RecordingStateChanged", typeof(string), typeof(RecordingState), typeof(DateTimeOffset?), typeof(RecordingKind?), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("SendDtmfTonesCompleted", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("SendDtmfTonesFailed", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("HoldFailed", typeof(string), typeof(ResultInformation), typeof(string), typeof(string), typeof(string))]
    [CodeGenModel("CommunicationCallAutomationModelFactory")]
    public static partial class CallAutomationModelFactory
    {
        /// <summary>
        /// Initializes a new instance of audio data.
        /// </summary>
        /// <param name="data">Base64 encoded audio data.</param>
        /// <param name="timestamp">The timestamp of when the audio was captured.</param>
        /// <param name="participantId">The identifier of the participant who sent the audio.</param>
        /// <param name="silent">Indicates if the audio data represents silence.</param>
        /// <returns>A new instance of <see cref="AudioData"/> for mocking.</returns>
        public static AudioData AudioData(
            string data,
            DateTime timestamp,
            string participantId,
            bool silent)
        {
            return new AudioData(data, timestamp, participantId, silent);
        }

        /// <summary>
        /// Initializes a new instance of audio meta data.
        /// </summary>
        /// <param name="mediaSubscriptionId">The media subscription id.</param>
        /// <param name="encoding">The audio encoding.</param>
        /// <param name="sampleRate">The audio sample rate.</param>
        /// <param name="channels">The number of audio channels.</param>
        /// <param name="length">The length of the audio in milliseconds.</param>
        /// <returns>A new instance of <see cref="AudioMetadata"/> for mocking.</returns>
        public static AudioMetadata AudioMetadata(
            string mediaSubscriptionId,
            string encoding,
            int sampleRate,
            int channels,
            int length)
        {
            var internalObject = new AudioMetadataInternal
            {
                MediaSubscriptionId = mediaSubscriptionId,
                Encoding = encoding,
                SampleRate = sampleRate,
                Channels = channels,
                Length = length
            };
            return new AudioMetadata(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of transcription data.
        /// </summary>
        /// <param name="text">The transcribed text.</param>
        /// <param name="format">The format of the transcription.</param>
        /// <param name="confidence">The confidence score of the transcription.</param>
        /// <param name="offset">The offset of the transcription in the audio stream.</param>
        /// <param name="duration">The duration of the transcription in milliseconds.</param>
        /// <param name="words">The list of words in the transcription.</param>
        /// <param name="participantRawID">The raw ID of the participant who spoke.</param>
        /// <param name="resultState">The result state of the transcription.</param>
        /// <returns>A new instance of <see cref="TranscriptionData"/> for mocking.</returns>
        public static TranscriptionData TranscriptionData(
            string text,
            string format,
            double confidence,
            long offset,
            long duration,
            IEnumerable<WordData> words,
            string participantRawID,
            TranscriptionResultState resultState)
        {
            IEnumerable<WordDataInternal> wordDataInternalList = words.Select(w => new WordDataInternal { Text = w.Text, Offset = w.Offset.Ticks, Duration = w.Duration.Ticks });
            return new TranscriptionData
            (
                text,
                format,
                confidence,
                offset,
                duration,
                wordDataInternalList,
                participantRawID,
                resultState
            );
        }

        /// <summary>
        /// Initializes a new instance of word data.
        /// </summary>
        /// <param name="text">The text of the word.</param>
        /// <param name="offset">The offset of the word in the audio stream.</param>
        /// <param name="duration">The duration of the word in milliseconds.</param>
        /// <returns>A new instance of <see cref="WordData"/> for mocking.</returns>
        public static WordData WordData(
            string text,
            long offset,
            long duration)
        {
            return new WordData(text, offset, duration);
        }

        /// <summary>
        /// Initializes a new instance of out streaming data.
        /// </summary>
        /// <param name="kind">The media kind.</param>
        /// <returns>A new instance of <see cref="OutStreamingData"/> for mocking.</returns>
        public static OutStreamingData OutStreamingData(
            MediaKind kind)
        {
            return new OutStreamingData(kind);
        }

        /// <summary> Initializes a new instance of AddParticipantsResult. </summary>
        /// <param name="participant"> Participant of the call. </param>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <param name="invitationId"> The Invitation id of this call </param>
        /// <returns> A new <see cref="CallAutomation.AddParticipantResult"/> instance for mocking. </returns>
        public static AddParticipantResult AddParticipantsResult(CallParticipant participant = default, string operationContext = default, string invitationId = null)
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
        /// <param name="mediaStreamingSubscription">The subscription details for Media Streaming.</param>
        /// <param name="transcriptionSubscription">The subscription details for transcription.</param>
        /// <param name="answeredBy">Identifier that answered the call.</param>
        /// <param name="answeredFor">Identity of the original Pstn target of an incoming Call.</param>
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
            MediaStreamingSubscription mediaStreamingSubscription = default,
            TranscriptionSubscription transcriptionSubscription = default,
            PhoneNumberIdentifier answeredFor = default)
        {
            return new CallConnectionProperties(callConnectionId, serverCallId, targets, callConnectionState, callbackUri, sourceIdentity, sourceCallerIdNumber, sourceDisplayName, mediaStreamingSubscription, transcriptionSubscription, answeredBy, answeredFor);
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        /// <param name="isOnHold"> Is participant on hold. </param>
        /// <returns> A new <see cref="CallAutomation.CallParticipant"/> instance for mocking. </returns>
        public static CallParticipant CallParticipant(CommunicationIdentifier identifier = default, bool isMuted = default, bool isOnHold = default)
        {
            return new CallParticipant(identifier, isMuted, isOnHold);
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
        /// Initializes a new instance of Participants Updated event.
        /// </summary>
        public static ParticipantsUpdated ParticipantsUpdated(string callConnectionId = default, string serverCallId = default, string correlationId = default, IEnumerable<CallParticipant> participants = default, int sequenceNumber = default, ResultInformation resultInformation = null)
        {
            var internalObject = new ParticipantsUpdatedInternal(
                 callConnectionId,
                serverCallId,
                correlationId,
                sequenceNumber: sequenceNumber,
                participants: participants == null
                    ? new List<CallParticipantInternal>()
                    : participants.Select(p => new CallParticipantInternal(CommunicationIdentifierSerializer.Serialize(p.Identifier), p.IsMuted, p.IsOnHold)).ToList(),
                resultInformation: resultInformation
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
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="recognizeResult"> Defines the result for general recognizeResult. </param>
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
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="transferTarget"> Target who the call is transferred to. </param>
        /// <param name="transferee"> the participant who is being transferred away. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferAccepted"/> instance for mocking. </returns>
        public static CallTransferAccepted CallTransferAccepted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, CommunicationIdentifier transferee = null, CommunicationIdentifier transferTarget = null)
        {
            var internalEvent = new CallTransferAcceptedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                transferTarget: transferTarget == null ? null : CommunicationIdentifierSerializer.Serialize(transferTarget),
                transferee: transferee == null ? null : CommunicationIdentifierSerializer.Serialize(transferee)
                );
            return new CallTransferAccepted(internalEvent);
        }

        /// <summary>
        /// Initializes a new instance of add participant cancelled event.
        /// </summary>
        public static CancelAddParticipantSucceeded CancelAddParticipantSucceeded(
            string callConnectionId = default,
            string serverCallId = default,
            string correlationId = default,
            string invitationId = default,
            string operationContext = default,
            ResultInformation resultInformation = null)
        {
            var internalObject = new CancelAddParticipantSucceededInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                invitationId: invitationId,
                resultInformation: resultInformation
                );

            return new CancelAddParticipantSucceeded(internalObject);
        }

        /// <summary>
        /// Initializes a new instance of cancel add participant failed event.
        /// </summary>
        public static CancelAddParticipantFailed CancelAddParticipantFailed(
            string callConnectionId = default,
            string serverCallId = default,
            string correlationId = default,
            string invitationId = default,
            ResultInformation resultInformation = default,
            string operationContext = default)
        {
            var internalObject = new CancelAddParticipantFailedInternal(
                callConnectionId,
                serverCallId,
                correlationId,
                operationContext,
                resultInformation,
                invitationId: invitationId);

            return new CancelAddParticipantFailed(internalObject);
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

        /// <summary> Initializes a new instance of CallConnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers to set the context for creating a new call. This property will be null for answering a call. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.CallConnected"/> instance for mocking. </returns>
        public static CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallConnected(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        ///// <summary> Initializes a new instance of CallConnected. </summary>
        ///// <param name="callConnectionId"> Call connection ID. </param>
        ///// <param name="serverCallId"> Server call ID. </param>
        ///// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        ///// <param name="operationContext"> Used by customers to set the context for creating a new call. This property will be null for answering a call. </param>
        ///// /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        ///// <returns> A new <see cref="CallAutomation.ConnectFailed"/> instance for mocking. </returns>
        //public static ConnectFailed ConnectFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        //{
        //    return new ConnectFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        //}

        /// <summary> Initializes a new instance of CallDisconnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers to set the context for creating a new call. This property will be null for answering a call. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.CallConnected"/> instance for mocking. </returns>
        public static CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallDisconnected(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of CallTransferFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferFailed"/> instance for mocking. </returns>
        public static CallTransferFailed CallTransferFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallTransferFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionStopped. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionStopped"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionStopped ContinuousDtmfRecognitionStopped(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new ContinuousDtmfRecognitionStopped(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionToneFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionToneFailed"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionToneFailed ContinuousDtmfRecognitionToneFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, ResultInformation resultInformation = null, string operationContext = null)
        {
            return new ContinuousDtmfRecognitionToneFailed(callConnectionId, serverCallId, correlationId, resultInformation, operationContext);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionToneReceived. </summary>
        /// <param name="sequenceId"> The sequence id which can be used to determine if the same tone was played multiple times or if any tones were missed. </param>
        /// <param name="tone"></param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId or skype chain ID. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionToneReceived"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionToneReceived ContinuousDtmfRecognitionToneReceived(int? sequenceId = null, DtmfTone? tone = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, ResultInformation resultInformation = null, string operationContext = null)
        {
            return new ContinuousDtmfRecognitionToneReceived(sequenceId, tone, callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCompleted"/> instance for mocking. </returns>
        public static PlayCompleted PlayCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new PlayCompletedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new PlayCompleted(internalObject);
        }

        /// <summary> Initializes a new instance of PlayFailed. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="failedPlaySourceIndex"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayFailed"/> instance for mocking. </returns>
        public static PlayFailed PlayFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, int? failedPlaySourceIndex = null)
        {
            var internalObject = new PlayFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation, failedPlaySourceIndex);

            return new PlayFailed(internalObject);
        }

        /// <summary> Initializes a new instance of PlayStarted. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayStarted"/> instance for mocking. </returns>
        public static PlayStarted PlayStarted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayStarted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayPaused. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayPaused"/> instance for mocking. </returns>
        public static PlayPaused PlayPaused(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayPaused(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayResumed. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.PlayResumed"/> instance for mocking. </returns>
        public static PlayResumed PlayResumed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayResumed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayCanceled. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCanceled"/> instance for mocking. </returns>
        public static PlayCanceled PlayCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayCanceled(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of RecognizeCanceled. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeCanceled"/> instance for mocking. </returns>
        public static RecognizeCanceled RecognizeCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new RecognizeCanceled(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of RecognizeFailed. </summary>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="failedPlaySourceIndex"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeFailed"/> instance for mocking. </returns>
        public static RecognizeFailed RecognizeFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null, int? failedPlaySourceIndex = null)
        {
            var internalObject = new RecognizeFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation, failedPlaySourceIndex);

            return new RecognizeFailed(internalObject);
        }

        /// <summary> Initializes a new instance of RecordingStateChanged. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="recordingId"> The call recording id. </param>
        /// <param name="state"></param>
        /// <param name="startDateTime"> The time of the recording started. </param>
        /// <param name="recordingKind"></param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.RecordingStateChanged"/> instance for mocking. </returns>
        public static RecordingStateChanged RecordingStateChanged(string callConnectionId = null, string serverCallId = null, string correlationId = null, string recordingId = null, RecordingState state = default, DateTimeOffset? startDateTime = null, RecordingKind? recordingKind = null, ResultInformation resultInformation = null)
        {
            return new RecordingStateChanged(callConnectionId, serverCallId, correlationId, recordingId, state: state, startDateTime: startDateTime, recordingKind, resultInformation);
        }

        /// <summary> Initializes a new instance of RecordingStateResult. </summary>
        /// <param name="recordingId"></param>
        /// <param name="recordingState"></param>
        /// <param name="recordingKind"></param>
        /// <returns> A new <see cref="CallAutomation.RecordingStateResult"/> instance for mocking. </returns>
        public static RecordingStateResult RecordingStateResult(string recordingId = null, RecordingState? recordingState = null, RecordingKind? recordingKind = null)
        {
            return new RecordingStateResult(recordingId: recordingId, recordingState: recordingState, recordingKind: recordingKind);
        }

        /// <summary> Initializes a new instance of SendDtmfTonesCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfTonesCompleted"/> instance for mocking. </returns>
        public static SendDtmfTonesCompleted SendDtmfTonesCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesCompletedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesCompleted(internalObject);
        }

        /// <summary> Initializes a new instance of SendDtmfTonesFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfTonesFailed"/> instance for mocking. </returns>
        public static SendDtmfTonesFailed SendDtmfTonesFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new SendDtmfTonesFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new SendDtmfTonesFailed(internalObject);
        }

        /// <summary> Initializes a new instance of HoldAudioStarted. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.HoldAudioStarted"/> instance for mocking. </returns>
        public static HoldAudioStarted HoldAudioStarted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new HoldAudioStarted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of HoldAudioPaused. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.HoldAudioPaused"/> instance for mocking. </returns>
        public static HoldAudioPaused HoldAudioPaused(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new HoldAudioPaused(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of HoldAudioResumed. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.HoldAudioResumed"/> instance for mocking. </returns>
        public static HoldAudioResumed HoldAudioResumed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new HoldAudioResumed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of HoldAudioCompleted. </summary>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <returns> A new <see cref="CallAutomation.HoldAudioCompleted"/> instance for mocking. </returns>
        public static HoldAudioCompleted HoldAudioCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new HoldAudioCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of HoldFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.HoldFailed"/> instance for mocking. </returns>
        public static HoldFailed HoldFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            var internalObject = new HoldFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            return new HoldFailed(internalObject);
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
            var createdCallFailedInternal = new CreateCallFailedInternal(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
            return new CreateCallFailed(createdCallFailedInternal);
        }

        /// <summary> Initializes a new instance of IncomingCall. </summary>
        /// <param name="to"> The recipient of the call. </param>
        /// <param name="from"> The caller initiating the call.</param>
        /// <param name="callerDisplayName"> The display name of the caller. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="customContext"> Custom Sip and Voip Headers of call.</param>
        /// <param name="incomingCallContext"> The context of the incoming call. </param>
        /// <param name="onBehalfOfCallee"> The identifier of the user on whose behalf the call is received.</param>
        /// <param name="correlationId"> The correlation ID for tracking the event. </param>
        /// <returns>A new <see cref="CallAutomation.IncomingCall"/> instance for mocking. </returns>
        public static IncomingCall IncomingCall(CommunicationIdentifier to = null, CommunicationIdentifier @from = null, string callerDisplayName = null, string serverCallId = null,
            CustomCallingContext customContext = null, string incomingCallContext = null, CommunicationIdentifier onBehalfOfCallee = null, string correlationId = null)
        {
            var internalObject = new IncomingCallInternal(
                to == null ? null : CommunicationIdentifierSerializer.Serialize(to),
                @from == null ? null : CommunicationIdentifierSerializer.Serialize(@from),
                callerDisplayName,
                serverCallId,
                customContext == null ? null : new CustomCallingContextInternal(
                    customContext.VoipHeaders,
                    customContext.SipHeaders,
                    CustomCallContextHelpers.CreateTeamsPhoneCallDetailsInternal(customContext.TeamsPhoneCallDetails)),
                incomingCallContext,
                onBehalfOfCallee == null ? null : CommunicationIdentifierSerializer.Serialize(onBehalfOfCallee),
                correlationId
                );

            return new IncomingCall(internalObject);
        }
    }
}
