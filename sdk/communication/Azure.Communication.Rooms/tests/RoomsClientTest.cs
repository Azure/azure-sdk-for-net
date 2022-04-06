// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Rooms.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientTest
    {
        [Test]
        public async Task CreateRoomAsyncShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            string communicationUser1 = "mockAcsUserIdentityString1";
            string communicationUser2 = "mockAcsUserIdentityString2";

            createRoomParticipants.Add(new RoomParticipant(communicationUser1, "Presenter"));
            createRoomParticipants.Add(new RoomParticipant(communicationUser2, "Attendee"));
            Response<CommunicationRoom>? expectedRoomResult = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil, cancellationToken))
                .ReturnsAsync(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = await mockRoomsClient.Object.CreateRoomAsync(createRoomParticipants, validFrom, validUntil, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.CreateRoomAsync(createRoomParticipants, validFrom, validUntil, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public async Task UpdateRoomAsyncShouldSucceed()
        {
            var roomId = "123";
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            Response<CommunicationRoom>? expectedRoomResult = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.UpdateRoomAsync(roomId, validFrom, validUntil, cancellationToken))
                .ReturnsAsync(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = await mockRoomsClient.Object.UpdateRoomAsync(roomId, validFrom, validUntil, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.UpdateRoomAsync(roomId, validFrom, validUntil, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public async Task GetRoomAsyncShouldSucceed()
        {
            var roomId = "123";
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            Response<CommunicationRoom>? expectedRoomResult = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.GetRoomAsync(roomId, cancellationToken))
                .ReturnsAsync(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = await mockRoomsClient.Object.GetRoomAsync(roomId, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.GetRoomAsync(roomId, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public async Task DeleteRoomAsyncShouldSucceed()
        {
            var roomId = "123";
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            Response? expectedRoomResult = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.DeleteRoomAsync(roomId, cancellationToken))
                .ReturnsAsync(expectedRoomResult);

            Response actualResponse = await mockRoomsClient.Object.DeleteRoomAsync(roomId, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.DeleteRoomAsync(roomId, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void CreateRoomShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);
            List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
            string communicationUser1 = "mockAcsUserIdentityString1";
            string communicationUser2 = "mockAcsUserIdentityString2";

            createRoomParticipants.Add(new RoomParticipant(communicationUser1, "Presenter"));
            createRoomParticipants.Add(new RoomParticipant(communicationUser2, "Attendee"));
            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.CreateRoom(createRoomParticipants, validFrom, validUntil, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.CreateRoom(createRoomParticipants, validFrom, validUntil, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.CreateRoom(createRoomParticipants, validFrom, validUntil, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void UpdateRoomShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            var validFrom = new DateTime(2022, 05, 01, 00, 00, 00, DateTimeKind.Utc);
            var validUntil = validFrom.AddDays(1);

            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.UpdateRoom(roomId, validFrom, validUntil, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.UpdateRoom(roomId, validFrom, validUntil, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.UpdateRoom(roomId, validFrom, validUntil, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void GetRoomShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.GetRoom(roomId, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.GetRoom(roomId, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.GetRoom(roomId, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void DeleteRoomShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            Response? expectedRoomResult = new Mock<Response>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.DeleteRoom(roomId, cancellationToken))
                .Returns(expectedRoomResult);

            Response actualResponse = mockRoomsClient.Object.DeleteRoom(roomId, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.DeleteRoom(roomId, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void AddParticipantsShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            List<RoomParticipant> communicationUsers = new List<RoomParticipant>();
            string communicationUser1 = "mockAcsUserIdentityString1";
            string communicationUser2 = "mockAcsUserIdentityString2";
            string communicationUser3 = "mockAcsUserIdentityString3";

            communicationUsers.Add(new RoomParticipant(communicationUser1, "Presenter"));
            communicationUsers.Add(new RoomParticipant(communicationUser2, "Attendee"));
            communicationUsers.Add(new RoomParticipant(communicationUser3, "Organizer"));

            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.AddParticipants(roomId, communicationUsers, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.AddParticipants(roomId, communicationUsers, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.AddParticipants(roomId, communicationUsers, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        public void UpdateParticipantsShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            List<RoomParticipant> communicationUsers = new List<RoomParticipant>();
            string communicationUser1 = "mockAcsUserIdentityString1";
            string communicationUser2 = "mockAcsUserIdentityString2";
            string communicationUser3 = "mockAcsUserIdentityString3";

            communicationUsers.Add(new RoomParticipant(communicationUser1, "Presenter"));
            communicationUsers.Add(new RoomParticipant(communicationUser2, "Attendee"));
            communicationUsers.Add(new RoomParticipant(communicationUser3, "Organizer"));

            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.UpdateParticipants(roomId, communicationUsers, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.UpdateParticipants(roomId, communicationUsers, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.UpdateParticipants(roomId, communicationUsers, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }

        [Test]
        [Ignore("Ignore remove participants temporarily")]
        public void RemoveParticipantsShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            List<string> communicationUsers = new List<string>();
            communicationUsers.Add("mockAcsUserIdentityString1");
            communicationUsers.Add("mockAcsUserIdentityString2");
            communicationUsers.Add("mockAcsUserIdentityString3");

            Response<CommunicationRoom>? expectedRoomResult = new Mock<Response<CommunicationRoom>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;

            mockRoomsClient
                .Setup(roomsClient => roomsClient.RemoveParticipants(roomId, communicationUsers, cancellationToken))
                .Returns(expectedRoomResult);

            Response<CommunicationRoom> actualResponse = mockRoomsClient.Object.RemoveParticipants(roomId, communicationUsers, cancellationToken);

            mockRoomsClient.Verify(roomsClient => roomsClient.RemoveParticipants(roomId, communicationUsers, cancellationToken), Times.Once());
            Assert.AreEqual(expectedRoomResult, actualResponse);
        }
    }
}
