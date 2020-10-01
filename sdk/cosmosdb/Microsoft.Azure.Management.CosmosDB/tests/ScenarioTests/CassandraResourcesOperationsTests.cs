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
        const string location = "EAST US 2";

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "db8192";

        const string keyspaceName = "keyspaceName2510";
        const string keyspaceName2 = "keyspaceName22510";
        const string tableName = "tableName2510";
        const string cassandraThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings";
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
        public void CassandraCRUDTests()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler);        

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                if (!isDatabaseNameExists)
                {
                    return;
                }

                CassandraKeyspaceCreateUpdateParameters cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters
                {
                    Resource = new CassandraKeyspaceResource { Id = keyspaceName },
                    Options = new CreateUpdateOptions()
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
                    Location = location,
                    Tags = tags,
                    Resource = new CassandraKeyspaceResource { Id = keyspaceName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
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
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(cassandraThroughputType, throughputSettingsGetResults.Type);

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
                    Options = new CreateUpdateOptions()
                };

                CassandraTableGetResults cassandraTableGetResults = cosmosDBManagementClient.CassandraResources.CreateUpdateCassandraTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, keyspaceName, tableName, cassandraTableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraTableGetResults);
                VerifyCassandraTableCreation(cassandraTableGetResults, cassandraTableCreateUpdateParameters);

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

        private void VerifyCassandraTableCreation(CassandraTableGetResults cassandraTableGetResults, CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters)
        {
            Assert.Equal(cassandraTableGetResults.Resource.Id, cassandraTableCreateUpdateParameters.Resource.Id);
            Assert.Equal(cassandraTableGetResults.Resource.Schema.Columns.Count, cassandraTableCreateUpdateParameters.Resource.Schema.Columns.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.Columns.Count; i++)
            {
                Assert.Equal(cassandraTableGetResults.Resource.Schema.Columns[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Name);
                Assert.Equal(cassandraTableGetResults.Resource.Schema.Columns[i].Type, cassandraTableCreateUpdateParameters.Resource.Schema.Columns[i].Type);
            }

            Assert.Equal(cassandraTableGetResults.Resource.Schema.ClusterKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.ClusterKeys.Count; i++)
            {
                Assert.Equal(cassandraTableGetResults.Resource.Schema.ClusterKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.ClusterKeys[i].Name);
            }

            Assert.Equal(cassandraTableGetResults.Resource.Schema.PartitionKeys.Count, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys.Count);
            for (int i = 0; i < cassandraTableGetResults.Resource.Schema.PartitionKeys.Count; i++)
            {
                Assert.Equal(cassandraTableGetResults.Resource.Schema.PartitionKeys[i].Name, cassandraTableCreateUpdateParameters.Resource.Schema.PartitionKeys[i].Name);
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
