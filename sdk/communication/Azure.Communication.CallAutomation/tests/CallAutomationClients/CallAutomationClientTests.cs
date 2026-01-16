// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallAutomationClients
{
    public class CallAutomationClientTests : CallAutomationTestBase
    {
        private readonly MediaStreamingOptions _mediaStreamingConfiguration = new MediaStreamingOptions(
            MediaStreamingAudioChannel.Mixed)
        { TransportUri = new Uri("https://websocket") };

        private readonly TranscriptionOptions _transcriptionConfiguration = new TranscriptionOptions(
            "en-CA")
        {
            TransportUri = new Uri("https://websocket"),
            StartTranscription = true
        };

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Null);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.AnswerCall(incomingCallContext, callbackUri);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Null);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallWithOptionsAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext, callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration,
                OperationContext = "operation_context"
            };

            var response = await callAutomationClient.AnswerCallAsync(options).ConfigureAwait(false);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Not.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallWithOptions_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext: incomingCallContext, callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration
            };

            var response = callAutomationClient.AnswerCall(options);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            Assert.That(response.Value.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Not.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallAsync_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(401));
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.AnswerCall(incomingCallContext, callbackUri));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(401));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public async Task RedirectCallAsync_204NoContent(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RedirectCallAsync(incomingCallContext, callInvite).ConfigureAwait(false);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_204NoContent(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RedirectCall(incomingCallContext, callInvite);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCallAsync_404NotFound(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.RedirectCallAsync(incomingCallContext, callInvite).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_404NotFound(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RedirectCall(incomingCallContext, callInvite));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public async Task RejectCallAsync_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            var response = await callAutomationClient.RejectCallAsync(rejectOption).ConfigureAwait(false);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            var response = callAutomationClient.RejectCall(rejectOption);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCallAsync_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.RejectCallAsync(rejectOption).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RejectCall(rejectOption));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Null);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Null);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallWithOptionsAsync_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration
            };

            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Not.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallWithOptions_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration
            };

            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Not.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallWithTeamsAppSourceAsync_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayloadWithTeamsAppSource);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                TeamsAppSource = new MicrosoftTeamsAppIdentifier("teamsAppId")
            };

            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyOPSCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallWithTeamsAppSource_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayloadWithTeamsAppSource);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                TeamsAppSource = new MicrosoftTeamsAppIdentifier("teamsAppId")
            };

            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyOPSCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallAsync_404NotFound(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(new CreateCallOptions(target, callbackUri)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_404NotFound(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.CreateCall(new CreateCallOptions(target, callbackUri)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public async Task ConnectCallAsync_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var response = await callAutomationClient.ConnectCallAsync(callLocator, callbackUri).ConfigureAwait(false);
            ConnectCallResult result = (ConnectCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public void ConnectCall_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var response = callAutomationClient.ConnectCall(callLocator, callbackUri);
            ConnectCallResult result = (ConnectCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public async Task ConnectCallWithOptionsAsync_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var options = new ConnectCallOptions(callLocator, callbackUri);
            var response = await callAutomationClient.ConnectCallAsync(options).ConfigureAwait(false);
            ConnectCallResult result = (ConnectCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public void ConnectCallWithOptions_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var options = new ConnectCallOptions(callLocator, callbackUri);
            var response = callAutomationClient.ConnectCall(options);
            ConnectCallResult result = (ConnectCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [TestCaseSource(nameof(TestData_GetCallConnection))]
        public void GetCallConnection(string callConnectionId)
        {
            var response = new CallAutomationClient(ConnectionString).GetCallConnection(callConnectionId);
            CallConnection result = (CallConnection)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CallConnectionId, Is.EqualTo(callConnectionId));
        }

        [Test]
        public void GetCallRecording()
        {
            var response = new CallAutomationClient(ConnectionString).GetCallRecording();
            Assert.That(response, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_CreateGroupCall))]
        public async Task CreateGroupCallAsync_201Created(IEnumerable<CommunicationIdentifier> targets, Uri callbackUri, PhoneNumberIdentifier callerIdNumber)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            CreateGroupCallOptions options = new(
                targets: targets,
                callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration,
                SourceCallerIdNumber = callerIdNumber,
            };

            var response = await callAutomationClient.CreateGroupCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.That(result, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Created));
            verifyCallConnectionProperties(result.CallConnectionProperties);
            Assert.That(result.CallConnection.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(response.Value.CallConnectionProperties.MediaStreamingSubscription, Is.Not.Null);
            Assert.That(response.Value.CallConnectionProperties.TranscriptionSubscription, Is.Not.Null);
        }

        private static void ValidateCreateCallResult(CreateCallResult createCallResult)
        {
            Assert.That(createCallResult, Is.Not.Null);
            Assert.That(createCallResult.CallConnection, Is.Not.Null);
            Assert.That(createCallResult.CallConnection.CallConnectionId, Is.EqualTo("callConnectionId"));
            ValidateCallConnectionProperties(createCallResult.CallConnectionProperties);
        }

        private static void ValidateAnswerCallResult(AnswerCallResult answerCallResult)
        {
            Assert.That(answerCallResult, Is.Not.Null);
            Assert.That(answerCallResult.CallConnection, Is.Not.Null);
            Assert.That(answerCallResult.CallConnection.CallConnectionId, Is.EqualTo("callConnectionId"));
            ValidateCallConnectionProperties(answerCallResult.CallConnectionProperties);
        }

        private static void ValidateCallConnectionProperties(CallConnectionProperties properties)
        {
            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.CallConnectionId, Is.EqualTo("callConnectionId"));
            Assert.That(properties.CallConnectionState, Is.EqualTo(CallConnectionState.Connecting));
            Assert.That(properties.Source.RawId, Is.EqualTo("dummySourceUser"));
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
        private static IEnumerable<object?[]> TestData_AnswerCall_NoCallbackUri()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
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
                    new CallInvite(new CommunicationUserIdentifier("12345"))
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
                    new CallInvite(new CommunicationUserIdentifier("12345")),
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CreateGroupCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationIdentifier[] {new CommunicationUserIdentifier("12345"), new PhoneNumberIdentifier("+1234567") },
                    new Uri("https://bot.contoso.com/callback"),
                    new PhoneNumberIdentifier("+18888888888"),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CreateGroupCall_NoCallerId()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationIdentifier[] {new CommunicationUserIdentifier("12345"), new PhoneNumberIdentifier("+1234567") },
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CreateCall_NoCallbackUri()
        {
            return new[]
            {
                new object?[]
                {
                    new CallInvite(new CommunicationUserIdentifier("12345")),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CreateGroupCall_EmptyTargets()
        {
            return new[]
            {
                new object?[]
                {
                    Array.Empty<CommunicationIdentifier>(),
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
        private static IEnumerable<object?[]> TestData_ConnectCall()
        {
            return new[]
            {
                new object?[]
                {
                    _serverCallLocator,
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }
    }
}
