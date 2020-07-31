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
    }
}
