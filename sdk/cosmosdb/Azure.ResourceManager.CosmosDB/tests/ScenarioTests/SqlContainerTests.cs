// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlContainerTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _sqlDatabaseId;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private string _containerName;

        public SqlContainerTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlContainerCollection SqlContainerCollection => _sqlDatabase.GetCosmosDBSqlContainers();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"));

            _sqlDatabaseId = (await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetCosmosDBSqlDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            await _sqlDatabase.DeleteAsync(WaitUntil.Completed);
            await _databaseAccount.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlDatabase = await ArmClient.GetCosmosDBSqlDatabaseResource(_sqlDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await SqlContainerCollection.ExistsAsync(_containerName))
            {
                var id = SqlContainerCollection.Id;
                id = CosmosDBSqlContainerResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _containerName);
                CosmosDBSqlContainerResource container = this.ArmClient.GetCosmosDBSqlContainerResource(id);
                await container.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerCreateAndUpdate()
        {
            var container = await CreateSqlContainer(null);
            Assert.AreEqual(_containerName, container.Data.Resource.ContainerName);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlContainerCollection.ExistsAsync(_containerName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await container.GetMongoDBCollectionThroughputAsync();
            CosmosDBSqlContainerResource container2 = await SqlContainerCollection.GetAsync(_containerName);
            Assert.AreEqual(_containerName, container2.Data.Resource.ContainerName);
            //Assert.AreEqual(TestThroughput1, container2.Data.Options.Throughput);

            VerifySqlContainers(container, container2);

            // TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
            var updateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestUS, container.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            container = (await SqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _containerName, updateOptions)).Value;
            Assert.AreEqual(_containerName, container.Data.Resource.ContainerName);
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
            CosmosDBSqlContainerThroughputSettingResource throughput = await container.GetCosmosDBSqlContainerThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            CosmosDBSqlContainerThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
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
            CosmosDBSqlContainerThroughputSettingResource throughput = await container.GetCosmosDBSqlContainerThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateSqlContainerToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
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

            CosmosDBSqlContainerThroughputSettingResource throughput = await container.GetCosmosDBSqlContainerThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateSqlContainerToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task SqlContainerRetrieveContinuousBackupInformation()
        {
            var container = await CreateSqlContainer(null);

            CosmosDBBackupInformation backupInfo = (await container.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, new ContinuousBackupRestoreLocation { Location = AzureLocation.WestUS })).Value;
            long restoreTime = backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp.Value.ToUnixTimeMilliseconds();
            Assert.True(restoreTime > 0);

            var updateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(container.Id, _containerName, container.Data.ResourceType, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, container.Data.Resource, new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }, default(ManagedServiceIdentity), null);

            container = (await SqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _containerName, updateOptions)).Value;
            backupInfo = (await container.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, new ContinuousBackupRestoreLocation { Location = AzureLocation.WestUS })).Value;
            long latestRestoreTime = backupInfo.ContinuousBackupInformation.LatestRestorableTimestamp.Value.ToUnixTimeMilliseconds();
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

        internal async Task<CosmosDBSqlContainerResource> CreateSqlContainer(AutoscaleSettings autoscale)
        {
            _containerName = Recording.GenerateAssetName("sql-container-");
            return await CreateSqlContainer(_containerName, autoscale, SqlContainerCollection);
        }
        internal static async Task<CosmosDBSqlContainerResource> CreateSqlContainer(string name, AutoscaleSettings autoscale, CosmosDBSqlContainerCollection sqlContainerCollection)
        {
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlContainerResourceInfo(name)
                {
                    PartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null, false, null)
                    {
                        Kind = new CosmosDBPartitionKind("Hash")
                    },
                    IndexingPolicy = new CosmosDBIndexingPolicy(
                        true,
                        CosmosDBIndexingMode.Consistent,
                        new List<CosmosDBIncludedPath>
                        {
                            new CosmosDBIncludedPath { Path = "/*"}
                        },
                        new List<CosmosDBExcludedPath>
                        {
                            new CosmosDBExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                        new List<IList<CosmosDBCompositePath>>
                        {
                            new List<CosmosDBCompositePath>
                            {
                                new CosmosDBCompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                                new CosmosDBCompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                            }
                        },
                        new List<SpatialSpec>
                        {
                            new SpatialSpec
                            (
                                    "/*",
                                    new List<CosmosDBSpatialType>
                                    {
                                        new CosmosDBSpatialType("Point")
                                    }, null),
                        }, null)
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await sqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlContainers(CosmosDBSqlContainerResource expectedValue, CosmosDBSqlContainerResource actualValue)
        {
            Assert.AreEqual(expectedValue.Data.Id, actualValue.Data.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.ContainerName, actualValue.Data.Resource.ContainerName);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IndexingMode, actualValue.Data.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Kind, actualValue.Data.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Paths, actualValue.Data.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Data.Resource.DefaultTtl, actualValue.Data.Resource.DefaultTtl);
        }
        protected async Task<CosmosDBAccountResource> CreateDatabaseAccount(string name)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = CosmosDBAccountKind.GlobalDocumentDB,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds, null),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120", null) },
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
