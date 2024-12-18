// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class DataflowEndpointsTests : IoTOperationsManagementClientBase
    {
        public DataflowEndpointsTests(bool isAsync)
            : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDataflowEndpoints()
        {
            // Get DataflowEndpoints
            DataflowEndpointResourceCollection dataflowEndpointsResourceCollection =
                await GetDataflowEndpointResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            DataflowEndpointResource dataflowEndpointsResource =
                await dataflowEndpointsResourceCollection.GetAsync("default");

            Assert.IsNotNull(dataflowEndpointsResource);
            Assert.IsNotNull(dataflowEndpointsResource.Data);
            Assert.AreEqual(dataflowEndpointsResource.Data.Name, "default");

            // Update DataflowEndpoint
            string utcTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            DataflowEndpointResourceData dataflowEndpointsResourceData =
                CreateDataflowEndpointResourceData(dataflowEndpointsResource, utcTime);

            ArmOperation<DataflowEndpointResource> resp =
                await dataflowEndpointsResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    dataflowEndpointsResourceData
                );
            DataflowEndpointResource updatedDataflowEndpoint = resp.Value;

            Assert.IsNotNull(updatedDataflowEndpoint);
            Assert.IsNotNull(updatedDataflowEndpoint.Data);
            Assert.IsNotNull(updatedDataflowEndpoint.Data.Properties);
        }

        private DataflowEndpointResourceData CreateDataflowEndpointResourceData(
            DataflowEndpointResource dataflowEndpointsResource,
            string utcTime
        )
        {
            EndpointType endpointType = dataflowEndpointsResource.Data.Properties.EndpointType;
            DataflowEndpointMqtt mqttSettings = new DataflowEndpointMqtt
            {
                Host = dataflowEndpointsResource.Data.Properties.MqttSettings.Host,
                Authentication = dataflowEndpointsResource
                    .Data
                    .Properties
                    .MqttSettings
                    .Authentication,
                Tls = dataflowEndpointsResource.Data.Properties.MqttSettings.Tls,
                Protocol = dataflowEndpointsResource.Data.Properties.MqttSettings.Protocol,
                KeepAliveSeconds = dataflowEndpointsResource
                    .Data
                    .Properties
                    .MqttSettings
                    .KeepAliveSeconds,
                Retain = dataflowEndpointsResource.Data.Properties.MqttSettings.Retain,
                Qos = dataflowEndpointsResource.Data.Properties.MqttSettings.Qos,
                SessionExpirySeconds = dataflowEndpointsResource
                    .Data
                    .Properties
                    .MqttSettings
                    .SessionExpirySeconds,
                CloudEventAttributes = dataflowEndpointsResource
                    .Data
                    .Properties
                    .MqttSettings
                    .CloudEventAttributes,
            };
            return new DataflowEndpointResourceData(
                new ExtendedLocation(
                    "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.ExtendedLocation/customLocations/location-o5fjq",
                    ExtendedLocationType.CustomLocation
                )
            )
            {
                Properties = new DataflowEndpointProperties
                {
                    EndpointType = endpointType,
                    MqttSettings = mqttSettings,
                    LocalStoragePersistentVolumeClaimRef = "dummy-volume-claim-ref-" + utcTime,
                },
                // LocalStoragePersistentVolumeClaimRef = "LocalStoragePersistentVolumeClaimRef",
            };
        }
    }
}
