// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.EventHubs.Tests.Helpers;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class ClusterTests: EventHubTestBase
    {
        public ClusterTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteCluster()
        {
            //create resource group
            ResourceGroup resourceGroup =await CreateResourceGroupAsync();

            //create cluster
            ClusterContainer clusterContainer = resourceGroup.GetClusters();
            ClusterData parameter = new ClusterData(Location.EastUS2)
            {
                Sku = new ClusterSku(ClusterSkuName.Dedicated)
            };
            string clusterName = Recording.GenerateAssetName("testcluster");
            Cluster cluster = (await clusterContainer.CreateOrUpdateAsync(clusterName, parameter)).Value;
            Assert.NotNull(cluster);
            Assert.NotNull(cluster.Data);
            Assert.AreEqual(cluster.Data.Sku.Name, ClusterSkuName.Dedicated);

            //get cluster
            cluster = await clusterContainer.GetAsync(clusterName);
            Assert.NotNull(cluster);
            Assert.NotNull(cluster.Data);
            Assert.AreEqual(cluster.Data.Sku.Name, ClusterSkuName.Dedicated);

            //get cluster under subscription
            List<Cluster> clusters =await DefaultSubscription.GetClustersAsync().ToEnumerableAsync();
            Assert.IsTrue(clusters.Count>0);
            cluster = clusters[0];
            Assert.NotNull(cluster);
            Assert.NotNull(cluster.Data);
            Assert.AreEqual(cluster.Data.Sku.Name, ClusterSkuName.Dedicated);

            //update cluster tag
            parameter.Tags.Add("key", "value");
            cluster = (await cluster.UpdateAsync(parameter)).Value;
            Assert.NotNull(cluster);
            Assert.NotNull(cluster.Data);
            Assert.AreEqual(cluster.Data.Tags.Count, 1);

            //delete cluster
            await cluster.DeleteAsync();

            //validate deletion
            clusters = await DefaultSubscription.GetClustersAsync().ToEnumerableAsync();
            Assert.IsTrue(clusters.Count == 0);
            Assert.IsFalse(await clusterContainer.CheckIfExistsAsync(clusterName));
        }
    }
}
