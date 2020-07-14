// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RestoreDatabaseAccountOperationsTests
    {
        const string location = "West US";
        const int sampleThroughput = 400;

        [Fact]
        public async Task RestoreDatabaseAccountTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler1);

                string resourceGroupName = CosmosDBTestUtilities.CreateResourceGroup(resourcesClient);
                string sourceDatabaseAccountName = TestUtilities.GenerateName(prefix: "accountname");
                string restoredatabaseAccountName = TestUtilities.GenerateName(prefix: "restoredaccountname");

                await this.CreateSourceDatabaseAccountAsync(sourceDatabaseAccountName, resourceGroupName, cosmosDBManagementClient);
                DatabaseAccountGetResults databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, sourceDatabaseAccountName);
                DateTime restoreTs = DateTime.UtcNow;
                RestorableDatabaseAccountGetResult restorableDatabaseAccount = await cosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationAsync(location, databaseAccount.InstanceId);
                List<Location> locations = new List<Location>();
                locations.Add(new Location(locationName: location));

                RestoreReqeustDatabaseAccountCreateUpdateProperties databaseAccountCreateUpdateProperties = new RestoreReqeustDatabaseAccountCreateUpdateProperties
                {
                    Locations = locations,
                    EnableMultipleWriteLocations = true,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = restoreTs,
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = location,
                    Kind = "GlobalDocumentDB",
                    Properties = databaseAccountCreateUpdateProperties
                };

                DatabaseAccountGetResults restoredDatabaseAccount = (await cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, restoredatabaseAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource, restorableDatabaseAccount.Id);
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        private async Task CreateSourceDatabaseAccountAsync(string databaseAccountName, string resourceGroupName, CosmosDBManagementClient cosmosDBManagementClient)
        {
            List<Location> locations = new List<Location>();
            locations.Add(new Location(locationName: location));
            DefaultRequestDatabaseAccountCreateUpdateProperties databaseAccountCreateUpdateProperties = new DefaultRequestDatabaseAccountCreateUpdateProperties
            {
                ConsistencyPolicy = new ConsistencyPolicy
                {
                    DefaultConsistencyLevel = DefaultConsistencyLevel.BoundedStaleness,
                    MaxStalenessPrefix = 300,
                    MaxIntervalInSeconds = 1000
                },
                Locations = locations,
                EnableMultipleWriteLocations = true,
                BackupPolicy = new ContinuousModeBackupPolicy()
            };

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
            {
                Location = location,
                Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                Kind = "GlobalDocumentDB",
                Properties = databaseAccountCreateUpdateProperties
            };

            DatabaseAccountGetResults databaseAccount = (await cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters)).Body;
            await this.CreateDatabaseAndCollectionAsync(databaseAccountName, resourceGroupName, cosmosDBManagementClient);
        }

        private async Task CreateDatabaseAndCollectionAsync(string databaseAccountName, string resourceGroupName, CosmosDBManagementClient cosmosDBManagementClient)
        {
            string databaseName = "Database1";
            string collectionName = "Collection1";
            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
            {
                Resource = new SqlDatabaseResource { Id = databaseName },
                Options = new CreateUpdateOptions()
            };

            SqlDatabaseGetResults sqlDatabaseGetResults = (await cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters)).Body;

            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
            {
                Resource = new SqlContainerResource
                {
                    Id = collectionName,
                    PartitionKey = new ContainerPartitionKey
                    {
                        Kind = "Hash",
                        Paths = new List<string> { "/address/zipCode" }
                    },
                },
                Options = new CreateUpdateOptions
                {
                    Throughput = sampleThroughput
                }
            };

            SqlContainerGetResults sqlContainerGetResults = (await cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, collectionName, sqlContainerCreateUpdateParameters)).Body;
        }
    }
}
