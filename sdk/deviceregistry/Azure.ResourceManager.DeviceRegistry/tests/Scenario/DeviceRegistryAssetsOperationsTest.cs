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
        protected DeviceRegistryAssetsOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task AssetsCrudOperationsTest()
        {
            var assetName = Recording.GenerateAssetName("deviceregistry-test-asset-sdk");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroup(subscription, "deviceregistry-test-sdk-rg", AzureLocation.WestUS);
            var extendedLocation = new AssetExtendedLocation() { AssetExtendedLocationType = "CustomLocation", Name = "" };

            var assetsCollection = rg.GetAssets();

            // Create DeviceRegistry Asset
            var assetData = new AssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties =
                {
                    Description = "This is an asset",
                    AssetEndpointProfileUri = new Uri("assetendpointprofileref"),
                }
            };
            var assetCreateOrUpdateResponse = await assetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, assetData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);

            // Read DeviceRegistry Asset
            var assetReadResponse = await assetsCollection.GetAsync(assetName, CancellationToken.None);
            var asset = assetReadResponse.Value;
            Assert.IsNotNull(asset);

            // Update DeviceRegistry Asset
            var assetPatchData = new AssetPatch()
            {
                Properties =
                {
                    Description = "This is a patched Asset"
                }
            };
            var assetUpdateResponse = await asset.UpdateAsync(WaitUntil.Completed, assetPatchData, CancellationToken.None);
            Assert.IsNotNull(assetUpdateResponse.Value);

            // Delete DeviceRegistry Asset
            await asset.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
