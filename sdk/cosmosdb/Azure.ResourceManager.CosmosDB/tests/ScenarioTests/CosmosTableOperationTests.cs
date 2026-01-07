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
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CosmosTableOperationTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public CosmosTableOperationTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBTableCollection TableCollection => _databaseAccount.GetCosmosDBTables();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            //capabilities.Add(new CosmosDBAccountCapability("EnableCassandra"));
            capabilities.Add(new CosmosDBAccountCapability("EnableTable", null));
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
                if (await TableCollection.ExistsAsync(_databaseName))
                {
                    var id = TableCollection.Id;
                    id = CosmosDBTableResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _databaseName);
                    CosmosDBTableResource table = this.ArmClient.GetCosmosDBTableResource(id);
                    await table.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("Flaky test: Need diagnose the table API issue from RP team")]
        public async Task TableCreateAndUpdate()
        {
            var table = await CreateTable(null);
            Assert.That(table.Data.Resource.TableName, Is.EqualTo(_databaseName));
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await TableCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            CosmosDBTableResource table2 = await TableCollection.GetAsync(_databaseName);
            Assert.That(table2.Data.Resource.TableName, Is.EqualTo(_databaseName));
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyTables(table, table2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new CosmosDBTableCreateOrUpdateContent(AzureLocation.WestUS, table.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            table = (await TableCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(table.Data.Resource.TableName, Is.EqualTo(_databaseName));
            table2 = await TableCollection.GetAsync(_databaseName);
            VerifyTables(table, table2);
        }

        [Test]
        [RecordedTest]
        //[Ignore("Flaky test: Need diagnose the table API issue from RP team")]
        public async Task TableRestoreTest()
        {
            var table = await CreateTable(null);
            Assert.That(table.Data.Resource.TableName, Is.EqualTo(_databaseName));

            bool ifExists = await TableCollection.ExistsAsync(_databaseName);
            Assert.That(ifExists, Is.True);

            var databases = await TableCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(table.Data.Name));

            VerifyTables(databases[0], table);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            var restorableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.Data.AccountName == _databaseAccount.Data.Name);
            DateTimeOffset timestampInUtc = DateTimeOffset.FromUnixTimeSeconds((int)table.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(180);

            String restoreSource = restorableDatabaseAccount.Id;
            ResourceRestoreParameters RestoreParameters = new ResourceRestoreParameters
            {
                RestoreSource = restoreSource,
                RestoreTimestampInUtc = timestampInUtc.AddSeconds(100)
            };

            await table.DeleteAsync(WaitUntil.Completed);
            bool exists = await TableCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);

            CosmosDBTableResourceInfo resource = new CosmosDBTableResourceInfo(table.Data.Name)
            {
                RestoreParameters = RestoreParameters,
                CreateMode = CosmosDBAccountCreateMode.Restore
            };

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new CosmosDBTableCreateOrUpdateContent(AzureLocation.WestUS, resource);

            var table2 = (await TableCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.That(table.Data.Resource.TableName, Is.EqualTo(_databaseName));
            var table3 = await TableCollection.GetAsync(_databaseName);
            VerifyTables(table, table2, true);
            VerifyTables(table, table3, true);

            await table.DeleteAsync(WaitUntil.Completed);
            exists = await TableCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
        }

        [Test]
        [RecordedTest]
        [Ignore("Flaky test: Need diagnose the table API issue from RP team")]
        public async Task TableList()
        {
            var database = await CreateTable(null);

            var databases = await TableCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(databases, Has.Count.EqualTo(1));
            Assert.That(databases[0].Data.Name, Is.EqualTo(database.Data.Name));

            VerifyTables(databases[0], database);
        }

        [Test]
        [RecordedTest]
        [Ignore("Flaky test: Need diagnose the table API issue from RP team")]
        public async Task TableThroughput()
        {
            var database = await CreateTable(null);
            CosmosTableThroughputSettingResource throughput = await database.GetCosmosTableThroughputSetting().GetAsync();
            ;

            Assert.That(throughput.Data.Resource.Throughput, Is.EqualTo(TestThroughput1));

            CosmosTableThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.That(throughput2.Data.Resource.Throughput, Is.EqualTo(TestThroughput2));
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task TableMigrateToAutoscale()
        {
            var database = await CreateTable(null);
            CosmosTableThroughputSettingResource throughput = await database.GetCosmosTableThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateTableToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task TableMigrateToManual()
        {
            var database = await CreateTable(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            CosmosTableThroughputSettingResource throughput = await database.GetCosmosTableThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateTableToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Flaky test: Need diagnose the table API issue from RP team")]
        public async Task TableDelete()
        {
            var database = await CreateTable(null);
            await database.DeleteAsync(WaitUntil.Completed);

            bool exists = await TableCollection.ExistsAsync(_databaseName);
            Assert.That(exists, Is.False);
        }

        internal async Task<CosmosDBTableResource> CreateTable(AutoscaleSettings autoscale)
        {
            _databaseName = Recording.GenerateAssetName("table-");
            return await CreateTable(_databaseName, autoscale, _databaseAccount.GetCosmosDBTables());
        }

        internal static async Task<CosmosDBTableResource> CreateTable(string name, AutoscaleSettings autoscale, CosmosDBTableCollection collection)
        {
            var mongoDBDatabaseCreateUpdateOptions = new CosmosDBTableCreateOrUpdateContent(AzureLocation.WestUS,
                new CosmosDBTableResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, mongoDBDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        private void VerifyTables(CosmosDBTableResource expectedValue, CosmosDBTableResource actualValue, bool isRestoredTable = false)
        {
            Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
            Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
            Assert.That(actualValue.Data.Resource.TableName, Is.EqualTo(expectedValue.Data.Resource.TableName));
            Assert.That(actualValue.Data.Resource.Rid, Is.EqualTo(expectedValue.Data.Resource.Rid));
            if (!isRestoredTable)
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
