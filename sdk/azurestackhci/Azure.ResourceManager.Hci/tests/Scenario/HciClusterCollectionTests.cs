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
            Assert.That(clusterName, Is.EqualTo(clusterData.Name));
            Assert.That(location, Is.EqualTo(clusterData.Location));
            Assert.That(new Guid(TestEnvironment.ClientId), Is.EqualTo(clusterData.AadClientId));
            Assert.That(new Guid(TestEnvironment.TenantId), Is.EqualTo(clusterData.AadTenantId));

            HciClusterResource clusterFromGet = await clusterCollection.GetAsync(clusterName);
            Assert.That(clusterName, Is.EqualTo(clusterFromGet.Data.Name));
            Assert.That(location, Is.EqualTo(clusterFromGet.Data.Location));
            Assert.That(new Guid(TestEnvironment.ClientId), Is.EqualTo(clusterFromGet.Data.AadClientId));
            Assert.That(new Guid(TestEnvironment.TenantId), Is.EqualTo(clusterFromGet.Data.AadTenantId));

            await foreach (HciClusterResource clusterFromList in clusterCollection)
            {
                Assert.That(clusterName, Is.EqualTo(clusterFromList.Data.Name));
                Assert.That(location, Is.EqualTo(clusterFromList.Data.Location));
                Assert.That(new Guid(TestEnvironment.ClientId), Is.EqualTo(clusterFromList.Data.AadClientId));
                Assert.That(new Guid(TestEnvironment.TenantId), Is.EqualTo(clusterFromList.Data.AadTenantId));
            }
        }
    }
}
