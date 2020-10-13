// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class QueryTests : E2eTestBase
    {
        public QueryTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Query_ValidQuery_Success()
        {
            DigitalTwinsClient client = GetClient();

            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
                string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
                string roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

                string queryString = "SELECT * FROM digitaltwins where IsOccupied = true";

                // act
                AsyncPageable<string> asyncPageableResponse = client.QueryAsync(queryString);

                // assert
                await foreach (string response in asyncPageableResponse)
                {
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(response);
                    JsonElement isOccupied = jsonElement.GetProperty("IsOccupied");
                    isOccupied.GetRawText().Should().Be("true");
                }
            }
            finally
            {
                // clean up
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task Query_PaginationWorks()
        {
            DigitalTwinsClient client = GetClient();
            int pageSize = 5;
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
                string roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);

                for (int i = 0; i < pageSize + 1; i++)
                {
                    string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
                    await client.CreateDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);
                }

                string queryString = "SELECT * FROM digitaltwins";

                // act
                var options = new QueryTwinsOptions();
                options.MaxItemsPerPage = pageSize;
                AsyncPageable<string> asyncPageableResponse = client.QueryAsync(queryString, options);

                // assert
                // Test that page size hint works, and that all returned pages either have the page size hint amount of
                // elements, or have no continuation token (signaling that it is the last page)
                int pageCount = 0;
                await foreach (Page<string> page in asyncPageableResponse.AsPages())
                {
                    pageCount++;
                    if (page.ContinuationToken != null)
                    {
                        page.Values.Count.Should().Be(pageSize, "Unexpected page size for a non-terminal page");
                    }
                }

                pageCount.Should().BeGreaterThan(1, "Expected more than one page of query results");
            }
            finally
            {
                // clean up
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}
