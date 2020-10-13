// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

                await client.CreateModelsAsync(new List<string> { roomWithWifiModel, wifiModel }).ConfigureAwait(false);

                // create room digital twin
                string roomWithWifiTwin = TestAssetsHelper.GetRoomWithWifiTwinPayload(roomWithWifiModelId, wifiComponentName);

                await client.CreateDigitalTwinAsync(roomWithWifiTwinId, roomWithWifiTwin);

                // Get the component
                Response<string> getComponentResponse = await client
                    .GetComponentAsync(
                        roomWithWifiTwinId,
                        wifiComponentName)
                    .ConfigureAwait(false);

                // The response to the GET request should be 200 (OK)
                getComponentResponse.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);

                // Patch component
                Response<string> updateComponentResponse = await client
                    .UpdateComponentAsync(
                        roomWithWifiTwinId,
                        wifiComponentName,
                        TestAssetsHelper.GetWifiComponentUpdatePayload())
                    .ConfigureAwait(false);

                // The response to the Patch request should be 204 (No content)
                updateComponentResponse.GetRawResponse().Status.Should().Be((int)HttpStatusCode.NoContent);
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
