// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class TableTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        private string _databaseName;

        public TableTests(bool isAsync) : base(isAsync)
        {
        }

        protected TableCollection TableCollection { get => _databaseAccount.GetTables(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new Capability("EnableTable"))).Id;
            StopSessionRecording();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            if (_databaseAccountIdentifier != null)
            {
                ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).Delete();
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _databaseAccount = await ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            Table database = await TableCollection.GetIfExistsAsync(_databaseName);
            if (database != null)
            {
                await database.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task TableCreateAndUpdate()
        {
            var database = await CreateTable(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await TableCollection.CheckIfExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettings throughtput = await database.GetMongoDBCollectionThroughputAsync();
            Table database2 = await TableCollection.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyTables(database, database2);

            TableCreateUpdateParameters updateParameters = new TableCreateUpdateParameters(database.Id, _databaseName, database.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS2, database.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            database = await (await TableCollection.CreateOrUpdateAsync(_databaseName, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            database2 = await TableCollection.GetAsync(_databaseName);
            VerifyTables(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task TableList()
        {
            var database = await CreateTable(null);

            var databases = await TableCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.AreEqual(database.Data.Name, databases[0].Data.Name);

            VerifyTables(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task TableThroughput()
        {
            var database = await CreateTable(null);
            ThroughputSettings throughput = await database.GetTableThroughputAsync();

            Assert.AreEqual(TestThroughput1, throughput.Resource.Throughput);

            ThroughputSettings throughput2 = await database.UpdateTableThroughput(new ThroughputSettingsUpdateParameters(Resources.Models.Location.WestUS2,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task TableMigrateToAutoscale()
        {
            var database = await CreateTable(null);
            ThroughputSettings throughput = await database.GetTableThroughputAsync();
            AssertManualThroughput(throughput);

            throughput = await database.MigrateTableToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughput);
        }

        [Test]
        [RecordedTest]
        public async Task TableMigrateToManual()
        {
            var database = await CreateTable(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            ThroughputSettings throughput = await database.GetTableThroughputAsync();
            AssertAutoscale(throughput);

            throughput = await database.MigrateTableToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughput);
        }

        [Test]
        [RecordedTest]
        public async Task TableDelete()
        {
            var database = await CreateTable(null);
            await database.DeleteAsync();

            database = await TableCollection.GetIfExistsAsync(_databaseName);
            Assert.Null(database);
        }

        protected async Task<Table> CreateTable(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("table-");
            return await CreateTable(_databaseName, autoscale, _databaseAccount.GetTables());
        }

        internal static async Task<Table> CreateTable(string name, AutoscaleSettings autoscale, TableCollection collection)
        {
            TableCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new TableCreateUpdateParameters(Resources.Models.Location.WestUS2,
                new TableResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(name, mongoDBDatabaseCreateUpdateParameters);
            return databaseLro.Value;
        }

        private void VerifyTables(Table expectedValue, Table actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
        }
    }
}
