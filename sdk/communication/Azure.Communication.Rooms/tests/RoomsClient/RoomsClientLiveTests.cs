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
            // Arrange
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);
                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                // List Rooms
                // TODO: add list rooms test

                // Act: Update Room
                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom.AddDays(1), validUntil.AddDays(2));
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateCommunicationRoom.ValidFrom, validFrom.AddDays(1));
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, validUntil.AddDays(2));

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert:
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
            // Arrange
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

                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                // List Rooms
                // TODO: add list rooms test

                // Act Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil);

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert
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
            // Arrange
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

                // Act: Upsert room participants
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

                // Assert
                Assert.AreEqual(3, upsertRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpsertParticipants to contain user1");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpsertParticipants to contain user2");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected UpsertParticipants to contain user3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Presenter), "Expected UpsertParticipants to contain Presenter");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Consumer), "Expected UpsertParticipants to contain Consumer");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Attendee), "Expected UpsertParticipants to contain Attendee");

                // Arrange: Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                // Act
                Response<RemoveParticipantsResult> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.GetRawResponse().Status);

                // Clean up
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
        public async Task RoomParticipantsUpsertAndRemoveWithNullRolesLiveTest()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);

            InvitedRoomParticipant participant1 = new InvitedRoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            InvitedRoomParticipant participant2 = new InvitedRoomParticipant(communicationUser2);
            InvitedRoomParticipant participant3 = new InvitedRoomParticipant(communicationUser3) { Role = null };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants with null roles or roles undefined
                List<InvitedRoomParticipant> createRoomParticipants = new List<InvitedRoomParticipant>
                {
                    participant1,
                    participant2,
                    participant3
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                var createdRoomId = createCommunicationRoom.Id;

                // Act
                AsyncPageable<RoomParticipant> roomParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> roomParticipantsResult = await roomParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(3, roomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpsertParticipants to contain user1");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpsertParticipants to contain user2");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected UpsertParticipants to contain user3");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                    "Expected participant1 to have Presenter role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant2 to have Attendee role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant3 to have Attendee role.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                // Arrange
                // participant1 should be unchanged as Presenter
                // participant2 updated from Attendee -> Consumer
                // participant4 added to the list as Attendee
                // participant5 added to the list as Attendee
                var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value;
                var communicationUser5 = communicationIdentityClient.CreateUserAsync().Result.Value;
                participant1 = new InvitedRoomParticipant(communicationUser1);
                participant2 = new InvitedRoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };
                InvitedRoomParticipant participant4 = new InvitedRoomParticipant(communicationUser4);
                InvitedRoomParticipant participant5 = new InvitedRoomParticipant(communicationUser5) { Role = null };
                List<InvitedRoomParticipant> toUpsertCommunicationUsers = new List<InvitedRoomParticipant>()
                {
                    participant1,
                    participant2,
                    participant4,
                    participant5
                };

                // Act
                Response<UpsertParticipantsResult> upsertParticipantsResponse = await roomsClient.UpsertParticipantsAsync(createdRoomId, toUpsertCommunicationUsers);
                Assert.AreEqual(200, upsertParticipantsResponse.GetRawResponse().Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> upsertRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(5, upsertRoomParticipantsResult.Count, "Expected Room participants count to be 5");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpsertParticipants to contain user1");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpsertParticipants to contain user2");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected UpsertParticipants to contain user3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected UpsertParticipants to contain user4");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant5.CommunicationIdentifier)), "Expected UpsertParticipants to contain user5");

                Assert.IsTrue(upsertRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                   "Expected participant1 to have Presenter role.");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Consumer)),
                    "Expected participant2 to have Consumer role.");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                  "Expected participant3 to have Attendee role.");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant5.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant5 to have Attendee role.");

                // Act Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                Response<RemoveParticipantsResult> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                AsyncPageable<RoomParticipant> allParticipantsAfterDelete = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> allParticipantsAfterDeleteResult = await allParticipantsAfterDelete.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.GetRawResponse().Status);
                Assert.AreEqual(3, allParticipantsAfterDeleteResult.Count, "Expected Room participants count to be 3");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpsertParticipants to contain user1");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpsertParticipants to contain user2");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected UpsertParticipants to contain user3");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected UpsertParticipants to contain user4");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant5.CommunicationIdentifier)), "Expected UpsertParticipants to contain user5");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                  "Expected participant3 to have Attendee role.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant5.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant5 to have Attendee role.");

                // Clean up
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
                    // Arrange: Create Room
                    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom);
                    CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                    Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                    Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom.UtcDateTime);

                    var createdRoomId = createCommunicationRoom.Id;

                    // Act: Update Room
                    Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                    CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                    // Assert
                    Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                    Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom.UtcDateTime);
                    Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil.UtcDateTime);

                    // Clean up
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
