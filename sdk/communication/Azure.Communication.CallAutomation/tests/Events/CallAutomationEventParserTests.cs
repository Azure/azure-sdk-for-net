// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Messaging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            ClassicAssert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, callConnected.ServerCallId);
            ClassicAssert.AreEqual(correlationId, callConnected.CorrelationId);
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
            ClassicAssert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            ClassicAssert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, callConnected.ServerCallId);
            ClassicAssert.AreEqual(correlationId, callConnected.CorrelationId);
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
            ClassicAssert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            ClassicAssert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            ClassicAssert.AreEqual(serverCallId, callConnected.ServerCallId);
            ClassicAssert.AreEqual(correlationId, callConnected.CorrelationId);
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
            ClassicAssert.AreEqual(2, callAutomationEvents.Length);
            ClassicAssert.AreEqual(callAutomationEvents[0].GetType(), typeof(CallConnected));
            ClassicAssert.AreEqual(callConnectionId1, callAutomationEvents[0].CallConnectionId);
            ClassicAssert.AreEqual(serverCallId1, callAutomationEvents[0].ServerCallId);
            ClassicAssert.AreEqual(correlationId1, callAutomationEvents[0].CorrelationId);
            ClassicAssert.AreEqual(callAutomationEvents[1].GetType(), typeof(CallDisconnected));
            ClassicAssert.AreEqual(callConnectionId2, callAutomationEvents[1].CallConnectionId);
            ClassicAssert.AreEqual(serverCallId2, callAutomationEvents[1].ServerCallId);
            ClassicAssert.AreEqual(correlationId2, callAutomationEvents[1].CorrelationId);
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
            ClassicAssert.AreEqual(2, callAutomationEvents.Length);
            ClassicAssert.AreEqual(callAutomationEvents[0].GetType(), typeof(CallConnected));
            ClassicAssert.AreEqual(callConnectionId1, callAutomationEvents[0].CallConnectionId);
            ClassicAssert.AreEqual(serverCallId1, callAutomationEvents[0].ServerCallId);
            ClassicAssert.AreEqual(correlationId1, callAutomationEvents[0].CorrelationId);
            ClassicAssert.AreEqual(callAutomationEvents[1].GetType(), typeof(CallDisconnected));
            ClassicAssert.AreEqual(callConnectionId2, callAutomationEvents[1].CallConnectionId);
            ClassicAssert.AreEqual(serverCallId2, callAutomationEvents[1].ServerCallId);
            ClassicAssert.AreEqual(correlationId2, callAutomationEvents[1].CorrelationId);
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
                ClassicAssert.AreEqual(callConnectionId, addParticipantsFailed.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, addParticipantsFailed.ServerCallId);
                ClassicAssert.AreEqual(correlationId, addParticipantsFailed.CorrelationId);
                ClassicAssert.AreEqual(operationContext, addParticipantsFailed.OperationContext);
                ClassicAssert.AreEqual(403, addParticipantsFailed.ResultInformation?.Code);
                ClassicAssert.AreEqual("8:acs:12345", addParticipantsFailed.Participant.RawId);
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
                ClassicAssert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                ClassicAssert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                ClassicAssert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                ClassicAssert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                ClassicAssert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                ClassicAssert.AreEqual(callConnectionId, calConnected.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, calConnected.ServerCallId);
                ClassicAssert.AreEqual(correlationId, calConnected.CorrelationId);
                ClassicAssert.IsNull(calConnected.OperationContext);
                ClassicAssert.IsNull(calConnected.ResultInformation);
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
        //        ClassicAssert.AreEqual(callConnectionId, connectFailed.CallConnectionId);
        //        ClassicAssert.AreEqual(serverCallId, connectFailed.ServerCallId);
        //        ClassicAssert.AreEqual(correlationId, connectFailed.CorrelationId);
        //        ClassicAssert.IsNull(connectFailed.OperationContext);
        //        ClassicAssert.IsNull(connectFailed.ResultInformation);
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
                ClassicAssert.AreEqual(callConnectionId, callDisconnected.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, callDisconnected.ServerCallId);
                ClassicAssert.AreEqual(correlationId, callDisconnected.CorrelationId);
                ClassicAssert.IsNull(callDisconnected.OperationContext);
                ClassicAssert.IsNull(callDisconnected.ResultInformation);
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
                ClassicAssert.AreEqual(callConnectionId, callTransferAccepted.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, callTransferAccepted.ServerCallId);
                ClassicAssert.AreEqual(correlationId, callTransferAccepted.CorrelationId);
                ClassicAssert.AreEqual(operationContext, callTransferAccepted.OperationContext);
                ClassicAssert.AreEqual(202, callTransferAccepted.ResultInformation?.Code);
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
                ClassicAssert.AreEqual(callConnectionId, callTransferFailed.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, callTransferFailed.ServerCallId);
                ClassicAssert.AreEqual(correlationId, callTransferFailed.CorrelationId);
                ClassicAssert.AreEqual(operationContext, callTransferFailed.OperationContext);
                ClassicAssert.AreEqual(403, callTransferFailed.ResultInformation?.Code);
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
                ClassicAssert.AreEqual(callConnectionId, participantsUpdated.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, participantsUpdated.ServerCallId);
                ClassicAssert.AreEqual(correlationId, participantsUpdated.CorrelationId);
                ClassicAssert.IsNull(participantsUpdated.OperationContext);
                ClassicAssert.IsNull(participantsUpdated.ResultInformation);
                ClassicAssert.AreEqual(2, participantsUpdated.Participants.Count);
                ClassicAssert.AreEqual("8:acs:12345", participantsUpdated.Participants[0].Identifier.RawId);
                ClassicAssert.IsFalse(participantsUpdated.Participants[0].IsMuted);
                ClassicAssert.IsFalse(participantsUpdated.Participants[0].IsOnHold);
                ClassicAssert.IsTrue(participantsUpdated.Participants[1].Identifier.RawId.EndsWith("123456789"));
                ClassicAssert.IsFalse(participantsUpdated.Participants[1].IsMuted);
                ClassicAssert.IsTrue(participantsUpdated.Participants[1].IsOnHold);
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
                ClassicAssert.AreEqual("recordingId", recordingEvent.RecordingId);
                ClassicAssert.AreEqual("serverCallId", recordingEvent.ServerCallId);
                ClassicAssert.AreEqual(RecordingState.Active, recordingEvent.State);
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
                ClassicAssert.AreEqual("correlationId", playCompleted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", playCompleted.ServerCallId);
                ClassicAssert.AreEqual(200, playCompleted.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaEventReasonCode.CompletedSuccessfully, playCompleted.ReasonCode);
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
                ClassicAssert.AreEqual("correlationId", playFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", playFailed.ServerCallId);
                ClassicAssert.AreEqual(400, playFailed.ResultInformation?.Code);
                //ClassicAssert.AreEqual(MediaEventReasonCode.PlayDownloadFailed, playFailed.ResultInformation);
                ClassicAssert.AreEqual(8536, playFailed.ResultInformation?.SubCode);
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
                ClassicAssert.AreEqual("correlationId", playStarted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", playStarted.ServerCallId);
                ClassicAssert.AreEqual(200, playStarted.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("correlationId", playCancelled.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", playCancelled.ServerCallId);
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
                ClassicAssert.AreEqual(recognizeResult is DtmfResult, true);
                ClassicAssert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                ClassicAssert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    string toneResults = dtmfResultReturned.ConvertToString();
                    ClassicAssert.NotZero(dtmfResultReturned.Tones.Count());
                    ClassicAssert.AreEqual(DtmfTone.Five, dtmfResultReturned.Tones.First());
                    ClassicAssert.AreEqual(toneResults, "56#");
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
                ClassicAssert.AreEqual(recognizeResult is DtmfResult, true);
                ClassicAssert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                ClassicAssert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    ClassicAssert.NotZero(dtmfResultReturned.Tones.Count());
                    ClassicAssert.AreEqual(DtmfTone.Five, dtmfResultReturned.Tones.First());
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
                ClassicAssert.AreEqual("correlationId", recognizeFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", recognizeFailed.ServerCallId);
                ClassicAssert.AreEqual(400, recognizeFailed.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaEventReasonCode.RecognizeInitialSilenceTimedOut.ToString(), recognizeFailed.ResultInformation?.SubCode.ToString());
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
                ClassicAssert.AreEqual("correlationId", recognizeCancelled.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", recognizeCancelled.ServerCallId);
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
                ClassicAssert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                ClassicAssert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                ClassicAssert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                ClassicAssert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                ClassicAssert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                ClassicAssert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                ClassicAssert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                ClassicAssert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                ClassicAssert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                ClassicAssert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                ClassicAssert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                ClassicAssert.AreEqual(DtmfTone.A, continuousDtmfRecognitionToneReceived.Tone);
                ClassicAssert.AreEqual(1, continuousDtmfRecognitionToneReceived.SequenceId);
                ClassicAssert.AreEqual("callConnectionId", continuousDtmfRecognitionToneReceived.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", continuousDtmfRecognitionToneReceived.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", continuousDtmfRecognitionToneReceived.ServerCallId);
                ClassicAssert.AreEqual("operationContext", continuousDtmfRecognitionToneReceived.OperationContext);
                ClassicAssert.AreEqual(200, continuousDtmfRecognitionToneReceived.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("callConnectionId", continuousDtmfRecognitionToneFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", continuousDtmfRecognitionToneFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", continuousDtmfRecognitionToneFailed.ServerCallId);
                ClassicAssert.AreEqual("operationContext", continuousDtmfRecognitionToneFailed.OperationContext);
                ClassicAssert.AreEqual(400, continuousDtmfRecognitionToneFailed.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("callConnectionId", continuousDtmfRecognitionStopped.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", continuousDtmfRecognitionStopped.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", continuousDtmfRecognitionStopped.ServerCallId);
                ClassicAssert.AreEqual("operationContext", continuousDtmfRecognitionStopped.OperationContext);
                ClassicAssert.AreEqual(200, continuousDtmfRecognitionStopped.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("callConnectionId", SendDtmfCompleted.CallConnectionId);
                ClassicAssert.AreEqual("operationContext", SendDtmfCompleted.OperationContext);
                ClassicAssert.AreEqual("correlationId", SendDtmfCompleted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", SendDtmfCompleted.ServerCallId);
                ClassicAssert.AreEqual(200, SendDtmfCompleted.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("operationContext", sendDtmfFailed.OperationContext);
                ClassicAssert.AreEqual("callConnectionId", sendDtmfFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", sendDtmfFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", sendDtmfFailed.ServerCallId);
                ClassicAssert.AreEqual(400, sendDtmfFailed.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("operationContext", CancelAddParticipantSucceeded.OperationContext);
                ClassicAssert.AreEqual("callConnectionId", CancelAddParticipantSucceeded.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", CancelAddParticipantSucceeded.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", CancelAddParticipantSucceeded.ServerCallId);
                ClassicAssert.AreEqual("invitationId", CancelAddParticipantSucceeded.InvitationId);
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
                ClassicAssert.AreEqual("operationContext", cancelAddParticipantFailed.OperationContext);
                ClassicAssert.AreEqual("callConnectionId", cancelAddParticipantFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", cancelAddParticipantFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", cancelAddParticipantFailed.ServerCallId);
                ClassicAssert.AreEqual("invitationId", cancelAddParticipantFailed.InvitationId);
                ClassicAssert.AreEqual(400, cancelAddParticipantFailed.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("operationContext", createCallFailed.OperationContext);
                ClassicAssert.AreEqual("callConnectionId", createCallFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", createCallFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", createCallFailed.ServerCallId);
                ClassicAssert.AreEqual(400, createCallFailed.ResultInformation?.Code);
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
                ClassicAssert.AreEqual("callConnectionId", transcriptionStarted.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", transcriptionStarted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", transcriptionStarted.ServerCallId);
                ClassicAssert.AreEqual("operationContext", transcriptionStarted.OperationContext);
                ClassicAssert.AreEqual(200, transcriptionStarted.ResultInformation?.Code);
                ClassicAssert.AreEqual(TranscriptionStatus.TranscriptionStarted, transcriptionStarted.TranscriptionUpdate.TranscriptionStatus);
                ClassicAssert.AreEqual(TranscriptionStatusDetails.SubscriptionStarted, transcriptionStarted.TranscriptionUpdate.TranscriptionStatusDetails);
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
                ClassicAssert.AreEqual("callConnectionId", transcriptionUpdated.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", transcriptionUpdated.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", transcriptionUpdated.ServerCallId);
                ClassicAssert.AreEqual("operationContext", transcriptionUpdated.OperationContext);
                ClassicAssert.AreEqual(200, transcriptionUpdated.ResultInformation?.Code);
                ClassicAssert.AreEqual(TranscriptionStatus.TranscriptionUpdated, transcriptionUpdated.TranscriptionUpdate.TranscriptionStatus);
                ClassicAssert.AreEqual(TranscriptionStatusDetails.StreamConnectionReestablished, transcriptionUpdated.TranscriptionUpdate.TranscriptionStatusDetails);
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
                ClassicAssert.AreEqual("callConnectionId", transcriptionStopped.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", transcriptionStopped.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", transcriptionStopped.ServerCallId);
                ClassicAssert.AreEqual("operationContext", transcriptionStopped.OperationContext);
                ClassicAssert.AreEqual(200, transcriptionStopped.ResultInformation?.Code);
                ClassicAssert.AreEqual(TranscriptionStatus.TranscriptionStopped, transcriptionStopped.TranscriptionUpdate.TranscriptionStatus);
                ClassicAssert.AreEqual(TranscriptionStatusDetails.SubscriptionStopped, transcriptionStopped.TranscriptionUpdate.TranscriptionStatusDetails);
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
                ClassicAssert.AreEqual("callConnectionId", transcriptionFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", transcriptionFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", transcriptionFailed.ServerCallId);
                ClassicAssert.AreEqual("operationContext", transcriptionFailed.OperationContext);
                ClassicAssert.AreEqual(200, transcriptionFailed.ResultInformation?.Code);
                ClassicAssert.AreEqual(TranscriptionStatus.TranscriptionFailed, transcriptionFailed.TranscriptionUpdate.TranscriptionStatus);
                ClassicAssert.AreEqual(TranscriptionStatusDetails.UnspecifiedError, transcriptionFailed.TranscriptionUpdate.TranscriptionStatusDetails);
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
                ClassicAssert.AreEqual("correlationId", holdFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", holdFailed.ServerCallId);
                ClassicAssert.AreEqual(400, holdFailed.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaEventReasonCode.PlayDownloadFailed, holdFailed.ReasonCode);
                ClassicAssert.AreEqual(8536, holdFailed.ReasonCode.GetReasonCodeValue());
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
                ClassicAssert.AreEqual("callConnectionId", mediaStreamingStarted.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", mediaStreamingStarted.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", mediaStreamingStarted.ServerCallId);
                ClassicAssert.AreEqual("operationContext", mediaStreamingStarted.OperationContext);
                ClassicAssert.AreEqual(200, mediaStreamingStarted.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaStreamingStatus.MediaStreamingStarted, mediaStreamingStarted.MediaStreamingUpdate.MediaStreamingStatus);
                ClassicAssert.AreEqual(MediaStreamingStatusDetails.SubscriptionStarted, mediaStreamingStarted.MediaStreamingUpdate.MediaStreamingStatusDetails);
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
                ClassicAssert.AreEqual("callConnectionId", mediaStreamingStopped.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", mediaStreamingStopped.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", mediaStreamingStopped.ServerCallId);
                ClassicAssert.AreEqual("operationContext", mediaStreamingStopped.OperationContext);
                ClassicAssert.AreEqual(200, mediaStreamingStopped.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaStreamingStatus.MediaStreamingStarted, mediaStreamingStopped.MediaStreamingUpdate.MediaStreamingStatus);
                ClassicAssert.AreEqual(MediaStreamingStatusDetails.SubscriptionStarted, mediaStreamingStopped.MediaStreamingUpdate.MediaStreamingStatusDetails);
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
                ClassicAssert.AreEqual("callConnectionId", mediaStreamingFailed.CallConnectionId);
                ClassicAssert.AreEqual("correlationId", mediaStreamingFailed.CorrelationId);
                ClassicAssert.AreEqual("serverCallId", mediaStreamingFailed.ServerCallId);
                ClassicAssert.AreEqual("operationContext", mediaStreamingFailed.OperationContext);
                ClassicAssert.AreEqual(200, mediaStreamingFailed.ResultInformation?.Code);
                ClassicAssert.AreEqual(MediaStreamingStatus.MediaStreamingStarted, mediaStreamingFailed.MediaStreamingUpdate.MediaStreamingStatus);
                ClassicAssert.AreEqual(MediaStreamingStatusDetails.SubscriptionStarted, mediaStreamingFailed.MediaStreamingUpdate.MediaStreamingStatusDetails);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
