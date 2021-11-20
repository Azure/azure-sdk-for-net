﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
                                                                "\"participantId\": \"dummyparticipantid\"" +
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

        private const string CreateAudioRoutingGroupResultPayload = "{" +
                                                                "\"audioRoutingGroupId\": \"dummyAudioRoutingGroupId\"" +
                                                            "}";

        private const string GetAudioRoutingGroupsResultPayload = "{" +
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

        [TestCaseSource(nameof(TestData_Transfer))]
        public async Task TransferAsync_Passes(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = await callConnection.TransferAsync(participant, targetCallConnectionId, userToUserInformation).ConfigureAwait(false);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_Transfer))]
        public void Transfer_Passes(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallResultPayload);

            var result = callConnection.Transfer(participant, targetCallConnectionId, userToUserInformation);
            VerifyTransferCallResult(result);
        }

        [TestCaseSource(nameof(TestData_Transfer))]
        public void TransferAsync_Failed(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferAsync(participant, targetCallConnectionId, userToUserInformation).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_Transfer))]
        public void Transfer_Failed(CommunicationIdentifier participant, string targetCallConnectionId, string userToUserInformation)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.Transfer(participant, targetCallConnectionId, userToUserInformation));
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
        public async Task HoldParticipantMeetingAudioAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.HoldParticipantMeetingAudioAsync(participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void HoldParticipantMeetingAudio_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = callConnection.HoldParticipantMeetingAudio(participant);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void HoldParticipantMeetingAudioAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HoldParticipantMeetingAudioAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void HoldParticipantMeetingAudio_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.HoldParticipantMeetingAudio(participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task ResumeParticipantMeetingAudioAsync_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.ResumeParticipantMeetingAudioAsync(participant).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void ResumeParticipantMeetingAudio_Passes(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = callConnection.ResumeParticipantMeetingAudio(participant);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void ResumeParticipantMeetingAudioAsync_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.ResumeParticipantMeetingAudioAsync(participant).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void ResumeParticipantMeetingAudio_Failed(string callConnectionId, string participantUserId)
        {
            var callConnection = CreateMockCallConnection(404);

            var participant = new CommunicationUserIdentifier(participantUserId);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.ResumeParticipantMeetingAudio(participant));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public async Task CreateAudioRoutingGroupAsync_Passes(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(201, CreateAudioRoutingGroupResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.CreateAudioRoutingGroupAsync(audioRoutingMode, targets).ConfigureAwait(false);
            Assert.IsNotEmpty(result.Value.AudioRoutingGroupId);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public void CreateAudioRoutingGroup_Passes(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(201, CreateAudioRoutingGroupResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.CreateAudioRoutingGroup(audioRoutingMode, targets);
            Assert.IsNotEmpty(result.Value.AudioRoutingGroupId);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public void CreateAudioRoutingGroupAsync_Failed(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.CreateAudioRoutingGroupAsync(audioRoutingMode, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public void CreateAudioRoutingGroup_Failed(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.CreateAudioRoutingGroup(audioRoutingMode, targets));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public void CreateAudioRoutingGroupAsync_FailedWithMode(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);
            audioRoutingMode = AudioRoutingMode.OneToOne;
            ArgumentOutOfRangeException? ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await callConnection.CreateAudioRoutingGroupAsync(audioRoutingMode, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
        }

        [TestCaseSource(nameof(TestData_CreateAudioRoutingGroup))]
        public void CreateAudioRoutingGroup_FailedWithMode(string callConnectionId, AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);
            audioRoutingMode = AudioRoutingMode.OneToOne;
            ArgumentOutOfRangeException? ex = Assert.Throws<ArgumentOutOfRangeException>(() => callConnection.CreateAudioRoutingGroup(audioRoutingMode, targets));
            Assert.NotNull(ex);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioRoutingGroup))]
        public async Task UpdateAudioRoutingGroupAsync_Passes(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = await callConnection.UpdateAudioRoutingGroupAsync(audioRoutingGroupId, targets).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioRoutingGroup))]
        public void UpdateAudioRoutingGroup_Passes(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(200, callConnectionId: callConnectionId);

            var response = callConnection.UpdateAudioRoutingGroup(audioRoutingGroupId, targets);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioRoutingGroup))]
        public void UpdateAudioRoutingGroupAsync_Failed(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.UpdateAudioRoutingGroupAsync(audioRoutingGroupId, targets).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_UpdateAudioRoutingGroup))]
        public void UpdateAudioRoutingGroup_Failed(string callConnectionId, string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.UpdateAudioRoutingGroup(audioRoutingGroupId, targets));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetAudioRoutingGroups))]
        public async Task GetAudioRoutingGroupsAsync_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, GetAudioRoutingGroupsResultPayload, callConnectionId: callConnectionId);

            var result = await callConnection.GetAudioRoutingGroupsAsync(audioRoutingGroupId).ConfigureAwait(false);
            VerifyGetAudioRoutingGroupsResult(result);
        }

        [TestCaseSource(nameof(TestData_GetAudioRoutingGroups))]
        public void GetAudioRoutingGroups_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(200, GetAudioRoutingGroupsResultPayload, callConnectionId: callConnectionId);

            var result = callConnection.GetAudioRoutingGroups(audioRoutingGroupId);
            VerifyGetAudioRoutingGroupsResult(result);
        }

        [TestCaseSource(nameof(TestData_GetAudioRoutingGroups))]
        public void GetAudioRoutingGroupsAsync_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetAudioRoutingGroupsAsync(audioRoutingGroupId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetAudioRoutingGroups))]
        public void GetAudioRoutingGroups_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetAudioRoutingGroups(audioRoutingGroupId));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioRoutingGroup))]
        public async Task DeleteAudioRoutingGroupAsync_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.DeleteAudioRoutingGroupAsync(audioRoutingGroupId).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioRoutingGroup))]
        public void DeleteAudioRoutingGroup_Passes(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.DeleteAudioRoutingGroup(audioRoutingGroupId);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.Status);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioRoutingGroup))]
        public void DeleteAudioRoutingGroupAsync_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.DeleteAudioRoutingGroupAsync(audioRoutingGroupId).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_DeleteAudioRoutingGroup))]
        public void DeleteAudioRoutingGroup_Failed(string callConnectionId, string audioRoutingGroupId)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.DeleteAudioRoutingGroup(audioRoutingGroupId));
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

        private void VerifyGetAudioRoutingGroupsResult(AudioRoutingGroupResult result)
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
                    "+14250000000",
                    "dummycontext"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_Transfer()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
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

        private static IEnumerable<object?[]> TestData_CreateAudioRoutingGroup()
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

        private static IEnumerable<object?[]> TestData_UpdateAudioRoutingGroup()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioRoutingGroupId",
                    new CommunicationIdentifier[]
                    {
                        new CommunicationUserIdentifier("8:acs:resource_target"),
                        new PhoneNumberIdentifier("+14255550123")
                    },
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetAudioRoutingGroups()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioRoutingGroupId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_DeleteAudioRoutingGroup()
        {
            return new[]
            {
                new object?[]
                {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "dummyAudioRoutingGroupId",
                },
            };
        }
    }
}
