// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
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
            _clusterName = Recording.GenerateAssetName("hdi");
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
            Assert.That(cluster.Data.Name, Is.EqualTo(_clusterName));
        }

        [RecordedTest]
        public async Task Exist()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            bool flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            var cluster = await _clusterCollection.GetAsync(_clusterName);
            ValidateCluster(cluster);
            Assert.That(cluster.Value.Data.Name, Is.EqualTo(_clusterName));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            var list = await _clusterCollection.GetAllAsync().ToEnumerableAsync();
            ValidateCluster(list.FirstOrDefault());
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [RecordedTest]
        public async Task Delete()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            bool flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.That(flag, Is.True);

            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.That(flag, Is.False);
        }

        [RecordedTest]
        public async Task GetExtension()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);

            var extension = await cluster.GetExtensionAsync("azuremonitor");
            Assert.IsNotNull(extension);
            Assert.That(extension.Value.IsClusterMonitoringEnabled, Is.False);
            Assert.IsNull(extension.Value.WorkspaceId);
        }

        [RecordedTest]
        public async Task AddTagTest()
        {
            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);
            await cluster.AddTagAsync("addtagkey", "addtagvalue");

            cluster = await _clusterCollection.GetAsync(_clusterName);
            KeyValuePair<string, string> tag = cluster.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
        }

        [RecordedTest]
        public async Task UpdateManagedIdentity()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/hdi-ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-test-msi");
            ResourceIdentifier resourceIdentifier2 = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/hdi-ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-test-msi2");

            var cluster = await CreateDefaultHadoopCluster(_resourceGroup, _clusterName, _storageAccountName, _containerName, _accessKey);

            HDInsightClusterPatch patch = new HDInsightClusterPatch();
            //patch.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            //await cluster.UpdateAsync(patch);

            //cluster = await _clusterCollection.GetAsync(_clusterName);
            //Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, cluster.Data.Identity.ManagedServiceIdentityType);

            //patch.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            //patch.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(resourceIdentifier), new UserAssignedIdentity());
            //await cluster.UpdateAsync(patch);

            //cluster = await _clusterCollection.GetAsync(_clusterName);
            //Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, cluster.Data.Identity.ManagedServiceIdentityType);
            //Assert.AreEqual(resourceIdentifier, cluster.Data.Identity.UserAssignedIdentities.First().Key);

            patch.Identity = new ManagedServiceIdentity("SystemAssigned,UserAssigned");
            patch.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(resourceIdentifier), new UserAssignedIdentity());
            patch.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(resourceIdentifier2), new UserAssignedIdentity());
            await cluster.UpdateAsync(patch);

            cluster = await _clusterCollection.GetAsync(_clusterName);
            Assert.That(cluster.Data.Identity.ManagedServiceIdentityType.ToString(), Is.EqualTo("SystemAssigned,UserAssigned"));
            Assert.That(cluster.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(2));
        }
        private void ValidateCluster(HDInsightClusterResource cluster)
        {
            Assert.IsNotNull(cluster);
            Assert.That(cluster.Data.Tags.Count, Is.EqualTo(1));
            Assert.That(cluster.Data.Properties.OSType.ToString(), Is.EqualTo("Linux"));
            Assert.That(cluster.Data.Properties.StorageAccounts.Count, Is.EqualTo(1));
            Assert.That(cluster.Data.Properties.Tier.ToString(), Is.EqualTo("standard"));
            Assert.That(cluster.Data.Properties.IsEncryptionInTransitEnabled, Is.EqualTo(true));
        }
    }
}
