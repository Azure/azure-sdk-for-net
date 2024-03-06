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
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
        private readonly string _assetNamePrefix = "deviceregistry-test-assetendpointprofile-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryAssetEndpointProfilesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AssetEndpointProfilesCrudOperationsTest()
        {
            var assetEndpointProfileName = Recording.GenerateAssetName(_assetNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new ExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var assetEndpointProfilesCollection = rg.GetAssetEndpointProfiles();

            // Create DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileData = new AssetEndpointProfileData(AzureLocation.WestUS, extendedLocation)
            {
                TargetAddress = new Uri("opc.tcp://aep-uri"),
                UserAuthentication = new UserAuthentication
                {
                    Mode = UserAuthenticationMode.Anonymous
                }
            };
            var assetCreateOrUpdateResponse = await assetEndpointProfilesCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetEndpointProfileName, assetEndpointProfileData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetCreateOrUpdateResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetCreateOrUpdateResponse.Value.Data.TargetAddress, assetEndpointProfileData.TargetAddress);

            // Read DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileReadResponse = await assetEndpointProfilesCollection.GetAsync(assetEndpointProfileName, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileReadResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.TargetAddress, assetEndpointProfileData.TargetAddress);

            // Update DeviceRegistry AssetEndpointProfile
            var assetEndpointProfile = assetEndpointProfileReadResponse.Value;
            var assetPatchData = new AssetEndpointProfilePatch
            {
                AdditionalConfiguration = "{\"foo\":\"bar\"}"
            };
            var assetEndpointProfileUpdateResponse = await assetEndpointProfile.UpdateAsync(WaitUntil.Completed, assetPatchData, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileUpdateResponse.Value.Data.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.TargetAddress, assetEndpointProfileData.TargetAddress);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.AdditionalConfiguration, assetPatchData.AdditionalConfiguration);

            // Delete DeviceRegistry AssetEndpointProfile
            await assetEndpointProfile.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
