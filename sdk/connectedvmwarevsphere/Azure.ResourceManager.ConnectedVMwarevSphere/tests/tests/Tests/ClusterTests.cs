// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;
using System.Linq;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

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

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            // get cluster
            cluster1 = await _clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            // check for exists cluster
            cluster1 = await _clusterCollection.GetIfExistsAsync(clusterName);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            int count = 0;
            await foreach (var cluster in _clusterCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var clusterName = Recording.GenerateAssetName("testcluster");
            var _clusterCollection = await GetVMwareClusterCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            // create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            cluster1 = null;
            await foreach (var cluster in DefaultSubscription.GetClustersAsync())
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
