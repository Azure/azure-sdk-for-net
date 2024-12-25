// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Models;
using System;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class GremlinDatabaseTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public GremlinDatabaseTests(bool isAsync) : base(isAsync)
        {
        }

        protected GremlinDatabaseCollection GremlinDatabaseCollection => _databaseAccount.GetGremlinDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            capabilities.Add(new CosmosDBAccountCapability("EnableGremlin", null));
            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, capabilities)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_databaseAccountIdentifier != null)
                {
                    await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _databaseAccount = await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await GremlinDatabaseCollection.ExistsAsync(_databaseName))
                {
                    var id = GremlinDatabaseCollection.Id;
                    id = GremlinDatabaseResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _databaseName);
                    GremlinDatabaseResource database = ArmClient.GetGremlinDatabaseResource(id);
                    await database.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseCreateAndUpdate()
        {
            var database = await CreateGremlinDatabase(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.DatabaseName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            GremlinDatabaseResource database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.DatabaseName);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyGremlinDatabases(database, database2);

            var updateOptions = new GremlinDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, database.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, default(ManagedServiceIdentity), null);

            database = await (await GremlinDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Started, _databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_databaseName, database.Data.Resource.DatabaseName);
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
            GremlinDatabaseThroughputSettingResource throughput = await database.GetGremlinDatabaseThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            GremlinDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task GremlinDatabaseMigrateToAutoscale()
        {
            var database = await CreateGremlinDatabase(null);
            GremlinDatabaseThroughputSettingResource throughput = await database.GetGremlinDatabaseThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateGremlinDatabaseToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task GremlinDatabaseMigrateToManual()
        {
            var database = await CreateGremlinDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            GremlinDatabaseThroughputSettingResource throughput = await database.GetGremlinDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateGremlinDatabaseToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseDelete()
        {
            var database = await CreateGremlinDatabase(null);
            await database.DeleteAsync(WaitUntil.Completed);

            bool exists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.IsFalse(exists);
        }

        internal async Task<GremlinDatabaseResource> CreateGremlinDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("gremlin-db-");
            return await CreateGremlinDatabase(_databaseName, autoscale, _databaseAccount.GetGremlinDatabases());
        }

        internal static async Task<GremlinDatabaseResource> CreateGremlinDatabase(string name, AutoscaleSettings autoscale, GremlinDatabaseCollection collection)
        {
            var cassandraKeyspaceCreateUpdateOptions = new GremlinDatabaseCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.GremlinDatabaseResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, cassandraKeyspaceCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyGremlinDatabases(GremlinDatabaseResource expectedValue, GremlinDatabaseResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.DatabaseName, actualValue.Data.Resource.DatabaseName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
        }
    }
}
