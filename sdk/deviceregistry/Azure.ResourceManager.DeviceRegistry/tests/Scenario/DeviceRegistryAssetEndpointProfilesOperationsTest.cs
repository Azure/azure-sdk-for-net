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
            var assetEndpointProfileResourceListByResourceGroupAsyncIterator = assetEndpointProfilesCollection.GetAllAsync(CancellationToken.None);
            await foreach (var assetEndpointProfileEntry in assetEndpointProfileResourceListByResourceGroupAsyncIterator)
            {
                assetEndpointProfileResourcesListByResourceGroup.Add(assetEndpointProfileEntry);
            }
            Assert.IsNotEmpty(assetEndpointProfileResourcesListByResourceGroup);
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup.Count, 1);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.TargetAddress, assetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.EndpointProfileType, assetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.Authentication.Method, assetEndpointProfileData.Properties.Authentication.Method);
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName);
            Assert.AreEqual(assetEndpointProfileResourcesListByResourceGroup[0].Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName);

            // List DeviceRegistry AssetEndpointProfile by Subscription
            var assetEndpointProfileResourcesListBySubscription = new List<DeviceRegistryAssetEndpointProfileResource>();
            var assetEndpointProfileResourceListBySubscriptionAsyncIterator = subscription.GetDeviceRegistryAssetEndpointProfilesAsync(CancellationToken.None);
            await foreach (var assetEndpointProfileEntry in assetEndpointProfileResourceListBySubscriptionAsyncIterator)
            {
                assetEndpointProfileResourcesListBySubscription.Add(assetEndpointProfileEntry);
            }
            Assert.IsNotEmpty(assetEndpointProfileResourcesListBySubscription);
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription.Count, 1);
            Assert.IsTrue(Guid.TryParse(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.Uuid, out _));
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.TargetAddress, assetEndpointProfileData.Properties.TargetAddress);
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.EndpointProfileType, assetEndpointProfileData.Properties.EndpointProfileType);
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.Authentication.Method, assetEndpointProfileData.Properties.Authentication.Method);
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName);
            Assert.AreEqual(assetEndpointProfileResourcesListBySubscription[0].Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName);

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
