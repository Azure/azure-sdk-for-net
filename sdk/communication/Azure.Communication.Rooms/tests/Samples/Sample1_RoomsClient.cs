// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication.Rooms.Models;
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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Presenter");
            RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);
            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(updateCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
            Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                /*@@*/ createdRoomId);
            CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(getCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                /*@@*/ createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync

            Assert.AreEqual(204, deleteRoomResponse.Status);
        }

        [Test]
        public async Task AddRemoveParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
            var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;

            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Presenter");
            RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
            RoomParticipant participant3 = new RoomParticipant(communicationUser3, "Organizer");
            RoomParticipant participant4 = new RoomParticipant(communicationUser4, "Consumer");
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants
            List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
            toAddCommunicationUsers.Add(participant3);
            toAddCommunicationUsers.Add(participant4);

            Response<CommunicationRoom> addParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
            CommunicationRoom addedParticipantsRoom = addParticipantResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants

            Assert.IsFalse(string.IsNullOrWhiteSpace(addedParticipantsRoom.Id));
        }

        [Test]
        public async Task RoomRequestsTroubleShooting()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
                var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
                var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
                var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
                var validUntil = validFrom.AddDays(1);
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(communicationUser1, "Presenter");
                RoomParticipant participant2 = new RoomParticipant(communicationUser2, "Attendee");
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
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
