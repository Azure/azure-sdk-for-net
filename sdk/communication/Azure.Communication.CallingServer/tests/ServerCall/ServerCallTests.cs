// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class ServerCallTests : CallingServerTestBase
    {
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
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string AddParticipantResultPayload = "{" +
                                                                "\"participantId\": \"dummyparticipantid\"" +
                                                            "}";

        private const string ServerCallId = "sampleServerCallId";

        private static CallLocator CallLocator = new ServerCallLocator(ServerCallId);

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

        private void VerifyPlayAudioResult(PlayAudioResult response)
        {
            Assert.AreEqual("dummyId", response.OperationId);
            Assert.AreEqual(OperationStatus.Running, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", response.ResultInfo.Message);
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
    }
}
