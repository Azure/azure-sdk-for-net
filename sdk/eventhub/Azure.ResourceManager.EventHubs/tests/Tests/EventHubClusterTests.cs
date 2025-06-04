// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventHubClusterTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        public EventHubClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("RequestFailedException: the supported api-versions are '2018-01-01-preview'")]
        public async Task GetAvailableClusterRegions()
        {
            await foreach (var _ in DefaultSubscription.GetAvailableClusterRegionClustersAsync())
            {
                return;
            }

            Assert.Fail($"{nameof(EventHubsExtensions)}.{nameof(EventHubsExtensions.GetAvailableClusterRegionClustersAsync)} has returned an empty collection of AvailableClusters.");
        }

        [Test]
        [RecordedTest]
        [Ignore("operation not supported for subscription or tenant")]
        public async Task CreateGetUpdateDeleteCluster()
        {
            //create a cluster
            _resourceGroup = await CreateResourceGroupAsync();
            string clusterName = Recording.GenerateAssetName("cluster");
            EventHubsClusterCollection clusterCollection = _resourceGroup.GetEventHubsClusters();
            EventHubsClusterData parameter = new EventHubsClusterData(AzureLocation.EastUS2);
            EventHubsClusterResource cluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, parameter)).Value;
            Assert.NotNull(cluster);
            Assert.AreEqual(cluster.Data.Name, clusterName);

            //get the cluster
            cluster = await clusterCollection.GetAsync(clusterName);
            Assert.NotNull(cluster);
            Assert.AreEqual(cluster.Data.Name, clusterName);

            //get the namespace under cluster
            SubResource subResource = null;
            await foreach (var namespaceId in cluster.GetNamespacesAsync())
            {
                subResource = namespaceId;
                break;
            }

            Assert.NotNull(subResource);

            //update the cluster
            cluster.Data.Tags.Add("key1", "value1");
            cluster = (await cluster.UpdateAsync(WaitUntil.Completed, cluster.Data)).Value;
            Assert.AreEqual(cluster.Data.Tags["key1"], "value1");

            //delete the cluster
            await cluster.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await clusterCollection.ExistsAsync(clusterName));
        }
    }
}
