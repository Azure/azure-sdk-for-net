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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            // Create communication users using the CommunicationIdentityClient
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);
            RoomParticipant participant1 = new RoomParticipant(communicationUser1); // If role is not provided, then it is set as Attendee by default
            RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter};
            List<RoomParticipant> invitedParticipants = new List<RoomParticipant>
            {
                participant1,
                participant2
            };

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, invitedParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
            validUntil = validFrom.AddDays(30);
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(updateCommunicationRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
            Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
            CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync

            Assert.IsFalse(string.IsNullOrWhiteSpace(getCommunicationRoom.Id));

            // TODO: Add list rooms

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync

            Assert.AreEqual(204, deleteRoomResponse.Status);
        }

        [Test]
        public async Task UpsertAndRemoveParticipantsExample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter };
            createRoomParticipants.Add(participant1);
            createRoomParticipants.Add(participant2);

            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpsertParticipants
            CommunicationIdentifier communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;
            RoomParticipant newParticipant = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Consumer };

            // Previous snippet for create room added participant2 as Presenter
            participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Attendee };

            List<RoomParticipant> participantsToUpsert = new List<RoomParticipant>
            {
                participant2,   // participant2 updated from Presenter to Attendee
                newParticipant, // newParticipant added to the room
            };

            Response<UpsertParticipantsResult> upsertParticipantResponse = await roomsClient.UpsertParticipantsAsync(createdRoomId, participantsToUpsert);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpsertParticipants

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
            List<CommunicationIdentifier> participantsToRemove = new List<CommunicationIdentifier>
            {
               communicationUser1,
               communicationUser2
            };
            Response<RemoveParticipantsResult> removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, participantsToRemove);
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
            RoomsClient roomsClient = CreateInstrumentedRoomsClient(RoomsClientOptions.ServiceVersion.V2023_03_31_Preview);
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
                CommunicationUserIdentifier communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
                CommunicationUserIdentifier communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
                var validFrom = DateTimeOffset.UtcNow;
                var validUntil = validFrom.AddDays(1);
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
                RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
                RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Attendee };
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
