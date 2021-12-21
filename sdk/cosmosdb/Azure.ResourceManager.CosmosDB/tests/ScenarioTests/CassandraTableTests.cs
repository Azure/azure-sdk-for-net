// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CassandraTableTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private ResourceIdentifier _cassandraKeyspaceId;
        private CassandraKeyspace _cassandraKeyspace;
        private string _tableName;

        public CassandraTableTests(bool isAsync) : base(isAsync)
        {
        }

        protected CassandraTableCollection CassandraTableCollection { get => _cassandraKeyspace.GetCassandraTables(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new DatabaseAccountCapability("EnableCassandra"));

            _cassandraKeyspaceId = (await CassandraKeyspaceTests.CreateCassandraKeyspace(SessionRecording.GenerateAssetName("cassandra-keyspace-"), null, _databaseAccount.GetCassandraKeyspaces())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _cassandraKeyspace.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _cassandraKeyspace = await ArmClient.GetCassandraKeyspace(_cassandraKeyspaceId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            CassandraTable table = await CassandraTableCollection.GetIfExistsAsync(_tableName);
            if (table != null)
            {
                await table.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableCreateAndUpdate()
        {
            var parameters = BuildCreateUpdateOptions(null);
            var table = await CreateCassandraTable(parameters);
            Assert.AreEqual(_tableName, table.Data.Resource.Id);
            VerifyCassandraTableCreation(table, parameters);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, table.Data.Options.Throughput);

            bool ifExists = await CassandraTableCollection.CheckIfExistsAsync(_tableName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await table.GetCassandraTableThroughputAsync();
            CassandraTable table2 = await CassandraTableCollection.GetAsync(_tableName);
            Assert.AreEqual(_tableName, table2.Data.Resource.Id);
            VerifyCassandraTableCreation(table2, parameters);
            //Assert.AreEqual(TestThroughput1, table2.Data.Options.Throughput);

            VerifyCassandraTables(table, table2);

            parameters.Options = new CreateUpdateOptions { Throughput = TestThroughput2 };

            table = await (await CassandraTableCollection.CreateOrUpdateAsync(_tableName, parameters)).WaitForCompletionAsync();
            Assert.AreEqual(_tableName, table.Data.Resource.Id);
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
            DatabaseAccountCassandraKeyspaceTableThroughputSetting throughput = await table.GetDatabaseAccountCassandraKeyspaceTableThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountCassandraKeyspaceTableThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableMigrateToAutoscale()
        {
            var table = await CreateCassandraTable(null);

            DatabaseAccountCassandraKeyspaceTableThroughputSetting throughput = await table.GetDatabaseAccountCassandraKeyspaceTableThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateCassandraTableToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableMigrateToManual()
        {
            var parameters = BuildCreateUpdateOptions(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });
            var table = await CreateCassandraTable(parameters);

            DatabaseAccountCassandraKeyspaceTableThroughputSetting throughput = await table.GetDatabaseAccountCassandraKeyspaceTableThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateCassandraTableToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task CassandraTableDelete()
        {
            var table = await CreateCassandraTable(null);
            await table.DeleteAsync();

            table = await CassandraTableCollection.GetIfExistsAsync(_tableName);
            Assert.Null(table);
        }

        protected async Task<CassandraTable> CreateCassandraTable(CassandraTableCreateUpdateOptions parameters)
        {
            if (parameters == null)
            {
                parameters = BuildCreateUpdateOptions(null);
            }

            var tableLro = await CassandraTableCollection.CreateOrUpdateAsync(_tableName, parameters);
            return tableLro.Value;
        }

        private CassandraTableCreateUpdateOptions BuildCreateUpdateOptions(AutoscaleSettings autoscale)
        {
            _tableName = Recording.GenerateAssetName("cassandra-table-");
            return new CassandraTableCreateUpdateOptions(Resources.Models.Location.WestUS,
                new CassandraTableResource(_tableName, default, new CassandraSchema {
                    Columns = { new CassandraColumn { Name = "columnA", Type = "int" }, new CassandraColumn { Name = "columnB", Type = "ascii" } },
                    PartitionKeys = { new CassandraPartitionKey { Name = "columnA" } },
                    ClusterKeys = { new ClusterKey { Name = "columnB", OrderBy = "Asc" } },
                }, default))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        private void VerifyCassandraTableCreation(CassandraTable cassandraTable, CassandraTableCreateUpdateOptions cassandraTableCreateUpdateOptions)
        {
            Assert.AreEqual(cassandraTable.Data.Resource.Id, cassandraTableCreateUpdateOptions.Resource.Id);
            Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns.Count, cassandraTableCreateUpdateOptions.Resource.Schema.Columns.Count);
            for (int i = 0; i < cassandraTable.Data.Resource.Schema.Columns.Count; i++)
            {
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns[i].Name, cassandraTableCreateUpdateOptions.Resource.Schema.Columns[i].Name);
                Assert.AreEqual(cassandraTable.Data.Resource.Schema.Columns[i].Type, cassandraTableCreateUpdateOptions.Resource.Schema.Columns[i].Type);
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

        private void VerifyCassandraTables(CassandraTable expectedValue, CassandraTable actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.Type, actualValue.Data.Type);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
        }
    }
}
