// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class SqlResourcesOperationsTests
    {
        const string location = "EAST US 2";

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "db9934";

        const string databaseName = "databaseName";
        const string databaseName2 = "databaseName2";
        const string containerName = "containerName";
        const string storedProcedureName = "storedProcedureName";
        const string triggerName = "triggerName";
        const string userDefinedFunctionName = "userDefinedFunctionName";

        const string sqlThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings";

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
        public void SqlCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                DatabaseAccountGetResults databaseAccount = null;
                if (!isDatabaseNameExists)
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Kind = DatabaseAccountKind.GlobalDocumentDB,
                        Properties = new DefaultRequestDatabaseAccountCreateUpdateProperties
                        {
                            Locations = new List<Location>()
                            {
                                {new Location(locationName: location) }
                            }
                        }
                };

                   databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                    Assert.Equal(databaseAccount.Name, databaseAccountName);
                }

                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                SqlDatabaseGetResults sqlDatabaseGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults);
                Assert.Equal(databaseName, sqlDatabaseGetResults.Name);

                SqlDatabaseGetResults sqlDatabaseGetResults2 = cosmosDBManagementClient.SqlResources.GetSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults2);
                Assert.Equal(databaseName, sqlDatabaseGetResults2.Name);

                VerifyEqualSqlDatabases(sqlDatabaseGetResults, sqlDatabaseGetResults2);

                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 = new SqlDatabaseCreateUpdateParameters
                {
                    Location = location,
                    Tags = tags,
                    Resource = new SqlDatabaseResource { Id = databaseName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                SqlDatabaseGetResults sqlDatabaseGetResults3 = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2, sqlDatabaseCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults3);
                Assert.Equal(databaseName2, sqlDatabaseGetResults3.Name);

                IEnumerable<SqlDatabaseGetResults> sqlDatabases = cosmosDBManagementClient.SqlResources.ListSqlDatabasesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(sqlThroughputType, throughputSettingsGetResults.Type);

                SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
                {
                    Resource = new SqlContainerResource { 
                        Id = containerName,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address/zipCode"}
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

                SqlContainerGetResults sqlContainerGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainerGetResults);

                IEnumerable<SqlContainerGetResults> sqlContainers = cosmosDBManagementClient.SqlResources.ListSqlContainersWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainers);

                SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters
                {
                    Resource = new SqlStoredProcedureResource
                    {
                        Id = storedProcedureName,
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlStoredProcedureGetResults sqlStoredProcedureGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlStoredProcedureWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedureGetResults);
                Assert.Equal(sqlStoredProcedureGetResults.Resource.Body, sqlStoredProcedureGetResults.Resource.Body);

                IEnumerable<SqlStoredProcedureGetResults> sqlStoredProcedures = cosmosDBManagementClient.SqlResources.ListSqlStoredProceduresWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedures);

                foreach (SqlStoredProcedureGetResults sqlStoredProcedure in sqlStoredProcedures)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlStoredProcedureWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlStoredProcedure.Name);
                }

                SqlUserDefinedFunctionCreateUpdateParameters sqlUserDefinedFunctionCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters
                {
                    Resource = new SqlUserDefinedFunctionResource
                    {
                        Id = userDefinedFunctionName,
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlUserDefinedFunctionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlUserDefinedFunctionGetResults);
                Assert.Equal(sqlUserDefinedFunctionGetResults.Resource.Body, sqlUserDefinedFunctionGetResults.Resource.Body);


                IEnumerable<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = cosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlUserDefinedFunctions);

                foreach (SqlUserDefinedFunctionGetResults sqlUserDefinedFunction in sqlUserDefinedFunctions)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlUserDefinedFunctionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlUserDefinedFunction.Name);
                }

                SqlTriggerCreateUpdateParameters sqlTriggerCreateUpdateParameters = new SqlTriggerCreateUpdateParameters
                {
                    Resource = new SqlTriggerResource
                    {
                        Id = triggerName,
                        TriggerOperation = "All",
                        TriggerType = "Pre",
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlTriggerGetResults sqlTriggerGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlTriggerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlTriggerGetResults);
                Assert.Equal(sqlTriggerGetResults.Resource.TriggerType, sqlTriggerCreateUpdateParameters.Resource.TriggerType);
                Assert.Equal(sqlTriggerGetResults.Resource.TriggerOperation, sqlTriggerCreateUpdateParameters.Resource.TriggerOperation);
                Assert.Equal(sqlTriggerGetResults.Resource.Body, sqlTriggerCreateUpdateParameters.Resource.Body);

                IEnumerable<SqlTriggerGetResults> sqlTriggers = cosmosDBManagementClient.SqlResources.ListSqlTriggersWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlTriggers);

                foreach (SqlTriggerGetResults sqlTrigger in sqlTriggers)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlTriggerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlTrigger.Name);
                }

                foreach (SqlContainerGetResults sqlContainer in sqlContainers)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlContainerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, sqlContainer.Name);
                }

                foreach (SqlDatabaseGetResults sqlDatabase in sqlDatabases)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, sqlDatabase.Name);
                }
            }
        }

        private void VerifySqlContainerCreation(SqlContainerGetResults sqlContainerGetResults, SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters)
        {
            Assert.Equal(sqlContainerGetResults.Resource.Id, sqlContainerCreateUpdateParameters.Resource.Id);
            Assert.Equal(sqlContainerGetResults.Resource.IndexingPolicy.IndexingMode.ToLower(), sqlContainerCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.ToLower());
            //Assert.Equal(sqlContainerGetResults.Resource.IndexingPolicy.ExcludedPaths, sqlContainerCreateUpdateParameters.Resource.IndexingPolicy.ExcludedPaths);
            Assert.Equal(sqlContainerGetResults.Resource.PartitionKey.Kind, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.Equal(sqlContainerGetResults.Resource.PartitionKey.Paths, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.Equal(sqlContainerGetResults.Resource.DefaultTtl, sqlContainerCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualSqlDatabases(SqlDatabaseGetResults expectedValue, SqlDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
            Assert.Equal(expectedValue.Resource._colls, actualValue.Resource._colls);
            Assert.Equal(expectedValue.Resource._users, actualValue.Resource._users);
        }
    }
}
