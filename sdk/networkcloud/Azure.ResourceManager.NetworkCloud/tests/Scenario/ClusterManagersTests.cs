// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
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
            var clusterManagerCollection = ResourceGroupResource.GetClusterManagers();
            string clusterManagerName = Recording.GenerateAssetName("clustermanager");

            // Create
            var createData = new ClusterManagerData(new AzureLocation(TestEnvironment.Location), TestEnvironment.SubnetId)
            {
                Tags = {
                    ["DisableFabricIntegration"] = "true"
                }
            };
            var createResult = await clusterManagerCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterManagerName, createData);
            // check a specific tag as the subscription policies add more automatically.
            Assert.AreEqual(createResult.Value.Data.Tags["DisableFabricIntegration"], createData.Tags["DisableFabricIntegration"]);

            // Get
            var getResult =await clusterManagerCollection.GetAsync(clusterManagerName);
            Assert.AreEqual(getResult.Value.Data.Name, clusterManagerName);
            ClusterManagerResource clusterManagerResource = Client.GetClusterManagerResource(getResult.Value.Data.Id);

            // Update
            var newTags = new ClusterManagerPatch()
            {
                Tags = {
                    ["DisableFabricIntegration"] = "true",
                    ["PatchTag"] = "patchTag",
                }
            };
            ClusterManagerResource updateResponse = await clusterManagerResource.UpdateAsync(newTags);
            Assert.AreEqual(updateResponse.Data.Tags["DisableFabricIntegration"], "true");
            Assert.AreEqual(updateResponse.Data.Tags["PatchTag"], "patchTag");

            // List by Resource Group
            var listByResourceGroup = new List<ClusterManagerResource>();
            await foreach (ClusterManagerResource item in clusterManagerCollection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<ClusterManagerResource>();
            await foreach (ClusterManagerResource item in SubscriptionResource.GetClusterManagersAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await clusterManagerResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
