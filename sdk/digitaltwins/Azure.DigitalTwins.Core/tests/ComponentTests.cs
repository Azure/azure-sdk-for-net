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
    public class ComponentTests : E2eTestBase
    {
        public ComponentTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Component_Lifecycle()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            string wifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomWithWifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomWithWifiTwinIdPrefix).ConfigureAwait(false);
            string wifiComponentName = "wifiAccessPoint";

            try
            {
                // CREATE

                // create roomWithWifi model
                string wifiModel = TestAssetsHelper.GetWifiModelPayload(wifiModelId);

                // create wifi model
                string roomWithWifiModel = TestAssetsHelper.GetRoomWithWifiModelPayload(roomWithWifiModelId, wifiModelId, wifiComponentName);

                await CreateAndListModelsAsync(client, new List<string> { roomWithWifiModel, wifiModel }).ConfigureAwait(false);

                // create room digital twin
                BasicDigitalTwin roomWithWifiTwin = TestAssetsHelper.GetRoomWithWifiTwinPayload(roomWithWifiModelId, wifiComponentName);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId, roomWithWifiTwin);

                // Get the component
                Response<object> getComponentResponse = await client
                    .GetComponentAsync<object>(
                        roomWithWifiTwinId,
                        wifiComponentName)
                    .ConfigureAwait(false);

                // The response to the GET request should be 200 (OK)
                getComponentResponse.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);

                // Patch component
                JsonPatchDocument componentUpdatePatchDocument = new JsonPatchDocument();
                componentUpdatePatchDocument.AppendReplace("/Network", "New Network");

                Response updateComponentResponse = await client
                    .UpdateComponentAsync(
                        roomWithWifiTwinId,
                        wifiComponentName,
                        componentUpdatePatchDocument)
                    .ConfigureAwait(false);

                // The response to the Patch request should be 204 (No content)
                updateComponentResponse.Status.Should().Be((int)HttpStatusCode.NoContent);
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
                    if (!string.IsNullOrWhiteSpace(roomWithWifiTwinId))
                    {
                        await client.DeleteDigitalTwinAsync(roomWithWifiTwinId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(roomWithWifiModelId))
                    {
                        await client.DeleteModelAsync(roomWithWifiModelId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(wifiModelId))
                    {
                        await client.DeleteModelAsync(wifiModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task Component_UpdateComponentFailsWhenIfMatchHeaderOutOfDate()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            string wifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomWithWifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomWithWifiTwinIdPrefix).ConfigureAwait(false);
            string wifiComponentName = "wifiAccessPoint";

            try
            {
                // CREATE

                // create roomWithWifi model
                string wifiModel = TestAssetsHelper.GetWifiModelPayload(wifiModelId);

                // create wifi model
                string roomWithWifiModel = TestAssetsHelper.GetRoomWithWifiModelPayload(roomWithWifiModelId, wifiModelId, wifiComponentName);

                await CreateAndListModelsAsync(client, new List<string> { roomWithWifiModel, wifiModel }).ConfigureAwait(false);

                // create room digital twin
                BasicDigitalTwin roomWithWifiTwin = TestAssetsHelper.GetRoomWithWifiTwinPayload(roomWithWifiModelId, wifiComponentName);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId, roomWithWifiTwin);

                // Get the component
                Response<object> getComponentResponse = await client
                    .GetComponentAsync<object>(
                        roomWithWifiTwinId,
                        wifiComponentName)
                    .ConfigureAwait(false);

                ETag? etagBeforeUpdate = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId)).Value.ETag;

                // Patch component
                JsonPatchDocument componentUpdatePatchDocument = new JsonPatchDocument();
                componentUpdatePatchDocument.AppendReplace("/Network", "New Network");

                Response updateComponentResponse = await client
                    .UpdateComponentAsync(
                        roomWithWifiTwinId,
                        wifiComponentName,
                        componentUpdatePatchDocument)
                    .ConfigureAwait(false);

                // Patch component again, but with the now out of date ETag
                JsonPatchDocument secondComponentUpdatePatchDocument = new JsonPatchDocument();
                secondComponentUpdatePatchDocument.AppendReplace("/Network", "Even newer Network");

                Func<Task> act = async () =>
                {
                    await client
                        .UpdateComponentAsync(
                            roomWithWifiTwinId,
                            wifiComponentName,
                            secondComponentUpdatePatchDocument,
                            etagBeforeUpdate)
                        .ConfigureAwait(false);
                };

                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.PreconditionFailed);
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
                    if (!string.IsNullOrWhiteSpace(roomWithWifiTwinId))
                    {
                        await client.DeleteDigitalTwinAsync(roomWithWifiTwinId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(roomWithWifiModelId))
                    {
                        await client.DeleteModelAsync(roomWithWifiModelId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(wifiModelId))
                    {
                        await client.DeleteModelAsync(wifiModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task Component_UpdateComponentSucceedsWhenIfMatchHeaderIsCorrect()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            string wifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomWithWifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomWithWifiTwinIdPrefix).ConfigureAwait(false);
            string wifiComponentName = "wifiAccessPoint";

            try
            {
                // CREATE

                // create roomWithWifi model
                string wifiModel = TestAssetsHelper.GetWifiModelPayload(wifiModelId);

                // create wifi model
                string roomWithWifiModel = TestAssetsHelper.GetRoomWithWifiModelPayload(roomWithWifiModelId, wifiModelId, wifiComponentName);

                await CreateAndListModelsAsync(client, new List<string> { roomWithWifiModel, wifiModel }).ConfigureAwait(false);

                // create room digital twin
                BasicDigitalTwin roomWithWifiTwin = TestAssetsHelper.GetRoomWithWifiTwinPayload(roomWithWifiModelId, wifiComponentName);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId, roomWithWifiTwin);

                // Get the component
                Response<object> getComponentResponse = await client
                    .GetComponentAsync<object>(
                        roomWithWifiTwinId,
                        wifiComponentName)
                    .ConfigureAwait(false);

                // Patch component
                JsonPatchDocument componentUpdatePatchDocument = new JsonPatchDocument();
                componentUpdatePatchDocument.AppendReplace("/Network", "New Network");

                Response updateComponentResponse = await client
                    .UpdateComponentAsync(
                        roomWithWifiTwinId,
                        wifiComponentName,
                        componentUpdatePatchDocument)
                    .ConfigureAwait(false);

                // Get the latest ETag
                ETag? etagBeforeUpdate = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId)).Value.ETag;
                Assert.IsNotNull(etagBeforeUpdate);

                // Patch component again, but with the now out of date ETag
                JsonPatchDocument secondComponentUpdatePatchDocument = new JsonPatchDocument();
                componentUpdatePatchDocument.AppendReplace("/Network", "Even newer Network");

                try
                {
                    await client
                        .UpdateComponentAsync(
                            roomWithWifiTwinId,
                            wifiComponentName,
                            secondComponentUpdatePatchDocument,
                            etagBeforeUpdate)
                        .ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.PreconditionFailed)
                {
                    throw new AssertionException("UpdateComponent should not have thrown PreconditionFailed because the ETag was up to date", ex);
                }
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
                    if (!string.IsNullOrWhiteSpace(roomWithWifiTwinId))
                    {
                        await client.DeleteDigitalTwinAsync(roomWithWifiTwinId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(roomWithWifiModelId))
                    {
                        await client.DeleteModelAsync(roomWithWifiModelId).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrWhiteSpace(wifiModelId))
                    {
                        await client.DeleteModelAsync(wifiModelId).ConfigureAwait(false);
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
