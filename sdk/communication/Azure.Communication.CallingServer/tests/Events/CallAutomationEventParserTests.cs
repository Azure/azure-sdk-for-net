// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Messaging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.Events
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

            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            CallConnected @event = CallAutomationModelFactory.CallConnected(callConnectionId, serverCallId, correlationId);
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
        public void RecordingStateChangedEventParsed_Test()
        {
            CallRecordingStateChanged @event = CallAutomationModelFactory.RecordingStateChanged(
                recordingId: "recordingId",
                state: RecordingState.Active,
                startDateTime: DateTimeOffset.UtcNow,
                callConnectionId: "callConnectionId",
                serverCallId: "serverCallId",
                correlationId: "correlationId");
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
        public void PlayCompletedEventParsed_Test()
        {
            PlayCompleted @event = CallAutomationModelFactory.PlayCompleted(
                "operationContext",
                new ResultInformation(code: 200, subCode: 200, message: "Action completed successfully"),
                "callConnectionId",
                "serverCallId",
                "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayCompleted");
            if (parsedEvent is PlayCompleted playCompleted)
            {
                Assert.AreEqual("correlationId", playCompleted.CorrelationId);
                Assert.AreEqual("serverCallId", playCompleted.ServerCallId);
                Assert.AreEqual(200, playCompleted.ResultInfo.Code);
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
                "operationContext",
                new ResultInformation(code: 400, subCode: 8536, message: "Action failed, file could not be downloaded."),
                "callConnectionId",
                "serverCallId",
                "correlationId");
            JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string jsonEvent = JsonSerializer.Serialize(@event, jsonOptions);
            var parsedEvent = CallAutomationEventParser.Parse(jsonEvent, "Microsoft.Communication.PlayFailed");
            if (parsedEvent is PlayFailed playFailed)
            {
                Assert.AreEqual("correlationId", playFailed.CorrelationId);
                Assert.AreEqual("serverCallId", playFailed.ServerCallId);
                Assert.AreEqual(400, playFailed.ResultInfo.Code);
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
