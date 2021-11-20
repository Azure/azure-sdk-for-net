// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerClientTests : CallingServerTestBase
    {
        private const string AmsDeleteUrl = "https://dummyurl.com/v1/objects/documentid";

        private const string DummyStartRecordingResponse = "{" +
                                        "\"recordingId\": \"dummyRecordingId\"" +
                                        "}";
        private const string DummyRecordingStateResponse = "{" +
                                                "\"recordingState\": \"active\"" +
                                                "}";

        private const string DummyPlayAudioResponse = "{" +
                                                "\"operationId\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultDetails\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string AddParticipantResultPayload = "{" +
                                                                "\"participantId\": \"dummyparticipantid\"" +
                                                            "}";

        private const string ServerCallId = "sampleServerCallId";

        private const string GetParticipantsResultPayload = "[" +
                                                "{" +
                                                    "\"identifier\": {" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"communicationUser\": {" +
                                                                "\"id\": \"0000000d-5a5f-2db9-ccd7-44482200049a\"" +
                                                            "}" +
                                                    "}," +
                                                    "\"participantId\": \"dummyParticipantId\"," +
                                                    "\"isMuted\": false" +
                                                "}," +
                                                "{" +
                                                    "\"identifier\": {" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"phoneNumber\": {" +
                                                                "\"value\": \"+1555123456\"" +
                                                            "}" +
                                                    "}," +
                                                    "\"participantId\": \"dummyParticipantId1\"," +
                                                    "\"isMuted\": false" +
                                                "}" +
                                                "]";

        private const string GetParticipantResultPayload =
                                                "{" +
                                                    "\"identifier\": {" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"communicationUser\": {" +
                                                                "\"id\": \"0000000d-5a5f-2db9-ccd7-44482200049a\"" +
                                                            "}" +
                                                    "}," +
                                                    "\"participantId\": \"dummyParticipantId\"," +
                                                    "\"isMuted\": false" +
                                                "}";

        private static CallLocator CallLocator = new ServerCallLocator(ServerCallId);

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_Returns201Created(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(201, CreateOrJoinOrAnswerCallPayload);

            var response = await callingServerClient.CreateCallConnectionAsync(source, targets, createCallOptions).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_Returns201Created(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(201, CreateOrJoinOrAnswerCallPayload);

            var response = callingServerClient.CreateCallConnection(source, targets, createCallOptions);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallAsync_Returns404NotFound(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callingServerClient.CreateCallConnectionAsync(source, targets, createCallOptions).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_Returns404NotFound(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.CreateCallConnection(source, targets, createCallOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public async Task JoinCallAsync_Returns202Accepted(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(202, CreateOrJoinOrAnswerCallPayload);

            var callLocator = new ServerCallLocator(serverCallId);

            var response = await callingServerClient.JoinCallAsync(callLocator, source, joinCallOptions).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public void JoinCall_Returns202Accepted(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(202, CreateOrJoinOrAnswerCallPayload);

            var callLocator = new ServerCallLocator(serverCallId);

            var response = callingServerClient.JoinCall(callLocator, source, joinCallOptions);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public void JoinCallAsync_Returns404NotFound(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(404);

            var callLocator = new ServerCallLocator(serverCallId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callingServerClient.JoinCallAsync(callLocator, source, joinCallOptions).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public void JoinCall_Returns404NotFound(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(404);

            var callLocator = new ServerCallLocator(serverCallId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.JoinCall(callLocator, source, joinCallOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void DeleteRecording_Returns200Ok()
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(200);
            var response = callingServerClient.DeleteRecording(new Uri(AmsDeleteUrl));
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task DeleteRecordingAsync_Returns200Ok()
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(200);
            var response = await callingServerClient.DeleteRecordingAsync(new Uri(AmsDeleteUrl)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [Test]
        public void DeleteRecording_Returns404NotFound()
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void DeleteRecording_Returns401Unauthorized()
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(401);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecordingAsync_Returns200Ok(Uri sampleCallBackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: DummyStartRecordingResponse);
            Response<StartCallRecordingResult> result = await serverCallRestClient.StartRecordingAsync(CallLocator, sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", result.Value.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns200Ok(Uri sampleCallBackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: DummyStartRecordingResponse);
            StartCallRecordingResult result = serverCallRestClient.StartRecording(CallLocator, sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecordingAsync_Returns404NotFound(Uri sampleCallBackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.StartRecordingAsync(CallLocator, sampleCallBackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns404NotFound(Uri sampleCallBackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.StartRecording(CallLocator, sampleCallBackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartRecordingLatestVersion))]
        public void StartRecordingLatestVersion_Returns200Ok(Uri sampleCallBackUri, RecordingContent? recordingContent, RecordingChannel recordingChannel, RecordingFormat recordingFormat)
        {
            CallingServerClient serverCall = CreateMockCallingServerClient(200, responseContent: DummyStartRecordingResponse);

            StartCallRecordingResult result = serverCall.StartRecording(CallLocator, sampleCallBackUri, recordingContent, recordingChannel, recordingFormat);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecordingLatestVersion))]
        public void StartRecordingAsyncLatestVersion_Returns404NotFound(Uri sampleCallBackUri, RecordingContent? recordingContent, RecordingChannel recordingChannel, RecordingFormat recordingFormat)
        {
            CallingServerClient serverCall = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCall.StartRecordingAsync(CallLocator, sampleCallBackUri, recordingContent, recordingChannel, recordingFormat).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartRecordingLatestVersion))]
        public void StartRecordingLatestVersion_Returns404NotFound(Uri sampleCallBackUri, RecordingContent? recordingContentType, RecordingChannel recordingChannelType, RecordingFormat recordingFormatType)
        {
            CallingServerClient serverCall = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCall.StartRecording(CallLocator, sampleCallBackUri, recordingContentType, recordingChannelType, recordingFormatType));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public async Task StopRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = await serverCallRestClient.StopRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecording_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = serverCallRestClient.StopRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecordingAsync_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.StopRecordingAsync(sampleRecordingId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecording_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.StopRecording(sampleRecordingId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public async Task PauseRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = await serverCallRestClient.PauseRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecording_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = serverCallRestClient.PauseRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecordingAsync_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.PauseRecordingAsync(sampleRecordingId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecording_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.PauseRecording(sampleRecordingId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public async Task ResumeRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = await serverCallRestClient.ResumeRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecording_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            Response response = serverCallRestClient.ResumeRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecordingAsync_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.ResumeRecordingAsync(sampleRecordingId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecording_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.ResumeRecording(sampleRecordingId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingStateAsync_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: DummyRecordingStateResponse);

            Response<CallRecordingProperties> result = await serverCallRestClient.GetRecordingStateAsync(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, result.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingState_Return200Ok(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: DummyRecordingStateResponse);

            CallRecordingProperties result = serverCallRestClient.GetRecordingState(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, result.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingStateAsync_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.GetRecordingStateAsync(sampleRecordingId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingState_Returns404NotFound(string sampleRecordingId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.GetRecordingState(sampleRecordingId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Return202Accepted(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, responseContent: DummyPlayAudioResponse);

            Response<PlayAudioResult> result = await serverCallRestClient.PlayAudioAsync(
                CallLocator,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                });

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Return202Accepted(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, responseContent: DummyPlayAudioResponse);

            PlayAudioResult result = serverCallRestClient.PlayAudio(
                CallLocator,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                });

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioAsync_Returns404NotFound(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.PlayAudioAsync(
                CallLocator,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                }).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Returns404NotFound(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.PlayAudio(
                CallLocator,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                }));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Return202Accepted(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, AddParticipantResultPayload);

            var response = await serverCallRestClient.AddParticipantAsync(CallLocator, participant, callBack, alternateCallerId, operationContext).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Return202Accepted(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, AddParticipantResultPayload);

            var response = serverCallRestClient.AddParticipant(CallLocator, participant, callBack, alternateCallerId, operationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipantsAsync_Returns404NotFound(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.AddParticipantAsync(CallLocator, participant, callBack, alternateCallerId, operationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Returns404NotFound(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.AddParticipant(CallLocator, participant, callBack, alternateCallerId, operationContext));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Return202Accepted(string participantUserId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await serverCallRestClient.RemoveParticipantAsync(CallLocator, participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Return202Accepted(string participantUserId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = serverCallRestClient.RemoveParticipant(CallLocator, participant);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantsAsync_Returns404NotFound(string participantUserId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.RemoveParticipantAsync(CallLocator, participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Returns404NotFound(string participantUserId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.RemoveParticipant(CallLocator, participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantPlayAudio))]
        public async Task PlayAudioToParticipantAsync_Return202Accepted(string participantUserId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, responseContent: DummyPlayAudioResponse);
            var participant = new CommunicationUserIdentifier(participantUserId);

            Response<PlayAudioResult> result = await serverCallRestClient.PlayAudioToParticipantAsync(
                CallLocator,
                participant,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                });

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_ParticipantPlayAudio))]
        public void PlayAudioToParticipant_Return202Accepted(string participantUserId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, responseContent: DummyPlayAudioResponse);
            var participant = new CommunicationUserIdentifier(participantUserId);

            PlayAudioResult result = serverCallRestClient.PlayAudioToParticipant(
                CallLocator,
                participant,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                });

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_ParticipantPlayAudio))]
        public void PlayAudioToParticipantAsync_Returns404NotFound(string participantUserId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.PlayAudioToParticipantAsync(
                CallLocator,
                participant,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                }).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantPlayAudio))]
        public void PlayAudioToParticipant_Returns404NotFound(string participantUserId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.PlayAudioToParticipant(
                CallLocator,
                participant,
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                }));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public async Task CancelParticipantMediaOperationAsync_Return200OK(string participantUserId, string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await serverCallRestClient.CancelParticipantMediaOperationAsync(
                CallLocator,
                participant,
                mediaOperationId);

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperation_Return200OK(string participantUserId, string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = serverCallRestClient.CancelParticipantMediaOperation(
                CallLocator,
                participant,
                mediaOperationId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperationAsync_Returns404NotFound(string participantUserId, string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.CancelParticipantMediaOperationAsync(
                CallLocator,
                participant,
                mediaOperationId).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperation_Returns404NotFound(string participantUserId, string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.CancelParticipantMediaOperation(
                CallLocator,
                participant,
                mediaOperationId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelMediaOperation))]
        public async Task CancelMediaOperationAsync_Return200OK(string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            var result = await serverCallRestClient.CancelMediaOperationAsync(
                CallLocator,
                mediaOperationId);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_CancelMediaOperation))]
        public void CancelMediaOperation_Return200OK(string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200);

            var result = serverCallRestClient.CancelMediaOperation(
                CallLocator,
                mediaOperationId);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_CancelMediaOperation))]
        public void CancelMediaOperationAsync_Returns404NotFound(string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.CancelMediaOperationAsync(
                CallLocator,
                mediaOperationId).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelMediaOperation))]
        public void CancelMediaOperation_Returns404NotFound(string mediaOperationId)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.CancelMediaOperation(
                CallLocator,
                mediaOperationId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public async Task GetParticipantsAsync_Return200OK()
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: GetParticipantsResultPayload);

            var result = await serverCallRestClient.GetParticipantsAsync(CallLocator);
            VerifyGetParticipantsResult(result.Value.ToList());
        }

        [Test]
        public void GetParticipants_Return200OK()
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: GetParticipantsResultPayload);

            var result = serverCallRestClient.GetParticipants(CallLocator);
            VerifyGetParticipantsResult(result.Value.ToList());
        }

        [Test]
        public void GetParticipantsAsync_Returns404NotFound()
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.GetParticipantsAsync(
                CallLocator
                ).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetParticipants_Returns404NotFound()
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.GetParticipants(
                CallLocator
                ));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_Participant))]
        public async Task GetParticipantAsync_Return200OK(CommunicationIdentifier participant)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: GetParticipantResultPayload);

            var result = await serverCallRestClient.GetParticipantAsync(CallLocator, participant);
            VerifyGetParticipantResult(result.Value);
        }

        [TestCaseSource(nameof(TestData_Participant))]
        public void GetParticipant_Return200OK(CommunicationIdentifier participant)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(200, responseContent: GetParticipantResultPayload);

            var result = serverCallRestClient.GetParticipant(CallLocator, participant);
            VerifyGetParticipantResult(result.Value);
        }

        [TestCaseSource(nameof(TestData_Participant))]
        public void GetParticipantAsync_Returns404NotFound(CommunicationIdentifier participant)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.GetParticipantAsync(
                CallLocator,
                participant
                ).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_Participant))]
        public void GetParticipant_Returns404NotFound(CommunicationIdentifier participant)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.GetParticipant(
                CallLocator,
                participant
                ));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public async Task RedirectCallAsync_Return200OK(string incomingCallContext, CommunicationIdentifier target)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202);

            var response = await serverCallRestClient.RedirectCallAsync(incomingCallContext, target);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_Return200OK(string incomingCallContext, CommunicationIdentifier target)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202);

            var response = serverCallRestClient.RedirectCall(incomingCallContext, target);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallAsync_Return200OK(string incomingCallContext, IEnumerable<CallMediaType> requestedMediaTypes, IEnumerable<CallingEventSubscriptionType> requestedCallEvents, Uri callbackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, CreateOrJoinOrAnswerCallPayload);

            var response = await serverCallRestClient.AnswerCallAsync(incomingCallContext, requestedMediaTypes, requestedCallEvents, callbackUri);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_Return202OK(string incomingCallContext, IEnumerable<CallMediaType> requestedMediaTypes, IEnumerable<CallingEventSubscriptionType> requestedCallEvents, Uri callbackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(202, CreateOrJoinOrAnswerCallPayload);

            var response = serverCallRestClient.AnswerCall(incomingCallContext, requestedMediaTypes, requestedCallEvents, callbackUri);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCallAsync_Returns404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.RedirectCallAsync(
                incomingCallContext,
                target
                ).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_Returns404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.RedirectCall(
                incomingCallContext,
                target
                ));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallAsync_Returns404NotFound(string incomingCallContext, IEnumerable<CallMediaType> requestedMediaTypes, IEnumerable<CallingEventSubscriptionType> requestedCallEvents, Uri callbackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await serverCallRestClient.AnswerCallAsync(
                incomingCallContext,
                requestedMediaTypes,
                requestedCallEvents,
                callbackUri)
            .ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_Returns404NotFound(string incomingCallContext, IEnumerable<CallMediaType> requestedMediaTypes, IEnumerable<CallingEventSubscriptionType> requestedCallEvents, Uri callbackUri)
        {
            CallingServerClient serverCallRestClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => serverCallRestClient.AnswerCall(
                incomingCallContext,
                requestedMediaTypes,
                requestedCallEvents,
                callbackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        private static IEnumerable<object?[]> TestData_CreateCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:resource_source"),
                    new CommunicationIdentifier[]
                    {
                        new CommunicationUserIdentifier("8:acs:resource_target"),
                        new PhoneNumberIdentifier("+14255550123")
                    },
                    new CreateCallOptions(
                        new Uri("https://bot.contoso.com/callback"),
                        new[]
                        {
                            CallMediaType.Video
                        },
                        new[]
                        {
                            CallingEventSubscriptionType.ParticipantsUpdated
                        }
                    )
                    {
                        AlternateCallerId = new PhoneNumberIdentifier("+14255550123"),
                        Subject = "testsubject"
                    }
                },
            };
        }

        private static IEnumerable<object?[]> TestData_JoinCall()
        {
            return new[]
            {
                new object?[]
                {
                    "guid",
                    new CommunicationUserIdentifier("8:acs:resource_source"),
                    new JoinCallOptions(
                        new Uri("https://bot.contoso.com/callback"),
                        new[]
                        {
                            CallMediaType.Video
                        },
                        new[]
                        {
                            CallingEventSubscriptionType.ParticipantsUpdated
                        }
                    )
                    {
                        Subject = "testsubject"
                    }
                },
            };
        }

        private void VerifyPlayAudioResult(PlayAudioResult response)
        {
            Assert.AreEqual("dummyId", response.OperationId);
            Assert.AreEqual(CallingOperationStatus.Running, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultDetails.Code);
            Assert.AreEqual("dummyMessage", response.ResultDetails.Message);
        }

        private void VerifyGetParticipantResult(CallParticipant result)
        {
            Assert.NotNull(result);
            Assert.True(result.Identifier is CommunicationUserIdentifier);
        }

        private void VerifyGetParticipantsResult(List<CallParticipant> result)
        {
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.True(result[0].Identifier is CommunicationUserIdentifier);
            Assert.True(result[1].Identifier is PhoneNumberIdentifier);
        }

        private static IEnumerable<object?[]> TestData_StartRecording()
        {
            return new[]
            {
                new object?[]
                {
                    new Uri("https://somecallbackurl"),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StartRecordingLatestVersion()
        {
            return new[]
            {
                new object?[]
                {
                    new Uri("https://somecallbackurl"),
                    RecordingContent.Audio,
                    RecordingChannel.Mixed,
                    RecordingFormat.Mp3
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StopRecording()
        {
            return new[]
            {
                new object?[]
                {
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PauseRecording()
        {
            return new[]
            {
                new object?[]
                {
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_ResumeRecording()
        {
            return new[]
            {
                new object?[]
                {
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetRecordingState()
        {
            return new[]
            {
                new object?[]
                {
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudio()
        {
            return new[]
            {
                new object?[]
                {
                    new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                    "sampleAudioFileId",
                    new Uri("https://av.ngrok.io/someCallbackUri"),
                    "sampleOperationContext",
                }
            };
        }

        private static IEnumerable<object?[]> TestData_ParticipantPlayAudio()
        {
            return new[]
            {
                new object?[]
                {
                    "66c76529-3e58-45bf-9592-84eadd52bc81",
                    new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                    "sampleAudioFileId",
                    new Uri("https://av.ngrok.io/someCallbackUri"),
                    "sampleOperationContext",
                }
            };
        }

        private static IEnumerable<object?[]> TestData_CancelParticipantMediaOperation()
        {
            return new[]
            {
                new object?[]
                {
                    "66c76529-3e58-45bf-9592-84eadd52bc81",
                    "3631b8cb-4a65-45b5-98ae-339fc78b0aed",
                }
            };
        }

        private static IEnumerable<object?[]> TestData_CancelMediaOperation()
        {
            return new[]
            {
                new object?[]
                {
                    "3631b8cb-4a65-45b5-98ae-339fc78b0aed",
                }
            };
        }

        private static IEnumerable<object?[]> TestData_AddParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                    new Uri("https://bot.contoso.com/callback"),
                    "+14250000000",
                    "dummycontext"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_ParticipantId()
        {
            return new[]
            {
                new object?[]
                {
                    "66c76529-3e58-45bf-9592-84eadd52bc81"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_Participant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                }
            };
        }

        private static IEnumerable<object?[]> TestData_RedirectCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIincomingCallContext",
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AnswerCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIincomingCallContext",
                    new CallMediaType[] { CallMediaType.Audio },
                    new CallingEventSubscriptionType[] { CallingEventSubscriptionType.ParticipantsUpdated },
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }
    }
}
