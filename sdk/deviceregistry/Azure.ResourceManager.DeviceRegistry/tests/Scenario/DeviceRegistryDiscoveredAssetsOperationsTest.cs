// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager.DeviceRegistry.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryDiscoveredAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
        private readonly string _assetNamePrefix = "deviceregistry-test-discoveredasset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryDiscoveredAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DiscoveredAssetsCrudOperationsTest()
        {
            var discoveredAssetName = Recording.GenerateAssetName(_assetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var discoveredAssetsCollection = rg.GetDiscoveredAssets();

            // Create DeviceRegistry DiscoveredAsset
            var discoveredAssetData = new DiscoveredAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new()
                {
                    AssetEndpointProfileRef = "assetEndpointProfileReference",
                    Manufacturer = "Contoso"
                }
            };
            var discoveredAssetCreateOrUpdateResponse = await discoveredAssetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveredAssetName, discoveredAssetData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetCreateOrUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.AssetEndpointProfileRef, discoveredAssetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(discoveredAssetCreateOrUpdateResponse.Value.Data.Properties.Manufacturer, discoveredAssetData.Properties.Manufacturer);

            // Read DeviceRegistry DiscoveredAsset
            var discoveredAssetReadResponse = await discoveredAssetsCollection.GetAsync(discoveredAssetName, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetReadResponse.Value);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.AssetEndpointProfileRef, discoveredAssetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(discoveredAssetReadResponse.Value.Data.Properties.Manufacturer, discoveredAssetData.Properties.Manufacturer);

            // List DeviceRegistry DiscoveredAsset by Resource Group
            var discoveredAssetResourcesListByResourceGroup = new List<DiscoveredAssetResource>();
            var discoveredAssetResourceListByResourceGroupAsyncIterator = discoveredAssetsCollection.GetAllAsync(CancellationToken.None);
            await foreach (var discoveredAssetEntry in discoveredAssetResourceListByResourceGroupAsyncIterator)
            {
                discoveredAssetResourcesListByResourceGroup.Add(discoveredAssetEntry);
            }
            Assert.IsNotEmpty(discoveredAssetResourcesListByResourceGroup);
            Assert.AreEqual(discoveredAssetResourcesListByResourceGroup.Count, 1);
            Assert.AreEqual(discoveredAssetResourcesListByResourceGroup[0].Data.Properties.AssetEndpointProfileRef, discoveredAssetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(discoveredAssetResourcesListByResourceGroup[0].Data.Properties.Manufacturer, discoveredAssetData.Properties.Manufacturer);

            // List DeviceRegistry Asset by Subscription
            var discoveredAssetResourcesListBySubscription = new List<DiscoveredAssetResource>();
            var discoveredAssetResourceListBySubscriptionAsyncIterator = subscription.GetDiscoveredAssetsAsync(CancellationToken.None);
            await foreach (var discoveredAssetEntry in discoveredAssetResourceListBySubscriptionAsyncIterator)
            {
                discoveredAssetResourcesListBySubscription.Add(discoveredAssetEntry);
            }
            Assert.IsNotEmpty(discoveredAssetResourcesListBySubscription);
            Assert.AreEqual(discoveredAssetResourcesListBySubscription.Count, 1);
            Assert.AreEqual(discoveredAssetResourcesListBySubscription[0].Data.Properties.AssetEndpointProfileRef, discoveredAssetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(discoveredAssetResourcesListBySubscription[0].Data.Properties.Manufacturer, discoveredAssetData.Properties.Manufacturer);

            // Update DeviceRegistry DiscoveredAsset
            var discoveredAsset = discoveredAssetReadResponse.Value;
            var discoveredAssetPatchData = new DiscoveredAssetPatch
            {
                Properties = new()
                {
                    Manufacturer = "Fabrikam"
                }
            };
            var discoveredAssetUpdateResponse = await discoveredAsset.UpdateAsync(WaitUntil.Completed, discoveredAssetPatchData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.AssetEndpointProfileRef, discoveredAssetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(discoveredAssetUpdateResponse.Value.Data.Properties.Manufacturer, discoveredAssetPatchData.Properties.Manufacturer);

            // Delete DeviceRegistry DiscoveredAsset
            await discoveredAsset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
