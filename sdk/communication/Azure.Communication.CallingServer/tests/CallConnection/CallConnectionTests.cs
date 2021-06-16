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
                                                "\"operationId\": \"dummyId\"," +
                                                "\"status\": \"completed\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string PlayAudioResponsePayload = "{" +
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
        public void HangupCallAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HangupAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void HangupCall_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.Hangup());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
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

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void CancelAllMediaOperationsAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void CancelAllMediaOperations_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.CancelAllMediaOperations());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
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
        public void PlayAudioAsync_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.PlayAudioAsync(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.PlayAudio(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
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

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioAsyncOverload_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileUri = sampleAudioFileUri,
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.PlayAudioAsync(playAudio).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioOverload_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileUri = sampleAudioFileUri,
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.PlayAudio(playAudio));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = callConnection.AddParticipant(participant, alternateCallerId, operationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyparticipantid", response.Value.ParticipantId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipantsAsync_Failed(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Failed(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipant(participant, alternateCallerId, operationContext));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
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

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantsAsync_Failed(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantAsync(participantId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Failed(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipant(participantId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        private void VerifyCancelAllMediaOperationsResult(CancelAllMediaOperationsResult result)
        {
            Assert.AreEqual("dummyId", result.OperationId);
            Assert.AreEqual(OperationStatus.Completed, result.Status);
            Assert.AreEqual("dummyOperationContext", result.OperationContext);
            Assert.AreEqual(200, result.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", result.ResultInfo.Message);
        }

        private void VerifyPlayAudioResult(PlayAudioResult result)
        {
            Assert.AreEqual("dummyId", result.OperationId);
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
