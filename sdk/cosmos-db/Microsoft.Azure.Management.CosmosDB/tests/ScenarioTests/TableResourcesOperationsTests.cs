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
    public class TableResourcesOperationsTests
    {
        [Fact]
        public void TableCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = "CosmosDBResourceGroup2510";
                string databaseAccountName = "db2527";

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

                string tableName = "tableName2527";
                string tableName2 = "tableName22527";
                TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
                {
                    Resource = new TableResource { Id = tableName },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                TableGetResults tableGetResults = cosmosDBManagementClient.TableResources.CreateUpdateTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, tableName, tableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults);
                Assert.Equal(tableName, tableGetResults.Name);

                TableGetResults tableGetResults2 = cosmosDBManagementClient.TableResources.GetTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, tableName).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults2);
                Assert.Equal(tableName, tableGetResults2.Name);

                VerifyEqualTables(tableGetResults, tableGetResults2);

                TableCreateUpdateParameters tableCreateUpdateParameters2 = new TableCreateUpdateParameters
                {
                    Location = "EAST US",
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"}
                    },
                    Resource = new TableResource { Id = tableName2 },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                TableGetResults tableGetResults3 = cosmosDBManagementClient.TableResources.CreateUpdateTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, tableName2, tableCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults3);
                Assert.Equal(tableName2, tableGetResults3.Name);

                IEnumerable<TableGetResults> tables = cosmosDBManagementClient.TableResources.ListTablesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(tables);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.TableResources.GetTableThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, tableName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings", throughputSettingsGetResults.Type);

                foreach (TableGetResults table in tables)
                {
                    cosmosDBManagementClient.TableResources.DeleteTableWithHttpMessagesAsync(resourceGroupName, databaseAccountName, table.Name);
                }
            }
        }

        private void VerifyEqualTables(TableGetResults expectedValue, TableGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
        }
    }
}
