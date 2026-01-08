// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagedServiceTests : ServiceFabricManagedClustersManagementTestBase
    {
        private const string _clusterNamePrefix = "sfmctest";
        private ResourceGroupResource _resourceGroup;
        private ServiceFabricManagedClusterCollection _clusterCollection;
        public ServiceFabricManagedServiceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroup();
            _clusterCollection = _resourceGroup.GetServiceFabricManagedClusters();
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string clusterName = Recording.GenerateAssetName(_clusterNamePrefix);
            var cluster = await CreateServiceFabricManagedCluster(_resourceGroup, clusterName);
            ValidatePurviewAccount(cluster.Data, clusterName);

            // Exist
            var flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.That((bool)flag, Is.True);

            // Get
            var getCluster = await _clusterCollection.GetAsync(clusterName);
            ValidatePurviewAccount(getCluster.Value.Data, clusterName);

            // GetAll
            var list = await _clusterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidatePurviewAccount(list.FirstOrDefault().Data, clusterName);

            // Delete
            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.That((bool)flag, Is.False);
        }

        [TestCase(true)]  // api-version '2022-09-01' is not support
        [TestCase(null)]  // api-version '2022-09-01' is not support
        [TestCase(false)] // Azure.RequestFailedException: 'Service request failed. Status: 202 (Accepted)
        [Ignore("All update methods failed")]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string clusterName = Recording.GenerateAssetName(_clusterNamePrefix);
            var cluster = await CreateServiceFabricManagedCluster(_resourceGroup, clusterName);

            // AddTag
            await cluster.AddTagAsync("addtagkey", "addtagvalue");
            cluster = await _clusterCollection.GetAsync(clusterName);
            Assert.That(cluster.Data.Tags, Has.Count.EqualTo(1));
            KeyValuePair<string, string> tag = cluster.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(tag.Key, Is.EqualTo("addtagkey"));
                Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
            });

            // RemoveTag
            await cluster.RemoveTagAsync("addtagkey");
            cluster = await _clusterCollection.GetAsync(clusterName);
            Assert.That(cluster.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidatePurviewAccount(ServiceFabricManagedClusterData cluster, string clusterName)
        {
            Assert.Multiple(() =>
            {
                Assert.That(cluster, Is.Not.Null);
                Assert.That((string)cluster.Id, Is.Not.Empty);
            });
            Assert.That(cluster.Name, Is.EqualTo(clusterName));
            Assert.That(cluster.Location, Is.EqualTo(DefaultLocation));
            Assert.That(cluster.ClientConnectionPort, Is.EqualTo(19000));
            Assert.That(cluster.HttpGatewayConnectionPort, Is.EqualTo(19080));
            Assert.That(cluster.ClusterUpgradeMode, Is.EqualTo(ManagedClusterUpgradeMode.Automatic));
            Assert.That(cluster.HasZoneResiliency, Is.EqualTo(false));
            Assert.That(cluster.AdminUserName, Is.EqualTo("vmadmin"));
        }
    }
}
