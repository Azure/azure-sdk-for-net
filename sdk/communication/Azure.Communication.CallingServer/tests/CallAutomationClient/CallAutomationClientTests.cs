// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class CallAutomationClientTests : CallAutomationTestBase
    {
        private const string NoneMediaSubscriptionId = "null";
        private const string MediaSubscriptionId = "\"mediaSubscriptionId\"";
        private const string SuccessfulCallConnectionProperties = "{{"
                + "\"callConnectionId\": \"callConnectionId\","
                + "\"serverCallId\": \"serverCallId\","
                + "\"source\": {{"
                + "\"identifier\": {{"
                + "\"rawId\": \"dummySourceUser\","
                + "\"kind\": \"communicationUser\""
                + "}}"
                + "}},"
                + "\"targets\": [{{"
                + "\"rawId\": \"dummyTargetUser\","
                + "\"kind\": \"communicationUser\""
                + "}}],"
                + "\"callConnectionState\": \"connecting\","
                + "\"subject\": \"subject\","
                + "\"callbackUri\": \"https://localhost\","
                + "\"mediaSubscriptionId\": {0}"
                + "}}";
        private readonly MediaStreamingConfiguration _mediaStreamingConfiguration = new MediaStreamingConfiguration()
        {
            AudioChannelType = MediaStreamingAudioChannelType.Unmixed,
            ContentType = MediaStreamingContentType.Audio,
            TransportType = MediaStreamingTransportType.Websocket,
            TransportUrl = "https://websocket"
        };

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateCall_Test(bool isAsync)
        {
            MockResponse callSuccessful = new MockResponse(201);
            callSuccessful.SetContent(string.Format(SuccessfulCallConnectionProperties, NoneMediaSubscriptionId));
            CallAutomationClient client = CreateMockCallAutomationClient(new MockResponse[] { callSuccessful });

            CreateCallResult callResult;
            if (isAsync)
            {
                callResult = await client.CreateCallAsync(
                    source: new CallSource(new CommunicationUserIdentifier("dummySourceUser")),
                    targets: new CommunicationIdentifier[] { new CommunicationUserIdentifier("dummyTargetUser") },
                    callbackEndpoint: new Uri("https://localhost"),
                    subject: "subject");
            }
            else
            {
                callResult = client.CreateCall(
                    source: new CallSource(new CommunicationUserIdentifier("dummySourceUser")),
                    targets: new CommunicationIdentifier[] { new CommunicationUserIdentifier("dummyTargetUser") },
                    callbackEndpoint: new Uri("https://localhost"),
                    subject: "subject");
            }

            ValidateCreateCallResult(callResult);
            Assert.Null(callResult.CallConnectionProperties.MediaSubscriptionId);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateCallWithOptions_Test(bool isAsync)
        {
            MockResponse callSuccessful = new MockResponse(201);
            callSuccessful.SetContent(string.Format(SuccessfulCallConnectionProperties, MediaSubscriptionId));
            CallAutomationClient client = CreateMockCallAutomationClient(new MockResponse[] { callSuccessful });
            CreateCallOptions options = new CreateCallOptions(
                source: new CallSource(new CommunicationUserIdentifier("dummySourceUser")),
                targets: new CommunicationIdentifier[] { new CommunicationUserIdentifier("dummyTargetUser") },
                callbackEndpoint: new Uri("https://localhost"))
            {
                Subject = "subject",
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            CreateCallResult callResult;
            if (isAsync)
            {
                callResult = await client.CreateCallAsync(options);
            }
            else
            {
                callResult = client.CreateCall(options);
            }

            ValidateCreateCallResult(callResult);
            Assert.AreEqual("mediaSubscriptionId", callResult.CallConnectionProperties.MediaSubscriptionId);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnswerCall_Test(bool isAsync)
        {
            MockResponse callSuccessful = new MockResponse(200);
            callSuccessful.SetContent(string.Format(SuccessfulCallConnectionProperties, NoneMediaSubscriptionId));
            CallAutomationClient client = CreateMockCallAutomationClient(new MockResponse[] { callSuccessful });

            AnswerCallResult callResult;
            if (isAsync)
            {
                callResult = await client.AnswerCallAsync(
                    incomingCallContext: "incomingCallContext",
                    callbackEndpoint: new Uri("https://localhost"));
            }
            else
            {
                callResult = client.AnswerCall(
                    incomingCallContext: "incomingCallContext",
                    callbackEndpoint: new Uri("https://localhost"));
            }

            ValidateAnswerCallResult(callResult);
            Assert.Null(callResult.CallConnectionProperties.MediaSubscriptionId);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AnswerCallWithOptions_Test(bool isAsync)
        {
            MockResponse callSuccessful = new MockResponse(200);
            callSuccessful.SetContent(string.Format(SuccessfulCallConnectionProperties, MediaSubscriptionId));
            CallAutomationClient client = CreateMockCallAutomationClient(new MockResponse[] { callSuccessful });
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: "incomingCallContext")
            {
                CallbackEndpoint = new Uri("https://localhost"),
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            AnswerCallResult callResult;
            if (isAsync)
            {
                callResult = await client.AnswerCallAsync(options);
            }
            else
            {
                callResult = client.AnswerCall(options);
            }

            ValidateAnswerCallResult(callResult);
            Assert.AreEqual("mediaSubscriptionId", callResult.CallConnectionProperties.MediaSubscriptionId);
        }

        private static void ValidateCreateCallResult(CreateCallResult createCallResult)
        {
            Assert.NotNull(createCallResult);
            Assert.NotNull(createCallResult.CallConnection);
            Assert.AreEqual("callConnectionId", createCallResult.CallConnection.CallConnectionId);
            ValidateCallConnectionProperties(createCallResult.CallConnectionProperties);
        }

        private static void ValidateAnswerCallResult(AnswerCallResult answerCallResult)
        {
            Assert.NotNull(answerCallResult);
            Assert.NotNull(answerCallResult.CallConnection);
            Assert.AreEqual("callConnectionId", answerCallResult.CallConnection.CallConnectionId);
            ValidateCallConnectionProperties(answerCallResult.CallConnectionProperties);
        }

        private static void ValidateCallConnectionProperties(CallConnectionProperties properties)
        {
            Assert.NotNull(properties);
            Assert.AreEqual("callConnectionId", properties.CallConnectionId);
            Assert.AreEqual(CallConnectionState.Connecting, properties.CallConnectionState);
            Assert.NotNull(properties.CallSource);
            Assert.AreEqual("dummySourceUser", properties.CallSource.Identifier.RawId);
            Assert.AreEqual("serverCallId", properties.ServerCallId);
            Assert.AreEqual(1, properties.Targets.Count);
        }
    }
}
