﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Messaging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Events
{
    public class CallAutomationEventParserTests
    {
        //private static string DTMF_RESULT_JSON = "{\"recognizeResult\":{},\"collectTonesResult\":{\"tones\":[\"five\", \"six\", \"pound\"]},\"choiceResult\":{\"label\":null,\"recognizedPhrase\":null},\"recognitionType\":\"dtmf\",\"callConnectionId\":\"callConnectionId\",\"serverCallId\":\"serverCallId\",\"correlationId\":\"correlationId\",\"operationContext\":\"operationContext\",\"resultInformation\":{\"code\":200,\"subCode\":8531,\"message\":\"Action completed, max digits received\"}}";
        //private static string CHIOCE_RESULT_JSON = "{\"recognizeResult\":{},\"collectTonesResult\":{\"tones\":[]},\"choiceResult\":{\"label\":\"testLabel\",\"recognizedPhrase\":\"testRecognizePhrase\"},\"recognitionType\":\"choices\",\"callConnectionId\":\"callConnectionId\",\"serverCallId\":\"serverCallId\",\"correlationId\":\"correlationId\",\"operationContext\":\"operationContext\",\"resultInformation\":{\"code\":200,\"subCode\":8531,\"message\":\"Action completed, max digits received\"}}";
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
            Assert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            Assert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            Assert.AreEqual(serverCallId, callConnected.ServerCallId);
            Assert.AreEqual(correlationId, callConnected.CorrelationId);
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
            Assert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            Assert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            Assert.AreEqual(serverCallId, callConnected.ServerCallId);
            Assert.AreEqual(correlationId, callConnected.CorrelationId);
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
            Assert.AreEqual(callConnected.GetType(), typeof(CallConnected));
            Assert.AreEqual(callConnectionId, callConnected.CallConnectionId);
            Assert.AreEqual(serverCallId, callConnected.ServerCallId);
            Assert.AreEqual(correlationId, callConnected.CorrelationId);
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
            Assert.AreEqual(2, callAutomationEvents.Length);
            Assert.AreEqual(callAutomationEvents[0].GetType(), typeof(CallConnected));
            Assert.AreEqual(callConnectionId1, callAutomationEvents[0].CallConnectionId);
            Assert.AreEqual(serverCallId1, callAutomationEvents[0].ServerCallId);
            Assert.AreEqual(correlationId1, callAutomationEvents[0].CorrelationId);
            Assert.AreEqual(callAutomationEvents[1].GetType(), typeof(CallDisconnected));
            Assert.AreEqual(callConnectionId2, callAutomationEvents[1].CallConnectionId);
            Assert.AreEqual(serverCallId2, callAutomationEvents[1].ServerCallId);
            Assert.AreEqual(correlationId2, callAutomationEvents[1].CorrelationId);
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
            Assert.AreEqual(2, callAutomationEvents.Length);
            Assert.AreEqual(callAutomationEvents[0].GetType(), typeof(CallConnected));
            Assert.AreEqual(callConnectionId1, callAutomationEvents[0].CallConnectionId);
            Assert.AreEqual(serverCallId1, callAutomationEvents[0].ServerCallId);
            Assert.AreEqual(correlationId1, callAutomationEvents[0].CorrelationId);
            Assert.AreEqual(callAutomationEvents[1].GetType(), typeof(CallDisconnected));
            Assert.AreEqual(callConnectionId2, callAutomationEvents[1].CallConnectionId);
            Assert.AreEqual(serverCallId2, callAutomationEvents[1].ServerCallId);
            Assert.AreEqual(correlationId2, callAutomationEvents[1].CorrelationId);
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
                Assert.AreEqual(callConnectionId, addParticipantsFailed.CallConnectionId);
                Assert.AreEqual(serverCallId, addParticipantsFailed.ServerCallId);
                Assert.AreEqual(correlationId, addParticipantsFailed.CorrelationId);
                Assert.AreEqual(operationContext, addParticipantsFailed.OperationContext);
                Assert.AreEqual(403, addParticipantsFailed.ResultInformation?.Code);
                Assert.AreEqual("8:acs:12345", addParticipantsFailed.Participant.RawId);
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
                Assert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                Assert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                Assert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                Assert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                Assert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                Assert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                Assert.AreEqual(callConnectionId, calConnected.CallConnectionId);
                Assert.AreEqual(serverCallId, calConnected.ServerCallId);
                Assert.AreEqual(correlationId, calConnected.CorrelationId);
                Assert.IsNull(calConnected.OperationContext);
                Assert.IsNull(calConnected.ResultInformation);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

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
                Assert.AreEqual(callConnectionId, callDisconnected.CallConnectionId);
                Assert.AreEqual(serverCallId, callDisconnected.ServerCallId);
                Assert.AreEqual(correlationId, callDisconnected.CorrelationId);
                Assert.IsNull(callDisconnected.OperationContext);
                Assert.IsNull(callDisconnected.ResultInformation);
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
                Assert.AreEqual(callConnectionId, callTransferAccepted.CallConnectionId);
                Assert.AreEqual(serverCallId, callTransferAccepted.ServerCallId);
                Assert.AreEqual(correlationId, callTransferAccepted.CorrelationId);
                Assert.AreEqual(operationContext, callTransferAccepted.OperationContext);
                Assert.AreEqual(202, callTransferAccepted.ResultInformation?.Code);
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
                Assert.AreEqual(callConnectionId, callTransferFailed.CallConnectionId);
                Assert.AreEqual(serverCallId, callTransferFailed.ServerCallId);
                Assert.AreEqual(correlationId, callTransferFailed.CorrelationId);
                Assert.AreEqual(operationContext, callTransferFailed.OperationContext);
                Assert.AreEqual(403, callTransferFailed.ResultInformation?.Code);
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
            var participant1 = new CallParticipant(new CommunicationUserIdentifier("8:acs:12345"), false);
            var participant2 = new CallParticipant(new PhoneNumberIdentifier("+123456789"), false);
            var participants = new CallParticipant[] { participant1, participant2 };
            var @event = CallAutomationModelFactory.ParticipantsUpdated(callConnectionId, serverCallId, correlationId, participants);
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            // act
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.ParticipantsUpdated");

            // assert
            if (parsedEvent is ParticipantsUpdated participantsUpdated)
            {
                Assert.AreEqual(callConnectionId, participantsUpdated.CallConnectionId);
                Assert.AreEqual(serverCallId, participantsUpdated.ServerCallId);
                Assert.AreEqual(correlationId, participantsUpdated.CorrelationId);
                Assert.IsNull(participantsUpdated.OperationContext);
                Assert.IsNull(participantsUpdated.ResultInformation);
                Assert.AreEqual(2, participantsUpdated.Participants.Count);
                Assert.AreEqual("8:acs:12345", participantsUpdated.Participants[0].Identifier.RawId);
                Assert.IsFalse(participantsUpdated.Participants[0].IsMuted);
                Assert.IsTrue(participantsUpdated.Participants[1].Identifier.RawId.EndsWith("123456789"));
                Assert.IsFalse(participantsUpdated.Participants[1].IsMuted);
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
                Assert.AreEqual("recordingId", recordingEvent.RecordingId);
                Assert.AreEqual("serverCallId", recordingEvent.ServerCallId);
                Assert.AreEqual(RecordingState.Active, recordingEvent.State);
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
                Assert.AreEqual("correlationId", playCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", playCompleted.ServerCallId);
                Assert.AreEqual(200, playCompleted.ResultInformation?.Code);
                Assert.AreEqual(MediaEventReasonCode.CompletedSuccessfully, playCompleted.ReasonCode);
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
                Assert.AreEqual("correlationId", playFailed.CorrelationId);
                Assert.AreEqual("serverCallId", playFailed.ServerCallId);
                Assert.AreEqual(400, playFailed.ResultInformation?.Code);
                Assert.AreEqual(MediaEventReasonCode.PlayDownloadFailed, playFailed.ReasonCode);
                Assert.AreEqual(8536, playFailed.ReasonCode.GetReasonCodeValue());
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
                Assert.AreEqual("correlationId", playCancelled.CorrelationId);
                Assert.AreEqual("serverCallId", playCancelled.ServerCallId);
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
            RecognizeDtmfCompleted @event = CallAutomationModelFactory.RecognizeDtmfCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Dtmf,
                dtmfResult: dtmfResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                RecognizeResult recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.AreEqual(recognizeResult is DtmfResult, true);
                Assert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                Assert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    string toneResults = dtmfResultReturned.ConvertToString();
                    Assert.NotZero(dtmfResultReturned.Tones.Count());
                    Assert.AreEqual(DtmfTone.Five, dtmfResultReturned.Tones.First());
                    Assert.AreEqual(toneResults, "56#");
                }
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void RecognizeCompletedWithChoiceEventParsed_Test()
        {
            ChoiceResult choiceResult = new ChoiceResult("testLabel", "testRecognizePhrase");
            RecognizeChoiceCompleted @event = CallAutomationModelFactory.RecognizeChoiceCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Choices,
                choiceResult: choiceResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                RecognizeResult recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.AreEqual(recognizeResult is ChoiceResult, true);
                Assert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                Assert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is ChoiceResult choiceRecongizedResult)
                {
                    Assert.AreEqual("testLabel", choiceRecongizedResult.Label);
                    Assert.AreEqual("testRecognizePhrase", choiceRecongizedResult.RecognizedPhrase);
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
            RecognizeDtmfCompleted @event = CallAutomationModelFactory.RecognizeDtmfCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Dtmf,
                dtmfResult: dtmfResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                RecognizeResult recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.AreEqual(recognizeResult is DtmfResult, true);
                Assert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                Assert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is DtmfResult dtmfResultReturned)
                {
                    Assert.NotZero(dtmfResultReturned.Tones.Count());
                    Assert.AreEqual(DtmfTone.Five, dtmfResultReturned.Tones.First());
                }
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void GetRecognizeResultFromRecognizeCompletedWithChoice_Test()
        {
            ChoiceResult choiceResult = new ChoiceResult("testLabel", "testRecognizePhrase");
            RecognizeChoiceCompleted @event = CallAutomationModelFactory.RecognizeChoiceCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Choices,
                choiceResult: choiceResult,
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                RecognizeResult recognizeResult = recognizeCompleted.RecognizeResult;
                Assert.AreEqual(recognizeResult is ChoiceResult, true);
                Assert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                Assert.AreEqual(200, recognizeCompleted.ResultInformation?.Code);
                if (recognizeResult is ChoiceResult choiceRecongizedResult)
                {
                    Assert.AreEqual("testLabel", choiceRecongizedResult.Label);
                    Assert.AreEqual("testRecognizePhrase", choiceRecongizedResult.RecognizedPhrase);
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
                Assert.AreEqual("correlationId", recognizeFailed.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeFailed.ServerCallId);
                Assert.AreEqual(400, recognizeFailed.ResultInformation?.Code);
                Assert.AreEqual(MediaEventReasonCode.RecognizeInitialSilenceTimedOut, recognizeFailed.ReasonCode);
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
                Assert.AreEqual("correlationId", recognizeCancelled.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCancelled.ServerCallId);
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
                Assert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                Assert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                Assert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                Assert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                Assert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                Assert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                Assert.AreEqual(callConnectionId, addParticipantsSucceeded.CallConnectionId);
                Assert.AreEqual(serverCallId, addParticipantsSucceeded.ServerCallId);
                Assert.AreEqual(correlationId, addParticipantsSucceeded.CorrelationId);
                Assert.AreEqual(operationContext, addParticipantsSucceeded.OperationContext);
                Assert.AreEqual(200, addParticipantsSucceeded.ResultInformation?.Code);
                Assert.AreEqual("8:acs:12345", addParticipantsSucceeded.Participant.RawId);
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
                toneInfo: new ToneInfo(sequenceId: 1, DtmfTone.A),
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
                Assert.AreEqual(DtmfTone.A, continuousDtmfRecognitionToneReceived.ToneInfo.Tone);
                Assert.AreEqual(1, continuousDtmfRecognitionToneReceived.ToneInfo.SequenceId);
                Assert.AreEqual("callConnectionId", continuousDtmfRecognitionToneReceived.CallConnectionId);
                Assert.AreEqual("correlationId", continuousDtmfRecognitionToneReceived.CorrelationId);
                Assert.AreEqual("serverCallId", continuousDtmfRecognitionToneReceived.ServerCallId);
                Assert.AreEqual("operationContext", continuousDtmfRecognitionToneReceived.OperationContext);
                Assert.AreEqual(200, continuousDtmfRecognitionToneReceived.ResultInformation?.Code);
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
                Assert.AreEqual("callConnectionId", continuousDtmfRecognitionToneFailed.CallConnectionId);
                Assert.AreEqual("correlationId", continuousDtmfRecognitionToneFailed.CorrelationId);
                Assert.AreEqual("serverCallId", continuousDtmfRecognitionToneFailed.ServerCallId);
                Assert.AreEqual("operationContext", continuousDtmfRecognitionToneFailed.OperationContext);
                Assert.AreEqual(400, continuousDtmfRecognitionToneFailed.ResultInformation?.Code);
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
                Assert.AreEqual("callConnectionId", continuousDtmfRecognitionStopped.CallConnectionId);
                Assert.AreEqual("correlationId", continuousDtmfRecognitionStopped.CorrelationId);
                Assert.AreEqual("serverCallId", continuousDtmfRecognitionStopped.ServerCallId);
                Assert.AreEqual("operationContext", continuousDtmfRecognitionStopped.OperationContext);
                Assert.AreEqual(200, continuousDtmfRecognitionStopped.ResultInformation?.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void SendDtmfCompletedEventParsed_Test()
        {
            SendDtmfCompleted @event = CallAutomationModelFactory.SendDtmfCompleted(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 0, message: "Action completed successfully"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.SendDtmfCompleted");
            if (parsedEvent is SendDtmfCompleted SendDtmfCompleted)
            {
                Assert.AreEqual("callConnectionId", SendDtmfCompleted.CallConnectionId);
                Assert.AreEqual("operationContext", SendDtmfCompleted.OperationContext);
                Assert.AreEqual("correlationId", SendDtmfCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", SendDtmfCompleted.ServerCallId);
                Assert.AreEqual(200, SendDtmfCompleted.ResultInformation?.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        public void SendDtmfFailedEventParsed_Test()
        {
            SendDtmfFailed @event = CallAutomationModelFactory.SendDtmfFailed(
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8510, message: "Action failed, some error."));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.SendDtmfFailed");
            if (parsedEvent is SendDtmfFailed sendDtmfFailed)
            {
                Assert.AreEqual("operationContext", sendDtmfFailed.OperationContext);
                Assert.AreEqual("callConnectionId", sendDtmfFailed.CallConnectionId);
                Assert.AreEqual("correlationId", sendDtmfFailed.CorrelationId);
                Assert.AreEqual("serverCallId", sendDtmfFailed.ServerCallId);
                Assert.AreEqual(400, sendDtmfFailed.ResultInformation?.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
