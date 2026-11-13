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
    public class DeviceRegistryNamespaceAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _resourceGroupNamePrefix = "adr-test-sdk-rg-ns-assets";
        private readonly string _namespaceNamePrefix = "adr-namespace-test";
        private readonly string _assetNamePrefix = "deviceregistry-test-asset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryNamespaceAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespaceAssetsCrudOperationsTest()
        {
            var resourceGroupName = Recording.GenerateAssetName(_resourceGroupNamePrefix);
            var namespaceName = Recording.GenerateAssetName(_namespaceNamePrefix);
            var assetName = Recording.GenerateAssetName(_assetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, resourceGroupName, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            // Create the parent namespace resource
            var namespacesCollection = rg.GetDeviceRegistryNamespaces();
            var namespaceData = new DeviceRegistryNamespaceData(AzureLocation.WestUS)
            {
                Properties = new()
                {
                    MessagingEndpoints =
                    {
                        ["myendpoint1"] = new MessagingEndpoint("https://myendpoint1.westeurope-1.iothub.azure.net")
                        {
                            EndpointType = "Microsoft.Devices/IoTHubs",
                            ResourceId = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                        }
                    }
                }
            };
            var namespaceCreateOrUpdateResponse = await namespacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData, CancellationToken.None);
            var namespaceResource = namespaceCreateOrUpdateResponse.Value;
            var assetsCollection = namespaceResource.GetDeviceRegistryNamespaceAssets();

            // Create DeviceRegistry Asset
            var deviceRef = new DeviceRef()
            {
                DeviceName = "device1",
                EndpointName = "endpoint1"
            };
            var assetData = new DeviceRegistryNamespaceAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new(deviceRef)
                {
                    Description = "This is an asset."
                }
            };
            var assetCreateOrUpdateResponse = await assetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, assetData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.ExternalAssetId, assetCreateOrUpdateResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.DeviceName, assetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.EndpointName, assetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.DisplayName, assetCreateOrUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.Description, assetData.Properties.Description);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.Enabled, true);

            // Read DeviceRegistry Asset
            var assetReadResponse = await assetsCollection.GetAsync(assetName, CancellationToken.None);
            Assert.IsNotNull(assetReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.ExternalAssetId, assetReadResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.DeviceRef.DeviceName, assetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.DeviceRef.EndpointName, assetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.DisplayName, assetReadResponse.Value.Data.Name);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.Enabled, true);

            // List DeviceRegistry Asset by Resource Group
            var assetResourcesListByResourceGroup = new List<DeviceRegistryNamespaceAssetResource>();
            var assetResourceListByResourceGroupAsyncIteratorPage = assetsCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var assetEntryPage in assetResourceListByResourceGroupAsyncIteratorPage)
            {
                assetResourcesListByResourceGroup.AddRange(assetEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(assetResourcesListByResourceGroup);
            Assert.GreaterOrEqual(assetResourcesListByResourceGroup.Count, 1);

            // Update DeviceRegistry Asset
            var asset = assetReadResponse.Value;
            var assetPatchData = new DeviceRegistryNamespaceAssetPatch
            {
                Properties = new()
                {
                    Description = "This is a patched Asset."
                }
            };
            var assetUpdateResponse = await asset.UpdateAsync(WaitUntil.Completed, assetPatchData, CancellationToken.None);
            Assert.IsNotNull(assetUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.ExternalAssetId, assetUpdateResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.DeviceRef.DeviceName, assetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.DeviceRef.EndpointName, assetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.DisplayName, assetUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.Description, assetPatchData.Properties.Description);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.Enabled, true);

            // Delete DeviceRegistry Asset
            await asset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
