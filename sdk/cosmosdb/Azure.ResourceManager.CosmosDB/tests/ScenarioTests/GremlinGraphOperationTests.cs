// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Castle.Core.Resource;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class GremlinGraphOperationTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _gremlinDatabaseId;
        private GremlinDatabaseResource _gremlinDatabase;
        private string _graphName;

        public GremlinGraphOperationTests(bool isAsync) : base(isAsync)
        {
        }

        protected GremlinGraphCollection GremlinGraphContainer { get => _gremlinDatabase.GetGremlinGraphs(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            capabilities.Add(new CosmosDBAccountCapability("EnableGremlin", null));
            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB, capabilities, true);

            _gremlinDatabaseId = (await GremlinDatabaseTests.CreateGremlinDatabase(SessionRecording.GenerateAssetName("gremlin-db-"), null, _databaseAccount.GetGremlinDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await _gremlinDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _gremlinDatabase = await ArmClient.GetGremlinDatabaseResource(_gremlinDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await GremlinGraphContainer.ExistsAsync(_graphName))
                {
                    var id = GremlinGraphContainer.Id;
                    id = GremlinGraphResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Name, id.Name, _graphName);
                    GremlinGraphResource graph = this.ArmClient.GetGremlinGraphResource(id);
                    await graph.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphCreateAndUpdate()
        {
            var parameters = BuildCreateUpdateOptions(null);
            var grpah = await CreateGremlinGraph(parameters);
            Assert.AreEqual(_graphName, grpah.Data.Resource.GraphName);
            VerifyGremlinGraphCreation(grpah, parameters);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, table.Data.Options.Throughput);

            bool ifExists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await table.GetGremlinGraphThroughputAsync();
            GremlinGraphResource graph2 = await GremlinGraphContainer.GetAsync(_graphName);
            Assert.AreEqual(_graphName, graph2.Data.Resource.GraphName);
            VerifyGremlinGraphCreation(graph2, parameters);
            //Assert.AreEqual(TestThroughput1, table2.Data.Options.Throughput);

            VerifyGremlinGraphs(grpah, graph2);

            parameters.Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 };

            grpah = await (await GremlinGraphContainer.CreateOrUpdateAsync(WaitUntil.Started, _graphName, parameters)).WaitForCompletionAsync();
            Assert.AreEqual(_graphName, grpah.Data.Resource.GraphName);
            VerifyGremlinGraphCreation(grpah, parameters);
            // Seems bug in swagger definition
            graph2 = await GremlinGraphContainer.GetAsync(_graphName);
            VerifyGremlinGraphCreation(graph2, parameters);
            // Seems bug in swagger definition
            VerifyGremlinGraphs(grpah, graph2);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphRestoreTest()
        {
            var parameters = BuildCreateUpdateOptions(null);
            var graph = await CreateGremlinGraph(parameters);
            Assert.AreEqual(_graphName, graph.Data.Resource.GraphName);
            VerifyGremlinGraphCreation(graph, parameters);

            bool ifExists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.True(ifExists);

            var graphs = await GremlinGraphContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(graphs, Has.Count.EqualTo(1));
            Assert.AreEqual(graph.Data.Name, graphs[0].Data.Name);

            VerifyGremlinGraphs(graphs[0], graph);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            var restorableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.Data.AccountName == _databaseAccount.Data.Name);
            DateTimeOffset timestampInUtc = DateTimeOffset.FromUnixTimeSeconds((int)graph.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(180);

            String restoreSource = restorableDatabaseAccount.Id;
            ResourceRestoreParameters RestoreParameters = new ResourceRestoreParameters
            {
                RestoreSource = restoreSource,
                RestoreTimestampInUtc = timestampInUtc.AddSeconds(100)
            };

            await graph.DeleteAsync(WaitUntil.Completed);
            bool exists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.IsFalse(exists);

            GremlinGraphResourceInfo resource = new GremlinGraphResourceInfo(_graphName)
            {
                RestoreParameters = RestoreParameters,
                CreateMode = CosmosDBAccountCreateMode.Restore
            };
            var updateOptions = new GremlinGraphCreateOrUpdateContent(AzureLocation.WestUS, resource);
            var graph2 = await (await GremlinGraphContainer.CreateOrUpdateAsync(WaitUntil.Started, _graphName, updateOptions)).WaitForCompletionAsync();
            Assert.AreEqual(_graphName, graph2.Value.Data.Name);

            VerifyGremlinGraphs(graph, graph2, true);

            await graph.DeleteAsync(WaitUntil.Completed);
            exists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.IsFalse(exists);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphList()
        {
            var graph = await CreateGremlinGraph(null);

            var praphs = await GremlinGraphContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(praphs, Has.Count.EqualTo(1));
            Assert.AreEqual(graph.Data.Name, praphs[0].Data.Name);

            VerifyGremlinGraphs(praphs[0], graph);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphThroughput()
        {
            var graph = await CreateGremlinGraph(null);
            GremlinGraphThroughputSettingResource throughput = await graph.GetGremlinGraphThroughputSetting().GetAsync();

            Assert.AreEqual(TestThroughput1, throughput.Data.Resource.Throughput);

            GremlinGraphThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.AreEqual(TestThroughput2, throughput2.Data.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task GremlinGraphMigrateToAutoscale()
        {
            var graph = await CreateGremlinGraph(null);

            GremlinGraphThroughputSettingResource throughput = await graph.GetGremlinGraphThroughputSetting().GetAsync();
            AssertManualThroughput(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateGremlinGraphToAutoscaleAsync(WaitUntil.Completed)).Value.Data;
            AssertAutoscale(throughputData);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to diagnose The operation has not completed yet.")]
        public async Task GremlinGraphMigrateToManual()
        {
            var parameters = BuildCreateUpdateOptions(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });
            var graph = await CreateGremlinGraph(parameters);

            GremlinGraphThroughputSettingResource throughput = await graph.GetGremlinGraphThroughputSetting().GetAsync();
            AssertAutoscale(throughput.Data);

            ThroughputSettingData throughputData = (await throughput.MigrateGremlinGraphToManualThroughputAsync(WaitUntil.Completed)).Value.Data;
            AssertManualThroughput(throughputData);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphDelete()
        {
            var graph = await CreateGremlinGraph(null);
            await graph.DeleteAsync(WaitUntil.Completed);

            bool exists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.IsFalse(exists);
        }

        protected async Task<GremlinGraphResource> CreateGremlinGraph(GremlinGraphCreateOrUpdateContent parameters)
        {
            if (parameters == null)
            {
                parameters = BuildCreateUpdateOptions(null);
            }

            var graphLro = await GremlinGraphContainer.CreateOrUpdateAsync(WaitUntil.Completed, _graphName, parameters);
            return graphLro.Value;
        }

        private GremlinGraphCreateOrUpdateContent BuildCreateUpdateOptions(AutoscaleSettings autoscale)
        {
            _graphName = Recording.GenerateAssetName("gremlin-graph-");

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

            return new GremlinGraphCreateOrUpdateContent(AzureLocation.WestUS, new Models.GremlinGraphResourceInfo(_graphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy, null, restoreParameters: null, createMode: null, null)) {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        private void VerifyGremlinGraphCreation(GremlinGraphResource graph, GremlinGraphCreateOrUpdateContent gremlinGraphCreateUpdateOptions)
        {
            Assert.AreEqual(graph.Data.Resource.GraphName, gremlinGraphCreateUpdateOptions.Resource.GraphName);
            Assert.AreEqual(graph.Data.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower(), gremlinGraphCreateUpdateOptions.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower());
            Assert.AreEqual(graph.Data.Resource.PartitionKey.Kind, gremlinGraphCreateUpdateOptions.Resource.PartitionKey.Kind);
            Assert.AreEqual(graph.Data.Resource.PartitionKey.Paths, gremlinGraphCreateUpdateOptions.Resource.PartitionKey.Paths);
            Assert.AreEqual(graph.Data.Resource.DefaultTtl, gremlinGraphCreateUpdateOptions.Resource.DefaultTtl);
        }

        private void VerifyGremlinGraphs(GremlinGraphResource expectedValue, GremlinGraphResource actualValue, bool isRestoredGraph = false)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.GraphName, actualValue.Data.Resource.GraphName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);

            if (!isRestoredGraph)
            {
                Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
                Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
            }

            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.Mode, actualValue.Data.Resource.ConflictResolutionPolicy.Mode);

            Assert.AreEqual(expectedValue.Data.Resource.DefaultTtl, actualValue.Data.Resource.DefaultTtl);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IsAutomatic, actualValue.Data.Resource.IndexingPolicy.IsAutomatic);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths.Count, actualValue.Data.Resource.IndexingPolicy.IncludedPaths.Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Path, actualValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Indexes, actualValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Indexes);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.ExcludedPaths.Count, actualValue.Data.Resource.IndexingPolicy.ExcludedPaths.Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.ExcludedPaths[0].Path, actualValue.Data.Resource.IndexingPolicy.ExcludedPaths[0].Path);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes.Count, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes.Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0].Count, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0].Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Path, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Order, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Order);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Path, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Order, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Order);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1].Count, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1].Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Path, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Order, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Order);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Path, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Order, actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Order);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.IndexingMode, actualValue.Data.Resource.IndexingPolicy.IndexingMode);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes.Count, actualValue.Data.Resource.IndexingPolicy.SpatialIndexes.Count);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Path, actualValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Path);
            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Types, actualValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Types);

            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Kind, actualValue.Data.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Paths, actualValue.Data.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Data.Resource.PartitionKey.Version, actualValue.Data.Resource.PartitionKey.Version);

            Assert.AreEqual(expectedValue.Data.Resource.UniqueKeyPolicy.UniqueKeys.Count, actualValue.Data.Resource.UniqueKeyPolicy.UniqueKeys.Count);
            Assert.AreEqual(expectedValue.Data.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths, actualValue.Data.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths);
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
