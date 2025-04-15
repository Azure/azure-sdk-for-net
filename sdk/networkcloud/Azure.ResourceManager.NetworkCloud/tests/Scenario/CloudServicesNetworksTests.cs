// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class CloudServicesNetworksTests : NetworkCloudManagementTestBase
    {
        public CloudServicesNetworksTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public CloudServicesNetworksTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task CloudServicesNetworks()
        {
            var cloudServicesNetworkCollection = ResourceGroupResource.GetNetworkCloudCloudServicesNetworks();
            var cloudServicesNetworkName = Recording.GenerateAssetName("csn");

            var cloudServicesNetworkId = NetworkCloudCloudServicesNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceIdentifier.Parse(ResourceGroupResource.Id).Name, cloudServicesNetworkName);
            var cloudServicesNetwork = Client.GetNetworkCloudCloudServicesNetworkResource(cloudServicesNetworkId);

            // Create
            var data = new NetworkCloudCloudServicesNetworkData(new AzureLocation(TestEnvironment.Location), new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation")) {
                AdditionalEgressEndpoints = {
                    new EgressEndpoint("azure-resource-management", new EndpointDependency[]{
                        new EndpointDependency("storageaccountex.blob.core.windows.net")
                        {
                            Port = 443
                        }
                    })
                }
            };
            var cloudServicesNetworkToCreate = await cloudServicesNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, cloudServicesNetworkName, data);
            Assert.AreEqual(cloudServicesNetworkToCreate.Value.Data.Name, cloudServicesNetworkName);

            // Get
            var retrievedCloudServicesNetwork = await cloudServicesNetworkCollection.GetAsync(cloudServicesNetworkName);
            Assert.AreEqual(retrievedCloudServicesNetwork.Value.Data.Name, cloudServicesNetworkName);

            // Update
            var patchData = new NetworkCloudCloudServicesNetworkPatch()
            {
                Tags = {
                    ["key1"] = "myvalue1"
                }
            };
            var patchedCloudServicesNetwork = await cloudServicesNetwork.UpdateAsync(WaitUntil.Completed, patchData);
            Assert.AreEqual(patchedCloudServicesNetwork.Value.Data.Tags["key1"], "myvalue1");

            // List by Resource Group
            var cloudServicesNetworkListByResourceGroup = new List<NetworkCloudCloudServicesNetworkResource>();
            await foreach (NetworkCloudCloudServicesNetworkResource item in cloudServicesNetworkCollection.GetAllAsync()) {
                cloudServicesNetworkListByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(cloudServicesNetworkListByResourceGroup);

            // List by Subscription
            var cloudServicesNetworkListBySubscription = new List<NetworkCloudCloudServicesNetworkResource>();
            await foreach (NetworkCloudCloudServicesNetworkResource item in SubscriptionResource.GetNetworkCloudCloudServicesNetworksAsync()) {
                cloudServicesNetworkListBySubscription.Add(item);
            }
            Assert.IsNotEmpty(cloudServicesNetworkListBySubscription);

            // Delete
            var response = await cloudServicesNetwork.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(response.HasCompleted);
        }
    }
}