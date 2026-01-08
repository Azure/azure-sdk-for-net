// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.ResourceManager.Models;
using System.Threading;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class GremlinDatabaseOperationTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public GremlinDatabaseOperationTests(bool isAsync) : base(isAsync)
        {
        }

        protected GremlinDatabaseCollection GremlinDatabaseCollection => _databaseAccount.GetGremlinDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            capabilities.Add(new CosmosDBAccountCapability("EnableGremlin", null));
            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, capabilities, true)).Id;
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
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            GremlinDatabaseResource database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            Assert.That(database2.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyGremlinDatabases(database, database2);

            var updateOptions = new GremlinDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, database.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, null);

            database = await (await GremlinDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Started, _databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            VerifyGremlinDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinDatabaseRestoreTest()
        {
            var database = await CreateGremlinDatabase(null);
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));

            bool ifExists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            GremlinDatabaseResource database2 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            Assert.That(database2.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));

            VerifyGremlinDatabases(database, database2);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            var restorableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.Data.AccountName == _databaseAccount.Data.Name);
            DateTimeOffset timestampInUtc = DateTimeOffset.FromUnixTimeSeconds((int)database.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(180);

            String restoreSource = restorableDatabaseAccount.Id;
            ResourceRestoreParameters RestoreParameters = new ResourceRestoreParameters
            {
                RestoreSource = restoreSource,
                RestoreTimestampInUtc = timestampInUtc.AddSeconds(100)
            };

            await database.DeleteAsync(WaitUntil.Completed);
            bool exists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);

            ExtendedGremlinDatabaseResourceInfo resource = new ExtendedGremlinDatabaseResourceInfo(_databaseName)
            {
                RestoreParameters = RestoreParameters,
                CreateMode = CosmosDBAccountCreateMode.Restore
            };

            var updateOptions = new GremlinDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, resource, new CosmosDBCreateUpdateConfig(), null);

            GremlinDatabaseResource database3 = await (await GremlinDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Started, _databaseName, updateOptions)).WaitForCompletionAsync();
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            GremlinDatabaseResource database4 = await GremlinDatabaseCollection.GetAsync(_databaseName);
            VerifyGremlinDatabases(database, database3, true);
            VerifyGremlinDatabases(database3, database4);

            await database4.DeleteAsync(WaitUntil.Completed);
            exists = await GremlinDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
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

            Assert.That(throughput.Data.Resource.Throughput, Is.EqualTo(TestThroughput1));

            GremlinDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.That(throughput2.Data.Resource.Throughput, Is.EqualTo(TestThroughput2));
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
            Assert.That(exists, Is.False);
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

        private void VerifyGremlinDatabases(GremlinDatabaseResource expectedValue, GremlinDatabaseResource actualValue, bool isRestoredGraph = false)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
                Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
                Assert.That(actualValue.Data.Location, Is.EqualTo(expectedValue.Data.Location));
                Assert.That(actualValue.Data.Tags, Is.EqualTo(expectedValue.Data.Tags));
                Assert.That(actualValue.Data.ResourceType, Is.EqualTo(expectedValue.Data.ResourceType));

                Assert.That(actualValue.Data.Options, Is.EqualTo(expectedValue.Data.Options));

                Assert.That(actualValue.Data.Resource.DatabaseName, Is.EqualTo(expectedValue.Data.Resource.DatabaseName));
                Assert.That(actualValue.Data.Resource.Rid, Is.EqualTo(expectedValue.Data.Resource.Rid));
            });
            if (!isRestoredGraph)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(actualValue.Data.Resource.Timestamp, Is.EqualTo(expectedValue.Data.Resource.Timestamp));
                    Assert.That(actualValue.Data.Resource.ETag, Is.EqualTo(expectedValue.Data.Resource.ETag));
                });
            }
        }

        private void AddDelayInSeconds(int delayInSeconds)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Thread.Sleep(delayInSeconds * 1000);
            }
        }
    }
}
