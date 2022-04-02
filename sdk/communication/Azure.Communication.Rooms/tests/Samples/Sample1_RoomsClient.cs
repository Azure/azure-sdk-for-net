// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
            createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063e", new RoomParticipant());
            createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063f", new RoomParticipant());
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
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
            createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063e", new RoomParticipant());
            createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063f", new RoomParticipant());
            Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil);
            CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

            var createdRoomId = createCommunicationRoom.Id;

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants

            var communicationUser1 = "8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063e";
            var communicationUser2 = "8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c6-f5d9-79ee-a427-0e9b917c063e";
            var communicationUser3 = "8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c6-f5d9-80ee-a427-0e9b917c063e";

            List<string> toAddCommunicationUsers = new List<string>();
            toAddCommunicationUsers.Add(communicationUser1);
            toAddCommunicationUsers.Add(communicationUser2);
            toAddCommunicationUsers.Add(communicationUser3);

            Response<CommunicationRoom> addParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
            CommunicationRoom addedParticipantsRoom = addParticipantResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants

            Assert.IsFalse(string.IsNullOrWhiteSpace(addedParticipantsRoom.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants

            List<string> toRemoveCommunicationUsers = new List<string>();
            toRemoveCommunicationUsers.Add(communicationUser1);
            toRemoveCommunicationUsers.Add(communicationUser2);

            Response<CommunicationRoom> removeParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
            CommunicationRoom removedParticipantsRoom = removeParticipantResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants

            Assert.IsFalse(string.IsNullOrWhiteSpace(removedParticipantsRoom.Id));
        }

        [Test]
        public async Task RoomRequestsTroubleShooting()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
                var validUntil = validFrom.AddDays(1);
                Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
                createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063e", new RoomParticipant());
                createRoomParticipants.Add("8:acs:db75ed0c-e801-41a3-99a4-66a0a119a06c_be3a83c1-f5d9-49ee-a427-0e9b917c063f", new RoomParticipant());
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
