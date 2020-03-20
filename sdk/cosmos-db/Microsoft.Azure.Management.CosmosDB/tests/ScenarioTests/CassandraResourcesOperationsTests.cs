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
    public class CassandraResourcesOperationsTests
    {
        [Fact]
        public void CassandraCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = "CosmosDBResourceGroup2510";
                string databaseAccountName = "db2725";

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

                string keyspaceName = "keyspaceName2510";
                string keyspaceName2 = "keyspaceName22510";
                CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters
                {
                    Resource = new CassandraKeyspaceResource{ Id = keyspaceName },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                CassandraKeyspaceGetResults cassandraKeyspaceGetResults = cosmosDBManagementClient.CassandraResources.CreateUpdateCassandraKeyspaceWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraKeyspaceCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults);
                Assert.Equal(keyspaceName, cassandraKeyspaceGetResults.Name);

                CassandraKeyspaceGetResults cassandraKeyspaceGetResults1 = cosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults1);
                Assert.Equal(keyspaceName, cassandraKeyspaceGetResults1.Name);

                VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults, cassandraKeyspaceGetResults1);

                CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters
                {
                    Location = "EAST US",
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"}
                    },
                    Resource = new CassandraKeyspaceResource { Id = keyspaceName2 },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                CassandraKeyspaceGetResults cassandraKeyspaceGetResults2 = cosmosDBManagementClient.CassandraResources.CreateUpdateCassandraKeyspaceWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName2, cassandraKeyspaceCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults2);
                Assert.Equal(keyspaceName2, cassandraKeyspaceGetResults2.Name);

                IEnumerable<CassandraKeyspaceGetResults> cassandraKeyspaces = cosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaces);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings", throughputSettingsGetResults.Type);

                string tableName = "tableName2510";

                CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters
                {
                    Resource = new CassandraTableResource
                    {
                        Id = tableName,
                        Schema = new CassandraSchema
                        {
                            Columns = new List<Column> { new Column { Name = "columnA", Type = "int" }, new Column { Name = "columnB", Type = "ascii" } },
                            ClusterKeys = new List<ClusterKey> { new ClusterKey { Name = "columnB", OrderBy = "Asc" } },
                            PartitionKeys = new List<CassandraPartitionKey> { new CassandraPartitionKey { Name = "columnA" } }
                        }
                    },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                CassandraTableGetResults cassandraTableGetResults = cosmosDBManagementClient.CassandraResources.CreateUpdateCassandraTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraTableGetResults);

                IEnumerable<CassandraTableGetResults> cassandraTables = cosmosDBManagementClient.CassandraResources.ListCassandraTablesWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraTables);

                foreach (CassandraTableGetResults cassandraTable in cassandraTables)
                {
                    cosmosDBManagementClient.CassandraResources.DeleteCassandraTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName, cassandraTable.Name);
                }

                foreach (CassandraKeyspaceGetResults cassandraKeyspace in cassandraKeyspaces)
                {
                    cosmosDBManagementClient.CassandraResources.DeleteCassandraKeyspaceWithHttpMessagesAsync(resourceGroupName, databaseAccountName, cassandraKeyspace.Name);
                }
            }
        }

        private void VerifyEqualCassandraDatabases(CassandraKeyspaceGetResults expectedValue, CassandraKeyspaceGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
        }
    }
}
