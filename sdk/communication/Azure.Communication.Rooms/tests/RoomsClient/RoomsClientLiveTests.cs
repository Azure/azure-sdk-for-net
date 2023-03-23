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

            var validFrom = DateTime.UtcNow;
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

                // List All Rooms
                Response<RoomsCollection> listRoomResponse = await roomsClient.ListRoomsAsync();
                RoomsCollection listCommunicationRooms = listRoomResponse.Value;

                // TODO: we should check that the list of retrieved rooms should not have count of 0;

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

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                RoomParticipant participant1 = new RoomParticipant(communicationUser1, ParticipantRole.Presenter);
                RoomParticipant participant2 = new RoomParticipant(communicationUser2);
                RoomParticipant participant3 = new RoomParticipant(communicationUser3, ParticipantRole.Consumer);

                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
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

                // List All Rooms
                Response<RoomsCollection> listRoomResponse = await roomsClient.ListRoomsAsync();
                RoomsCollection listCommunicationRooms = listRoomResponse.Value;

                // TODO: we should check that the list of retrieved rooms should not have count of 0;

                // Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, createCommunicationRoom.ValidUntil);

                // Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                Assert.AreEqual(204, deleteRoomResponse.Status);

                // Get Deleted Room
                Response<CommunicationRoom> getDeletedRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                Assert.AreEqual(404, getDeletedRoomResponse.GetRawResponse().Status);
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

            RoomParticipant participant1 = new RoomParticipant(communicationUser1, ParticipantRole.Presenter);
            RoomParticipant participant2 = new RoomParticipant(communicationUser2, ParticipantRole.Presenter);
            RoomParticipant participant3 = new RoomParticipant(communicationUser3, ParticipantRole.Attendee);

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                var createdRoomId = createCommunicationRoom.Id;
                participant2 = new RoomParticipant(communicationUser1, ParticipantRole.Consumer);

                // Upsert room participants
                // participant2 updated from Presenter -> Consumer
                // participant3 added to the list
                List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>()
                {
                    participant2,
                    participant3
                };

                Response<object> addParticipantsResponse = await roomsClient.UpsertParticipantsAsync(createdRoomId, toAddCommunicationUsers);
                Assert.AreEqual(200, addParticipantsResponse.GetRawResponse().Status);

                Response<ParticipantsCollection> getParticipantsResponse = await roomsClient.GetParticipantsAsync(createdRoomId);
                ParticipantsCollection roomParticipantsResponse = getParticipantsResponse.Value;
                List<RoomParticipant> upsertRoomParticipantsResult = roomParticipantsResponse.Value.ToList();
                Assert.AreEqual(3, upsertRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected AddParticipants to contain user1");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected AddParticipants to contain user2");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected AddParticipants to contain user3");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Presenter), "Expected AddParticipants to contain Presenter");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Consumer), "Expected AddParticipants to contain Consumer");
                Assert.IsTrue(upsertRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Attendee), "Expected AddParticipants to contain Attendee");

                // Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };

                Response<object> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
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
                    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom);
                    CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                    Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                    Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom.UtcDateTime);

                    var createdRoomId = createCommunicationRoom.Id;

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
