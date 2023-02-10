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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(0, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 0");

                var createdRoomId = createCommunicationRoom.Id;

                // Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                List<RoomParticipant> getRoomParticipantsResult = getCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(0, getRoomParticipantsResult.Count, "Expected GetRoom participants count to be 0");

                // Update Room
                List<RoomParticipant> updateRoomParticipants = new List<RoomParticipant>();

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom.AddDays(1), validUntil.AddDays(2), RoomJoinPolicy.InviteOnly, updateRoomParticipants);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(0, updateRoomParticipantsResult.Count, "Expected UpdateRoom participants count to be 0");
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, updateCommunicationRoom.ValidUntil);

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
        public async Task AcsRoomRequestLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
                RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2));
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                // Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected CreateRoom to contain user2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == participant1.Role), "Expected CreateRoom to contain role1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == RoleType.Attendee), "Expected CreateRoom to contain role2");

                var createdRoomId = createCommunicationRoom.Id;

                // Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                List<RoomParticipant> getRoomParticipantsResult = getCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(2, getRoomParticipantsResult.Count, "Expected GetRoom participants count to be 2");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected GetRoom to contain user1");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected GetRoom to contain user2");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.Role == participant1.Role), "Expected GetRoom to contain role1");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.Role == RoleType.Attendee), "Expected GetRoom to contain role2");

                // Update Room
                validFrom = validFrom.AddHours(1);

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil, roomJoinPolicy:RoomJoinPolicy.CommunicationServiceUsers);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(2, updateRoomParticipantsResult.Count, "Expected UpdateRoom participants count to be 2");
                Assert.AreEqual(RoomJoinPolicy.CommunicationServiceUsers , updateCommunicationRoom.RoomJoinPolicy, "Expected RoomJoinPolicy to be updated");

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
        public async Task AcsRoomOpenRequestLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(3);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
                RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2));
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(createCommunicationRoom.RoomJoinPolicy, RoomJoinPolicy.InviteOnly);
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected CreateRoom to contain user2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == participant1.Role), "Expected CreateRoom to contain role1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == RoleType.Attendee), "Expected CreateRoom to contain role2");

                var createdRoomId = createCommunicationRoom.Id;

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom.AddDays(1), validUntil, RoomJoinPolicy.CommunicationServiceUsers);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateCommunicationRoom.RoomJoinPolicy, RoomJoinPolicy.CommunicationServiceUsers);
                Assert.AreEqual(2, updateRoomParticipantsResult.Count, "Expected UpdateRoom participants count to be 2");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected UpdateRoom to contain user1");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected UpdateRoom to contain user2");
                Assert.AreEqual(updateCommunicationRoom.ValidUntil, updateCommunicationRoom.ValidUntil);

                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
                List<RoomParticipant> getRoomParticipantsResult = getCommunicationRoom.Participants.ToList();
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(getCommunicationRoom.RoomJoinPolicy, RoomJoinPolicy.CommunicationServiceUsers);
                Assert.AreEqual(2, getRoomParticipantsResult.Count, "Expected GetRoom participants count to be 2");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected GetRoom to contain user1");
                Assert.IsTrue(getRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected GetRoom to contain user2");

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
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);

            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Consumer);
            RoomParticipant participant3 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), RoleType.Attendee);

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                createRoomParticipants.Add(participant1);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(1, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == participant1.Role), "Expected CreateRoom to contain role1");

                var createdRoomId = createCommunicationRoom.Id;

                List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
                toAddCommunicationUsers.Add(participant2);
                toAddCommunicationUsers.Add(participant3);

                Response addParticipantsResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
                Assert.AreEqual(200, addParticipantsResponse.Status);
                Response<ParticipantsCollection> getParticipantsResponse = await roomsClient.GetParticipantsAsync(createdRoomId);

                ParticipantsCollection roomParticipantsResponse = getParticipantsResponse.Value;
                List<RoomParticipant> addRoomParticipantsResult = roomParticipantsResponse.Participants.ToList();
                Assert.AreEqual(3, addRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected AddParticipants to contain user2");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected AddParticipants to contain user3");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.Role == participant2.Role), "Expected AddParticipants to contain role2");
                Assert.IsTrue(addRoomParticipantsResult.Any(x => x.Role == participant3.Role), "Expected AddParticipants to contain role3");

                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>();
                toRemoveCommunicationUsers.Add(new CommunicationUserIdentifier(communicationUser2));
                toRemoveCommunicationUsers.Add(new CommunicationUserIdentifier(communicationUser3));
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                Assert.AreEqual(200, removeParticipantsResponse.Status);

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

            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);

            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Presenter);
            RoomParticipant participant4 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Consumer);
            RoomParticipant participant5 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                createRoomParticipants.Add(participant1);
                createRoomParticipants.Add(participant2);

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                List<RoomParticipant> createRoomParticipantsResult = createCommunicationRoom.Participants.ToList();

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(2, createRoomParticipantsResult.Count, "Expected CreateRoom participants count to be 2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected CreateRoom to contain user1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected CreateRoom to contain user2");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == participant1.Role), "Expected CreateRoom to contain role1");
                Assert.IsTrue(createRoomParticipantsResult.Any(x => x.Role == participant2.Role), "Expected CreateRoom to contain role2");

                var createdRoomId = createCommunicationRoom.Id;

                List<RoomParticipant> toUpdateCommunicationUsers = new List<RoomParticipant>();
                toUpdateCommunicationUsers.Add(participant4);
                toUpdateCommunicationUsers.Add(participant5);

                Response updateParticipantsResponse = await roomsClient.UpdateParticipantsAsync(createdRoomId, toUpdateCommunicationUsers);
                Assert.AreEqual(200, updateParticipantsResponse.Status);
                Response<ParticipantsCollection> getParticipantsResponse = await roomsClient.GetParticipantsAsync(createdRoomId);
                ParticipantsCollection updateParticipantsRoom = getParticipantsResponse.Value;
                List<RoomParticipant> updateRoomParticipantsResult = updateParticipantsRoom.Participants.ToList();
                Assert.AreEqual(2, updateRoomParticipantsResult.Count, 2);
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected AddParticipants to contain user4");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant5.CommunicationIdentifier)), "Expected AddParticipants to contain user5");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Role == participant4.Role), "Expected AddParticipants to contain role4");
                Assert.IsTrue(updateRoomParticipantsResult.Any(x => x.Role == participant5.Role), "Expected AddParticipants to contain role5");

                // Delete room
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
                RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);

                var validFrom = DateTime.UtcNow;
                var validUntil = validFrom.AddDays(1);

                try
                {
                    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom);
                    CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                    Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                    Assert.AreEqual(validFrom, createCommunicationRoom.ValidFrom?.UtcDateTime);

                    var createdRoomId = createCommunicationRoom.Id;

                    Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
                    CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
                    Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                    Assert.AreEqual(validFrom, updateCommunicationRoom.ValidFrom?.UtcDateTime);
                    Assert.AreEqual(validUntil, updateCommunicationRoom.ValidUntil?.UtcDateTime);

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
