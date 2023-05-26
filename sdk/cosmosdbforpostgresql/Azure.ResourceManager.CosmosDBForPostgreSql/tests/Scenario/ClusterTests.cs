// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Tests
{
    public class ClusterTests : CosmosDBForPostgreSqlManagementTestBase
    {
        public ClusterTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "cosmospgrg", AzureLocation.WestUS);
            ClusterCollection clusters = rg.GetClusters();
            string clusterName = Recording.GenerateAssetName("cosmospgnet");
            var data = new ClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                EnableHa = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                CoordinatorEnablePublicIPAccess = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                EnableShardsOnCoordinator = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            ClusterResource cluster = lro.Value;
            Assert.AreEqual(clusterName, cluster.Data.Name);

            // Get
            ClusterResource clusterFromGet = await clusters.GetAsync(clusterName);
            Assert.AreEqual(clusterName, clusterFromGet.Data.Name);

            // List
            await foreach (ClusterResource clusterFromList in clusters)
            {
                Assert.AreEqual(clusterName, clusterFromList.Data.Name);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "cosmospgrg", AzureLocation.WestUS);
            ClusterCollection clusters = rg.GetClusters();
            string clusterName = Recording.GenerateAssetName("cosmospgnet");
            var data = new ClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                EnableHa = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                CoordinatorEnablePublicIPAccess = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                EnableShardsOnCoordinator = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            ClusterResource cluster = lro.Value;
            Assert.AreEqual(clusterName, cluster.Data.Name);

            // Update
            var updatedData = new ClusterData(rg.Data.Location)
            {
                EnableHa = true
            };
            lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, updatedData);
            ClusterResource clusterFromUpdate = lro.Value;
            Assert.AreEqual(clusterName, clusterFromUpdate.Data.Name);
            Assert.AreEqual(true, clusterFromUpdate.Data.EnableHa);

            // Get
            ClusterResource clusterFromGet = await clusterFromUpdate.GetAsync();
            Assert.AreEqual(clusterName, clusterFromGet.Data.Name);

            // Delete
            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
