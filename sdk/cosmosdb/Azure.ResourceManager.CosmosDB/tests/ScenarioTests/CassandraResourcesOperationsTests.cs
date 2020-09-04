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
        public CassandraResourcesOperationsTests()
            : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations, CosmosDBTestUtilities.Location, resourceGroupName);
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
           await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task CassandraCRUDTestsAsync()
        {
            var cosmosDBClient = GetCosmosDBManagementClient();

            var locations = new List<Location>();
            Location loc = new Location();
            loc.LocationName = "West US";
            loc.FailoverPriority = 0;
            loc.IsZoneRedundant = false;
            locations.Add(loc);

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountCreateUpdateParameters.Location = "West US";
            databaseAccountCreateUpdateParameters.Capabilities.Add(new Capability("EnableCassandra"));
            databaseAccountCreateUpdateParameters.ConsistencyPolicy = new (DefaultConsistencyLevel.Eventual);

            await WaitForCompletionAsync(await cosmosDBClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));

            Task<Response> taskIsDatabaseNameExists = cosmosDBClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Response isDatabaseNameExists = taskIsDatabaseNameExists.ConfigureAwait(false).GetAwaiter().GetResult();
            if (isDatabaseNameExists.Status != 200)
            {
                return;
            }

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CreateUpdateOptions());

            var cassandraKeyspaceResponse = await WaitForCompletionAsync (await cosmosDBClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));

            CassandraKeyspaceGetResults cassandraKeyspaceGetResults = cassandraKeyspaceResponse.Value;

            Assert.NotNull(cassandraKeyspaceGetResults);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults.Name);

            var cassandraKeyspaceResponse1 = await WaitForCompletionAsync(await cosmosDBClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));

            CassandraKeyspaceGetResults cassandraKeyspaceGetResults1 = cassandraKeyspaceResponse1.Value;
            Assert.NotNull(cassandraKeyspaceGetResults1);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults1.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults, cassandraKeyspaceGetResults1);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName2), new CreateUpdateOptions(sampleThroughput, default));

            var cassandraKeyspaceResponse2 = await WaitForCompletionAsync(await cosmosDBClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName2, cassandraKeyspaceCreateUpdateParameters2));

            CassandraKeyspaceGetResults cassandraKeyspaceGetResults2 = cassandraKeyspaceResponse2.Value;
            Assert.NotNull(cassandraKeyspaceGetResults2);
            Assert.AreEqual(keyspaceName2, cassandraKeyspaceGetResults2.Name);

            var keyspacesResponse = cosmosDBClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName);
            Task<List<CassandraKeyspaceGetResults>> taskCassandraKeyspaces = keyspacesResponse.ToEnumerableAsync();
            List<CassandraKeyspaceGetResults> cassandraKeyspaces = taskCassandraKeyspaces.ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.NotNull(cassandraKeyspaces);

            var throughputResponse = cosmosDBClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName2);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraThroughputType, throughputSettingsGetResults.Type);

            //TODO: Migrate To Manual and Autoscale tests from example: https://github.com/Azure/azure-rest-api-specs/blob/master/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2020-04-01/examples/CosmosDBCassandraTableMigrateToAutoscale.json
            //var migrateKeyspace = await cosmosDBClient.CassandraResources.StartMigrateCassandraKeyspaceToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            //var taskResponseMigrate = migrateKeyspace.WaitForCompletionAsync();
            //var responseMigrate = taskResponseMigrate.ConfigureAwait(false).GetAwaiter().GetResult();
            //Assert.AreEqual(responseMigrate.Value.Resource.MinimumThroughput, responseMigrate.Value.Resource.Throughput);

            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters(new CassandraTableResource(tableName, default, new CassandraSchema(new List<Column> { new Column { Name = "columnA", Type = "int" }, new Column { Name = "columnB", Type = "ascii" } },  new List<CassandraPartitionKey> { new CassandraPartitionKey { Name = "columnA" } }, new List<ClusterKey> { new ClusterKey { Name = "columnB", OrderBy = "Asc" } }), default), new CreateUpdateOptions());

            Response<CassandraTableGetResults> cassandraResponse = await WaitForCompletionAsync(await cosmosDBClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters));
            CassandraTableGetResults cassandraTableGetResults = cassandraResponse.Value;
            Assert.NotNull(cassandraTableGetResults);

            VerifyCassandraTableCreation(cassandraTableGetResults, cassandraTableCreateUpdateParameters);

            AsyncPageable<CassandraTableGetResults> cassandraPageableResults = cosmosDBClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName);
            Task<List<CassandraTableGetResults>> taskCassandraTables = cassandraPageableResults.ToEnumerableAsync();
            List<CassandraTableGetResults> cassandraTables = taskCassandraTables.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(cassandraTables);

            foreach (CassandraTableGetResults cassandraTable in cassandraTables)
            {
                await cosmosDBClient.CassandraResources.StartDeleteCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraTable.Name);
            }

            foreach (CassandraKeyspaceGetResults cassandraKeyspace in cassandraKeyspaces)
            {
                await cosmosDBClient.CassandraResources.StartDeleteCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, cassandraKeyspace.Name);
            }
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
    }
}
