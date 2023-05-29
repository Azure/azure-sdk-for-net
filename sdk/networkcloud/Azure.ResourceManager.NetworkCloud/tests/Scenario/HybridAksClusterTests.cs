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
    public class HybridAksClusterTests : NetworkCloudManagementTestBase
    {
        public HybridAksClusterTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public HybridAksClusterTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task HybridAksCluster()
        {
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterManagedRG);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);

            HybridAksClusterCollection collection = resourceGroupResource.GetHybridAksClusters();

            // List by Resource Group
            var listByResourceGroup = new List<HybridAksClusterResource>();
            await foreach (HybridAksClusterResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);
            var firstHaksCluster = listByResourceGroup[0].Data;

            // List by Subscription
            var listBySubscription = new List<HybridAksClusterResource>();
            await foreach (HybridAksClusterResource item in SubscriptionResource.GetHybridAksClustersAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Get
            HybridAksClusterResource getResult = await collection.GetAsync(firstHaksCluster.Name);
            Assert.AreEqual(firstHaksCluster.Name, getResult.Data.Name);

            // Update
            HybridAksClusterResource firstHybridAksCluster = Client.GetHybridAksClusterResource(firstHaksCluster.Id);
            string testKey = "test-key";
            string testValue = "test-value";
            HybridAksClusterPatch patch = new HybridAksClusterPatch()
            {
                Tags= {[testKey] = testValue},
            };
            // duplicate existing tags
            foreach (var key in firstHaksCluster.Tags.Keys)
            {
                patch.Tags[key] = firstHaksCluster.Tags[key];
            }
            // PATCH add test tag
            HybridAksClusterResource updateResult = await firstHybridAksCluster.UpdateAsync(patch);
            Assert.AreEqual(testValue, updateResult.Data.Tags[testKey]);
            // revert PATCH update
            patch.Tags.Remove(testKey);
            updateResult = await firstHybridAksCluster.UpdateAsync(patch);
            Assert.IsFalse(updateResult.Data.Tags.ContainsKey(testKey), "test key/value pair not removed from HAKS Cluster");
        }
    }
}