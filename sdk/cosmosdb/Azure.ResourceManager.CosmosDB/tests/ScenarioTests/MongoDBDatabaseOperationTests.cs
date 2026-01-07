// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoDBDatabaseOperationTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public MongoDBDatabaseOperationTests(bool isAsync) : base(isAsync)
        {
        }

        protected MongoDBDatabaseCollection MongoDBDatabaseCollection => _databaseAccount.GetMongoDBDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB, true)).Id;
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
                if (await MongoDBDatabaseCollection.ExistsAsync(_databaseName))
                {
                    var id = MongoDBDatabaseCollection.Id;
                    id = MongoDBDatabaseResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _databaseName);
                    MongoDBDatabaseResource database = this.ArmClient.GetMongoDBDatabaseResource(id);
                    await database.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseCreateAndUpdate()
        {
            var database = await CreateMongoDBDatabase(null);
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            MongoDBDatabaseResource database2 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            Assert.That(database2.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyMongoDBDatabases(database, database2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new MongoDBDatabaseCreateOrUpdateContent(AzureLocation.WestUS, database.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            database = (await MongoDBDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            database2 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            VerifyMongoDBDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to rerun once the null timestamp value from the database resource fixed")]
        public async Task MongoDBDatabaseRestoreTest()
        {
            var database = await CreateMongoDBDatabase(null);
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));

            bool ifExists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            MongoDBDatabaseResource database2 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            Assert.That(database2.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));

            VerifyMongoDBDatabases(database, database2);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            var restorableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.Data.AccountName == _databaseAccount.Data.Name);
            DateTimeOffset timestampInUtc = DateTimeOffset.FromUnixTimeSeconds((int)database.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(60);

            String restoreSource = restorableDatabaseAccount.Id;
            ResourceRestoreParameters RestoreParameters = new ResourceRestoreParameters
            {
                RestoreSource = restoreSource,
                RestoreTimestampInUtc = timestampInUtc.AddSeconds(60)
            };

            await database.DeleteAsync(WaitUntil.Completed);

            bool exists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);

            MongoDBDatabaseResourceInfo resource = new MongoDBDatabaseResourceInfo(_databaseName)
            {
                RestoreParameters = RestoreParameters,
                CreateMode = CosmosDBAccountCreateMode.Restore
            };

            var updateOptions = new MongoDBDatabaseCreateOrUpdateContent(AzureLocation.WestUS, resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            var database3 = (await MongoDBDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            var database4 = await MongoDBDatabaseCollection.GetAsync(_databaseName);
            VerifyMongoDBDatabases(database3, database4);
            VerifyMongoDBDatabases(database, database3, true);

            ifExists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            await database.DeleteAsync(WaitUntil.Completed);
            exists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseList()
        {
            var database = await CreateMongoDBDatabase(null);

            var databases = await MongoDBDatabaseCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(database.Data.Name));

            VerifyMongoDBDatabases(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseThroughput()
        {
            var database = await CreateMongoDBDatabase(null);
            MongoDBDatabaseThroughputSettingResource throughput = await database.GetMongoDBDatabaseThroughputSetting().GetAsync();

            Assert.That(throughput.Data.Resource.Throughput, Is.EqualTo(TestThroughput1));

            MongoDBDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.That(throughput2.Data.Resource.Throughput, Is.EqualTo(TestThroughput2));
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task MongoDBDatabaseMigrateToAutoscale()
        {
            var database = await CreateMongoDBDatabase(null);
            MongoDBDatabaseThroughputSettingResource throughput = await database.GetMongoDBDatabaseThroughputSetting().GetAsync();

            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateMongoDBDatabaseToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task MongoDBDatabaseMigrateToManual()
        {
            var database = await CreateMongoDBDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            MongoDBDatabaseThroughputSettingResource throughput = await database.GetMongoDBDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateMongoDBDatabaseToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task MongoDBDatabaseDelete()
        {
            var database = await CreateMongoDBDatabase(null);
            await database.DeleteAsync(WaitUntil.Completed);

            bool exists = await MongoDBDatabaseCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
        }

        internal async Task<MongoDBDatabaseResource> CreateMongoDBDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("mongodb-");
            return await CreateMongoDBDatabase(_databaseName, autoscale, _databaseAccount.GetMongoDBDatabases());
        }

        internal static async Task<MongoDBDatabaseResource> CreateMongoDBDatabase(string name, AutoscaleSettings autoscale, MongoDBDatabaseCollection collection)
        {
            var mongoDBDatabaseCreateUpdateOptions = new MongoDBDatabaseCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.MongoDBDatabaseResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, mongoDBDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyMongoDBDatabases(MongoDBDatabaseResource expectedValue, MongoDBDatabaseResource actualValue, bool isRestoredResource = false)
        {
            Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
            Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
            Assert.That(actualValue.Data.Resource.DatabaseName, Is.EqualTo(expectedValue.Data.Resource.DatabaseName));
            Assert.That(actualValue.Data.Resource.Rid, Is.EqualTo(expectedValue.Data.Resource.Rid));
            if (!isRestoredResource)
            {
                Assert.That(actualValue.Data.Resource.Timestamp, Is.EqualTo(expectedValue.Data.Resource.Timestamp));
                Assert.That(actualValue.Data.Resource.ETag, Is.EqualTo(expectedValue.Data.Resource.ETag));
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
