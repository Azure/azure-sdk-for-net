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
        private string resourcesGroupName = "GA-Test";
        private string clusterpoolName = "pool12";
        private string ClusterPoolVersion = "1.2";

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

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Trino";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create trino cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // create managed user assigned identity with the new package
            string msiName = Recording.GenerateAssetName($"sdk-{clusterName}-msi-");
            UserAssignedIdentityCollection userAssignedIdentityCollection = ResourceGroup.GetUserAssignedIdentities();
            UserAssignedIdentityData userAssignedIdentityData = new UserAssignedIdentityData(Location);
            var userMsi = await userAssignedIdentityCollection.CreateOrUpdateAsync(WaitUntil.Completed, msiName, userAssignedIdentityData).ConfigureAwait(false);
            string msiClientId = userMsi.Value.Data.ClientId.ToString();
            string msiObjectId = userMsi.Value.Data.PrincipalId.ToString();

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // trino profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster", userMsi.Value.Id, msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };

            // set trino profile
            clusterProfile.TrinoProfile = new TrinoProfile();

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);
            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var trinoClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            // Get trino cluster instance view
            var clusterInstanceViewResult = await trinoClusterResult.Value.GetInstanceViewAsync().ConfigureAwait(false);

            // Get trino cluster service configurations
            var clusterServiceConfigurations = await trinoClusterResult.Value.GetServiceConfigsAsync().ToEnumerableAsync().ConfigureAwait(false);

            // Delete the trino cluster
            await trinoClusterResult.Value.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task TestTrinoClusterWithHMS()
        {
            Location = "west us 3";

            string userMsiId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/psmsi";
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";

            // define the HMS configurations
            string metastoreDbConnectionPasswordSecret = "sqlpassword";
            string metastoreDbConnectionURL = "jdbc:sqlserver://ycgaserver.database.windows.net;database=trinohms;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=30";
            string metastoreDbConnectionUserName = "hdi";
            string metastoreWarehouseDir = "abfs://trino122@hilostorage.dfs.core.windows.net/warehouse";

            // Secret cofig
            string keyVaultResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hilocli-test/providers/Microsoft.KeyVault/vaults/HiloCLIKV";
            string keyVaultObjectName = "sqlpassword";
            string referenceName = "sqlpassword";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Trino";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create trino cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // trino profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster", new ResourceIdentifier(userMsiId), msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };

            // set trino profile
            clusterProfile.TrinoProfile = new TrinoProfile();

            // initialize the ClusterServiceConfigsProfile for HMS
            ClusterServiceConfigsProfile clusterServiceConfigsProfile = new ClusterServiceConfigsProfile(serviceName: "trino", new ClusterServiceConfig[] {
                new ClusterServiceConfig(component: "common", new ClusterConfigFile[] { new ClusterConfigFile("config.properties")
                    {
                        Values = {
                                ["hive.metastore.hdi.metastoreDbConnectionAuthenticationMode"] = "SqlAuth",
                                ["hive.metastore.hdi.metastoreDbConnectionPasswordSecret"] = metastoreDbConnectionPasswordSecret,
                                ["hive.metastore.hdi.metastoreDbConnectionURL"] = metastoreDbConnectionURL,
                                ["hive.metastore.hdi.metastoreDbConnectionUserName"] = metastoreDbConnectionUserName,
                                ["hive.metastore.hdi.metastoreWarehouseDir"] = metastoreWarehouseDir
                        }
                    }
                })
            });
            clusterProfile.ServiceConfigsProfiles.Add(clusterServiceConfigsProfile);

            ClusterSecretsProfile clusterSecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(keyVaultResourceId));
            clusterSecretsProfile.Secrets.Add(new ClusterSecretReference(referenceName, KeyVaultObjectType.Secret, keyVaultObjectName));
            clusterProfile.SecretsProfile = clusterSecretsProfile;

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);
            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var trinoClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task TestTrinoClusterAzZone()
        {
            Location = "west us 3";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Trino";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create trino cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            // create managed user assigned identity with the new package
            string msiName = Recording.GenerateAssetName($"sdk-{clusterName}-msi-");
            UserAssignedIdentityCollection userAssignedIdentityCollection = ResourceGroup.GetUserAssignedIdentities();
            UserAssignedIdentityData userAssignedIdentityData = new UserAssignedIdentityData(Location);
            var userMsi = await userAssignedIdentityCollection.CreateOrUpdateAsync(WaitUntil.Completed, msiName, userAssignedIdentityData).ConfigureAwait(false);
            string msiClientId = userMsi.Value.Data.ClientId.ToString();
            string msiObjectId = userMsi.Value.Data.PrincipalId.ToString();

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // trino profile
            string vmSize = "Standard_D16a_v4";
            int workerCount = 5;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });

            // set availability zones
            nodeProfile.AvailabilityZones.Add("1");
            nodeProfile.AvailabilityZones.Add("2");

            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster", userMsi.Value.Id, msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };

            // set trino profile
            clusterProfile.TrinoProfile = new TrinoProfile();

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);
            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var trinoClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            // Get trino cluster instance view
            var clusterInstanceViewResult = await trinoClusterResult.Value.GetInstanceViewAsync().ConfigureAwait(false);

            // Get trino cluster service configurations
            var clusterServiceConfigurations = await trinoClusterResult.Value.GetServiceConfigsAsync().ToEnumerableAsync().ConfigureAwait(false);

            // Delete the trino cluster
            await trinoClusterResult.Value.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task TestSparkCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.2";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Spark";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create spark cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            string userMsiId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/psmsi";
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // spark profile
            string vmSize = "Standard_E8ads_v5";
            int workerCount = 2;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(userMsiId), msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };

            // set saprk profile
            clusterProfile.SparkProfile = new SparkProfile()
            {
                DefaultStorageUriString = "abfs://spark@hilostorage.dfs.core.windows.net",
            };

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);
            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var sparkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);
            Assert.AreEqual(sparkClusterResult.Value.Data.Properties.ClusterProfile.ServiceConfigsProfiles.Count, 0);

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
            Assert.AreEqual(value.Data.Properties.ClusterProfile.ServiceConfigsProfiles.Count, 1);

            // Test set autoscale on spark cluster
            HDInsightClusterPatch autoscalePatch = new HDInsightClusterPatch()
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

            sparkClusterResult = await sparkClusterResult.Value.UpdateAsync(WaitUntil.Completed, autoscalePatch);

            Assert.AreEqual(sparkClusterResult.Value.Data.Properties.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].StartOn, "00:00");
            Assert.AreEqual(sparkClusterResult.Value.Data.Properties.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].EndOn, "12:00");
            Assert.AreEqual(sparkClusterResult.Value.Data.Properties.ClusterProfile.AutoscaleProfile.ScheduleBasedConfig.Schedules[0].Days.Count, 1);

            // Test manage cluster libraries
            ClusterPyPILibraryProperties pyPiLibraryProperties = new ClusterPyPILibraryProperties("pandas");
            List<ClusterLibrary> clusterLibraries = new List<ClusterLibrary> { new ClusterLibrary(pyPiLibraryProperties) };
            ClusterLibraryManagementOperationContent clusterLibraryManagementOperation = new ClusterLibraryManagementOperationContent(new ClusterLibraryManagementOperationProperties(LibraryManagementAction.Install, clusterLibraries));
            ArmOperation armOperation = await sparkClusterResult.Value.ManageLibrariesClusterLibraryAsync(WaitUntil.Completed, clusterLibraryManagementOperation);

            // Test list cluster libraries
            AsyncPageable<ClusterLibrary> asyncPageable = sparkClusterResult.Value.GetClusterLibrariesAsync(ClusterLibraryCategory.Custom);
            await foreach (var lib in asyncPageable)
            {
                Assert.NotNull(lib);
            }
        }

        [RecordedTest]
        public async Task TestFlinkCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.2";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Flink";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create flink cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            string userMsiId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/psmsi";
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // cluster profile
            string vmSize = "Standard_E8ads_v5";
            int workerCount = 5;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(userMsiId), msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };
            // set flink profile
            clusterData.Properties.ClusterProfile.FlinkProfile = new FlinkProfile()
            {
                JobManager = new ComputeResourceRequirement(1, 2000),
                TaskManager = new ComputeResourceRequirement(6, 49016),
                Storage = new FlinkStorageProfile()
                {
                    StorageUriString = "abfs://flink@hilostorage.dfs.core.windows.net"
                }
            };

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);

            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var flinkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);

            ClusterJob clusterJob = new ClusterJob(new FlinkJobProperties()
            {
                JobName = "flink-job-name",
                JobJarDirectory = "abfs://flink-app@hilostorage.dfs.core.windows.net/job-jars",
                JarName = "JobDemo.jar",
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
        public async Task TestKafkaCluster()
        {
            Location = "west us 3";
            string ClusterPoolVersion = "1.2";

            // Call get available cluster pool version API to get the supported versions per cluster type
            string clusterType = "Kafka";
            var clusterVersions = await Subscription.GetAvailableClusterVersionsByLocationAsync(Location).ToEnumerableAsync().ConfigureAwait(false);
            var availableClusterVersionResult = clusterVersions.Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).Where(version => version.Properties.ClusterPoolVersion.Equals(ClusterPoolVersion)).FirstOrDefault();

            // Create spark cluster
            string clusterName = Recording.GenerateAssetName($"sdk-{clusterType}-cluster-");

            string userMsiId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/psmsi";
            string msiClientId = "00000000-0000-0000-0000-000000000000";
            string msiObjectId = "00000000-0000-0000-0000-000000000000";

            // authorization profile
            // my user Id
            var userIds = "00000000-0000-0000-0000-000000000000";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userIds);

            // cluster profile
            string vmSize = "Standard_E8ads_v5";
            int workerCount = 5;
            ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
            ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersionResult.Properties.ClusterVersion, availableClusterVersionResult.Properties.OssVersion, authorizationProfile)
            {
                IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(userMsiId), msiClientId, msiObjectId) }
            };

            var clusterData = new HDInsightClusterData(Location)
            {
                Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
            };
            // set kafka profile
            clusterData.Properties.ClusterProfile.KafkaProfile = new KafkaProfile(new DiskStorageProfile(8,DataDiskType.StandardSsdLrs))
            {
               IsKRaftEnabled = true,
               IsPublicEndpointsEnabled = true,
               RemoteStorageUriString = "abfs://kafka@hilostorage.dfs.core.windows.net/"
            };

            Response<Resources.ResourceGroupResource> RG = await Subscription.GetResourceGroupAsync(resourcesGroupName);

            Response<HDInsightClusterPoolResource> ClusterPool = await RG.Value.GetHDInsightClusterPoolAsync(clusterpoolName);

            var clusterCollection = ClusterPool.Value.GetHDInsightClusters();
            var flinkClusterResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData).ConfigureAwait(false);
        }
    }
}
