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

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns200Ok(Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(200, responseContent: DummyStartRecordingResponse);
            StartCallRecordingResult result = serverCall.StartRecording(sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecordingAsync_Returns200Ok(Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(200, responseContent: DummyStartRecordingResponse);
            Response<StartCallRecordingResult> result = await serverCall.StartRecordingAsync(sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", result.Value.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecording_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = serverCall.StopRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public async Task StopRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = await serverCall.StopRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecording_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = serverCall.PauseRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public async Task PauseRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = await serverCall.PauseRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecording_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = serverCall.ResumeRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public async Task ResumeRecordingAsync_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200);
            Response response = await serverCall.ResumeRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingState_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200, responseContent: DummyRecordingStateResponse);
            CallRecordingProperties result = serverCall.GetRecordingState(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, result.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingStateAsync_Return200Ok(string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(200, responseContent: DummyRecordingStateResponse);
            Response<CallRecordingProperties> result = await serverCall.GetRecordingStateAsync(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, result.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Return202Accepted(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(202, responseContent: DummyPlayAudioResponse);
            PlayAudioResult result = serverCall.PlayAudio(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Return202Accepted(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(202, responseContent: DummyPlayAudioResponse);
            Response<PlayAudioResult> result = await serverCall.PlayAudioAsync(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Return202Accepted(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(202, AddParticipantResultPayload);

            var response = await serverCall.AddParticipantAsync(participant, callBack, alternateCallerId, operationContext).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Return202Accepted(CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(202, AddParticipantResultPayload);

            var response = serverCall.AddParticipant(participant, callBack, alternateCallerId, operationContext);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Return202Accepted(string participantId)
        {
            var serverCall = CreateMockServerCall(202);

            var response = await serverCall.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Return202Accepted(string participantId)
        {
            var serverCall = CreateMockServerCall(202);

            var response = serverCall.RemoveParticipant(participantId);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
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

        private ServerCall CreateMockServerCall(int responseCode, string? responseContent = null, string serverCallId = "sampleServerCallId")
        {
            return CreateMockCallingServerClient(responseCode, responseContent).InitializeServerCall(serverCallId);
        }
    }
}
