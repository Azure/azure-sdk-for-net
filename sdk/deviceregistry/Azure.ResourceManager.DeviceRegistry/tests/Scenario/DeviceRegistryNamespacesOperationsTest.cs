// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryNamespacesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-namespaces-rg";
        private readonly string _namespaceNamePrefix = "deviceregistry-test-namespace-sdk";
        private readonly string _extendedLocationName = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.ExtendedLocation/customLocations/adr-sdk-test-cluster-cl";
        private readonly string _assetEndpointProfileNamePrefix = "deviceregistry-test-aep-sdk";
        private readonly string _assetNamePrefix = "deviceregistry-test-asset-sdk";

        public DeviceRegistryNamespacesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespacesCrudOperationsTest()
        {
            var resourceGroupName = Recording.GenerateAssetName(_rgNamePrefix);
            var namespaceName = Recording.GenerateAssetName(_namespaceNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, resourceGroupName, AzureLocation.WestUS);

            var namespacesCollection = rg.GetDeviceRegistryNamespaces();

            // Create DeviceRegistry Namespace
            var namespaceData = new DeviceRegistryNamespaceData(AzureLocation.WestUS)
            {
                Properties = new()
                {
                    MessagingEndpoints =
                    {
                        ["endpoint1"] = new MessagingEndpoint("https://myendpoint1.westeurope-1.iothub.azure.net")
                        {
                            EndpointType = "Microsoft.Devices/IoTHubs",
                            ResourceId = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                        }
                    }
                }
            };
            var namespaceCreateOrUpdateResponse = await namespacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData, CancellationToken.None);
            Assert.IsNotNull(namespaceCreateOrUpdateResponse.Value);
            Assert.AreEqual(namespaceCreateOrUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].EndpointType, namespaceData.Properties.MessagingEndpoints["endpoint1"].EndpointType);
            Assert.AreEqual(namespaceCreateOrUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].Address, namespaceData.Properties.MessagingEndpoints["endpoint1"].Address);
            Assert.AreEqual(namespaceCreateOrUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].ResourceId, namespaceData.Properties.MessagingEndpoints["endpoint1"].ResourceId);

            // Read DeviceRegistry Namespace
            var namespaceReadResponse = await namespacesCollection.GetAsync(namespaceName, CancellationToken.None);
            Assert.IsNotNull(namespaceReadResponse.Value);
            Assert.AreEqual(namespaceReadResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].EndpointType, namespaceData.Properties.MessagingEndpoints["endpoint1"].EndpointType);
            Assert.AreEqual(namespaceReadResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].Address, namespaceData.Properties.MessagingEndpoints["endpoint1"].Address);
            Assert.AreEqual(namespaceReadResponse.Value.Data.Properties.MessagingEndpoints["endpoint1"].ResourceId, namespaceData.Properties.MessagingEndpoints["endpoint1"].ResourceId);

            // List DeviceRegistry Namespace by Resource Group
            var namespaceListByResourceGroup = new List<DeviceRegistryNamespaceResource>();
            var namespaceResourceListByResourceGroupAsyncIteratorPage = namespacesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var namespaceEntryPage in namespaceResourceListByResourceGroupAsyncIteratorPage)
            {
                namespaceListByResourceGroup.AddRange(namespaceEntryPage.Values);
                break; // limit to the the first page of results
            }
            Assert.IsNotEmpty(namespaceListByResourceGroup);
            Assert.GreaterOrEqual(namespaceListByResourceGroup.Count, 1);

            // Update DeviceRegistry Namespace
            var namespaceResource = namespaceReadResponse.Value;
            var namespacePatchData = new DeviceRegistryNamespacePatch
            {
                Properties = new()
                {
                    MessagingEndpoints = {
                        ["endpoint2"] = new MessagingEndpoint("https://myendpoint2.westeurope-1.iothub.azure.net")
                        {
                            EndpointType = "Microsoft.Devices/IoTHubs",
                            ResourceId = "/subscriptions/8c64812d-6e59-4e65-96b3-14a7cdb1a4e4/resourceGroups/adr-sdk-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace2"
                        }
                    }
                }
            };
            var namespaceUpdateResponse = await namespaceResource.UpdateAsync(WaitUntil.Completed, namespacePatchData, CancellationToken.None);
            Assert.IsNotNull(namespaceUpdateResponse.Value);
            Assert.AreEqual(namespaceUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint2"].EndpointType, namespacePatchData.Properties.MessagingEndpoints["endpoint2"].EndpointType);
            Assert.AreEqual(namespaceUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint2"].Address, namespacePatchData.Properties.MessagingEndpoints["endpoint2"].Address);
            Assert.AreEqual(namespaceUpdateResponse.Value.Data.Properties.MessagingEndpoints["endpoint2"].ResourceId, namespacePatchData.Properties.MessagingEndpoints["endpoint2"].ResourceId);

            // Create Root AssetEndpointProfile for Migration Test
            var extendedLocation = new DeviceRegistryExtendedLocation() { ExtendedLocationType = "CustomLocation", Name = _extendedLocationName };
            var assetEndpointProfileName = Recording.GenerateAssetName(_assetEndpointProfileNamePrefix);
            var assetEndpointProfilesCollection = rg.GetDeviceRegistryAssetEndpointProfiles();
            var assetEndpointProfileData = new DeviceRegistryAssetEndpointProfileData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new()
                {
                    TargetAddress = new Uri("opc.tcp://aep-uri"),
                    EndpointProfileType = "Microsoft.OpcUa",
                    Authentication = new DeviceRegistryAuthentication()
                    {
                        Method = AuthenticationMethod.Anonymous,
                    },
                }
            };
            var assetEndpointProfileCreateOrUpdateResponse = await assetEndpointProfilesCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetEndpointProfileName, assetEndpointProfileData, CancellationToken.None);
            Assert.IsNotNull(assetEndpointProfileCreateOrUpdateResponse.Value);

            // Create Root Asset for Migration Test
            var assetsCollection = rg.GetDeviceRegistryAssets();
            var assetName = Recording.GenerateAssetName(_assetNamePrefix);
            var assetData = new DeviceRegistryAssetData(AzureLocation.WestUS, extendedLocation)
            {
                Properties = new(assetEndpointProfileName)
                {
                    Description = "This is an asset."
                }
            };
            var assetCreateOrUpdateResponse = await assetsCollection.CreateOrUpdateAsync(WaitUntil.Completed, assetName, assetData, CancellationToken.None);
            Assert.IsNotNull(assetCreateOrUpdateResponse.Value);

            // Migrate DeviceRegistry Namespace
            var migrateData = new NamespaceMigrateContent();
            migrateData.ResourceIds.Add(assetCreateOrUpdateResponse.Value.Id.ToString());
            var namespaceMigrationResponse = await namespaceResource.MigrateAsync(WaitUntil.Completed, migrateData, CancellationToken.None);
            Assert.IsNotNull(namespaceMigrationResponse);
            // Check that the migration operation succeeded by looking for the migrated asset and device in the namespace
            var namespaceAssetGetResponse = await namespaceResource.GetDeviceRegistryNamespaceAssetAsync(assetName, CancellationToken.None);
            var namespaceAssetResource = namespaceAssetGetResponse.Value;
            Assert.IsNotNull(namespaceAssetResource);
            Assert.AreEqual(namespaceAssetResource.Data.Properties.Description, assetData.Properties.Description);
            var namespaceDeviceGetResponse = await namespaceResource.GetDeviceRegistryNamespaceDeviceAsync(assetEndpointProfileName, CancellationToken.None);
            var namespaceDeviceResource = namespaceDeviceGetResponse.Value;
            Assert.IsNotNull(namespaceDeviceResource);
            var primaryEndpoint = namespaceDeviceResource.Data.Properties.Endpoints.Inbound["primaryEndpoint"];
            Assert.AreEqual(primaryEndpoint.Address, assetEndpointProfileData.Properties.TargetAddress.ToString());
            Assert.AreEqual(primaryEndpoint.EndpointType, assetEndpointProfileData.Properties.EndpointProfileType);

            // Delete the Namespace Asset and Device created for Migration Test
            await namespaceAssetResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            try
            {
                await namespaceDeviceResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            }
            catch (RequestFailedException ex)
            {
                // Delete temporary returns 200 since async operation is defined for the resource but not implemented in RP
                if (ex.Status != 200)
                {
                    throw;
                }
            }

            // Delete DeviceRegistry Namespace
            await namespaceResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
