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
        public async Task ClusterMetricsConfiguration()
        {
            ClusterResource cluster = Client.GetClusterResource(TestEnvironment.ClusterId);
            var clusterResponse = await cluster.GetAsync();
            var clusterName = clusterResponse.Value.Data.Name;
            ClusterMetricsConfigurationCollection collection = cluster.GetClusterMetricsConfigurations();

            // Create
            // invoke the operation
            string metricsConfigurationName = "default";
            ClusterMetricsConfigurationData createData = new ClusterMetricsConfigurationData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                15
            )
            {
                EnabledMetrics = {},
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<ClusterMetricsConfigurationResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, metricsConfigurationName, createData);
            Assert.AreEqual(metricsConfigurationName, createResult.Value.Data.Name);

            // Get
            ClusterMetricsConfigurationResource clusterMetricsConfiguration = Client.GetClusterMetricsConfigurationResource(createResult.Value.Data.Id);
            var getResult = await clusterMetricsConfiguration.GetAsync();
            Assert.AreEqual(metricsConfigurationName, getResult.Value.Data.Name);

            // Update
            ClusterMetricsConfigurationPatch patch = new ClusterMetricsConfigurationPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<ClusterMetricsConfigurationResource> updateResult = await clusterMetricsConfiguration.UpdateAsync(WaitUntil.Completed, patch);

            // List by Resource Group
            var listByResourceGroup = new List<ClusterMetricsConfigurationResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            // var listBySubscription = new List<ClusterMetricsConfigurationResource>();
            // await foreach (var item in SubscriptionResource.GetClusterMetricsConfigurationsAsync(clusterName))
            // {
            //     listBySubscription.Add(item);
            // }
            // Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await clusterMetricsConfiguration.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}