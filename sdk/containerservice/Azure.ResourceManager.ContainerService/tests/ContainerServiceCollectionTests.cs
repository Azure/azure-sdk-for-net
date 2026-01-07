// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceCollectionTests : ContainerServiceManagementTestBase
    {
        public ContainerServiceCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateListGetDelete()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            ContainerServiceManagedClusterResource cluster = await CreateContainerServiceAsync(rg, clusterName, rg.Data.Location);
            Assert.That(cluster.Data.Name, Is.EqualTo(clusterName));
            Assert.That(cluster.Data.DnsPrefix, Is.EqualTo(DnsPrefix));
            // List
            await foreach (var clusterFromList in clusterCollection)
            {
                Assert.That(clusterName, Is.EqualTo(clusterFromList.Data.Name));
            }
            // Get
            ContainerServiceManagedClusterResource clusterFromGet = await cluster.GetAsync();
            Assert.That(cluster.Data.Name, Is.EqualTo(clusterFromGet.Data.Name));
            Assert.That(cluster.Data.DnsPrefix, Is.EqualTo(clusterFromGet.Data.DnsPrefix));
            // Delete
            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Update()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.WestUS3);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            ContainerServiceManagedClusterResource cluster = await CreateContainerServiceAsync(rg, clusterName, rg.Data.Location);
            // Update
            var clusterData = cluster.Data;
            clusterData.AgentPoolProfiles[0].Count = 2;
            var lro = await rg.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            ContainerServiceManagedClusterResource clusterFromUpdate = lro.Value;
            Assert.That(clusterName, Is.EqualTo(clusterFromUpdate.Data.Name));
            Assert.That(clusterFromUpdate.Data.AgentPoolProfiles[0].Count, Is.EqualTo(2));
            // Delete
            await clusterFromUpdate.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task GetCredentials()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            ContainerServiceManagedClusterResource cluster = await CreateContainerServiceAsync(rg, clusterName, rg.Data.Location);
            ManagedClusterCredentials adminCredentials = await cluster.GetClusterAdminCredentialsAsync();
            Assert.That(adminCredentials.Kubeconfigs.Count > 0, Is.True);
            Assert.That(!string.IsNullOrWhiteSpace(adminCredentials.Kubeconfigs[0].Name), Is.True);
            ManagedClusterCredentials userCredentials = await cluster.GetClusterUserCredentialsAsync();
            Assert.That(userCredentials.Kubeconfigs.Count > 0, Is.True);
            // Delete
            await cluster.DeleteAsync(WaitUntil.Completed);
        }
    }
}
