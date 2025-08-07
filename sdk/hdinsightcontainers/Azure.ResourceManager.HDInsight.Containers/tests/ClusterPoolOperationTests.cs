// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.HDInsight.Containers.Models;
using Castle.Core.Resource;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests
{
    [NonParallelizable]
    [RunFrequency(RunTestFrequency.Manually)]
    public class ClusterPoolOperationTests : HDInsightContainersOperationTestsBase
    {
        public ClusterPoolOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheForRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        [TearDown]
        public async Task Cleanup()
        {
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task TestClusterPoolOperations()
        {
            Location = "westus2";

            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location)
            {
                Properties = new HDInsightClusterPoolProperties(new ClusterPoolComputeProfile("Standard_D4a_v4"))
                {
                    ClusterPoolVersion = "1.2"
                }
            };

            HDInsightClusterPoolCollection clusterPoolCollection = ResourceGroup.GetHDInsightClusterPools();
            var clusterPoolResult = await clusterPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPoolName, clusterPoolData).ConfigureAwait(false);

            // Test get cluster pool
            var getClusterPoolResult = await clusterPoolCollection.GetAsync(clusterPoolResult.Value.Data.Name).ConfigureAwait(false);
            Assert.NotNull(getClusterPoolResult.Value);

            // Test list cluster pool
            var listClusterPoolByResourceGroupResult = await clusterPoolCollection.GetAllAsync().ToEnumerableAsync().ConfigureAwait(false);
            Assert.AreEqual(listClusterPoolByResourceGroupResult.Count(), 1);

            // Test delete cluster pool
            await clusterPoolResult.Value.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);

            var listClusterPoolAfterDeletion = await clusterPoolCollection.GetAllAsync().ToEnumerableAsync().ConfigureAwait(false);
            Assert.AreEqual(listClusterPoolAfterDeletion.Count(), 0);
        }

        [RecordedTest]
        public async Task TesClusterPoolUpgrade()
        {
            Location = "westus2";

            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location)
            {
                Properties = new HDInsightClusterPoolProperties(new ClusterPoolComputeProfile("Standard_D4a_v4"))
                {
                    ClusterPoolVersion = "1.1"
                }
            };

            HDInsightClusterPoolCollection clusterPoolCollection = ResourceGroup.GetHDInsightClusterPools();

            var clusterPoolResult = await clusterPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPoolName, clusterPoolData).ConfigureAwait(false);

            // Test get cluster pool available upgrades
            AsyncPageable<ClusterPoolAvailableUpgrade> availableUpgrades = clusterPoolResult.Value.GetClusterPoolAvailableUpgradesAsync();
            await foreach (var availableUpgrade in availableUpgrades)
            {
                Assert.NotNull(availableUpgrade);
            }

            // Test get cluster pool upgrade histories
            AsyncPageable<ClusterPoolUpgradeHistory> upgradeHistories = clusterPoolResult.Value.GetClusterPoolUpgradeHistoriesAsync();
            await foreach (var availableUpgrade in upgradeHistories)
            {
                Assert.NotNull(availableUpgrade);
            }
        }

        [RecordedTest]
        public async Task TestClusterPoolWithPrivateNetwork()
        {
            Location = "westus2";

            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            // Create a network profile with private API server enabled
            Core.ResourceIdentifier networkId = new Core.ResourceIdentifier("/subscriptions/10e32bab-26da-4cc4-a441-52b318f824e6/resourceGroups/Yuchen-GA-Test/providers/Microsoft.Network/virtualNetworks/GA-VN-wus2/subnets/default");
            ClusterPoolNetworkProfile clusterPoolNetworkProfile = new ClusterPoolNetworkProfile(networkId)
            {
                IsPrivateApiServerEnabled = true,
                OutboundType = OutboundType.LoadBalancer
            };

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location)
            {
                Properties = new HDInsightClusterPoolProperties(new ClusterPoolComputeProfile("Standard_D4a_v4"))
                {
                    ClusterPoolVersion = "1.2",
                    NetworkProfile = clusterPoolNetworkProfile
                }
            };

            HDInsightClusterPoolCollection clusterPoolCollection = ResourceGroup.GetHDInsightClusterPools();
            var clusterPoolResult = await clusterPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPoolName, clusterPoolData).ConfigureAwait(false);

            // Test get cluster pool
            var clusterPool = await clusterPoolCollection.GetAsync(clusterPoolResult.Value.Data.Name).ConfigureAwait(false);
            Assert.AreEqual(clusterPool.Value.Data.Properties.NetworkProfile.SubnetId, networkId);

            // Test update cluster pool tags
            await clusterPool.Value.AddTagAsync("SDK", "Test");
            clusterPool = await clusterPoolCollection.GetAsync(clusterPoolResult.Value.Data.Name).ConfigureAwait(false);
            Assert.AreEqual(clusterPool.Value.Data.Tags["SDK"], "Test");
        }
    }
}
