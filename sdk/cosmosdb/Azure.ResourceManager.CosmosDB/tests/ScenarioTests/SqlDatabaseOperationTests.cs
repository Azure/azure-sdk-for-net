// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlDatabaseOperationTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public SqlDatabaseOperationTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlDatabaseCollection SqlDatabaseContainer => _databaseAccount.GetCosmosDBSqlDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            //BackupPolicy = new ContinuousModeBackupPolicy()
            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, null , true)).Id;
            //_databaseAccountIdentifier =  (await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"))).Id;
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
                if (await SqlDatabaseContainer.ExistsAsync(_databaseName))
                {
                    var id = SqlDatabaseContainer.Id;
                    id = CosmosDBSqlDatabaseResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _databaseName);
                    CosmosDBSqlDatabaseResource database = this.ArmClient.GetCosmosDBSqlDatabaseResource(id);
                    await database.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseCreateAndUpdate()
        {
            var database = await CreateSqlDatabase(null);
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await SqlDatabaseContainer.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            CosmosDBSqlDatabaseResource database2 = await SqlDatabaseContainer.GetAsync(_databaseName);
            Assert.That(database2.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyDatabases(database, database2);

            var updateOptions = new CosmosDBSqlDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, database.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, null);

            database = (await SqlDatabaseContainer.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            database2 = await SqlDatabaseContainer.GetAsync(_databaseName);
            VerifyDatabases(database, database2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseRestoreTest()
        {
            var database = await CreateSqlDatabase(null);
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));

            bool ifExists = await SqlDatabaseContainer.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);
            var databases = await SqlDatabaseContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(database.Data.Name));
            DateTimeOffset timestampInUtc = DateTimeOffset.FromUnixTimeSeconds((int)database.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(180);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            var restorableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.Data.AccountName == _databaseAccount.Data.Name);

            await database.DeleteAsync(WaitUntil.Completed);
            bool exists = await SqlDatabaseContainer.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);

            String restoreSource = restorableDatabaseAccount.Id;
            ResourceRestoreParameters RestoreParameters = new ResourceRestoreParameters
            {
                RestoreSource = restoreSource,
                RestoreTimestampInUtc = timestampInUtc.AddSeconds(100)
            };
            CosmosDBSqlDatabaseResourceInfo resource = new CosmosDBSqlDatabaseResourceInfo(_databaseName, RestoreParameters, CosmosDBAccountCreateMode.Restore, null);

            var updateOptions = new CosmosDBSqlDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, resource, null, null);

            var database3 = (await SqlDatabaseContainer.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(database.Data.Resource.DatabaseName, Is.EqualTo(_databaseName));
            var database4 = await SqlDatabaseContainer.GetAsync(_databaseName);
            VerifyDatabases(database, database3, true);
            VerifyDatabases(database, database4, true);

            databases = await SqlDatabaseContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(database.Data.Name));

            // cleanup
            await database.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseList()
        {
            var database = await CreateSqlDatabase(null);

            var databases = await SqlDatabaseContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(database.Data.Name));

            VerifyDatabases(databases[0], database);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseThroughput()
        {
            var database = await CreateSqlDatabase(null);
            CosmosDBSqlDatabaseThroughputSettingResource throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();

            Assert.That(throughput.Data.Resource.Throughput, Is.EqualTo(TestThroughput1));

            CosmosDBSqlDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.That(throughput2.Data.Resource.Throughput, Is.EqualTo(TestThroughput2));
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task SqlDatabaseMigrateToAutoscale()
        {
            var database = await CreateSqlDatabase(null);
            CosmosDBSqlDatabaseThroughputSettingResource throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateSqlDatabaseToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task SqlDatabaseMigrateToManual()
        {
            var database = await CreateSqlDatabase(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            CosmosDBSqlDatabaseThroughputSettingResource throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateSqlDatabaseToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseDelete()
        {
            var database = await CreateSqlDatabase(null);
            await database.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlDatabaseContainer.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
        }

        internal async Task<CosmosDBSqlDatabaseResource> CreateSqlDatabase(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("sql-db-");
            return await CreateSqlDatabase(_databaseName, autoscale, _databaseAccount.GetCosmosDBSqlDatabases());
        }

        internal static async Task<CosmosDBSqlDatabaseResource> CreateSqlDatabase(string name, AutoscaleSettings autoscale, CosmosDBSqlDatabaseCollection collection)
        {
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlDatabaseCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlDatabaseResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, sqlDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyDatabases(CosmosDBSqlDatabaseResource expectedValue, CosmosDBSqlDatabaseResource actualValue, bool isRestoreRequest = false)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
                Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
                Assert.That(actualValue.Data.Resource.DatabaseName, Is.EqualTo(expectedValue.Data.Resource.DatabaseName));
                Assert.That(actualValue.Data.Resource.Rid, Is.EqualTo(expectedValue.Data.Resource.Rid));
                Assert.That(actualValue.Data.Resource.Colls, Is.EqualTo(expectedValue.Data.Resource.Colls));
                Assert.That(actualValue.Data.Resource.Users, Is.EqualTo(expectedValue.Data.Resource.Users));
            });
            if (!isRestoreRequest)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(actualValue.Data.Resource.ETag, Is.EqualTo(expectedValue.Data.Resource.ETag));
                    Assert.That(actualValue.Data.Resource.Timestamp, Is.EqualTo(expectedValue.Data.Resource.Timestamp));
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
