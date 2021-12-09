// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlContainerTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private ResourceIdentifier _sqlDatabaseId;
        private SqlDatabase _sqlDatabase;
        private string _containerName;

        public SqlContainerTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlContainerCollection SqlContainerCollection { get => _sqlDatabase.GetSqlContainers(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"));

            _sqlDatabaseId = (await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _sqlDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlDatabase = await ArmClient.GetSqlDatabase(_sqlDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlContainer container = await SqlContainerCollection.GetIfExistsAsync(_containerName);
            if (container != null)
            {
                await container.DeleteAsync();
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

            bool ifExists = await SqlContainerCollection.CheckIfExistsAsync(_containerName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingsData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            SqlContainer container2 = await SqlContainerCollection.GetAsync(_containerName);
            Assert.AreEqual(_containerName, container2.Data.Resource.Id);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlContainers(container, container2);

            SqlContainerCreateUpdateOptions updateOptions = new SqlContainerCreateUpdateOptions(container.Id, _containerName, container.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, container.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            container = await (await SqlContainerCollection.CreateOrUpdateAsync(_containerName, updateOptions)).WaitForCompletionAsync();
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
            DatabaseAccountSqlDatabaseContainerThroughputSetting throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            DatabaseAccountSqlDatabaseContainerThroughputSetting throughput2 = await throughput.CreateOrUpdate(new ThroughputSettingsUpdateOptions(Resources.Models.Location.WestUS,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerMigrateToAutoscale()
        {
            var container = await CreateSqlContainer(null);
            DatabaseAccountSqlDatabaseContainerThroughputSetting throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateSqlContainerToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerMigrateToManual()
        {
            var container = await CreateSqlContainer(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });

            DatabaseAccountSqlDatabaseContainerThroughputSetting throughput = await container.GetDatabaseAccountSqlDatabaseContainerThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingsData throughputData = await throughput.MigrateSqlContainerToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerRetrieveContinuousBackupInformation()
        {
            var container = await CreateSqlContainer(null);

            BackupInformation backupInfo =  await container.RetrieveContinuousBackupInformation(new ContinuousBackupRestoreLocation{ Location  = Resources.Models.Location.WestUS}).WaitForCompletionAsync();
            long restoreTime = DateTimeOffset.Parse(backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp).ToUnixTimeMilliseconds();
            Assert.True(restoreTime > 0);

            SqlContainerCreateUpdateOptions updateOptions = new SqlContainerCreateUpdateOptions(container.Id, _containerName, container.Data.Type,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                Resources.Models.Location.WestUS, container.Data.Resource, new CreateUpdateOptions { Throughput = TestThroughput2 });

            container = await (await SqlContainerCollection.CreateOrUpdateAsync(_containerName, updateOptions)).WaitForCompletionAsync();
            backupInfo =  await container.RetrieveContinuousBackupInformation(new ContinuousBackupRestoreLocation{ Location  = Resources.Models.Location.WestUS}).WaitForCompletionAsync();
            long latestRestoreTime = DateTimeOffset.Parse(backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp).ToUnixTimeMilliseconds();
            Assert.True(latestRestoreTime > 0);
            Assert.True(latestRestoreTime > restoreTime);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerDelete()
        {
            var container = await CreateSqlContainer(null);
            await container.DeleteAsync();

            container = await SqlContainerCollection.GetIfExistsAsync(_containerName);
            Assert.Null(container);
        }

        protected async Task<SqlContainer> CreateSqlContainer(AutoscaleSettings autoscale)
        {
            _containerName = Recording.GenerateAssetName("sql-container-");
            return await CreateSqlContainer(_containerName, autoscale, SqlContainerCollection);
        }
        internal static async Task<SqlContainer> CreateSqlContainer(string name, AutoscaleSettings autoscale, SqlContainerCollection sqlContainerCollection)
        {
            SqlContainerCreateUpdateOptions sqlDatabaseCreateUpdateOptions = new SqlContainerCreateUpdateOptions(Resources.Models.Location.WestUS,
                new SqlContainerResource(name)
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
            var sqlContainerLro = await sqlContainerCollection.CreateOrUpdateAsync(name, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlContainers(SqlContainer expectedValue, SqlContainer actualValue)
        {
            Assert.AreEqual(expectedValue.Data.Id, actualValue.Data.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IndexingMode, actualValue.Data.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Kind, actualValue.Data.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Paths, actualValue.Data.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Data.Resource.DefaultTtl, actualValue.Data.Resource.DefaultTtl);
        }
        protected async Task<DatabaseAccount> CreateDatabaseAccount(string name)
        {
            var locations = new List<DatabaseAccountLocation>()
            {
                new DatabaseAccountLocation(id: null, locationName: Resources.Models.Location.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createOptions = new DatabaseAccountCreateUpdateOptions(Resources.Models.Location.WestUS, locations)
            {
                Kind = DatabaseAccountKind.GlobalDocumentDB,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IpRules = { new IpAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = new ContinuousModeBackupPolicy(), // Point in time restore feature
            };
            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(_databaseAccountName, createOptions);
            return accountLro.Value;
        }
    }
}
