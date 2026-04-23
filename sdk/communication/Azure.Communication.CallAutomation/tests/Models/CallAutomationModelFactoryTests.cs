// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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

            var audioData = CallAutomationModelFactory.AudioData(data, timestamp, participantId, silent);

            ClassicAssert.AreEqual(data, Convert.ToBase64String(audioData.Data.ToArray()));
            ClassicAssert.AreEqual(timestamp, audioData.Timestamp.DateTime);
            ClassicAssert.AreEqual(participantId, audioData.Participant.RawId);
            ClassicAssert.AreEqual(silent, audioData.IsSilent);
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

            ClassicAssert.AreEqual(mediaSubscriptionId, audioMetadata.MediaSubscriptionId);
            ClassicAssert.AreEqual(encoding, audioMetadata.Encoding);
            ClassicAssert.AreEqual(sampleRate, audioMetadata.SampleRate);
            ClassicAssert.AreEqual(AudioChannel.Mono, audioMetadata.Channels);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateTranscriptionData()
        {
            var text = "Hello World";
            var format = "display";
            var confidence = 0.95;
            var offset = 1000L;
            var duration = 2000L;
            var words = new List<WordData> { CallAutomationModelFactory.WordData("Hello", 1000, 500) };
            var participantRawID = "participant123";
            var resultState = TranscriptionResultState.Final;

            var transcriptionData = CallAutomationModelFactory.TranscriptionData(text, format, confidence, offset, duration, words, participantRawID, resultState);

            ClassicAssert.AreEqual(text, transcriptionData.Text);
            ClassicAssert.AreEqual(format, transcriptionData.Format);
            ClassicAssert.AreEqual(confidence, transcriptionData.Confidence);
            ClassicAssert.AreEqual(TimeSpan.FromTicks(offset), transcriptionData.Offset);
            ClassicAssert.AreEqual(TimeSpan.FromTicks(duration), transcriptionData.Duration);
            ClassicAssert.AreEqual(CommunicationIdentifier.FromRawId(participantRawID), transcriptionData.Participant);
            ClassicAssert.AreEqual(resultState, transcriptionData.ResultState);
            ClassicAssert.IsNotNull(transcriptionData.Words);
            ClassicAssert.AreEqual(1, transcriptionData.Words.Count());
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateWordData()
        {
            var text = "Hello";
            var offset = 1000L;
            var duration = 500L;

            var wordData = CallAutomationModelFactory.WordData(text, offset, duration);

            ClassicAssert.AreEqual(text, wordData.Text);
            ClassicAssert.AreEqual(TimeSpan.FromTicks(offset), wordData.Offset);
            ClassicAssert.AreEqual(TimeSpan.FromTicks(duration), wordData.Duration);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateOutStreamingData()
        {
            var kind = MediaKind.AudioData;

            var outStreamingData = CallAutomationModelFactory.OutStreamingData(kind);

            ClassicAssert.AreEqual(kind, outStreamingData.Kind);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAddParticipantResult()
        {
            var participant = CallAutomationModelFactory.CallParticipant(_testUser, true, false);
            var operationContext = "testContext";
            var invitationId = "invitation123";

            var result = CallAutomationModelFactory.AddParticipantsResult(participant, operationContext, invitationId);

            ClassicAssert.AreEqual(participant, result.Participant);
            ClassicAssert.AreEqual(operationContext, result.OperationContext);
            ClassicAssert.AreEqual(invitationId, result.InvitationId);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAnswerCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.AnswerCallResult(callConnection, callConnectionProperties);

            ClassicAssert.AreEqual(callConnection, result.CallConnection);
            ClassicAssert.AreEqual(callConnectionProperties, result.CallConnectionProperties);
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

            ClassicAssert.AreEqual(callConnectionId, properties.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, properties.ServerCallId);
            ClassicAssert.AreNotSame(targets, properties.Targets);
            ClassicAssert.AreEqual(targets, properties.Targets);
            ClassicAssert.AreEqual(callConnectionState, properties.CallConnectionState);
            ClassicAssert.AreEqual(callbackUri, properties.CallbackUri);
            ClassicAssert.AreEqual(sourceIdentity, properties.Source);
            ClassicAssert.AreEqual(sourceCallerIdNumber, properties.SourceCallerIdNumber);
            ClassicAssert.AreEqual(sourceDisplayName, properties.SourceDisplayName);
            ClassicAssert.AreEqual(answeredBy, properties.AnsweredBy);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallParticipant()
        {
            var identifier = _testUser;
            var isMuted = true;
            var isOnHold = false;

            var participant = CallAutomationModelFactory.CallParticipant(identifier, isMuted, isOnHold);

            ClassicAssert.AreEqual(identifier, participant.Identifier);
            ClassicAssert.AreEqual(isMuted, participant.IsMuted);
            ClassicAssert.AreEqual(isOnHold, participant.IsOnHold);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCreateCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.CreateCallResult(callConnection, callConnectionProperties);

            ClassicAssert.AreEqual(callConnection, result.CallConnection);
            ClassicAssert.AreEqual(callConnectionProperties, result.CallConnectionProperties);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRemoveParticipantResult()
        {
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.RemoveParticipantResult(operationContext);

            ClassicAssert.AreEqual(operationContext, result.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCancelAddParticipantResult()
        {
            var invitationId = "invitation123";
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.CancelAddParticipantResult(invitationId, operationContext);

            ClassicAssert.AreEqual(invitationId, result.InvitationId);
            ClassicAssert.AreEqual(operationContext, result.OperationContext);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(participant, eventResult.Participant);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(participant, eventResult.Participant);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(sequenceNumber, eventResult.SequenceNumber);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.IsNotNull(eventResult.Participants);
            ClassicAssert.AreEqual(1, eventResult.Participants.Count());
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(recognitionType, eventResult.RecognitionType);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(transferee, eventResult.Transferee);
            ClassicAssert.AreEqual(transferTarget, eventResult.TransferTarget);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiatePlayFailed()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var operationContext = "testContext";
            var resultInformation = CallAutomationModelFactory.ResultInformation(400, 1, "Failed");
            var failedPlaySourceIndex = 0;

            var eventResult = CallAutomationModelFactory.PlayFailed(
                callConnectionId, serverCallId, correlationId, operationContext, resultInformation, failedPlaySourceIndex);

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(failedPlaySourceIndex, eventResult.FailedPlaySourceIndex);
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
                sequenceId, tone, callConnectionId, serverCallId, correlationId, resultInformation, operationContext);

            ClassicAssert.AreEqual(sequenceId, eventResult.SequenceId);
            ClassicAssert.AreEqual(tone, eventResult.Tone);
            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecordingStateChanged()
        {
            var callConnectionId = "connection123";
            var serverCallId = "server123";
            var correlationId = "correlation123";
            var recordingId = "recording123";
            var state = RecordingState.Active;
            var startDateTime = DateTimeOffset.UtcNow;
            var recordingKind = RecordingKind.AzureCommunicationServices;
            var resultInformation = CallAutomationModelFactory.ResultInformation(200, 0, "Success");

            var eventResult = CallAutomationModelFactory.RecordingStateChanged(
                callConnectionId, serverCallId, correlationId, recordingId, state, startDateTime, recordingKind, resultInformation);

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(recordingId, eventResult.RecordingId);
            ClassicAssert.AreEqual(state, eventResult.State);
            ClassicAssert.AreEqual(startDateTime, eventResult.StartDateTime);
            ClassicAssert.AreEqual(recordingKind, eventResult.RecordingKind);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecordingStateResult()
        {
            var recordingId = "recording123";
            var recordingState = RecordingState.Active;
            var recordingKind = RecordingKind.AzureCommunicationServices;

            var result = CallAutomationModelFactory.RecordingStateResult(recordingId, recordingState, recordingKind);

            ClassicAssert.AreEqual(recordingId, result.RecordingId);
            ClassicAssert.AreEqual(recordingState, result.RecordingState);
            ClassicAssert.AreEqual(recordingKind, result.RecordingKind);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
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

            ClassicAssert.AreEqual(callConnectionId, eventResult.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, eventResult.ServerCallId);
            ClassicAssert.AreEqual(correlationId, eventResult.CorrelationId);
            ClassicAssert.AreEqual(resultInformation, eventResult.ResultInformation);
            ClassicAssert.AreEqual(operationContext, eventResult.OperationContext);
        }

        [Test]
        public void CallAutomationModelFactoryHandlesNullCollections()
        {
            // Test that null collections are handled gracefully
            var properties = CallAutomationModelFactory.CallConnectionProperties(
                targets: null);

            ClassicAssert.IsNotNull(properties.Targets);
            ClassicAssert.AreEqual(0, properties.Targets.Count);
        }

        [Test]
        public void CallAutomationModelFactoryHandlesDefaultValues()
        {
            // Test that default parameter values work correctly
            var participant = CallAutomationModelFactory.CallParticipant();

            ClassicAssert.IsNull(participant.Identifier);
            ClassicAssert.IsFalse(participant.IsMuted);
            ClassicAssert.IsFalse(participant.IsOnHold);
        }

        [Test]
        public void CallAutomationModelFactoryCreatesImmutableCollections()
        {
            // Test that collections in factory methods are properly copied
            var originalTargets = new List<CommunicationIdentifier> { _testUser };
            var properties = CallAutomationModelFactory.CallConnectionProperties(targets: originalTargets);

            ClassicAssert.AreNotSame(originalTargets, properties.Targets);
            ClassicAssert.AreEqual(originalTargets, properties.Targets);

            // Modifying original should not affect the created instance
            originalTargets.Add(_testPhoneNumber);
            ClassicAssert.AreEqual(1, properties.Targets.Count);
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }
    }
}
