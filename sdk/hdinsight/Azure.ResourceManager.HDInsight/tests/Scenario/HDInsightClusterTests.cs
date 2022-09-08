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
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class HDInsightClusterTests : HDInsightManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private HDInsightClusterCollection _clusterCollection => _resourceGroup.GetHDInsightClusters();

        public HDInsightClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _storageAccount = await CreateStorageAccount(_resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            ValidateCluster(cluster);
            Assert.AreEqual(clusterName, cluster.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            bool flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            var cluster = await _clusterCollection.GetAsync(clusterName);
            ValidateCluster(cluster);
            Assert.AreEqual(clusterName, cluster.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            var list = await _clusterCollection.GetAllAsync().ToEnumerableAsync();
            ValidateCluster(list.FirstOrDefault());
            Assert.AreEqual(1, list.Count);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            bool flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(flag);

            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetExtension()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);

            var extension = await cluster.GetExtensionAsync("azuremonitor");
            Assert.IsNotNull(extension);
            Assert.IsFalse(extension.Value.IsClusterMonitoringEnabled);
            Assert.IsNull(extension.Value.WorkspaceId);
        }

        [RecordedTest]
        public async Task AddTagTest()
        {
            string clusterName = Recording.GenerateAssetName("cluster");
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _storageAccount, clusterName);
            await cluster.AddTagAsync("addtagkey", "addtagvalue");

            cluster = await _clusterCollection.GetAsync(clusterName);
            KeyValuePair<string, string> tag = cluster.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);
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
