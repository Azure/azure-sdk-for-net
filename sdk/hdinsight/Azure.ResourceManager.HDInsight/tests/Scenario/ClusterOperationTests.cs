// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class ClusterOperationTests : HDInsightManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _storageAccountName, _containerName, _accessKey, _vnetName;
        private HDInsightClusterCollection _clusterCollection => _resourceGroup.GetHDInsightClusters();

        public ClusterOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            _storageAccountName = Recording.GenerateAssetName("azstorageforcluster");
            _containerName = Recording.GenerateAssetName("container");
            _vnetName = Recording.GenerateAssetName("vnet");
            _resourceGroup = await CreateResourceGroup(rgName);
            if (Mode == RecordedTestMode.Playback)
            {
                _accessKey = "Sanitized";
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    _accessKey = await CreateStorageResources(_resourceGroup, _storageAccountName, _containerName);
                }
            }
        }

        private async Task<Tuple<ResourceIdentifier, ResourceIdentifier>> CreateDefaultNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            ResourceIdentifier vnetIdentifier, subnetIdentifier;
            if (Mode == RecordedTestMode.Playback)
            {
                vnetIdentifier = VirtualNetworkResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName);
                subnetIdentifier = SubnetResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName, "subnet1");
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    // Create a NSG
                    var nsgData = new NetworkSecurityGroupData() { Location = DefaultLocation, };
                    var nsg = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, "nsg", nsgData);

                    VirtualNetworkData data = new VirtualNetworkData() { Location = DefaultLocation, };
                    data.AddressPrefixes.Add("10.10.0.0/16");
                    data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24", PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Disabled, NetworkSecurityGroup = nsg.Value.Data });
                    data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
                    var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
                    vnetIdentifier = vnet.Value.Id;
                    subnetIdentifier = vnet.Value.Data.Subnets.FirstOrDefault().Id;
                }
            }
            return Tuple.Create(vnetIdentifier, subnetIdentifier);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithAutoScaleLoadBasedType()
        {
            string clusterName = "hdisdk-loadbased";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
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
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(4, cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Capacity.MinInstanceCount);
            Assert.AreEqual(5, cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Capacity.MaxInstanceCount);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithAutoScaleScheduleBasedType()
        {
            string clusterName = "hdisdk-schedulebased";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
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
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual("China Standard Time", cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Recurrence.TimeZone);
            Assert.AreEqual("16:00", cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Recurrence.Schedule.FirstOrDefault().TimeAndCapacity.Time);
            Assert.AreEqual(4, cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Recurrence.Schedule.FirstOrDefault().TimeAndCapacity.MaxInstanceCount);
            Assert.AreEqual(4, cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("workernode")).AutoScaleConfiguration.Recurrence.Schedule.FirstOrDefault().TimeAndCapacity.MinInstanceCount);
        }

        [RecordedTest]
        [Ignore("DeploymentDocument 'OozieConfigurationValidator' failed the validation")]
        public async Task TestCreateClusterWithAvailabilityZones()
        {
            string clusterName = "hdisdk-az";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            var workerNode = properties.ComputeRoles.First(role => role.Name.Equals("workernode"));
            properties.ClusterDefinition.Kind = "Spark";
            properties.ClusterVersion = "4.0";

            // availability zones requires custom vnet
            var vnetInfo = await CreateDefaultNetwork(_resourceGroup, _vnetName);
            foreach (var role in properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnetInfo.Item1,
                    Subnet = vnetInfo.Item2.ToString(),
                };
            }

            // availability zones requires custom metastore: ambari, hive,oozie
            string content = File.ReadAllText(@"TestData/ClusterWithAvailabilityZonesSqlDefinition.json");
            properties.ClusterDefinition.Configurations = new BinaryData(content);

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            // set zones
            data.Zones.Add("1");
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithEncryptionAtHost()
        {
            string clusterName = "hdisdk-encryptionathost";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.ClusterDefinition.Kind = "Spark";
            properties.ComputeProfile.Roles.ToList().ForEach(role => role.HardwareProfile.VmSize = "Standard_DS14_v2");
            properties.DiskEncryptionProperties = new HDInsightDiskEncryptionProperties()
            {
                IsEncryptionAtHostEnabled = true
            };

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual("Spark", cluster.Value.Data.Properties.ClusterDefinition.Kind);
            Assert.AreEqual("standard_ds14_v2", cluster.Value.Data.Properties.ComputeRoles.FirstOrDefault().HardwareVmSize);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithEncryptionInTransit()
        {
            string clusterName = "hdisdk-encryption-intransit";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.ClusterDefinition.Kind = "Spark";
            properties.IsEncryptionInTransitEnabled = true;

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual("Spark", cluster.Value.Data.Properties.ClusterDefinition.Kind);
            Assert.AreEqual(true, cluster.Value.Data.Properties.IsEncryptionInTransitEnabled);
        }

        [RecordedTest]
        [Ignore("200: Azure.RequestFailedException : Internal server error occurred while processing the request")]
        public async Task TestCreateClusterWithOutboundAndPrivateLink()
        {
            string clusterName = "hdisdk-outbounprivatelink";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.StorageAccounts.FirstOrDefault().ResourceId = StorageAccountResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, _storageAccountName);
            properties.NetworkProperties = new HDInsightClusterNetworkProperties()
            {
                ResourceProviderConnection = HDInsightResourceProviderConnection.Outbound,
                PrivateLink = HDInsightPrivateLinkState.Enabled
            };

            var vnetInfo = await CreateDefaultNetwork(_resourceGroup, _vnetName);
            foreach (var role in properties.ComputeRoles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnetInfo.Item1,
                    Subnet = vnetInfo.Item2.ToString()
                };
            }

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        [Ignore("200: Azure.RequestFailedException : Internal server error occurred while processing the request")]
        public async Task TestCreateClusterWithPrivateLinkConfiguration()
        {
            string clusterName = "hdisdk-privatelinkconfig";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.NetworkProperties = new HDInsightClusterNetworkProperties()
            {
                ResourceProviderConnection = HDInsightResourceProviderConnection.Outbound,
                PrivateLink = HDInsightPrivateLinkState.Enabled
            };
            properties.StorageAccounts.FirstOrDefault().ResourceId = StorageAccountResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, _storageAccountName);

            var vnetInfo = await CreateDefaultNetwork(_resourceGroup, _vnetName);
            foreach (var role in properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = vnetInfo.Item1,
                    Subnet = vnetInfo.Item2.ToString()
                };
            }
            var ipConfigurations = new List<HDInsightIPConfiguration> { new HDInsightIPConfiguration("ipconfig") { IsPrimary = true, } };
            properties.PrivateLinkConfigurations.Add(new HDInsightPrivateLinkConfiguration("plconfig", "headnode", ipConfigurations));

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateClusterWithTLS12()
        {
            string clusterName = "hdisdk-tls12";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.MinSupportedTlsVersion = "1.2";

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual("Hadoop", cluster.Value.Data.Properties.ClusterDefinition.Kind);
            Assert.AreEqual("1.2", cluster.Value.Data.Properties.MinSupportedTlsVersion);
        }

        [RecordedTest]
        [Ignore("200: Internal server error occurred while processing the request")]
        public async Task TestCreateHumboldtCluster()
        {
            string clusterName = "hdisdk-humboldt";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateHumboldtClusterWithCustomVMSizes()
        {
            string clusterName = "hdisdk-customvmsizes";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);

            var headNode = properties.ComputeRoles.First(role => role.Name == "headnode");
            var zookeeperNode = properties.ComputeRoles.First(role => role.Name == "zookeepernode");
            headNode.HardwareProfile.VmSize = "ExtraLarge";
            zookeeperNode.HardwareProfile.VmSize = "Medium";

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual("Hadoop", cluster.Value.Data.Properties.ClusterDefinition.Kind);
            Assert.AreEqual("standard_a8_v2", cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("headnode")).HardwareProfile.VmSize);
            Assert.AreEqual("standard_a2_v2", cluster.Value.Data.Properties.ComputeRoles.First(role => role.Name.Equals("zookeepernode")).HardwareProfile.VmSize);
        }

        [RecordedTest]
        [Ignore("Premium Cluster only available for ESP cluster.")]
        public async Task TestCreateHumboldtClusterWithPremiumTier()
        {
            string clusterName = "hdisdk-premium";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.Tier = HDInsightTier.Premium;

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateLinuxSparkClusterWithComponentVersion()
        {
            string clusterName = "hdisdk-sparkcomponentversions";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.ClusterDefinition.Kind = "Spark";
            properties.IsEncryptionInTransitEnabled = false;
            properties.ClusterDefinition.ComponentVersion.Add(new KeyValuePair<string, string>("Spark", "2.4"));

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(clusterName, cluster.Value.Data.Name);
            Assert.AreEqual("Spark", cluster.Value.Data.Properties.ClusterDefinition.Kind);
            Assert.AreEqual(false, cluster.Value.Data.Properties.IsEncryptionInTransitEnabled);
        }

        [RecordedTest]
        [Ignore("HDI 4.0 doesn't support create MLServices cluster and 3.6 will be deprecated soon.")]
        public async Task TestCreateMLServicesCluster()
        {
            string clusterName = "hdisdk-mlservices";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.ClusterDefinition.Kind = "MLServices";
            properties.ClusterVersion = "4.0";
            properties.ComputeProfile.Roles.Add(new HDInsightClusterRole()
            {
                Name = "edgenode",
                TargetInstanceCount = 1,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Standard_D4_v2"
                },
                OSProfile = new OSProfile()
                {
                    LinuxProfile = new HDInsightLinuxOSProfile()
                    {
                        Username = Common_User,
                        Password = Common_Password
                    }
                }
            });

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        [Ignore("HDI 4.0 doesn't support create MLServices cluster and 3.6 will be deprecated soon.")]
        public async Task TestCreateRServerCluster()
        {
            string clusterName = "hdisdk-rserver";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            properties.ClusterDefinition.Kind = "RServer";
            properties.ClusterDefinition.ComponentVersion.Add(new KeyValuePair<string, string>("RServer", "9.3"));
            properties.ComputeProfile.Roles.Add(new HDInsightClusterRole()
            {
                Name = "edgenode",
                TargetInstanceCount = 1,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Standard_D4_v2"
                },
                OSProfile = new OSProfile()
                {
                    LinuxProfile = new HDInsightLinuxOSProfile()
                    {
                        Username = Common_User,
                        Password = Common_Password
                    }
                }
            });

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public async Task TestCreateWithAdditionalStorageAccount()
        {
            string clusterName = "hdisdk-additional";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);

            // Add additional storage account
            string secondaryStorageAccountName = _storageAccountName + "2";
            string containerName = _containerName + "2";
            string accessKey = "Sanitized";
            if (Mode != RecordedTestMode.Playback)
            {
                using (Recording.DisableRecording())
                {
                    accessKey = await CreateStorageResources(_resourceGroup, secondaryStorageAccountName, containerName);
                }
            }

            properties.StorageAccounts.Add(new HDInsightStorageAccountInfo()
            {
                Name = $"{secondaryStorageAccountName}.blob.core.windows.net",
                IsDefault = false,
                Container = containerName,
                Key = accessKey,
            });

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(clusterName, cluster.Value.Data.Name);
            Assert.AreEqual(2, cluster.Value.Data.Properties.StorageAccounts.Count);
            Assert.AreEqual($"{_storageAccountName}.blob.core.windows.net", cluster.Value.Data.Properties.StorageAccounts.First(item => item.IsDefault == true).Name);
            Assert.AreEqual($"{secondaryStorageAccountName}.blob.core.windows.net", cluster.Value.Data.Properties.StorageAccounts.First(item => item.IsDefault == false).Name);
        }

        [RecordedTest]
        [Ignore("Higher permissions required")]
        public async Task TestCreateWithADLSv1()
        {
            string clusterName = "hdisdk-adlgen1";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);

            // TODO: Add data lake properties

            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);
        }

        [RecordedTest]
        public void TestCreateWithEmptyExtendedParameters()
        {
            string clusterName = "hdisdk-empty";
            var data = new HDInsightClusterCreateOrUpdateContent()
            {
            };
            Assert.ThrowsAsync<RequestFailedException>(() => _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data));
        }

        [RecordedTest]
        public async Task TestGetOrUpdateGatewaySettings()
        {
            string clusterName = "hdisdk-gateway";
            var properties = PrepareClusterCreateParams(_storageAccountName, _containerName, _accessKey);
            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.IsNotNull(cluster);

            var gatewaySetting = await cluster.Value.GetGatewaySettingsAsync();
            Assert.AreEqual("admin4468", gatewaySetting.Value.UserName);
            Assert.AreEqual("Password1!9688", gatewaySetting.Value.Password);
        }
    }
}
