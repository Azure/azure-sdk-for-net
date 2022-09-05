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

namespace Azure.ResourceManager.HDInsight.Tests
{
    public class HDInsightManagementTestBase : ManagementRecordedTestBase<HDInsightManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string DefaultResourceGroupPrefix = "HDInsightRG-";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

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

        protected async Task<HDInsightClusterResource> CreateCluster(ResourceGroupResource resourceGroup, StorageAccountResource storageAccount, string clusterName, string containerName)
        {
            var container = await storageAccount.GetBlobService().GetBlobContainers().CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData());
            string key = (await storageAccount.GetKeysAsync().ToEnumerableAsync()).FirstOrDefault().Value;
            string common_user = "sshuser5951";
            string common_passwork = "Password!5951";
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
                    Username = common_user,
                    Password = common_passwork
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "workernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "Large",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = common_user,
                    Password = common_passwork
                }
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "zookeepernode",
                TargetInstanceCount = 3,
                HardwareVmSize = "Small",
                OSLinuxProfile = new HDInsightLinuxOSProfile()
                {
                    Username = common_user,
                    Password = common_passwork
                }
            });
            properties.StorageAccounts.Add(new HDInsightStorageAccountInfo()
            {
                Name = $"{storageAccount.Data.Name}.blob.core.windows.net",
                IsDefault = true,
                Container = container.Value.Data.Name,
                Key = key,
            });
            var data = new HDInsightClusterCreateOrUpdateContent()
            {
                Properties = properties,
                Location = resourceGroup.Data.Location,
            };
            data.Tags.Add(new KeyValuePair<string, string>("key0", "value0"));
            var cluster = await resourceGroup.GetHDInsightClusters().CreateOrUpdateAsync(Azure.WaitUntil.Completed, clusterName, data);
            return cluster.Value;
        }
    }
}
