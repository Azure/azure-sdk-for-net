// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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
            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
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

                    if (!string.IsNullOrWhiteSpace(roomTwinId))
                    {
                        await client.DeleteDigitalTwinAsync(roomTwinId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        // TODO:azabbasi: Once you enable this test by removing the Ignore attribute, make sure to record and update session records.
        [Test]
        [Ignore("Waiting for Azure.Core to fix the issue with AsPages helper method")]
        public async Task Query_MultiplePages_Resuming_Success()
        {
            DigitalTwinsClient client = GetClient();

            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);

            int numberOfTwinsToCreate = 250;
            IEnumerable<string> newTwinIds = GetMultipleTwinIds(roomTwinId, numberOfTwinsToCreate);

            try
            {
                //arrange

                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { roomModel }).ConfigureAwait(false);

                // Create multiple room twins, with property "IsOccupied": true
                // We do this to make sure the service is going to return multiple pages in the response.
                List<Task> tasks = new List<Task>();

                foreach (var twinName in newTwinIds)
                {
                    string roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                    tasks.Add(client.CreateDigitalTwinAsync(twinName, roomTwin));
                }

                Task.WaitAll(tasks.ToArray());

                string queryString = "SELECT * FROM digitaltwins where IsOccupied = true";

                // act
                IAsyncEnumerable<Page<string>> asyncPageableResponse = client.QueryAsync(queryString).AsPages();
                string continuationToken = null;

                // Get the first page and store the continuation token.
                await foreach (Page<string> page in asyncPageableResponse)
                {
                    Console.WriteLine(page.ContinuationToken);
                    continuationToken = page.ContinuationToken;
                    break;
                }

                // resume getting the query response by providing the continuation token.
                IAsyncEnumerable<Page<string>> nextPages = client.QueryAsync(queryString).AsPages(continuationToken);
                await foreach (Page<string> page in nextPages)
                {
                    // Make sure resume functionality works by comparing the new continuation token and the previously provided continuation token.
                    Assert.AreNotEqual(
                        continuationToken,
                        page.ContinuationToken,
                        "ContinuationToken should not remain the same when using resume functionality");

                    break;
                }
            }
            finally
            {
                //clean up
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                        if (!string.IsNullOrEmpty(roomTwinId))
                        {
                            List<Task> tasks = new List<Task>();

                            foreach (string twinName in newTwinIds)
                            {
                                tasks.Add(client.DeleteDigitalTwinAsync(twinName));
                            }

                            Task.WaitAll(tasks.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        private IEnumerable<string> GetMultipleTwinIds(string baseName, int count)
        {
            var listOfTwinIds = new List<string>();
            for (int i = 0; i < count; i++)
            {
               listOfTwinIds.Add(baseName + $"random{i}");
            }

            return listOfTwinIds;
        }
    }
}
