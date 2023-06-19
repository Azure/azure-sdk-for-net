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
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTests : RoomsClientLiveTestBase
    {
        public RoomsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "AcsRoomRequestLiveWithoutParticipantsUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "AcsRoomRequestLiveWithoutParticipantsUsingKeyCredential")]
        public async Task AcsRoomRequestLiveWithoutParticipantsTest(AuthMethod authMethod)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod);

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);

                // Act: Update Room
                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom.AddDays(1), validUntil.AddDays(2));
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);

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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
                RoomParticipant participant2 = new RoomParticipant(communicationUser2);
                RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Consumer };

                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);

                // Act Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);

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
        public async Task GetRoomsLiveTest_FirstRoomIsNotNull_Succeed()
        {
            // Arrange
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            // First create a room to ensure that the list rooms will not be empty.
            CommunicationRoom createdRoom = await roomsClient.CreateRoomAsync();
            CommunicationRoom? firstActiveRoom = null;
            try
            {
                AsyncPageable<CommunicationRoom> allActiveRooms = roomsClient.GetRoomsAsync();
                await foreach (CommunicationRoom room in allActiveRooms)
                {
                    if (room is not null)
                    {
                        firstActiveRoom = room;
                        break;
                    }
                }
                Assert.IsNotNull(firstActiveRoom);
                Assert.IsNotNull(firstActiveRoom?.Id);
                Assert.IsNotNull(firstActiveRoom?.CreatedAt);
                Assert.IsNotNull(firstActiveRoom?.ValidFrom);
                Assert.IsNotNull(firstActiveRoom?.ValidUntil);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            await roomsClient.DeleteRoomAsync(createdRoom.Id);
        }

            [Test]
        public async Task RoomParticipantsAddUpdateAndRemoveLiveTest()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter };
            RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Attendee };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                var createdRoomId = createCommunicationRoom.Id;
                participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };

                // Act: Add or update room participants
                // participant2 updated from Presenter -> Consumer
                // participant3 added to the list
                List<RoomParticipant> toAddOrUpdateCommunicationUsers = new List<RoomParticipant>()
                {
                    participant2,
                    participant3
                };

                Response addOrUpdateParticipantsResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, toAddOrUpdateCommunicationUsers);
                Assert.AreEqual(200, addOrUpdateParticipantsResponse.Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> addOrUpdateRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(3, addOrUpdateRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Presenter), "Expected participants to contain Presenter");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Consumer), "Expected participants to contain Consumer");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Attendee), "Expected participants to contain Attendee");

                // Arrange: Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                // Act
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);

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
        public async Task RoomParticipantsAddUpdateAndRemoveWithNullRolesLiveTest()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2);
            RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Presenter };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants with null roles or roles undefined
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
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
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                    "Expected participant1 to have Presenter role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant2 to have Attendee role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                   "Expected participant3 to have Presenter role.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                // Arrange
                // participant1 should be updated to Attendee which is default
                // participant2 updated from Attendee -> Consumer
                // participant4 added to the list as Attendee
                var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value;
                participant1 = new RoomParticipant(communicationUser1);
                participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };
                RoomParticipant participant4 = new RoomParticipant(communicationUser4);
                List<RoomParticipant> toAddOrUpdateCommunicationUsers = new List<RoomParticipant>()
                {
                    participant1,
                    participant2,
                    participant4
                };

                // Act
                Response addOrUpdateParticipantsResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, toAddOrUpdateCommunicationUsers);
                Assert.AreEqual(200, addOrUpdateParticipantsResponse.Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> addOrUpdateRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(4, addOrUpdateRoomParticipantsResult.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add or update.");

                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant1 to have Attendee role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Consumer)),
                    "Expected participant2 to have Consumer role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

                // Act Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                AsyncPageable<RoomParticipant> allParticipantsAfterDelete = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> allParticipantsAfterDeleteResult = await allParticipantsAfterDelete.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);
                Assert.AreEqual(2, allParticipantsAfterDeleteResult.Count, "Expected Room participants count to be 2");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add and update.");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

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
                RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

                var validFrom = DateTime.UtcNow;
                var validUntil = validFrom.AddDays(1);

                try
                {
                    // Arrange: Create Room
                    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom);
                    CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                    Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                    var createdRoomId = createCommunicationRoom.Id;

                    // Act: Update Room
                    Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                    CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                    // Assert
                    Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);

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
