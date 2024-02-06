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
    public class DeviceRegistryAssetEndpointProfilesOperationsTest : DeviceRegistryManagementTestBase
    {
        protected DeviceRegistryAssetEndpointProfilesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task AssetEndpointProfilesCrudOperationsTest()
        {
            var assetEndpointProfileName = Recording.GenerateAssetName("deviceregistry-test-assetendpointprofile-sdk");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroup(subscription, "deviceregistry-test-sdk-rg", AzureLocation.WestUS);
            var extendedLocation = new AssetEndpointProfileExtendedLocation() { AssetEndpointProfileExtendedLocationType = "CustomLocation", Name = "" };

            var assetEndpointProfilesCollection = rg.GetAssetEndpointProfiles();

            // Create DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileData = new AssetEndpointProfileData(AzureLocation.WestUS, extendedLocation)
            {
                Properties =
                {
                    TargetAddress = new Uri("opc.tcp://aep-uri"),
                    UserAuthentication =
                    {
                        Mode = Models.Mode.Anonymous
                    }
                }
            };
            var assetCreateOrUpdateResponse = await assetEndpointProfilesCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetEndpointProfileName, assetEndpointProfileData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);

            // Read DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileReadResponse = await assetEndpointProfilesCollection.GetAsync(assetEndpointProfileName, CancellationToken.None);
            var assetEndpointProfile = assetEndpointProfileReadResponse.Value;
            Assert.IsNotNull(assetEndpointProfile);

            // Update DeviceRegistry AssetEndpointProfile
            var assetPatchData = new AssetEndpointProfilePatch()
            {
                Properties =
                {
                    AdditionalConfiguration = "{\"foo\":\"bar\"}"
                }
            };
            var assetEndpointProfileUpdateResponse = await assetEndpointProfile.UpdateAsync(WaitUntil.Completed, assetPatchData, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileUpdateResponse.Value);

            // Delete DeviceRegistry AssetEndpointProfile
            await assetEndpointProfile.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
