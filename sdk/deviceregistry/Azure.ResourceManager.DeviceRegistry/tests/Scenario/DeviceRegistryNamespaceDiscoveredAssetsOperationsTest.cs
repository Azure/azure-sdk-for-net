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
        private readonly string _rgNamePrefix = "adr-test-sdk-rg-ns-discoveredassets";
        private readonly string _namespaceName = "adr-namespace";
        private readonly string _discoveredAssetNamePrefix = "deviceregistry-test-discoveredAsset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryNamespaceDiscoveredAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespaceDiscoveredAssetsCrudOperationsTest()
        {
            var discoveredAssetName = Recording.GenerateAssetName(_discoveredAssetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var namespacesCollection = rg.GetDeviceRegistryNamespaces();
            var namespaceResource = await namespacesCollection.GetAsync(_namespaceName);
            var discoveredAssetsCollection = namespaceResource.Value.GetDeviceRegistryNamespaceDiscoveredAssets();

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
                    Description = "This is an discoveredAsset."
                }
            };
            var discoveredAssetCreateOrUpdateResponse = await discoveredAssetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveredAssetName, discoveredAssetData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetCreateOrUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.DeviceName, discoveredAssetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DeviceRef.EndpointName, discoveredAssetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DisplayName, discoveredAssetCreateOrUpdateResponse.Value.Data.Name);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.Description, discoveredAssetData.Properties.Description);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.Version, 1);

            // Read DeviceRegistry DiscoveredAsset
            var discoveredAssetReadResponse = await discoveredAssetsCollection.GetAsync(discoveredAssetName, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetReadResponse.Value);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DeviceRef.DeviceName, discoveredAssetData.Properties.DeviceRef.DeviceName);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DeviceRef.EndpointName, discoveredAssetData.Properties.DeviceRef.EndpointName);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DisplayName, discoveredAssetReadResponse.Value.Data.Name);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.Description, discoveredAssetData.Properties.Description);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.Version, 1);

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
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DisplayName, discoveredAssetUpdateResponse.Value.Data.Name);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.Description, discoveredAssetPatchData.Properties.Description);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.DiscoveryId, discoveredAssetData.Properties.DiscoveryId);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.Version, 2);

            // Delete DeviceRegistry Asset
            await discoveredAsset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
