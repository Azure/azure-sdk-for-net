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

            var audioData = CallAutomationModelFactory.AudioData(data, timestamp, participantId, silent);

            Assert.Multiple(() =>
            {
                Assert.That(Convert.ToBase64String(audioData.Data.ToArray()), Is.EqualTo(data));
                Assert.That(audioData.Timestamp.DateTime, Is.EqualTo(timestamp));
                Assert.That(audioData.Participant.RawId, Is.EqualTo(participantId));
                Assert.That(audioData.IsSilent, Is.EqualTo(silent));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(audioMetadata.MediaSubscriptionId, Is.EqualTo(mediaSubscriptionId));
                Assert.That(audioMetadata.Encoding, Is.EqualTo(encoding));
                Assert.That(audioMetadata.SampleRate, Is.EqualTo(sampleRate));
                Assert.That(audioMetadata.Channels, Is.EqualTo(AudioChannel.Mono));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(transcriptionData.Text, Is.EqualTo(text));
                Assert.That(transcriptionData.Format, Is.EqualTo(format));
                Assert.That(transcriptionData.Confidence, Is.EqualTo(confidence));
                Assert.That(transcriptionData.Offset, Is.EqualTo(TimeSpan.FromTicks(offset)));
                Assert.That(transcriptionData.Duration, Is.EqualTo(TimeSpan.FromTicks(duration)));
                Assert.That(transcriptionData.Participant, Is.EqualTo(CommunicationIdentifier.FromRawId(participantRawID)));
                Assert.That(transcriptionData.ResultState, Is.EqualTo(resultState));
                Assert.That(transcriptionData.Words, Is.Not.Null);
            });
            Assert.That(transcriptionData.Words.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateWordData()
        {
            var text = "Hello";
            var offset = 1000L;
            var duration = 500L;

            var wordData = CallAutomationModelFactory.WordData(text, offset, duration);

            Assert.Multiple(() =>
            {
                Assert.That(wordData.Text, Is.EqualTo(text));
                Assert.That(wordData.Offset, Is.EqualTo(TimeSpan.FromTicks(offset)));
                Assert.That(wordData.Duration, Is.EqualTo(TimeSpan.FromTicks(duration)));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateOutStreamingData()
        {
            var kind = MediaKind.AudioData;

            var outStreamingData = CallAutomationModelFactory.OutStreamingData(kind);

            Assert.That(outStreamingData.Kind, Is.EqualTo(kind));
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAddParticipantResult()
        {
            var participant = CallAutomationModelFactory.CallParticipant(_testUser, true, false);
            var operationContext = "testContext";
            var invitationId = "invitation123";

            var result = CallAutomationModelFactory.AddParticipantsResult(participant, operationContext, invitationId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Participant, Is.EqualTo(participant));
                Assert.That(result.OperationContext, Is.EqualTo(operationContext));
                Assert.That(result.InvitationId, Is.EqualTo(invitationId));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateAnswerCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.AnswerCallResult(callConnection, callConnectionProperties);

            Assert.Multiple(() =>
            {
                Assert.That(result.CallConnection, Is.EqualTo(callConnection));
                Assert.That(result.CallConnectionProperties, Is.EqualTo(callConnectionProperties));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(properties.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(properties.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(properties.Targets, Is.Not.SameAs(targets));
            });
            Assert.Multiple(() =>
            {
                Assert.That(properties.Targets, Is.EqualTo(targets));
                Assert.That(properties.CallConnectionState, Is.EqualTo(callConnectionState));
                Assert.That(properties.CallbackUri, Is.EqualTo(callbackUri));
                Assert.That(properties.Source, Is.EqualTo(sourceIdentity));
                Assert.That(properties.SourceCallerIdNumber, Is.EqualTo(sourceCallerIdNumber));
                Assert.That(properties.SourceDisplayName, Is.EqualTo(sourceDisplayName));
                Assert.That(properties.AnsweredBy, Is.EqualTo(answeredBy));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCallParticipant()
        {
            var identifier = _testUser;
            var isMuted = true;
            var isOnHold = false;

            var participant = CallAutomationModelFactory.CallParticipant(identifier, isMuted, isOnHold);

            Assert.Multiple(() =>
            {
                Assert.That(participant.Identifier, Is.EqualTo(identifier));
                Assert.That(participant.IsMuted, Is.EqualTo(isMuted));
                Assert.That(participant.IsOnHold, Is.EqualTo(isOnHold));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCreateCallResult()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            var callConnectionProperties = CallAutomationModelFactory.CallConnectionProperties(
                "connection123", "server123", new[] { _testUser },
                CallConnectionState.Connected, _testCallbackUri);

            var result = CallAutomationModelFactory.CreateCallResult(callConnection, callConnectionProperties);

            Assert.Multiple(() =>
            {
                Assert.That(result.CallConnection, Is.EqualTo(callConnection));
                Assert.That(result.CallConnectionProperties, Is.EqualTo(callConnectionProperties));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRemoveParticipantResult()
        {
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.RemoveParticipantResult(operationContext);

            Assert.That(result.OperationContext, Is.EqualTo(operationContext));
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateCancelAddParticipantResult()
        {
            var invitationId = "invitation123";
            var operationContext = "testContext";

            var result = CallAutomationModelFactory.CancelAddParticipantResult(invitationId, operationContext);

            Assert.Multiple(() =>
            {
                Assert.That(result.InvitationId, Is.EqualTo(invitationId));
                Assert.That(result.OperationContext, Is.EqualTo(operationContext));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.Participant, Is.EqualTo(participant));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.Participant, Is.EqualTo(participant));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.SequenceNumber, Is.EqualTo(sequenceNumber));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.Participants, Is.Not.Null);
            });
            Assert.That(eventResult.Participants.Count(), Is.EqualTo(1));
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.RecognitionType, Is.EqualTo(recognitionType));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.Transferee, Is.EqualTo(transferee));
                Assert.That(eventResult.TransferTarget, Is.EqualTo(transferTarget));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.FailedPlaySourceIndex, Is.EqualTo(failedPlaySourceIndex));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.SequenceId, Is.EqualTo(sequenceId));
                Assert.That(eventResult.Tone, Is.EqualTo(tone));
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.RecordingId, Is.EqualTo(recordingId));
                Assert.That(eventResult.State, Is.EqualTo(state));
                Assert.That(eventResult.StartDateTime, Is.EqualTo(startDateTime));
                Assert.That(eventResult.RecordingKind, Is.EqualTo(recordingKind));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
            });
        }

        [Test]
        public void CallAutomationModelFactoryCanInstantiateRecordingStateResult()
        {
            var recordingId = "recording123";
            var recordingState = RecordingState.Active;
            var recordingKind = RecordingKind.AzureCommunicationServices;

            var result = CallAutomationModelFactory.RecordingStateResult(recordingId, recordingState, recordingKind);

            Assert.Multiple(() =>
            {
                Assert.That(result.RecordingId, Is.EqualTo(recordingId));
                Assert.That(result.RecordingState, Is.EqualTo(recordingState));
                Assert.That(result.RecordingKind, Is.EqualTo(recordingKind));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(eventResult.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(eventResult.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(eventResult.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(eventResult.ResultInformation, Is.EqualTo(resultInformation));
                Assert.That(eventResult.OperationContext, Is.EqualTo(operationContext));
            });
        }

        [Test]
        public void CallAutomationModelFactoryHandlesNullCollections()
        {
            // Test that null collections are handled gracefully
            var properties = CallAutomationModelFactory.CallConnectionProperties(
                targets: null);

            Assert.That(properties.Targets, Is.Not.Null);
            Assert.That(properties.Targets.Count, Is.EqualTo(0));
        }

        [Test]
        public void CallAutomationModelFactoryHandlesDefaultValues()
        {
            // Test that default parameter values work correctly
            var participant = CallAutomationModelFactory.CallParticipant();

            Assert.Multiple(() =>
            {
                Assert.That(participant.Identifier, Is.Null);
                Assert.That(participant.IsMuted, Is.False);
                Assert.That(participant.IsOnHold, Is.False);
            });
        }

        [Test]
        public void CallAutomationModelFactoryCreatesImmutableCollections()
        {
            // Test that collections in factory methods are properly copied
            var originalTargets = new List<CommunicationIdentifier> { _testUser };
            var properties = CallAutomationModelFactory.CallConnectionProperties(targets: originalTargets);

            Assert.That(properties.Targets, Is.Not.SameAs(originalTargets));
            Assert.That(properties.Targets, Is.EqualTo(originalTargets));

            // Modifying original should not affect the created instance
            originalTargets.Add(_testPhoneNumber);
            Assert.That(properties.Targets.Count, Is.EqualTo(1));
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }
    }
}
