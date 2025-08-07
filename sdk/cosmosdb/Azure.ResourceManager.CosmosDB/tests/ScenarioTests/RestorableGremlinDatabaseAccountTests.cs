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
    public class RestorableGremlinDatabaseAccountTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _restorableDatabaseAccount;
        private CosmosDBAccountResource _restoredDatabaseAccount;

        public RestorableGremlinDatabaseAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetup()
        {
            _restorableDatabaseAccount = null;
            _restoredDatabaseAccount = null;
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_restorableDatabaseAccount != null)
                {
                    await _restorableDatabaseAccount.DeleteAsync(WaitUntil.Completed);
                }

                if (_restoredDatabaseAccount != null)
                {
                    await _restoredDatabaseAccount.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task RestoreGremlinDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var databaseName = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database = await CreateGremlinDatabase(databaseName, null);

            var containerName = Recording.GenerateAssetName("graph-");
            GremlinGraphResource container = await CreateGremlinGraph(containerName, database, null);
            AddDelayInSeconds(60);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)container.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(60);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(60),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            _restoredDatabaseAccount = await RestoreAndVerifyRestoredAccount(restorableAccount, restoreParameters);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreGremlinGraph()
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
            var databaseName1 = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database1 = await CreateGremlinDatabase(databaseName1, null);

            var graphName1 = Recording.GenerateAssetName("graph-");
            GremlinGraphResource graph1 = await CreateGremlinGraph(graphName1, database1, null);
            AddDelayInSeconds(60);

            var databaseName2 = Recording.GenerateAssetName("graphdb-");
            GremlinDatabaseResource database2 = await CreateGremlinDatabase(databaseName2, null);

            var graphName2 = Recording.GenerateAssetName("graph-");
            GremlinGraphResource graph2 = await CreateGremlinGraph(graphName2, database2, null);
            AddDelayInSeconds(60);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)graph1.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(60);

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
            GremlinDatabaseRestoreResourceInfo restoreInfo = new GremlinDatabaseRestoreResourceInfo(restorableDatabase.Resource.DatabaseName, new List<string>() { restorableGraph.Resource.GraphName }, null);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreSource = restorableAccount.Id.ToString(),
                RestoreTimestampInUtc = ts.AddSeconds(60)
            };

            restoreParameters.GremlinDatabasesToRestore.Add(restoreInfo);

            _restoredDatabaseAccount = await RestoreAndVerifyRestoredAccount(restorableAccount, restoreParameters);

            // verifying restored database
            GremlinDatabaseResource restoredDatabase = await _restoredDatabaseAccount.GetGremlinDatabaseAsync(restorableDatabase.Resource.DatabaseName);
            Assert.NotNull(restoredDatabase);

            // verifying restored graph
            GremlinGraphResource restoredGraph = await restoredDatabase.GetGremlinGraphAsync(restorableGraph.Resource.GraphName);
            Assert.NotNull(restoredGraph);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableGremlinDatabaseAccountFeed()
        {
            await RestorableDatabaseAccountFeedTestHelperAsync("Gremlin, Sql", 1);
        }

        protected async Task<CosmosDBAccountResource> CreateRestorableDatabaseAccount(string name, CosmosDBAccountKind kind, bool isFreeTierEnabled = false, List<CosmosDBAccountCapability> capabilities = null, string apiVersion = null)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds, null),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120", null) },
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

        private async Task<CosmosDBAccountResource> RestoreAndVerifyRestoredAccount(RestorableCosmosDBAccountResource restorableAccount, CosmosDBAccountRestoreParameters restoreParameters, bool IsFreeTierEnabled = false)
        {
            CosmosDBAccountKind kind = CosmosDBAccountKind.GlobalDocumentDB;
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var restoredAccountName = Recording.GenerateAssetName("restoredaccount-");

            CosmosDBAccountCreateOrUpdateContent databaseAccountCreateUpdateParameters = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                CreateMode = CosmosDBAccountCreateMode.Restore,
                RestoreParameters = restoreParameters
            };
            databaseAccountCreateUpdateParameters.Tags.Add("key1", "value1");
            databaseAccountCreateUpdateParameters.Tags.Add("key2", "value2");
            databaseAccountCreateUpdateParameters.Capabilities.Add(new CosmosDBAccountCapability("EnableGremlin", null));
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
            _restorableDatabaseAccount = await GetDatabaseAccount();
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

        private async Task RestorableDatabaseAccountFeedTestHelperAsync(
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
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
                SpatialIndexes = { new SpatialSpec("/*", new List<CosmosDBSpatialType> { new CosmosDBSpatialType("Point") }, null) }
            };

            var containerPartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address" }, CosmosDBPartitionKind.Hash, null, null, null);
            var uniqueKeyPolicy = new CosmosDBUniqueKeyPolicy()
            {
                UniqueKeys = { new CosmosDBUniqueKey(new List<string>() { "/testpath" }, null) },
            };

            var conflictResolutionPolicy = new ConflictResolutionPolicy(ConflictResolutionMode.LastWriterWins, "/path", "", null);

            return new GremlinGraphCreateOrUpdateContent(AzureLocation.WestUS, new Models.GremlinGraphResourceInfo(graphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy, null, restoreParameters: null, createMode: null, null))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        public async Task<CosmosDBAccountResource> GetDatabaseAccount()
        {
            string accountName = Recording.GenerateAssetName("r-grem-db-account-");

            CosmosDBAccountResource account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableGremlin", null) }
                    );
            return account;
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
