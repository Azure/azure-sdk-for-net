// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class HciClusterCollectionTests: HciManagementTestBase
    {
        public HciClusterCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            var location = AzureLocation.EastUS;
            var resourceGroup = await CreateResourceGroupAsync(Subscription, "hci-cluster-rg", location);
            var clusterCollection = resourceGroup.GetHciClusters();
            var clusterName = Recording.GenerateAssetName("hci-cluster");
            var cluster = await CreateHciClusterAsync(resourceGroup, clusterName);
            var clusterData = cluster.Data;
            Assert.AreEqual(clusterData.Name, clusterName);
            Assert.AreEqual(clusterData.Location, location);
            Assert.AreEqual(clusterData.AadClientId, new Guid(TestEnvironment.ClientId));
            Assert.AreEqual(clusterData.AadTenantId, new Guid(TestEnvironment.TenantId));

            HciClusterResource clusterFromGet = await clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(clusterFromGet.Data.Name, clusterName);
            Assert.AreEqual(clusterFromGet.Data.Location, location);
            Assert.AreEqual(clusterFromGet.Data.AadClientId, new Guid(TestEnvironment.ClientId));
            Assert.AreEqual(clusterFromGet.Data.AadTenantId, new Guid(TestEnvironment.TenantId));

            await foreach (HciClusterResource clusterFromList in clusterCollection)
            {
                Assert.AreEqual(clusterFromList.Data.Name, clusterName);
                Assert.AreEqual(clusterFromList.Data.Location, location);
                Assert.AreEqual(clusterFromList.Data.AadClientId, new Guid(TestEnvironment.ClientId));
                Assert.AreEqual(clusterFromList.Data.AadTenantId, new Guid(TestEnvironment.TenantId));
            }
        }
    }
}
