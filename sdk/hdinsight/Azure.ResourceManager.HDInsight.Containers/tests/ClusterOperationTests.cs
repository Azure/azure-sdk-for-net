// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.HDInsight.Containers.Models;
using Azure.ResourceManager.ManagedServiceIdentities;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests
{
    [NonParallelizable]
    [RunFrequency(RunTestFrequency.Manually)]
    public class ClusterOperationTests : HDInsightContainersOperationTestsBase
    {
        public ClusterOperationTests(bool isAsync) : base(isAsync)
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
        public async Task TestTrinoCluster()
        {
            Location = "west us 2";

            // Create cluster pool
            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location);
            string clusterPoolVmSize = "Standard_E4s_v3";
            clusterPoolData.ComputeProfile = new ClusterPoolComputeProfile(clusterPoolVmSize);

            HDInsightClusterPoolCollection clusterPoolCollection = ResourceGroup.GetHDInsightClusterPools();
            var clusterPoolResult = await clusterPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPoolName, clusterPoolData).ConfigureAwait(false);

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Trino";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            // Create trino cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // create managed user assigned identity with the new package
            string msiName = Recording.GenerateAssetName($"sdk-{clusterName}-msi-");
            UserAssignedIdentityCollection userAssignedIdentityCollection = ResourceGroup.GetUserAssignedIdentities();
            UserAssignedIdentityData userAssignedIdentityData = new UserAssignedIdentityData(Location);
            var userMsi = await userAssignedIdentityCollection.CreateOrUpdateAsync(WaitUntil.Completed, msiName, userAssignedIdentityData).ConfigureAwait(false);

            // set the IdentityProfile
            string msiClientId = userMsi.Value.Data.ClientId.ToString();
            string msiObjectId = userMsi.Value.Data.PrincipalId.ToString();
            var identityProfile = new HDInsightIdentityProfile(msiResourceId: userMsi.Value.Id, msiClientId: msiClientId, msiObjectId: msiObjectId);

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // trino profile
            string vmSize = "Standard_D8s_v3";
            int workerCount = 5;
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            var clusterData = new HDInsightClusterData(Location);
            clusterData.ClusterType = clusterType;

            clusterData.ComputeProfile = new ComputeProfile(new List<ClusterComputeNodeProfile> { nodeProfile });

            clusterData.ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersionResult.ClusterVersion, ossVersion: availableClusterVersionResult.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile);

            // set trino profile
            clusterData.ClusterProfile.TrinoProfile = new TrinoProfile();

            var clusterCollection = clusterPoolResult.Value.GetHDInsightClusters();
            var trinoClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            // Get trino cluster instance view
            var clusterInstanceViewResult = await trinoClusterResult.Value.GetInstanceViewAsync().ConfigureAwait(false);

            // Get trino cluster service configurations
            var clusterServiceConfigurations = await trinoClusterResult.Value.GetServiceConfigsAsync().ToEnumerableAsync().ConfigureAwait(false);

            // Delete the trino cluster
            await trinoClusterResult.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
