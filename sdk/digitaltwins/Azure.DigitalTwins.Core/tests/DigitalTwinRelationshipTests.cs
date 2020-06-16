// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.DigitalTwins.Core.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class DigitalTwinRelationshipTests : E2eTestBase
    {
        private const string ContainsRelationship = "contains";
        private const string ContainedInRelationship = "containedIn";
        private const string CoolsRelationship = "cools";
        private const string CooledByRelationship = "cooledBy";

        public DigitalTwinRelationshipTests(bool isAsync)
           : base(isAsync)
        {
        }

        [Test]
        public async Task Relationships_Lifecycle()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            var floorContainsRoomRelationshipId = "FloorToRoomRelationship";
            var floorCooledByHvacRelationshipId = "FloorToHvacRelationship";
            var hvacCoolsFloorRelationshipId = "HvacToFloorRelationship";
            var roomContainedInFloorRelationshipId = "RoomToFloorRelationship";

            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);
            string hvacModelId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.HvacModelIdPrefix).ConfigureAwait(false);

            string floorTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.FloorTwinIdPrefix).ConfigureAwait(false);
            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string hvacTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.HvacTwinIdPrefix).ConfigureAwait(false);

            try
            {
                // create floor, room and hvac model
                string floorModel = TestAssetsHelper.GetFloorModelPayload(floorModelId, roomModelId, hvacModelId);
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                string hvacModel = TestAssetsHelper.GetHvacModelPayload(hvacModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { floorModel, roomModel, hvacModel }).ConfigureAwait(false);

                // create floor twin
                string floorTwin = TestAssetsHelper.GetFloorTwinPayload(floorModelId);
                await client.CreateDigitalTwinAsync(floorTwinId, floorTwin).ConfigureAwait(false);

                // Create room twin
                string roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

                // create hvac twin
                string hvacTwin = TestAssetsHelper.GetHvacTwinPayload(hvacModelId);
                await client.CreateDigitalTwinAsync(hvacTwinId, hvacTwin).ConfigureAwait(false);

                string floorContainsRoomPayload = TestAssetsHelper.GetRelationshipWithPropertyPayload(roomTwinId, ContainsRelationship, "isAccessRestricted", true);
                string floorTwinCoolsRelationshipPayload = TestAssetsHelper.GetRelationshipPayload(floorTwinId, CoolsRelationship);
                string floorTwinContainedInRelationshipPayload = TestAssetsHelper.GetRelationshipPayload(floorTwinId, ContainedInRelationship);
                string floorCooledByHvacPayload = TestAssetsHelper.GetRelationshipPayload(hvacTwinId, CooledByRelationship);
                string floorContainsRoomUpdatePayload = TestAssetsHelper.GetRelationshipUpdatePayload("/isAccessRestricted", false);

                // CREATE relationships

                // create Relationship from Floor -> Room
                await client
                    .CreateRelationshipAsync(
                        floorTwinId,
                        floorContainsRoomRelationshipId,
                        floorContainsRoomPayload)
                    .ConfigureAwait(false);

                // create Relationship from Floor -> Hvac
                await client
                    .CreateRelationshipAsync(
                        floorTwinId,
                        floorCooledByHvacRelationshipId,
                        floorCooledByHvacPayload)
                    .ConfigureAwait(false);

                // create Relationship from Hvac -> Floor
                await client
                    .CreateRelationshipAsync(
                        hvacTwinId,
                        hvacCoolsFloorRelationshipId,
                        floorTwinCoolsRelationshipPayload)
                    .ConfigureAwait(false);

                // create Relationship from Room -> Floor
                await client
                    .CreateRelationshipAsync(
                        roomTwinId,
                        roomContainedInFloorRelationshipId,
                        floorTwinContainedInRelationshipPayload)
                    .ConfigureAwait(false);

                // UPDATE relationships

                // create Relationship from Floor -> Room
                await client
                    .UpdateRelationshipAsync(
                        floorTwinId,
                        floorContainsRoomRelationshipId,
                        floorContainsRoomUpdatePayload)
                    .ConfigureAwait(false);

                // GET relationship
                Response<string> containsRelationshipId = await client
                    .GetRelationshipAsync(
                        floorTwinId,
                        floorContainsRoomRelationshipId)
                    .ConfigureAwait(false);

                // LIST incoming relationships
                AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync(floorTwinId);

                int numberOfIncomingRelationshipsToFloor = 0;
                await foreach (IncomingRelationship relationship in incomingRelationships)
                {
                    ++numberOfIncomingRelationshipsToFloor;
                }
                numberOfIncomingRelationshipsToFloor.Should().Be(2, "floor has incoming relationships from room and hvac");

                // LIST relationships
                AsyncPageable<string> floorRelationships = client.GetRelationshipsAsync(floorTwinId);

                int numberOfFloorRelationships = 0;
                await foreach (var relationship in floorRelationships)
                {
                    ++numberOfFloorRelationships;
                }
                numberOfFloorRelationships.Should().Be(2, "floor has an relationship to room and hvac");

                // LIST relationships by name
                AsyncPageable<string> roomTwinRelationships = client
                   .GetRelationshipsAsync(
                       roomTwinId,
                       ContainedInRelationship);
                containsRelationshipId.Value.Should().Contain(floorContainsRoomRelationshipId);

                int numberOfRelationships = 0;
                await foreach (var relationship in roomTwinRelationships)
                {
                    ++numberOfRelationships;
                }
                numberOfRelationships.Should().Be(1, "room has only one containedIn relationship to floor");

                await client
                    .DeleteRelationshipAsync(
                        floorTwinId,
                        floorContainsRoomRelationshipId)
                    .ConfigureAwait(false);

                await client
                    .DeleteRelationshipAsync(
                        roomTwinId,
                        roomContainedInFloorRelationshipId)
                    .ConfigureAwait(false);

                await client
                   .DeleteRelationshipAsync(
                        floorTwinId,
                        floorCooledByHvacRelationshipId)
                   .ConfigureAwait(false);

                await client
                   .DeleteRelationshipAsync(
                        hvacTwinId,
                        hvacCoolsFloorRelationshipId)
                   .ConfigureAwait(false);

                Func<Task> act = async () =>
                {
                    await client
                        .GetRelationshipAsync(
                            floorTwinId,
                            floorContainsRoomRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync(
                            roomTwinId,
                            roomContainedInFloorRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>().
                    And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync(
                            floorTwinId,
                            floorCooledByHvacRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>().
                    And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync(
                            hvacTwinId,
                            hvacCoolsFloorRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);
            }
            finally
            {
                // clean up
                try
                {
                    await Task
                        .WhenAll(
                            client.DeleteDigitalTwinAsync(floorTwinId),
                            client.DeleteDigitalTwinAsync(roomTwinId),
                            client.DeleteDigitalTwinAsync(hvacTwinId),
                            client.DeleteModelAsync(hvacModelId),
                            client.DeleteModelAsync(floorModelId),
                            client.DeleteModelAsync(roomModelId))
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}
