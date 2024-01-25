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
            Location = "west us 2";

            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location);

            string clusterPoolVmSize = "Standard_E4s_v3";
            clusterPoolData.ComputeProfile = new ClusterPoolComputeProfile(clusterPoolVmSize);

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
    }
}
