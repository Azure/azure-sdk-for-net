// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoDBDatabaseTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        private string _databaseName;

        public MongoDBDatabaseTests(bool isAsync) : base(isAsync)
        {
        }

        protected MongoDBDatabaseCollection MongoDBDatabaseCollection { get => _databaseAccount.GetMongoDBDatabases(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB)).Id;
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
            MongoDBDatabase database = await MongoDBDatabaseCollection.GetIfExistsAsync(_databaseName);
            if (database != null)
            {
                await database.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseCreateAndUpdate()
        {
            var database = await CreateMongoDBDatabase(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await MongoDBDatabaseCollection.CheckIfExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            MongoDBDatabase database2 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyMongoDBDatabases(database, database2);

            MongoDBDatabaseCreateUpdateOptions updateOptions = new MongoDBDatabaseCreateUpdateOptions(database.Id, _databaseName, database.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, database.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            database = await (await MongoDBDatabaseCollection.CreateOrUpdateAsync(_databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            database2 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            VerifyMongoDBDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseList()
        {
            var database = await CreateMongoDBDatabase(null);

            var databases = await MongoDBDatabaseCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.AreEqual(database.Data.Name, databases[0].Data.Name);

            VerifyMongoDBDatabases(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseThroughput()
        {
            var database = await CreateMongoDBDatabase(null);
            DatabaseAccountMongodbDatabaseThroughputSetting throughput = await database.GetDatabaseAccountMongodbDatabaseThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountMongodbDatabaseThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseMigrateToAutoscale()
        {
            var database = await CreateMongoDBDatabase(null);
            DatabaseAccountMongodbDatabaseThroughputSetting throughput = await database.GetDatabaseAccountMongodbDatabaseThroughputSetting().GetAsync();

            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateMongoDBDatabaseToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseMigrateToManual()
        {
            var database = await CreateMongoDBDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountMongodbDatabaseThroughputSetting throughput = await database.GetDatabaseAccountMongodbDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateMongoDBDatabaseToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseDelete()
        {
            var database = await CreateMongoDBDatabase(null);
            await database.DeleteAsync();

            database = await MongoDBDatabaseCollection.GetIfExistsAsync(_databaseName);
            Assert.Null(database);
        }

        protected async Task<MongoDBDatabase> CreateMongoDBDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("mongodb-");
            return await CreateMongoDBDatabase(_databaseName, autoscale, _databaseAccount.GetMongoDBDatabases());
        }

        internal static async Task<MongoDBDatabase> CreateMongoDBDatabase(string name, AutoscaleSettings autoscale, MongoDBDatabaseCollection collection)
        {
            MongoDBDatabaseCreateUpdateOptions mongoDBDatabaseCreateUpdateOptions = new MongoDBDatabaseCreateUpdateOptions(Resources.Models.Location.WestUS,
                new MongoDBDatabaseResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(name, mongoDBDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyMongoDBDatabases(MongoDBDatabase expectedValue, MongoDBDatabase actualValue)
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
