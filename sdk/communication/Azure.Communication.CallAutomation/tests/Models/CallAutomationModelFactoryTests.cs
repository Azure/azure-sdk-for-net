// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.Models
{
    /// <summary>
    /// The suite of tests for the <see cref="CallAutomationModelFactory"/> class.
    /// </summary>
    public class CallAutomationModelFactoryTests : CallAutomationTestBase
    {
        private readonly DateTime _testTimestamp = new DateTime(2023, 10, 15, 14, 30, 0, DateTimeKind.Utc);
        private readonly PhoneNumberIdentifier _testPhoneNumber = new PhoneNumberIdentifier("+14255551234");
        private readonly CommunicationUserIdentifier _testUser = new CommunicationUserIdentifier("8:acs:test-user");
        private readonly Uri _testCallbackUri = new Uri("https://example.com/callback");

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAudioData()
        {
            var data = "SGVsbG8gV29ybGQ=";
            var timestamp = _testTimestamp;
            var participantId = "participant123";
            var silent = true;
            var mark = new MarkAudio
            {
                Id = "mark123",
            };

            var audioData = CallAutomationModelFactory.AudioData(data, timestamp, participantId, silent, mark);

            Assert.AreEqual(data, Convert.ToBase64String(audioData.Data.ToArray()));
            Assert.AreEqual(timestamp, audioData.Timestamp.DateTime);
            Assert.AreEqual(participantId, audioData.Participant.RawId);
            Assert.AreEqual(silent, audioData.IsSilent);
            Assert.AreEqual(mark.Id, audioData.Mark.Id);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAudioMetadata()
        {
            var mediaSubscriptionId = "subscription123";
            var encoding = "PCM";
            var sampleRate = 16000;
            var channels = 1;
            var length = 1000;

            var audioMetadata = CallAutomationModelFactory.AudioMetadata(mediaSubscriptionId, encoding, sampleRate, channels, length);

            Assert.AreEqual(mediaSubscriptionId, audioMetadata.MediaSubscriptionId);
            Assert.AreEqual(encoding, audioMetadata.Encoding);
            Assert.AreEqual(sampleRate, audioMetadata.SampleRate);
            Assert.AreEqual(AudioChannel.Mono, audioMetadata.Channels);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateTranscriptionData()
        {
            var text = "Hello World";
            var format = TextFormat.Display;
            var confidence = 0.95;
            ulong offset = 1000;
            ulong duration = 2000;
            var words = new List<WordData> { new WordData { Text = "Hello", Offset = 1000, Duration = 500 } };
            var participantRawID = "participant123";
            var resultState = ResultStatus.Final;

            var transcriptionData = CallAutomationModelFactory.TranscriptionData(text, format.ToString(), confidence, offset, duration, words, participantRawID, resultState.ToString());

            Assert.AreEqual(text, transcriptionData.Text);
            Assert.AreEqual(format, transcriptionData.Format);
            Assert.AreEqual(confidence, transcriptionData.Confidence);
            Assert.AreEqual(offset, transcriptionData.Offset);
            Assert.AreEqual(duration, transcriptionData.Duration);
            Assert.AreEqual(CommunicationIdentifier.FromRawId(participantRawID), transcriptionData.Participant);
            Assert.AreEqual(resultState, transcriptionData.ResultStatus);
            Assert.IsNotNull(transcriptionData.Words);
            Assert.AreEqual(1, transcriptionData.Words.Count());
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateOutStreamingData()
        {
            var kind = MediaKind.AudioData;

            var outStreamingData = CallAutomationModelFactory.OutStreamingData(kind);

            Assert.AreEqual(kind, outStreamingData.Kind);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAddParticipantResult()
        {
            var participant = CallAutomationModelFactory.CallParticipant(_testUser, true, false);
            var operationContext = "testContext";
            var invitationId = "invitation123";

            var result = CallAutomationModelFactory.AddParticipantsResult(participant, operationContext, invitationId);

            Assert.AreEqual(participant, result.Participant);
            Assert.AreEqual(operationContext, result.OperationContext);
            Assert.AreEqual(invitationId, result.InvitationId);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAnswerCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.AnswerCallResult(callConnection, callConnectionProperties);

            Assert.AreEqual(callConnection, result.CallConnection);
            Assert.AreEqual(callConnectionProperties, result.CallConnectionProperties);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallConnectionProperties()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var targets = new List<CommunicationIdentifier> { _testUser };
            var callConnectionState = CallConnectionState.Connected;
            var callbackUri = _testCallbackUri;
            var sourceIdentity = _testPhoneNumber;
            var sourceCallerIdNumber = _testPhoneNumber;
            var sourceDisplayName = "Test Display";
            var answeredBy = _testUser;

            var properties = CallAutomationModelFactory.CallConnectionProperties(
                callConnectionId, serverCallId, targets, callConnectionState, callbackUri,
                sourceIdentity, sourceCallerIdNumber, sourceDisplayName, answeredBy);

            Assert.AreEqual(callConnectionId, properties.CallConnectionId);
            Assert.AreEqual(serverCallId, properties.ServerCallId);
            Assert.AreNotSame(targets, properties.Targets);
            Assert.AreEqual(targets, properties.Targets);
            Assert.AreEqual(callConnectionState, properties.CallConnectionState);
            Assert.AreEqual(callbackUri, properties.CallbackUri);
            Assert.AreEqual(sourceIdentity, properties.Source);
            Assert.AreEqual(sourceCallerIdNumber, properties.SourceCallerIdNumber);
            Assert.AreEqual(sourceDisplayName, properties.SourceDisplayName);
            Assert.AreEqual(answeredBy, properties.AnsweredBy);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallParticipant()
        {
            var identifier = _testUser;
            var isMuted = true;
            var isOnHold = false;

            var participant = CallAutomationModelFactory.CallParticipant(identifier, isMuted, isOnHold);

            Assert.AreEqual(identifier, participant.Identifier);
            Assert.AreEqual(isMuted, participant.IsMuted);
            Assert.AreEqual(isOnHold, participant.IsOnHold);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCreateCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.CreateCallResult(callConnection, callConnectionProperties);

            Assert.AreEqual(callConnection, result.CallConnection);
            Assert.AreEqual(callConnectionProperties, result.CallConnectionProperties);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRemoveParticipantResult()
        {
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.RemoveParticipantResult(operationContext);

            Assert.AreEqual(operationContext, result.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCancelAddParticipantResult()
        {
            var invitationId = "invitation123";
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.CancelAddParticipantResult(invitationId, operationContext);

            Assert.AreEqual(invitationId, result.InvitationId);
            Assert.AreEqual(operationContext, result.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAddParticipantFailed()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");
            var participant = _testUser;

            var eventResult = CallAutomationModelFactory.AddParticipantFailed(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation, participant);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(participant, eventResult.Participant);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAddParticipantSucceeded()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");
            var participant = _testUser;

            var eventResult = CallAutomationModelFactory.AddParticipantSucceeded(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation, participant);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(participant, eventResult.Participant);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateParticipantsUpdated()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var participants = new List<CallParticipant>
            {
                CallAutomationModelFactory.CallParticipant(_testUser, false, false)
            };
            var sequenceNumber = 1;
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.ParticipantsUpdated(
                callConnectionId, serverCallId, correlationId, participants, sequenceNumber, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(sequenceNumber, eventResult.SequenceNumber);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.IsNotNull(eventResult.Participants);
            Assert.AreEqual(1, eventResult.Participants.Count());
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecognizeCompleted()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");
            var recognitionType = CallMediaRecognitionType.Dtmf;

            var eventResult = CallAutomationModelFactory.RecognizeCompleted(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation, recognitionType);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(recognitionType, eventResult.RecognitionType);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallTransferAccepted()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");
            var transferee = _testUser;
            var transferTarget = _testPhoneNumber;

            var eventResult = CallAutomationModelFactory.CallTransferAccepted(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation, transferee, transferTarget);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(transferee, eventResult.Transferee);
            Assert.AreEqual(transferTarget, eventResult.TransferTarget);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallConnected()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.CallConnected(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallDisconnected()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.CallDisconnected(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiatePlayCompleted()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.PlayCompleted(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiatePlayFailed()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(400, 1, "Failed");

            var eventResult = CallAutomationModelFactory.PlayFailed(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateContinuousDtmfRecognitionToneReceived()
        {
            var sequenceId = 1;
            var tone = DtmfTone.One;
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");
            var operationContext = "testContext";

            var eventResult = CallAutomationModelFactory.ContinuousDtmfRecognitionToneReceived(
                resultInformation, sequenceId, tone, operationContext, callConnectionId, serverCallId, correlationId);

            Assert.AreEqual(sequenceId, eventResult.SequenceId);
            Assert.AreEqual(tone, eventResult.Tone);
            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecordingStateChanged()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var recordingId = "recording123";
            var operationContext = "testContext";
            var state = RecordingState.Active;
            var startDateTime = DateTimeOffset.UtcNow;
            var recordingKind = RecordingKind.AzureCommunicationServices;
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.RecordingStateChanged(recordingId,
                state, startDateTime, recordingKind, operationContext, resultInformation, callConnectionId, serverCallId, correlationId);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(recordingId, eventResult.RecordingId);
            Assert.AreEqual(state, eventResult.State);
            Assert.AreEqual(startDateTime, eventResult.StartDateTime);
            Assert.AreEqual(recordingKind, eventResult.RecordingKind);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecordingStateResult()
        {
            var recordingId = "recording123";
            var recordingState = RecordingState.Active;
            var recordingKind = RecordingKind.AzureCommunicationServices;

            var result = CallAutomationModelFactory.RecordingStateResult(recordingId, recordingState, recordingKind);

            Assert.AreEqual(recordingId, result.RecordingId);
            Assert.AreEqual(recordingState, result.RecordingState);
            Assert.AreEqual(recordingKind, result.RecordingKind);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateSendDtmfTonesCompleted()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.SendDtmfTonesCompleted(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCreateCallFailed()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var resultInformation = CallAutomationModelFactory.ResultInformation(400, 1, "Failed");
            var operationContext = "testContext";

            var eventResult = CallAutomationModelFactory.CreateCallFailed(
                callConnectionId, serverCallId, correlationId, resultInformation, operationContext);

            Assert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            Assert.AreEqual(serverCallId, eventResult.ServerCallId);
            Assert.AreEqual(correlationId, eventResult.CorrelationId);
            Assert.AreEqual(resultInformation, eventResult.ResultInformation);
            Assert.AreEqual(operationContext, eventResult.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryHandlesNullCollections()
        {
            // Test that null collections are handled gracefully
            var properties = CallAutomationModelFactory.CallConnectionProperties(
                targets: null);

            Assert.IsNotNull(properties.Targets);
            Assert.AreEqual(0, properties.Targets.Count);
        }

        [Test]
        public void CallAutomationModelFactoryHandlesDefaultValues()
        {
            // Test that default parameter values work correctly
            var participant = CallAutomationModelFactory.CallParticipant();

            Assert.IsNull(participant.Identifier);
            Assert.IsFalse(participant.IsMuted);
            Assert.IsFalse(participant.IsOnHold);
        }

        [Test]
        public void CallAutomationModelFactoryCreatesImmutableCollections()
        {
            // Test that collections in factory methods are properly copied
            var originalTargets = new List<CommunicationIdentifier> { _testUser };
            var properties = CallAutomationModelFactory.CallConnectionProperties(targets: originalTargets);

            Assert.AreNotSame(originalTargets, properties.Targets);
            Assert.AreEqual(originalTargets, properties.Targets);

            // Modifying original should not affect the created instance
            originalTargets.Add(_testPhoneNumber);
            Assert.AreEqual(1, properties.Targets.Count);
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }
    }
}
