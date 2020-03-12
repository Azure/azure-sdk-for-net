// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class SqlResourcesOperationsTests
    {
        [Fact]
        public void SqlCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = "CosmosDBResourceGroup822"; // Using a pre-existing ResourceGroup and DatabaseAccount, because Database Account provisioning takes some time
                string databaseAccountName = "db9934";

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                DatabaseAccountGetResults databaseAccount = null;
                if (!isDatabaseNameExists)
                {
                    List<Location> locations = new List<Location>();
                    locations.Add(new Location(locationName: "East US"));
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = "EAST US",
                        Kind = "GlobalDocumentDB",
                        Locations = locations
                    };

                   databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                }

                string databaseName = "databaseName822";
                string databaseName2 = "databaseName2822";
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
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
                    Location = "EAST US",
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"}
                    },
                    Resource = new SqlDatabaseResource { Id = databaseName2 },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
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
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings", throughputSettingsGetResults.Type);

                string containerName = "containerName822";

                SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
                {
                    Resource = new SqlContainerResource { 
                        Id = containerName,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address/zipCode"}
                        }
                    },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                SqlContainerGetResults sqlContainerGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainerGetResults);

                IEnumerable<SqlContainerGetResults> sqlContainers = cosmosDBManagementClient.SqlResources.ListSqlContainersWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainers);

                string storedProcedureName = "storedProcedureName822";

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
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                SqlStoredProcedureGetResults sqlStoredProcedureGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlStoredProcedureWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedureGetResults);

                IEnumerable<SqlStoredProcedureGetResults> sqlStoredProcedures = cosmosDBManagementClient.SqlResources.ListSqlStoredProceduresWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedures);

                foreach (SqlStoredProcedureGetResults sqlStoredProcedure in sqlStoredProcedures)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlStoredProcedureWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlStoredProcedure.Name);
                }

                string userDefinedFunctionName = "userDefinedFunctionName822";

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
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlUserDefinedFunctionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedureGetResults);

                IEnumerable<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = cosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlUserDefinedFunctions);

                foreach (SqlUserDefinedFunctionGetResults sqlUserDefinedFunction in sqlUserDefinedFunctions)
                {
                    cosmosDBManagementClient.SqlResources.DeleteSqlUserDefinedFunctionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlUserDefinedFunction.Name);
                }

                string triggerName = "triggerName822";

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
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                SqlTriggerGetResults sqlTriggerGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlTriggerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlTriggerGetResults);

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
