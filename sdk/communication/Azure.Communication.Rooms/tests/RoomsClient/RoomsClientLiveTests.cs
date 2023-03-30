// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
#region Snippet:Azure_Communication_Rooms_Tests_UsingStatements
//@@ using Azure.Communication.Rooms
#endregion Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication.Rooms;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTests : RoomsClientLiveTestBase
    {
        public RoomsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestLiveWithoutParticipantsTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);
                var createdRoomId = createCommunicationRoom.Id;

                // Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                // List Rooms
                // TODO: add list rooms test

                // Update Room
                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom.AddDays(1), validUntil.AddDays(2));
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateCommunicationRoom.ValidFrom, validFrom.AddDays(1));
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, validUntil.AddDays(2));

                // Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                Assert.AreEqual(204, deleteRoomResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task AcsRoomLifeCycleLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                InvitedRoomParticipant participant1 = new InvitedRoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
                InvitedRoomParticipant participant2 = new InvitedRoomParticipant(communicationUser2);
                InvitedRoomParticipant participant3 = new InvitedRoomParticipant(communicationUser3) { Role = ParticipantRole.Consumer };

                List<InvitedRoomParticipant> createRoomParticipants = new List<InvitedRoomParticipant>
                {
                    participant1,
                    participant2
                };

                // Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                var createdRoomId = createCommunicationRoom.Id;

                // Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                // List Rooms
                // TODO: add list rooms test

                // Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil);

                // Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                Assert.AreEqual(204, deleteRoomResponse.Status);

                // Get Deleted Room
                RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync(createdRoomId));
                Assert.NotNull(ex);
                Assert.AreEqual(404, ex?.Status);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RoomParticipantsUpsertAndRemoveLiveTest()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);

            InvitedRoomParticipant participant1 = new InvitedRoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            InvitedRoomParticipant participant2 = new InvitedRoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter };
            InvitedRoomParticipant participant3 = new InvitedRoomParticipant(communicationUser3) { Role = ParticipantRole.Attendee };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants
                List<InvitedRoomParticipant> createRoomParticipants = new List<InvitedRoomParticipant>
                {
                    participant1,
                    participant2
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                var createdRoomId = createCommunicationRoom.Id;
                participant2 = new InvitedRoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };

                // Upsert room participants
                // participant2 updated from Presenter -> Consumer
                // participant3 added to the list
                List<InvitedRoomParticipant> toUpsertCommunicationUsers = new List<InvitedRoomParticipant>()
                {
                    participant2,
                    participant3
                };

                Response<UpsertParticipantsResult> upsertParticipantsResponse = await roomsClient.UpsertParticipantsAsync(createdRoomId, toUpsertCommunicationUsers);
                Assert.AreEqual(200, upsertParticipantsResponse.GetRawResponse().Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> upsertRoomParticipantsResult = await allParticipants.ToEnumerableAsync();
                Assert.AreEqual(3, upsertRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpsertParticipants to contain user1");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpsertParticipants to contain user2");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected UpsertParticipants to contain user3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Presenter), "Expected UpsertParticipants to contain Presenter");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Consumer), "Expected UpsertParticipants to contain Consumer");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Attendee), "Expected UpsertParticipants to contain Attendee");

                // Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };

                Response<RemoveParticipantsResult> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                Assert.AreEqual(200, removeParticipantsResponse.GetRawResponse().Status);

                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                Assert.AreEqual(204, deleteRoomResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task AcsRoomTimePartialUpdateLiveTest()
        {
            if (Mode != Core.TestFramework.RecordedTestMode.Playback)
            {
                RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);

                var validFrom = DateTime.UtcNow;
                var validUntil = validFrom.AddDays(1);

                try
                {
                    // Create Room
                    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom);
                    CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                    Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                    Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom.UtcDateTime);

                    var createdRoomId = createCommunicationRoom.Id;

                    // Update Room
                    Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                    CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                    Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                    Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom.UtcDateTime);
                    Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil.UtcDateTime);

                    Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                    Assert.AreEqual(204, deleteRoomResponse.Status);
                }
                catch (RequestFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    Assert.Fail($"Unexpected error: {ex}");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Unexpected error: {ex}");
                }
            }
        }
    }
}
