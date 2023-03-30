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
using System.Threading;
using System.ComponentModel;
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class RestorableDatabaseAccountTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _restorableDatabaseAccount;
        public Dictionary<AccountType, string> accounts;

        public RestorableDatabaseAccountTests(bool isAsync) : base(isAsync)
        {
            this.accounts = new Dictionary<AccountType, string>();
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetup()
        {
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_restorableDatabaseAccount != null)
            {
                await _restorableDatabaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task RestorableDatabaseAccountList()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
        }

        [Test]
        [RecordedTest]
        [Ignore("Not recorded")]
        public async Task RestorableDatabaseAccountListByLocation()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB);
            CosmosDBLocationResource location = await (await ArmClient.GetDefaultSubscriptionAsync()).GetCosmosDBLocations().GetAsync(AzureLocation.WestUS);
            var restorableAccounts = await location.GetRestorableCosmosDBAccounts().GetAllAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
        }

        [Test]
        [RecordedTest]
        public async Task RestoreSqlDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.PitrSql);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var databaseName = Recording.GenerateAssetName("sql-database-");
            CosmosDBSqlDatabaseResource database = await CreateSqlDatabase(databaseName, null);

            var containerName = Recording.GenerateAssetName("sql-container-");
            CosmosDBSqlContainerResource container = await CreateSqlContainer(containerName, database, null);
            Thread.Sleep(60000);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)container.Data.Resource.Timestamp.Value);
            Thread.Sleep(10000);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(30),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            await RestoreAndVerifyRestoredAccount(AccountType.PitrSql, restorableAccount, restoreParameters);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreGremlinDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Gremlin);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var databaseName = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database = await CreateGremlinDatabase(databaseName, null);

            var containerName = Recording.GenerateAssetName("graph-");
            GremlinGraphResource container = await CreateGremlinGraph(containerName, database, null);
            Thread.Sleep(60000);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)container.Data.Resource.Timestamp.Value);
            Thread.Sleep(10000);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(30),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            await RestoreAndVerifyRestoredAccount(AccountType.Gremlin, restorableAccount, restoreParameters);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreGremlinGraph()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Gremlin);
            var databaseName1 = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database1 = await CreateGremlinDatabase(databaseName1, null);

            var graphName1 = Recording.GenerateAssetName("graph-");
            GremlinGraphResource graph1 = await CreateGremlinGraph(graphName1, database1, null);
            Thread.Sleep(60000);

            var databaseName2 = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database2 = await CreateGremlinDatabase(databaseName2, null);

            var graphName2 = Recording.GenerateAssetName("graph-");
            GremlinGraphResource graph2 = await CreateGremlinGraph(graphName2, database2, null);
            Thread.Sleep(60000);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)graph1.Data.Resource.Timestamp.Value);
            Thread.Sleep(30000);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            // Fetching restorable databases and graph feed
            var restorableDatabases = await restorableAccount.GetRestorableGremlinDatabasesAsync().ToEnumerableAsync();
            Assert.True(restorableDatabases.Count == 2);
            RestorableGremlinDatabase restorableDatabase = restorableDatabases.Single(database => database.Resource.DatabaseName == databaseName1);
            var restorableGraphs = await restorableAccount.GetRestorableGremlinGraphsAsync(restorableDatabase.Resource.DatabaseId).ToEnumerableAsync();
            Assert.True(restorableGraphs.Count == 1);
            RestorableGremlinGraph restorableGraph = restorableGraphs.Single(graph => graph.Resource.GraphName == graphName1);

            // building restore info to restore only database1 and graph1
            GremlinDatabaseRestoreResourceInfo restoreInfo = new GremlinDatabaseRestoreResourceInfo(restorableDatabase.Resource.DatabaseName, new List<string>() { restorableGraph.Resource.GraphName });

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreSource = restorableAccount.Id.ToString(),
                RestoreTimestampInUtc = ts.AddSeconds(30)
            };

            restoreParameters.GremlinDatabasesToRestore.Add(restoreInfo);

            CosmosDBAccountResource restoredAccount = await RestoreAndVerifyRestoredAccount(AccountType.Gremlin, restorableAccount, restoreParameters);

            // verifying restored database
            GremlinDatabaseResource restoredDatabase = await restoredAccount.GetGremlinDatabaseAsync(restorableDatabase.Resource.DatabaseName);
            Assert.NotNull(restoredDatabase);

            // verifying restored graph
            GremlinGraphResource restoredGraph = await restoredDatabase.GetGremlinGraphAsync(restorableGraph.Resource.GraphName);
            Assert.NotNull(restoredGraph);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreTableDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Table);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var tableName = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table = await CreateTable(tableName, null);
            Thread.Sleep(60000);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)table.Data.Resource.Timestamp.Value);
            Thread.Sleep(10000);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(50),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            await RestoreAndVerifyRestoredAccount(AccountType.Table, restorableAccount, restoreParameters);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreTable()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Table);

            var tableName1 = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table1 = await CreateTable(tableName1, null);
            Thread.Sleep(60000);

            var tableName2 = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table2 = await CreateTable(tableName2, null);
            Thread.Sleep(60000);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)table1.Data.Resource.Timestamp.Value);
            Thread.Sleep(30000);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            // Fetching restorable tables
            var restorableTables = await restorableAccount.GetRestorableTablesAsync().ToEnumerableAsync();
            Assert.True(restorableTables.Count == 2);

            // Building restore parameter to restore table1
            RestorableTable restorableTable = restorableTables.Single(table => table.Resource.TableName == tableName1);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreSource = restorableAccount.Id.ToString(),
                RestoreTimestampInUtc = ts.AddSeconds(30)
            };

            restoreParameters.TablesToRestore.Add(restorableTable.Resource.TableName);

            CosmosDBAccountResource restoredAccount = await RestoreAndVerifyRestoredAccount(AccountType.Table, restorableAccount, restoreParameters);

            // verifying restored table
            CosmosDBTableResource restoredTable = await restoredAccount.GetCosmosDBTableAsync(restorableTable.Resource.TableName);
            Assert.NotNull(restoredTable);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableGremlinDatabaseAccountFeed()
        {
            await RestorableDatabaseAccountFeedTestHelperAsync(AccountType.Gremlin, "Gremlin, Sql", 1);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableTableDatabaseAccountFeed()
        {
            await RestorableDatabaseAccountFeedTestHelperAsync(AccountType.Table, "Table, Sql", 1);
        }
        // TODO: more tests after fixing the code generation issue

        protected async Task<CosmosDBAccountResource> CreateRestorableDatabaseAccount(string name, CosmosDBAccountKind kind, bool isFreeTierEnabled = false, List<CosmosDBAccountCapability> capabilities = null, string apiVersion = null)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = new ContinuousModeBackupPolicy(),
                IsFreeTierEnabled = isFreeTierEnabled,
            };

            if (capabilities != null)
            {
                capabilities.ForEach(x => createOptions.Capabilities.Add(x));
            }

            if (apiVersion != null)
            {
                createOptions.ApiServerVersion = apiVersion;
            }

            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseAccountName, createOptions);
            return accountLro.Value;
        }

        private async Task<CosmosDBAccountResource> RestoreAndVerifyRestoredAccount(AccountType accountType, RestorableCosmosDBAccountResource restorableAccount, CosmosDBAccountRestoreParameters restoreParameters, bool IsFreeTierEnabled = false)
        {
            CosmosDBAccountKind kind = CosmosDBAccountKind.GlobalDocumentDB;
            if (accountType == AccountType.Mongo32 || accountType == AccountType.Mongo36)
            {
                kind = CosmosDBAccountKind.MongoDB;
            }
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var restoredAccountName = Recording.GenerateAssetName("restoredaccount-");

            //ResourceIdentifier Id = CosmosDBAccountResource.CreateResourceIdentifier(_restorableDatabaseAccount.Id.SubscriptionId, _restorableDatabaseAccount.Id.ResourceGroupName, restoredAccountName);

            CosmosDBAccountCreateOrUpdateContent databaseAccountCreateUpdateParameters = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                CreateMode = CosmosDBAccountCreateMode.Restore,
                RestoreParameters = restoreParameters
            };
            databaseAccountCreateUpdateParameters.Tags.Add("key1", "value1");
            databaseAccountCreateUpdateParameters.Tags.Add("key2", "value2");
            if (accountType == AccountType.Gremlin)
            {
                databaseAccountCreateUpdateParameters.Capabilities.Add(new CosmosDBAccountCapability("EnableGremlin"));
            }

            if (accountType == AccountType.Table)
            {
                databaseAccountCreateUpdateParameters.Capabilities.Add(new CosmosDBAccountCapability("EnableTable"));
            }

            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, restoredAccountName, databaseAccountCreateUpdateParameters);
            CosmosDBAccountResource restoredDatabaseAccount = accountLro.Value;
            Assert.NotNull(restoredDatabaseAccount);
            Assert.NotNull(restoredDatabaseAccount.Data.RestoreParameters);
            Assert.AreEqual(restoredDatabaseAccount.Data.RestoreParameters.RestoreSource.ToLower(), restorableAccount.Id.ToString().ToLower());
            Assert.True(restoredDatabaseAccount.Data.BackupPolicy is ContinuousModeBackupPolicy);

            ContinuousModeBackupPolicy policy = restoredDatabaseAccount.Data.BackupPolicy as ContinuousModeBackupPolicy;
            Assert.AreEqual(_restorableDatabaseAccount.Data.BackupPolicy.BackupPolicyType, policy.BackupPolicyType);
            Assert.AreEqual(IsFreeTierEnabled, restoredDatabaseAccount.Data.IsFreeTierEnabled);

            return restoredDatabaseAccount;
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphRetrieveContinuousBackupInformation()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Gremlin);
            Resources.SubscriptionResource subscriptionResource = await ArmClient.GetDefaultSubscriptionAsync();
            var restorableAccounts = await subscriptionResource.GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var databaseName = Recording.GenerateAssetName("database");
            GremlinDatabaseResource database = await CreateGremlinDatabase(databaseName, null);

            var containerName = Recording.GenerateAssetName("container");
            GremlinGraphResource container = await CreateGremlinGraph(containerName, database, null);
            ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation()
            {
                Location = restorableAccount.Data.Location
            };
            var backupInformation = await container.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, restoreLocation);

            DateTime? oldTime = _restorableDatabaseAccount.Data.SystemData.CreatedOn.Value.DateTime;
            Assert.NotNull(oldTime);

            Assert.NotNull(backupInformation);
            Assert.NotNull(backupInformation.Value.ContinuousBackupInformation);
            Assert.True(backupInformation.Value.ContinuousBackupInformation.LatestRestorableTimestamp.Value.DateTime > oldTime);
        }

        [Test]
        [RecordedTest]
        public async Task TableRetrieveContinuousBackupInformation()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.Table);
            Resources.SubscriptionResource subscriptionResource = await ArmClient.GetDefaultSubscriptionAsync();
            var restorableAccounts = await subscriptionResource.GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var tableName = Recording.GenerateAssetName("table");
            CosmosDBTableResource table = await CreateTable(tableName, null);
            ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation()
            {
                Location = restorableAccount.Data.Location
            };
            var backupInformation = await table.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, restoreLocation);

            DateTime? oldTime = _restorableDatabaseAccount.Data.SystemData.CreatedOn.Value.DateTime;
            Assert.NotNull(oldTime);

            Assert.NotNull(backupInformation);
            Assert.NotNull(backupInformation.Value.ContinuousBackupInformation);
            Assert.True(backupInformation.Value.ContinuousBackupInformation.LatestRestorableTimestamp.Value.DateTime > oldTime);
        }

        private async Task RestorableDatabaseAccountFeedTestHelperAsync(
            AccountType accountType,
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(accountType);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);
            ValidateRestorableDatabaseAccount(restorableAccount, sourceApiType, expectedRestorableLocationCount);
        }

        private void ValidateRestorableDatabaseAccount(
            RestorableCosmosDBAccountResource restorableDatabaseAccount,
            string expectedApiType,
            int expectedRestorableLocations)
        {
            Assert.AreEqual(expectedApiType, restorableDatabaseAccount.Data.ApiType.Value.ToString());
            Assert.AreEqual(expectedRestorableLocations, restorableDatabaseAccount.Data.RestorableLocations.Count);
            Assert.AreEqual("Microsoft.DocumentDB/locations/restorableDatabaseAccounts", restorableDatabaseAccount.Data.ResourceType.ToString());
            Assert.AreEqual(_restorableDatabaseAccount.Data.Location, restorableDatabaseAccount.Data.Location);
            Assert.AreEqual(_restorableDatabaseAccount.Data.Name, restorableDatabaseAccount.Data.AccountName);
            Assert.True(restorableDatabaseAccount.Data.CreatedOn.HasValue);
        }

        internal async Task<CosmosDBSqlDatabaseResource> CreateSqlDatabase(string databaseName, AutoscaleSettings autoscale)
        {
            return await CreateSqlDatabase(databaseName, autoscale, _restorableDatabaseAccount.GetCosmosDBSqlDatabases());
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

        internal async Task<CosmosDBSqlContainerResource> CreateSqlContainer(string containerName, CosmosDBSqlDatabaseResource database,  AutoscaleSettings autoscale)
        {
            return await CreateSqlContainer(containerName, autoscale, database.GetCosmosDBSqlContainers());
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

        internal async Task<GremlinDatabaseResource> CreateGremlinDatabase(string databaseName, AutoscaleSettings autoscale)
        {
            return await CreateGremlinDatabase(databaseName, autoscale, _restorableDatabaseAccount.GetGremlinDatabases());
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

        protected async Task<GremlinGraphResource> CreateGremlinGraph(string graphName, GremlinDatabaseResource database, GremlinGraphCreateOrUpdateContent parameters)
        {
            if (parameters == null)
            {
                parameters = BuildCreateUpdateOptions(graphName, null);
            }

            GremlinGraphCollection gremlinGraphCollection = database.GetGremlinGraphs();
            var graphLro = await gremlinGraphCollection.CreateOrUpdateAsync(WaitUntil.Completed, graphName, parameters);
            return graphLro.Value;
        }

        private GremlinGraphCreateOrUpdateContent BuildCreateUpdateOptions(string graphName, AutoscaleSettings autoscale)
        {
            var indexingPolicy = new CosmosDBIndexingPolicy()
            {
                IsAutomatic = true,
                IndexingMode = CosmosDBIndexingMode.Consistent,
                IncludedPaths = { new CosmosDBIncludedPath { Path = "/*" } },
                ExcludedPaths = { new CosmosDBExcludedPath { Path = "/pathToNotIndex/*" } },
                CompositeIndexes = {
                    new List<CosmosDBCompositePath>
                    {
                        new CosmosDBCompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                        new CosmosDBCompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                    },
                    new List<CosmosDBCompositePath>
                    {
                        new CosmosDBCompositePath { Path = "/orderByPath3", Order = CompositePathSortOrder.Ascending },
                        new CosmosDBCompositePath { Path = "/orderByPath4", Order = CompositePathSortOrder.Descending }
                    }
                },
                SpatialIndexes = { new SpatialSpec("/*", new List<CosmosDBSpatialType> { new CosmosDBSpatialType("Point") }) }
            };

            var containerPartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address" }, CosmosDBPartitionKind.Hash, null, null);
            var uniqueKeyPolicy = new CosmosDBUniqueKeyPolicy()
            {
                UniqueKeys = { new CosmosDBUniqueKey(new List<string>() { "/testpath" }) },
            };

            var conflictResolutionPolicy = new ConflictResolutionPolicy(ConflictResolutionMode.LastWriterWins, "/path", "");

            return new GremlinGraphCreateOrUpdateContent(AzureLocation.WestUS, new Models.GremlinGraphResourceInfo(graphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy, null))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        internal async Task<CosmosDBTableResource> CreateTable(string tableName, AutoscaleSettings autoscale)
        {
            return await CreateTable(tableName, autoscale, _restorableDatabaseAccount.GetCosmosDBTables());
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

        public enum AccountType
        {
            PitrSql,
            Pitr7Sql,
            Sql,
            Mongo32,
            Mongo36,
            Table,
            Cassandra,
            Gremlin
        }

        public async Task<CosmosDBAccountResource> GetDatabaseAccountForSpecificAPI(AccountType accountType)
        {
            CosmosDBAccountResource account = null;
            string accountName = Recording.GenerateAssetName("r-database-account-");

            if (accountType == AccountType.PitrSql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB
                );
            }
            if (accountType == AccountType.Pitr7Sql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    isFreeTierEnabled: true
                );
            }
            else if (accountType == AccountType.Sql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB
                );
            }
            else if (accountType == AccountType.Mongo32)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.MongoDB,
                    apiVersion: "3.2"
                );
            }
            else if (accountType == AccountType.Mongo36)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.MongoDB,
                    capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableMongo"), new CosmosDBAccountCapability("EnableMongoRoleBasedAccessControl") },
                    apiVersion: "3.6"
                );
            }
            else if (accountType == AccountType.Table)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableTable")}
                );
            }
            else if (accountType == AccountType.Cassandra)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableCassandra") }
                );
            }
            else if (accountType == AccountType.Gremlin)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableGremlin") }
                );
            }
            return account;
        }
    }
}
