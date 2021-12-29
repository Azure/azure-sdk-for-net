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
    public class CallConnectionTests : CallingServerTestBase
    {
        private const string CancelAllMediaOperaionsResponsePayload = "{" +
                                                "\"status\": \"completed\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "}";

        private const string PlayAudioResponsePayload = "{" +
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
                                                "\"operationId\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultDetails\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string TransferCallResultPayload = "{" +
                                                "\"operationId\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultDetails\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        private const string GetCallResultPayload = "{" +
                                                "\"callConnectionId\": \"af50dd7b-37e7-4cdb-a176-a7c37b71098a\"," +
                                                "\"targets\": [" +
                                                   "{" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"communicationUser\": {" +
                                                            "\"id\": \"a795d01f-f9ad-45e6-99c4-14bf8449ad4b\"" +
                                                            "}" +
                                                    "}," +
                                                   "{" +
                                                        "\"rawId\": \"dummyRawId1\"," +
                                                        "\"phoneNumber\": {" +
                                                            "\"value\": \"+1555123456\"" +
                                                            "}" +
                                                    "}" +
                                                "]," +
                                                "\"source\": {" +
                                                    "\"rawId\": \"dummyRawId\"," +
                                                    "\"communicationUser\": {" +
                                                            "\"id\": \"0000000d-5a5f-2db9-ccd7-44482200049a\"" +
                                                        "}" +
                                                "}," +
                                                "\"callConnectionState\": \"connected\"," +
                                                "\"subject\": \"dummySubject\"," +
                                                "\"callbackUri\": \"https://callBackUri.local\"," +
                                                "\"requestedMediaTypes\": [" +
                                                    "\"audio\"," +
                                                    "\"video\"" +
                                                "]," +
                                                "\"requestedCallEvents\": [" +
                                                    "\"participantsUpdated\"" +
                                                "]," +
                                                "\"callLocator\": {" +
                                                "\"serverCallId\": \"c07910ba-733a-4848-9e3b-0ec204c8ea34\"," +
                                                        "\"kind\": \"serverCallLocator\"" +
                                                    "}" +
                                                "}";

        private const string GetParticipantsResultPayload = "[" +
                                                "{" +
                                                    "\"identifier\": {" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"communicationUser\": {" +
                                                                "\"id\": \"0000000d-5a5f-2db9-ccd7-44482200049a\"" +
                                                            "}" +
                                                    "}," +
                                                    "\"isMuted\": false" +
                                                "}," +
                                                "{" +
                                                    "\"identifier\": {" +
                                                        "\"rawId\": \"dummyRawId\"," +
                                                        "\"phoneNumber\": {" +
                                                                "\"value\": \"+1555123456\"" +
                                                            "}" +
                                                    "}," +
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
                                                    "\"isMuted\": false" +
                                                "}";

        private const string CreateAudioGroupResultPayload = "{" +
                                                                "\"audioRoutingGroupId\": \"dummyAudioGroupId\"" +
                                                            "}";

        private const string GetAudioGroupsResultPayload = "{" +
                                                                "\"targets\": [" +
                                                                   "{" +
                                                                        "\"rawId\": \"dummyRawId\"," +
                                                                        "\"communicationUser\": {" +
                                                                            "\"id\": \"a795d01f-f9ad-45e6-99c4-14bf8449ad4b\"" +
                                                                            "}" +
                                                                    "}," +
                                                                   "{" +
                                                                        "\"rawId\": \"dummyRawId1\"," +
                                                                        "\"phoneNumber\": {" +
                                                                            "\"value\": \"+1555123456\"" +
                                                                            "}" +
                                                                    "}" +
                                                                "]," +
                                                                "\"audioRoutingMode\": \"oneToOne\"" +
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
        public async Task DeleteCallAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.DeleteAsync().ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void DeleteCall_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.Delete();
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void DeleteCallAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.DeleteAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void DeleteCall_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.Delete());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task CancelAllMediaOperationsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var response = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void CancelAllMediaOperations_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var response = callConnection.CancelAllMediaOperations();
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
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
        public async Task AddParticipantsAsync_Passes(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyId", response.Value.OperationId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Passes(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantResultPayload);

            var response = callConnection.AddParticipant(participant, alternateCallerId, operationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("dummyId", response.Value.OperationId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipantsAsync_Failed(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Failed(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipant(participant, alternateCallerId, operationContext));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferToParticipant))]
        public async Task TransferToParticipantAsync_Passes(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = await callConnection.TransferToParticipantAsync(participant, alternateCallerId, userToUserInformation).ConfigureAwait(false);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_TransferToParticipant))]
        public void TransferToParticipant_Passes(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = callConnection.TransferToParticipant(participant, alternateCallerId, userToUserInformation);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_TransferToParticipant))]
        public void TransferToParticipantAsync_Failed(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferToParticipantAsync(participant, alternateCallerId, userToUserInformation).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferToParticipant))]
        public void TransferToParticipant_Failed(CommunicationIdentifier participant, PhoneNumberIdentifier alternateCallerId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferToParticipant(participant, alternateCallerId, userToUserInformation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferToCall))]
        public async Task TransferToCallAsync_Passes(string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = await callConnection.TransferToCallAsync(targetCallConnectionId, userToUserInformation).ConfigureAwait(false);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_TransferToCall))]
        public void TransferToCall_Passes(string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = callConnection.TransferToCall(targetCallConnectionId, userToUserInformation);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_TransferToCall))]
        public void TransferToCallAsync_Failed(string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferToCallAsync(targetCallConnectionId, userToUserInformation).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferToCall))]
        public void TransferToCall_Failed(string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferToCall(targetCallConnectionId, userToUserInformation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task GetCallAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetCallResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.GetCallAsync().ConfigureAwait(false);
            VerifyGetCallResult(result);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetCall_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetCallResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.GetCall();
            VerifyGetCallResult(result);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetCallAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetCallAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetCall_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetCall());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task GetParticipantsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.GetParticipantsAsync().ConfigureAwait(false);
            VerifyGetParticipantsResult(result.Value.ToList());
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetParticipants_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.GetParticipants();
            VerifyGetParticipantsResult(result.Value.ToList());
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetParticipantsAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantsAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetParticipants_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipants());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task GetParticipantAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantResultPayload, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = await callConnection.GetParticipantAsync(participant).ConfigureAwait(false);
            VerifyGetParticipantResult(result.Value);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void GetParticipant_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantResultPayload, callConnectionId: callConnectionId);
            var participant = new CommunicationUserIdentifier(participantUserId);

            var result = callConnection.GetParticipant(participant);
            VerifyGetParticipantResult(result.Value);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void GetParticipantAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void GetParticipant_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);
            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participant));
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

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task KeepAliveAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsResultPayload, callConnectionId: callConnectionId);

            var response = await callConnection.KeepAliveAsync().ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void KeepAlive_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsResultPayload, callConnectionId: callConnectionId);

            var response = callConnection.KeepAlive();
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void KeepAliveAsync_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.KeepAliveAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void KeepAlive_Failed(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.KeepAlive());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantFromDefaultAudioGroupAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.RemoveParticipantFromDefaultAudioGroupAsync(participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantFromDefaultAudioGroup_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = callConnection.RemoveParticipantFromDefaultAudioGroup(participant);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantFromDefaultAudioGroupAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantFromDefaultAudioGroupAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipantFromDefaultAudioGroup_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipantFromDefaultAudioGroup(participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task AddParticipantToDefaultAudioGroupAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.AddParticipantToDefaultAudioGroupAsync(participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void AddParticipantToDefaultAudioGroup_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = callConnection.AddParticipantToDefaultAudioGroup(participant);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void AddParticipantToDefaultAudioGroupAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantToDefaultAudioGroupAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void AddParticipantToDefaultAudioGroup_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipantToDefaultAudioGroup(participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public async Task CreateAudioGroupAsync_Passes(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(201, CreateAudioGroupResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.CreateAudioGroupAsync(audioRoutingMode, targets).ConfigureAwait(false);
            Assert.IsNotEmpty(result.Value.AudioGroupId);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public void CreateAudioGroup_Passes(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(201, CreateAudioGroupResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.CreateAudioGroup(audioRoutingMode, targets);
            Assert.IsNotEmpty(result.Value.AudioGroupId);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public void CreateAudioGroupAsync_Failed(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.CreateAudioGroupAsync(audioRoutingMode, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public void CreateAudioGroup_Failed(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.CreateAudioGroup(audioRoutingMode, targets));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public void CreateAudioGroupAsync_FailedWithMode(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);
            audioRoutingMode = AudioRoutingMode.OneToOne;
            ArgumentOutOfRangeException? ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await callConnection.CreateAudioGroupAsync(audioRoutingMode, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
        }

        [TestCaseSource(nameof(TestData_CreateAudioGroup))]
        public void CreateAudioGroup_FailedWithMode(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);
            audioRoutingMode = AudioRoutingMode.OneToOne;
            ArgumentOutOfRangeException? ex = Assert.Throws<ArgumentOutOfRangeException>(() => callConnection.CreateAudioGroup(audioRoutingMode, targets));
            Assert.NotNull(ex);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioGroup))]
        public async Task UpdateAudioGroupAsync_Passes(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = await callConnection.UpdateAudioGroupAsync(audioRoutingGroupId, targets).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioGroup))]
        public void UpdateAudioGroup_Passes(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = callConnection.UpdateAudioGroup(audioRoutingGroupId, targets);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioGroup))]
        public void UpdateAudioGroupAsync_Failed(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.UpdateAudioGroupAsync(audioRoutingGroupId, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioGroup))]
        public void UpdateAudioGroup_Failed(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.UpdateAudioGroup(audioRoutingGroupId, targets));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetAudioGroups))]
        public async Task GetAudioGroupsAsync_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, GetAudioGroupsResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.GetAudioGroupsAsync(audioRoutingGroupId).ConfigureAwait(false);
            VerifyGetAudioGroupsResult(result);
        }

        [TestCaseSource(nameof(TestData_GetAudioGroups))]
        public void GetAudioGroups_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, GetAudioGroupsResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.GetAudioGroups(audioRoutingGroupId);
            VerifyGetAudioGroupsResult(result);
        }

        [TestCaseSource(nameof(TestData_GetAudioGroups))]
        public void GetAudioGroupsAsync_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetAudioGroupsAsync(audioRoutingGroupId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetAudioGroups))]
        public void GetAudioGroups_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetAudioGroups(audioRoutingGroupId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioGroup))]
        public async Task DeleteAudioGroupAsync_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = await callConnection.DeleteAudioGroupAsync(audioRoutingGroupId).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioGroup))]
        public void DeleteAudioGroup_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = callConnection.DeleteAudioGroup(audioRoutingGroupId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioGroup))]
        public void DeleteAudioGroupAsync_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.DeleteAudioGroupAsync(audioRoutingGroupId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioGroup))]
        public void DeleteAudioGroup_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.DeleteAudioGroup(audioRoutingGroupId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        private void VerifyPlayAudioResult(PlayAudioResult result)
        {
            Assert.AreEqual("dummyId", result.OperationId);
            Assert.AreEqual(CallingOperationStatus.Running, result.Status);
            Assert.AreEqual("dummyOperationContext", result.OperationContext);
            Assert.AreEqual(200, result.ResultDetails.Code);
            Assert.AreEqual("dummyMessage", result.ResultDetails.Message);
        }
        private void VerifyTransferCallResult(TransferCallResult result)
        {
            Assert.AreEqual("dummyId", result.OperationId);
            Assert.AreEqual(CallingOperationStatus.Running, result.Status);
            Assert.AreEqual("dummyOperationContext", result.OperationContext);
            Assert.AreEqual(200, result.ResultDetails.Code);
            Assert.AreEqual("dummyMessage", result.ResultDetails.Message);
        }

        private void VerifyGetCallResult(CallConnectionProperties result)
        {
            Assert.NotNull(result);
            Assert.True(result.Source is CommunicationUserIdentifier);
            Assert.NotNull(result.Targets);
            Assert.AreEqual(2, result.Targets.ToList().Count);
            Assert.True(result.Targets.ElementAt(0) is CommunicationUserIdentifier);
            Assert.True(result.Targets.ElementAt(1) is PhoneNumberIdentifier);
            Assert.True(result.CallLocator is ServerCallLocator);
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

        private void VerifyGetAudioGroupsResult(AudioGroupResult result)
        {
            Assert.NotNull(result);
            Assert.AreEqual(AudioRoutingMode.OneToOne, result.AudioRoutingMode);
            Assert.NotNull(result.Targets);
            Assert.AreEqual(2, result.Targets.ToList().Count);
            Assert.True(result.Targets.ElementAt(0) is CommunicationUserIdentifier);
            Assert.True(result.Targets.ElementAt(1) is PhoneNumberIdentifier);
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
                    new PhoneNumberIdentifier("+14255550123"),
                    "dummycontext"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferToParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                    new PhoneNumberIdentifier("+14255550123"),
                    "dummyUserToUserInformation"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferToCall()
        {
            return new[]
            {
                new object?[]
                {
                    "targetCallConnectionId",
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

        private static IEnumerable<object?[]> TestData_CreateAudioGroup()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    AudioRoutingMode.Multicast,
                    new CommunicationIdentifier[]
                    {
                        new CommunicationUserIdentifier("8:acs:resource_target"),
                        new PhoneNumberIdentifier("+14255550123")
                    },
                },
            };
        }

        private static IEnumerable<object?[]> TestData_UpdateAudioGroup()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioGroupId",
                    new CommunicationIdentifier[]
                    {
                        new CommunicationUserIdentifier("8:acs:resource_target"),
                        new PhoneNumberIdentifier("+14255550123")
                    },
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetAudioGroups()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioGroupId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_DeleteAudioGroup()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioGroupId",
                },
            };
        }
    }
}
