// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.AnswerCall(incomingCallContext, callbackUri);
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
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
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);
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
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response.Value.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, response.Value.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallAsync_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callAutomationClient.AnswerCall(incomingCallContext, callbackUri));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public async Task RedirectCallAsync_204NoContent(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RedirectCallAsync(incomingCallContext, callInvite).ConfigureAwait(false);
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_204NoContent(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RedirectCall(incomingCallContext, callInvite);
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCallAsync_404NotFound(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.RedirectCallAsync(incomingCallContext, callInvite).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_404NotFound(string incomingCallContext, CallInvite callInvite)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callAutomationClient.RedirectCall(incomingCallContext, callInvite));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public async Task RejectCallAsync_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            var response = await callAutomationClient.RejectCallAsync(rejectOption).ConfigureAwait(false);
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            var response = callAutomationClient.RejectCall(rejectOption);
            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCallAsync_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.RejectCallAsync(rejectOption).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RejectCallOptions rejectOption = new RejectCallOptions(incomingCallContext);
            rejectOption.CallRejectReason = reason;

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callAutomationClient.RejectCall(rejectOption));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
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
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);
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
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);
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
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyOPSCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
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
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyOPSCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallAsync_404NotFound(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(new CreateCallOptions(target, callbackUri)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public async Task CreateCallAsync_MicrosoftTeamsAppIdentifier_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(target.Target);
            var teamsApp = target.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public void CreateCall_MicrosoftTeamsAppIdentifier_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var options = new CreateCallOptions(target, callbackUri);
            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.Null(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.Null(response.Value.CallConnectionProperties.TranscriptionSubscription);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(target.Target);
            var teamsApp = target.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public async Task CreateCallWithOptionsAsync_MicrosoftTeamsAppIdentifier_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration,
                OperationContext = "teams-app-context"
            };

            var response = await callAutomationClient.CreateCallAsync(options).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);

            // Verify all optional properties can be set
            ClassicAssert.AreEqual("teams-app-context", options.OperationContext);
            ClassicAssert.IsNotNull(options.MediaStreamingOptions);
            ClassicAssert.IsNotNull(options.TranscriptionOptions);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public void CreateCallWithOptions_MicrosoftTeamsAppIdentifier_201Created(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload);
            CreateCallOptions options = new CreateCallOptions(
                callInvite: target,
                callbackUri: callbackUri)
            {
                MediaStreamingOptions = _mediaStreamingConfiguration,
                TranscriptionOptions = _transcriptionConfiguration,
                OperationContext = "teams-app-context"
            };

            var response = callAutomationClient.CreateCall(options);
            CreateCallResult result = (CreateCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);

            // Verify all optional properties can be set
            ClassicAssert.AreEqual("teams-app-context", options.OperationContext);
            ClassicAssert.IsNotNull(options.MediaStreamingOptions);
            ClassicAssert.IsNotNull(options.TranscriptionOptions);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public void CreateCallAsync_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(new CreateCallOptions(target, callbackUri)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall_MicrosoftTeamsApp))]
        public void CreateCall_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite target, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callAutomationClient.CreateCall(new CreateCallOptions(target, callbackUri)));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public async Task ConnectCallAsync_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var response = await callAutomationClient.ConnectCallAsync(callLocator, callbackUri).ConfigureAwait(false);
            ConnectCallResult result = (ConnectCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public void ConnectCall_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var response = callAutomationClient.ConnectCall(callLocator, callbackUri);
            ConnectCallResult result = (ConnectCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public async Task ConnectCallWithOptionsAsync_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var options = new ConnectCallOptions(callLocator, callbackUri);
            var response = await callAutomationClient.ConnectCallAsync(options).ConfigureAwait(false);
            ConnectCallResult result = (ConnectCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_ConnectCall))]
        public void ConnectCallWithOptions_200OK(CallLocator callLocator, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, DummyConnectPayload);

            var options = new ConnectCallOptions(callLocator, callbackUri);
            var response = callAutomationClient.ConnectCall(options);
            ConnectCallResult result = (ConnectCallResult)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties, isConnectApi: true);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_GetCallConnection))]
        public void GetCallConnection(string callConnectionId)
        {
            var response = new CallAutomationClient(ConnectionString).GetCallConnection(callConnectionId);
            CallConnection result = (CallConnection)response;
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(callConnectionId, result.CallConnectionId);
        }

        [Test]
        public void GetCallRecording()
        {
            var response = new CallAutomationClient(ConnectionString).GetCallRecording();
            ClassicAssert.NotNull(response);
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
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            verifyCallConnectionProperties(result.CallConnectionProperties);
            ClassicAssert.AreEqual(CallConnectionId, result.CallConnection.CallConnectionId);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.MediaStreamingSubscription);
            ClassicAssert.NotNull(response.Value.CallConnectionProperties.TranscriptionSubscription);
        }

        private static void ValidateCreateCallResult(CreateCallResult createCallResult)
        {
            ClassicAssert.NotNull(createCallResult);
            ClassicAssert.NotNull(createCallResult.CallConnection);
            ClassicAssert.AreEqual("callConnectionId", createCallResult.CallConnection.CallConnectionId);
            ValidateCallConnectionProperties(createCallResult.CallConnectionProperties);
        }

        private static void ValidateAnswerCallResult(AnswerCallResult answerCallResult)
        {
            ClassicAssert.NotNull(answerCallResult);
            ClassicAssert.NotNull(answerCallResult.CallConnection);
            ClassicAssert.AreEqual("callConnectionId", answerCallResult.CallConnection.CallConnectionId);
            ValidateCallConnectionProperties(answerCallResult.CallConnectionProperties);
        }

        private static void ValidateCallConnectionProperties(CallConnectionProperties properties)
        {
            ClassicAssert.NotNull(properties);
            ClassicAssert.AreEqual("callConnectionId", properties.CallConnectionId);
            ClassicAssert.AreEqual(CallConnectionState.Connecting, properties.CallConnectionState);
            ClassicAssert.AreEqual("dummySourceUser", properties.Source.RawId);
            ClassicAssert.AreEqual("serverCallId", properties.ServerCallId);
            ClassicAssert.AreEqual(1, properties.Targets.Count);
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

        private static IEnumerable<object?[]> TestData_CreateCall_MicrosoftTeamsApp()
        {
            var callInvite = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId"));
            callInvite.CustomCallingContext.AddVoip("key1", "value1");
            return new[]
            {
                new object?[]
                {
                    callInvite,
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CreateCall_MicrosoftTeamsAppWithCloud()
        {
            var callInvitePublic = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Public));
            callInvitePublic.CustomCallingContext.AddVoip("key1", "value1");

            var callInviteDod = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Dod));
            callInviteDod.CustomCallingContext.AddVoip("key2", "value2");

            var callInviteGcch = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Gcch));
            callInviteGcch.CustomCallingContext.AddVoip("key3", "value3");

            return new[]
            {
                new object?[] { callInvitePublic, new Uri("https://bot.contoso.com/callback") },
                new object?[] { callInviteDod, new Uri("https://bot.contoso.com/callback") },
                new object?[] { callInviteGcch, new Uri("https://bot.contoso.com/callback") },
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
