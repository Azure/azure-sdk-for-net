// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallConnectionTests : CallingServerTestBase
    {
        private const string CancelAllMediaOperaionsResponsePayload = "{" +
                                                "\"id\": \"dummyId\"," +
                                                "\"status\": \"completed\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string PlayAudioResponsePayload = "{" +
                                                "\"id\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string GetCallConnectionDetailsPayload = "{" +
                                                "\"callConnectionId\": \"411f6d00-1d3f-425b-9d7d-df971f16564b\", " +
                                                "\"source\":{ \"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d376\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d376\"}}," +
                                                "\"targets\":[{ \"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000009-9189-b73c-edbe-a43a0d0050e3\", \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000009-9189-b73c-edbe-a43a0d0050e3\"}}]," +
                                                "\"callState\":\"establishing\"," +
                                                "\"subject\":\"testsubject\"," +
                                                "\"callbackUri\":\"https://bot.contoso.io/callback\"," +
                                                "\"requestedMediaTypes\":[\"audio\", \"video\"]," +
                                                "\"requestedCallEvents\":[\"dtmfReceived\"]" +
                                                "}";

        private const string GetParticipantsPayload = "[" +
                                                "{ \"identifier\": {\"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\"}}, \"participantId\": \"ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac\", \"isMuted\": true }, " +
                                                "{ \"identifier\": {\"rawId\": \"4:+14251234567\",  \"phoneNumber\": {\"value\":\"+14251234567\"}}, \"participantId\": \"e44ca273-079f-4759-8d6e-284ee8322625\", \"isMuted\": false }" +
                                                "]";

        private const string GetParticipantPayload1 = "{ " +
                                                "\"identifier\": {\"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\"}}, " +
                                                "\"participantId\": \"ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac\", " +
                                                "\"isMuted\": true " +
                                                "}";

        private const string GetParticipantPayload2 = "{ " +
                                                "\"identifier\": {\"rawId\": \"4:+14251234567\",  \"phoneNumber\": {\"value\":\"+14251234567\"}}, " +
                                                "\"participantId\": \"e44ca273-079f-4759-8d6e-284ee8322625\", " +
                                                "\"isMuted\": false " +
                                                "}";

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task HangupCallAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.HangupAsync().ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void HangupCall_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.Hangup();

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task CancelAllMediaOperationsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var result = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);

            VerifyCancelAllMediaOperationsResult(result);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void CancelAllMediaOperations_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var result = callConnection.CancelAllMediaOperations();

            VerifyCancelAllMediaOperationsResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var result = await callConnection.PlayAudioAsync(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext).ConfigureAwait(false);

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var result = callConnection.PlayAudio(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsyncOverload_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileUri = sampleAudioFileUri,
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            var result = await callConnection.PlayAudioAsync(playAudio).ConfigureAwait(false);

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioOverload_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileUri = sampleAudioFileUri,
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            var result = callConnection.PlayAudio(playAudio);

            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202);

            var response = await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202);

            var response = callConnection.AddParticipant(participant, alternateCallerId, operationContext);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Passes(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Passes(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.RemoveParticipant(participantId);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        private void VerifyCancelAllMediaOperationsResult(CancelAllMediaOperationsResult result)
        {
            Assert.AreEqual("dummyId", result.Id);
            Assert.AreEqual(OperationStatus.Completed, result.Status);
            Assert.AreEqual("dummyOperationContext", result.OperationContext);
            Assert.AreEqual(200, result.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", result.ResultInfo.Message);
        }

        private void VerifyPlayAudioResult(PlayAudioResult result)
        {
            Assert.AreEqual("dummyId", result.Id);
            Assert.AreEqual(OperationStatus.Running, result.Status);
            Assert.AreEqual("dummyOperationContext", result.OperationContext);
            Assert.AreEqual(200, result.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", result.ResultInfo.Message);
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallingServerClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }

        private static IEnumerable<object?[]> TestData_CallConnectionId()
        {
            return new[]
            {
                new object?[]
                {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudio()
        {
            return new[]
            {
                new object?[]
                {
                    new Uri("https://bot.contoso.io/audio/sample-message.wav"),
                    "sampleAudioFileId",
                    new Uri("https://bot.contoso.io/callback"),
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
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "66c76529-3e58-45bf-9592-84eadd52bc81"
                },
            };
        }
    }
}
