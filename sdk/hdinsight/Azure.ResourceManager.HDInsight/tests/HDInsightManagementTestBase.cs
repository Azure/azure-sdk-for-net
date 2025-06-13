// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    public class HDInsightManagementTestBase : ManagementRecordedTestBase<HDInsightManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string DefaultResourceGroupPrefix = "HDInsightRG-";
        protected AzureLocation DefaultLocation = AzureLocation.EastAsia;
        protected const string Common_User = "sshusername";
        protected const string Common_Password = "ValidPassword";
        protected const string Common_VNet_Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-ps-test/providers/Microsoft.Network/virtualNetworks/hditestvnet";
        protected const string Common_SubNet = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-ps-test/providers/Microsoft.Network/virtualNetworks/hditestvnet/subnets/default";
        protected HDInsightManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..key");
        }

        protected HDInsightManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..key");
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgName)
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<string> CreateStorageResources(ResourceGroupResource resourceGroup, string storageAccountName, string containerName)
        {
            StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
            StorageKind kind = StorageKind.Storage;
            var location = DefaultLocation;
            StorageAccountCreateOrUpdateContent storagedata = new StorageAccountCreateOrUpdateContent(sku, kind, location);
            var lro = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storagedata);
            var storageAccount = lro.Value;
            await storageAccount.GetBlobService().GetBlobContainers().CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData());
            return (await storageAccount.GetKeysAsync().ToEnumerableAsync()).FirstOrDefault().Value;
        }

        protected async Task<HDInsightClusterResource> CreateDefaultHadoopCluster(ResourceGroupResource resourceGroup, string clusterName, string storageAccountName, string containerName, string accessKey)
        {
            var properties = PrepareClusterCreateParams(storageAccountName, containerName, accessKey);
            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = DefaultLocation,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await resourceGroup.GetHDInsightClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            return cluster.Value;
        }

        protected HDInsightClusterCreateOrUpdateProperties PrepareClusterCreateParams(string storageAccountName, string containerName, string accessKey)
        {
            string clusterDeifnitionConfigurations = "{         \"gateway\": {             \"restAuthCredential.isEnabled\": \"true\",             \"restAuthCredential.username\": \"admin\",             \"restAuthCredential.password\": \"Password\"         }     } ";
            var properties = new HDInsightClusterCreateOrUpdateProperties()
            {
                ClusterVersion = "4.0",
                OSType = HDInsightOSType.Linux,
                Tier = HDInsightTier.Standard,
                ClusterDefinition = new HDInsightClusterDefinition()
                {
                    Kind = "Hadoop",
                    Configurations = new BinaryData(clusterDeifnitionConfigurations),
                },
                IsEncryptionInTransitEnabled = true,
            };
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "headnode",
                TargetInstanceCount = 2,
                HardwareVmSize = "standard_e8_v3",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                },
                VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = new ResourceIdentifier(Common_VNet_Id),
                    Subnet = Common_SubNet
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "workernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "standard_e8_v3",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                },
                VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = new ResourceIdentifier(Common_VNet_Id),
                    Subnet = Common_SubNet
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "zookeepernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "standard_a2_v2",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                },
                VirtualNetworkProfile = new HDInsightVirtualNetworkProfile()
                {
                    Id = new ResourceIdentifier(Common_VNet_Id),
                    Subnet = Common_SubNet
                }
            });
            properties.StorageAccounts.Add(new HDInsightStorageAccountInfo()
            {
                Name = $"{storageAccountName}.blob.core.windows.net",
                IsDefault = true,
                Container = containerName,
                Key = accessKey,
            });
            return properties;
        }
    }
}
