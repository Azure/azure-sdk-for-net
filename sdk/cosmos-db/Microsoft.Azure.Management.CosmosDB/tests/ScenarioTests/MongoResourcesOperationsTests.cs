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
    public class MongoResourcesOperationsTests
    {
        [Fact]
        public void MongoCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = "CosmosDBResourceGroup3668";
                string databaseAccountName = "db001"; // Using a pre-existing ResourceGroup and DatabaseAccount, because Database Account provisioning takes some time

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                DatabaseAccountGetResults databaseAccount = null;
                if (!isDatabaseNameExists)
                {
                    List<Location> locations = new List<Location>();
                    locations.Add(new Location(locationName: "East US"));
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = "EAST US",
                        Kind = "MongoDB",
                        Locations = locations
                    };

                   databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                }

                string databaseName = "databaseName3668";
                string databaseName2 = "databaseName23668";
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar"}
                    }
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/mongodbDatabases", mongoDBDatabaseGetResults.Type);

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults1 = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults1);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults1.Name);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/mongodbDatabases", mongoDBDatabaseGetResults1.Type);


                VerifyEqualMongoDBDatabases(mongoDBDatabaseGetResults, mongoDBDatabaseGetResults1);

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters2 = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName2 },
                    Options = new Dictionary<string, string>(){
                        { "Throughput", "700"}
                    }
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults2 = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2, mongoDBDatabaseCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults2);
                Assert.Equal(databaseName2, mongoDBDatabaseGetResults2.Name);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/mongodbDatabases", mongoDBDatabaseGetResults2.Type);

                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = cosmosDBManagementClient.MongoDBResources.ListMongoDBDatabasesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal("Microsoft.DocumentDB/databaseAccounts/mongodbDatabases/throughputSettings", throughputSettingsGetResults.Type);

                string collectionName = "collectionName3668";

                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                    },
                    Options = new Dictionary<string, string>(){
                        { "foo", "bar" },
                    }
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);

                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = cosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollections);

                foreach(MongoDBCollectionGetResults mongoDBCollection in mongoDBCollections)
                {
                    cosmosDBManagementClient.MongoDBResources.DeleteMongoDBCollectionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, mongoDBCollection.Name);
                }

                foreach (MongoDBDatabaseGetResults mongoDBDatabase in mongoDBDatabases)
                {
                    cosmosDBManagementClient.MongoDBResources.DeleteMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, mongoDBDatabase.Name);
                }
            }
        }

        private void VerifyEqualMongoDBDatabases(MongoDBDatabaseGetResults expectedValue, MongoDBDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
        }
    }
}
