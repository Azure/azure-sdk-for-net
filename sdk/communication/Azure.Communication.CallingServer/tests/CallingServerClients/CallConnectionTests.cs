// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallConnectionTests
    {
        private const string connectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";

        private const string CancelAllMediaOperaionsResponsePayload  = "{" +
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

        private const string GetParticipantPayload1 = "{ \"identifier\": {\"rawId\": \"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\",  \"communicationUser\": {\"id\":\"8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d371\"}}, \"participantId\": \"ef70f6b0-c052-4ab7-9fdc-2dedb5fd16ac\", \"isMuted\": true }";

        private const string GetParticipantPayload2 = "{ \"identifier\": {\"rawId\": \"4:+14251234567\",  \"phoneNumber\": {\"value\":\"+14251234567\"}}, \"participantId\": \"e44ca273-079f-4759-8d6e-284ee8322625\", \"isMuted\": false }";

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task DeleteCallAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.DeleteAsync().ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void DeleteCall_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.Delete();

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task HangupCallAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.HangupAsync().ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void HangupCall_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.Hangup();

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task CancelAllMediaOperationsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var response = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);

            VerifyCancelAllMediaOperationsResponse(response);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void CancelAllMediaOperations_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, CancelAllMediaOperaionsResponsePayload, callConnectionId: callConnectionId);

            var response = callConnection.CancelAllMediaOperations();

            VerifyCancelAllMediaOperationsResponse(response);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var response = await callConnection.PlayAudioAsync(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext).ConfigureAwait(false);

            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Passes(Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            var callConnection = CreateMockCallConnection(202, PlayAudioResponsePayload);

            var response = callConnection.PlayAudio(sampleAudioFileUri, false, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);

            VerifyPlayAudioResponse(response);
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

            var response = await callConnection.PlayAudioAsync(playAudio).ConfigureAwait(false);

            VerifyPlayAudioResponse(response);
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

            var response = callConnection.PlayAudio(playAudio);

            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public async Task AddParticipantsAsync_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202);

            var response = await callConnection.AddParticipantAsync(participant, alternateCallerId, operationContext).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_AddParticipant))]
        public void AddParticipants_Passes(CommunicationIdentifier participant, string alternateCallerId, string operationContext)
        {
            var callConnection = CreateMockCallConnection(202);

            var response = callConnection.AddParticipant(participant, alternateCallerId, operationContext);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public async Task RemoveParticipantsAsync_Passes(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = await callConnection.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_ParticipantId))]
        public void RemoveParticipants_Passes(string callConnectionId, string participantId)
        {
            var callConnection = CreateMockCallConnection(202, callConnectionId: callConnectionId);

            var response = callConnection.RemoveParticipant(participantId);

            Assert.AreEqual((int)response.Status, 202);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task GetCallConnectionDetailsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetCallConnectionDetailsPayload, callConnectionId: callConnectionId);

            var response = await callConnection.GetDetailsAsync().ConfigureAwait(false);

            VerifyCallConnectionDetails(response);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetCallConnectionDetails_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetCallConnectionDetailsPayload, callConnectionId: callConnectionId);

            var response = callConnection.GetDetails();

            VerifyCallConnectionDetails(response);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public async Task GetParticipantsAsync_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload, callConnectionId: callConnectionId);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);

            VerifyParticipantsResponse(response.Value);
        }

        [TestCaseSource(nameof(TestData_CallConnectionId))]
        public void GetParticipants_Passes(string callConnectionId)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload, callConnectionId: callConnectionId);

            var response = callConnection.GetParticipants();

            VerifyParticipantsResponse(response.Value);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_Passes(string callConnectionId, string participantId, string payload, int participantNumber)
        {
            var callConnection = CreateMockCallConnection(200, payload, callConnectionId: callConnectionId);

            var response = await callConnection.GetParticipantAsync(participantId).ConfigureAwait(false);

            VerifyParticipantResponse(response.Value, participantNumber);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_Passes(string callConnectionId, string participantId, string payload, int participantNumber)
        {
            var callConnection = CreateMockCallConnection(200, payload, callConnectionId: callConnectionId);

            var response = callConnection.GetParticipant(participantId);

            VerifyParticipantResponse(response.Value, participantNumber);
        }

        private void VerifyCancelAllMediaOperationsResponse(CancelAllMediaOperationsResponse response)
        {
            Assert.AreEqual("dummyId", response.Id);
            Assert.AreEqual(OperationStatus.Completed, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", response.ResultInfo.Message);
        }

        private void VerifyPlayAudioResponse(PlayAudioResponse response)
        {
            Assert.AreEqual("dummyId", response.Id);
            Assert.AreEqual(OperationStatus.Running, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", response.ResultInfo.Message);
        }

        private void VerifyCallConnectionDetails(CallConnectionDetails response)
        {
            Assert.AreEqual("411f6d00-1d3f-425b-9d7d-df971f16564b", response.CallConnectionId);
            Assert.AreEqual(CallState.Establishing, response.CallState);
            Assert.AreEqual("https://bot.contoso.io/callback", response.CallbackUri.ToString());
            Assert.AreEqual("testsubject", response.Subject);
            Assert.AreEqual("8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000008-ddad-a008-b8ba-a43a0d00d376", ((CommunicationUserIdentifier) response.Source).Id);
            Assert.AreEqual("8:acs:024a7064-0581-40b9-be73-6dde64d69d89_00000009-9189-b73c-edbe-a43a0d0050e3", ((CommunicationUserIdentifier)response.Targets.First()).Id);
            Assert.AreEqual(1, response.RequestedMediaTypes.Where(f => f == CallModality.Audio).Count());
            Assert.AreEqual(1, response.RequestedMediaTypes.Where(f => f == CallModality.Video).Count());
            Assert.AreEqual(1, response.RequestedCallEvents.Where(f => f == EventSubscriptionType.DtmfReceived).Count());
            Assert.AreEqual(0, response.RequestedCallEvents.Where(f => f == EventSubscriptionType.ParticipantsUpdated).Count());
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

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallingServerClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }

        private static IEnumerable<object?[]> TestData_CallConnectionId()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudio()
        {
            return new List<object?[]>(){
                new object?[] {
                    new Uri("https://bot.contoso.io/audio/sample-message.wav"),
                    "sampleAudioFileId",
                    new Uri("https://bot.contoso.io/callback"),
                    "sampleOperationContext",
                }
            };
        }

        private static IEnumerable<object?[]> TestData_AddParticipant()
        {
            return new List<object?[]>(){
                new object?[] {
                    new CommunicationUserIdentifier("8:acs:acsuserid"),
                    "+14250000000",
                    "dummycontext"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_ParticipantId()
        {
            return new List<object?[]>(){
                new object?[] {
                    "d09038e7-38f7-4aa1-9c5c-4bb07a65aa17",
                    "66c76529-3e58-45bf-9592-84eadd52bc81"
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
    }
}
