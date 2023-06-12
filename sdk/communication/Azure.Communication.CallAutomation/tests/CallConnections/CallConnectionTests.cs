﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using System;

namespace Azure.Communication.CallAutomation.Tests.CallConnections
{
    public class CallConnectionTests : CallAutomationTestBase
    {
        private const string OperationContextPayload = "{" +
                                        "\"operationContext\": \"someOperationContext\"" +
                                        "}";

        private const string AddParticipantPayload = "{\"participant\":{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false},\"operationContext\":\"someOperationContext\"}";

        private const string GetParticipantPayload = "{" +
            "\"identifier\":{" +
            "\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}" +
            "}," +
            "\"isMuted\":false" +
            "}";

        private const string GetParticipantsPayload = "{" +
            "\"values\":[" +
               "{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false}," +
               "{\"identifier\":{\"rawId\":\"participantId2\",\"kind\":\"phoneNumber\",\"phoneNumber\":{\"value\":\"+11234567\"}},\"isMuted\":true}" +
               "]" +
            "}";

        private const string OperationContext = "someOperationContext";
        private const string ParticipantUserId = "participantId1";
        private const string PhoneNumber = "+11234567";

        [Test]
        public async Task GetCallConnectionPropertiesAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response);
        }

        [Test]
        public void GetCallConnectionProperties_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callConnection.GetCallConnectionProperties();

            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response);
        }
        [Test]
        public void GetCallConnectionPropertiesAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetCallConnectionProperties_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetCallConnectionProperties());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public async Task HangupCallAsync_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = await callConnection.HangUpAsync(false).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [Test]
        public void HangupCall_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = callConnection.HangUp(false);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [Test]
        public void HangUpCallAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HangUpAsync(false).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void HangUpCall_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.HangUp(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantAsync_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_ExceedsMaxOperationContextLength(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202);

            var options = new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier) {
                OperationContext = new string('a', 1 + CallAutomationConstants.InputValidation.StringMaxLength)
            };
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => callConnection.TransferCallToParticipant(options));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.OperationContextExceedsMaxLength));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task AddParticipantsAsync_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [Test]
        public void AddParticipantsAsync_NullParticipantToAdd()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(null)).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains("Value cannot be null."));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipantsAsync_ExceedsInvitationTimeOut(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var options = new AddParticipantOptions(callInvite) {
                InvitationTimeoutInSeconds = CallAutomationConstants.InputValidation.MaxInvitationTimeoutInSeconds + 1
            };
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.AddParticipantAsync(options).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipantsAsync_NegativeInvitationTimeOut(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var options = new AddParticipantOptions(callInvite)
            {
                InvitationTimeoutInSeconds = 0
            };
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.AddParticipantAsync(options).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipantsAsync_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipant(new AddParticipantOptions(callInvite)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = callConnection.GetParticipant(participantIdentifier);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipantAsync_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participantIdentifier));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public async Task GetParticipantsAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipants_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = callConnection.GetParticipants();
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipantsAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantsAsync().ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetParticipants_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipants());
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task RemoveParticipantsAsync_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.RemoveParticipant(participantToRemove);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_ExceedsMaxOperationContextLength(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var operationContext = new string('a', 1 + CallAutomationConstants.InputValidation.StringMaxLength);
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.RemoveParticipantAsync(participantToRemove, operationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.OperationContextExceedsMaxLength));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipantsAsync_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipant(participantToRemove));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetCallMediaTest()
        {
            var connectionId = "someId";
            var callConnection = CreateMockCallConnection(200, null, connectionId);

            var response = callConnection.GetCallMedia();
            Assert.IsNotNull(response);
            Assert.AreEqual(connectionId, response.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipant_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.MuteParticipants(participant, OperationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void UnmuteParticipant_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.UnmuteParticipants(participant, OperationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipant_WithOptions_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new MuteParticipantsOptions(new List<CommunicationIdentifier> { participant })
            {
                OperationContext = OperationContext
            };
            var response = callConnection.MuteParticipants(options);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void UnmuteParticipant_WithOptions_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new UnmuteParticipantsOptions(new List<CommunicationIdentifier> { participant })
            {
                OperationContext = OperationContext
            };

            var response = callConnection.UnmuteParticipants(options);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task MuteParticipantAsync_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.MuteParticipantsAsync(participant, OperationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [Test]
        public void MuteParticipantAsync_NotAcsUser_400BadRequest()
        {
            var callConnection = CreateMockCallConnection(400);
            var participant = new PhoneNumberIdentifier("+15559501234");
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantsAsync(participant, OperationContext));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task UnmuteParticipantAsync_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.UnmuteParticipantsAsync(participant, OperationContext);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [Test]
        public void UnmuteParticipantAsync_NotAcsUser_400BadRequest()
        {
            var callConnection = CreateMockCallConnection(400);
            var participant = new PhoneNumberIdentifier("+15559501234");
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.UnmuteParticipantsAsync(participant, OperationContext));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task MuteParticipantAsync_WithOptions_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new MuteParticipantsOptions(new List<CommunicationIdentifier> { participant })
            {
                OperationContext = OperationContext,
            };

            var response = await callConnection.MuteParticipantsAsync(options);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipantAsync_WithOptions_MoreThanOneParticipant_400BadRequest(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(400);
            var options = new MuteParticipantsOptions(new List<CommunicationIdentifier> { participant, participant })
            {
                OperationContext = OperationContext,
            };

            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantsAsync(options));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task UnmuteParticipantAsync_WithOptions_202Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new UnmuteParticipantsOptions(new List<CommunicationIdentifier> { participant })
            {
                OperationContext = OperationContext,
            };

            var response = await callConnection.UnmuteParticipantsAsync(options);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void UnmuteParticipantAsync_WithOptions_MoreThanOneParticipant_400BadRequest(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(400);
            var options = new UnmuteParticipantsOptions(new List<CommunicationIdentifier> { participant, participant })
            {
                OperationContext = OperationContext,
            };

            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.UnmuteParticipantsAsync(options));
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CallInvite(new CommunicationUserIdentifier("userId")){
                        VoipHeaders = {{ "key1", "value1" }}}
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    "somemri"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AddOrRemoveParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("userId")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_MuteParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("userId")
                },
            };
        }

        private void verifyOperationContext(TransferCallToParticipantResult result)
        {
            Assert.AreEqual(OperationContext, result.OperationContext);
        }

        private void verifyAddParticipantsResult(AddParticipantResult result)
        {
            var identifier = (CommunicationUserIdentifier) result.Participant.Identifier;
            Assert.AreEqual(ParticipantUserId, identifier.Id);
            Assert.IsFalse(result.Participant.IsMuted);
            Assert.AreEqual(OperationContext, result.OperationContext);
        }

        private void verifyGetParticipantResult(CallParticipant participant)
        {
            var identifier = (CommunicationUserIdentifier)participant.Identifier;
            Assert.AreEqual(ParticipantUserId, identifier.Id);
            Assert.IsFalse(participant.IsMuted);
        }

        private void verifyGetParticipantsResult(IReadOnlyList<CallParticipant> participants)
        {
            Assert.AreEqual(2, participants.Count);
            var identifier = (CommunicationUserIdentifier)participants[0].Identifier;
            Assert.AreEqual(ParticipantUserId, identifier.Id);
            Assert.IsFalse(participants[0].IsMuted);
            var identifier2 = (PhoneNumberIdentifier)participants[1].Identifier;
            Assert.AreEqual(PhoneNumber, identifier2.PhoneNumber);
            Assert.IsTrue(participants[1].IsMuted);
        }
    }
}
