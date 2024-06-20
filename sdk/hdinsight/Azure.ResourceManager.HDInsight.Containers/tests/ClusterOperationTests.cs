// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
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
        public async Task TestCheckIfClusterNameAvaliable()
        {
            Location = "west us 3";

            // Create cluster pool
            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");
            string clusterName = Recording.GenerateAssetName("sdk-test-cluster-");
            Response<HDInsightNameAvailabilityResult> response = await Subscription.CheckHDInsightNameAvailabilityAsync(Location, new HDInsightNameAvailabilityContent()
            {
                Name = clusterPoolName + "/" + clusterName,
                ResourceType = "Microsoft.HDInsight/clusterPools/clusters",
            });
            Assert.IsTrue(response.Value.IsNameAvailable);
        }

        [RecordedTest]
        public async Task TestTrinoCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.1";

            // Create cluster pool
            string clusterPoolName = Recording.GenerateAssetName("sdk-testpool-");

            HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(Location);
            clusterPoolData.ClusterPoolVersion = ClusterPoolVersion;
            string clusterPoolVmSize = "Standard_E4s_v3";
            clusterPoolData.ComputeProfile = new ClusterPoolComputeProfile(clusterPoolVmSize);

            HDInsightClusterPoolCollection clusterPoolCollection = ResourceGroup.GetHDInsightClusterPools();
            ArmOperation<HDInsightClusterPoolResource> clusterPoolResult = await clusterPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPoolName, clusterPoolData).ConfigureAwait(false);

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
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            var clusterData = new HDInsightClusterData(Location);
            clusterData.ClusterType = clusterType;

            clusterData.ComputeProfile = new ComputeProfile(new List<ClusterComputeNodeProfile> { nodeProfile });

            clusterData.ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersionResult.ClusterVersion, ossVersion: availableClusterVersionResult.OssVersion, authorizationProfile: authorizationProfile);
            clusterData.ClusterProfile.IdentityProfile = identityProfile;
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

        [RecordedTest]
        public async Task TestUpdateSparkCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.0";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Spark";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create spark cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // set the IdentityProfile
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";
            var identityProfile = new HDInsightIdentityProfile(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testmsi"), msiClientId: msiClientId, msiObjectId: msiObjectId);

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // spark profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            var clusterData = new HDInsightClusterData(Location);
            clusterData.ClusterType = clusterType;

            clusterData.ComputeProfile = new ComputeProfile(new List<ClusterComputeNodeProfile> { nodeProfile });

            clusterData.ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersionResult.ClusterVersion, ossVersion: availableClusterVersionResult.OssVersion, authorizationProfile: authorizationProfile);
            clusterData.ClusterProfile.IdentityProfile = identityProfile;
            // set saprk profile

            clusterData.ClusterProfile.SparkProfile = new SparkProfile()
            {
                DefaultStorageUriString = "abfs://sparkps@hilostorage.dfs.core.windows.net",
            };

            string resourcesGroupName = "testGroup";
            string clusterpoolName = "DemoPool125";
            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);

            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var sparkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);
            Assert.AreEqual(sparkClusterResult.Value.Data.ClusterProfile.ServiceConfigsProfiles.Count, 0);

            // initialize the ClusterServiceConfigsProfile.
            ClusterConfigFile clusterConfigFile = new ClusterConfigFile("yarn-site.xml")
            {
                Values = {
                        ["yarn.nodemanager.resource.memory-mb"] = "22223",
                        ["yarn.scheduler.maximum-allocation-mb"] = "22223"
                    }
            };
            ClusterServiceConfig clusterServiceConfig = new ClusterServiceConfig(component: "hadoop-config-client", new ClusterConfigFile[] { clusterConfigFile });
            ClusterServiceConfigsProfile clusterServiceConfigsProfile = new ClusterServiceConfigsProfile(serviceName: "yarn-service", new ClusterServiceConfig[] { clusterServiceConfig });

            // invoke the operation
            HDInsightClusterPatch patch = new HDInsightClusterPatch()
            {
                ClusterProfile = new UpdatableClusterProfile()
                {
                    ServiceConfigsProfiles = { clusterServiceConfigsProfile },
                }
            };

            HDInsightClusterResource value = sparkClusterResult.Value.UpdateAsync(WaitUntil.Completed, patch).Result.Value;
            Assert.AreEqual(value.Data.ClusterProfile.ServiceConfigsProfiles.Count, 1);
        }

        [RecordedTest]
        public async Task TestSubmitJobToFlinkCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.1";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Flink";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create flink cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // create managed user assigned identity with the new package
            string msiName = Recording.GenerateAssetName($"sdk-{clusterName}-msi-");
            UserAssignedIdentityCollection userAssignedIdentityCollection = ResourceGroup.GetUserAssignedIdentities();
            UserAssignedIdentityData userAssignedIdentityData = new UserAssignedIdentityData(Location);
            var userMsi = await userAssignedIdentityCollection.CreateOrUpdateAsync(WaitUntil.Completed, msiName, userAssignedIdentityData).ConfigureAwait(false);

            // set the IdentityProfile
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";
            var identityProfile = new HDInsightIdentityProfile(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testmsi"), msiClientId: msiClientId, msiObjectId: msiObjectId);

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // flink profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 3;
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            var clusterData = new HDInsightClusterData(Location);
            clusterData.ClusterType = clusterType;

            clusterData.ComputeProfile = new ComputeProfile(new List<ClusterComputeNodeProfile> { nodeProfile });

            clusterData.ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersionResult.ClusterVersion, ossVersion: availableClusterVersionResult.OssVersion, authorizationProfile: authorizationProfile);
            clusterData.ClusterProfile.IdentityProfile = identityProfile;
            // set flink profile
            clusterData.ClusterProfile.FlinkProfile = new FlinkProfile() {
                    JobManager = new ComputeResourceRequirement(1, 2000),
                    TaskManager = new ComputeResourceRequirement(6, 49016),
                    Storage = new FlinkStorageProfile()
                    {
                       StorageUriString = "abfs://cluster2024221@cluster202422113392st0lz.dfs.core.windows.net"
                    }
                };

            string resourcesGroupName = "testGroup";
            string clusterpoolName = "hilopool";
            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);

            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var flinkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            ClusterJob clusterJob = new ClusterJob(new FlinkJobProperties()
            {
                JobName = "flink-job-name",
                JobJarDirectory = "abfs://storage@flinkdemo.dfs.core.windows.net/jars",
                JarName = "FlinkJobDemo-1.0-SNAPSHOT.jar",
                EntryClass = "org.example.SleepJob",
                Action = FlinkJobAction.New,
                FlinkConfiguration =
                    {
                       ["parallelism"] = "1"
                    },
            });

            ArmOperation<ClusterJob> armOperation = await flinkClusterResult.Value.RunJobClusterJobAsync(WaitUntil.Completed, clusterJob);
            Assert.NotNull(armOperation.Value);
        }

        [RecordedTest]
        public async Task TestAutoScaleSparkCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.0";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Spark";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create spark cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // set the IdentityProfile
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";
            var identityProfile = new HDInsightIdentityProfile(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testmsi"), msiClientId: msiClientId, msiObjectId: msiObjectId);

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // spark profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            var clusterData = new HDInsightClusterData(Location);
            clusterData.ClusterType = clusterType;

            clusterData.ComputeProfile = new ComputeProfile(new List<ClusterComputeNodeProfile> { nodeProfile });

            clusterData.ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersionResult.ClusterVersion, ossVersion: availableClusterVersionResult.OssVersion, authorizationProfile: authorizationProfile);
            clusterData.ClusterProfile.IdentityProfile = identityProfile;

            // set saprk profile
            clusterData.ClusterProfile.SparkProfile = new SparkProfile()
            {
                DefaultStorageUriString = "abfs://sparkautoscale@hilostorage.dfs.core.windows.net",
            };

            string resourcesGroupName = "testGroup";
            string clusterpoolName = "DemoPool125";
            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);

            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var sparkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            HDInsightClusterPatch patch = new HDInsightClusterPatch()
                {
                    ClusterProfile = new UpdatableClusterProfile()
                    {
                        AutoscaleProfile = new ClusterAutoscaleProfile(true)
                        {
                            GracefulDecommissionTimeout = -1,
                            AutoscaleType = ClusterAutoscaleType.ScheduleBased,
                            ScheduleBasedConfig = new ScheduleBasedConfig("UTC", 3, new AutoscaleSchedule[]{
                                new AutoscaleSchedule("00:00","12:00",3,new AutoscaleScheduleDay[]
                                {
                                    new AutoscaleScheduleDay("Monday, Tuesday, Wednesday")
                                }),
                            }),
                        },
                    },
                };

            sparkClusterResult = await sparkClusterResult.Value.UpdateAsync(WaitUntil.Completed, patch);

            Assert.AreEqual(sparkClusterResult.Value.Data.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].StartOn, "00:00");
            Assert.AreEqual(sparkClusterResult.Value.Data.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].EndOn, "12:00");
            Assert.AreEqual(sparkClusterResult.Value.Data.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].Days.Count, 1);
        }
    }
}
