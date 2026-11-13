// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryNamespaceDiscoveredAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _resourceGroupNamePrefix = "adr-test-sdk-rg-ns-discoveredassets";
        private readonly string _namespaceNamePrefix = "adr-namespace-test";
        private readonly string _discoveredAssetNamePrefix = "deviceregistry-test-discoveredasset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryNamespaceDiscoveredAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespaceDiscoveredAssetsCrudOperationsTest()
        {
            var resourceGroupName = Recording.GenerateAssetName(_resourceGroupNamePrefix);
            var namespaceName = Recording.GenerateAssetName(_namespaceNamePrefix);
            var discoveredAssetName = Recording.GenerateAssetName(_discoveredAssetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var rg = await CreateResourceGroup(subscription, resourceGroupName, AzureLocation.WestUS);

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
            var discoveredAssetsCollection = namespaceResource.GetDeviceRegistryNamespaceDiscoveredAssets();

            // Create DeviceRegistry Asset
            var deviceRef = new DeviceRef()
            {
                DeviceName = "device1",
                EndpointName = "endpoint1"
            };
            var discoveredAssetData = new DeviceRegistryNamespaceDiscoveredAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new(deviceRef, "myDiscoveryID", 1)
                {
                    DisplayName = "Discovered Asset 1",
                    Description = "This is an discoveredAsset."
                }
            };
            var discoveredAssetCreateOrUpdateResponse = await discoveredAssetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveredAssetName, discoveredAssetData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetCreateOrUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.DeviceName, discoveredAssetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.EndpointName, discoveredAssetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DisplayName, discoveredAssetData.Properties.DisplayName);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.Description, discoveredAssetData.Properties.Description);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.Version, discoveredAssetData.Properties.Version);

            // Read DeviceRegistry DiscoveredAsset
            var discoveredAssetReadResponse = await discoveredAssetsCollection.GetAsync(discoveredAssetName, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetReadResponse.Value);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DeviceRef.DeviceName, discoveredAssetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DeviceRef.EndpointName, discoveredAssetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DisplayName, discoveredAssetData.Properties.DisplayName);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.Description, discoveredAssetData.Properties.Description);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.Version, discoveredAssetData.Properties.Version);

            // List DeviceRegistry DiscoveredAsset by Resource Group
            var discoveredAssetResourcesListByResourceGroup = new List<DeviceRegistryNamespaceDiscoveredAssetResource>();
            var discoveredAssetResourceListByResourceGroupAsyncIteratorPage = discoveredAssetsCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var discoveredAssetEntryPage in discoveredAssetResourceListByResourceGroupAsyncIteratorPage)
            {
                discoveredAssetResourcesListByResourceGroup.AddRange(discoveredAssetEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(discoveredAssetResourcesListByResourceGroup);
            Assert.GreaterOrEqual(discoveredAssetResourcesListByResourceGroup.Count, 1);

            // Update DeviceRegistry Asset
            var discoveredAsset = discoveredAssetReadResponse.Value;
            var discoveredAssetPatchData = new DeviceRegistryNamespaceDiscoveredAssetPatch
            {
                Properties = new()
                {
                    Description = "This is a patched DiscoveredAsset."
                }
            };
            var discoveredAssetUpdateResponse = await discoveredAsset.UpdateAsync(WaitUntil.Completed, discoveredAssetPatchData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DeviceRef.DeviceName, discoveredAssetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DeviceRef.EndpointName, discoveredAssetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DisplayName, discoveredAssetData.Properties.DisplayName);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.Description, discoveredAssetPatchData.Properties.Description);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.Version, discoveredAssetData.Properties.Version);

            // Delete DeviceRegistry Asset
            await discoveredAsset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
