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
        private readonly string _namespaceRgName = "adr-sdk-test-rg";
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
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var namespaceRg = await subscription.GetResourceGroupAsync(_namespaceRgName);
            var namespacesCollection = namespaceRg.Value.GetDeviceRegistryNamespaces();
            var namespaceResource = await namespacesCollection.GetAsync(_namespaceName);
            var devicesCollection = namespaceResource.Value.GetDeviceRegistryNamespaceDevices();

            // Create DeviceRegistry Device
            var deviceData = new DeviceRegistryNamespaceDeviceData(AzureLocation.WestUS2)
            {
                Properties = new()
                {
                    Manufacturer = "Contoso",
                    Model = "Model 5000",
                    OperatingSystem = "Linux",
                    OperatingSystemVersion = "18.04",
                    Endpoints = new MessagingEndpoints(),
                }
            };
            deviceData.Properties.Endpoints.Inbound.Add("myendpoint1", new InboundEndpoints()
            {
                Address = "https://myendpoint1.westeurope-1.iothub.azure.net",
                EndpointType = "Microsoft.Devices/IoTHubs"
            });
            var deviceCreateOrUpdateResponse = await devicesCollection.CreateOrUpdateAsync(WaitUntil.Completed, deviceName, deviceData, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(deviceCreateOrUpdateResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(deviceCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
            });
            Assert.That(deviceCreateOrUpdateResponse.Value.Data.Properties.Uuid, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.ExternalDeviceId));
            Assert.That(deviceData.Properties.Manufacturer, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.Manufacturer));
            Assert.That(deviceData.Properties.Model, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.Model));
            Assert.That(deviceData.Properties.OperatingSystem, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystem));
            Assert.That(deviceData.Properties.OperatingSystemVersion, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.OperatingSystemVersion));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].Address, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, Is.EqualTo(deviceCreateOrUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType));
            Assert.That(deviceCreateOrUpdateResponse.Value.Data.Properties.Version, Is.EqualTo(1));

            // Read DeviceRegistry Device
            var deviceReadResponse = await devicesCollection.GetAsync(deviceName, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(deviceReadResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(deviceReadResponse.Value.Data.Properties.Uuid, out _), Is.True);
            });
            Assert.That(deviceReadResponse.Value.Data.Properties.Uuid, Is.EqualTo(deviceReadResponse.Value.Data.Properties.ExternalDeviceId));
            Assert.That(deviceData.Properties.Manufacturer, Is.EqualTo(deviceReadResponse.Value.Data.Properties.Manufacturer));
            Assert.That(deviceData.Properties.Model, Is.EqualTo(deviceReadResponse.Value.Data.Properties.Model));
            Assert.That(deviceData.Properties.OperatingSystem, Is.EqualTo(deviceReadResponse.Value.Data.Properties.OperatingSystem));
            Assert.That(deviceData.Properties.OperatingSystemVersion, Is.EqualTo(deviceReadResponse.Value.Data.Properties.OperatingSystemVersion));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].Address, Is.EqualTo(deviceReadResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, Is.EqualTo(deviceReadResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType));
            Assert.That(deviceReadResponse.Value.Data.Properties.Version, Is.EqualTo(1));

            // List DeviceRegistry Device by Resource Group
            var deviceResourcesListByResourceGroup = new List<DeviceRegistryNamespaceDeviceResource>();
            var deviceResourceListByResourceGroupAsyncIteratorPage = devicesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var deviceEntryPage in deviceResourceListByResourceGroupAsyncIteratorPage)
            {
                deviceResourcesListByResourceGroup.AddRange(deviceEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.That(deviceResourcesListByResourceGroup, Is.Not.Empty);
            Assert.That(deviceResourcesListByResourceGroup.Count, Is.GreaterThanOrEqualTo(1));

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
            Assert.Multiple(() =>
            {
                Assert.That(deviceUpdateResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(deviceUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
            });
            Assert.That(deviceUpdateResponse.Value.Data.Properties.Uuid, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.ExternalDeviceId));
            Assert.That(deviceData.Properties.Manufacturer, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.Manufacturer));
            Assert.That(deviceData.Properties.Model, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.Model));
            Assert.That(deviceData.Properties.OperatingSystem, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.OperatingSystem));
            Assert.That(devicePatchData.Properties.OperatingSystemVersion, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.OperatingSystemVersion));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].Address, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].Address));
            Assert.That(deviceData.Properties.Endpoints.Inbound["myendpoint1"].EndpointType, Is.EqualTo(deviceUpdateResponse.Value.Data.Properties.Endpoints.Inbound["myendpoint1"].EndpointType));
            Assert.That(deviceUpdateResponse.Value.Data.Properties.Version, Is.EqualTo(2));

            // Delete DeviceRegistry Device
            try
            {
                await device.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            }
            catch (RequestFailedException ex)
            {
                // Delete temporary returns 200 since async operation is defined for the resource but not implemented in RP
                if (ex.Status != 200)
                {
                    throw;
                }
            }
        }
    }
}
