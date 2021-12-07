// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class GremlinDatabaseTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        private string _databaseName;

        public GremlinDatabaseTests(bool isAsync) : base(isAsync)
        {
        }

        protected GremlinDatabaseCollection GremlinDatabaseCollection { get => _databaseAccount.GetGremlinDatabases(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new DatabaseAccountCapability("EnableGremlin"))).Id;
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
            GremlinDatabase database = await GremlinDatabaseCollection.GetIfExistsAsync(_databaseName);
            if (database != null)
            {
                await database.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseCreateAndUpdate()
        {
            var database = await CreateGremlinDatabase(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await GremlinDatabaseCollection.CheckIfExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            GremlinDatabase database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyGremlinDatabases(database, database2);

            GremlinDatabaseCreateUpdateOptions updateOptions = new GremlinDatabaseCreateUpdateOptions(database.Id, _databaseName, database.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, database.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            database = await (await GremlinDatabaseCollection.CreateOrUpdateAsync(_databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, database.Data.Resource.Id);
            database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            VerifyGremlinDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseList()
        {
            var database = await CreateGremlinDatabase(null);

            var databases = await GremlinDatabaseCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.GreaterThan(0));
            Assert.That(databases.Any(d => d.Data.Name == database.Data.Name));

            VerifyGremlinDatabases(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseThroughput()
        {
            var database = await CreateGremlinDatabase(null);
            DatabaseAccountGremlinDatabaseThroughputSetting throughput = await database.GetDatabaseAccountGremlinDatabaseThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountGremlinDatabaseThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseMigrateToAutoscale()
        {
            var database = await CreateGremlinDatabase(null);
            DatabaseAccountGremlinDatabaseThroughputSetting throughput = await database.GetDatabaseAccountGremlinDatabaseThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateGremlinDatabaseToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseMigrateToManual()
        {
            var database = await CreateGremlinDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountGremlinDatabaseThroughputSetting throughput = await database.GetDatabaseAccountGremlinDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateGremlinDatabaseToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseDelete()
        {
            var database = await CreateGremlinDatabase(null);
            await database.DeleteAsync();

            database = await GremlinDatabaseCollection.GetIfExistsAsync(_databaseName);
            Assert.Null(database);
        }

        protected async Task<GremlinDatabase> CreateGremlinDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("gremlin-db-");
            return await CreateGremlinDatabase(_databaseName, autoscale, _databaseAccount.GetGremlinDatabases());
        }

        internal static async Task<GremlinDatabase> CreateGremlinDatabase(string name, AutoscaleSettings autoscale, GremlinDatabaseCollection collection)
        {
            GremlinDatabaseCreateUpdateOptions cassandraKeyspaceCreateUpdateOptions = new GremlinDatabaseCreateUpdateOptions(Resources.Models.Location.WestUS,
                new GremlinDatabaseResource(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(name, cassandraKeyspaceCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyGremlinDatabases(GremlinDatabase expectedValue, GremlinDatabase actualValue)
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
