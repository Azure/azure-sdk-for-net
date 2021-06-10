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
                                                "\"id\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyStartRecordingResponse);
            StartCallRecordingResult response = serverCall.StartRecording(sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", response.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecordingAsync_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyStartRecordingResponse);
            Response<StartCallRecordingResult> response = await serverCall.StartRecordingAsync(sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", response.Value.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = serverCall.StopRecording(sampleRecordingId);
            var temp = response.Status;
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public async Task StopRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = await serverCall.StopRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = serverCall.PauseRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public async Task PauseRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = await serverCall.PauseRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = serverCall.ResumeRecording(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public async Task ResumeRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200);
            Response response = await serverCall.ResumeRecordingAsync(sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingState_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyRecordingStateResponse);
            CallRecordingStateResult response = serverCall.GetRecordingState(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingStateAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyRecordingStateResponse);
            Response<CallRecordingStateResult> response = await serverCall.GetRecordingStateAsync(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 202, DummyPlayAudioResponse);
            PlayAudioResult response = serverCall.PlayAudio(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 202, DummyPlayAudioResponse);
            Response<PlayAudioResult> response = await serverCall.PlayAudioAsync(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Return202Accepted(string serverCallId, CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = await serverCall.AddParticipantAsync(participant, callBack, alternateCallerId, operationContext).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Return202Accepted(string serverCallId, CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = serverCall.AddParticipant(participant, callBack, alternateCallerId, operationContext);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Return202Accepted(string serverCallId, string participantId)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = await serverCall.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Return202Accepted(string serverCallId, string participantId)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = serverCall.RemoveParticipant(participantId);

            Assert.AreEqual((int)response.Status, 202);
        }

        private void VerifyPlayAudioResponse(PlayAudioResult response)
        {
            Assert.AreEqual("dummyId", response.Id);
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
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
                    "sampleConversationId",
                    "66c76529-3e58-45bf-9592-84eadd52bc81"
                },
            };
        }

        private ServerCall CreateMockServerCall(string serverCallId, int responseCode, string? responseContent = null)
        {
            return CreateMockCallingServerClient(responseCode, responseContent).InitializeServerCall(serverCallId);
        }
    }
}
