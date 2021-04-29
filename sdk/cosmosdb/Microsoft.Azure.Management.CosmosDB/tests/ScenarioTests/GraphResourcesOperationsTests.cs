// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;
using System;

namespace CosmosDB.Tests.ScenarioTests
{
    public class GraphResourcesOperationsTests
    {
        const string location = "EAST US 2";

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "db4096";

        const string databaseName = "databaseName1002";
        const string databaseName2 = "databaseName21002";
        const string gremlinGraphName = "gremlinGraphName1002";

        const string graphThroughputType = "Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/throughputSettings";

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

        [Fact]
        public void GraphCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                if (!isDatabaseNameExists)
                {
                    return;
                }

                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters
                {
                    Resource = new GremlinDatabaseResource {Id = databaseName},
                    Options = new CreateUpdateOptions()
                };

                GremlinDatabaseGetResults gremlinDatabaseGetResults = cosmosDBManagementClient.GremlinResources.CreateUpdateGremlinDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, gremlinDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults);
                Assert.Equal(databaseName, gremlinDatabaseGetResults.Name);

                GremlinDatabaseGetResults gremlinDatabaseGetResults1 = cosmosDBManagementClient.GremlinResources.GetGremlinDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults1);
                Assert.Equal(databaseName, gremlinDatabaseGetResults1.Name);

                VerifyEqualGremlinDatabases(gremlinDatabaseGetResults, gremlinDatabaseGetResults1);

                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters
                {
                    Location = location,
                    Tags = tags,
                    Resource = new GremlinDatabaseResource { Id = databaseName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                GremlinDatabaseGetResults gremlinDatabaseGetResults2 = cosmosDBManagementClient.GremlinResources.CreateUpdateGremlinDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2, gremlinDatabaseCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabaseGetResults2);
                Assert.Equal(databaseName2, gremlinDatabaseGetResults2.Name);

                IEnumerable<GremlinDatabaseGetResults> gremlinDatabases = cosmosDBManagementClient.GremlinResources.ListGremlinDatabasesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(graphThroughputType, throughputSettingsGetResults.Type);

                GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters
                {
                    Resource = new GremlinGraphResource
                    { 
                        Id = gremlinGraphName,
                        DefaultTtl = -1,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address"}
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

                GremlinGraphGetResults gremlinGraphGetResults = cosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinGraphGetResults);
                VerifyGremlinGraphCreation(gremlinGraphGetResults, gremlinGraphCreateUpdateParameters);

                IEnumerable<GremlinGraphGetResults> gremlinGraphs = cosmosDBManagementClient.GremlinResources.ListGremlinGraphsWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinGraphs);

                foreach (GremlinGraphGetResults gremlinGraph in gremlinGraphs)
                {
                    cosmosDBManagementClient.GremlinResources.DeleteGremlinGraphWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraph.Name);
                }

                foreach (GremlinDatabaseGetResults gremlinDatabase in gremlinDatabases)
                {
                    cosmosDBManagementClient.GremlinResources.DeleteGremlinDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, gremlinDatabase.Name);
                }
            }
        }

        private void VerifyGremlinGraphCreation(GremlinGraphGetResults gremlinGraphGetResults, GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters)
        {
            Assert.Equal(gremlinGraphGetResults.Resource.Id, gremlinGraphCreateUpdateParameters.Resource.Id);
            Assert.Equal(gremlinGraphGetResults.Resource.IndexingPolicy.IndexingMode.ToLower(), gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.ToLower());
            //Assert.Equal(gremlinGraphGetResults.Resource.IndexingPolicy.ExcludedPaths, gremlinGraphCreateUpdateParameters.Resource.IndexingPolicy.ExcludedPaths);
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
