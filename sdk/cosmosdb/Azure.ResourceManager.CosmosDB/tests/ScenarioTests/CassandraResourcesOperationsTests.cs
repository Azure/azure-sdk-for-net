// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
                InitializeClients();
                resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                databaseAccountName = Recording.GenerateAssetName("amecassandratest");
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations, CosmosDBTestUtilities.Location, resourceGroupName);
                setUpRun = true;
            }
            else if (setUpRun)
            {
                initNewRecord();
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

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings()));

            var cassandraKeyspaceResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults1 = cassandraKeyspaceResponse1.Value;
            Assert.NotNull(cassandraKeyspaceGetResults1);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults1.Name);

            var cassandraKeyspaceResponse2 = await  CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName);
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults2 = cassandraKeyspaceResponse2.Value;
            Assert.NotNull(cassandraKeyspaceGetResults2);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults2.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults1, cassandraKeyspaceGetResults2);

            var throughputResponse = CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettingsGetResults.Type);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings()));
            var cassandraKeyspaceResponse3 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters2));
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults3 = cassandraKeyspaceResponse3.Value;
            Assert.NotNull(cassandraKeyspaceGetResults3);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults3.Name);

            var cassandraKeyspaceResponse4 = await CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName);
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults4 = cassandraKeyspaceResponse4.Value;
            Assert.NotNull(cassandraKeyspaceGetResults4);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults4.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults3, cassandraKeyspaceGetResults4);

            var throughputResponse2 = CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            ThroughputSettingsGetResults throughputSettingsGetResults2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults2);
            Assert.NotNull(throughputSettingsGetResults2.Name);
            Assert.AreEqual(throughputSettingsGetResults2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettingsGetResults2.Type);
        }

        [TestCase, Order(3)]
        public async Task CassandraKeyspaceListTests()
        {
            List<CassandraKeyspaceGetResults> cassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(cassandraKeyspaces);
            Assert.AreEqual(cassandraKeyspaces.Count, 1);
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults = await (CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName));
            VerifyEqualCassandraDatabases(cassandraKeyspaces[0], cassandraKeyspaceGetResults);
        }

        [TestCase, Order(3)]
        public async Task CassandraKeyspaceUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartUpdateCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, throughputSettingsUpdateParameters));
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, maxThroughput);
            Assert.AreEqual(cassandraKeyspacesThroughputType, throughputSettingsGetResults.Type);
        }

        [TestCase, Order(4)]
        public async Task CassandraKeyspaceMigrateToAutoscaleTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraKeyspaceToAutoscaleAsync(resourceGroupName, databaseAccountName, keyspaceName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task CassandraKeyspaceMigrateToManualTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraKeyspaceToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(6)]
        public async Task CassandraTableCreateUpdateTests()
        {
            IList<Column> columns = new List<Column> { new Column { Name = "columnA", Type = "int" }, new Column { Name = "columnB", Type = "ascii" } };
            IList<CassandraPartitionKey> partitionKeys = new List<CassandraPartitionKey> { new CassandraPartitionKey { Name = "columnA" } };
            IList<ClusterKey> clusterKeys = new List<ClusterKey> { new ClusterKey { Name = "columnB", OrderBy = "Asc" } };
            CassandraSchema cassandraSchema = new CassandraSchema(columns, partitionKeys, clusterKeys);
            CassandraTableResource cassandraTableResource = new CassandraTableResource(tableName, default, cassandraSchema, default);
            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters(cassandraTableResource, new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings()));

            Response<CassandraTableGetResults> cassandraResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters));
            CassandraTableGetResults cassandraTableGetResults = cassandraResponse.Value;
            Assert.NotNull(cassandraTableGetResults);

            VerifyCassandraTableCreation(cassandraTableGetResults, cassandraTableCreateUpdateParameters);

            var throughputResponse = CosmosDBManagementClient.CassandraResources.GetCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettingsGetResults.Type);

            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters2 = new CassandraTableCreateUpdateParameters(cassandraTableResource, new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings()));

            Response<CassandraTableGetResults> cassandraResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters2));
            CassandraTableGetResults cassandraTableGetResults2 = cassandraResponse2.Value;
            Assert.NotNull(cassandraTableGetResults2);

            VerifyCassandraTableCreation(cassandraTableGetResults2, cassandraTableCreateUpdateParameters2);

            var throughputResponse2 = CosmosDBManagementClient.CassandraResources.GetCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            ThroughputSettingsGetResults throughputSettingsGetResults2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults2);
            Assert.NotNull(throughputSettingsGetResults2.Name);
            Assert.AreEqual(throughputSettingsGetResults2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettingsGetResults2.Type);
        }

        [TestCase, Order(7)]
        public async Task CassandraTableListTests()
        {
            List<CassandraTableGetResults> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.NotNull(cassandraTables);
            Assert.AreEqual(cassandraTables.Count, 1);
            CassandraTableGetResults cassandraTableGetResults = await CosmosDBManagementClient.CassandraResources.GetCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName);
            VerifyEqualCassandraTables(cassandraTables[0], cassandraTableGetResults);
        }

        [TestCase, Order(7)]
        public async Task CassandraTableUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartUpdateCassandraTableThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, throughputSettingsUpdateParameters));
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, maxThroughput);
            Assert.AreEqual(cassandraTablesThroughputType, throughputSettingsGetResults.Type);
        }

        [TestCase, Order(8)]
        public async Task CassandraTableMigrateToAutoscaleTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraTableToAutoscaleAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task CassandraTableMigrateToManualTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartMigrateCassandraTableToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(10)]
        public async Task CassandraDeleteTableTests()
        {
            List<CassandraTableGetResults> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            foreach (CassandraTableGetResults cassandraTable in cassandraTables)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartDeleteCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraTable.Name));
            }
            List<CassandraTableGetResults> checkCassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.AreEqual(checkCassandraTables.Count, 0);
        }

        [TestCase, Order(11)]
        public async Task CassandraDeleteKeyspacesTests()
        {
            List<CassandraKeyspaceGetResults> cassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            foreach (CassandraKeyspaceGetResults cassandraKeyspace in cassandraKeyspaces)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartDeleteCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, cassandraKeyspace.Name));
            }
            List<CassandraKeyspaceGetResults> checkCassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.AreEqual(checkCassandraKeyspaces.Count, 0);
        }

        private void VerifyCassandraTableCreation(CassandraTableGetResults cassandraTableGetResults, CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters)
        {
            Assert.AreEqual(cassandraTableGetResults.Resource.Id, cassandraTableCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(cassandraTableGetResults.Resource.Schema.Columns.Count, cassandraTableCreateUpdateParameters.Resource.Schema.Columns.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.Columns.Count; i++)
            {
                Assert.AreEqual(cassandraTableGetResults.Resource.Schema.Columns[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Name);
                Assert.AreEqual(cassandraTableGetResults.Resource.Schema.Columns[i].Type, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Type);
            }

            Assert.AreEqual(cassandraTableGetResults.Resource.Schema.ClusterKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.ClusterKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTableGetResults.Resource.Schema.ClusterKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys[i].Name);
            }

            Assert.AreEqual(cassandraTableGetResults.Resource.Schema.PartitionKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.PartitionKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTableGetResults.Resource.Schema.PartitionKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys[i].Name);
            }
        }

        private void VerifyEqualCassandraDatabases(CassandraKeyspaceGetResults expectedValue, CassandraKeyspaceGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }

        private void VerifyEqualCassandraTables(CassandraTableGetResults expectedValue, CassandraTableGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
