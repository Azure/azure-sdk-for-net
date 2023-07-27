// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class CassandraResourcesOperationsTests : CosmosDBManagementClientBase
    {
        protected string resourceGroupName;
        protected string databaseAccountName;
        protected string keyspaceName = "keyspaceName2510";
        protected string tableName = "tableName2510";
        protected string cassandraKeyspacesThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings";
        protected string cassandraTablesThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/tables/throughputSettings";
        protected int sampleThroughput = 700;
        protected int sampleThroughput2 = 800;
        protected int maxThroughput = 7000;
        protected bool setUpRun = false;

        public CassandraResourcesOperationsTests()
            : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setUpRun)
            {
                await InitializeClients();
                resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                databaseAccountName = Recording.GenerateAssetName("amecassandratest");
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations, CosmosDBTestUtilities.Location, resourceGroupName);
                setUpRun = true;
            }
            else if (setUpRun)
            {
                await initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task CassandraCreateDatabaseAccount()
        {
            var locations = new List<Location>();
            Location loc = new Location();
            loc.LocationName = CosmosDBTestUtilities.Location;
            loc.FailoverPriority = 0;
            loc.IsZoneRedundant = false;
            locations.Add(loc);

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountCreateUpdateParameters.Location = CosmosDBTestUtilities.Location;
            databaseAccountCreateUpdateParameters.Capabilities.Add(new Capability("EnableCassandra"));
            databaseAccountCreateUpdateParameters.ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.Eventual);

            await WaitForCompletionAsync(await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));
        }

        [TestCase, Order(2)]
        public async Task CassandraKeyspaceCreateUpdateTests()
        {
            var responseIsDatabaseNameExists = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(true, responseIsDatabaseNameExists.Value);
            Assert.AreEqual(200, responseIsDatabaseNameExists.GetRawResponse().Status);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CosmosDBCreateUpdateConfig(sampleThroughput, new AutoscaleSettings()));

            var cassandraKeyspaceResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));
            CassandraKeyspaceResource cassandraKeyspace1 = cassandraKeyspaceResponse1.Value;
            Assert.NotNull(cassandraKeyspace1);
            Assert.AreEqual(keyspaceName, cassandraKeyspace1.Name);

            var cassandraKeyspaceResponse2 = await  CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName);
            CassandraKeyspaceResource cassandraKeyspace2 = cassandraKeyspaceResponse2.Value;
            Assert.NotNull(cassandraKeyspace2);
            Assert.AreEqual(keyspaceName, cassandraKeyspace2.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspace1, cassandraKeyspace2);

            var throughputResponse = CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettings.Type);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings()));
            var cassandraKeyspaceResponse3 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters2));
            CassandraKeyspaceResource cassandraKeyspace3 = cassandraKeyspaceResponse3.Value;
            Assert.NotNull(cassandraKeyspace3);
            Assert.AreEqual(keyspaceName, cassandraKeyspace3.Name);

            var cassandraKeyspaceResponse4 = await CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName);
            CassandraKeyspaceResource cassandraKeyspace4 = cassandraKeyspaceResponse4.Value;
            Assert.NotNull(cassandraKeyspace4);
            Assert.AreEqual(keyspaceName, cassandraKeyspace4.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspace3, cassandraKeyspace4);

            var throughputResponse2 = CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            ThroughputSettingsData throughputSettings2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(throughputSettings2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettings2.Type);
        }

        [TestCase, Order(3)]
        public async Task CassandraKeyspaceListTests()
        {
            List<CassandraKeyspaceResource> cassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(cassandraKeyspaces);
            Assert.AreEqual(cassandraKeyspaces.Count, 1);
            CassandraKeyspaceResource cassandraKeyspace = await (CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName));
            VerifyEqualCassandraDatabases(cassandraKeyspaces[0], cassandraKeyspace);
        }

        [TestCase, Order(3)]
        public async Task CassandraKeyspaceUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartUpdateCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, throughputSettingsUpdateParameters));
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.Value;
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, maxThroughput);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettings.Type);
        }

        [TestCase, Order(4)]
        public async Task CassandraKeyspaceMigrateToAutoscaleTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraKeyspaceToAutoscaleAsync(resourceGroupName, databaseAccountName, keyspaceName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task CassandraKeyspaceMigrateToManualTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraKeyspaceToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(6)]
        public async Task CassandraTableCreateUpdateTests()
        {
            IList<Column> columns = new List<Column> { new Column { Name = "columnA", Type = "int" }, new Column { Name = "columnB", Type = "ascii" } };
            IList<CassandraPartitionKey> partitionKeys = new List<CassandraPartitionKey> { new CassandraPartitionKey { Name = "columnA" } };
            IList<ClusterKey> clusterKeys = new List<ClusterKey> { new ClusterKey { Name = "columnB", OrderBy = "Asc" } };
            CassandraSchema cassandraSchema = new CassandraSchema(columns, partitionKeys, clusterKeys);
            CassandraTableResource cassandraTableResource = new CassandraTableResource(tableName, default, cassandraSchema, default);
            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters(cassandraTableResource, new CosmosDBCreateUpdateConfig(sampleThroughput, new AutoscaleSettings()));

            Response<CassandraTableResource> cassandraResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters));
            CassandraTableResource cassandraTable = cassandraResponse.Value;
            Assert.NotNull(cassandraTable);

            VerifyCassandraTableCreation(cassandraTable, cassandraTableCreateUpdateParameters);

            var throughputResponse = CosmosDBManagementClient.CassandraResources.GetCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettings.Type);

            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters2 = new CassandraTableCreateUpdateParameters(cassandraTableResource, new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings()));

            Response<CassandraTableResource> cassandraResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters2));
            CassandraTableResource cassandraTable2 = cassandraResponse2.Value;
            Assert.NotNull(cassandraTable2);

            VerifyCassandraTableCreation(cassandraTable2, cassandraTableCreateUpdateParameters2);

            var throughputResponse2 = CosmosDBManagementClient.CassandraResources.GetCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            ThroughputSettingsData throughputSettings2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(throughputSettings2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettings2.Type);
        }

        [TestCase, Order(7)]
        public async Task CassandraTableListTests()
        {
            List<CassandraTableResource> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.NotNull(cassandraTables);
            Assert.AreEqual(cassandraTables.Count, 1);
            CassandraTableResource cassandraTable = await CosmosDBManagementClient.CassandraResources.GetCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            VerifyEqualCassandraTables(cassandraTables[0], cassandraTable);
        }

        [TestCase, Order(7)]
        public async Task CassandraTableUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartUpdateCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, throughputSettingsUpdateParameters));
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.Value;
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, maxThroughput);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettings.Type);
        }

        [TestCase, Order(8)]
        public async Task CassandraTableMigrateToAutoscaleTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraTableToAutoscaleAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task CassandraTableMigrateToManualTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraTableToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(10)]
        public async Task CassandraDeleteTableTests()
        {
            List<CassandraTableResource> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            foreach (CassandraTableResource cassandraTable in cassandraTables)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartDeleteCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraTable.Name));
            }
            List<CassandraTableResource> checkCassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.AreEqual(checkCassandraTables.Count, 0);
        }

        [TestCase, Order(11)]
        public async Task CassandraDeleteKeyspacesTests()
        {
            List<CassandraKeyspaceResource> cassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            foreach (CassandraKeyspaceResource cassandraKeyspace in cassandraKeyspaces)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartDeleteCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, cassandraKeyspace.Name));
            }
            List<CassandraKeyspaceResource> checkCassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.AreEqual(checkCassandraKeyspaces.Count, 0);
        }

        private void VerifyCassandraTableCreation(CassandraTableResource cassandraTable, CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters)
        {
            Assert.AreEqual(cassandraTable.Resource.Id, cassandraTableCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(cassandraTable.Resource.Schema.Columns.Count, cassandraTableCreateUpdateParameters.Resource.Schema.Columns.Count);
            for (int i = 0; i < cassandraTable.Resource.Schema.Columns.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Resource.Schema.Columns[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Name);
                Assert.AreEqual(cassandraTable.Resource.Schema.Columns[i].Type, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Type);
            }

            Assert.AreEqual(cassandraTable.Resource.Schema.ClusterKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys.Count);
            for (int i = 0; i < cassandraTable.Resource.Schema.ClusterKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Resource.Schema.ClusterKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys[i].Name);
            }

            Assert.AreEqual(cassandraTable.Resource.Schema.PartitionKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys.Count);
            for (int i = 0; i < cassandraTable.Resource.Schema.PartitionKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Resource.Schema.PartitionKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys[i].Name);
            }
        }

        private void VerifyEqualCassandraDatabases(CassandraKeyspaceResource expectedValue, CassandraKeyspaceResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }

        private void VerifyEqualCassandraTables(CassandraTableResource expectedValue, CassandraTableResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }
    }
}
#endif
