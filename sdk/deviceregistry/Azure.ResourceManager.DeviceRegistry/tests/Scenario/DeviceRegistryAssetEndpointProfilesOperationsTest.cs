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
    public class DeviceRegistryAssetEndpointProfilesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg-assetendpointprofiles";
        private readonly string _assetEndpointProfileNamePrefix = "deviceregistry-test-assetendpointprofile-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";

        public DeviceRegistryAssetEndpointProfilesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AssetEndpointProfilesCrudOperationsTest()
        {
            var assetEndpointProfileName = Recording.GenerateAssetName(_assetEndpointProfileNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };

            var assetEndpointProfilesCollection = rg.GetDeviceRegistryAssetEndpointProfiles();

            // Create DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileData = new DeviceRegistryAssetEndpointProfileData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new()
                {
                    TargetAddress = new Uri("opc.tcp://aep-uri"),
                    EndpointProfileType = "Microsoft.OpcUa",
                    Authentication = new()
                    {
                        Method = AuthenticationMethod.UsernamePassword,
                        UsernamePasswordCredentials = new()
                        {
                            UsernameSecretName = "usernameSecretNameRef",
                            PasswordSecretName = "passwordSecretNameRef"
                        }
                    }
                }
            };
            var assetEndpointProfileCreateOrUpdateResponse = await assetEndpointProfilesCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetEndpointProfileName, assetEndpointProfileData, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.TargetAddress, assetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.EndpointProfileType, assetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.Method, assetEndpointProfileData.Properties.Authentication.Method);
            Assert.AreEqual(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName);
            Assert.AreEqual(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName);

            // Read DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileReadResponse = await assetEndpointProfilesCollection.GetAsync(assetEndpointProfileName, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.Properties.TargetAddress, assetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.Properties.EndpointProfileType, assetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.Method, assetEndpointProfileData.Properties.Authentication.Method);
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName);
            Assert.AreEqual(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName);

            // List DeviceRegistry AssetEndpointProfile by Resource Group
            var assetEndpointProfileResourcesListByResourceGroup = new List<DeviceRegistryAssetEndpointProfileResource>();
            var assetEndpointProfileResourceListByResourceGroupAsyncIteratorPage = assetEndpointProfilesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var assetEndpointProfileEntryPage in assetEndpointProfileResourceListByResourceGroupAsyncIteratorPage)
            {
                assetEndpointProfileResourcesListByResourceGroup.AddRange(assetEndpointProfileEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(assetEndpointProfileResourcesListByResourceGroup);
            Assert.GreaterOrEqual(assetEndpointProfileResourcesListByResourceGroup.Count, 1);

            // List DeviceRegistry AssetEndpointProfile by Subscription
            var assetEndpointProfileResourcesListBySubscription = new List<DeviceRegistryAssetEndpointProfileResource>();
            var assetEndpointProfileResourceListBySubscriptionAsyncIteratorPage = subscription.GetDeviceRegistryAssetEndpointProfilesAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var assetEndpointProfileEntryPage in assetEndpointProfileResourceListBySubscriptionAsyncIteratorPage)
            {
                assetEndpointProfileResourcesListBySubscription.AddRange(assetEndpointProfileEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(assetEndpointProfileResourcesListBySubscription);
            Assert.GreaterOrEqual(assetEndpointProfileResourcesListBySubscription.Count, 1);

            // Update DeviceRegistry AssetEndpointProfile
            var assetEndpointProfile = assetEndpointProfileReadResponse.Value;
            var assetEndpointProfilePatchData = new DeviceRegistryAssetEndpointProfilePatch
            {
                Properties = new()
                {
                    AdditionalConfiguration = "{\"refreshIntervalMs\":1000}"
                }
            };
            var assetEndpointProfileUpdateResponse = await assetEndpointProfile.UpdateAsync(WaitUntil.Completed, assetEndpointProfilePatchData, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.TargetAddress, assetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.EndpointProfileType, assetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.Method, assetEndpointProfileData.Properties.Authentication.Method);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName);
            Assert.AreEqual(assetEndpointProfileUpdateResponse.Value.Data.Properties.AdditionalConfiguration, assetEndpointProfilePatchData.Properties.AdditionalConfiguration);

            // Delete DeviceRegistry AssetEndpointProfile
            await assetEndpointProfile.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
