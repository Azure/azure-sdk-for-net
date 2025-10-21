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
    public class DeviceRegistryNamespacesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-namespaces-rg";
        private readonly string _namespaceNamePrefix = "deviceregistry-test-namespace-sdk";

        public DeviceRegistryNamespacesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task NamespacesCrudOperationsTest()
        {
            var namespaceName = Recording.GenerateAssetName(_namespaceNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);

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

            // Delete DeviceRegistry Namespace
            await namespaceResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
