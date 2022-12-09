// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
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
                await InitializeClients();
                resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                databaseAccountName = Recording.GenerateAssetName("amegraphtest");
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations, CosmosDBTestUtilities.Location, resourceGroupName);
                setUpRun = true;
            }
            else if (setUpRun)
            {
                await initNewRecord();
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
            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName), new CosmosDBCreateUpdateConfig(sampleThroughput, new AutoscaleSettings()));
            var gremlinDatabaseResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters));
            Assert.NotNull(gremlinDatabaseResponse1);
            GremlinDatabaseResource gremlinDatabase1 = gremlinDatabaseResponse1.Value;
            Assert.NotNull(gremlinDatabase1);
            Assert.AreEqual(databaseName, gremlinDatabase1.Name);

            var gremlinDatabaseResponse2 = await CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(gremlinDatabaseResponse2);
            GremlinDatabaseResource gremlinDatabase2 = gremlinDatabaseResponse2.Value;
            Assert.NotNull(gremlinDatabase2);
            Assert.AreEqual(databaseName, gremlinDatabase2.Name);

            VerifyEqualGremlinDatabases(gremlinDatabase1, gremlinDatabase2);

            var throughputResponse = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettings.Type);

            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName), new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings()));
            var gremlinDatabaseResponse3 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters2));
            Assert.NotNull(gremlinDatabaseResponse3);
            GremlinDatabaseResource gremlinDatabase3 = gremlinDatabaseResponse3.Value;
            Assert.NotNull(gremlinDatabase3);
            Assert.AreEqual(databaseName, gremlinDatabase3.Name);

            var gremlinDatabaseResponse4 = await CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(gremlinDatabaseResponse4);
            GremlinDatabaseResource gremlinDatabase4 = gremlinDatabaseResponse4.Value;
            Assert.NotNull(gremlinDatabase4);
            Assert.AreEqual(databaseName, gremlinDatabase4.Name);

            VerifyEqualGremlinDatabases(gremlinDatabase3, gremlinDatabase4);

            var throughputResponse2 = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            ThroughputSettingsData throughputSettings2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(throughputSettings2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettings2.Type);
        }

        [TestCase, Order(3)]
        public async Task GremlinDatabaseListTests()
        {
            List<GremlinDatabaseResource> gremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(gremlinDatabases);
            Assert.AreEqual(gremlinDatabases.Count, 1);
            GremlinDatabaseResource gremlinDatabase = await (CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            VerifyEqualGremlinDatabases(gremlinDatabases[0], gremlinDatabase);
        }

        [TestCase, Order(3)]
        public async Task GremlinDatabaseUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            Response<ThroughputSettings> throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartUpdateGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName, throughputSettingsUpdateParameters));
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.Value;
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, maxThroughput);
            Assert.AreEqual(gremlinDatabasesThroughputType, throughputSettings.Type);
        }

        [TestCase, Order(4)]
        public async Task GremlinDatabaseMigrateToAutoscaleTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinDatabaseToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task GremlinDatabaseMigrateToManualTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinDatabaseToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.Throughput);
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

            IndexingPolicyResource indexingPolicy = new IndexingPolicy(true, IndexingMode.Consistent, includedPath, excludedPaths, compositeIndexes, spatialIndexes);

            ContainerPartitionKey containerPartitionKey = new ContainerPartitionKey(new List<string> { "/address" }, "Hash", null);
            IList<string> paths = new List<string>() { "/testpath" };
            UniqueKey uk = new UniqueKey(paths);
            IList<UniqueKey> uniqueKeys = new List<UniqueKey>();
            uniqueKeys.Add(uk);
            UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy(uniqueKeys);

            ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy(new ConflictResolutionMode("LastWriterWins"), "/path", "");
            CosmosDBCreateUpdateConfig createUpdateOptions = new CosmosDBCreateUpdateConfig(sampleThroughput, new AutoscaleSettings());

            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters(new GremlinGraphResource(gremlinGraphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy), createUpdateOptions);

            Response<GremlinGraphResource> gremlinResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters));
            Assert.NotNull(gremlinResponse);
            GremlinGraphResource gremlinGraph = gremlinResponse.Value;
            Assert.NotNull(gremlinGraph);

            VerifyGremlinGraphCreation(gremlinGraph, gremlinGraphCreateUpdateParameters);

            var throughputResponse = CosmosDBManagementClient.GremlinResources.GetGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettings.Type);

            CosmosDBCreateUpdateConfig createUpdateOptions2 = new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings());
            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters2 = new GremlinGraphCreateUpdateParameters(new GremlinGraphResource(gremlinGraphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy), createUpdateOptions2);

            Response<GremlinGraphResource> gremlinResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters2));
            Assert.NotNull(gremlinResponse2);
            GremlinGraphResource gremlinGraph2 = gremlinResponse2.Value;
            Assert.NotNull(gremlinGraph2);

            VerifyGremlinGraphCreation(gremlinGraph2, gremlinGraphCreateUpdateParameters2);

            var throughputResponse2 = CosmosDBManagementClient.GremlinResources.GetGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            ThroughputSettingsData throughputSettings2 = throughputResponse2.ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(throughputSettings2.Resource.Throughput, sampleThroughput2);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettings2.Type);
        }

        [TestCase, Order(7)]
        public async Task GremlinGraphListTests()
        {
            List<GremlinGraphResource> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(gremlinGraphs);
            Assert.AreEqual(gremlinGraphs.Count, 1);
            GremlinGraphResource gremlinGraph = await CosmosDBManagementClient.GremlinResources.GetGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName);
            VerifyEqualGremlinGraphs(gremlinGraphs[0], gremlinGraph);
        }

        [TestCase, Order(7)]
        public async Task GremlinGraphUpdateThroughputTests()
        {
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(maxThroughput, null, null, null));
            var throughputResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartUpdateGremlinGraphThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, throughputSettingsUpdateParameters));
            ThroughputSettingsData ThroughputSettingsData = throughputResponse.Value;
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(throughputSettings.Resource.Throughput, maxThroughput);
            Assert.AreEqual(gremlinGraphsThroughputType, throughputSettings.Type);
        }

        [TestCase, Order(8)]
        public async Task GremlinGraphMigrateToAutoscaleTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinGraphToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(sampleThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task GremlinGraphMigrateToManualTests()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartMigrateGremlinGraphToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(maxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(10)]
        public async Task GremlinGraphDeleteTests()
        {
            List<GremlinGraphResource> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            foreach (GremlinGraphResource gremlinGraph in gremlinGraphs)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartDeleteGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraph.Name));
            }
            List<GremlinGraphResource> checkGremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.AreEqual(checkGremlinGraphs.Count, 0);
        }

        [TestCase, Order(11)]
        public async Task GremlinDatabaseDeleteTests()
        {
            List<GremlinDatabaseResource> gremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(gremlinDatabases);
            foreach (GremlinDatabaseResource gremlinDatabase in gremlinDatabases)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartDeleteGremlinDatabaseAsync(resourceGroupName, databaseAccountName, gremlinDatabase.Name));
            }
            List<GremlinDatabaseResource> checkGremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.AreEqual(checkGremlinDatabases.Count, 0);
        }

        private void VerifyGremlinGraphCreation(GremlinGraphResource gremlinGraph, GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters)
        {
            Assert.AreEqual(gremlinGraph.Resource.Id, gremlinGraphCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(gremlinGraph.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower(), gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.Value.ToString().ToLower());
            Assert.AreEqual(gremlinGraph.Resource.PartitionKey.Kind, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.AreEqual(gremlinGraph.Resource.PartitionKey.Paths, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.AreEqual(gremlinGraph.Resource.DefaultTtl, gremlinGraphCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualGremlinDatabases(GremlinDatabaseResource expectedValue, GremlinDatabaseResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }

        private void VerifyEqualGremlinGraphs(GremlinGraphResource expectedValue, GremlinGraphResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.AreEqual(expectedValue.Tags, actualValue.Tags);
            Assert.AreEqual(expectedValue.Type, actualValue.Type);

            Assert.AreEqual(expectedValue.Options, actualValue.Options);

            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);

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
#endif
