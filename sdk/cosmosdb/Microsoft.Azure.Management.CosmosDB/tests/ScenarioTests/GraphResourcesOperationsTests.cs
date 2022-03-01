// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class GraphResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;

        public GraphResourcesOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GraphCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);

                string databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Gremlin);

                var gremlinClient = this.fixture.CosmosDBManagementClient.GremlinResources;

                string databaseName = TestUtilities.GenerateName(prefix: "gremlinDb");
                string databaseName2 = TestUtilities.GenerateName(prefix: "gremlinDb");
                string gremlinGraphName = TestUtilities.GenerateName(prefix: "gremlinGraph");

                const string gremlinThroughputType = "Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/throughputSettings";

                const int sampleThroughput = 700;

                Dictionary<string, string> additionalProperties = new Dictionary<string, string>
            {
                {"foo","bar" }
            };
                Dictionary<string, string> tags = new Dictionary<string, string>
            {
                {"key3","value3"},
                {"key4","value4"}
            };

                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters
                {
                    Resource = new GremlinDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                GremlinDatabaseGetResults gremlinDatabaseGetResults = gremlinClient.CreateUpdateGremlinDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    gremlinDatabaseCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults);
                Assert.Equal(databaseName, gremlinDatabaseGetResults.Name);

                GremlinDatabaseGetResults gremlinDatabaseGetResults1 = gremlinClient.GetGremlinDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults1);
                Assert.Equal(databaseName, gremlinDatabaseGetResults1.Name);

                VerifyEqualGremlinDatabases(gremlinDatabaseGetResults, gremlinDatabaseGetResults1);

                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = tags,
                    Resource = new GremlinDatabaseResource { Id = databaseName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                GremlinDatabaseGetResults gremlinDatabaseGetResults2 = gremlinClient.CreateUpdateGremlinDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName2,
                    gremlinDatabaseCreateUpdateParameters2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults2);
                Assert.Equal(databaseName2, gremlinDatabaseGetResults2.Name);

                IEnumerable<GremlinDatabaseGetResults> gremlinDatabases = gremlinClient.ListGremlinDatabasesWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = gremlinClient.GetGremlinDatabaseThroughputWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(gremlinThroughputType, throughputSettingsGetResults.Type);

                GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters
                {
                    Resource = new GremlinGraphResource
                    {
                        Id = gremlinGraphName,
                        DefaultTtl = -1,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address" }
                        },
                        IndexingPolicy = new IndexingPolicy
                        {
                            Automatic = true,
                            IndexingMode = IndexingMode.Consistent,
                            IncludedPaths = new List<IncludedPath>
                        {
                            new IncludedPath { Path = "/*"}
                        },
                            ExcludedPaths = new List<ExcludedPath>
                        {
                            new ExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                            CompositeIndexes = new List<IList<CompositePath>>
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
                        }
                        }
                    },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                GremlinGraphGetResults gremlinGraphGetResults = gremlinClient.CreateUpdateGremlinGraphWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinGraphGetResults);
                VerifyGremlinGraphCreation(gremlinGraphGetResults, gremlinGraphCreateUpdateParameters);

                IEnumerable<GremlinGraphGetResults> gremlinGraphs = gremlinClient.ListGremlinGraphsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinGraphs);

                foreach (GremlinGraphGetResults gremlinGraph in gremlinGraphs)
                {
                    gremlinClient.DeleteGremlinGraphWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, gremlinGraph.Name);
                }

                foreach (GremlinDatabaseGetResults gremlinDatabase in gremlinDatabases)
                {
                    gremlinClient.DeleteGremlinDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, gremlinDatabase.Name);
                }
            }
        }

        private void VerifyGremlinGraphCreation(GremlinGraphGetResults gremlinGraphGetResults, GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters)
        {
            Assert.Equal(gremlinGraphGetResults.Resource.Id, gremlinGraphCreateUpdateParameters.Resource.Id);
            Assert.Equal(gremlinGraphGetResults.Resource.IndexingPolicy.IndexingMode.ToLower(), gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.ToLower());
            Assert.Equal(gremlinGraphGetResults.Resource.PartitionKey.Kind, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.Equal(gremlinGraphGetResults.Resource.PartitionKey.Paths, gremlinGraphCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.Equal(gremlinGraphGetResults.Resource.DefaultTtl, gremlinGraphCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualGremlinDatabases(GremlinDatabaseGetResults expectedValue, GremlinDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
        }
    }
}