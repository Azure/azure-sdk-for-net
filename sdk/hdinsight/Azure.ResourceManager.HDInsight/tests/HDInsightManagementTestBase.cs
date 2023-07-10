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
            string clusterDeifnitionConfigurations = "{         \"gateway\": {             \"restAuthCredential.isEnabled\": \"true\",             \"restAuthCredential.username\": \"admin4468\",             \"restAuthCredential.password\": \"Password1!9688\"         }     } ";
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
                Name = $"{storageAccountName}.blob.core.windows.net",
                IsDefault = true,
                Container = containerName,
                Key = accessKey,
            });
            return properties;
        }
    }
}
