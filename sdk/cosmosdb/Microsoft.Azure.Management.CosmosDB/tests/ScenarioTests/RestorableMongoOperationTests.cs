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
    public class RestorableMongoOperationsTests
    {
        const string location = "eastus2";
        const string sourceDatabaseAccountName32 = "pitr-mongo32-stage-source";
        const string sourceDatabaseAccountName36 = "pitr-mongo36-stage-source";
        const string sourceDatabaseAccountInstanceId32 = "eadac7e2-61f0-4e07-aaa1-9dbb495ec5a8";
        const string sourceDatabaseAccountInstanceId36 = "25a04cf0-89d4-4546-9c30-14d1dc8899df";
        const string restoreTimestamp = "2020-12-16T00:00:00+0000";

        [Fact]
        public async Task RestorableMongodb32Tests()
        {
            DatabaseRestoreResource databaseRestoreResource1 = new DatabaseRestoreResource()
            {
                DatabaseName = "database1",
                CollectionNames = new List<string>() { "collection1", "collection2", "collection3" }
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

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler);
                await RestorableMongodbTestHelper(cosmosDBManagementClient, sourceDatabaseAccountInstanceId32, resources);
            }
        }

        [Fact]
        public async Task RestorableMongodb36Tests()
        {
            DatabaseRestoreResource databaseRestoreResource1 = new DatabaseRestoreResource()
            {
                DatabaseName = "database1",
                CollectionNames = new List<string>() { "collection1", "collection2", "collection3" }
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

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler);
                await RestorableMongodbTestHelper(cosmosDBManagementClient, sourceDatabaseAccountInstanceId36, resources);
            }
        }

        private async Task RestorableMongodbTestHelper(
            CosmosDBManagementClient cosmosDBManagementClient, 
            string sourceAccountInstanceId, 
            List<DatabaseRestoreResource> resources = null)
        {
            List<RestorableMongodbDatabaseGetResult> restorableMongodbDatabases =
                (await cosmosDBManagementClient.RestorableMongodbDatabases.ListAsync(location, sourceAccountInstanceId)).ToList();

            Assert.Equal(resources.Count, restorableMongodbDatabases.Count());

            DatabaseRestoreResource resource = resources.Single(x => x.DatabaseName == "database1");

            RestorableMongodbDatabaseGetResult restorableMongodbDatabase = restorableMongodbDatabases.Single(db => db.Resource.OwnerId == resource.DatabaseName);

            string dbRid = restorableMongodbDatabase.Resource.OwnerResourceId;

            List<RestorableMongodbCollectionGetResult> restorableMongodbContainers =
                (await cosmosDBManagementClient.RestorableMongodbCollections.ListAsync(location, sourceAccountInstanceId, dbRid)).ToList();

            Assert.Equal(resource.CollectionNames.Count, restorableMongodbContainers.Count());

            List<DatabaseRestoreResource> restorableMongodbResources =
                (await cosmosDBManagementClient.RestorableMongodbResources.ListAsync(location, sourceAccountInstanceId, location, restoreTimestamp.ToString())).ToList();

            ValidateDatabaseRestoreResource(resources, restorableMongodbResources);
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