// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager.DeviceRegistry.Models;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryAssetsOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
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
            var extendedLocation = new ExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var assetsCollection = rg.GetAssets();

            // Create DeviceRegistry Asset
            var assetData = new AssetData(AzureLocation.WestUS, extendedLocation)
            {
                Description = "This is an asset.",
                AssetEndpointProfileUri = new Uri("http://assetendpointprofileref"),
            };
            var assetCreateOrUpdateResponse = await assetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, assetData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetCreateOrUpdateResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.ExternalAssetId, assetCreateOrUpdateResponse.Value.Data.Uuid);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.AssetEndpointProfileUri, assetData.AssetEndpointProfileUri);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.DisplayName, assetCreateOrUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Description, assetData.Description);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Version, 1);
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.Enabled, true);

            // Read DeviceRegistry Asset
            var assetReadResponse = await assetsCollection.GetAsync(assetName, CancellationToken.None);
            Assert.IsNotNull(assetReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetReadResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetReadResponse.Value.Data.ExternalAssetId, assetReadResponse.Value.Data.Uuid);
            Assert.AreEqual(assetReadResponse.Value.Data.AssetEndpointProfileUri, assetData.AssetEndpointProfileUri);
            Assert.AreEqual(assetReadResponse.Value.Data.DisplayName, assetReadResponse.Value.Data.Name);
            Assert.AreEqual(assetReadResponse.Value.Data.Version, 1);
            Assert.AreEqual(assetReadResponse.Value.Data.Enabled, true);

            // Update DeviceRegistry Asset
            var asset = assetReadResponse.Value;
            var assetPatchData = new AssetPatch
            {
                Description = "This is a patched Asset."
            };
            var assetUpdateResponse = await asset.UpdateAsync(WaitUntil.Completed, assetPatchData, CancellationToken.None);
            Assert.IsNotNull(assetUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetUpdateResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetUpdateResponse.Value.Data.ExternalAssetId, assetUpdateResponse.Value.Data.Uuid);
            Assert.AreEqual(assetUpdateResponse.Value.Data.AssetEndpointProfileUri, assetData.AssetEndpointProfileUri);
            Assert.AreEqual(assetUpdateResponse.Value.Data.DisplayName, assetUpdateResponse.Value.Data.Name);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Description, assetPatchData.Description);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Version, 2);
            Assert.AreEqual(assetUpdateResponse.Value.Data.Enabled, true);

            // Delete DeviceRegistry Asset
            await asset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
