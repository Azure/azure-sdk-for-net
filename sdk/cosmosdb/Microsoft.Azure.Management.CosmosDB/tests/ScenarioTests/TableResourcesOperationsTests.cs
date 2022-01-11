// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class TableResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;

        public TableResourcesOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void TableCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                const string tableThroughputType = "Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings";
                const int sampleThroughput = 700;

                var additionalProperties = new Dictionary<string, string>
            {
                {"foo","bar" }
            };
                var tags = new Dictionary<string, string>
            {
                {"key3","value3"},
                {"key4","value4"}
            };

                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Table);

                var client = this.fixture.CosmosDBManagementClient.TableResources;

                var tableName = TestUtilities.GenerateName("table");
                TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
                {
                    Resource = new TableResource { Id = tableName },
                    Options = new CreateUpdateOptions()
                };

                TableGetResults tableGetResults = client.CreateUpdateTableWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, tableName, tableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults);
                Assert.Equal(tableName, tableGetResults.Name);

                TableGetResults tableGetResults2 = client.GetTableWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, tableName).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults2);
                Assert.Equal(tableName, tableGetResults2.Name);

                VerifyEqualTables(tableGetResults, tableGetResults2);

                var tableName2 = TestUtilities.GenerateName("table");
                TableCreateUpdateParameters tableCreateUpdateParameters2 = new TableCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = tags,
                    Resource = new TableResource { Id = tableName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                TableGetResults tableGetResults3 = client.CreateUpdateTableWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, tableName2, tableCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(tableGetResults3);
                Assert.Equal(tableName2, tableGetResults3.Name);

                IEnumerable<TableGetResults> tables = client.ListTablesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(tables);

                ThroughputSettingsGetResults throughputSettingsGetResults = client.GetTableThroughputWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, tableName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(tableThroughputType, throughputSettingsGetResults.Type);

                foreach (TableGetResults table in tables)
                {
                    client.DeleteTableWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, table.Name);
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