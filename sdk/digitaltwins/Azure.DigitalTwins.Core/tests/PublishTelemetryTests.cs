// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinsClient APIs that handle publishing telemetry messages to Azure Digital Twins.
    /// </summary>
    public class PublishTelemetryTests : E2eTestBase
    {
        public PublishTelemetryTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Infrastructure setup script uses this hard-coded value when linking the test eventhub to the test digital twins instance.
        private const string EndpointName = "someEventHubEndpoint";

        [Test]
        public async Task PublishTelemetry_Lifecycle()
        {
            // Setup

            // Create a DigitalTwinsClient instance.
            DigitalTwinsClient client = GetClient();

            string wifiComponentName = "wifiAccessPoint";
            string wifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomWithWifiModelIdPrefix).ConfigureAwait(false);
            string roomWithWifiTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomWithWifiTwinIdPrefix).ConfigureAwait(false);
            string eventRouteId = $"someEventRouteId-{GetRandom()}";

            try
            {
                // Create an event route for the digital twins client.
                DigitalTwinsEventRoute eventRoute = await CreateEventRoute(client, eventRouteId).ConfigureAwait(false);

                // Create the models needed for the digital twin.
                await CreateModelsAndTwins(client, wifiModelId, roomWithWifiModelId, wifiComponentName, roomWithWifiTwinId).ConfigureAwait(false);

                // Act - Test publishing telemetry to a digital twin.
                Response publishTelemetryResponse = await client.PublishTelemetryAsync(
                    roomWithWifiTwinId,
                    Recording.Random.NewGuid().ToString(),
                    "{\"Telemetry1\": 5}",
                    timestamp: default(DateTimeOffset))
                    .ConfigureAwait(false);

                // Assert
                publishTelemetryResponse.Status.Should().Be((int)HttpStatusCode.NoContent);

                // Act - Test publishing telemetry to a component in a digital twin.
                var telemetryPayload = new Dictionary<string, int>
                {
                    { "ComponentTelemetry1", 9}
                };
                Response publishComponentTelemetryResponse = await client.PublishComponentTelemetryAsync(
                    roomWithWifiTwinId,
                    wifiComponentName,
                    Recording.Random.NewGuid().ToString(),
                    JsonSerializer.Serialize(telemetryPayload),
                    timestamp: default(DateTimeOffset))
                    .ConfigureAwait(false);

                // Assert
                publishComponentTelemetryResponse.Status.Should().Be((int)HttpStatusCode.NoContent);
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
                    if (!string.IsNullOrWhiteSpace(eventRouteId))
                    {
                        await client.DeleteEventRouteAsync(eventRouteId).ConfigureAwait(false);
                    }
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

        private async Task CreateModelsAndTwins(DigitalTwinsClient client, string wifiModelId, string roomWithWifiModelId, string wifiComponentName, string roomWithWifiTwinId)
        {
            // Generate the payload needed to create the WiFi component model.
            string wifiModel = TestAssetsHelper.GetWifiModelPayload(wifiModelId);

            // Generate the payload needed to create the room with WiFi model.
            string roomWithWifiModel = TestAssetsHelper.GetRoomWithWifiModelPayload(roomWithWifiModelId, wifiModelId, wifiComponentName);

            // Create the room and WiFi models.
            await CreateAndListModelsAsync(client, new List<string> { roomWithWifiModel, wifiModel }).ConfigureAwait(false);

            // Generate the payload needed to create the room with WiFi twin.
            BasicDigitalTwin roomWithWifiTwin = TestAssetsHelper.GetRoomWithWifiTwinPayload(roomWithWifiModelId, wifiComponentName);

            // Create the room with WiFi component digital twin.
            await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomWithWifiTwinId, roomWithWifiTwin).ConfigureAwait(false);
        }

        private async Task<DigitalTwinsEventRoute> CreateEventRoute(DigitalTwinsClient client, string eventRouteId)
        {
            string filter = "type = 'Microsoft.DigitalTwins.Twin.Create' OR type = 'microsoft.iot.telemetry'";
            var eventRoute = new DigitalTwinsEventRoute(EndpointName, filter);

            // Create an event route.
            Response createEventRouteResponse = await client.CreateOrReplaceEventRouteAsync(eventRouteId, eventRoute).ConfigureAwait(false);
            createEventRouteResponse.Status.Should().Be((int)HttpStatusCode.NoContent);

            return eventRoute;
        }
    }
}
