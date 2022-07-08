// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class ClusterTests : ConnectedVMwareTestBase
    {
        public ClusterTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VMwareClusterCollection> GetVMwareClusterCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVMwareClusters();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareClusterResource cluster1 = (await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareClusterResource cluster1 = (await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            // get cluster
            cluster1 = await _clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareClusterResource cluster1 = (await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            // check for exists cluster
            bool exists = await _clusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareClusterResource cluster1 = (await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            int count = 0;
            await foreach (var cluster in _clusterCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareClusterResource cluster1 = (await _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            cluster1 = null;
            await foreach (var cluster in DefaultSubscription.GetVMwareClustersAsync())
            {
                if (cluster.Data.Name == clusterName)
                {
                    cluster1 = cluster;
                }
            }
            Assert.NotNull(cluster1);
        }
    }
}
