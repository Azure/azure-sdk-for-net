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
            Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
            createRoomParticipants.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000005e-3240-55cf-9806-113a0d001dd9", new RoomParticipant());
            createRoomParticipants.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000005e-3240-55cf-9806-113a0d001dd8", new RoomParticipant());
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
            var validUntil = validFrom.AddDays(2);
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
            Dictionary<string, object> createRoomParticipants = new Dictionary<string, object>();
            createRoomParticipants.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000005e-3240-55cf-9806-113a0d001dd9", new RoomParticipant());
            createRoomParticipants.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000005e-3240-55cf-9806-113a0d001dd8", new RoomParticipant());
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
            var validUntil = validFrom.AddDays(2);
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
            List<string> communicationUsers = new List<string>();
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000002e-3240-55cf-9806-113a0d001dd9");
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000003e-3240-55cf-9806-113a0d001dd9");
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000004e-3240-55cf-9806-113a0d001dd9");

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
        public void RemoveParticipantsShouldSucceed()
        {
            Mock<RoomsClient> mockRoomsClient = new Mock<RoomsClient>();
            string roomId = "123";
            List<string> communicationUsers = new List<string>();
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000005e-3240-55cf-9806-113a0d001dd9");
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000006e-3240-55cf-9806-113a0d001dd9");
            communicationUsers.Add("8:acs:71ec590b-cbad-490c-99c5-b578bdacde54_0000007e-3240-55cf-9806-113a0d001dd9");

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
