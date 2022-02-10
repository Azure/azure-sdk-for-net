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
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventHubClusterTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        public EventHubClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("not supported yet in 2021-11-01")]
        public async Task GetAvailableClusterRegions()
        {
            await foreach (var _ in DefaultSubscription.GetAvailableClusterRegionClustersAsync())
            {
                return;
            }

            Assert.Fail($"{nameof(SubscriptionExtensions)}.{nameof(SubscriptionExtensions.GetAvailableClusterRegionClustersAsync)} has returned an empty collection of AvailableClusters.");
        }

        [Test]
        [RecordedTest]
        [Ignore("operation not supported for subscription or tenant")]
        public async Task CreateGetUpdateDeleteCluster()
        {
            //create a cluster
            _resourceGroup = await CreateResourceGroupAsync();
            string clusterName = Recording.GenerateAssetName("cluster");
            EventHubClusterCollection clusterCollection = _resourceGroup.GetEventHubClusters();
            EventHubClusterData parameter = new EventHubClusterData(AzureLocation.EastUS2);
            EventHubCluster cluster = (await clusterCollection.CreateOrUpdateAsync(true, clusterName, parameter)).Value;
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
            cluster.Data.Tags.Add("key", "value");
            cluster = (await cluster.UpdateAsync(true, cluster.Data)).Value;
            Assert.AreEqual(cluster.Data.Tags["key"], "value");

            //delete the cluster
            await cluster.DeleteAsync(true);
            Assert.IsFalse(await clusterCollection.ExistsAsync(clusterName));
        }
    }
}
