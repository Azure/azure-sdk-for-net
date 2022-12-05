// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using System.Linq;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.HDInsight.Tests
{
    public class HDInsightManagementTestBase : ManagementRecordedTestBase<HDInsightManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string DefaultResourceGroupPrefix = "HDInsightRG-";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string Common_User = "sshuser5951";
        protected const string Common_Password = "Password!5951";

        protected HDInsightManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HDInsightManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            var input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource resourceGroup, string storageAccountName)
        {
            StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
            StorageKind kind = StorageKind.Storage;
            var location = resourceGroup.Data.Location;
            StorageAccountCreateOrUpdateContent storagedata = new StorageAccountCreateOrUpdateContent(sku, kind, location)
            {
            };
            var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storagedata);
            return storage.Value;
        }

        protected async Task<VirtualNetworkResource> CreateDefaultNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            // Create a NSG
            string nsgName = Recording.GenerateAssetName("ngs");
            var nsgData = new NetworkSecurityGroupData() { Location = resourceGroup.Data.Location, };
            var nsg = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, nsgName, nsgData);

            VirtualNetworkData data = new VirtualNetworkData() {Location = resourceGroup.Data.Location,};
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24", PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Disabled,NetworkSecurityGroup = nsg.Value.Data });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }

        protected async Task<HDInsightClusterResource> CreateDefaultHadoopCluster(ResourceGroupResource resourceGroup, StorageAccountResource storageAccount, string clusterName)
        {
            var properties = await PrepareClusterCreateParams(storageAccount);
            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await resourceGroup.GetHDInsightClusters().CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            return cluster.Value;
        }

        protected async Task<HDInsightClusterCreateOrUpdateProperties> PrepareClusterCreateParams(StorageAccountResource storageAccount)
        {
            string containerName = Recording.GenerateAssetName("container");
            string accessKey = (await storageAccount.GetKeysAsync().ToEnumerableAsync()).FirstOrDefault().Value;
            await storageAccount.GetBlobService().GetBlobContainers().CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData());
            string clusterDeifnitionConfigurations = "{         \"gateway\": {             \"restAuthCredential.isEnabled\": \"true\",             \"restAuthCredential.username\": \"admin4468\",             \"restAuthCredential.password\": \"Password1!9688\"         }     } ";
            var properties = new HDInsightClusterCreateOrUpdateProperties()
            {
                ClusterVersion = "3.6",
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
                HardwareVmSize = "Large",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "workernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "Large",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "zookeepernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "Small",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = Common_User,
                    Password = Common_Password
                }
            });
            properties.StorageAccounts.Add(new HDInsightStorageAccountInfo()
            {
                Name = $"{storageAccount.Data.Name}.blob.core.windows.net",
                IsDefault = true,
                Container = containerName,
                Key = accessKey,
            });
            return properties;
        }
    }
}
