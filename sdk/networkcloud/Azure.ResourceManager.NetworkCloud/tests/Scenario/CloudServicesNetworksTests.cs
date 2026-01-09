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
            Assert.That(cloudServicesNetworkName, Is.EqualTo(cloudServicesNetworkToCreate.Value.Data.Name));

            // Get
            var retrievedCloudServicesNetwork = await cloudServicesNetworkCollection.GetAsync(cloudServicesNetworkName);
            Assert.That(cloudServicesNetworkName, Is.EqualTo(retrievedCloudServicesNetwork.Value.Data.Name));

            // Update
            var patchData = new NetworkCloudCloudServicesNetworkPatch()
            {
                Tags = {
                    ["key1"] = "myvalue1"
                }
            };
            var patchedCloudServicesNetwork = await cloudServicesNetwork.UpdateAsync(WaitUntil.Completed, patchData);
            Assert.That(patchedCloudServicesNetwork.Value.Data.Tags["key1"], Is.EqualTo("myvalue1"));

            // List by Resource Group
            var cloudServicesNetworkListByResourceGroup = new List<NetworkCloudCloudServicesNetworkResource>();
            await foreach (NetworkCloudCloudServicesNetworkResource item in cloudServicesNetworkCollection.GetAllAsync()) {
                cloudServicesNetworkListByResourceGroup.Add(item);
            }
            Assert.That(cloudServicesNetworkListByResourceGroup, Is.Not.Empty);

            // List by Subscription
            var cloudServicesNetworkListBySubscription = new List<NetworkCloudCloudServicesNetworkResource>();
            await foreach (NetworkCloudCloudServicesNetworkResource item in SubscriptionResource.GetNetworkCloudCloudServicesNetworksAsync()) {
                cloudServicesNetworkListBySubscription.Add(item);
            }
            Assert.That(cloudServicesNetworkListBySubscription, Is.Not.Empty);

            // Delete
            var response = await cloudServicesNetwork.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.That(response.HasCompleted, Is.True);
        }
    }
}