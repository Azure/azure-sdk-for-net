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
            Assert.That(grpah.Data.Resource.GraphName, Is.EqualTo(_graphName));
            VerifyGremlinGraphCreation(grpah, parameters);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, table.Data.Options.Throughput);

            bool ifExists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.That(ifExists, Is.True);

            // NOT WORKING API
            //ThroughputSettingData throughtput = await table.GetGremlinGraphThroughputAsync();
            GremlinGraphResource graph2 = await GremlinGraphContainer.GetAsync(_graphName);
            Assert.That(graph2.Data.Resource.GraphName, Is.EqualTo(_graphName));
            VerifyGremlinGraphCreation(graph2, parameters);
            //Assert.AreEqual(TestThroughput1, table2.Data.Options.Throughput);

            VerifyGremlinGraphs(grpah, graph2);

            parameters.Options = new CosmosDBCreateUpdateConfig { Throughput = TestThroughput2 };

            grpah = await (await GremlinGraphContainer.CreateOrUpdateAsync(WaitUntil.Started, _graphName, parameters)).WaitForCompletionAsync();
            Assert.That(grpah.Data.Resource.GraphName, Is.EqualTo(_graphName));
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
            Assert.That(graph.Data.Resource.GraphName, Is.EqualTo(_graphName));
            VerifyGremlinGraphCreation(graph, parameters);

            bool ifExists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.That(ifExists, Is.True);

            var graphs = await GremlinGraphContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(graphs, Has.Count.EqualTo(1));
            Assert.That(graphs[0].Data.Name, Is.EqualTo(graph.Data.Name));

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
            Assert.That(exists, Is.False);

            GremlinGraphResourceInfo resource = new GremlinGraphResourceInfo(_graphName)
            {
                RestoreParameters = RestoreParameters,
                CreateMode = CosmosDBAccountCreateMode.Restore
            };
            var updateOptions = new GremlinGraphCreateOrUpdateContent(AzureLocation.WestUS, resource);
            var graph2 = await (await GremlinGraphContainer.CreateOrUpdateAsync(WaitUntil.Started, _graphName, updateOptions)).WaitForCompletionAsync();
            Assert.That(graph2.Value.Data.Name, Is.EqualTo(_graphName));

            VerifyGremlinGraphs(graph, graph2, true);

            await graph.DeleteAsync(WaitUntil.Completed);
            exists = await GremlinGraphContainer.ExistsAsync(_graphName);
            Assert.That(exists, Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphList()
        {
            var graph = await CreateGremlinGraph(null);

            var praphs = await GremlinGraphContainer.GetAllAsync().ToEnumerableAsync();
            Assert.That(praphs, Has.Count.EqualTo(1));
            Assert.That(praphs[0].Data.Name, Is.EqualTo(graph.Data.Name));

            VerifyGremlinGraphs(praphs[0], graph);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphThroughput()
        {
            var graph = await CreateGremlinGraph(null);
            GremlinGraphThroughputSettingResource throughput = await graph.GetGremlinGraphThroughputSetting().GetAsync();

            Assert.That(throughput.Data.Resource.Throughput, Is.EqualTo(TestThroughput1));

            GremlinGraphThroughputSettingResource throughput2 = (await throughput.CreateOrUpdateAsync(WaitUntil.Completed, new ThroughputSettingsUpdateData(AzureLocation.WestUS,
                new ThroughputSettingsResourceInfo()
                {
                    Throughput = TestThroughput2
                }))).Value;

            Assert.That(throughput2.Data.Resource.Throughput, Is.EqualTo(TestThroughput2));
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
            Assert.That(exists, Is.False);
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
            Assert.That(gremlinGraphCreateUpdateOptions.Resource.GraphName, Is.EqualTo(graph.Data.Resource.GraphName));
            Assert.That(gremlinGraphCreateUpdateOptions.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower(), Is.EqualTo(graph.Data.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower()));
            Assert.That(gremlinGraphCreateUpdateOptions.Resource.PartitionKey.Kind, Is.EqualTo(graph.Data.Resource.PartitionKey.Kind));
            Assert.That(gremlinGraphCreateUpdateOptions.Resource.PartitionKey.Paths, Is.EqualTo(graph.Data.Resource.PartitionKey.Paths));
            Assert.That(gremlinGraphCreateUpdateOptions.Resource.DefaultTtl, Is.EqualTo(graph.Data.Resource.DefaultTtl));
        }

        private void VerifyGremlinGraphs(GremlinGraphResource expectedValue, GremlinGraphResource actualValue, bool isRestoredGraph = false)
        {
            Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
            Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
            Assert.That(actualValue.Data.Location, Is.EqualTo(expectedValue.Data.Location));
            Assert.That(actualValue.Data.Tags, Is.EqualTo(expectedValue.Data.Tags));
            Assert.That(actualValue.Data.ResourceType, Is.EqualTo(expectedValue.Data.ResourceType));

            Assert.That(actualValue.Data.Options, Is.EqualTo(expectedValue.Data.Options));

            Assert.That(actualValue.Data.Resource.GraphName, Is.EqualTo(expectedValue.Data.Resource.GraphName));
            Assert.That(actualValue.Data.Resource.Rid, Is.EqualTo(expectedValue.Data.Resource.Rid));

            if (!isRestoredGraph)
            {
                Assert.That(actualValue.Data.Resource.Timestamp, Is.EqualTo(expectedValue.Data.Resource.Timestamp));
                Assert.That(actualValue.Data.Resource.ETag, Is.EqualTo(expectedValue.Data.Resource.ETag));
            }

            Assert.That(actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, Is.EqualTo(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath));
            Assert.That(actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, Is.EqualTo(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath));
            Assert.That(actualValue.Data.Resource.ConflictResolutionPolicy.Mode, Is.EqualTo(expectedValue.Data.Resource.ConflictResolutionPolicy.Mode));

            Assert.That(actualValue.Data.Resource.DefaultTtl, Is.EqualTo(expectedValue.Data.Resource.DefaultTtl));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.IsAutomatic, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.IsAutomatic));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.IncludedPaths.Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths.Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Indexes, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.IncludedPaths[0].Indexes));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.ExcludedPaths.Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.ExcludedPaths.Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.ExcludedPaths[0].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.ExcludedPaths[0].Path));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes.Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes.Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0].Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0].Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Order, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][0].Order));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Order, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[0][1].Order));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1].Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1].Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Order, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][0].Order));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Order, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.CompositeIndexes[1][1].Order));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.IndexingMode, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.IndexingMode));

            Assert.That(actualValue.Data.Resource.IndexingPolicy.SpatialIndexes.Count, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes.Count));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Path, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Path));
            Assert.That(actualValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Types, Is.EqualTo(expectedValue.Data.Resource.IndexingPolicy.SpatialIndexes[0].Types));

            Assert.That(actualValue.Data.Resource.PartitionKey.Kind, Is.EqualTo(expectedValue.Data.Resource.PartitionKey.Kind));
            Assert.That(actualValue.Data.Resource.PartitionKey.Paths, Is.EqualTo(expectedValue.Data.Resource.PartitionKey.Paths));
            Assert.That(actualValue.Data.Resource.PartitionKey.Version, Is.EqualTo(expectedValue.Data.Resource.PartitionKey.Version));

            Assert.That(actualValue.Data.Resource.UniqueKeyPolicy.UniqueKeys.Count, Is.EqualTo(expectedValue.Data.Resource.UniqueKeyPolicy.UniqueKeys.Count));
            Assert.That(actualValue.Data.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths, Is.EqualTo(expectedValue.Data.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths));
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
