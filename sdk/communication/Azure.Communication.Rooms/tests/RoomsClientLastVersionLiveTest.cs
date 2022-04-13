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
    public class RoomsClientLastVersionLiveTest : RoomsClientLiveTestBase
    {
        public RoomsClientLastVersionLiveTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2021_04_07_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Attendee");
                RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant1.Identifier), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant2.Identifier), "Expected CreateRoom to contain user2");

                var createdRoomId = createCommunicationRoom.Id;

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(2, updateRoomParticipantsResult.Count, "Expected UpdateRoom participants count to be 2");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Identifier == participant1.Identifier), "Expected UpdateRoom to contain user1");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Identifier == participant2.Identifier), "Expected UpdateRoom to contain user2");
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, updateCommunicationRoom.ValidUntil);

                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                List<RoomParticipant> getRoomParticipantsResult = getCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(2, getRoomParticipantsResult.Count, "Expected GetRoom participants count to be 2");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.Identifier == participant1.Identifier), "Expected GetRoom to contain user1");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.Identifier == participant2.Identifier), "Expected GetRoom to contain user2");

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
        public async Task RoomParticipantsMethodLiveTest()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser5 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser6 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2021_04_07_Preview);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Attendee");
            RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
            RoomParticipant participant4 = new RoomParticipant(communicationUser4, "Attendee");
            RoomParticipant participant5 = new RoomParticipant(communicationUser5, "Attendee");
            RoomParticipant participant6 = new RoomParticipant(communicationUser6, "Attendee");

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant1.Identifier), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant2.Identifier), "Expected CreateRoom to contain user2");

                var createdRoomId = createCommunicationRoom.Id;

                List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
                toAddCommunicationUsers.Add(participant4);
                toAddCommunicationUsers.Add(participant5);

                Response<CommunicationRoom> addParticipantsResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
                CommunicationRoom addParticipantsRoom = addParticipantsResponse.Value;
                List<RoomParticipant> addRoomParticipantsResult = addParticipantsRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, addParticipantsRoom.Id);
                Assert.AreEqual(4, addRoomParticipantsResult.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.Identifier == participant4.Identifier), "Expected AddParticipants to contain user4");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.Identifier == participant5.Identifier), "Expected AddParticipants to contain user5");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.RoleName == null), "Expected AddParticipants to contain role4");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.RoleName == null), "Expected AddParticipants to contain rol55");

                // Remove participants is not working temporarily due to json merge patch not supported at .net.
                /*
                 *
                 *  List<string> toRemoveCommunicationUsers = new List<string>();
                 *  toRemoveCommunicationUsers.Add(communicationUser5);
                 *  toRemoveCommunicationUsers.Add(communicationUser6);
                 *  Response<CommunicationRoom> removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                 *  CommunicationRoom removeParticipantsRoom = removeParticipantsResponse.Value;
                 *  Assert.AreEqual(createdRoomId, removeParticipantsRoom.Id);
                */

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
        public async Task UpdateParticipantRoleMethodLiveTest()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2021_04_07_Preview);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Attendee");
            RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
            RoomParticipant participant4 = new RoomParticipant(communicationUser1, "Attendee");
            RoomParticipant participant5 = new RoomParticipant(communicationUser2, "Attendee");

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant1.Identifier), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Identifier == participant2.Identifier), "Expected CreateRoom to contain user2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.RoleName == null), "Expected CreateRoom to contain role1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.RoleName == null), "Expected CreateRoom to contain role2");

                var createdRoomId = createCommunicationRoom.Id;

                List<RoomParticipant> toUpdateCommunicationUsers = new List<RoomParticipant>();
                toUpdateCommunicationUsers.Add(participant4);
                toUpdateCommunicationUsers.Add(participant5);

                Response<CommunicationRoom> updateParticipantsResponse = await roomsClient.UpdateParticipantsAsync(createdRoomId, toUpdateCommunicationUsers);
                CommunicationRoom updateParticipantsRoom = updateParticipantsResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateParticipantsRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, updateParticipantsRoom.Id);
                Assert.AreEqual(2, updateRoomParticipantsResult.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Identifier == participant4.Identifier), "Expected AddParticipants to contain user4");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Identifier == participant5.Identifier), "Expected AddParticipants to contain user5");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.RoleName == null), "Expected AddParticipants to contain role4");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.RoleName == null), "Expected AddParticipants to contain role5");

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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2021_04_07_Preview);

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
