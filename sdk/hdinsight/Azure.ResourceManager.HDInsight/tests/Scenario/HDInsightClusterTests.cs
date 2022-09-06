// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class HDInsightClusterTests : HDInsightManagementTestBase
    {
        public HDInsightClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            string containerName = Recording.GenerateAssetName("container");
            var cluster = await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);
            ValidateCluster(cluster);
            Assert.AreEqual(clusterName, cluster.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            string containerName = Recording.GenerateAssetName("container");
            await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);
            bool flag = await resourceGroup.GetHDInsightClusters().ExistsAsync(clusterName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);
            var cluster = await resourceGroup.GetHDInsightClusters().GetAsync(clusterName);
            ValidateCluster(cluster);
            Assert.AreEqual(clusterName, cluster.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);
            var list = await resourceGroup.GetHDInsightClusters().GetAllAsync().ToEnumerableAsync();
            ValidateCluster(list.FirstOrDefault());
            Assert.AreEqual(1, list.Count);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);
            bool flag = await resourceGroup.GetHDInsightClusters().ExistsAsync(clusterName);
            Assert.IsTrue(flag);

            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await resourceGroup.GetHDInsightClusters().ExistsAsync(clusterName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetExtension()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(resourceGroup, storageAccount, clusterName);

            var extension    = await cluster.GetExtensionAsync("azuremonitor");
            Assert.IsNotNull(extension);
            Assert.IsFalse(extension.Value.IsClusterMonitoringEnabled);
            Assert.IsNull(extension.Value.WorkspaceId);
        }

        private void ValidateCluster(HDInsightClusterResource cluster)
        {
            Assert.IsNotNull(cluster);
            Assert.AreEqual(1, cluster.Data.Tags.Count);
            Assert.AreEqual("Linux", cluster.Data.Properties.OSType.ToString());
            Assert.AreEqual(1, cluster.Data.Properties.StorageAccounts.Count);
            Assert.AreEqual("standard", cluster.Data.Properties.Tier.ToString());
            Assert.AreEqual(true, cluster.Data.Properties.IsEncryptionInTransitEnabled);
        }
    }
}
