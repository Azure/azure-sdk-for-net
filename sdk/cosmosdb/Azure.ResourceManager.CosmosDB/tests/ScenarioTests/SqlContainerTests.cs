// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlContainerTests : CosmosDBManagementClientBase
    {
        private DatabaseAccountResource _databaseAccount;
        private ResourceIdentifier _sqlDatabaseId;
        private SqlDatabaseResource _sqlDatabase;
        private string _containerName;

        public SqlContainerTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlContainerCollection SqlContainerCollection => _sqlDatabase.GetSqlContainers();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"));

            _sqlDatabaseId = (await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _sqlDatabase.Delete(WaitUntil.Completed);
            _databaseAccount.Delete(WaitUntil.Completed);
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlDatabase = await ArmClient.GetSqlDatabaseResource(_sqlDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await SqlContainerCollection.ExistsAsync(_containerName))
            {
                var id = SqlContainerCollection.Id;
                id = SqlContainerResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _containerName);
                SqlContainerResource container = this.ArmClient.GetSqlContainerResource(id);
                await container.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerCreateAndUpdate()
        {
            var container = await CreateSqlContainer(null);
            Assert.AreEqual(_containerName, container.Data.Resource.Id);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlContainerCollection.ExistsAsync(_containerName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            SqlContainerResource container2 = await SqlContainerCollection.GetAsync(_containerName);
            Assert.AreEqual(_containerName, container2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlContainers(container, container2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new SqlContainerCreateOrUpdateContent(AzureLocation.WestUS, container.Data.Resource)
            {
                Options = new CreateUpdateOptions { Throughput = TestThroughput2 }
            };

            container = (await SqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _containerName, updateOptions)).Value;
            Assert.AreEqual(_containerName, container.Data.Resource.Id);
            container2 = await SqlContainerCollection.GetAsync(_containerName);
            VerifySqlContainers(container, container2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerList()
        {
            var container = await CreateSqlContainer(null);

            var containers = await SqlContainerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(containers, Has.Count.EqualTo(1));
            Assert.AreEqual(container.Data.Name, containers[0].Data.Name);

            VerifySqlContainers(containers[0], container);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerThroughput()
        {
            var container = await CreateSqlContainer(null);
            DatabaseAccountSqlDatabaseContainerThroughputSettingResource throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountSqlDatabaseContainerThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResource()
                {
                    Throughput = TestThroughput2,
                }))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task SqlContainerMigrateToAutoscale()
        {
            var container = await CreateSqlContainer(null);
            DatabaseAccountSqlDatabaseContainerThroughputSettingResource throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = (await throughput.MigrateSqlContainerToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task SqlContainerMigrateToManual()
        {
            var container = await CreateSqlContainer(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountSqlDatabaseContainerThroughputSettingResource throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = (await throughput.MigrateSqlContainerToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerRetrieveContinuousBackupInformation()
        {
            var container = await CreateSqlContainer(null);

            BackupInformation backupInfo = (await container.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, new ContinuousBackupRestoreLocation { Location = AzureLocation.WestUS })).Value;
            long restoreTime = DateTimeOffset.Parse(backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp).ToUnixTimeMilliseconds();
            Assert.True(restoreTime > 0);

            var updateOptions = new SqlContainerCreateOrUpdateContent(container.Id, _containerName, container.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, container.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            container = (await SqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _containerName, updateOptions)).Value;
            backupInfo = (await container.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, new ContinuousBackupRestoreLocation { Location = AzureLocation.WestUS })).Value;
            long latestRestoreTime = DateTimeOffset.Parse(backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp).ToUnixTimeMilliseconds();
            Assert.True(latestRestoreTime > 0);
            Assert.True(latestRestoreTime > restoreTime);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerDelete()
        {
            var container = await CreateSqlContainer(null);
            await container.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlContainerCollection.ExistsAsync(_containerName);
            Assert.IsFalse(exists);
        }

        internal async Task<SqlContainerResource> CreateSqlContainer(AutoscaleSettings autoscale)
        {
            _containerName = Recording.GenerateAssetName("sql-container-");
            return await CreateSqlContainer(_containerName, autoscale, SqlContainerCollection);
        }
        internal static async Task<SqlContainerResource> CreateSqlContainer(string name, AutoscaleSettings autoscale, SqlContainerCollection sqlContainerCollection)
        {
            var sqlDatabaseCreateUpdateOptions = new SqlContainerCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.SqlContainerResource(name)
                {
                    PartitionKey = new ContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null, false)
                    {
                        Kind = new PartitionKind("Hash")
                    },
                    IndexingPolicy = new IndexingPolicy(
                        true,
                        IndexingMode.Consistent,
                        new List<IncludedPath>
                        {
                            new IncludedPath { Path = "/*"}
                        },
                        new List<ExcludedPath>
                        {
                            new ExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                        new List<IList<CompositePath>>
                        {
                            new List<CompositePath>
                            {
                                new CompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                                new CompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                            }
                        },
                        new List<SpatialSpec>
                        {
                            new SpatialSpec
                            (
                                    "/*",
                                    new List<SpatialType>
                                    {
                                        new SpatialType("Point")
                                    }
                            ),
                        }
                    )
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await sqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlContainers(SqlContainerResource expectedValue, SqlContainerResource actualValue)
        {
            Assert.AreEqual(expectedValue.Data.Id, actualValue.Data.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IndexingMode, actualValue.Data.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Kind, actualValue.Data.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Paths, actualValue.Data.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Data.Resource.DefaultTtl, actualValue.Data.Resource.DefaultTtl);
        }
        protected async Task<DatabaseAccountResource> CreateDatabaseAccount(string name)
        {
            var locations = new List<DatabaseAccountLocation>()
            {
                new DatabaseAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createOptions = new DatabaseAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = DatabaseAccountKind.GlobalDocumentDB,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IPRules = { new IPAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = new ContinuousModeBackupPolicy(), // Point in time restore feature
            };
            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseAccountName, createOptions);
            return accountLro.Value;
        }
    }
}
