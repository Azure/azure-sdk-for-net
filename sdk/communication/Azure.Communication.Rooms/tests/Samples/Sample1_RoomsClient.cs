// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    ///
    public partial class Sample1_RoomsClient : RoomsClientLiveTestBase
    {
        public Sample1_RoomsClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestSample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);
            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateOpenRoomAsync
            Response<CommunicationRoom> createOpenRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.CommunicationServiceUsers);
            CommunicationRoom createCommunicationOpenRoom = createOpenRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateOpenRoomAsync

            Assert.AreEqual(createCommunicationOpenRoom.RoomJoinPolicy, RoomJoinPolicy.CommunicationServiceUsers);

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(updateCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
            Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                createdRoomId);
            CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(getCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                 createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync

            Assert.AreEqual(204, deleteRoomResponse.Status);
        }

        [Test]
        public async Task AddParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
            RoomParticipant participant3 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), RoleType.Consumer);
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants
            List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
            toAddCommunicationUsers.Add(participant3);

            Response addParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
            Response<ParticipantsCollection> participantResponse = await roomsClient.GetParticipantsAsync(createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
        }

        [Test]
        public async Task RemoveParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
            List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>();
            toRemoveCommunicationUsers.Add(new CommunicationUserIdentifier(communicationUser2));

            Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
        }

        [Test]
        public async Task UpdateParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
            RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
            RoomParticipant participant3 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), RoleType.Attendee);
            RoomParticipant participant4 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser4), RoleType.Attendee);
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);
            createRoomParticipants.Add(participant3);
            createRoomParticipants.Add(participant4);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateParticipants
            List<RoomParticipant> toUpdateCommunicationUsers = new List<RoomParticipant>();
            participant3 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), "Presenter");
            participant4 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser4), "Presenter");
            toUpdateCommunicationUsers.Add(participant3);
            toUpdateCommunicationUsers.Add(participant4);

            Response updateParticipantResponse = await roomsClient.UpdateParticipantsAsync(createdRoomId, toUpdateCommunicationUsers);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateParticipants
        }

        [Test]
        public async Task RoomRequestsTroubleShooting()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2022_02_01_Preview);
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
                var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
                var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
                var validFrom = DateTime.UtcNow;
                var validUntil = validFrom.AddDays(1);
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
                RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
                CommunicationRoom createRoomResult = createRoomResponse.Value;
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
        }
    }
}
