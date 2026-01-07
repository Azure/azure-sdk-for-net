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
            Assert.That(assetEndpointProfileCreateOrUpdateResponse.Value, Is.Not.Null);
            Assert.That(Guid.TryParse(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
            Assert.That(assetEndpointProfileData.Properties.TargetAddress, Is.EqualTo(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.TargetAddress));
            Assert.That(assetEndpointProfileData.Properties.EndpointProfileType, Is.EqualTo(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.EndpointProfileType));
            Assert.That(assetEndpointProfileData.Properties.Authentication.Method, Is.EqualTo(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.Method));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, Is.EqualTo(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, Is.EqualTo(assetEndpointProfileCreateOrUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName));

            // Read DeviceRegistry AssetEndpointProfile
            var assetEndpointProfileReadResponse = await assetEndpointProfilesCollection.GetAsync(assetEndpointProfileName, CancellationToken.None);
            Assert.That(assetEndpointProfileReadResponse.Value, Is.Not.Null);
            Assert.That(Guid.TryParse(assetEndpointProfileReadResponse.Value.Data.Properties.Uuid, out _), Is.True);
            Assert.That(assetEndpointProfileData.Properties.TargetAddress, Is.EqualTo(assetEndpointProfileReadResponse.Value.Data.Properties.TargetAddress));
            Assert.That(assetEndpointProfileData.Properties.EndpointProfileType, Is.EqualTo(assetEndpointProfileReadResponse.Value.Data.Properties.EndpointProfileType));
            Assert.That(assetEndpointProfileData.Properties.Authentication.Method, Is.EqualTo(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.Method));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, Is.EqualTo(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, Is.EqualTo(assetEndpointProfileReadResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName));

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
            Assert.That(assetEndpointProfileUpdateResponse.Value, Is.Not.Null);
            Assert.That(Guid.TryParse(assetEndpointProfileUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
            Assert.That(assetEndpointProfileData.Properties.TargetAddress, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.TargetAddress));
            Assert.That(assetEndpointProfileData.Properties.EndpointProfileType, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.EndpointProfileType));
            Assert.That(assetEndpointProfileData.Properties.Authentication.Method, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.Method));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.UsernameSecretName));
            Assert.That(assetEndpointProfileData.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.Authentication.UsernamePasswordCredentials.PasswordSecretName));
            Assert.That(assetEndpointProfilePatchData.Properties.AdditionalConfiguration, Is.EqualTo(assetEndpointProfileUpdateResponse.Value.Data.Properties.AdditionalConfiguration));

            // Delete DeviceRegistry AssetEndpointProfile
            await assetEndpointProfile.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
