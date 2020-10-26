// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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

        // Relationships list operation default max item count is 10. We create 31 to make sure we will get over 3 pages of response.
        // Ideally, service team would let us set max items per page when listing, but that isn't a feature yet
        private const int bulkRelationshipCount = 31;

        private const int defaultRelationshipPageSize = 10;

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
                BasicDigitalTwin floorTwin = TestAssetsHelper.GetFloorTwinPayload(floorModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(floorTwinId, floorTwin).ConfigureAwait(false);

                // Create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // create hvac twin
                BasicDigitalTwin hvacTwin = TestAssetsHelper.GetHvacTwinPayload(hvacModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(hvacTwinId, hvacTwin).ConfigureAwait(false);

                BasicRelationship floorContainsRoomPayload = TestAssetsHelper.GetRelationshipWithPropertyPayload(roomTwinId, ContainsRelationship, "isAccessRestricted", true);
                BasicRelationship floorTwinCoolsRelationshipPayload = TestAssetsHelper.GetRelationshipPayload(floorTwinId, CoolsRelationship);
                BasicRelationship floorTwinContainedInRelationshipPayload = TestAssetsHelper.GetRelationshipPayload(floorTwinId, ContainedInRelationship);
                BasicRelationship floorCooledByHvacPayload = TestAssetsHelper.GetRelationshipPayload(hvacTwinId, CooledByRelationship);
                JsonPatchDocument floorContainsRoomUpdatePayload = new JsonPatchDocument();
                floorContainsRoomUpdatePayload.AppendReplace("/isAccessRestricted", false);

                // CREATE relationships

                // create Relationship from Floor -> Room
                await client
                    .CreateOrReplaceRelationshipAsync<BasicRelationship>(
                        floorTwinId,
                        floorContainsRoomRelationshipId,
                        floorContainsRoomPayload)
                    .ConfigureAwait(false);

                // create Relationship from Floor -> Hvac
                await client
                    .CreateOrReplaceRelationshipAsync<BasicRelationship>(
                        floorTwinId,
                        floorCooledByHvacRelationshipId,
                        floorCooledByHvacPayload)
                    .ConfigureAwait(false);

                // create Relationship from Hvac -> Floor
                await client
                    .CreateOrReplaceRelationshipAsync<BasicRelationship>(
                        hvacTwinId,
                        hvacCoolsFloorRelationshipId,
                        floorTwinCoolsRelationshipPayload)
                    .ConfigureAwait(false);

                // create Relationship from Room -> Floor
                await client
                    .CreateOrReplaceRelationshipAsync<BasicRelationship>(
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
                Response<BasicRelationship> containsRelationshipId = await client
                    .GetRelationshipAsync<BasicRelationship>(
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
                containsRelationshipId.Value.Id.Should().Be(floorContainsRoomRelationshipId);

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
                        .GetRelationshipAsync<BasicRelationship>(
                            floorTwinId,
                            floorContainsRoomRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync<BasicRelationship>(
                            roomTwinId,
                            roomContainedInFloorRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>().
                    And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync<BasicRelationship>(
                            floorTwinId,
                            floorCooledByHvacRelationshipId)
                        .ConfigureAwait(false);
                };
                act.Should().Throw<RequestFailedException>().
                    And.Status.Should().Be((int)HttpStatusCode.NotFound);

                act = async () =>
                {
                    await client
                        .GetRelationshipAsync<BasicRelationship>(
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

        public async Task Relationships_PaginationWorks()
        {
            DigitalTwinsClient client = GetClient();

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
                BasicDigitalTwin floorTwin = TestAssetsHelper.GetFloorTwinPayload(floorModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(floorTwinId, floorTwin).ConfigureAwait(false);

                // Create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                BasicRelationship floorContainsRoomPayload = TestAssetsHelper.GetRelationshipWithPropertyPayload(roomTwinId, ContainsRelationship, "isAccessRestricted", true);
                BasicRelationship floorTwinContainedInRelationshipPayload = TestAssetsHelper.GetRelationshipPayload(floorTwinId, ContainedInRelationship);

                // For the sake of test simplicity, we'll just add multiple relationships from the same floor to the same room.
                for (int i = 0; i < bulkRelationshipCount; i++)
                {
                    var floorContainsRoomRelationshipId = $"FloorToRoomRelationship-{GetRandom()}";

                    // create Relationship from Floor -> Room
                    await client
                        .CreateOrReplaceRelationshipAsync<BasicRelationship>(
                            floorTwinId,
                            floorContainsRoomRelationshipId,
                            floorContainsRoomPayload)
                        .ConfigureAwait(false);
                }

                // For the sake of test simplicity, we'll just add multiple relationships from the same room to the same floor.
                for (int i = 0; i < bulkRelationshipCount; i++)
                {
                    var roomContainedInFloorRelationshipId = $"RoomToFloorRelationship-{GetRandom()}";

                    // create Relationship from Room -> Floor
                    await client
                    .CreateOrReplaceRelationshipAsync<BasicRelationship>(
                        roomTwinId,
                        roomContainedInFloorRelationshipId,
                        floorTwinContainedInRelationshipPayload)
                    .ConfigureAwait(false);
                }

                // LIST incoming relationships by page
                AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync(floorTwinId);

                int incomingRelationshipPageCount = 0;
                await foreach (Page<IncomingRelationship> incomingRelationshipPage in incomingRelationships.AsPages())
                {
                    incomingRelationshipPageCount++;
                    if (incomingRelationshipPage.ContinuationToken != null)
                    {
                        incomingRelationshipPage.Values.Count.Should().Be(defaultRelationshipPageSize, "Unexpected page size for a non-terminal page");
                    }
                }

                incomingRelationshipPageCount.Should().BeGreaterThan(1, "Expected more than one page of incoming relationships");

                // LIST outgoing relationships by page
                AsyncPageable<string> outgoingRelationships = client.GetRelationshipsAsync(floorTwinId);

                int outgoingRelationshipPageCount = 0;
                await foreach (Page<string> outgoingRelationshipPage in outgoingRelationships.AsPages())
                {
                    outgoingRelationshipPageCount++;
                    if (outgoingRelationshipPage.ContinuationToken != null)
                    {
                        outgoingRelationshipPage.Values.Count.Should().Be(defaultRelationshipPageSize, "Unexpected page size for a non-terminal page");
                    }
                }

                outgoingRelationshipPageCount.Should().BeGreaterThan(1, "Expected more than one page of outgoing relationships");
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
