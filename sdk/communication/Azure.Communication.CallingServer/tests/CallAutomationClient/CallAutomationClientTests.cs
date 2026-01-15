// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class CallAutomationClientTests : CallAutomationTestBase
    {
        private readonly MediaStreamingOptions _mediaStreamingConfiguration = new MediaStreamingOptions(
            new Uri("https://websocket"),
            MediaStreamingTransport.Websocket,
            MediaStreamingContent.Audio,
            MediaStreamingAudioChannel.Mixed);

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task AnswerCallAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaSubscriptionId, Is.Null);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AnswerCall_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.AnswerCall(incomingCallContext, callbackUri);
            Assert.NotNull(response);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaSubscriptionId, Is.Null);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task AnswerCallWithOptionsAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext, callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration
            };

            var response = await callAutomationClient.AnswerCallAsync(options).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaSubscriptionId, Is.EqualTo("mediaSubscriptionId"));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AnswerCallWithOptions_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext, callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration
            };

            var response = callAutomationClient.AnswerCall(options);
            Assert.NotNull(response);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaSubscriptionId, Is.EqualTo("mediaSubscriptionId"));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AnswerCallAsync_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(401));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AnswerCall_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.AnswerCall(incomingCallContext, callbackUri));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(401));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RedirectCallAsync_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RedirectCall_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RedirectCall(incomingCallContext, target);
            Assert.NotNull(response);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RedirectCallAsync_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RedirectCall_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RedirectCall(incomingCallContext, target));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RejectCallAsync_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RejectCall_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RejectCall(incomingCallContext, reason);
            Assert.NotNull(response);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RejectCallAsync_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RejectCall_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RejectCall(incomingCallContext, reason));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task CreateCallAsync_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnectionProperties.MediaSubscriptionId, Is.Null);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void CreateCall_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.CreateCall(source, targets, callbackUri);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnectionProperties.MediaSubscriptionId, Is.Null);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task CreateCallWithOptionsAsync_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callSource: source,
                targets: targets,
                callbackUri: callbackUri)
            {
                Subject = "subject",
                MediaStreamingOptions = _mediaStreamingConfiguration
            };

            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(result.CallConnectionProperties.MediaSubscriptionId, Is.EqualTo("mediaSubscriptionId"));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void CreateCallWithOptions_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callSource: source,
                targets: targets,
                callbackUri: callbackUri)
            {
                Subject = "subject",
                MediaStreamingOptions = _mediaStreamingConfiguration
            };

            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(result.CallConnectionProperties.MediaSubscriptionId, Is.EqualTo("mediaSubscriptionId"));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void CreateCallAsync_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void CreateCall_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.CreateCall(source, targets, callbackUri));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_GetCallConnection))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallConnection(string callConnectionId)
        {
            var response = new CallAutomationClient(ConnectionString).GetCallConnection(callConnectionId);
            CallConnection result = (CallConnection)response;
            Assert.NotNull(result);
            Assert.That(result.CallConnectionId, Is.EqualTo(callConnectionId));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallRecording()
        {
            var response = new CallAutomationClient(ConnectionString).GetCallRecording();
            Assert.NotNull(response);
        }

        private static void ValidateCreateCallResult(CreateCallResult createCallResult)
        {
            Assert.NotNull(createCallResult);
            Assert.NotNull(createCallResult.CallConnection);
            Assert.That(createCallResult.CallConnection.CallConnectionId, Is.EqualTo("callConnectionId"));
            ValidateCallConnectionProperties(createCallResult.CallConnectionProperties);
        }

        private static void ValidateAnswerCallResult(AnswerCallResult answerCallResult)
        {
            Assert.NotNull(answerCallResult);
            Assert.NotNull(answerCallResult.CallConnection);
            Assert.That(answerCallResult.CallConnection.CallConnectionId, Is.EqualTo("callConnectionId"));
            ValidateCallConnectionProperties(answerCallResult.CallConnectionProperties);
        }

        private static void ValidateCallConnectionProperties(CallConnectionProperties properties)
        {
            Assert.NotNull(properties);
            Assert.That(properties.CallConnectionId, Is.EqualTo("callConnectionId"));
            Assert.That(properties.CallConnectionState, Is.EqualTo(CallConnectionState.Connecting));
            Assert.NotNull(properties.CallSource);
            Assert.That(properties.CallSource.Identifier.RawId, Is.EqualTo("dummySourceUser"));
            Assert.That(properties.ServerCallId, Is.EqualTo("serverCallId"));
            Assert.That(properties.Targets.Count, Is.EqualTo(1));
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
