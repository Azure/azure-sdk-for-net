﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlDatabaseTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public SqlDatabaseTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlDatabaseCollection SqlDatabaseContainer => _databaseAccount.GetCosmosDBSqlDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (_databaseAccountIdentifier != null)
            {
                await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).DeleteAsync(WaitUntil.Completed);
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
            if (await SqlDatabaseContainer.ExistsAsync(_databaseName))
            {
                var id = SqlDatabaseContainer.Id;
                id = CosmosDBSqlDatabaseResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _databaseName);
                CosmosDBSqlDatabaseResource database = this.ArmClient.GetCosmosDBSqlDatabaseResource(id);
                await database.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlDatabaseCreateAndUpdate()
        {
            var database = await CreateSqlDatabase(null);
            Assert.AreEqual(_databaseName, database.Data.Resource.DatabaseName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, database.Data.Options.Throughput);

            bool ifExists = await SqlDatabaseContainer.ExistsAsync(_databaseName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await database.GetMongoDBCollectionThroughputAsync();
            CosmosDBSqlDatabaseResource database2 = await SqlDatabaseContainer.GetAsync(_databaseName);
            Assert.AreEqual(_databaseName, database2.Data.Resource.DatabaseName);
            //Assert.AreEqual(TestThroughput1, database2.Data.Options.Throughput);

            VerifyDatabases(database, database2);

            var updateOptions = new CosmosDBSqlDatabaseCreateOrUpdateContent(database.Id, _databaseName, database.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, database.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, default(ManagedServiceIdentity));

            database = (await SqlDatabaseContainer.CreateOrUpdateAsync(WaitUntil.Completed, _databaseName, updateOptions)).Value;
            Assert.AreEqual(_databaseName, database.Data.Resource.DatabaseName);
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
            CosmosDBSqlDatabaseThroughputSettingResource throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            CosmosDBSqlDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo(TestThroughput2, null, null, null, null, null)))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
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
            Assert.IsFalse(exists);
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

        private void VerifyDatabases(CosmosDBSqlDatabaseResource expectedValue, CosmosDBSqlDatabaseResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.DatabaseName, actualValue.Data.Resource.DatabaseName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
            Assert.AreEqual(expectedValue.Data.Resource.Colls, actualValue.Data.Resource.Colls);
            Assert.AreEqual(expectedValue.Data.Resource.Users, actualValue.Data.Resource.Users);
        }
    }
}
