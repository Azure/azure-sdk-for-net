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
    public class CassandraResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;

        public CassandraResourcesOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CassandraCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);

                var cassandraClient = this.fixture.CosmosDBManagementClient.CassandraResources;
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Cassandra);

                const string keyspaceName = "keyspaceName2510";
                const string keyspaceName2 = "keyspaceName22510";
                const string tableName = "tableName2510";
                const string cassandraThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings";
                const int sampleThroughput = 700;

                var cassandraKeyspaceCreateUpdateParameters = new CassandraKeyspaceCreateUpdateParameters
                {
                    Resource = new CassandraKeyspaceResource { Id = keyspaceName },
                    Options = new CreateUpdateOptions()
                };

                var cassandraKeyspaceGetResults = cassandraClient.CreateUpdateCassandraKeyspaceWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName,
                    cassandraKeyspaceCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults);
                Assert.Equal(keyspaceName, cassandraKeyspaceGetResults.Name);

                var cassandraKeyspaceGetResults1 = cassandraClient.GetCassandraKeyspaceWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults1);
                Assert.Equal(keyspaceName, cassandraKeyspaceGetResults1.Name);

                VerifyEqualCassandraDatabases(cassandraKeyspaceGetResults, cassandraKeyspaceGetResults1);

                var cassandraKeyspaceCreateUpdateParameters2 = new CassandraKeyspaceCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                {
                    {"key3","value3"},
                    {"key4","value4"}
                },
                    Resource = new CassandraKeyspaceResource { Id = keyspaceName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                var cassandraKeyspaceGetResults2 = cassandraClient.CreateUpdateCassandraKeyspaceWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName2,
                    cassandraKeyspaceCreateUpdateParameters2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaceGetResults2);
                Assert.Equal(keyspaceName2, cassandraKeyspaceGetResults2.Name);

                var cassandraKeyspaces = cassandraClient.ListCassandraKeyspacesWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraKeyspaces);

                var throughputSettingsGetResults = cassandraClient.GetCassandraKeyspaceThroughputWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(cassandraThroughputType, throughputSettingsGetResults.Type);

                var cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters
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

                CassandraTableGetResults cassandraTableGetResults = cassandraClient.CreateUpdateCassandraTableWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName,
                    tableName,
                    cassandraTableCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraTableGetResults);
                VerifyCassandraTableCreation(cassandraTableGetResults, cassandraTableCreateUpdateParameters);

                var cassandraTables = cassandraClient.ListCassandraTablesWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    keyspaceName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(cassandraTables);

                foreach (CassandraTableGetResults cassandraTable in cassandraTables)
                {
                    cassandraClient.DeleteCassandraTableWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName,
                        databaseAccountName,
                        keyspaceName,
                        cassandraTable.Name
                    );
                }

                foreach (CassandraKeyspaceGetResults cassandraKeyspace in cassandraKeyspaces)
                {
                    cassandraClient.DeleteCassandraKeyspaceWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName,
                        databaseAccountName,
                        cassandraKeyspace.Name
                    );
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
    }
}