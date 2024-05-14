// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CassandraTableTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _cassandraKeyspaceId;
        private CassandraKeyspaceResource _cassandraKeyspace;
        private string _tableName;

        public CassandraTableTests(bool isAsync) : base(isAsync)
        {
        }

        protected CassandraTableCollection CassandraTableCollection => _cassandraKeyspace.GetCassandraTables();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            capabilities.Add(new CosmosDBAccountCapability("EnableCassandra", null));
            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, capabilities);

            _cassandraKeyspaceId = (await CassandraKeyspaceTests.CreateCassandraKeyspace(SessionRecording.GenerateAssetName("cassandra-keyspace-"), null, _databaseAccount.GetCassandraKeyspaces())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            await _cassandraKeyspace.DeleteAsync(WaitUntil.Completed);
            await _databaseAccount.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task SetUp()
        {
            _cassandraKeyspace = await ArmClient.GetCassandraKeyspaceResource(_cassandraKeyspaceId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await CassandraTableCollection.ExistsAsync(_tableName))
            {
                var id = CassandraTableCollection.Id;
                id = CassandraTableResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _tableName);
                CassandraTableResource table = this.ArmClient.GetCassandraTableResource(id);
                await table.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableCreateAndUpdate()
        {
            var parameters = BuildCreateUpdateOptions(null);
            var table = await CreateCassandraTable(parameters);
            Assert.AreEqual(_tableName, table.Data.Resource.TableName);
            VerifyCassandraTableCreation(table, parameters);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, table.Data.Options.Throughput);

            bool ifExists = await CassandraTableCollection.ExistsAsync(_tableName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await table.GetCassandraTableThroughputAsync();
            CassandraTableResource table2 = await CassandraTableCollection.GetAsync(_tableName);
            Assert.AreEqual(_tableName, table2.Data.Resource.TableName);
            VerifyCassandraTableCreation(table2, parameters);
            //Assert.AreEqual(TestThroughput1, table2.Data.Options.Throughput);

            VerifyCassandraTables(table, table2);

            parameters.Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 };

            table = (await CassandraTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, _tableName, parameters)).Value;
            Assert.AreEqual(_tableName, table.Data.Resource.TableName);
            VerifyCassandraTableCreation(table, parameters);
            // Seems bug in swagger definition
            table2 = await CassandraTableCollection.GetAsync(_tableName);
            VerifyCassandraTableCreation(table2, parameters);
            // Seems bug in swagger definition
            VerifyCassandraTables(table, table2);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableList()
        {
            var table = await CreateCassandraTable(null);

            var tables = await CassandraTableCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(tables, Has.Count.EqualTo(1));
            Assert.AreEqual(table.Data.Name, tables[0].Data.Name);

            VerifyCassandraTables(tables[0], table);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableThroughput()
        {
            var table = await CreateCassandraTable(null);
            CassandraTableThroughputSettingResource throughput = await table.GetCassandraTableThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            CassandraTableThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo(TestThroughput2, null, null, null, null, null, null)))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task CassandraTableMigrateToAutoscale()
        {
            var table = await CreateCassandraTable(null);

            CassandraTableThroughputSettingResource throughput = await table.GetCassandraTableThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateCassandraTableToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task CassandraTableMigrateToManual()
        {
            var parameters = BuildCreateUpdateOptions(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });
            var table = await CreateCassandraTable(parameters);

            CassandraTableThroughputSettingResource throughput = await table.GetCassandraTableThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateCassandraTableToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableDelete()
        {
            var table = await CreateCassandraTable(null);
            await table.DeleteAsync(WaitUntil.Completed);

            bool exists = await CassandraTableCollection.ExistsAsync(_tableName);
            Assert.IsFalse(exists);
        }

        protected async Task<CassandraTableResource> CreateCassandraTable(CassandraTableCreateOrUpdateContent parameters)
        {
            if (parameters == null)
            {
                parameters = BuildCreateUpdateOptions(null);
            }

            var tableLro = await CassandraTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, _tableName, parameters);
            return tableLro.Value;
        }

        private CassandraTableCreateOrUpdateContent BuildCreateUpdateOptions(AutoscaleSettings autoscale)
        {
            _tableName = Recording.GenerateAssetName("cassandra-table-");
            return new CassandraTableCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CassandraTableResourceInfo(_tableName, default, new CassandraSchema {
                    Columns = { new CassandraColumn { Name = "columnA", CassandraColumnType = "int" }, new CassandraColumn { Name = "columnB", CassandraColumnType = "ascii" } },
                    PartitionKeys = { new CassandraPartitionKey { Name = "columnA" } },
                    ClusterKeys = { new CassandraClusterKey { Name = "columnB", OrderBy = "Asc" } },
                }, default, null))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        private void VerifyCassandraTableCreation(CassandraTableResource cassandraTable, CassandraTableCreateOrUpdateContent cassandraTableCreateUpdateOptions)
        {
            Assert.AreEqual(cassandraTable.Data.Resource.TableName, cassandraTableCreateUpdateOptions.Resource.TableName);
            Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns.Count, cassandraTableCreateUpdateOptions.Resource.Schema.Columns.Count);
            for (int i = 0; i < cassandraTable.Data.Resource.Schema.Columns.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns[i].Name, cassandraTableCreateUpdateOptions.Resource.Schema.Columns[i].Name);
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns[i].CassandraColumnType, cassandraTableCreateUpdateOptions.Resource.Schema.Columns[i].CassandraColumnType);
            }

            Assert.AreEqual(cassandraTable.Data.Resource.Schema.ClusterKeys.Count, cassandraTableCreateUpdateOptions.Resource.Schema.ClusterKeys.Count);
            for (int i = 0; i < cassandraTable.Data.Resource.Schema.ClusterKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.ClusterKeys[i].Name, cassandraTableCreateUpdateOptions.Resource.Schema.ClusterKeys[i].Name);
            }

            Assert.AreEqual(cassandraTable.Data.Resource.Schema.PartitionKeys.Count, cassandraTableCreateUpdateOptions.Resource.Schema.PartitionKeys.Count);
            for (int i = 0; i < cassandraTable.Data.Resource.Schema.PartitionKeys.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.PartitionKeys[i].Name, cassandraTableCreateUpdateOptions.Resource.Schema.PartitionKeys[i].Name);
            }
        }

        private void VerifyCassandraTables(CassandraTableResource expectedValue, CassandraTableResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.TableName, actualValue.Data.Resource.TableName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
        }
    }
}
