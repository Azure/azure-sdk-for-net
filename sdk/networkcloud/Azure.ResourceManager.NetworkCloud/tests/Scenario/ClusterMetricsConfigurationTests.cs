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
    public class ClusterMetricsConfigurationTests : NetworkCloudManagementTestBase
    {
        public ClusterMetricsConfigurationTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public ClusterMetricsConfigurationTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task ClusterMetricsConfiguration()
        {
            // retrieve a parent cluster
            NetworkCloudClusterResource cluster = Client.GetNetworkCloudClusterResource(TestEnvironment.ClusterId);
            cluster = await cluster.GetAsync();

            NetworkCloudClusterMetricsConfigurationCollection collection = cluster.GetNetworkCloudClusterMetricsConfigurations();

            // Create
            // invoke the operation
            string metricsConfigurationName = "default";
            NetworkCloudClusterMetricsConfigurationData createData = new NetworkCloudClusterMetricsConfigurationData
            (
                cluster.Data.Location,
                cluster.Data.ClusterExtendedLocation,
                15
            )
            {
                EnabledMetrics = {},
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<NetworkCloudClusterMetricsConfigurationResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, metricsConfigurationName, createData);
            Assert.AreEqual(metricsConfigurationName, createResult.Value.Data.Name);

            // Get
            NetworkCloudClusterMetricsConfigurationResource clusterMetricsConfiguration = Client.GetNetworkCloudClusterMetricsConfigurationResource(createResult.Value.Data.Id);
            var getResult = await clusterMetricsConfiguration.GetAsync();
            Assert.AreEqual(metricsConfigurationName, getResult.Value.Data.Name);

            // Update
            NetworkCloudClusterMetricsConfigurationPatch patch = new NetworkCloudClusterMetricsConfigurationPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<NetworkCloudClusterMetricsConfigurationResource> updateResult = await clusterMetricsConfiguration.UpdateAsync(WaitUntil.Completed, patch);

            // List by cluster
            var listByCluster = new List<NetworkCloudClusterMetricsConfigurationResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByCluster.Add(item);
            }
            Assert.IsNotEmpty(listByCluster);

            // Delete
            var deleteResult = await clusterMetricsConfiguration.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
