// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RestorableSqlOperationsTests
    {
        const string location = "eastus2";
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "sqltestaccount124";

        [Fact]
        public async Task RestorableSqlTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler1);
                DatabaseAccountGetResults databaseAccount = await RestorableSqlOperationsTests.CreateDatabaseAccountIfNotExists(cosmosDBManagementClient);

                RestorableDatabaseAccountGetResult restorableDatabaseAccount = (await cosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationAsync(location, databaseAccount.InstanceId));

                Assert.Equal(databaseAccount.InstanceId, restorableDatabaseAccount.Name);
                Assert.Equal(databaseAccount.Name, restorableDatabaseAccount.AccountName);
                Assert.Equal(ApiType.Sql, restorableDatabaseAccount.ApiType);

                foreach (var location in restorableDatabaseAccount.RestorableLocations)
                {
                    Assert.NotNull(location.CreationTime);
                    Assert.False(string.IsNullOrEmpty(location.LocationName));
                    Assert.False(string.IsNullOrEmpty(location.RegionalDatabaseAccountInstanceId));
                }

                List<RestorableSqlDatabaseGetResult> restorableSqlDatabases =
                    (await cosmosDBManagementClient.RestorableSqlDatabases.ListAsync(location, restorableDatabaseAccount.Name)).ToList();

                RestorableSqlDatabaseGetResult restorableSqlDatabase = restorableSqlDatabases.Where(account => account.Resource.Database.Id.Equals("database1")).SingleOrDefault();
                Assert.NotNull(restorableSqlDatabase);

                Assert.Equal(3, restorableSqlDatabases.Count());

                string dbRid = restorableSqlDatabase.Resource.OwnerResourceId;

                List<RestorableSqlContainerGetResult> restorableSqlContainers =
                    (await cosmosDBManagementClient.RestorableSqlContainers.ListAsync(location, restorableDatabaseAccount.Name, dbRid)).ToList();

                Assert.Equal(2, restorableSqlContainers.Count());

                string restoreTimestamp = DateTime.ParseExact("16-06-21 06:20:00", "dd-MM-yy HH:mm:ss", null).ToString(); // use - DateTime.UtcNow.AddMinutes(-1).ToString() when generating json file
                List<DatabaseRestoreResource> restorableSqlResources =
                    (await cosmosDBManagementClient.RestorableSqlResources.ListAsync(location, restorableDatabaseAccount.Name, location, restoreTimestamp.ToString())).ToList();

                DatabaseRestoreResource databaseRestoreResource1 = new DatabaseRestoreResource()
                {
                    DatabaseName = "database1",
                    CollectionNames = new List<string>() { "container1", "container2" }
                };

                DatabaseRestoreResource databaseRestoreResource2 = new DatabaseRestoreResource()
                {
                    DatabaseName = "databaseA",
                    CollectionNames = new List<string>()
                };

                DatabaseRestoreResource databaseRestoreResource3 = new DatabaseRestoreResource()
                {
                    DatabaseName = "TestDB1",
                    CollectionNames = new List<string>() { "TestContainer1" }
                };

                List<DatabaseRestoreResource> resources = new List<DatabaseRestoreResource>()
                {
                    databaseRestoreResource1,
                    databaseRestoreResource2,
                    databaseRestoreResource3
                };

                ValidateDatabaseRestoreResource(resources, restorableSqlResources);
            }
        }

        private static void ValidateDatabaseRestoreResource(
            List<DatabaseRestoreResource> expectedResources,
            List<DatabaseRestoreResource> actualResources)
        {
            Assert.Equal(expectedResources.Count, actualResources.Count);

            foreach (var resource in expectedResources)
            {
                DatabaseRestoreResource actual = actualResources.Single(x => x.DatabaseName == resource.DatabaseName);
                Assert.False(resource.CollectionNames.Except(actual.CollectionNames).Any() && actual.CollectionNames.Except(resource.CollectionNames).Any());
            }
        }

        private static async Task<DatabaseAccountGetResults> CreateDatabaseAccountIfNotExists(CosmosDBManagementClient cosmosDBManagementClient)
        {
            bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

            DatabaseAccountGetResults databaseAccount = null;
            if (!isDatabaseNameExists)
            {
                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = location,
                    Kind = DatabaseAccountKind.GlobalDocumentDB,
                    Locations = new List<Location>()
                    {
                        {new Location(locationName: location) }
                    },
                    BackupPolicy = new ContinuousModeBackupPolicy()
                };

                databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseAccount.Name, databaseAccountName);
            }
            databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);

            return databaseAccount;
        }

        private static void CreateDatabasesAndCollections(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName)
        {
            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters1 = new SqlDatabaseCreateUpdateParameters
            {
                Resource = new SqlDatabaseResource("database1")
            };
            SqlDatabaseGetResults sqlDatabaseGetResults1 = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabase(resourceGroupName, databaseAccountName, "database1", sqlDatabaseCreateUpdateParameters1);

            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParametersA = new SqlDatabaseCreateUpdateParameters
            {
                Resource = new SqlDatabaseResource("databaseA")
            };
            SqlDatabaseGetResults sqlDatabaseGetResultsA = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabase(resourceGroupName, databaseAccountName, "databaseA", sqlDatabaseCreateUpdateParametersA);

            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters1 = new SqlContainerCreateUpdateParameters
            {
                Resource = new SqlContainerResource("container1", partitionKey: new ContainerPartitionKey(new List<string> { "/id" }))
            };
            SqlContainerGetResults sqlContainerGetResults1 = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainer(resourceGroupName, databaseAccountName, sqlDatabaseGetResults1.Name, "container1", sqlContainerCreateUpdateParameters1);

            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters2 = new SqlContainerCreateUpdateParameters
            {
                Resource = new SqlContainerResource("container2", partitionKey: new ContainerPartitionKey(new List<string> { "/id" }))
            };
            SqlContainerGetResults sqlContainerGetResults2 = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainer(resourceGroupName, databaseAccountName, sqlDatabaseGetResults1.Name, "container2", sqlContainerCreateUpdateParameters2);
        }
    }
}
