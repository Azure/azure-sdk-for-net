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
        private string _storageAccountName, _containerName, _accessKey, _clusterName;
        private HDInsightClusterCollection _clusterCollection => _resourceGroup.GetHDInsightClusters();

        public HDInsightClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            _storageAccountName = Recording.GenerateAssetName("azstorageforcluster");
            _containerName = Recording.GenerateAssetName("container");
            _clusterName = Recording.GenerateAssetName("cluster");
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

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            ValidateCluster(cluster);
            Assert.AreEqual(_clusterName, cluster.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            bool flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            var cluster = await _clusterCollection.GetAsync(_clusterName);
            ValidateCluster(cluster);
            Assert.AreEqual(_clusterName, cluster.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            var list = await _clusterCollection.GetAllAsync().ToEnumerableAsync();
            ValidateCluster(list.FirstOrDefault());
            Assert.AreEqual(1, list.Count);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            bool flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.IsTrue(flag);

            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetExtension()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);

            var extension = await cluster.GetExtensionAsync("azuremonitor");
            Assert.IsNotNull(extension);
            Assert.IsFalse(extension.Value.IsClusterMonitoringEnabled);
            Assert.IsNull(extension.Value.WorkspaceId);
        }

        [RecordedTest]
        public async Task AddTagTest()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            await cluster.AddTagAsync("addtagkey", "addtagvalue");

            cluster = await _clusterCollection.GetAsync(_clusterName);
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
