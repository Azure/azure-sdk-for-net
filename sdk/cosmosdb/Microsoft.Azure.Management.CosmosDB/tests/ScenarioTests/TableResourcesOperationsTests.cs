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
        const string location = "EAST US 2";

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "db2048";

        const string tableName = "tableName2527";
        const string tableName2 = "tableName22527";

        const string tableThroughputType = "Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings";

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
        public void TableCRUDTests()
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

                TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
                {
                    Resource = new TableResource { Id = tableName },
                    Options = new CreateUpdateOptions()
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
                    Location = location,
                    Tags = tags,
                    Resource = new TableResource { Id = tableName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
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
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(tableThroughputType, throughputSettingsGetResults.Type);

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
