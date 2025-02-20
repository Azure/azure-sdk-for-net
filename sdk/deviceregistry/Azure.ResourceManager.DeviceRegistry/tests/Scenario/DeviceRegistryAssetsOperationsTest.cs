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
    public class DeviceRegistryAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg-assets";
        private readonly string _assetNamePrefix = "deviceregistry-test-asset-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AssetsCrudOperationsTest()
        {
            var assetName = Recording.GenerateAssetName(_assetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var assetsCollection = rg.GetDeviceRegistryAssets();

            // Create DeviceRegistry Asset
            var assetData = new DeviceRegistryAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new("assetEndpointProfileReference")
                {
                    Description = "This is an asset."
                }
            };
            var assetCreateOrUpdateResponse = await assetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, assetData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.ExternalAssetId, assetCreateOrUpdateResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.AssetEndpointProfileRef, assetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.DisplayName, assetCreateOrUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.Description, assetData.Properties.Description);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.Version, 1);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Properties.IsEnabled, true);

            // Read DeviceRegistry Asset
            var assetReadResponse = await assetsCollection.GetAsync(assetName, CancellationToken.None);
            Assert.IsNotNull(assetReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.ExternalAssetId, assetReadResponse.Value.Data.Properties.Uuid);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.AssetEndpointProfileRef, assetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.DisplayName, assetReadResponse.Value.Data.Name);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.Version, 1);
            Assert.AreEqual(assetReadResponse.Value.Data.Properties.IsEnabled, true);

            // List DeviceRegistry Asset by Resource Group
            var assetResourcesListByResourceGroup = new List<DeviceRegistryAssetResource>();
            var assetResourceListByResourceGroupAsyncIteratorPage = assetsCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var assetEntryPage in assetResourceListByResourceGroupAsyncIteratorPage)
            {
                assetResourcesListByResourceGroup.AddRange(assetEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(assetResourcesListByResourceGroup);
            Assert.GreaterOrEqual(assetResourcesListByResourceGroup.Count, 1);

            // List DeviceRegistry Asset by Subscription
            var assetResourcesListBySubscription = new List<DeviceRegistryAssetResource>();
            var assetResourceListBySubscriptionAsyncIteratorPage = subscription.GetDeviceRegistryAssetsAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var assetEntryPage in assetResourceListBySubscriptionAsyncIteratorPage)
            {
                assetResourcesListBySubscription.AddRange(assetEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(assetResourcesListBySubscription);
            Assert.GreaterOrEqual(assetResourcesListBySubscription.Count, 1);

            // Update DeviceRegistry Asset
            var asset = assetReadResponse.Value;
            var assetPatchData = new DeviceRegistryAssetPatch
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
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.AssetEndpointProfileRef, assetData.Properties.AssetEndpointProfileRef);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.DisplayName, assetUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.Description, assetPatchData.Properties.Description);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.Version, 2);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Properties.IsEnabled, true);

            // Delete DeviceRegistry Asset
            await asset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
