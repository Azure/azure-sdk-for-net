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
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
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
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
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
            Assert.That(callConnected.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(callConnected.CallConnectionId, Is.EqualTo(callConnectionId));
            Assert.That(callConnected.ServerCallId, Is.EqualTo(serverCallId));
            Assert.That(callConnected.CorrelationId, Is.EqualTo(correlationId));
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
                Assert.That(playCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(playCompleted.ResultInformation.Code, Is.EqualTo(200));
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
                Assert.That(playFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(playFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(playFailed.ResultInformation.Code, Is.EqualTo(400));
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
                Assert.That(recognizeCompleted.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeCompleted.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recognizeCompleted.ResultInformation.Code, Is.EqualTo(200));
                Assert.NotZero(recognizeCompleted.CollectTonesResult.Tones.Count());
                Assert.That(recognizeCompleted.CollectTonesResult.Tones.First(), Is.EqualTo(DtmfTone.Five));
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
                Assert.That(recognizeFailed.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(recognizeFailed.ServerCallId, Is.EqualTo("serverCallId"));
                Assert.That(recognizeFailed.ResultInformation.Code, Is.EqualTo(400));
            }
            else
            {
                Assert.Fail("Event parsed wrongfully");
            }
        }
    }
}
