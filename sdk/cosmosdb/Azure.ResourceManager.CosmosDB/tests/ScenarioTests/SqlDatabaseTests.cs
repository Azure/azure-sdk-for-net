// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlDatabaseTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        private string _databaseName;

        public SqlDatabaseTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlDatabaseCollection SqlDatabaseContainer { get => _databaseAccount.GetSqlDatabases(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB)).Id;
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
            SqlDatabase database = await SqlDatabaseContainer.GetIfExistsAsync(_databaseName);
            if (database != null)
            {
                await database.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseCreateAndUpdate()
        {
            var database = await CreateSqlDatabase(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await SqlDatabaseContainer.CheckIfExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            SqlDatabase database2 = await SqlDatabaseContainer.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyDatabases(database, database2);

            SqlDatabaseCreateUpdateOptions updateOptions = new SqlDatabaseCreateUpdateOptions(database.Id, _databaseName, database.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, database.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            database = await (await SqlDatabaseContainer.CreateOrUpdateAsync(_databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            database2 = await SqlDatabaseContainer.GetAsync(_databaseName);
            VerifyDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseList()
        {
            var database = await CreateSqlDatabase(null);

            var databases = await SqlDatabaseContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.AreEqual(database.Data.Name, databases[0].Data.Name);

            VerifyDatabases(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseThroughput()
        {
            var database = await CreateSqlDatabase(null);
            DatabaseAccountSqlDatabaseThroughputSetting throughput = await database.GetDatabaseAccountSqlDatabaseThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountSqlDatabaseThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseMigrateToAutoscale()
        {
            var database = await CreateSqlDatabase(null);
            DatabaseAccountSqlDatabaseThroughputSetting throughput = await database.GetDatabaseAccountSqlDatabaseThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateSqlDatabaseToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseMigrateToManual()
        {
            var database = await CreateSqlDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountSqlDatabaseThroughputSetting throughput = await database.GetDatabaseAccountSqlDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateSqlDatabaseToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseDelete()
        {
            var database = await CreateSqlDatabase(null);
            await database.DeleteAsync();

            database = await SqlDatabaseContainer.GetIfExistsAsync(_databaseName);
            Assert.Null(database);
        }

        protected async Task<SqlDatabase> CreateSqlDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("sql-db-");
            return await CreateSqlDatabase(_databaseName, autoscale, _databaseAccount.GetSqlDatabases());
        }

        internal static async Task<SqlDatabase> CreateSqlDatabase(string name, AutoscaleSettings autoscale, SqlDatabaseCollection collection)
        {
            SqlDatabaseCreateUpdateOptions sqlDatabaseCreateUpdateOptions = new SqlDatabaseCreateUpdateOptions(Resources.Models.Location.WestUS,
                new SqlDatabaseResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(name, sqlDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyDatabases(SqlDatabase expectedValue, SqlDatabase actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
            Assert.AreEqual(expectedValue.Data.Resource.Colls, actualValue.Data.Resource.Colls);
            Assert.AreEqual(expectedValue.Data.Resource.Users, actualValue.Data.Resource.Users);
        }
    }
}
