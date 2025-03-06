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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2025_03_13);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            // Create communication users using the CommunicationIdentityClient
            Response<CommunicationUserIdentifier> communicationUser1 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUserIdentifier> communicationUser2 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUserIdentifier> communicationUser3 = await communicationIdentityClient.CreateUserAsync();

            DateTimeOffset validFrom = DateTimeOffset.UtcNow;
            DateTimeOffset validUntil = validFrom.AddDays(1);
            RoomParticipant participant1 = new RoomParticipant(communicationUser1.Value); // If role is not provided, then it is set as Attendee by default
            RoomParticipant participant2 = new RoomParticipant(communicationUser2.Value) { Role = ParticipantRole.Presenter};
            // Starting in 1.2.0 release, A new role Collaborator is added
            RoomParticipant participant3 = new RoomParticipant(communicationUser3.Value) { Role = ParticipantRole.Collaborator };
            List<RoomParticipant> invitedParticipants = new List<RoomParticipant>
            {
                participant1,
                participant2,
                participant3
            };

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, invitedParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            // Starting in 1.1.0-beta.1 release,CreateRoom function also takes roomCreateOptions as parameter
            bool pstnDialOutEnabled = true;
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled,
                Participants = invitedParticipants
            };

            createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            createCommunicationRoom = createRoomResponse.Value;

            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            string createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
            validUntil = validFrom.AddDays(30);
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

            // Starting in 1.1.0 release,UpdateRoom function also takes roomCreateOptions as parameter
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled,
            };

            updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
            updateCommunicationRoom = updateRoomResponse.Value;

            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(updateCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
            Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
            CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(getCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomsAsync

            // Retrieve the first 2 pages of active rooms
            const int PageSize = 30;
            const int PageCount = 2;
            int maxRoomCount = PageCount * PageSize;
            int counter = 1;

            AsyncPageable<CommunicationRoom> allRooms = roomsClient.GetRoomsAsync();
            await foreach (CommunicationRoom room in allRooms)
            {
                Console.WriteLine($"Room with id {room.Id} is valid from {room.ValidFrom} to {room.ValidUntil}.");
                counter++;

                if (counter == maxRoomCount)
                {
                    break;
                }
            }
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomsAsync

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync

            Assert.AreEqual(204, deleteRoomResponse.Status);
        }

        [Test]
        public async Task AddUpdateAndRemoveParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2025_03_13);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUserIdentifier> communicationUser1 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUserIdentifier> communicationUser2 = await communicationIdentityClient.CreateUserAsync();

            DateTimeOffset validFrom = DateTimeOffset.UtcNow;
            DateTimeOffset validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(communicationUser1.Value) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2.Value) { Role = ParticipantRole.Presenter };
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            string createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_AddOrUpdateParticipants
            Response<CommunicationUserIdentifier> communicationUser3 = await communicationIdentityClient.CreateUserAsync();
            RoomParticipant newParticipant = new RoomParticipant(communicationUser3.Value) { Role = ParticipantRole.Consumer };

            // Previous snippet for create room added participant2 as Presenter
            participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Attendee };

            List<RoomParticipant> participantsToAddOrUpdate = new List<RoomParticipant>
            {
                participant2,   // participant2 updated from Presenter to Attendee
                newParticipant, // newParticipant added to the room
            };

            Response addOrUpdateParticipantResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, participantsToAddOrUpdate);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_AddOrUpdateParticipants

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
            List<CommunicationIdentifier> participantsToRemove = new List<CommunicationIdentifier>
            {
               communicationUser1,
               communicationUser2
            };
            Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, participantsToRemove);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
            AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
            await foreach (RoomParticipant participant in allParticipants)
            {
                Console.WriteLine($" Participant with id {participant.CommunicationIdentifier.RawId} is a {participant.Role}");
            }
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
        }

        [Test]
        public async Task RoomRequestsTroubleShooting()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2025_03_13);
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
                Response<CommunicationUserIdentifier> communicationUser1 = await communicationIdentityClient.CreateUserAsync();
                Response<CommunicationUserIdentifier> communicationUser2 = await communicationIdentityClient.CreateUserAsync();
                DateTimeOffset validFrom = DateTimeOffset.UtcNow;
                DateTimeOffset validUntil = validFrom.AddDays(1);
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(communicationUser1.Value) { Role = ParticipantRole.Presenter };
                RoomParticipant participant2 = new RoomParticipant(communicationUser2.Value) { Role = ParticipantRole.Attendee };
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
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
