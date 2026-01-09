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
            Assert.That(cluster.Data.Name, Is.EqualTo(clusterName));

            // Get
            CosmosDBForPostgreSqlClusterResource clusterFromGet = await clusters.GetAsync(clusterName);
            Assert.That(clusterFromGet.Data.Name, Is.EqualTo(clusterName));

            // List
            await foreach (CosmosDBForPostgreSqlClusterResource clusterFromList in clusters)
            {
                Assert.That(clusterFromList.Data.Name, Is.EqualTo(clusterName));
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
            Assert.That(cluster.Data.Name, Is.EqualTo(clusterName));

            // Update
            var updatedData = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
            {
                IsHAEnabled = true
            };
            lro = await clusters.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, updatedData);
            CosmosDBForPostgreSqlClusterResource clusterFromUpdate = lro.Value;
            Assert.Multiple(() =>
            {
                Assert.That(clusterFromUpdate.Data.Name, Is.EqualTo(clusterName));
                Assert.That(clusterFromUpdate.Data.IsHAEnabled, Is.EqualTo(true));
            });

            // Get
            CosmosDBForPostgreSqlClusterResource clusterFromGet = await clusterFromUpdate.GetAsync();
            Assert.That(clusterFromGet.Data.Name, Is.EqualTo(clusterName));

            // Delete
            await clusterFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
