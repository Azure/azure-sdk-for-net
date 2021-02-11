// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class GraphResourcesOperationsTests : CosmosDBManagementClientBase
    {
        protected string resourceGroupName;
        protected string databaseAccountName;
        protected string databaseName = "databaseName1002";
        protected string gremlinGraphName = "gremlinGraphName1002";

        protected string gremlinDatabasesThroughputType = "Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/throughputSettings";
        protected string gremlinGraphsThroughputType = "Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/graphs/throughputSettings";
        protected int sampleThroughput = 700;
        protected int sampleThroughput2 = 800;
        protected int maxThroughput = 7000;
        protected bool setUpRun = false;

        public GraphResourcesOperationsTests()
            : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setUpRun)
            {
                InitializeClients();
                resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                databaseAccountName = Recording.GenerateAssetName("amegraphtest");
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations, CosmosDBTestUtilities.Location, resourceGroupName);
                setUpRun = true;
            }
            else if (setUpRun)
            {
                initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task GremlinCreateDatabaseAccount()
        {
            var locations = new List<Location>();
            Location loc = new Location();
            loc.LocationName = CosmosDBTestUtilities.Location;
            loc.FailoverPriority = 0;
            loc.IsZoneRedundant = false;
            locations.Add(loc);

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountCreateUpdateParameters.Location = CosmosDBTestUtilities.Location;
            databaseAccountCreateUpdateParameters.Capabilities.Add(new Capability("EnableGremlin"));
            databaseAccountCreateUpdateParameters.ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.Eventual);

            await WaitForCompletionAsync(await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));
        }

        [TestCase, Order(2)]
        public async Task GremlinDatabaseCreateUpdateTests()
        {
            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName), new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings()));
            var gremlinDatabaseResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters));
            Assert.NotNull(gremlinDatabaseResponse1);
            GremlinDatabaseGetResults gremlinDatabaseGetResults1 = gremlinDatabaseResponse1.Value;
            Assert.NotNull(gremlinDatabaseGetResults1);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults1.Name);

            var gremlinDatabaseResponse2 = await CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(gremlinDatabaseResponse2);
            GremlinDatabaseGetResults gremlinDatabaseGetResults2 = gremlinDatabaseResponse2.Value;
            Assert.NotNull(gremlinDatabaseGetResults2);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults2.Name);

            VerifyEqualGremlinDatabases(gremlinDatabaseGetResults1, gremlinDatabaseGetResults2);

            var throughputResponse = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettingsGetResults.Type);

            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName), new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings()));
            var gremlinDatabaseResponse3 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters2));
            Assert.NotNull(gremlinDatabaseResponse3);
            GremlinDatabaseGetResults gremlinDatabaseGetResults3 = gremlinDatabaseResponse3.Value;
            Assert.NotNull(gremlinDatabaseGetResults3);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults3.Name);

            var gremlinDatabaseResponse4 = await CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(gremlinDatabaseResponse4);
            GremlinDatabaseGetResults gremlinDatabaseGetResults4 = gremlinDatabaseResponse4.Value;
            Assert.NotNull(gremlinDatabaseGetResults4);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults4.Name);

            VerifyEqualGremlinDatabases(gremlinDatabaseGetResults3, gremlinDatabaseGetResults4);

            var throughputResponse2 = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            ThroughputSettingsGetResults throughputSettingsGetResults2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults2);
            Assert.NotNull(throughputSettingsGetResults2.Name);
            Assert.AreEqual(throughputSettingsGetResults2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettingsGetResults2.Type);
        }

        [TestCase, Order(3)]
        public async Task GremlinDatabaseListTests()
        {
            List<GremlinDatabaseGetResults> gremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(gremlinDatabases);
            Assert.AreEqual(gremlinDatabases.Count, 1);
            GremlinDatabaseGetResults gremlinDatabaseGetResults = await (CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            VerifyEqualGremlinDatabases(gremlinDatabases[0], gremlinDatabaseGetResults);
        }

        [TestCase, Order(3)]
        public async Task GremlinDatabaseUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            Response<ThroughputSettingsGetResults> throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartUpdateGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName, throughputSettingsUpdateParameters));
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, maxThroughput);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettingsGetResults.Type);
        }

        [TestCase, Order(4)]
        public async Task GremlinDatabaseMigrateToAutoscaleTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinDatabaseToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task GremlinDatabaseMigrateToManualTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinDatabaseToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(6)]
        public async Task GremlinGraphCreateUpdateTests()
        {
            IList<IncludedPath> includedPath = new List<IncludedPath> { new IncludedPath { Path = "/*" } };
            IList<ExcludedPath> excludedPaths = new List<ExcludedPath> { new ExcludedPath { Path = "/pathToNotIndex/*" } };
            IList<IList<CompositePath>> compositeIndexes = new List<IList<CompositePath>>
                        {
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
                        };
            IList<SpatialSpec> spatialIndexes = new List<SpatialSpec> { new SpatialSpec("/*", new List<SpatialType> { new SpatialType("Point") }) };

            IndexingPolicy indexingPolicy = new IndexingPolicy(true, IndexingMode.Consistent, includedPath, excludedPaths, compositeIndexes, spatialIndexes);

            ContainerPartitionKey containerPartitionKey = new ContainerPartitionKey(new List<string> { "/address" }, "Hash", null);
            IList<string> paths = new List<string>() { "/testpath" };
            UniqueKey uk = new UniqueKey(paths);
            IList<UniqueKey> uniqueKeys = new List<UniqueKey>();
            uniqueKeys.Add(uk);
            UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy(uniqueKeys);

            ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy(new ConflictResolutionMode("LastWriterWins"), "/path", "");
            CreateUpdateOptions createUpdateOptions = new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings());

            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters(new GremlinGraphResource(gremlinGraphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy), createUpdateOptions);

            Response<GremlinGraphGetResults> gremlinResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters));
            Assert.NotNull(gremlinResponse);
            GremlinGraphGetResults gremlinGraphGetResults = gremlinResponse.Value;
            Assert.NotNull(gremlinGraphGetResults);

            VerifyGremlinGraphCreation(gremlinGraphGetResults, gremlinGraphCreateUpdateParameters);

            var throughputResponse = CosmosDBManagementClient.GremlinResources.GetGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettingsGetResults.Type);

            CreateUpdateOptions createUpdateOptions2 = new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings());
            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters2 = new GremlinGraphCreateUpdateParameters(new GremlinGraphResource(gremlinGraphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy), createUpdateOptions2);

            Response<GremlinGraphGetResults> gremlinResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters2));
            Assert.NotNull(gremlinResponse2);
            GremlinGraphGetResults gremlinGraphGetResults2 = gremlinResponse2.Value;
            Assert.NotNull(gremlinGraphGetResults2);

            VerifyGremlinGraphCreation(gremlinGraphGetResults2, gremlinGraphCreateUpdateParameters2);

            var throughputResponse2 = CosmosDBManagementClient.GremlinResources.GetGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            ThroughputSettingsGetResults throughputSettingsGetResults2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettingsGetResults2);
            Assert.NotNull(throughputSettingsGetResults2.Name);
            Assert.AreEqual(throughputSettingsGetResults2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettingsGetResults2.Type);
        }

        [TestCase, Order(7)]
        public async Task GremlinGraphListTests()
        {
            List<GremlinGraphGetResults> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(gremlinGraphs);
            Assert.AreEqual(gremlinGraphs.Count, 1);
            GremlinGraphGetResults gremlinGraphGetResults = await CosmosDBManagementClient.GremlinResources.GetGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            VerifyEqualGremlinGraphs(gremlinGraphs[0], gremlinGraphGetResults);
        }

        [TestCase, Order(7)]
        public async Task GremlinGraphUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartUpdateGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, throughputSettingsUpdateParameters));
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, maxThroughput);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettingsGetResults.Type);
        }

        [TestCase, Order(8)]
        public async Task GremlinGraphMigrateToAutoscaleTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinGraphToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task GremlinGraphMigrateToManualTests()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinGraphToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(10)]
        public async Task GremlinGraphDeleteTests()
        {
            List<GremlinGraphGetResults> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            foreach (GremlinGraphGetResults gremlinGraph in gremlinGraphs)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartDeleteGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraph.Name));
            }
            List<GremlinGraphGetResults> checkGremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.AreEqual(checkGremlinGraphs.Count, 0);
        }

        [TestCase, Order(11)]
        public async Task GremlinDatabaseDeleteTests()
        {
            List<GremlinDatabaseGetResults> gremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(gremlinDatabases);
            foreach (GremlinDatabaseGetResults gremlinDatabase in gremlinDatabases)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartDeleteGremlinDatabaseAsync(resourceGroupName, databaseAccountName, gremlinDatabase.Name));
            }
            List<GremlinDatabaseGetResults> checkGremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.AreEqual(checkGremlinDatabases.Count, 0);
        }

        private void VerifyGremlinGraphCreation(GremlinGraphGetResults gremlinGraphGetResults, GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters)
        {
            Assert.AreEqual(gremlinGraphGetResults.Resource.Id, gremlinGraphCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(gremlinGraphGetResults.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower(), gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower());
            Assert.AreEqual(gremlinGraphGetResults.Resource.PartitionKey.Kind, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.AreEqual(gremlinGraphGetResults.Resource.PartitionKey.Paths, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.AreEqual(gremlinGraphGetResults.Resource.DefaultTtl, gremlinGraphCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualGremlinDatabases(GremlinDatabaseGetResults expectedValue, GremlinDatabaseGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }

        private void VerifyEqualGremlinGraphs(GremlinGraphGetResults expectedValue, GremlinGraphGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);

            Assert.AreEqual(expectedValue.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Resource.ConflictResolutionPolicy.ConflictResolutionPath, actualValue.Resource.ConflictResolutionPolicy.ConflictResolutionPath);
            Assert.AreEqual(expectedValue.Resource.ConflictResolutionPolicy.Mode, actualValue.Resource.ConflictResolutionPolicy.Mode);

            Assert.AreEqual(expectedValue.Resource.DefaultTtl, actualValue.Resource.DefaultTtl);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.Automatic, actualValue.Resource.IndexingPolicy.Automatic);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IncludedPaths.Count, actualValue.Resource.IndexingPolicy.IncludedPaths.Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IncludedPaths[0].Path, actualValue.Resource.IndexingPolicy.IncludedPaths[0].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IncludedPaths[0].Indexes, actualValue.Resource.IndexingPolicy.IncludedPaths[0].Indexes);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.ExcludedPaths.Count, actualValue.Resource.IndexingPolicy.ExcludedPaths.Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.ExcludedPaths[0].Path, actualValue.Resource.IndexingPolicy.ExcludedPaths[0].Path);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes.Count, actualValue.Resource.IndexingPolicy.CompositeIndexes.Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[0].Count, actualValue.Resource.IndexingPolicy.CompositeIndexes[0].Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[0][0].Path, actualValue.Resource.IndexingPolicy.CompositeIndexes[0][0].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[0][0].Order, actualValue.Resource.IndexingPolicy.CompositeIndexes[0][0].Order);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[0][1].Path, actualValue.Resource.IndexingPolicy.CompositeIndexes[0][1].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[0][1].Order, actualValue.Resource.IndexingPolicy.CompositeIndexes[0][1].Order);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[1].Count, actualValue.Resource.IndexingPolicy.CompositeIndexes[1].Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[1][0].Path, actualValue.Resource.IndexingPolicy.CompositeIndexes[1][0].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[1][0].Order, actualValue.Resource.IndexingPolicy.CompositeIndexes[1][0].Order);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[1][1].Path, actualValue.Resource.IndexingPolicy.CompositeIndexes[1][1].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.CompositeIndexes[1][1].Order, actualValue.Resource.IndexingPolicy.CompositeIndexes[1][1].Order);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IndexingMode, actualValue.Resource.IndexingPolicy.IndexingMode);

            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.SpatialIndexes.Count, actualValue.Resource.IndexingPolicy.SpatialIndexes.Count);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.SpatialIndexes[0].Path, actualValue.Resource.IndexingPolicy.SpatialIndexes[0].Path);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.SpatialIndexes[0].Types, actualValue.Resource.IndexingPolicy.SpatialIndexes[0].Types);

            Assert.AreEqual(expectedValue.Resource.PartitionKey.Kind, actualValue.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Paths, actualValue.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Version, actualValue.Resource.PartitionKey.Version);

            Assert.AreEqual(expectedValue.Resource.UniqueKeyPolicy.UniqueKeys.Count, actualValue.Resource.UniqueKeyPolicy.UniqueKeys.Count);
            Assert.AreEqual(expectedValue.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths, actualValue.Resource.UniqueKeyPolicy.UniqueKeys[0].Paths);
        }
    }
}
