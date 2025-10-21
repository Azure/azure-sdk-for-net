// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryNamespaceDiscoveredDevicesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _namespaceRgName = "adr-sdk-test-rg";
        private readonly string _namespaceName = "adr-namespace";
        private readonly string _discoveredDeviceNamePrefix = "deviceregistry-test-discovereddevice-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryNamespaceDiscoveredDevicesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespaceDiscoveredDevicesCrudOperationsTest()
        {
            var discoveredDeviceName = Recording.GenerateAssetName(_discoveredDeviceNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var namespaceRg = await subscription.GetResourceGroupAsync(_namespaceRgName);
            var namespacesCollection = namespaceRg.Value.GetDeviceRegistryNamespaces();
            var namespaceResource = await namespacesCollection.GetAsync(_namespaceName);
            var discoveredDevicesCollection = namespaceResource.Value.GetDeviceRegistryNamespaceDiscoveredDevices();

            // Create DeviceRegistry Device
            var discoveredDeviceData = new DeviceRegistryNamespaceDiscoveredDeviceData(AzureLocation.WestUS2, extendedLocation)
            {
                Properties = new("myDiscoveryId", 1)
                {
                    Manufacturer = "Constoso",
                    Model = "Model 5000",
                    OperatingSystem = "Linux",
                    OperatingSystemVersion = "18.04",
                    Endpoints = new DiscoveredMessagingEndpoints(),
                    DiscoveryId = "myDiscoveryId",
                    Version = 1,
                }
            };
            discoveredDeviceData.Properties.Endpoints.Inbound.Add("myendpoint1", new DiscoveredInboundEndpoints("Microsoft.Devices/IoTHubs", "https://myendpoint1.westeurope-1.iothub.azure.net", "1", [AuthenticationMethod.Certificate], "", null, null));
            discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].SupportedAuthenticationMethods.Add(AuthenticationMethod.Certificate);
            var discoveredDeviceCreateOrUpdateResponse = await discoveredDevicesCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveredDeviceName, discoveredDeviceData, CancellationToken.None);
            Assert.IsNotNull(discoveredDeviceCreateOrUpdateResponse.Value);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.Manufacturer, discoveredDeviceData.Properties.Manufacturer);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.Model, discoveredDeviceData.Properties.Model);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystem, discoveredDeviceData.Properties.OperatingSystem);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystemVersion, discoveredDeviceData.Properties.OperatingSystemVersion);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].Address);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredDeviceData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredDeviceCreateOrUpdateResponse.Value.Data.Properties.Version, discoveredDeviceData.Properties.Version);

            // Read DeviceRegistry DiscoveredDevice
            var discoveredDeviceReadResponse = await discoveredDevicesCollection.GetAsync(discoveredDeviceName, CancellationToken.None);
            Assert.IsNotNull(discoveredDeviceReadResponse.Value);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.Manufacturer, discoveredDeviceData.Properties.Manufacturer);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.Model, discoveredDeviceData.Properties.Model);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.OperatingSystem, discoveredDeviceData.Properties.OperatingSystem);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.OperatingSystemVersion, discoveredDeviceData.Properties.OperatingSystemVersion);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].Address);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.DiscoveryId, discoveredDeviceData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredDeviceReadResponse.Value.Data.Properties.Version, discoveredDeviceData.Properties.Version);

            // List DeviceRegistry DiscoveredDevice by Resource Group
            var discoveredDeviceResourcesListByResourceGroup = new List<DeviceRegistryNamespaceDiscoveredDeviceResource>();
            var discoveredDeviceResourceListByResourceGroupAsyncIteratorPage = discoveredDevicesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var discoveredDeviceEntryPage in discoveredDeviceResourceListByResourceGroupAsyncIteratorPage)
            {
                discoveredDeviceResourcesListByResourceGroup.AddRange(discoveredDeviceEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(discoveredDeviceResourcesListByResourceGroup);
            Assert.GreaterOrEqual(discoveredDeviceResourcesListByResourceGroup.Count, 1);

            // Update DeviceRegistry Device
            var discoveredDevice = discoveredDeviceReadResponse.Value;
            var discoveredDevicePatchData = new DeviceRegistryNamespaceDiscoveredDevicePatch
            {
                Properties = new()
                {
                    OperatingSystemVersion = "20.04",
                    DiscoveryId = discoveredDeviceData.Properties.DiscoveryId,
                }
            };
            var discoveredDeviceUpdateResponse = await discoveredDevice.UpdateAsync(WaitUntil.Completed, discoveredDevicePatchData, CancellationToken.None);
            Assert.IsNotNull(discoveredDeviceUpdateResponse.Value);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.Manufacturer, discoveredDeviceData.Properties.Manufacturer);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.Model, discoveredDeviceData.Properties.Model);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.OperatingSystem, discoveredDeviceData.Properties.OperatingSystem);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.OperatingSystemVersion, discoveredDevicePatchData.Properties.OperatingSystemVersion);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].Address);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, discoveredDeviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredDeviceData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredDeviceUpdateResponse.Value.Data.Properties.Version, discoveredDeviceData.Properties.Version);

            // Delete DeviceRegistry Device
            await discoveredDevice.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
