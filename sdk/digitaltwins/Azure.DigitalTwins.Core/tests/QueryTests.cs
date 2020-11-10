// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class QueryTests : E2eTestBase
    {
        private static readonly int s_retryCount = 10;
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(2);

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
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
                string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

                // Construct a query string to find the twins with the EXACT model id and provided version. If EXACT is not specified, the query
                // call will get all twins with the same model id but that implement any version higher than the provided version
                string queryString = $"SELECT * FROM digitaltwins WHERE IS_OF_MODEL('{roomModelId}', EXACT) AND IsOccupied = true";

                // act
                AsyncPageable<BasicDigitalTwin> asyncPageableResponse = client.QueryAsync<BasicDigitalTwin>(queryString);

                // assert

                // It takes a few seconds for the service to be able to fetch digital twins through queries after being created. Hence, adding the retry logic
                var digitalTwinFound = false;
                await TestRetryHelper.RetryAsync<AsyncPageable<BasicDigitalTwin>>(async () =>
                {
                    await foreach (BasicDigitalTwin response in asyncPageableResponse)
                    {
                        digitalTwinFound = true;
                        bool isOccupied = ((JsonElement)response.Contents["IsOccupied"]).GetBoolean();
                        isOccupied.Should().BeTrue();
                        break;
                    }

                    if (!digitalTwinFound)
                    {
                        throw new Exception($"Digital twin based on model Id {roomModelId} not found");
                    }

                    return null;
                }, s_retryCount, s_retryDelay);

                digitalTwinFound.Should().BeTrue();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
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
            TimeSpan QueryWaitTimeout = TimeSpan.FromMinutes(1); // Wait at most one minute for the created twins to become queryable

            try
            {
                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);

                for (int i = 0; i < pageSize * 2; i++)
                {
                    string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
                    await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);
                }

                string queryString = "SELECT * FROM digitaltwins";

                // act
                CancellationTokenSource queryTimeoutCancellationToken = new CancellationTokenSource(QueryWaitTimeout);
                bool queryHasExpectedCount = false;
                while (!queryHasExpectedCount)
                {
                    if (queryTimeoutCancellationToken.IsCancellationRequested)
                    {
                        throw new AssertionException($"Timed out waiting for at least {pageSize + 1} twins to be queryable");
                    }

                    AsyncPageable<BasicDigitalTwin> asyncPageableResponse = client.QueryAsync<BasicDigitalTwin>(queryString, queryTimeoutCancellationToken.Token);
                    int count = 0;
                    await foreach (Page<BasicDigitalTwin> queriedTwinPage in asyncPageableResponse.AsPages(pageSizeHint: pageSize))
                    {
                        count += queriedTwinPage.Values.Count;
                    }

                    // Once at least (page + 1) twins are query-able, then page size control can be tested.
                    queryHasExpectedCount = count >= pageSize + 1;
                }

                // assert
                // Test that page size hint works, and that all returned pages either have the page size hint amount of
                // elements, or have no continuation token (signaling that it is the last page)
                int pageCount = 0;
                await foreach (Page<BasicDigitalTwin> page in client.QueryAsync<BasicDigitalTwin>(queryString).AsPages(pageSizeHint: pageSize))
                {
                    pageCount++;
                    if (page.ContinuationToken != null)
                    {
                        page.Values.Count.Should().Be(pageSize, "Unexpected page size for a non-terminal page");
                    }
                }

                pageCount.Should().BeGreaterThan(1, "Expected more than one page of query results");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
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
        public async Task Query_GetTwinCount()
        {
            DigitalTwinsClient client = GetClient();

            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // Create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // Create a room twin, with property "IsOccupied": true
                string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

                // Construct a query string to find the twins with the EXACT model id and provided version. If EXACT is not specified, the query
                // call will get all twins with the same model id but that implement any version higher than the provided version
                string queryString = $"SELECT COUNT() FROM digitaltwins WHERE IS_OF_MODEL('{roomModelId}', EXACT) AND IsOccupied = true";

                // act
                AsyncPageable<JsonElement> asyncPageableResponse = client.QueryAsync<JsonElement>(queryString);

                // assert

                // It takes a few seconds for the service to be able to fetch digital twins through queries after being created. Hence, adding the retry logic
                var currentCount = 0;
                await TestRetryHelper.RetryAsync<AsyncPageable<JsonElement>>(async () =>
                {
                    await foreach (JsonElement response in asyncPageableResponse)
                    {
                        string currentCountStr = response.GetRawText();
                        IDictionary<string, int> currentCountDictionary = JsonSerializer.Deserialize<IDictionary<string, int>>(currentCountStr);
                        currentCountDictionary.ContainsKey("COUNT").Should().BeTrue();
                        currentCount = currentCountDictionary["COUNT"];
                    }

                    if (currentCount == 0)
                    {
                        throw new Exception($"Digital twin based on model Id {roomModelId} not found");
                    }

                    return null;
                }, s_retryCount, s_retryDelay);

                currentCount.Should().Be(1);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
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
