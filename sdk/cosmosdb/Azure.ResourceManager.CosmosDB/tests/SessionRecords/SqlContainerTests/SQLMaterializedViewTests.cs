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
    public class SQLMaterializedViewTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _sqlDatabaseId;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private string _srcContainerName;
        private string _mvContainerName;

        public SQLMaterializedViewTests(bool isAsync) : base(isAsync)
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
            if (await SqlContainerCollection.ExistsAsync(_mvContainerName))
            {
                var id = SqlContainerCollection.Id;
                id = CosmosDBSqlContainerResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _mvContainerName);
                CosmosDBSqlContainerResource container = this.ArmClient.GetCosmosDBSqlContainerResource(id);
                await container.DeleteAsync(WaitUntil.Completed);
            }
            if (await SqlContainerCollection.ExistsAsync(_srcContainerName))
            {
                var id = SqlContainerCollection.Id;
                id = CosmosDBSqlContainerResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _srcContainerName);
                CosmosDBSqlContainerResource container = this.ArmClient.GetCosmosDBSqlContainerResource(id);
                await container.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlMaterializedViewContainerCreateAndUpdate()
        {
            var container = await CreateSqlContainer(null);
            Assert.AreEqual(_srcContainerName, container.Data.Resource.ContainerName);

            bool ifExists = await SqlContainerCollection.ExistsAsync(_srcContainerName);
            Assert.True(ifExists);

            CosmosDBSqlContainerResource container2 = await SqlContainerCollection.GetAsync(_srcContainerName);
            Assert.AreEqual(_srcContainerName, container2.Data.Resource.ContainerName);

            VerifySqlContainers(container, container2);

            var materializedViewContainer = await CreateSqlMaterializedViewContainer(_srcContainerName, container.Data.Resource.Rid);
            Assert.AreEqual(_mvContainerName, materializedViewContainer.Data.Resource.ContainerName);

            CosmosDBSqlContainerResource materializedViewContainer2 = await SqlContainerCollection.GetAsync(_mvContainerName);
            Assert.AreEqual(_mvContainerName, materializedViewContainer2.Data.Resource.ContainerName);

            VerifySqlContainers(materializedViewContainer, materializedViewContainer2);

            var updateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestUS, materializedViewContainer.Data.Resource)
            {
                Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 }
            };

            materializedViewContainer = (await SqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _mvContainerName, updateOptions)).Value;
            Assert.AreEqual(_mvContainerName, materializedViewContainer.Data.Resource.ContainerName);

            materializedViewContainer2 = await SqlContainerCollection.GetAsync(_mvContainerName);
            VerifySqlContainers(materializedViewContainer, materializedViewContainer2);

            CosmosDBSqlContainerThroughputSettingResource throughput = await materializedViewContainer2.GetCosmosDBSqlContainerThroughputSetting().GetAsync();
            Assert.AreEqual(TestThroughput2, throughput.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task SqlMaterializedViewContainerInternalAPI()
        {
            var container = await CreateSqlContainer(null);
            var materializedViewContainer = await CreateSqlMaterializedViewContainer(_srcContainerName, container.Data.Resource.Rid, testInternalAPI: true);

            Assert.AreEqual(_mvContainerName, materializedViewContainer.Data.Resource.ContainerName);
        }

        [Test]
        [RecordedTest]
        public async Task SqlMVContainerDelete()
        {
            var container = await CreateSqlContainer(null);
            var materializedViewContainer = await CreateSqlMaterializedViewContainer(_srcContainerName);

            try
            {
                await container.DeleteAsync(WaitUntil.Completed);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Delete not allowed on collections with materialized views. Retry after deleting associated materialized views"));
            }

            await materializedViewContainer.DeleteAsync(WaitUntil.Completed);
            await container.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlContainerCollection.ExistsAsync(_srcContainerName);
            Assert.IsFalse(exists);
        }

        internal async Task<CosmosDBSqlContainerResource> CreateSqlContainer(AutoscaleSettings autoscale)
        {
            _srcContainerName = Recording.GenerateAssetName("sql-container-");
            return await CreateSqlContainer(_srcContainerName, autoscale, SqlContainerCollection);
        }
        internal static async Task<CosmosDBSqlContainerResource> CreateSqlContainer(string name, AutoscaleSettings autoscale, CosmosDBSqlContainerCollection sqlContainerCollection)
        {
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlContainerResourceInfo(name)
                {
                    PartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null, false)
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

        internal async Task<CosmosDBSqlContainerResource> CreateSqlMaterializedViewContainer(string srcContainerName,
            string srcContainerRid = null, bool testInternalAPI = false)
        {
            _mvContainerName = Recording.GenerateAssetName("mv-sql-container-");
            return await CreateSqlMaterializedViewContainer(_mvContainerName, srcContainerName, srcContainerRid, SqlContainerCollection, testInternalAPI);
        }

        internal static async Task<CosmosDBSqlContainerResource> CreateSqlMaterializedViewContainer(string mvName, string srcContainerName,
            string srcContainerRid, CosmosDBSqlContainerCollection sqlContainerCollection, bool testInternalAPI)
        {
            var sqlContainerCreateUpdateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlContainerResourceInfo(mvName)
                {
                    PartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null, false)
                    {
                        Kind = new CosmosDBPartitionKind("Hash")
                    },
                    MaterializedViewDefinition = testInternalAPI ? new MaterializedViewDefinition(srcContainerRid, srcContainerName, "select * from root") :
                        new MaterializedViewDefinition(srcContainerName, "select * from root")
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, null),
            };

            var sqlContainerLro = await sqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, mvName, sqlContainerCreateUpdateOptions);
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
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = CosmosDBAccountKind.GlobalDocumentDB,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                EnableMaterializedViews = true,
            };
            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseAccountName, createOptions);
            return accountLro.Value;
        }
    }
}
