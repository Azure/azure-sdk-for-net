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
    internal class SqlPartitionMergeTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _databaseName;

        public SqlPartitionMergeTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlDatabaseCollection SqlDatabaseContainer => _databaseAccount.GetCosmosDBSqlDatabases();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            //BackupPolicy = new ContinuousModeBackupPolicy()
            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, null, enablePartitionMerge:true)).Id;
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
        public async Task SqlDatabasePartitionMerge()
        {
            var database = await CreateSqlDatabase(new AutoscaleSettings()
            {
                MaxThroughput = 12000,
            });

            //update throughput to lower value.
            CosmosDBSqlDatabaseThroughputSettingResource throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();
            ThroughputSettingData throughputData = (await throughput.MigrateSqlDatabaseToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            throughput = await database.GetCosmosDBSqlDatabaseThroughputSetting().GetAsync();
            CosmosDBSqlDatabaseThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
               new ThroughputSettingsResourceInfo(1000, null, null, null, null, null, null)))).Value;

            MergeParameters mergeParameters = new MergeParameters() { IsDryRun = true };
            try
            {
                PhysicalPartitionStorageInfoCollection physicalPartitionCollection = (await database.SqlDatabasePartitionMergeAsync(WaitUntil.Completed, mergeParameters)).Value;
                Assert.IsTrue(physicalPartitionCollection.PhysicalPartitionStorageInfoCollectionValue.Count == 1);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Merge feature is not available") || e.Message.Contains("Merge operation feature is not available/enabled"));
            }
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
    }
}
