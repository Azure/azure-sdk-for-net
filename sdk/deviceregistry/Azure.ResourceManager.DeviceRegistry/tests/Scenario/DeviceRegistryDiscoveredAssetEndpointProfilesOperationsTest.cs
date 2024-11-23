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
    public class DeviceRegistryDiscoveredAssetEndpointProfilesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
        private readonly string _discoveredAssetEndpointProfileNamePrefix = "deviceregistry-test-discoveredassetendpointprofile-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryDiscoveredAssetEndpointProfilesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DiscoveredAssetEndpointProfilesCrudOperationsTest()
        {
            var discoveredAssetEndpointProfileName = Recording.GenerateAssetName(_discoveredAssetEndpointProfileNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var discoveredAssetEndpointProfilesCollection = rg.GetDiscoveredAssetEndpointProfiles();

            // Create DeviceRegistry DiscoveredAssetEndpointProfile
            var discoveredAssetEndpointProfileData = new DiscoveredAssetEndpointProfileData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new()
                {
                    TargetAddress = new Uri("opc.tcp://aep-uri"),
                    EndpointProfileType = "Microsoft.OpcUa"
                }
            };
            discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods.Add("Anonymous");
            discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods.Add("UsernamePassword");

            var discoveredAssetEndpointProfileCreateOrUpdateResponse = await discoveredAssetEndpointProfilesCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveredAssetEndpointProfileName, discoveredAssetEndpointProfileData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetEndpointProfileCreateOrUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.TargetAddress, discoveredAssetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(discoveredAssetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.EndpointProfileType, discoveredAssetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(discoveredAssetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.SupportedAuthenticationMethods[0], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[0]);
            Assert.AreEqual(discoveredAssetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.SupportedAuthenticationMethods[1], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[1]);

            // Read DeviceRegistry DiscoveredAssetEndpointProfile
            var discoveredAssetEndpointProfileReadResponse = await discoveredAssetEndpointProfilesCollection.GetAsync(discoveredAssetEndpointProfileName, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetEndpointProfileReadResponse.Value);
            Assert.AreEqual(discoveredAssetEndpointProfileReadResponse.Value.Data.Properties.TargetAddress, discoveredAssetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(discoveredAssetEndpointProfileReadResponse.Value.Data.Properties.EndpointProfileType, discoveredAssetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(discoveredAssetEndpointProfileReadResponse.Value.Data.Properties.SupportedAuthenticationMethods[0], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[0]);
            Assert.AreEqual(discoveredAssetEndpointProfileReadResponse.Value.Data.Properties.SupportedAuthenticationMethods[1], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[1]);

            // List DeviceRegistry DiscoveredAssetEndpointProfile by Resource Group
            var discoveredAssetEndpointProfileResourcesListByResourceGroup = new List<DiscoveredAssetEndpointProfileResource>();
            var discoveredAssetEndpointProfileResourceListByResourceGroupAsyncIterator = discoveredAssetEndpointProfilesCollection.GetAllAsync(CancellationToken.None);
            await foreach (var discoveredAssetEndpointProfileEntry in discoveredAssetEndpointProfileResourceListByResourceGroupAsyncIterator)
            {
                discoveredAssetEndpointProfileResourcesListByResourceGroup.Add(discoveredAssetEndpointProfileEntry);
            }
            Assert.IsNotEmpty(discoveredAssetEndpointProfileResourcesListByResourceGroup);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListByResourceGroup.Count, 1);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.TargetAddress, discoveredAssetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.EndpointProfileType, discoveredAssetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.SupportedAuthenticationMethods[0], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[0]);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.SupportedAuthenticationMethods[1], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[1]);

            // List DeviceRegistry DiscoveredAssetEndpointProfile by Subscription
            var discoveredAssetEndpointProfileResourcesListBySubscription = new List<DiscoveredAssetEndpointProfileResource>();
            var discoveredAssetEndpointProfileResourceListBySubscriptionAsyncIterator = subscription.GetDiscoveredAssetEndpointProfilesAsync(CancellationToken.None);
            await foreach (var discoveredAssetEndpointProfileEntry in discoveredAssetEndpointProfileResourceListBySubscriptionAsyncIterator)
            {
                discoveredAssetEndpointProfileResourcesListBySubscription.Add(discoveredAssetEndpointProfileEntry);
            }
            Assert.IsNotEmpty(discoveredAssetEndpointProfileResourcesListBySubscription);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListBySubscription.Count, 1);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListBySubscription[0].Data.Properties.TargetAddress, discoveredAssetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListBySubscription[0].Data.Properties.EndpointProfileType, discoveredAssetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListBySubscription[0].Data.Properties.SupportedAuthenticationMethods[0], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[0]);
            Assert.AreEqual(discoveredAssetEndpointProfileResourcesListBySubscription[0].Data.Properties.SupportedAuthenticationMethods[1], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[1]);

            // Update DeviceRegistry DiscoveredAssetEndpointProfile
            var discoveredAssetEndpointProfile = discoveredAssetEndpointProfileReadResponse.Value;
            var discoveredAssetEndpointProfilePatchData = new DiscoveredAssetEndpointProfilePatch
            {
                Properties = new()
                {
                    AdditionalConfiguration = "{\"refreshIntervalMs\":1000}"
                }
            };
            var discoveredAssetEndpointProfileUpdateResponse = await discoveredAssetEndpointProfile.UpdateAsync(WaitUntil.Completed, discoveredAssetEndpointProfilePatchData, CancellationToken.None);
            Assert.IsNotNull(discoveredAssetEndpointProfileUpdateResponse.Value);
            Assert.AreEqual(discoveredAssetEndpointProfileUpdateResponse.Value.Data.Properties.TargetAddress, discoveredAssetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(discoveredAssetEndpointProfileUpdateResponse.Value.Data.Properties.EndpointProfileType, discoveredAssetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(discoveredAssetEndpointProfileUpdateResponse.Value.Data.Properties.SupportedAuthenticationMethods[0], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[0]);
            Assert.AreEqual(discoveredAssetEndpointProfileUpdateResponse.Value.Data.Properties.SupportedAuthenticationMethods[1], discoveredAssetEndpointProfileData.Properties.SupportedAuthenticationMethods[1]);
            Assert.AreEqual(discoveredAssetEndpointProfileUpdateResponse.Value.Data.Properties.AdditionalConfiguration, discoveredAssetEndpointProfileData.Properties.AdditionalConfiguration);

            // Delete DeviceRegistry DiscoveredAssetEndpointProfile
            await discoveredAssetEndpointProfile.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
