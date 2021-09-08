// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class GremlinGraphTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _databaseAccount;
        private ResourceIdentifier _gremlinDatabaseId;
        private GremlinDatabase _gremlinDatabase;
        private string _graphName;

        public GremlinGraphTests(bool isAsync) : base(isAsync)
        {
        }

        protected GremlinGraphCollection GremlinGraphContainer { get => _gremlinDatabase.GetGremlinGraphs(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new Capability("EnableGremlin"));

            _gremlinDatabaseId = (await GremlinDatabaseTests.CreateGremlinDatabase(SessionRecording.GenerateAssetName("gremlin-db-"), null, _databaseAccount.GetGremlinDatabases())).Id;

            StopSessionRecording();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _gremlinDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _gremlinDatabase = await ArmClient.GetGremlinDatabase(_gremlinDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            GremlinGraph graph = await GremlinGraphContainer.GetIfExistsAsync(_graphName);
            if (graph != null)
            {
                await graph.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphCreateAndUpdate()
        {
            var parameters = BuildCreateUpdateParameters(null);
            var grpah = await CreateGremlinGraph(parameters);
            Assert.AreEqual(_graphName, grpah.Data.Resource.Id);
            VerifyGremlinGraphCreation(grpah, parameters);
            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, table.Data.Options.Throughput);

            bool ifExists = await GremlinGraphContainer.CheckIfExistsAsync(_graphName);
            Assert.True(ifExists);

            // NOT WORKING API
            //ThroughputSettings throughtput = await table.GetGremlinGraphThroughputAsync();
            GremlinGraph graph2 = await GremlinGraphContainer.GetAsync(_graphName);
            Assert.AreEqual(_graphName, graph2.Data.Resource.Id);
            VerifyGremlinGraphCreation(graph2, parameters);
            //Assert.AreEqual(TestThroughput1, table2.Data.Options.Throughput);

            VerifyGremlinGraphs(grpah, graph2);

            parameters.Options = new CreateUpdateOptions { Throughput = TestThroughput2 };

            grpah = await (await GremlinGraphContainer.CreateOrUpdateAsync(_graphName, parameters)).WaitForCompletionAsync();
            Assert.AreEqual(_graphName, grpah.Data.Resource.Id);
            VerifyGremlinGraphCreation(grpah, parameters);
            // Seems bug in swagger definition
            graph2 = await GremlinGraphContainer.GetAsync(_graphName);
            VerifyGremlinGraphCreation(graph2, parameters);
            // Seems bug in swagger definition
            VerifyGremlinGraphs(grpah, graph2);
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
            ThroughputSettings throughput = await graph.GetThroughputAsync();

            Assert.AreEqual(TestThroughput1, throughput.Resource.Throughput);

            ThroughputSettings throughput2 = await graph.UpdateThroughput(new ThroughputSettingsUpdateParameters(Resources.Models.Location.WestUS2,
                new ThroughputSettingsResource(TestThroughput2, null, null, null))).WaitForCompletionAsync();

            Assert.AreEqual(TestThroughput2, throughput2.Resource.Throughput);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphMigrateToAutoscale()
        {
            var graph = await CreateGremlinGraph(null);

            ThroughputSettings throughput = await graph.GetThroughputAsync();
            AssertManualThroughput(throughput);

            throughput = await graph.MigrateToAutoscale().WaitForCompletionAsync();
            AssertAutoscale(throughput);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphMigrateToManual()
        {
            var parameters = BuildCreateUpdateParameters(new AutoscaleSettings()
            {
                MaxThroughput = DefaultMaxThroughput,
            });
            var graph = await CreateGremlinGraph(parameters);

            ThroughputSettings throughput = await graph.GetThroughputAsync();
            AssertAutoscale(throughput);

            throughput = await graph.MigrateToManualThroughput().WaitForCompletionAsync();
            AssertManualThroughput(throughput);
        }

        [Test]
        [RecordedTest]
        public async Task GremlinGraphDelete()
        {
            var graph = await CreateGremlinGraph(null);
            await graph.DeleteAsync();

            graph = await GremlinGraphContainer.GetIfExistsAsync(_graphName);
            Assert.Null(graph);
        }

        protected async Task<GremlinGraph> CreateGremlinGraph(GremlinGraphCreateUpdateParameters parameters)
        {
            if (parameters == null)
            {
                parameters = BuildCreateUpdateParameters(null);
            }

            var graphLro = await GremlinGraphContainer.CreateOrUpdateAsync(_graphName, parameters);
            return graphLro.Value;
        }

        private GremlinGraphCreateUpdateParameters BuildCreateUpdateParameters(AutoscaleSettings autoscale)
        {
            _graphName = Recording.GenerateAssetName("gremlin-graph-");

            var indexingPolicy = new IndexingPolicy()
            {
                Automatic = true,
                IndexingMode = IndexingMode.Consistent,
                IncludedPaths = { new IncludedPath { Path = "/*" } },
                ExcludedPaths = { new ExcludedPath { Path = "/pathToNotIndex/*" } },
                CompositeIndexes = {
                    new List<CompositePath>
                    {
                        new CompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                        new CompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                    },
                    new List<CompositePath>
                    {
                        new CompositePath { Path = "/orderByPath3", Order = CompositePathSortOrder.Ascending },
                        new CompositePath { Path = "/orderByPath4", Order = CompositePathSortOrder.Descending }
                    }
                },
                SpatialIndexes = { new SpatialSpec("/*", new List<SpatialType> { new SpatialType("Point") }) }
            };

            var containerPartitionKey = new ContainerPartitionKey(new List<string> { "/address" }, PartitionKind.Hash, null, null);
            var uniqueKeyPolicy = new UniqueKeyPolicy()
            {
                UniqueKeys = { new UniqueKey(new List<string>() { "/testpath" }) },
            };

            var conflictResolutionPolicy = new ConflictResolutionPolicy(ConflictResolutionMode.LastWriterWins, "/path", "");

            return new GremlinGraphCreateUpdateParameters(Resources.Models.Location.WestUS2, new GremlinGraphResource(_graphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy)) {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
        }

        private void VerifyGremlinGraphCreation(GremlinGraph graph, GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters)
        {
            Assert.AreEqual(graph.Data.Resource.Id, gremlinGraphCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(graph.Data.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower(), gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower());
            Assert.AreEqual(graph.Data.Resource.PartitionKey.Kind, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.AreEqual(graph.Data.Resource.PartitionKey.Paths, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.AreEqual(graph.Data.Resource.DefaultTtl, gremlinGraphCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyGremlinGraphs(GremlinGraph expectedValue, GremlinGraph actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Location, actualValue.Data.Location);
            Assert.AreEqual(expectedValue.Data.Tags, actualValue.Data.Tags);
            Assert.AreEqual(expectedValue.Data.Type, actualValue.Data.Type);

            Assert.AreEqual(expectedValue.Data.Options, actualValue.Data.Options);

            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);

            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Data.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Data.Resource.ConflictResolutionPolicy.Mode, actualValue.Data.Resource.ConflictResolutionPolicy.Mode);

            Assert.AreEqual(expectedValue.Data.Resource.DefaultTtl, actualValue.Data.Resource.DefaultTtl);

            Assert.AreEqual(expectedValue.Data.Resource.IndexingPolicy.Automatic, actualValue.Data.Resource.IndexingPolicy.Automatic);

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
    }
}
