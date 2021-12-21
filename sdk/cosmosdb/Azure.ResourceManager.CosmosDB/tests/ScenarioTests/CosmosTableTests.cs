// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CosmosTableTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        private string _databaseName;

        public CosmosTableTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosTableCollection TableCollection { get => _databaseAccount.GetCosmosTables(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new DatabaseAccountCapability("EnableTable"))).Id;
            await StopSessionRecordingAsync();
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
            CosmosTable table = await TableCollection.GetIfExistsAsync(_databaseName);
            if (table != null)
            {
                await table.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task TableCreateAndUpdate()
        {
            var table = await CreateTable(null);
            Assert.AreEqual(_databaseName, table.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await TableCollection.CheckIfExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            CosmosTable table2 = await TableCollection.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, table2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyTables(table, table2);

            TableCreateUpdateOptions updateOptions = new TableCreateUpdateOptions(table.Id, _databaseName, table.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, table.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            table = await (await TableCollection.CreateOrUpdateAsync(_databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, table.Data.Resource.Id);
            table2 = await TableCollection.GetAsync(_databaseName);
            VerifyTables(table, table2);
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
            DatabaseAccountTableThroughputSetting throughput = await database.GetDatabaseAccountTableThroughputSetting().GetAsync();
            ;

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountTableThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task TableMigrateToAutoscale()
        {
            var database = await CreateTable(null);
            DatabaseAccountTableThroughputSetting throughput = await database.GetDatabaseAccountTableThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateTableToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task TableMigrateToManual()
        {
            var database = await CreateTable(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountTableThroughputSetting throughput = await database.GetDatabaseAccountTableThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateTableToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
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

        protected async Task<CosmosTable> CreateTable(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("table-");
            return await CreateTable(_databaseName, autoscale, _databaseAccount.GetCosmosTables());
        }

        internal static async Task<CosmosTable> CreateTable(string name, AutoscaleSettings autoscale, CosmosTableCollection collection)
        {
            TableCreateUpdateOptions mongoDBDatabaseCreateUpdateOptions = new TableCreateUpdateOptions(Resources.Models.Location.WestUS,
                new TableResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(name, mongoDBDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyTables(CosmosTable expectedValue, CosmosTable actualValue)
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
