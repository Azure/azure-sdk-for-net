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
        protected string databaseName2 = "databaseName21002";
        protected string gremlinGraphName = "gremlinGraphName1002";

        protected string graphThroughputType = "Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/throughputSettings";
        protected int sampleThroughput = 700;
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
        public async Task CreateDatabaseAccount()
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
        public async Task GremlinDatabaseCRUDTests()
        {
            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName), new CreateUpdateOptions());
            var gremlinDatabaseResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters));
            Assert.NotNull(gremlinDatabaseResponse);
            GremlinDatabaseGetResults gremlinDatabaseGetResults = gremlinDatabaseResponse.Value;
            Assert.NotNull(gremlinDatabaseGetResults);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults.Name);

            var gremlinDatabaseResponse1 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters));
            Assert.NotNull(gremlinDatabaseResponse1);
            GremlinDatabaseGetResults gremlinDatabaseGetResults1 = gremlinDatabaseResponse1.Value;
            Assert.NotNull(gremlinDatabaseGetResults);
            Assert.AreEqual(databaseName, gremlinDatabaseGetResults1.Name);

            VerifyEqualGremlinDatabases(gremlinDatabaseGetResults, gremlinDatabaseGetResults1);

            GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters(new GremlinDatabaseResource(databaseName2), new CreateUpdateOptions(sampleThroughput, default));
            var gremlinDatabaseResponse2 = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinDatabaseAsync(resourceGroupName, databaseAccountName, databaseName2, gremlinDatabaseCreateUpdateParameters2));
            Assert.NotNull(gremlinDatabaseResponse2);
            GremlinDatabaseGetResults gremlinDatabaseGetResults2 = gremlinDatabaseResponse2.Value;
            Assert.NotNull(gremlinDatabaseGetResults2);
            Assert.AreEqual(databaseName2, gremlinDatabaseGetResults2.Name);

            List<GremlinDatabaseGetResults> gremlinDatabases = await CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(gremlinDatabases);
        }

        [TestCase, Order(3)]
        public async Task GraphThroughputTests()
        {
            Response<ThroughputSettingsGetResults> throughputResponse = await CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName2);
            ThroughputSettingsGetResults throughputSettingsGetResults = throughputResponse.Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(graphThroughputType, throughputSettingsGetResults.Type);
        }

        [TestCase, Order(4)]
        public async Task GremlinGraphCRUDTests()
        {
            IndexingPolicy indexingPolicy = new IndexingPolicy(true, IndexingMode.Consistent, new List<IncludedPath> { new IncludedPath { Path = "/*" } }, new List<ExcludedPath> { new ExcludedPath { Path = "/pathToNotIndex/*" } }, new List<IList<CompositePath>>
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
                        }, new List<SpatialSpec> { new SpatialSpec ( "/*", new List<SpatialType> { new SpatialType("Point") } ) });

            ContainerPartitionKey containerPartitionKey = new ContainerPartitionKey(new List<string> { "/address" }, "Hash", null);
            IList<string> paths = new List<string>() { "/testpath" };
            UniqueKey uk = new UniqueKey(paths);
            IList<UniqueKey> uniqueKeys = new List<UniqueKey>();
            uniqueKeys.Add(uk);
            UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy(uniqueKeys);

            ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy(new ConflictResolutionMode("LastWriterWins"), "/path", "");

            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters(new GremlinGraphResource(gremlinGraphName, indexingPolicy, containerPartitionKey, -1, uniqueKeyPolicy, conflictResolutionPolicy), new CreateUpdateOptions(sampleThroughput, default));

            Response<GremlinGraphGetResults> gremlinResponse = await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartCreateUpdateGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters));
            Assert.NotNull(gremlinResponse);
            GremlinGraphGetResults gremlinGraphGetResults = gremlinResponse.Value;
            Assert.NotNull(gremlinGraphGetResults);

            VerifyGremlinGraphCreation(gremlinGraphGetResults, gremlinGraphCreateUpdateParameters);

            List<GremlinGraphGetResults> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(gremlinGraphs);
        }

        [TestCase, Order(5)]
        public async Task GraphDeleteTests()
        {
            List<GremlinGraphGetResults> gremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            foreach (GremlinGraphGetResults gremlinGraph in gremlinGraphs)
            {
                await WaitForCompletionAsync(await CosmosDBManagementClient.GremlinResources.StartDeleteGremlinGraphAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraph.Name));
            }
            List<GremlinGraphGetResults> checkGremlinGraphs = await CosmosDBManagementClient.GremlinResources.ListGremlinGraphsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.AreEqual(checkGremlinGraphs.Count, 0);

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
    }
}
