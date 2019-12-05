// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;
using System.Globalization;
using System;

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

                string resourceGroupName = "CosmosDBResourceGroup822";//CosmosDBTestUtilities.CreateResourceGroup(resourcesClient);
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

                string databaseName = GetResourceName("databaseName");
                string databaseName2 = GetResourceName("databaseName2");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "600"}
                    }
                };

                SqlDatabaseGetResults sqlDatabaseGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults);

                SqlDatabaseGetResults sqlDatabaseGetResults2 = cosmosDBManagementClient.SqlResources.GetSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults2);

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

                IEnumerable<SqlDatabaseGetResults> sqlDatabases = cosmosDBManagementClient.SqlResources.ListSqlDatabasesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);

                string containerName = GetResourceName("containerName");

                SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
                {
                    Resource = new SqlContainerResource { Id = containerName },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                SqlContainerGetResults sqlContainerGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainerGetResults);

                IEnumerable< SqlContainerGetResults > sqlContainerGetResults1 = cosmosDBManagementClient.SqlResources.ListSqlContainersWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainerGetResults1);

            }
        }

        private string GetResourceName(string prefix)
        {
            return string.Concat(prefix, (DateTime.Now).ToString("yyyyMMddHHmmssffff"));
        }

        private void VerifyEqualSqlDatabases(SqlDatabaseGetResults expectedValue, SqlDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue._rid, actualValue._rid);
            Assert.Equal(expectedValue._ts, actualValue._ts);
            Assert.Equal(expectedValue._etag, actualValue._etag);
            Assert.Equal(expectedValue._colls, actualValue._colls);
            Assert.Equal(expectedValue._users, actualValue._users);
        }
    }
}
