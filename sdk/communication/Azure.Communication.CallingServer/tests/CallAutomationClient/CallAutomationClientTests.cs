// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.CodeDom;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;

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
            TransportUrl = new Uri("https://websocket")
        };

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.Null(response.Value.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.AnswerCall(incomingCallContext, callbackUri);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.Null(response.Value.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallWithOptionsAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext)
            {
                CallbackEndpoint = callbackUri,
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            var response = await callAutomationClient.AnswerCallAsync(options).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.Null(response.Value.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallWithOptions_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext)
            {
                CallbackEndpoint = callbackUri,
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            var response = callAutomationClient.AnswerCall(options);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.Null(response.Value.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallAsync_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.AnswerCall(incomingCallContext, callbackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public async Task RedirectCallAsync_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RedirectCall(incomingCallContext, target);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCallAsync_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RedirectCall(incomingCallContext, target));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public async Task RejectCallAsync_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RejectCall(incomingCallContext, reason);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCallAsync_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RejectCall(incomingCallContext, reason));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.Null(result.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.CreateCall(source, targets, callbackUri);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.Null(result.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallWithOptionsAsync_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);
            CreateCallOptions options = new CreateCallOptions(
                source: source,
                targets: targets,
                callbackEndpoint: callbackUri)
            {
                Subject = "subject",
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.Null(result.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallWithOptions_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);
            CreateCallOptions options = new CreateCallOptions(
                source: source,
                targets: targets,
                callbackEndpoint: callbackUri)
            {
                Subject = "subject",
                MediaStreamingConfiguration = _mediaStreamingConfiguration
            };

            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.Null(result.CallConnectionProperties.MediaSubscriptionId);
            Assert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallAsync_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.CreateCall(source, targets, callbackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetCallConnection))]
        public void GetCallConnection(string callConnectionId)
        {
            var response = new CallAutomationClient(ConnectionString).GetCallConnection(callConnectionId);
            CallConnection result = (CallConnection)response;
            Assert.NotNull(result);
            Assert.AreEqual(callConnectionId, result.CallConnectionId);
        }

        [Test]
        public void GetCallRecording()
        {
            var response = new CallAutomationClient(ConnectionString).GetCallRecording();
            Assert.NotNull(response);
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

        // exceptions
        private static IEnumerable<object?[]> TestData_AnswerCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }
        private static IEnumerable<object?[]> TestData_RedirectCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    new CommunicationUserIdentifier("12345")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RejectCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    CallRejectReason.Busy
                },
            };
        }
        private static IEnumerable<object?[]> TestData_CreateCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CallSource(new CommunicationUserIdentifier("56789")),
                    new CommunicationIdentifier[] {new CommunicationUserIdentifier("12345") },
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetCallConnection()
        {
            return new[]
            {
                new object?[]
                {
                    "12345"
                },
            };
        }
    }
}
