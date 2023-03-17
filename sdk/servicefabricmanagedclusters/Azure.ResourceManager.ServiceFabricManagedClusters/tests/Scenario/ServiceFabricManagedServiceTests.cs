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

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests.Scenario
{
    internal class ServiceFabricManagedServiceTests : ServiceFabricManagedClustersManagementTestBase
    {
        private const string _clusterNamePrefix = "sfmctest";
        private ResourceGroupResource _resourceGroup;
        private ServiceFabricManagedClusterCollection _clusterCollection;
        public ServiceFabricManagedServiceTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroup();
            _clusterCollection = _resourceGroup.GetServiceFabricManagedClusters();
        }

        //[RecordedTest]
        //public async Task Update()
        //{
        //    // CreateOrUpdate
        //    string clusterName = Recording.GenerateAssetName(_clusterNamePrefix);
        //    var cluster = await CreateServiceFabricManagedCluster(_resourceGroup, clusterName);
        //    ValidatePurviewAccount(cluster.Data, clusterName);

        //    var patch = new ServiceFabricManagedClusterPatch()
        //    {
        //        Tags =
        //        {
        //            new KeyValuePair<string, string>("key1","value1"),
        //            new KeyValuePair<string, string>("key2","value2"),
        //        }
        //    };
        //    var response = await cluster.UpdateAsync(patch);
        //}

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string clusterName = Recording.GenerateAssetName(_clusterNamePrefix);
            var cluster = await CreateServiceFabricManagedCluster(_resourceGroup, clusterName);
            ValidatePurviewAccount(cluster.Data, clusterName);

            // Exist
            var flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(flag);

            // Get
            var getCluster = await _clusterCollection.GetAsync(clusterName);
            ValidatePurviewAccount(getCluster.Value.Data, clusterName);

            // GetAll
            var list = await _clusterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePurviewAccount(list.FirstOrDefault().Data, clusterName);

            // Delete
            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsFalse(flag);
        }

        [TestCase(true)]  // api-version '2022-09-01' is not support
        [TestCase(null)]  // api-version '2022-09-01' is not support
        [TestCase(false)] // Azure.RequestFailedException: 'Service request failed. Status: 202 (Accepted)
        [Ignore("Both update methods failed")]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string clusterName = Recording.GenerateAssetName(_clusterNamePrefix);
            var cluster = await CreateServiceFabricManagedCluster(_resourceGroup, clusterName);

            // AddTag
            await cluster.AddTagAsync("addtagkey", "addtagvalue");
            cluster = await _clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(1, cluster.Data.Tags.Count);
            KeyValuePair<string, string> tag = cluster.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await cluster.RemoveTagAsync("addtagkey");
            cluster = await _clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(0, cluster.Data.Tags.Count);
        }

        private void ValidatePurviewAccount(ServiceFabricManagedClusterData cluster, string clusterName)
        {
            Assert.IsNotNull(cluster);
            Assert.IsNotEmpty(cluster.Id);
            Assert.AreEqual(clusterName, cluster.Name);
            Assert.AreEqual(DefaultLocation, cluster.Location);
            Assert.AreEqual(19000, cluster.ClientConnectionPort);
            Assert.AreEqual(19080, cluster.HttpGatewayConnectionPort);
            Assert.AreEqual(ManagedClusterUpgradeMode.Automatic, cluster.ClusterUpgradeMode);
            Assert.AreEqual(false, cluster.HasZoneResiliency);
            Assert.AreEqual("vmadmin", cluster.AdminUserName);
            //Assert.AreEqual("Password123!@#", cluster.AdminPassword);
        }
    }
}
