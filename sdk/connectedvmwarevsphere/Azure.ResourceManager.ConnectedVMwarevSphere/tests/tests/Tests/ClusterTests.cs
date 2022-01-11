// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class ClusterTests : ConnectedVMwareTestBase
    {
        private VMwareClusterCollection _clusterCollection;
        public ClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteCluster()
        {
            string clusterName = Recording.GenerateAssetName("testcluster");
            _clusterCollection = _resourceGroup.GetVMwareClusters();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var clusterBody = new VMwareClusterData(DefaultLocation);
            clusterBody.MoRefId = "domain-c7";
            clusterBody.VCenterId = VcenterId;
            clusterBody.ExtendedLocation = _extendedLocation;
            //create cluster
            VMwareCluster cluster1 = (await _clusterCollection.CreateOrUpdateAsync(clusterName, clusterBody)).Value;
            Assert.IsNotNull(cluster1);
            Assert.AreEqual(cluster1.Id.Name, clusterName);
            _clusterId = cluster1.Id;
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task GetCluster()
        {
            _clusterCollection = _resourceGroup.GetVMwareClusters();
            // get cluster
            VMwareCluster cluster1 = await _clusterCollection.GetAsync(_clusterId);
            Assert.IsNotNull(cluster1);
        }
    }
}
