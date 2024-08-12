// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class PrivateCloudClusterResourceTest : AvsManagementTestBase
    {
        public PrivateCloudClusterResourceTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Get()
        {
            var privateCloudClusterResource = await getAvsPrivateCloudClusterResource();
            Assert.AreEqual(privateCloudClusterResource.Data.Name, CLUSTER1_NAME);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        [AsyncOnly]
        public async Task Update()
        {
            var privateCloudClusterResource = await getAvsPrivateCloudClusterResource();
            AvsPrivateCloudClusterPatch patch = new AvsPrivateCloudClusterPatch()
            {
                ClusterSize = 6,
            };
            ArmOperation<AvsPrivateCloudClusterResource> lro = await privateCloudClusterResource.UpdateAsync(WaitUntil.Started, patch);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task GetZones()
        {
            var privateCloudClusterResource = await getAvsPrivateCloudClusterResource();
            var zones = new List<AvsClusterZone>();
            await foreach (AvsClusterZone item in privateCloudClusterResource.GetZonesAsync())
            {
                zones.Add(item);
            }
            Assert.IsTrue(zones.Any());
        }
    }
}
