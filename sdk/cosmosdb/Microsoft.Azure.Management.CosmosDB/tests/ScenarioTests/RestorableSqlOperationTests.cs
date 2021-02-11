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
        const string location = "westus2";
        const string resourceGroupName = "pitr-stage-rg";
        const string sourceDatabaseAccountName = "pitr-sql-stage-source";
        const string sourceDatabaseAccountInstanceId = "9a4b63c3-49d1-4c87-b28e-92e92aeaa0ea";
        const string restoreTimestamp = "2020-12-16T00:00:00+0000";

        [Fact]
        public async Task RestorableSqlTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler1);
                DatabaseAccountGetResults databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, sourceDatabaseAccountName);

                RestorableDatabaseAccountGetResult restorableDatabaseAccount = (await cosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationAsync(location, sourceDatabaseAccountInstanceId));

                Assert.Equal(databaseAccount.InstanceId, restorableDatabaseAccount.Name);
                Assert.Equal(databaseAccount.Name, restorableDatabaseAccount.AccountName);
                Assert.Equal(ApiType.Sql, restorableDatabaseAccount.ApiType);
                Assert.Equal(3, restorableDatabaseAccount.RestorableLocations.Count);

                foreach (var location in restorableDatabaseAccount.RestorableLocations)
                {
                    Assert.NotNull(location.CreationTime);
                    // Assert.Null(location.DeletionTime);
                    Assert.False(string.IsNullOrEmpty(location.LocationName));
                    Assert.False(string.IsNullOrEmpty(location.RegionalDatabaseAccountInstanceId));
                }

                List<RestorableSqlDatabaseGetResult> restorableSqlDatabases =
                    (await cosmosDBManagementClient.RestorableSqlDatabases.ListAsync(location, restorableDatabaseAccount.Name)).ToList();

                RestorableSqlDatabaseGetResult restorableSqlDatabase = restorableSqlDatabases.First();

                Assert.Equal(2, restorableSqlDatabases.Count());

                string dbRid = restorableSqlDatabase.Resource.OwnerResourceId;

                List<RestorableSqlContainerGetResult> restorableSqlContainers =
                    (await cosmosDBManagementClient.RestorableSqlContainers.ListAsync(location, restorableDatabaseAccount.Name, dbRid)).ToList();

                Assert.Equal(2, restorableSqlContainers.Count());

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

                List<DatabaseRestoreResource> resources = new List<DatabaseRestoreResource>()
                {
                    databaseRestoreResource1,
                    databaseRestoreResource2
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
    }
}