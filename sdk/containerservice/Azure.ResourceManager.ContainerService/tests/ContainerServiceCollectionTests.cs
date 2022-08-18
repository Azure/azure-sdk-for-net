// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceCollectionTests : ContainerServiceManagementTestBase
    {
        public ContainerServiceCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateListGetDelete()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            ContainerServiceManagedClusterResource cluster = await CreateContainerServiceAsync(rg, clusterName, rg.Data.Location);
            Assert.AreEqual(clusterName, cluster.Data.Name);
            Assert.AreEqual(DnsPrefix, cluster.Data.DnsPrefix);
            // List
            await foreach (var clusterFromList in clusterCollection)
            {
                Assert.AreEqual(clusterFromList.Data.Name, clusterName);
            }
            // Get
            ContainerServiceManagedClusterResource clusterFromGet = await cluster.GetAsync();
            Assert.AreEqual(clusterFromGet.Data.Name, cluster.Data.Name);
            Assert.AreEqual(clusterFromGet.Data.DnsPrefix, cluster.Data.DnsPrefix);
            // Delete
            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
