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
        protected string keyspaceName2 = "keyspaceName22510";
        protected string tableName = "tableName2510";
        protected string cassandraThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings";
        protected int sampleThroughput = 700;
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
        public async Task CreateDatabaseAccount()
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
        public async Task CassandraKeyspaceCreateTests()
        {
            Response responseIsDatabaseNameExists = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(200, responseIsDatabaseNameExists.Status);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName), new CreateUpdateOptions());

            var cassandraKeyspaceResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));

            CassandraKeyspaceGetResults cassandraKeyspaceGetResults = cassandraKeyspaceResponse.Value;
            Assert.NotNull(cassandraKeyspaceGetResults);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults.Name);

            var cassandraKeyspaceResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters));
            CassandraKeyspaceGetResults cassandraKeyspaceGetResults1 = cassandraKeyspaceResponse1.Value;
            Assert.NotNull(cassandraKeyspaceGetResults1);
            Assert.AreEqual(keyspaceName, cassandraKeyspaceGetResults1.Name);

            VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults, cassandraKeyspaceGetResults1);

            CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters(new CassandraKeyspaceResource(keyspaceName2), new CreateUpdateOptions(sampleThroughput, default));
            var cassandraKeyspaceResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraKeyspaceAsync(resourceGroupName, databaseAccountName, keyspaceName2, cassandraKeyspaceCreateUpdateParameters2));

            CassandraKeyspaceGetResults cassandraKeyspaceGetResults2 = cassandraKeyspaceResponse2.Value;
            Assert.NotNull(cassandraKeyspaceGetResults2);
            Assert.AreEqual(keyspaceName2, cassandraKeyspaceGetResults2.Name);

            List<CassandraKeyspaceGetResults> cassandraKeyspaces = await CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(cassandraKeyspaces);
        }

        [TestCase, Order(3)]
        public async Task CassandraThroughputTests()
        {
            Response<ThroughputSettingsGetResults> throughputResponse = await CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName2);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(cassandraThroughputType, throughputSettingsGetResults.Type);

            //TODO: Migrate To Manual and Autoscale tests from example: https://github.com/Azure/azure-rest-api-specs/blob/master/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2020-04-01/examples/CosmosDBCassandraTableMigrateToAutoscale.json
            //var migrateKeyspace = await cosmosDBClient.CassandraResources.StartMigrateCassandraKeyspaceToManualThroughputAsync(resourceGroupName, databaseAccountName, keyspaceName);
            //var taskResponseMigrate = migrateKeyspace.WaitForCompletionAsync();
            //var responseMigrate = taskResponseMigrate.ConfigureAwait(false).GetAwaiter().GetResult();
            //Assert.AreEqual(responseMigrate.Value.Resource.MinimumThroughput, responseMigrate.Value.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task CassandraTableCRUDTests()
        {
            CassandraSchema cassandraSchema = new CassandraSchema(new List<Column> { new Column { Name = "columnA", Type = "int" }, new Column { Name = "columnB", Type = "ascii" } }, new List<CassandraPartitionKey> { new CassandraPartitionKey { Name = "columnA" } }, new List<ClusterKey> { new ClusterKey { Name = "columnB", OrderBy = "Asc" } });
            CassandraTableResource cassandraTableResource = new CassandraTableResource(tableName, default, cassandraSchema, default);
            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters(cassandraTableResource, new CreateUpdateOptions());

            Response<CassandraTableGetResults> cassandraResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartCreateUpdateCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters));
            CassandraTableGetResults cassandraTableGetResults = cassandraResponse.Value;
            Assert.NotNull(cassandraTableGetResults);

            VerifyCassandraTableCreation(cassandraTableGetResults, cassandraTableCreateUpdateParameters);

            List<CassandraTableGetResults> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.NotNull(cassandraTables);
        }

        [TestCase, Order(5)]
        public async Task CassandraDeleteTests()
        {
            List<CassandraTableGetResults> cassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            foreach (CassandraTableGetResults cassandraTable in cassandraTables)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.CassandraResources.StartDeleteCassandraTableAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraTable.Name));
            }
            List<CassandraTableGetResults> checkCassandraTables = await CosmosDBManagementClient.CassandraResources.ListCassandraTablesAsync(resourceGroupName, databaseAccountName, keyspaceName).ToEnumerableAsync();
            Assert.AreEqual(checkCassandraTables.Count, 0);

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
    }
}
