// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure.Messaging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.Events
{
    public class CallAutomationEventParserTests
    {
        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void EventParserShouldParseEventWithEventDataAndType()
        {
            // arrange
            var callConnectionId = Guid.NewGuid().ToString();
            var serverCallId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();
            var resultInformation = new ResultInformation(200, 0, "success");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            CallConnected @event = CommunicationCallingServerModelFactory.CallConnected(resultInformation: resultInformation, callConnectionId: callConnectionId, serverCallId: serverCallId, correlationId: correlationId);
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecordingStateChangedEventParsed_Test()
        {
            CallRecordingStateChanged @event = CommunicationCallingServerModelFactory.CallRecordingStateChanged(
                recordingId: "recordingId",
                state: RecordingState.Active,
                startDateTime: DateTimeOffset.UtcNow,
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId",
                resultInformation: new ResultInformation(200, 0, "success"));
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.CallRecordingStateChanged");
            if (parsedEvent is CallRecordingStateChanged recordingEvent)
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void PlayCompletedEventParsed_Test()
        {
            PlayCompleted @event = CommunicationCallingServerModelFactory.PlayCompleted(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 200, subCode: 200, message: "Action completed successfully"),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayCompleted");
            if (parsedEvent is PlayCompleted playCompleted)
            {
                Assert.AreEqual("correlationId", playCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", playCompleted.ServerCallId);
                Assert.AreEqual(200, playCompleted.ResultInformation.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void PlayFailedEventParsed_Test()
        {
            PlayFailed @event = CommunicationCallingServerModelFactory.PlayFailed(
                operationContext: "operationContext",
                resultInformation: new ResultInformation(code: 400, subCode: 8536, message: "Action failed, file could not be downloaded."),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayFailed");
            if (parsedEvent is PlayFailed playFailed)
            {
                Assert.AreEqual("correlationId", playFailed.CorrelationId);
                Assert.AreEqual("serverCallId", playFailed.ServerCallId);
                Assert.AreEqual(400, playFailed.ResultInformation.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecognizeCompletedEventParsed_Test()
        {
            RecognizeCompleted @event = CommunicationCallingServerModelFactory.RecognizeCompleted(
                operationContext: "operationContext",
                recognitionType: CallMediaRecognitionType.Dtmf,
                collectTonesResult: new CollectTonesResult(new DtmfTone[] { DtmfTone.Five }),
                resultInformation: new ResultInformation(
                    code: 200,
                    subCode: 8531,
                    message: "Action completed, max digits received"),
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);

            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.RecognizeCompleted");
            if (parsedEvent is RecognizeCompleted recognizeCompleted)
            {
                Assert.AreEqual("correlationId", recognizeCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", recognizeCompleted.ServerCallId);
                Assert.AreEqual(200, recognizeCompleted.ResultInformation.Code);
                Assert.NotZero(recognizeCompleted.CollectTonesResult.Tones.Count());
                Assert.AreEqual(DtmfTone.Five, recognizeCompleted.CollectTonesResult.Tones.First());
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecognizeFailedEventParsed_Test()
        {
            RecognizeFailed @event = CommunicationCallingServerModelFactory.RecognizeFailed(
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
                Assert.AreEqual(400, recognizeFailed.ResultInformation.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
