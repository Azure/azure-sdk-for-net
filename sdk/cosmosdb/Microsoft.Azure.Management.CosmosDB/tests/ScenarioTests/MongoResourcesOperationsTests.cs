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
        const string location = "EAST US 2";
        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "db001";

        const string databaseName = "databaseName3668";
        const string databaseName2 = "databaseName23668";
        const string collectionName = "collectionName3668";

        const string mongoDatabaseThroughputType = "Microsoft.DocumentDB/databaseAccounts/mongodbDatabases/throughputSettings";

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
        public void MongoCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);

                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;

                DatabaseAccountGetResults databaseAccount = null;
                if (!isDatabaseNameExists)
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Kind = DatabaseAccountKind.MongoDB,
                        Properties = new DefaultRequestDatabaseAccountCreateUpdateProperties
                        {
                            Locations = new List<Location>
                            {
                                {new Location(locationName: location) }
                            }
                        }
                    };

                   databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                    Assert.Equal(databaseAccount.Name, databaseAccountName);
                }

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource {Id = databaseName},
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults1 = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults1);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults1.Name);

                VerifyEqualMongoDBDatabases(mongoDBDatabaseGetResults, mongoDBDatabaseGetResults1);

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters2 = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults2 = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2, mongoDBDatabaseCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults2);
                Assert.Equal(databaseName2, mongoDBDatabaseGetResults2.Name);

                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = cosmosDBManagementClient.MongoDBResources.ListMongoDBDatabasesWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(mongoDatabaseThroughputType, throughputSettingsGetResults.Type);

                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionGetResults, mongoDBCollectionCreateUpdateParameters);

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

        private void VerfiyMongoCollectionCreation(MongoDBCollectionGetResults mongoDBCollectionGetResults, MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters)
        {
            Assert.Equal(mongoDBCollectionGetResults.Resource.Id, mongoDBCollectionCreateUpdateParameters.Resource.Id);
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
