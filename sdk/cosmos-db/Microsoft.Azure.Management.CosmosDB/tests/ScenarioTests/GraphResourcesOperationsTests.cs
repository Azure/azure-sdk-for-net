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
        [Fact]
        public void GraphCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = "CosmosDBResourceGroup2510";
                string databaseAccountName = "db1002";

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                //DatabaseAccountGetResults databaseAccount = null;
                if (!isDatabaseNameExists)
                {
                    return;
                    // SDK doesnt support creation of Cassandra, Table, Gremlin Accounts, use accounts created using Azure portal

                    // List<Location> locations = new List<Location>();
                    // locations.Add(new Location(locationName: "East US"));
                    // DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    // {
                    //     Location = "EAST US",
                    //     Locations = locations
                    // };

                    //databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                }

                string databaseName = "databaseName1002";
                string databaseName2 = "databaseName21002";
                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters
                {
                    Resource = new GremlinDatabaseResource { Id = databaseName },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
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
                    Location = "EAST US",
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"}
                    },
                    Resource = new GremlinDatabaseResource { Id = databaseName2 },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
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
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/gremlinDatabases/throughputSettings", throughputSettingsGetResults.Type);

                string gremlinGraphName = "gremlinGraphName1002";

                GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters
                {
                    Resource = new GremlinGraphResource
                    { 
                        Id = gremlinGraphName,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address"}
                        }
                    },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                GremlinGraphGetResults gremlinGraphGetResults = cosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, gremlinGraphName, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(gremlinGraphGetResults);

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

        private void VerifyEqualGremlinDatabases(GremlinDatabaseGetResults expectedValue, GremlinDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
        }
    }
}
