// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryDiscoveredAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
        private readonly string _discoveredAssetNamePrefix = "deviceregistry-test-discoveredasset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryDiscoveredAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DiscoveredAssetsCrudOperationsTest()
        {
            var discoveredAssetName = Recording.GenerateAssetName(_discoveredAssetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var discoveredAssetsCollection = rg.GetDeviceRegistryDiscoveredAssets();

            // Create DeviceRegistry DiscoveredAsset
            var discoveredAssetData = new DeviceRegistryDiscoveredAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new("assetEndpointProfileReference", "discoveryIdSample", 1)
            };
            discoveredAssetData.Properties.Manufacturer = "Contoso";
            discoveredAssetData.Properties.ManufacturerUri = "http://contoso.com";
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
            int resourcesToFetchByResourceGroup = 10;
            int fetchedResourcesByResourceGroup = 0;
            var discoveredAssetResourcesListByResourceGroup = new List<DeviceRegistryDiscoveredAssetResource>();
            var discoveredAssetResourceListByResourceGroupAsyncIterator = discoveredAssetsCollection.GetAllAsync(CancellationToken.None);
            await foreach (var discoveredAssetEntry in discoveredAssetResourceListByResourceGroupAsyncIterator)
            {
                fetchedResourcesByResourceGroup++;
                discoveredAssetResourcesListByResourceGroup.Add(discoveredAssetEntry);
                // limit the test to at most the first 10 entries
                if (fetchedResourcesByResourceGroup == resourcesToFetchByResourceGroup)
                {
                    break;
                }
            }
            Assert.IsNotEmpty(discoveredAssetResourcesListByResourceGroup);
            Assert.AreEqual(discoveredAssetResourcesListByResourceGroup.Count, 1);

            // List DeviceRegistry Asset by Subscription
            int resourcesToFetchBySubscription = 10;
            int fetchedResourcesBySubscription = 0;
            var discoveredAssetResourcesListBySubscription = new List<DeviceRegistryDiscoveredAssetResource>();
            var discoveredAssetResourceListBySubscriptionAsyncIterator = subscription.GetDeviceRegistryDiscoveredAssetsAsync(CancellationToken.None);
            await foreach (var discoveredAssetEntry in discoveredAssetResourceListBySubscriptionAsyncIterator)
            {
                fetchedResourcesBySubscription++;
                discoveredAssetResourcesListBySubscription.Add(discoveredAssetEntry);
                // limit the test to at most the first 10 entries
                if (fetchedResourcesBySubscription == resourcesToFetchBySubscription)
                {
                    break;
                }
            }
            Assert.IsNotEmpty(discoveredAssetResourcesListBySubscription);
            Assert.GreaterOrEqual(discoveredAssetResourcesListBySubscription.Count, 1);

            // Update DeviceRegistry DiscoveredAsset
            var discoveredAsset = discoveredAssetReadResponse.Value;
            var discoveredAssetPatchData = new DeviceRegistryDiscoveredAssetPatch
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
            try
            {
                await discoveredAsset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status != 200)
                {
                    throw;
                }
            }
        }
    }
}
