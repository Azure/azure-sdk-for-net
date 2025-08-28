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
using Azure.Communication.Rooms.Tests;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.Communication.Rooms.RoomsClientOptions;

namespace Azure.Communication.Rooms.Test
{
    public class RoomClientPstnDialOutLiveTest : RoomsClientLiveTestBase
    {
        public static object[] AuthenticationVersionSource =
        [
            new object[] { AuthMethod.ConnectionString, ServiceVersion.V2024_04_15 },
            new object[] { AuthMethod.KeyCredential, ServiceVersion.V2024_04_15},
            new object[] { AuthMethod.ConnectionString, ServiceVersion.V2025_03_13 },
            new object[] { AuthMethod.KeyCredential, ServiceVersion.V2025_03_13 }
        ];

        public static readonly object[] AuthenticationVersionPstnEnabledSource =
        [
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2024_04_15, false },
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2024_04_15, true },
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2024_04_15, null },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2024_04_15, false },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2024_04_15, true },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2024_04_15, null },
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2025_03_13, false },
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2025_03_13, true },
            new object?[] { AuthMethod.ConnectionString, ServiceVersion.V2025_03_13, null },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2025_03_13, false },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2025_03_13, true },
            new object?[] { AuthMethod.KeyCredential, ServiceVersion.V2025_03_13, null }
        ];

        public RoomClientPstnDialOutLiveTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task AcsRoomLiveWithoutParticipantsTest(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            Rooms.RoomsClient roomsClient = CreateClient(authMethod, true, apiVersion);

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Act: Create Room
                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom);
                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom);

                // Act: Update Room
                validFrom = validFrom.AddDays(10);
                validUntil = validUntil.AddDays(10);
                UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil
                };

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom);

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert:
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
            await Task.Run(() => Console.WriteLine("Test Completed"));
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task AcsRoomWithPstnLiveWithoutParticipantsTest(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            Rooms.RoomsClient roomsClient = CreateClient(authMethod, true, apiVersion);

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    PstnDialOutEnabled = pstnDialOutEnabled
                };

                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom, roomCreateOptions);

                // Act: Get Room
                var createdRoomId = createCommunicationRoom.Id;
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, getCommunicationRoom.Id);
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom, roomCreateOptions);

                // Act: Update Room
                validFrom = validFrom.AddDays(10);
                validUntil = validUntil.AddDays(10);
                UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    PstnDialOutEnabled = pstnDialOutEnabled
                };

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert:
                Assert.AreEqual(createdRoomId, updateCommunicationRoom.Id);
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom, roomUpdateOptions);

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert:
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

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task AcsRoomLifeCycleLiveTest(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
                RoomParticipant participant2 = new RoomParticipant(communicationUser2);

                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    Participants = createRoomParticipants
                };

                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom);

                var createdRoomId = createCommunicationRoom.Id;

                // Act: Get Room
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom);

                // Act Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil
                };
                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom);

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert
                Assert.AreEqual(204, deleteRoomResponse.Status);

                // Get Deleted Room
                RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync(createdRoomId));
                Assert.NotNull(ex);
                Assert.AreEqual(404, ex?.Status);
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

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task AcsRoomWithPstnLifeCycleLiveTest(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();

            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var validFrom = DateTimeOffset.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
                RoomParticipant participant2 = new RoomParticipant(communicationUser2);
                RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Consumer };

                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    PstnDialOutEnabled = pstnDialOutEnabled,
                    Participants = createRoomParticipants
                };

                // Act: Create Room
                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                // Assert
                Assert.AreEqual(createRoomResponse.GetRawResponse().Status, 201);
                ValidateRoom(createCommunicationRoom, roomCreateOptions);

                // Act: Get Room
                var createdRoomId = createCommunicationRoom.Id;
                Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                CommunicationRoom getCommunicationRoom = getRoomResponse.Value;

                // Assert
                Assert.AreEqual(getRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(getCommunicationRoom, roomCreateOptions);

                // Act Update Room
                validFrom = validFrom.AddDays(30);
                validUntil = validUntil.AddDays(30);

                UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    PstnDialOutEnabled = !pstnDialOutEnabled // Set Pstn Dial-Out
                };

                Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
                CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

                // Assert
                Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
                ValidateRoom(updateCommunicationRoom, roomUpdateOptions);

                // Act: Delete Room
                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

                // Assert
                Assert.AreEqual(204, deleteRoomResponse.Status);

                // Get Deleted Room
                RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync(createdRoomId));
                Assert.NotNull(ex);
                Assert.AreEqual(404, ex?.Status);
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

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task CreateRoom_WithNullRoomCreateOptionsAttributes_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(options: null);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task CreateRoom_WithEmptyRoomCreateOptionsAttributes_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(new CreateRoomOptions());

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task CreateRoomWithPstn_WithOnlyPstnDialOutEnabledAttribute(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };

            // Act
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            var createdRoom = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value, roomCreateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task CreateRoom_WithOnlyParticipants_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                Participants = roomParticipants
            };

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task CreateRoomWithPstn_WithOnlyParticipants_Succeed(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            // Act
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                PstnDialOutEnabled = pstnDialOutEnabled,
                Participants = roomParticipants
            };

            var createdRoom = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value, roomCreateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task CreateRoom_WithAllOptionalParameters_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                Participants = roomParticipants
            };

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task CreateRoomWithPstn_WithAllOptionalParameters_Succeed(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(participant1.Value)
            };
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled,
                Participants = roomParticipants,
            };

            // Act
            var createdRoom = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Assert
            Assert.AreEqual(createdRoom.GetRawResponse().Status, 201);
            ValidateRoom(createdRoom.Value, roomCreateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void CreateRoom_WithTimeRangeExceedMax_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(200);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public void CreateRoomWithPstn_WithTimeRangeExceedMax_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(200);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled,
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void CreateRoom_WithPastValidUntil_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange;
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var validFrom = DateTime.UtcNow.AddDays(-10);
            var validUntil = validFrom.AddDays(-20);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };
            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public void CreateRoomWithPstn_WithPastValidUntil_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange;
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var validFrom = DateTime.UtcNow.AddDays(-10);
            var validUntil = validFrom.AddDays(-20);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled,
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void CreateRoom_WithInvalidParticipantMri_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(new CommunicationUserIdentifier("invalid_mri"))
            };
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                Participants = roomParticipants
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public void CreateRoomWithPstn_WithInvalidParticipantMri_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(new CommunicationUserIdentifier("invalid_mri"))
            };
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                PstnDialOutEnabled = pstnDialOutEnabled,
                Participants = roomParticipants
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.CreateRoomAsync(roomCreateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void GetRoom_WithInvalidFormatRoomId_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync("invalid_id"));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task UpdateRoomWithPstn_WithPstnDailOutEnabledAttributeOnly_Succeed(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                PstnDialOutEnabled = !pstnDialOutEnabled
            };

            // Act and Assert
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

            // Assert:
            Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
            Assert.AreEqual(createRoomResponse.Value.Id, updateCommunicationRoom.Id);
            ValidateRoom(updateCommunicationRoom, roomUpdateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task UpdateRoom_WithValidTimeRange_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = true,
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom.AddDays(10),
                ValidUntil = validUntil.AddDays(10)
            };

            // Act and Assert
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

            // Assert:
            Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
            Assert.AreEqual(createRoomResponse.Value.Id, updateCommunicationRoom.Id);
            Assert.AreEqual(updateCommunicationRoom.PstnDialOutEnabled, roomCreateOptions.PstnDialOutEnabled); // PSTN Enabled Dial-Out remains unchanged as in the room create operation
            ValidateRoom(updateCommunicationRoom, roomUpdateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task UpdateRoom_WithEmptyUpdateRoomOptions_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = true,
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions(){ };

            // Act and Assert
            Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions);
            CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

            // Assert:
            Assert.AreEqual(updateRoomResponse.GetRawResponse().Status, 200);
            Assert.AreEqual(createRoomResponse.Value.Id, updateCommunicationRoom.Id);
            Assert.AreEqual(updateCommunicationRoom.PstnDialOutEnabled, roomCreateOptions.PstnDialOutEnabled); // PSTN Enabled Dial-Out remains unchanged as in the room create operation
            ValidateRoom(updateCommunicationRoom, roomUpdateOptions);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task UpdateRoom_WithTimeRangeExceedMax_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            validUntil = validFrom.AddDays(200);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task UpdateRoom_WithTimeRangeExceedMax_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            validUntil = validFrom.AddDays(200);

            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task UpdateRoom_WithPastValidUntil_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);

            // Act and Assert
            validUntil = validFrom.AddDays(-20);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task UpdateRoom_WithPastValidUntil_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            validUntil = validFrom.AddDays(-20);

            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void UpdateRoom_WithInvalidFormatRoomId_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync("invalid_id", roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public void UpdateRoomWithPstn_WithInvalidFormatRoomId_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            if (authMethod == AuthMethod.KeyCredential){
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            // Act and Assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync("invalid_id", roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task UpdateRoom_WithDeletedRoom_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            await roomsClient.DeleteRoomAsync(createRoomResponse.Value.Id);
            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil
            };

            // Act and assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(404, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionPstnEnabledSource))]
        public async Task UpdateRoomWithPstn_WithDeletedRoom_Fail(AuthMethod authMethod, ServiceVersion apiVersion, bool? pstnDialOutEnabled)
        {
            // Arrange
            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(10);
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            var createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
            await roomsClient.DeleteRoomAsync(createRoomResponse.Value.Id);

            UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
            {
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                PstnDialOutEnabled = pstnDialOutEnabled
            };

            // Act and assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.UpdateRoomAsync(createRoomResponse.Value.Id, roomUpdateOptions));
            Assert.NotNull(ex);
            Assert.AreEqual(404, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task AddOrUpdateParticipants_IncorrectlyFormattedMri_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var createRoomResponse = await roomsClient.CreateRoomAsync(options: null);
            List<RoomParticipant> roomParticipants = new List<RoomParticipant>()
            {
                new RoomParticipant(new CommunicationUserIdentifier("invalid_mri"))
            };

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.AddOrUpdateParticipantsAsync(createRoomResponse.Value.Id, participants: roomParticipants));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task GetRoomsLiveTest_FirstTwoPagesOfRoomIsNotNull_Succeed(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            // First create a room to ensure that the list rooms will not be empty.
            CommunicationRoom createdRoom = await roomsClient.CreateRoomAsync(new CreateRoomOptions());
            int roomCounter = 0;
            try
            {
                AsyncPageable<CommunicationRoom> allActiveRooms = roomsClient.GetRoomsAsync();
                await foreach (CommunicationRoom room in allActiveRooms)
                {
                    if (roomCounter > 60)
                    {
                        break;
                    }
                    ValidateRoom(room);
                    roomCounter++;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            await roomsClient.DeleteRoomAsync(createdRoom.Id);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task RoomParticipantsAddUpdateAndRemoveLiveTest(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter };
            RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Attendee };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2
                };

                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    Participants = createRoomParticipants
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                var createdRoomId = createCommunicationRoom.Id;
                participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };

                // Act: Add or update room participants
                // participant2 updated from Presenter -> Consumer
                // participant3 added to the list
                List<RoomParticipant> toAddOrUpdateCommunicationUsers = new List<RoomParticipant>()
                {
                    participant2,
                    participant3
                };

                Response addOrUpdateParticipantsResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, toAddOrUpdateCommunicationUsers);
                Assert.AreEqual(200, addOrUpdateParticipantsResponse.Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> addOrUpdateRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(3, addOrUpdateRoomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Presenter), "Expected participants to contain Presenter");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Consumer), "Expected participants to contain Consumer");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.Role == ParticipantRole.Attendee), "Expected participants to contain Attendee");

                // Arrange: Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                // Act
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                AsyncPageable<RoomParticipant> existingParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> removeRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);
                Assert.AreEqual(1, removeRoomParticipantsResult.Count, "Expected Room participants count to be 1 after removal");
                Assert.IsTrue(removeRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");

                // Clean up
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

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task RoomParticipantsAddUpdateAndRemoveWithNullRolesLiveTest(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                return;
            }

            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateClient(authMethod, apiVersion: apiVersion);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2);
            RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Presenter };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants with null roles or roles undefined
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2,
                    participant3
                };

                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    Participants = createRoomParticipants
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                var createdRoomId = createCommunicationRoom.Id;

                // Act
                AsyncPageable<RoomParticipant> roomParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> roomParticipantsResult = await roomParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(3, roomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                    "Expected participant1 to have Presenter role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant2 to have Attendee role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                   "Expected participant3 to have Presenter role.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                // Arrange
                // participant1 should be updated to Attendee which is default
                // participant2 updated from Attendee -> Consumer
                // participant4 added to the list as Attendee
                var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value;
                participant1 = new RoomParticipant(communicationUser1);
                participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Consumer };
                RoomParticipant participant4 = new RoomParticipant(communicationUser4);
                List<RoomParticipant> toAddOrUpdateCommunicationUsers = new List<RoomParticipant>()
                {
                    participant1,
                    participant2,
                    participant4
                };

                // Act
                Response addOrUpdateParticipantsResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, toAddOrUpdateCommunicationUsers);
                Assert.AreEqual(200, addOrUpdateParticipantsResponse.Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> addOrUpdateRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(4, addOrUpdateRoomParticipantsResult.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add or update.");

                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant1 to have Attendee role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Consumer)),
                    "Expected participant2 to have Consumer role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

                // Act Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                AsyncPageable<RoomParticipant> allParticipantsAfterDelete = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> allParticipantsAfterDeleteResult = await allParticipantsAfterDelete.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);
                Assert.AreEqual(2, allParticipantsAfterDeleteResult.Count, "Expected Room participants count to be 2");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add and update.");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

                // Clean up
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

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task RemoveParticipants_NonExistentParticipants_Success(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var createRoomResponse = await roomsClient.CreateRoomAsync(options: null);
            var participant1 = await communicationIdentityClient.CreateUserAsync();
            List<CommunicationUserIdentifier> communicationUsers = new List<CommunicationUserIdentifier>()
            {
                participant1
            };

            // Act
            Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createRoomResponse.Value.Id, participantIdentifiers: communicationUsers);
            AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createRoomResponse.Value.Id);
            List<RoomParticipant> removeRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

            // Assert
            Assert.AreEqual(removeParticipantResponse.Status, 200);
            Assert.AreEqual(removeRoomParticipantsResult.Count, 0);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task RemoveParticipants_IncorrectlyFormattedMri_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var createRoomResponse = await roomsClient.CreateRoomAsync(new CreateRoomOptions());
            List<CommunicationUserIdentifier> communicationUsers = new List<CommunicationUserIdentifier>()
            {
                new CommunicationUserIdentifier("invalid_mri")
            };

            // Act and assert
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.RemoveParticipantsAsync(createRoomResponse.Value.Id, participantIdentifiers: communicationUsers));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public async Task DeleteRoom_Success(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var createRoomResponse = await roomsClient.CreateRoomAsync(options: null);
            var createdRoomId = createRoomResponse.Value.Id;

            // Act
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);

            // Assert:
            Assert.AreEqual(204, deleteRoomResponse.Status);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.GetRoomAsync(createdRoomId));
            Assert.NotNull(ex);
            Assert.AreEqual(404, ex?.Status);
        }

        [TestCaseSource(nameof(AuthenticationVersionSource))]
        public void DeleteInvalidRoomId_Fail(AuthMethod authMethod, ServiceVersion apiVersion)
        {
            if (authMethod == AuthMethod.KeyCredential)
            {
                // TODO: to fix bug before enabling this test for KeyCredential
                Assert.Ignore();
                return;
            }

            // Arrange
            var roomsClient = CreateClient(authMethod, apiVersion: apiVersion);
            var invalidRoomId = "123";

            // Act and Assert:
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await roomsClient.DeleteRoomAsync(invalidRoomId));
            Assert.NotNull(ex);
            Assert.AreEqual(400, ex?.Status);
        }

        [TestCase(ServiceVersion.V2025_03_13)]
        public async Task RoomParticipantsAddUpdateAndRemoveWithCollaboratorRolesLiveTest(ServiceVersion apiVersion)
        {
            // Arrange
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;
            var communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;

            RoomsClient roomsClient = CreateClient(apiVersion: apiVersion);

            RoomParticipant participant1 = new RoomParticipant(communicationUser1) { Role = ParticipantRole.Presenter };
            RoomParticipant participant2 = new RoomParticipant(communicationUser2);
            RoomParticipant participant3 = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Collaborator };

            var validFrom = DateTime.UtcNow;
            var validUntil = validFrom.AddDays(1);

            try
            {
                // Create room with participants with null roles or roles undefined
                List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>
                {
                    participant1,
                    participant2,
                    participant3
                };

                CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
                {
                    ValidFrom = validFrom,
                    ValidUntil = validUntil,
                    Participants = createRoomParticipants
                };

                Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
                CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
                var createdRoomId = createCommunicationRoom.Id;

                // Act
                AsyncPageable<RoomParticipant> roomParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> roomParticipantsResult = await roomParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(3, roomParticipantsResult.Count, "Expected Room participants count to be 3");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Presenter)),
                    "Expected participant1 to have Presenter role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                    "Expected participant2 to have Attendee role.");
                Assert.IsTrue(roomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Collaborator)),
                   "Expected participant3 to have Presenter role.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(createCommunicationRoom.Id));

                // Arrange
                // participant1 should be updated to Attendee which is default
                // participant2 updated from Attendee -> Collaborator
                // participant4 added to the list as Attendee
                var communicationUser4 = communicationIdentityClient.CreateUserAsync().Result.Value;
                participant1 = new RoomParticipant(communicationUser1);
                participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Collaborator };
                RoomParticipant participant4 = new RoomParticipant(communicationUser4);
                List<RoomParticipant> toAddOrUpdateCommunicationUsers = new List<RoomParticipant>()
                {
                    participant1,
                    participant2,
                    participant4
                };

                // Act
                Response addOrUpdateParticipantsResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, toAddOrUpdateCommunicationUsers);
                Assert.AreEqual(200, addOrUpdateParticipantsResponse.Status);

                AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> addOrUpdateRoomParticipantsResult = await allParticipants.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(4, addOrUpdateRoomParticipantsResult.Count, "Expected Room participants count to be 4");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add or update.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add or update.");

                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant1 to have Attendee role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                    x => (x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier) && x.Role == ParticipantRole.Collaborator)),
                    "Expected participant2 to have Consumer role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Collaborator)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(addOrUpdateRoomParticipantsResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

                // Act Remove participants
                List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>
                {
                    communicationUser1,
                    communicationUser2
                };
                Response removeParticipantsResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
                AsyncPageable<RoomParticipant> allParticipantsAfterDelete = roomsClient.GetParticipantsAsync(createdRoomId);
                List<RoomParticipant> allParticipantsAfterDeleteResult = await allParticipantsAfterDelete.ToEnumerableAsync();

                // Assert
                Assert.AreEqual(200, removeParticipantsResponse.Status);
                Assert.AreEqual(2, allParticipantsAfterDeleteResult.Count, "Expected Room participants count to be 2");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant1.CommunicationIdentifier)), "Expected participants to contain user1 after add and update.");
                Assert.IsFalse(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant2.CommunicationIdentifier)), "Expected participants to contain user2 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier)), "Expected participants to contain user3 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(x => x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier)), "Expected participants to contain user4 after add and update.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                  x => (x.CommunicationIdentifier.Equals(participant3.CommunicationIdentifier) && x.Role == ParticipantRole.Collaborator)),
                  "Expected participant3 to have Presenter role.");
                Assert.IsTrue(allParticipantsAfterDeleteResult.Any(
                   x => (x.CommunicationIdentifier.Equals(participant4.CommunicationIdentifier) && x.Role == ParticipantRole.Attendee)),
                   "Expected participant4 to have Attendee role.");

                // Clean up
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

        private void ValidateRoom(CommunicationRoom? room)
        {
            Assert.NotNull(room);
            Assert.NotNull(room?.Id);
            Assert.NotNull(room?.CreatedAt);
            Assert.NotNull(room?.ValidFrom);
            Assert.NotNull(room?.ValidUntil);
            Assert.NotNull(room?.PstnDialOutEnabled);
        }

        private void ValidateRoom(CommunicationRoom? room, CreateRoomOptions roomCreateOptions)
        {
            Assert.NotNull(room);
            Assert.NotNull(room?.Id);
            Assert.NotNull(room?.CreatedAt);
            Assert.NotNull(room?.ValidFrom);
            Assert.NotNull(room?.ValidUntil);
            Assert.AreEqual(room?.PstnDialOutEnabled, roomCreateOptions.PstnDialOutEnabled.HasValue ? roomCreateOptions?.PstnDialOutEnabled : false);
            Console.Write("Room Id: " + room?.Id);
            Console.Write("CreatedAt: " + room?.CreatedAt);
            Console.Write("ValidFrom: " + room?.ValidFrom);
            Console.Write("ValidUntil: " + room?.ValidUntil);
            Console.Write("PstnDialOutEnabled: " + room?.PstnDialOutEnabled);
        }

        private void ValidateRoom(CommunicationRoom? room, UpdateRoomOptions roomUpdateOptions)
        {
            Assert.NotNull(room);
            Assert.NotNull(room?.Id);
            Assert.NotNull(room?.CreatedAt);
            Assert.NotNull(room?.CreatedAt);
            Assert.NotNull(room?.ValidFrom);
            Assert.AreEqual(room?.PstnDialOutEnabled, roomUpdateOptions.PstnDialOutEnabled.HasValue ? roomUpdateOptions.PstnDialOutEnabled : room?.PstnDialOutEnabled);
        }
    }
}
