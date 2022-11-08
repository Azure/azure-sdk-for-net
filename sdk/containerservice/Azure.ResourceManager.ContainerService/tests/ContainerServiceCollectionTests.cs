// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
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

        [TestCase]
        [RecordedTest]
        public async Task CreateListGetDelete()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            var lro = await CreateContainerServiceAsync(WaitUntil.Started, rg, clusterName, rg.Data.Location);
            var rehydration = new ContainerServiceArmOperationRehydration<ContainerServiceManagedClusterResource>(Client, lro.Id);
            var rehydratedLro = await rehydration.RehydrateAsync(WaitUntil.Completed);
            ContainerServiceManagedClusterResource cluster = rehydratedLro.Value;
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
            var deleteLro = await clusterFromGet.DeleteAsync(WaitUntil.Started);
            var deleteRehydration = new ContainerServiceArmOperationRehydration(Client, deleteLro.Id);
            var deleteRehydratedLro = await deleteRehydration.RehydrateAsync(WaitUntil.Completed);
            await deleteRehydratedLro.WaitForCompletionResponseAsync(CancellationToken.None).ConfigureAwait(false);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            var lro = await CreateContainerServiceAsync(WaitUntil.Completed, rg, clusterName, rg.Data.Location);
            ContainerServiceManagedClusterResource cluster = lro.Value;
            // Update
            var clusterData = cluster.Data;
            clusterData.AgentPoolProfiles[0].Count = 2;
            var updateLro = await rg.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            ContainerServiceManagedClusterResource clusterFromUpdate = updateLro.Value;
            Assert.AreEqual(clusterFromUpdate.Data.Name, clusterName);
            Assert.AreEqual(clusterFromUpdate.Data.AgentPoolProfiles[0].Count, 2);
            // Delete
            await clusterFromUpdate.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetCredentials()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            var lro = await CreateContainerServiceAsync(WaitUntil.Completed, rg, clusterName, rg.Data.Location);
            ContainerServiceManagedClusterResource cluster = lro.Value;
            ManagedClusterCredentials adminCredentials = await cluster.GetClusterAdminCredentialsAsync();
            Assert.True(adminCredentials.Kubeconfigs.Count > 0);
            Assert.True(!string.IsNullOrWhiteSpace(adminCredentials.Kubeconfigs[0].Name));
            ManagedClusterCredentials userCredentials = await cluster.GetClusterUserCredentialsAsync();
            Assert.True(userCredentials.Kubeconfigs.Count > 0);
            // Delete
            await cluster.DeleteAsync(WaitUntil.Completed);
        }
    }
}
