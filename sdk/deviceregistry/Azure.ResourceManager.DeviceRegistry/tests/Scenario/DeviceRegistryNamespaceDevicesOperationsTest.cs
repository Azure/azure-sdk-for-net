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
    public class DeviceRegistryNamespaceDevicesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg-ns-devices";
        private readonly string _namespaceName = "adr-namespace";
        private readonly string _deviceNamePrefix = "deviceregistry-test-device-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryNamespaceDevicesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespaceDevicesCrudOperationsTest()
        {
            var deviceName = Recording.GenerateAssetName(_deviceNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var namespacesCollection = rg.GetDeviceRegistryNamespaces();
            var namespaceResource = await namespacesCollection.GetAsync(_namespaceName);
            var devicesCollection = namespaceResource.Value.GetDeviceRegistryNamespaceDevices();

            // Create DeviceRegistry Device
            var deviceData = new DeviceRegistryNamespaceDeviceData(AzureLocation.WestUS)
            {
                Properties = new()
                {
                    Manufacturer = "Constoso",
                    Model = "Model 5000",
                    OperatingSystem = "Linux",
                    OperatingSystemVersion = "18.04",
                    Attributes =
                    {
                        ["deviceType"] = BinaryData.FromString("sensor"),
                        ["deviceCategory"] = BinaryData.FromString("temperature"),
                    },
                }
            };
            var deviceCreateOrUpdateResponse = await devicesCollection.CreateOrUpdateAsync(WaitUntil.Completed, deviceName, deviceData, CancellationToken.None);
            Assert.IsNotNull(deviceCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(deviceCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.ExternalDeviceId, deviceCreateOrUpdateResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Manufacturer, deviceData.Properties.Manufacturer);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Model, deviceData.Properties.Model);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystem, deviceData.Properties.OperatingSystem);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystemVersion, deviceData.Properties.OperatingSystemVersion);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Attributes["deviceType"].ToString(), deviceData.Properties.Attributes["deviceType"].ToString());
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Attributes["deviceCategory"].ToString(), deviceData.Properties.Attributes["deviceCategory"].ToString());
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Version, 1);
            Assert.AreEqual(deviceCreateOrUpdateResponse.Value.Data.Properties.Enabled, true);

            // Read DeviceRegistry Device
            var deviceReadResponse = await devicesCollection.GetAsync(deviceName, CancellationToken.None);
            Assert.IsNotNull(deviceReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(deviceReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.ExternalDeviceId, deviceReadResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Manufacturer, deviceData.Properties.Manufacturer);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Model, deviceData.Properties.Model);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.OperatingSystem, deviceData.Properties.OperatingSystem);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.OperatingSystemVersion, deviceData.Properties.OperatingSystemVersion);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Attributes["deviceType"].ToString(), deviceData.Properties.Attributes["deviceType"].ToString());
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Attributes["deviceCategory"].ToString(), deviceData.Properties.Attributes["deviceCategory"].ToString());
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Version, 1);
            Assert.AreEqual(deviceReadResponse.Value.Data.Properties.Enabled, true);

            // List DeviceRegistry Device by Resource Group
            var deviceResourcesListByResourceGroup = new List<DeviceRegistryNamespaceDeviceResource>();
            var deviceResourceListByResourceGroupAsyncIteratorPage = devicesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var deviceEntryPage in deviceResourceListByResourceGroupAsyncIteratorPage)
            {
                deviceResourcesListByResourceGroup.AddRange(deviceEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(deviceResourcesListByResourceGroup);
            Assert.GreaterOrEqual(deviceResourcesListByResourceGroup.Count, 1);

            // Update DeviceRegistry Device
            var device = deviceReadResponse.Value;
            var devicePatchData = new DeviceRegistryNamespaceDevicePatch
            {
                Properties = new()
                {
                    OperatingSystemVersion = "20.04",
                }
            };
            var deviceUpdateResponse = await device.UpdateAsync(WaitUntil.Completed, devicePatchData, CancellationToken.None);
            Assert.IsNotNull(deviceUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(deviceUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.ExternalDeviceId, deviceUpdateResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Manufacturer, deviceData.Properties.Manufacturer);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Model, deviceData.Properties.Model);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.OperatingSystem, deviceData.Properties.OperatingSystem);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.OperatingSystemVersion, devicePatchData.Properties.OperatingSystemVersion);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Attributes["deviceType"].ToString(), deviceData.Properties.Attributes["deviceType"].ToString());
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Attributes["deviceCategory"].ToString(), deviceData.Properties.Attributes["deviceCategory"].ToString());
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Version, 2);
            Assert.AreEqual(deviceUpdateResponse.Value.Data.Properties.Enabled, true);

            // Delete DeviceRegistry Device
            await device.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
