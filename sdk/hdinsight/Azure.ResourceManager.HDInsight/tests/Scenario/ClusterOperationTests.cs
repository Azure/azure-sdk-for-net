// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class ClusterOperationTests : HDInsightManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private HDInsightClusterCollection _clusterCollection => _resourceGroup.GetHDInsightClusters();

        public ClusterOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _storageAccount = await CreateStorageAccount(_resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
        }

        [RecordedTest]
        public async Task TestCreateClusterWithAutoScaleLoadBasedType()
        {
            string clusterName = "hdisdk-loadbased";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            var workerNode = properties.ComputeRoles.First(role => role.Name.Equals("workernode"));

            //Add auto scale configuration Load-based type
            workerNode.AutoScaleConfiguration = new HDInsightAutoScaleConfiguration()
            {
                Capacity = new HDInsightAutoScaleCapacity()
                {
                    MinInstanceCount = 4,
                    MaxInstanceCount = 5
                }
            };

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            //Assert.AreEqual(4,cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Capacity.MinInstanceCount);
            //Assert.AreEqual(5, cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Capacity.MaxInstanceCount);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithAutoScaleScheduleBasedType()
        {
            string clusterName = "hdisdk-schedulebased";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            var workerNode = properties.ComputeRoles.First(role => role.Name.Equals("workernode"));

            //Add auto scale configuration.
            workerNode.AutoScaleConfiguration = new HDInsightAutoScaleConfiguration()
            {
                Recurrence = new HDInsightAutoScaleRecurrence()
                {
                    //"China Standard Time", "Central Standard Time","Central American Standard Time"
                    TimeZone = "China Standard Time",
                }
            };
            var timeAndCapacity = new HDInsightAutoScaleSchedule()
            {
                TimeAndCapacity = new HDInsightAutoScaleTimeAndCapacity()
                {
                    Time = "16:00",
                    MinInstanceCount = 4,
                    MaxInstanceCount = 4
                },
            };
            timeAndCapacity.Days.Add(HDInsightDayOfWeek.Thursday);
            workerNode.AutoScaleConfiguration.Recurrence.Schedule.Add(timeAndCapacity);

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        [Ignore("DeploymentDocument 'OozieConfigurationValidator' failed the validation")]
        public async Task TestCreateClusterWithAvailabilityZones()
        {
            string clusterName = "hdisdk-az";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            var workerNode = properties.ComputeRoles.First(role => role.Name.Equals("workernode"));
            properties.ClusterDefinition.Kind = "Spark";
            properties.ClusterVersion = "4.0";

            // availability zones requires custom vnet
            string vnetName = Recording.GenerateAssetName("vnet");
            var vnet = await CreateDefaultNetwork(_resourceGroup, vnetName);
            foreach (var role in properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnet.Data.Id,
                    Subnet = vnet.Data.Subnets.FirstOrDefault().Id.ToString(),
                };
            }

            // availability zones requires custom metastore: ambari, hive,oozie
            string content = File.ReadAllText(@"TestData/ClusterWithAvailabilityZonesSqlDefinition.json");
            properties.ClusterDefinition.Configurations = new BinaryData(content);

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            // set zones
            data.Zones.Add("1");
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithEncryptionAtHost()
        {
            string clusterName = "hdisdk-encryptionathost";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.ClusterDefinition.Kind = "Spark";
            properties.ComputeProfile.Roles.ToList().ForEach(role => role.HardwareProfile.VmSize = "Standard_DS14_v2");
            properties.DiskEncryptionProperties = new HDInsightDiskEncryptionProperties()
            {
                IsEncryptionAtHostEnabled = true
            };

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithEncryptionInTransit()
        {
            string clusterName = "hdisdk-encryption";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.ClusterDefinition.Kind = "Spark";
            properties.EncryptionInTransitProperties = new EncryptionInTransitProperties()
            {
                IsEncryptionInTransitEnabled = true
            };

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithOutboundAndPrivateLink()
        {
            string clusterName = "hdisdk-outboundpl";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.NetworkProperties = new HDInsightClusterNetworkProperties()
            {
                ResourceProviderConnection = HDInsightResourceProviderConnection.Outbound,
                PrivateLink = HDInsightPrivateLinkState.Enabled
            };

            string vnetName = Recording.GenerateAssetName("vnet");
            var vnet = await CreateDefaultNetwork(_resourceGroup, vnetName);
            foreach (var role in properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnet.Data.Id,
                    Subnet = vnet.Data.Subnets.FirstOrDefault().Id.ToString()
                };
            }

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithPrivateLinkConfiguration()
        {
            string clusterName = "hdisdk-outboundpl";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.NetworkProperties = new HDInsightClusterNetworkProperties()
            {
                ResourceProviderConnection = HDInsightResourceProviderConnection.Outbound,
                PrivateLink = HDInsightPrivateLinkState.Enabled
            };

            string vnetName = Recording.GenerateAssetName("vnet");
            var vnet = await CreateDefaultNetwork(_resourceGroup, vnetName);
            foreach (var role in properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnet.Data.Id,
                    Subnet = vnet.Data.Subnets.FirstOrDefault().Id.ToString()
                };
            }
            var ipConfigurations = new List<HDInsightIPConfiguration> { new HDInsightIPConfiguration("ipconfig") { IsPrimary = true, } };
            properties.PrivateLinkConfigurations.Add(new HDInsightPrivateLinkConfiguration("plconfig", "headnode", ipConfigurations));

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithTLS12()
        {
            string clusterName = "hdisdk-tls12";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.MinSupportedTlsVersion = "1.2";

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateHumboldtCluster()
        {
            string clusterName = "hdisdk-humboldt";
            var properties = await PrepareClusterCreateParams(_storageAccount);

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateHumboldtClusterWithCustomVMSizes()
        {
            string clusterName = "hdisdk-customvmsizes";
            var properties = await PrepareClusterCreateParams(_storageAccount);

            var headNode = properties.ComputeRoles.First(role => role.Name == "headnode");
            var zookeeperNode = properties.ComputeRoles.First(role => role.Name == "zookeepernode");
            headNode.HardwareProfile.VmSize = "ExtraLarge";
            zookeeperNode.HardwareProfile.VmSize = "Medium";

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        [Ignore("Premium Cluster only available for ESP cluster.")]
        public async Task TestCreateHumboldtClusterWithPremiumTier()
        {
            string clusterName = "hdisdk-premium";
            var properties = await PrepareClusterCreateParams(_storageAccount);
            properties.Tier = HDInsightTier.Premium;

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = _resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }
    }
}
