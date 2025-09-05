// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom);
                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom);

                // Act: Update Room
                validFrom = validFrom.AddDays(10);
                validUntil = validUntil.AddDays(10);
                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom);

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
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom);

                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom);

                // Act Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom);

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
        public async Task CreateRoom_WithNoAttributes_Succeed()
        {
            // Arrange
            var roomsClient = CreateClientWithAzureKeyCredential(apiVersion: RoomsClientOptions.ServiceVersion.V2025_03_13);

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync();

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [Test]
        public async Task CreateRoom_WithOnlyParticipants_Succeed()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(participants: roomParticipants);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [Test]
        public async Task CreateRoom_WithAllOptionalParameters_Succeed()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(participants: roomParticipants, validFrom: validFrom, validUntil: validUntil);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [Test]
        public void CreateRoom_WithTimeRangeExceedMax_Fail()
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(200);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public void CreateRoom_WithPastValidUntil_Fail()
        {
            // Arrange;
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var validFrom = DateTime.UtcNow.AddDays(-10);
            var validUntil = validFrom.AddDays(-20);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public void CreateRoom_WithInvalidParticipantMri_Fail()
        {
            // Arrange
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(new CommunicationUserIdentifier("invalid_mri"))
            };
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(participants: roomParticipants));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public void GetRoom_WithInvalidFormatRoomId_Fail()
        {
            // Arrange
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync("invalid_id"));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public async Task UpdateRoom_WithTimeRangeExceedMax_Fail()
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync(validFrom: validFrom, validUntil: validUntil);

            // Act and Assert
            validUntil = validFrom.AddDays(200);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

         [Test]
        public async Task UpdateRoom_WithPastValidUntil_Fail()
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync(validFrom: validFrom, validUntil: validUntil);

            // Act and Assert
            validUntil = validFrom.AddDays(-20);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public void UpdateRoom_WithInvalidFormatRoomId_Fail()
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync("invalid_id", validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public async Task UpdateRoom_WithDeletedRoom_Fail()
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync(validFrom: validFrom, validUntil: validUntil);
            await roomsClient.DeleteRoomAsync(createRoomResponse.Value.Id);

            // Act and assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, validFrom: validFrom, validUntil: validUntil));
            Assert.NotNull(ex);
            Assert.AreEqual(404, ex?.Status);
        }

        [Test]
        public async Task AddOrUpdateParticipants_IncorrectlyFormattedMri_Fail()
        {
            // Arrange
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(new CommunicationUserIdentifier("invalid_mri"))
            };

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.AddOrUpdateParticipantsAsync(createRoomResponse.Value.Id, participants: roomParticipants));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public async Task GetRoomsLiveTest_FirstTwoPagesOfRoomIsNotNull_Succeed()
        {
            // Arrange
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            // First create a room to ensure that the list rooms will not be empty.
            CommunicationRoom createdRoom = await roomsClient.CreateRoomAsync();
            int roomCounter = 0;
            try
            {
                AsyncPageable<CommunicationRoom> allActiveRooms = roomsClient.GetRoomsAsync();
                await foreach (CommunicationRoom room in allActiveRooms)
                {
                    if (roomCounter > 60)
                    {
                        break;
                    }
                    ValidateRoom(room);
                    roomCounter++;
                }
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
                AsyncPageable<RoomParticipant> existingParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> removeRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);
                Assert.AreEqual(1, removeRoomParticipantsResult.Count, "Expected Room participants count to be 1 after removal");
                Assert.IsTrue(removeRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");

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
        public async Task RemoveParticipants_NonExistentParticipants_Success()
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<CommunicationUserIdentifier> communicationUsers = new List<CommunicationUserIdentifier>()
            {
                participant1
            };

            // Act
            Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createRoomResponse.Value.Id, participantIdentifiers: communicationUsers);
            AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createRoomResponse.Value.Id);
            List<RoomParticipant> removeRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

            // Assert
            Assert.AreEqual(removeParticipantResponse.Status, 200);
            Assert.AreEqual(removeRoomParticipantsResult.Count, 0);
        }

        [Test]
        public async Task RemoveParticipants_IncorrectlyFormattedMri_Fail()
        {
            // Arrange
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync();
            List<CommunicationUserIdentifier> communicationUsers = new List<CommunicationUserIdentifier>()
            {
                new CommunicationUserIdentifier("invalid_mri")
            };

            // Act and assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.RemoveParticipantsAsync(createRoomResponse.Value.Id, participantIdentifiers: communicationUsers));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [Test]
        public async Task DeleteRoom_Success()
        {
            // Arrange
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var createRoomResponse = await roomsClient.CreateRoomAsync();
            var createdRoomId = createRoomResponse.Value.Id;

            // Act
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

            // Assert:
            Assert.AreEqual(204, deleteRoomResponse.Status);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync(createdRoomId));
            Assert.NotNull(ex);
            Assert.AreEqual(404, ex?.Status);
        }

        [Test]
        public void DeleteInvalidRoomId_Fail()
        {
            // Arrange
            var roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_06_14);
            var ivnalidRoomId = "123";

            // Act and Assert:
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.DeleteRoomAsync(ivnalidRoomId));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        private void ValidateRoom(CommunicationRoom? room)
        {
            Assert.NotNull(room);
            Assert.NotNull(room?.Id);
            Assert.NotNull(room?.CreatedAt);
            Assert.NotNull(room?.ValidFrom);
            Assert.NotNull(room?.ValidUntil);
        }
    }
}
