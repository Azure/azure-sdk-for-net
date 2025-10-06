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
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "cosmospgrg", AzureLocation.WestUS);
            CosmosDBForPostgreSqlClusterCollection clusters = rg.GetCosmosDBForPostgreSqlClusters();
            string clusterName = Recording.GenerateAssetName("cosmos-pg-net-");
            var data = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                IsHAEnabled = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                IsCoordinatorPublicIPAccessEnabled = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                IsShardsOnCoordinatorEnabled = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            CosmosDBForPostgreSqlClusterResource cluster = lro.Value;
            Assert.AreEqual(clusterName, cluster.Data.Name);

            // Get
            CosmosDBForPostgreSqlClusterResource clusterFromGet = await clusters.GetAsync(clusterName);
            Assert.AreEqual(clusterName, clusterFromGet.Data.Name);

            // List
            await foreach (CosmosDBForPostgreSqlClusterResource clusterFromList in clusters)
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
            CosmosDBForPostgreSqlClusterCollection clusters = rg.GetCosmosDBForPostgreSqlClusters();
            string clusterName = Recording.GenerateAssetName("cosmos-pg-net-");
            var data = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                IsHAEnabled = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                IsCoordinatorPublicIPAccessEnabled = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                IsShardsOnCoordinatorEnabled = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            CosmosDBForPostgreSqlClusterResource cluster = lro.Value;
            Assert.AreEqual(clusterName, cluster.Data.Name);

            // Update
            var updatedData = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
            {
                IsHAEnabled = true
            };
            lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, updatedData);
            CosmosDBForPostgreSqlClusterResource clusterFromUpdate = lro.Value;
            Assert.AreEqual(clusterName, clusterFromUpdate.Data.Name);
            Assert.AreEqual(true, clusterFromUpdate.Data.IsHAEnabled);

            // Get
            CosmosDBForPostgreSqlClusterResource clusterFromGet = await clusterFromUpdate.GetAsync();
            Assert.AreEqual(clusterName, clusterFromGet.Data.Name);

            // Delete
            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
