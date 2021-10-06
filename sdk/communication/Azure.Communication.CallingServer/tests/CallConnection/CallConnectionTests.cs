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

            var result = await callConnection.PlayAudioAsync(
                sampleAudioFileUri,
                new PlayAudioOptions()
                {
                    Loop = false,
                    AudioFileId = sampleAudioFileId,
                    CallbackUri = sampleCallbackUri,
                    OperationContext = sampleOperationContext
                }).ConfigureAwait(false);
            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var result = callConnection.PlayAudio(
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
        public void PlayAudioAsync_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.PlayAudioAsync(
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
        public void PlayAudio_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.PlayAudio(
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

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsyncOverload_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            var result = await callConnection.PlayAudioAsync(sampleAudioFileUri, playAudio).ConfigureAwait(false);
            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioOverload_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            var result = callConnection.PlayAudio(sampleAudioFileUri, playAudio);
            VerifyPlayAudioResult(result);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioAsyncOverload_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.PlayAudioAsync(sampleAudioFileUri, playAudio).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudioOverload_Failed(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            var playAudio = new PlayAudioOptions()
            {
                AudioFileId = sampleAudioFileId,
                CallbackUri = sampleCallbackUri,
                Loop = false,
                OperationContext = sampleOperationContext
            };

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.PlayAudio(sampleAudioFileUri, playAudio));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantPlayAudio))]
        public async Task PlayAudioToParticipantAsync_Return202Accepted(string participantUserId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);
            var participant = new CommunicationUserIdentifier(participantUserId);

            Response<PlayAudioResult> result = await callConnection.PlayAudioToParticipantAsync(
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
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);
            var participant = new CommunicationUserIdentifier(participantUserId);

            PlayAudioResult result = callConnection.PlayAudioToParticipant(
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
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.PlayAudioToParticipantAsync(
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
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.PlayAudioToParticipant(
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
            var callConnection = CreateMockCallConnection(200);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = await callConnection.CancelParticipantMediaOperationAsync(
                participant,
                mediaOperationId);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperation_Return200OK(string participantUserId, string mediaOperationId)
        {
            var callConnection = CreateMockCallConnection(200);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = callConnection.CancelParticipantMediaOperation(
                participant,
                mediaOperationId);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperationAsync_Returns404NotFound(string participantUserId, string mediaOperationId)
        {
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.CancelParticipantMediaOperationAsync(
                participant,
                mediaOperationId).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelParticipantMediaOperation))]
        public void CancelParticipantMediaOperation_Returns404NotFound(string participantUserId, string mediaOperationId)
        {
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.CancelParticipantMediaOperation(
                participant,
                mediaOperationId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task MuteParticipantAsync_Return200OK(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = await callConnection.MuteParticipantAsync(
                participant);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void MuteParticipant_Return200OK(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = callConnection.MuteParticipant(
                participant);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void MuteParticipantAsync_Returns404NotFound(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.MuteParticipantAsync(
                participant).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void MuteParticipant_Returns404NotFound(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.MuteParticipant(
                participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task UnmuteParticipantAsync_Return200OK(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = await callConnection.UnmuteParticipantAsync(
                participant);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void UnmuteParticipant_Return200OK(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = callConnection.UnmuteParticipant(
                participant);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void UnmuteParticipantAsync_Returns404NotFound(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.UnmuteParticipantAsync(
                participant).ConfigureAwait(false));

            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void UnmuteParticipant_Returns404NotFound(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.UnmuteParticipant(
                participant));
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

        [TestCaseSource(nameof(TestData_TransferCall))]
        public async Task TransferCallAsync_Passes(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = await callConnection.TransferCallAsync(participant, targetCallConnectionId, userToUserInformation).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_TransferCall))]
        public void TransferCall_Passes(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = callConnection.TransferCall(participant, targetCallConnectionId, userToUserInformation);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_TransferCall))]
        public void TransferCallAsync_Failed(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallAsync(participant, targetCallConnectionId, userToUserInformation).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCall))]
        public void TransferCall_Failed(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCall(participant, targetCallConnectionId, userToUserInformation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.RemoveParticipantAsync(participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = callConnection.RemoveParticipant(participant);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantsAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipant(participant));
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

        private static IEnumerable<object?[]> TestData_TransferCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                    "dummyUserToUserInformation"
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
