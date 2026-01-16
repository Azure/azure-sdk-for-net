// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Messaging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Events
{
    public class CallAutomationEventParserTests
    {
        [Test]
        public void EventParserShouldParseEventWithEventDataAndType()
        {
            // arrange
            var callConnectionId = Guid.NewGuid().ToString();
            var serverCallId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();
            var resultInformation = new ResultInformation(200, 0, "success");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            CallConnected @event = CallAutomationModelFactory.CallConnected(callConnectionId: callConnectionId, serverCallId: serverCallId, correlationId: correlationId);
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            CallAutomationEventBase callConnected = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallConnected");

            // assert
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
        }

        [Test]
        public void EventParserShouldParseEventWithCloudEvent()
        {
            // arrange
            var callConnectionId = Guid.NewGuid().ToString();
            var serverCallId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();

            JObject jsonEvent = new JObject();
            jsonEvent["callConnectionId"] = callConnectionId;
            jsonEvent["serverCallId"] = serverCallId;
            jsonEvent["correlationId"] = correlationId;

            var binaryEvent = BinaryData.FromString(jsonEvent.ToString());

            var cloudEvent = new CloudEvent("foo/source", "Microsoft.Communication.CallConnected", binaryEvent, "");

            // act
            CallAutomationEventBase callConnected = CallAutomationEventParser.Parse(cloudEvent);

            // assert
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
        }

        [Test]
        public void EventParserShouldParseEventWithBinaryData()
        {
            // arrange
            var callConnectionId = Guid.NewGuid().ToString();
            var serverCallId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();

            JObject jsonEvent = new JObject();
            jsonEvent["callConnectionId"] = callConnectionId;
            jsonEvent["serverCallId"] = serverCallId;
            jsonEvent["correlationId"] = correlationId;

            var binaryEvent = BinaryData.FromString(jsonEvent.ToString());

            var cloudEvent = new CloudEvent("foo/source", "Microsoft.Communication.CallConnected", binaryEvent, "");

            // act
            CallAutomationEventBase callConnected = CallAutomationEventParser.Parse(new BinaryData(cloudEvent));

            // assert
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
        }

        [Test]
        public void EventParserShouldParseEventsWithCloudEvents()
        {
            // arrange
            var callConnectionId1 = Guid.NewGuid().ToString();
            var serverCallId1 = Guid.NewGuid().ToString();
            var correlationId1 = Guid.NewGuid().ToString();

            JObject jsonEvent1 = new JObject();
            jsonEvent1["callConnectionId"] = callConnectionId1;
            jsonEvent1["serverCallId"] = serverCallId1;
            jsonEvent1["correlationId"] = correlationId1;
            var binaryEvent1 = BinaryData.FromString(jsonEvent1.ToString());

            var callConnectionId2 = Guid.NewGuid().ToString();
            var serverCallId2 = Guid.NewGuid().ToString();
            var correlationId2 = Guid.NewGuid().ToString();

            JObject jsonEvent2 = new JObject();
            jsonEvent2["callConnectionId"] = callConnectionId2;
            jsonEvent2["serverCallId"] = serverCallId2;
            jsonEvent2["correlationId"] = correlationId2;
            var binaryEvent2 = BinaryData.FromString(jsonEvent2.ToString());

            var cloudEvents = new CloudEvent[] {
                new CloudEvent("foo/source", "Microsoft.Communication.CallConnected", binaryEvent1, ""),
                new CloudEvent("foo/source", "Microsoft.Communication.CallDisconnected", binaryEvent2, "") };

            // act
            CallAutomationEventBase[] callAutomationEvents = CallAutomationEventParser.ParseMany(cloudEvents);

            // assert
            Assert.That(callAutomationEvents.Length, Is.EqualTo(2));
            Assert.That(callAutomationEvents[0].GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callAutomationEvents[0].CallConnectionId, Is.EqualTo(callConnectionId1));
            Assert.That(callAutomationEvents[0].ServerCallId, Is.EqualTo(serverCallId1));
            Assert.That(callAutomationEvents[0].CorrelationId, Is.EqualTo(correlationId1));
            Assert.That(callAutomationEvents[1].GetType(), Is.EqualTo(typeof(CallDisconnected)));
            Assert.That(callAutomationEvents[1].CallConnectionId, Is.EqualTo(callConnectionId2));
            Assert.That(callAutomationEvents[1].ServerCallId, Is.EqualTo(serverCallId2));
            Assert.That(callAutomationEvents[1].CorrelationId, Is.EqualTo(correlationId2));
        }

        [Test]
        public void EventParserShouldParseEventsWithBinaryData()
        {
            // arrange
            var callConnectionId1 = Guid.NewGuid().ToString();
            var serverCallId1 = Guid.NewGuid().ToString();
            var correlationId1 = Guid.NewGuid().ToString();

            JObject jsonEvent1 = new JObject();
            jsonEvent1["callConnectionId"] = callConnectionId1;
            jsonEvent1["serverCallId"] = serverCallId1;
            jsonEvent1["correlationId"] = correlationId1;
            var binaryEvent1 = BinaryData.FromString(jsonEvent1.ToString());

            var callConnectionId2 = Guid.NewGuid().ToString();
            var serverCallId2 = Guid.NewGuid().ToString();
            var correlationId2 = Guid.NewGuid().ToString();

            JObject jsonEvent2 = new JObject();
            jsonEvent2["callConnectionId"] = callConnectionId2;
            jsonEvent2["serverCallId"] = serverCallId2;
            jsonEvent2["correlationId"] = correlationId2;
            var binaryEvent2 = BinaryData.FromString(jsonEvent2.ToString());

            var cloudEvents = new CloudEvent[] {
                new CloudEvent("foo/source", "Microsoft.Communication.CallConnected", binaryEvent1, ""),
                new CloudEvent("foo/source", "Microsoft.Communication.CallDisconnected", binaryEvent2, "") };

            // act
            CallAutomationEventBase[] callAutomationEvents = CallAutomationEventParser.ParseMany(new BinaryData(cloudEvents));

            // assert
            Assert.That(callAutomationEvents.Length, Is.EqualTo(2));
            Assert.That(callAutomationEvents[0].GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callAutomationEvents[0].CallConnectionId, Is.EqualTo(callConnectionId1));
            Assert.That(callAutomationEvents[0].ServerCallId, Is.EqualTo(serverCallId1));
            Assert.That(callAutomationEvents[0].CorrelationId, Is.EqualTo(correlationId1));
            Assert.That(callAutomationEvents[1].GetType(), Is.EqualTo(typeof(CallDisconnected)));
            Assert.That(callAutomationEvents[1].CallConnectionId, Is.EqualTo(callConnectionId2));
            Assert.That(callAutomationEvents[1].ServerCallId, Is.EqualTo(serverCallId2));
            Assert.That(callAutomationEvents[1].CorrelationId, Is.EqualTo(correlationId2));
        }

        [Test]
        public void AddParticipantsFailedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var participant = new CommunicationUserIdentifier("8:acs:12345");
            var @event = CallAutomationModelFactory.AddParticipantFailed(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(403, 30, "result info message"), participant);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.AddParticipantFailed");

            // assert
            if (parsedEvent is AddParticipantFailed addParticipantsFailed)
            {
                Assert.That(addParticipantsFailed.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(addParticipantsFailed.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(addParticipantsFailed.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(addParticipantsFailed.OperationContext, Is.EqualTo(operationContext));
                Assert.That(addParticipantsFailed.ResultInformation?.Code, Is.EqualTo(403));
                Assert.That(addParticipantsFailed.Participant.RawId, Is.EqualTo("8:acs:12345"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void AddParticipantsSucceededEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var participant = new CommunicationUserIdentifier("8:acs:12345");
            var @event = CallAutomationModelFactory.AddParticipantSucceeded(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(200, 30, "result info message"), participant);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.AddParticipantSucceeded");

            // assert
            if (parsedEvent is AddParticipantSucceeded addParticipantsSucceeded)
            {
                Assert.That(addParticipantsSucceeded.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(addParticipantsSucceeded.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(addParticipantsSucceeded.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(addParticipantsSucceeded.OperationContext, Is.EqualTo(operationContext));
                Assert.That(addParticipantsSucceeded.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(addParticipantsSucceeded.Participant.RawId, Is.EqualTo("8:acs:12345"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CallConnectedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var @event = CallAutomationModelFactory.CallConnected(callConnectionId, serverCallId, correlationId);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallConnected");

            // assert
            if (parsedEvent is CallConnected calConnected)
            {
                Assert.That(calConnected.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(calConnected.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(calConnected.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(calConnected.OperationContext, Is.Null);
                Assert.That(calConnected.ResultInformation, Is.Null);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        //[Test]
        //public void ConnectFailedEventParsed_Test()
        //{
        //    // arrange
        //    var callConnectionId = "callConnectionId";
        //    var serverCallId = "serverCallId";
        //    var correlationId = "correlationId";
        //    var @event = CallAutomationModelFactory.ConnectFailed(callConnectionId, serverCallId, correlationId);
        //    JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        //    string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

        //    // act
        //    var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ConnectFailed");

        //    // assert
        //    if (parsedEvent is ConnectFailed connectFailed)
        //    {
        //        Assert.AreEqual(callConnectionId, connectFailed.CallConnectionId);
        //        Assert.AreEqual(serverCallId, connectFailed.ServerCallId);
        //        Assert.AreEqual(correlationId, connectFailed.CorrelationId);
        //        Assert.IsNull(connectFailed.OperationContext);
        //        Assert.IsNull(connectFailed.ResultInformation);
        //    }
        //    else
        //    {
        //        Assert.Fail("Event parsed wrongfully");
        //    }
        //}

        [Test]
        public void CallDisconnectedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var @event = CallAutomationModelFactory.CallDisconnected(callConnectionId, serverCallId, correlationId);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallDisconnected");

            // assert
            if (parsedEvent is CallDisconnected callDisconnected)
            {
                Assert.That(callDisconnected.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(callDisconnected.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(callDisconnected.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(callDisconnected.OperationContext, Is.Null);
                Assert.That(callDisconnected.ResultInformation, Is.Null);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CallTransferAcceptedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var @event = CallAutomationModelFactory.CallTransferAccepted(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(202, 30, "result info message"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallTransferAccepted");

            // assert
            if (parsedEvent is CallTransferAccepted callTransferAccepted)
            {
                Assert.That(callTransferAccepted.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(callTransferAccepted.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(callTransferAccepted.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(callTransferAccepted.OperationContext, Is.EqualTo(operationContext));
                Assert.That(callTransferAccepted.ResultInformation?.Code, Is.EqualTo(202));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CallTransferFailedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var @event = CallAutomationModelFactory.CallTransferFailed(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(403, 30, "result info message"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallTransferFailed");

            // assert
            if (parsedEvent is CallTransferFailed callTransferFailed)
            {
                Assert.That(callTransferFailed.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(callTransferFailed.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(callTransferFailed.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(callTransferFailed.OperationContext, Is.EqualTo(operationContext));
                Assert.That(callTransferFailed.ResultInformation?.Code, Is.EqualTo(403));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void ParticipantsUpdatedEventParsed_Test()
        {
            // arrange
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var participant1 = new CallParticipant(new CommunicationUserIdentifier("8:acs:12345"), false, false);
            var participant2 = new CallParticipant(new PhoneNumberIdentifier("+123456789"), false, true);
            var participants = new CallParticipant[] { participant1, participant2 };
            var @event = CallAutomationModelFactory.ParticipantsUpdated(callConnectionId, serverCallId, correlationId, participants);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ParticipantsUpdated");

            // assert
            if (parsedEvent is ParticipantsUpdated participantsUpdated)
            {
                Assert.That(participantsUpdated.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(participantsUpdated.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(participantsUpdated.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(participantsUpdated.OperationContext, Is.Null);
                Assert.That(participantsUpdated.ResultInformation, Is.Null);
                Assert.That(participantsUpdated.Participants.Count, Is.EqualTo(2));
                Assert.That(participantsUpdated.Participants[0].Identifier.RawId, Is.EqualTo("8:acs:12345"));
                Assert.That(participantsUpdated.Participants[0].IsMuted, Is.False);
                Assert.That(participantsUpdated.Participants[0].IsOnHold, Is.False);
                Assert.That(participantsUpdated.Participants[1].Identifier.RawId.EndsWith("123456789"), Is.True);
                Assert.That(participantsUpdated.Participants[1].IsMuted, Is.False);
                Assert.That(participantsUpdated.Participants[1].IsOnHold, Is.True);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RecordingStateChangedEventParsed_Test()
        {
            RecordingStateChanged @event = CallAutomationModelFactory.RecordingStateChanged(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                recordingId: "recordingId",
                state: RecordingState.Active,
                startDateTime: DateTimeOffset.UtcNow);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecordingStateChanged");
            if (parsedEvent is RecordingStateChanged recordingEvent)
            {
                Assert.That(recordingEvent.RecordingId, Is.EqualTo("recordingId"));
                Assert.That(recordingEvent.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recordingEvent.State, Is.EqualTo(RecordingState.Active));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void PlayCompletedEventParsed_Test()
        {
            PlayCompleted @event = CallAutomationModelFactory.PlayCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayCompleted");
            if (parsedEvent is PlayCompleted playCompleted)
            {
                Assert.That(playCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(playCompleted.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(playCompleted.ReasonCode, Is.EqualTo(MediaEventReasonCode.CompletedSuccessfully));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void PlayFailedEventParsed_Test()
        {
            PlayFailed @event = CallAutomationModelFactory.PlayFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8536, message: "Action failed, file could not be downloaded."));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayFailed");
            if (parsedEvent is PlayFailed playFailed)
            {
                Assert.That(playFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(playFailed.ResultInformation?.Code, Is.EqualTo(400));
                //Assert.AreEqual(MediaEventReasonCode.PlayDownloadFailed, playFailed.ResultInformation);
                Assert.That(playFailed.ResultInformation?.SubCode, Is.EqualTo(8536));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void PlayStartedEventParsed_Test()
        {
            PlayStarted @event = CallAutomationModelFactory.PlayStarted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayStarted");
            if (parsedEvent is PlayStarted playStarted)
            {
                Assert.That(playStarted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playStarted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(playStarted.ResultInformation?.Code, Is.EqualTo(200));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void PlayCanceledEventParsed_Test()
        {
            PlayCanceled @event = CallAutomationModelFactory.PlayCanceled(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayCanceled");
            if (parsedEvent is PlayCanceled playCancelled)
            {
                Assert.That(playCancelled.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playCancelled.ServerCallId, Is.EqualTo("serverCallId"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RecognizeCompletedWithDtmfEventParsed_Test()
        {
            DtmfResult dtmfResult = new DtmfResult(new DtmfTone[] { DtmfTone.Five, DtmfTone.Six, DtmfTone.Pound });
            RecognizeCompleted @event = CallAutomationModelFactory.RecognizeCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Dtmf,
                recognizeResult: dtmfResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            string jsonEvent = @event.Serialize();

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                var recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.That(recognizeResult is DtmfResult, Is.EqualTo(true));
                Assert.That(recognizeCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recognizeCompleted.ResultInformation?.Code, Is.EqualTo(200));
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    string toneResults = dtmfResultReturned.ConvertToString();
                    Assert.That(dtmfResultReturned.Tones.Count(), Is.Not.Zero);
                    Assert.That(dtmfResultReturned.Tones.First(), Is.EqualTo(DtmfTone.Five));
                    Assert.That(toneResults, Is.EqualTo("56#"));
                }
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void GetRecognizeResultFromRecognizeCompletedWithDtmf_Test()
        {
            DtmfResult dtmfResult = new DtmfResult(new DtmfTone[] { DtmfTone.Five });
            RecognizeCompleted @event = CallAutomationModelFactory.RecognizeCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Dtmf,
                recognizeResult: dtmfResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            string jsonEvent = @event.Serialize();

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                var recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.That(recognizeResult is DtmfResult, Is.EqualTo(true));
                Assert.That(recognizeCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recognizeCompleted.ResultInformation?.Code, Is.EqualTo(200));
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    Assert.That(dtmfResultReturned.Tones.Count(), Is.Not.Zero);
                    Assert.That(dtmfResultReturned.Tones.First(), Is.EqualTo(DtmfTone.Five));
                }
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RecognizeFailedEventParsed_Test()
        {
            RecognizeFailed @event = CallAutomationModelFactory.RecognizeFailed(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, initial silence timeout reached."),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeFailed");
            if (parsedEvent is RecognizeFailed recognizeFailed)
            {
                Assert.That(recognizeFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recognizeFailed.ResultInformation?.Code, Is.EqualTo(400));
                Assert.That(recognizeFailed.ResultInformation?.SubCode.ToString(), Is.EqualTo(MediaEventReasonCode.RecognizeInitialSilenceTimedOut.ToString()));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RecognizeCancelledEventParsed_Test()
        {
            RecognizeCanceled @event = CallAutomationModelFactory.RecognizeCanceled(
                operationContext: "operationContext",
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCanceled");
            if (parsedEvent is RecognizeCanceled recognizeCancelled)
            {
                Assert.That(recognizeCancelled.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeCancelled.ServerCallId, Is.EqualTo("serverCallId"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RemoveParticipantsSucceededEventParsed_Test()
        {
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var participant = new CommunicationUserIdentifier("8:acs:12345");
            var @event = CallAutomationModelFactory.RemoveParticipantSucceeded(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(200, 30, "result info message"), participant);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RemoveParticipantSucceeded");

            if (parsedEvent is RemoveParticipantSucceeded addParticipantsSucceeded)
            {
                Assert.That(addParticipantsSucceeded.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(addParticipantsSucceeded.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(addParticipantsSucceeded.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(addParticipantsSucceeded.OperationContext, Is.EqualTo(operationContext));
                Assert.That(addParticipantsSucceeded.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(addParticipantsSucceeded.Participant.RawId, Is.EqualTo("8:acs:12345"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RemoveParticipantsFailedEventParsed_Test()
        {
            var callConnectionId = "callConnectionId";
            var serverCallId = "serverCallId";
            var correlationId = "correlationId";
            var operationContext = "operation context";
            var participant = new CommunicationUserIdentifier("8:acs:12345");
            var @event = CallAutomationModelFactory.RemoveParticipantFailed(callConnectionId, serverCallId, correlationId, operationContext, new ResultInformation(200, 30, "result info message"), participant);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RemoveParticipantFailed");

            if (parsedEvent is RemoveParticipantFailed addParticipantsSucceeded)
            {
                Assert.That(addParticipantsSucceeded.CallConnectionId, Is.EqualTo(callConnectionId));
                Assert.That(addParticipantsSucceeded.ServerCallId, Is.EqualTo(serverCallId));
                Assert.That(addParticipantsSucceeded.CorrelationId, Is.EqualTo(correlationId));
                Assert.That(addParticipantsSucceeded.OperationContext, Is.EqualTo(operationContext));
                Assert.That(addParticipantsSucceeded.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(addParticipantsSucceeded.Participant.RawId, Is.EqualTo("8:acs:12345"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void ContinuousDtmfRecognitionToneReceivedEventParsed_Test()
        {
            ContinuousDtmfRecognitionToneReceived @event = CallAutomationModelFactory.ContinuousDtmfRecognitionToneReceived(
                tone: DtmfTone.A,
                sequenceId: 1,
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ContinuousDtmfRecognitionToneReceived");
            if (parsedEvent is ContinuousDtmfRecognitionToneReceived continuousDtmfRecognitionToneReceived)
            {
                Assert.That(continuousDtmfRecognitionToneReceived.Tone, Is.EqualTo(DtmfTone.A));
                Assert.That(continuousDtmfRecognitionToneReceived.SequenceId, Is.EqualTo(1));
                Assert.That(continuousDtmfRecognitionToneReceived.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(continuousDtmfRecognitionToneReceived.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(continuousDtmfRecognitionToneReceived.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(continuousDtmfRecognitionToneReceived.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(continuousDtmfRecognitionToneReceived.ResultInformation?.Code, Is.EqualTo(200));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void ContinuousDtmfRecognitionToneFailedEventParsed_Test()
        {
            ContinuousDtmfRecognitionToneFailed @event = CallAutomationModelFactory.ContinuousDtmfRecognitionToneFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, some error."));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ContinuousDtmfRecognitionToneFailed");
            if (parsedEvent is ContinuousDtmfRecognitionToneFailed continuousDtmfRecognitionToneFailed)
            {
                Assert.That(continuousDtmfRecognitionToneFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(continuousDtmfRecognitionToneFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(continuousDtmfRecognitionToneFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(continuousDtmfRecognitionToneFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(continuousDtmfRecognitionToneFailed.ResultInformation?.Code, Is.EqualTo(400));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void ContinuousDtmfRecognitionStoppedEventParsed_Test()
        {
            ContinuousDtmfRecognitionStopped @event = CallAutomationModelFactory.ContinuousDtmfRecognitionStopped(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ContinuousDtmfRecognitionStopped");
            if (parsedEvent is ContinuousDtmfRecognitionStopped continuousDtmfRecognitionStopped)
            {
                Assert.That(continuousDtmfRecognitionStopped.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(continuousDtmfRecognitionStopped.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(continuousDtmfRecognitionStopped.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(continuousDtmfRecognitionStopped.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(continuousDtmfRecognitionStopped.ResultInformation?.Code, Is.EqualTo(200));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void SendDtmfCompletedEventParsed_Test()
        {
            SendDtmfTonesCompleted @event = CallAutomationModelFactory.SendDtmfTonesCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.SendDtmfTonesCompleted");
            if (parsedEvent is SendDtmfTonesCompleted SendDtmfCompleted)
            {
                Assert.That(SendDtmfCompleted.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(SendDtmfCompleted.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(SendDtmfCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(SendDtmfCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(SendDtmfCompleted.ResultInformation?.Code, Is.EqualTo(200));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void SendDtmfFailedEventParsed_Test()
        {
            SendDtmfTonesFailed @event = CallAutomationModelFactory.SendDtmfTonesFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, some error."));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.SendDtmfTonesFailed");
            if (parsedEvent is SendDtmfTonesFailed sendDtmfFailed)
            {
                Assert.That(sendDtmfFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(sendDtmfFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(sendDtmfFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(sendDtmfFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(sendDtmfFailed.ResultInformation?.Code, Is.EqualTo(400));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CancelAddParticipantSucceededEventParsed_Test()
        {
            CancelAddParticipantSucceeded @event = CallAutomationModelFactory.CancelAddParticipantSucceeded(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                invitationId: "invitationId",
                operationContext: "operationContext");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CancelAddParticipantSucceeded");

            if (parsedEvent is CancelAddParticipantSucceeded CancelAddParticipantSucceeded)
            {
                Assert.That(CancelAddParticipantSucceeded.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(CancelAddParticipantSucceeded.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(CancelAddParticipantSucceeded.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(CancelAddParticipantSucceeded.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(CancelAddParticipantSucceeded.InvitationId, Is.EqualTo("invitationId"));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CancelAddParticipantFailedEventParsed_Test()
        {
            CancelAddParticipantFailed @event = CallAutomationModelFactory.CancelAddParticipantFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                invitationId: "invitationId",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, some error."),
                operationContext: "operationContext");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CancelAddParticipantFailed");

            if (parsedEvent is CancelAddParticipantFailed cancelAddParticipantFailed)
            {
                Assert.That(cancelAddParticipantFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(cancelAddParticipantFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(cancelAddParticipantFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(cancelAddParticipantFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(cancelAddParticipantFailed.InvitationId, Is.EqualTo("invitationId"));
                Assert.That(cancelAddParticipantFailed.ResultInformation?.Code, Is.EqualTo(400));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void CreateCallFailedEventParsed_Test()
        {
            CreateCallFailed @event = CallAutomationModelFactory.CreateCallFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, some error."),
                operationContext: "operationContext");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CreateCallFailed");
            if (parsedEvent is CreateCallFailed createCallFailed)
            {
                Assert.That(createCallFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(createCallFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(createCallFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(createCallFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(createCallFailed.ResultInformation?.Code, Is.EqualTo(400));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void TranscriptionStartedEventParsed_Test()
        {
            TranscriptionStarted @event = CallAutomationModelFactory.TranscriptionStarted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                transcriptionUpdate: new TranscriptionUpdate(TranscriptionStatus.TranscriptionStarted, TranscriptionStatusDetails.SubscriptionStarted));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.TranscriptionStarted");
            if (parsedEvent is TranscriptionStarted transcriptionStarted)
            {
                Assert.That(transcriptionStarted.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(transcriptionStarted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(transcriptionStarted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(transcriptionStarted.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(transcriptionStarted.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(transcriptionStarted.TranscriptionUpdate.TranscriptionStatus, Is.EqualTo(TranscriptionStatus.TranscriptionStarted));
                Assert.That(transcriptionStarted.TranscriptionUpdate.TranscriptionStatusDetails, Is.EqualTo(TranscriptionStatusDetails.SubscriptionStarted));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void TranscriptionUpdatedEventParsed_Test()
        {
            TranscriptionUpdated @event = CallAutomationModelFactory.TranscriptionUpdated(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                transcriptionUpdate: new TranscriptionUpdate(TranscriptionStatus.TranscriptionUpdated, TranscriptionStatusDetails.StreamConnectionReestablished));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.TranscriptionUpdated");
            if (parsedEvent is TranscriptionUpdated transcriptionUpdated)
            {
                Assert.That(transcriptionUpdated.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(transcriptionUpdated.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(transcriptionUpdated.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(transcriptionUpdated.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(transcriptionUpdated.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(transcriptionUpdated.TranscriptionUpdate.TranscriptionStatus, Is.EqualTo(TranscriptionStatus.TranscriptionUpdated));
                Assert.That(transcriptionUpdated.TranscriptionUpdate.TranscriptionStatusDetails, Is.EqualTo(TranscriptionStatusDetails.StreamConnectionReestablished));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void TranscriptionStoppedEventParsed_Test()
        {
            TranscriptionStopped @event = CallAutomationModelFactory.TranscriptionStopped(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                transcriptionUpdate: new TranscriptionUpdate(transcriptionStatus: TranscriptionStatus.TranscriptionStopped, transcriptionStatusDetails: TranscriptionStatusDetails.SubscriptionStopped));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.TranscriptionStopped");
            if (parsedEvent is TranscriptionStopped transcriptionStopped)
            {
                Assert.That(transcriptionStopped.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(transcriptionStopped.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(transcriptionStopped.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(transcriptionStopped.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(transcriptionStopped.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(transcriptionStopped.TranscriptionUpdate.TranscriptionStatus, Is.EqualTo(TranscriptionStatus.TranscriptionStopped));
                Assert.That(transcriptionStopped.TranscriptionUpdate.TranscriptionStatusDetails, Is.EqualTo(TranscriptionStatusDetails.SubscriptionStopped));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void TranscriptionFailedEventParsed_Test()
        {
            TranscriptionFailed @event = CallAutomationModelFactory.TranscriptionFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                transcriptionUpdate: new TranscriptionUpdate(transcriptionStatus: TranscriptionStatus.TranscriptionFailed, transcriptionStatusDetails: TranscriptionStatusDetails.UnspecifiedError));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.TranscriptionFailed");
            if (parsedEvent is TranscriptionFailed transcriptionFailed)
            {
                Assert.That(transcriptionFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(transcriptionFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(transcriptionFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(transcriptionFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(transcriptionFailed.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(transcriptionFailed.TranscriptionUpdate.TranscriptionStatus, Is.EqualTo(TranscriptionStatus.TranscriptionFailed));
                Assert.That(transcriptionFailed.TranscriptionUpdate.TranscriptionStatusDetails, Is.EqualTo(TranscriptionStatusDetails.UnspecifiedError));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void HoldFailedEventParsed_Test()
        {
            HoldFailed @event = CallAutomationModelFactory.HoldFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8536, message: "Action failed, file could not be downloaded."));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.HoldFailed");
            if (parsedEvent is HoldFailed holdFailed)
            {
                Assert.That(holdFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(holdFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(holdFailed.ResultInformation?.Code, Is.EqualTo(400));
                Assert.That(holdFailed.ReasonCode, Is.EqualTo(MediaEventReasonCode.PlayDownloadFailed));
                Assert.That(holdFailed.ReasonCode.GetReasonCodeValue(), Is.EqualTo(8536));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void MediaStreamingStartedEventParsed_Test()
        {
            MediaStreamingStarted @event = CallAutomationModelFactory.MediaStreamingStarted(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                mediaStreamingUpdate: new MediaStreamingUpdate("contentType", MediaStreamingStatus.MediaStreamingStarted, MediaStreamingStatusDetails.SubscriptionStarted),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.MediaStreamingStarted");
            if (parsedEvent is MediaStreamingStarted mediaStreamingStarted)
            {
                Assert.That(mediaStreamingStarted.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(mediaStreamingStarted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(mediaStreamingStarted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(mediaStreamingStarted.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(mediaStreamingStarted.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(mediaStreamingStarted.MediaStreamingUpdate.MediaStreamingStatus, Is.EqualTo(MediaStreamingStatus.MediaStreamingStarted));
                Assert.That(mediaStreamingStarted.MediaStreamingUpdate.MediaStreamingStatusDetails, Is.EqualTo(MediaStreamingStatusDetails.SubscriptionStarted));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void MediaStreamingStoppedEventParsed_Test()
        {
            MediaStreamingStopped @event = CallAutomationModelFactory.MediaStreamingStopped(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                mediaStreamingUpdate: new MediaStreamingUpdate("contentType", MediaStreamingStatus.MediaStreamingStarted, MediaStreamingStatusDetails.SubscriptionStarted),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.MediaStreamingStopped");
            if (parsedEvent is MediaStreamingStopped mediaStreamingStopped)
            {
                Assert.That(mediaStreamingStopped.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(mediaStreamingStopped.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(mediaStreamingStopped.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(mediaStreamingStopped.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(mediaStreamingStopped.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(mediaStreamingStopped.MediaStreamingUpdate.MediaStreamingStatus, Is.EqualTo(MediaStreamingStatus.MediaStreamingStarted));
                Assert.That(mediaStreamingStopped.MediaStreamingUpdate.MediaStreamingStatusDetails, Is.EqualTo(MediaStreamingStatusDetails.SubscriptionStarted));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void MediaStreamingFailedEventParsed_Test()
        {
            MediaStreamingFailed @event = CallAutomationModelFactory.MediaStreamingFailed(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"),
                mediaStreamingUpdate: new MediaStreamingUpdate("contentType", MediaStreamingStatus.MediaStreamingStarted, MediaStreamingStatusDetails.SubscriptionStarted),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.MediaStreamingFailed");
            if (parsedEvent is MediaStreamingFailed mediaStreamingFailed)
            {
                Assert.That(mediaStreamingFailed.CallConnectionId, Is.EqualTo("callConnectionId"));
                Assert.That(mediaStreamingFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(mediaStreamingFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(mediaStreamingFailed.OperationContext, Is.EqualTo("operationContext"));
                Assert.That(mediaStreamingFailed.ResultInformation?.Code, Is.EqualTo(200));
                Assert.That(mediaStreamingFailed.MediaStreamingUpdate.MediaStreamingStatus, Is.EqualTo(MediaStreamingStatus.MediaStreamingStarted));
                Assert.That(mediaStreamingFailed.MediaStreamingUpdate.MediaStreamingStatusDetails, Is.EqualTo(MediaStreamingStatusDetails.SubscriptionStarted));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
