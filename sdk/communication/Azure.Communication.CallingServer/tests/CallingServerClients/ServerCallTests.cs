// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class ServerCallTests
    {
        private const string connectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";

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

        private const string GetParticipantsPayload = "[" +
                                                "{ \"identifier\": {\"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\"}}, \"participantId\": \"ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac\", \"isMuted\": true }, " +
                                                "{ \"identifier\": {\"rawId\": \"4:+14251234567\",  \"phoneNumber\": {\"value\":\"+14251234567\"}}, \"participantId\": \"e44ca273-079f-4759-8d6e-284ee8322625\", \"isMuted\": false }" +
                                                "]";

        private const string GetParticipantPayload1 = "{ \"identifier\": {\"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\"}}, \"participantId\": \"ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac\", \"isMuted\": true }";

        private const string GetParticipantPayload2 = "{ \"identifier\": {\"rawId\": \"4:+14251234567\",  \"phoneNumber\": {\"value\":\"+14251234567\"}}, \"participantId\": \"e44ca273-079f-4759-8d6e-284ee8322625\", \"isMuted\": false }";

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyStartRecordingResponse);
            StartCallRecordingResponse response = serverCall.StartRecording(sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", response.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecordingAsync_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyStartRecordingResponse);
            Response<StartCallRecordingResponse> response = await serverCall.StartRecordingAsync(sampleCallBackUri);
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
            GetCallRecordingStateResponse response = serverCall.GetRecordingState(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingStateAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 200, DummyRecordingStateResponse);
            Response<GetCallRecordingStateResponse> response = await serverCall.GetRecordingStateAsync(sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 202, DummyPlayAudioResponse);
            PlayAudioResponse response = serverCall.PlayAudio(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ServerCall serverCall = CreateMockServerCall(sampleConversationId, 202, DummyPlayAudioResponse);
            Response<PlayAudioResponse> response = await serverCall.PlayAudioAsync(sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Passes(string serverCallId, CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = await serverCall.AddParticipantAsync(participant, callBack, alternateCallerId, operationContext).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Passes(string serverCallId, CommunicationIdentifier participant, Uri callBack, string alternateCallerId, string operationContext)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = serverCall.AddParticipant(participant, callBack, alternateCallerId, operationContext);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Passes(string serverCallId, string participantId)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = await serverCall.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Passes(string serverCallId, string participantId)
        {
            var serverCall = CreateMockServerCall(serverCallId, 202);

            var response = serverCall.RemoveParticipant(participantId);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_GetParticipants))]
        public async Task GetParticipantsAsync_Passes(string serverCallId)
        {
            var callConnection = CreateMockServerCall(serverCallId, 200, GetParticipantsPayload);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);

            VerifyParticipantsResponse(response.Value);
        }

        [TestCaseSource(nameof(TestData_GetParticipants))]
        public void GetParticipants_Passes(string serverCallId)
        {
            var callConnection = CreateMockServerCall(serverCallId, 200, GetParticipantsPayload);

            var response = callConnection.GetParticipants();

            VerifyParticipantsResponse(response.Value);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_Passes(string serverCallId, string participantId, string payload, int participantNumber)
        {
            var callConnection = CreateMockServerCall(serverCallId, 200, payload);

            var response = await callConnection.GetParticipantAsync(participantId).ConfigureAwait(false);

            VerifyParticipantResponse(response.Value, participantNumber);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_Passes(string serverCallId, string participantId, string payload, int participantNumber)
        {
            var callConnection = CreateMockServerCall(serverCallId, 200, payload);

            var response = callConnection.GetParticipant(participantId);

            VerifyParticipantResponse(response.Value, participantNumber);
        }

        private void VerifyPlayAudioResponse(PlayAudioResponse response)
        {
            Assert.AreEqual("dummyId", response.Id);
            Assert.AreEqual(OperationStatus.Running, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", response.ResultInfo.Message);
        }

        private void VerifyParticipantsResponse(IEnumerable<CommunicationParticipant> participants)
        {
            Assert.AreEqual(2, participants.Count());

            var participant1 = participants.Where(p => p.ParticipantId == "ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac").FirstOrDefault();

            Assert.IsNotNull(participant1);
            Assert.AreEqual("8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371", ((CommunicationUserIdentifier)participant1!.Identifier).Id);
            Assert.AreEqual(true, participant1.IsMuted);

            var participant2 = participants.Where(p => p.ParticipantId == "e44ca273-079f-4759-8d6e-284ee8322625").FirstOrDefault();

            Assert.IsNotNull(participant2);
            Assert.AreEqual("+14251234567", ((PhoneNumberIdentifier)participant2!.Identifier).PhoneNumber);
            Assert.AreEqual(false, participant2.IsMuted);
        }

        private void VerifyParticipantResponse(CommunicationParticipant participant, int participantNumber)
        {
            Assert.IsNotNull(participant);

            if (participantNumber == 1)
            {
                Assert.AreEqual("ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac", participant.ParticipantId);
                Assert.AreEqual("8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371", ((CommunicationUserIdentifier)participant!.Identifier).Id);
                Assert.AreEqual(true, participant.IsMuted);
            }
            else
            {
                Assert.AreEqual("e44ca273-079f-4759-8d6e-284ee8322625", participant.ParticipantId);
                Assert.AreEqual("+14251234567", ((PhoneNumberIdentifier)participant!.Identifier).PhoneNumber);
                Assert.AreEqual(false, participant.IsMuted);
            }
        }

        private static IEnumerable<object?[]> TestData_StartRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    new Uri("https://somecallbackurl"),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StopRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PauseRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_ResumeRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetRecordingState()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudio()
        {
            return new List<object?[]>(){
                new object?[] {
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
            return new List<object?[]>(){
                new object?[] {
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
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "66c76529-3e58-45bf-9592-84eadd52bc81"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetParticipants()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetParticipant()
        {
            return new List<object?[]>(){
                new object?[] {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac",
                    GetParticipantPayload1,
                    1
                },
                new object?[] {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "e44ca273-079f-4759-8d6e-284ee8322625",
                    GetParticipantPayload2,
                    2
                },
            };
        }

        private CallingServerClient CreateMockCallingServerClient(int responseCode, string? responseContent = null)
        {
            var mockResponse = new MockResponse(responseCode);
            if (responseContent != null)
            {
                mockResponse.SetContent(responseContent);
            }

            var callingServerClientOptions = new CallingServerClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new CallingServerClient(connectionString, callingServerClientOptions);
        }

        private ServerCall CreateMockServerCall(string serverCallId, int responseCode, string? responseContent = null)
        {
            return CreateMockCallingServerClient(responseCode, responseContent).InitializeServerCall(new ServerCallLocator(serverCallId));
        }
    }
}
