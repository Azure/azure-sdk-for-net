// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class ClusterManagersTests : NetworkCloudManagementTestBase
    {
        public ClusterManagersTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public ClusterManagersTests(bool isAsync) : base(isAsync) {}

        // updated from Test to RecordedTest per pipeline recommendation
        [RecordedTest]
        public async Task ClusterManagers()
        {
            var clusterManagerCollection = ResourceGroupResource.GetNetworkCloudClusterManagers();
            string clusterManagerName = Recording.GenerateAssetName("clustermanager");

            // Create
            var createData = new NetworkCloudClusterManagerData(new AzureLocation(TestEnvironment.Location), new ResourceIdentifier(TestEnvironment.SubnetId))
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Tags = {
                    ["DisableFabricIntegration"] = "true"
                }
            };
            var createResult = await clusterManagerCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterManagerName, createData);
            // check a specific tag as the subscription policies add more automatically.
            Assert.That(createData.Tags["DisableFabricIntegration"], Is.EqualTo(createResult.Value.Data.Tags["DisableFabricIntegration"]));

            // Get
            var getResult =await clusterManagerCollection.GetAsync(clusterManagerName);
            Assert.That(clusterManagerName, Is.EqualTo(getResult.Value.Data.Name));
            NetworkCloudClusterManagerResource clusterManagerResource = Client.GetNetworkCloudClusterManagerResource(getResult.Value.Data.Id);

            // Update
            var newTags = new NetworkCloudClusterManagerPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Tags = {
                    ["DisableFabricIntegration"] = "true",
                    ["PatchTag"] = "patchTag",
                }
            };
            NetworkCloudClusterManagerResource updateResponse = await clusterManagerResource.UpdateAsync(newTags);
            Assert.That(updateResponse.Data.Tags["DisableFabricIntegration"], Is.EqualTo("true"));
            Assert.That(updateResponse.Data.Tags["PatchTag"], Is.EqualTo("patchTag"));

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudClusterManagerResource>();
            await foreach (NetworkCloudClusterManagerResource item in clusterManagerCollection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.That(listByResourceGroup, Is.Not.Empty);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudClusterManagerResource>();
            await foreach (NetworkCloudClusterManagerResource item in SubscriptionResource.GetNetworkCloudClusterManagersAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.That(listBySubscription, Is.Not.Empty);

            // Delete
            var deleteResult = await clusterManagerResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.That(deleteResult.HasCompleted, Is.True);
        }
    }
}
