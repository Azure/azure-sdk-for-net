// Copyright (c) Microsoft Corporation. All rights reserved.
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

        private const string AddParticipantsPayload = "{" +
            "\"participants\":[" +
               "{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false}," +
               "{\"identifier\":{\"rawId\":\"participantId2\",\"kind\":\"phoneNumber\",\"phoneNumber\":{\"value\":\"+11234567\"}},\"isMuted\":true}" +
            "]," +
            "\"operationContext\":\"someOperationContext\"" +
            "}";

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
        public async Task TransferCallToParticipantAsync_202Accepted(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(targetParticipant)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_202Accepted(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(targetParticipant));
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantAsync_404NotFound(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(targetParticipant)).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_404NotFound(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(targetParticipant)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_NoCallerId))]
        public void TransferCallToParticipant_NoCallerIdValidation(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202);

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(targetParticipant)));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains("Value cannot be null."));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_ExceedsMaxOperationContextLength(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202);

            var options = new TransferToParticipantOptions(targetParticipant) {
                OperationContext = new string('a', 1 + CallAutomationConstants.InputValidation.StringMaxLength)
            };
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => callConnection.TransferCallToParticipant(options));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.OperationContextExceedsMaxLength));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_ExceedsMaxUserToUserInformationLengthLength(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202);

            var options = new TransferToParticipantOptions(targetParticipant)
            {
                UserToUserInformation = new string('a', 1 + CallAutomationConstants.InputValidation.StringMaxLength)
            };
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => callConnection.TransferCallToParticipant(options));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.UserToUserInformationExceedsMaxLength));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public async Task AddParticipantsAsync_202Accepted(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var response = await callConnection.AddParticipantsAsync(new AddParticipantsOptions(participantsToAdd)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void AddParticipants_202Accepted(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var response = callConnection.AddParticipants(new AddParticipantsOptions(participantsToAdd));
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [Test]
        public void AddParticipantsAsync_EmptyParticipantsToAdd()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.AddParticipantsAsync(new AddParticipantsOptions(new CommunicationIdentifier[] { })).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains("Value cannot be an empty collection."));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void AddParticipantsAsync_ExceedsInvitationTimeOut(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var options = new AddParticipantsOptions(participantsToAdd) {
                InvitationTimeoutInSeconds = CallAutomationConstants.InputValidation.MaxInvitationTimeoutInSeconds + 1
            };
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.AddParticipantsAsync(options).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void AddParticipantsAsync_NegativeInvitationTimeOut(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var options = new AddParticipantsOptions(participantsToAdd)
            {
                InvitationTimeoutInSeconds = 0
            };
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.AddParticipantsAsync(options).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void AddParticipantsAsync_404NotFound(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantsAsync(new AddParticipantsOptions(participantsToAdd)).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void AddParticipants_404NotFound(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipants(new AddParticipantsOptions(participantsToAdd)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipants_NoCallerId))]
        public void AddParticipants_NoCallerId(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(404);

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() => callConnection.AddParticipants(new AddParticipantsOptions(participantsToAdd)));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains("Value cannot be null."));
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);

            var response = await callConnection.GetParticipantAsync(participantMri).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);

            var response = callConnection.GetParticipant(participantMri);
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipantAsync_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participantMri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participantMri));
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

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public async Task RemoveParticipantsAsync_202Accepted(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.RemoveParticipantsAsync(participants).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void RemoveParticipants_202Accepted(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.RemoveParticipants(participants);
            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [Test]
        public void RemoveParticipants_EmptyParticipantsToRemove()
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.RemoveParticipantsAsync(new CommunicationIdentifier[] { }).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains("Value cannot be an empty collection."));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void RemoveParticipants_ExceedsMaxOperationContextLength(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var operationContext = new string('a', 1 + CallAutomationConstants.InputValidation.StringMaxLength);
            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(async () => await callConnection.RemoveParticipantsAsync(participants, operationContext).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.True(ex?.Message.Contains(CallAutomationErrorMessages.OperationContextExceedsMaxLength));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void RemoveParticipantsAsync_404NotFound(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantsAsync(participants).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        public void RemoveParticipants_404NotFound(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipants(participants));
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
                    new CommunicationUserIdentifier("userId")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant_NoCallerId()
        {
            return new[]
            {
                new object?[]
                {
                    new PhoneNumberIdentifier("+123456")
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

        private static IEnumerable<object?[]> TestData_AddOrRemoveParticipants()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationIdentifier[] { new CommunicationUserIdentifier("userId"), new CommunicationUserIdentifier("userId2") }
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AddParticipants_NoCallerId()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationIdentifier[] { new CommunicationUserIdentifier("userId"), new PhoneNumberIdentifier("+1234567") }
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

        private void verifyAddParticipantsResult(AddParticipantsResult result)
        {
            Assert.AreEqual(2, result.Participants.Count);
            var identifier = (CommunicationUserIdentifier) result.Participants[0].Identifier;
            Assert.AreEqual(ParticipantUserId, identifier.Id);
            Assert.IsFalse(result.Participants[0].IsMuted);
            var identifier2 = (PhoneNumberIdentifier) result.Participants[1].Identifier;
            Assert.AreEqual(PhoneNumber, identifier2.PhoneNumber);
            Assert.IsTrue(result.Participants[1].IsMuted);

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
