// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallConnectionTests : CallAutomationTestBase
    {
        private const string TransferCallOrRemoveParticipantsPayload = "{" +
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task GetCallConnectionPropertiesAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallConnectionProperties_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callConnection.GetCallConnectionProperties();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response);
        }
        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallConnectionPropertiesAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallConnectionProperties_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetCallConnectionProperties());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task HangupCallAsync_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = await callConnection.HangUpAsync(false).ConfigureAwait(false);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void HangupCall_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = callConnection.HangUp(false);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void HangUpCallAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HangUpAsync(false).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void HangUpCall_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.HangUp(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task TransferCallToParticipantAsync_202Accepted(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallOrRemoveParticipantsPayload);

            var response = await callConnection.TransferCallToParticipantAsync(targetParticipant).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void TransferCallToParticipant_202Accepted(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallOrRemoveParticipantsPayload);

            var response = callConnection.TransferCallToParticipant(targetParticipant);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void TransferCallToParticipantAsync_404NotFound(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(targetParticipant).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void TransferCallToParticipant_404NotFound(CommunicationIdentifier targetParticipant)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(targetParticipant));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task AddParticipantsAsync_202Accepted(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var response = await callConnection.AddParticipantsAsync(participantsToAdd).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AddParticipants_202Accepted(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantsPayload);

            var response = callConnection.AddParticipants(participantsToAdd);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AddParticipantsAsync_404NotFound(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantsAsync(participantsToAdd).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AddParticipants_404NotFound(CommunicationIdentifier[] participantsToAdd)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipants(participantsToAdd));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task GetParticipantAsync_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);

            var response = await callConnection.GetParticipantAsync(participantMri).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipant_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);

            var response = callConnection.GetParticipant(participantMri);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipantAsync_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participantMri).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipant_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participantMri));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task GetParticipantsAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipants_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = callConnection.GetParticipants();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipantsAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantsAsync().ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetParticipants_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipants());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RemoveParticipantsAsync_202Accepted(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallOrRemoveParticipantsPayload);

            var response = await callConnection.RemoveParticipantsAsync(participants).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
                Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
            });
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RemoveParticipants_202Accepted(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(202, TransferCallOrRemoveParticipantsPayload);

            var response = callConnection.RemoveParticipants(participants);
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
                Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
            });
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RemoveParticipantsAsync_404NotFound(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantsAsync(participants).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipants))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RemoveParticipants_404NotFound(CommunicationIdentifier[] participants)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipants(participants));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void GetCallMediaTest()
        {
            var connectionId = "someId";
            var callConnection = CreateMockCallConnection(200, null, connectionId);

            var response = callConnection.GetCallMedia();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.CallConnectionId, Is.EqualTo(connectionId));
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

        private void verifyOperationContext(TransferCallToParticipantResult result)
        {
            Assert.That(result.OperationContext, Is.EqualTo(OperationContext));
        }

        private void verifyAddParticipantsResult(AddParticipantsResult result)
        {
            Assert.That(result.Participants, Has.Count.EqualTo(2));
            var identifier = (CommunicationUserIdentifier) result.Participants[0].Identifier;
            Assert.Multiple(() =>
            {
                Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
                Assert.That(result.Participants[0].IsMuted, Is.False);
            });
            var identifier2 = (PhoneNumberIdentifier) result.Participants[1].Identifier;
            Assert.Multiple(() =>
            {
                Assert.That(identifier2.PhoneNumber, Is.EqualTo(PhoneNumber));
                Assert.That(result.Participants[1].IsMuted, Is.True);

                Assert.That(result.OperationContext, Is.EqualTo(OperationContext));
            });
        }

        private void verifyGetParticipantResult(CallParticipant participant)
        {
            var identifier = (CommunicationUserIdentifier)participant.Identifier;
            Assert.Multiple(() =>
            {
                Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
                Assert.That(participant.IsMuted, Is.False);
            });
        }

        private void verifyGetParticipantsResult(IReadOnlyList<CallParticipant> participants)
        {
            Assert.That(participants, Has.Count.EqualTo(2));
            var identifier = (CommunicationUserIdentifier)participants[0].Identifier;
            Assert.Multiple(() =>
            {
                Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
                Assert.That(participants[0].IsMuted, Is.False);
            });
            var identifier2 = (PhoneNumberIdentifier)participants[1].Identifier;
            Assert.Multiple(() =>
            {
                Assert.That(identifier2.PhoneNumber, Is.EqualTo(PhoneNumber));
                Assert.That(participants[1].IsMuted, Is.True);
            });
        }
    }
}
