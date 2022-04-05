// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System;
using System.Collections.Generic;
using System.Linq;
//@@ using Azure.Communication.Rooms
#endregion Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication.Rooms.Models;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTests : RoomsClientLiveTestBase
    {
        public RoomsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            try
            {
                Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
                createRoomParticipants.Add(communicationUser1, new RoomParticipant());
                createRoomParticipants.Add(communicationUser2, new RoomParticipant());

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createCommunicationRoom.Participants.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createCommunicationRoom.Participants.ContainsKey(communicationUser1), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createCommunicationRoom.Participants.ContainsKey(communicationUser2), "Expected CreateRoom to contain user2");

                var createdRoomId = createCommunicationRoom.Id;

                Dictionary<string, object?> updateRoomParticipants = new Dictionary<string, object?>();
                updateRoomParticipants.Add(communicationUser3, new RoomParticipant());
                updateRoomParticipants.Add(communicationUser2, null);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(2, updateCommunicationRoom.Participants.Count, "Expected UpdateRoom participants count to be 2");
                Assert.IsTrue(updateCommunicationRoom.Participants.ContainsKey(communicationUser1), "Expected UpdateRoom to contain user1");
                Assert.IsTrue(updateCommunicationRoom.Participants.ContainsKey(communicationUser2), "Expected UpdateRoom to contain user2");
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, updateCommunicationRoom.ValidUntil);

                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(2, getCommunicationRoom.Participants.Count, "Expected GetRoom participants count to be 2");
                Assert.IsTrue(getCommunicationRoom.Participants.ContainsKey(communicationUser1), "Expected GetRoom to contain user1");
                Assert.IsTrue(getCommunicationRoom.Participants.ContainsKey(communicationUser2), "Expected GetRoom to contain user2");

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
        public async Task AcsRoomParticipantsMethodLiveTest()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser5 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser6 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient();

            List<string> toAddCommunicationUsers = new List<string>();
            toAddCommunicationUsers.Add(communicationUser4);
            toAddCommunicationUsers.Add(communicationUser5);

            List<string> toRemoveCommunicationUsers = new List<string>();
            toRemoveCommunicationUsers.Add(communicationUser5);
            toRemoveCommunicationUsers.Add(communicationUser6);

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            try
            {
                Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
                createRoomParticipants.Add(communicationUser1, new RoomParticipant());
                createRoomParticipants.Add(communicationUser2, new RoomParticipant());

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createCommunicationRoom.Participants.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createCommunicationRoom.Participants.ContainsKey(communicationUser1), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createCommunicationRoom.Participants.ContainsKey(communicationUser2), "Expected CreateRoom to contain user2");

                var createdRoomId = createCommunicationRoom.Id;

                Response<CommunicationRoom> addParticipantsResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
                CommunicationRoom addParticipantsRoom = addParticipantsResponse.Value;
                Assert.AreEqual(createdRoomId, addParticipantsRoom.Id);
                Assert.AreEqual(4, addParticipantsRoom.Participants.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(addParticipantsRoom.Participants.ContainsKey(communicationUser4), "Expected Room to contain user4");
                Assert.IsTrue(addParticipantsRoom.Participants.ContainsKey(communicationUser5), "Expected Room to contain user5");

                Response<CommunicationRoom> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                CommunicationRoom removeParticipantsRoom = removeParticipantsResponse.Value;
                Assert.AreEqual(createdRoomId, removeParticipantsRoom.Id);
                Assert.AreEqual(3, removeParticipantsRoom.Participants.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(removeParticipantsRoom.Participants.ContainsKey(communicationUser4), "Expected Room to contain user4");
                Assert.IsFalse(removeParticipantsRoom.Participants.ContainsKey(communicationUser5), "Expected Room not contain user5");
                Assert.IsFalse(removeParticipantsRoom.Participants.ContainsKey(communicationUser6), "Expected Room not contain user6");

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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();

            var validFrom = new DateTimeOffset(2022, 05, 01, 00, 00, 00, new TimeSpan(0, 0, 0));
            var validUntil = validFrom.AddDays(1);

            try
            {
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(default, validFrom);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom);

                var createdRoomId = createCommunicationRoom.Id;

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom);
                Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil);

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
