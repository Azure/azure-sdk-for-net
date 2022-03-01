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
using System.Collections.Specialized;

namespace CosmosDB.Tests.ScenarioTests
{
    public class MongoResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public TestFixture fixture;

        public MongoResourcesOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void MongoCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                string databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
                string databaseName2 = TestUtilities.GenerateName(prefix: "mongoDb");
                string collectionName = TestUtilities.GenerateName(prefix: "mongoCollection");

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

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults1 = mongoClient.GetMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
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

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults2 = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName2, mongoDBDatabaseCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults2);
                Assert.Equal(databaseName2, mongoDBDatabaseGetResults2.Name);

                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = mongoClient.ListMongoDBDatabasesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = mongoClient.GetMongoDBDatabaseThroughputWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(mongoDatabaseThroughputType, throughputSettingsGetResults.Type);

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("partitionKey", PartitionKind.Hash.ToString());

                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                        ShardKey = dict
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionGetResults, mongoDBCollectionCreateUpdateParameters);

                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = mongoClient.ListMongoDBCollectionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollections);

                foreach (MongoDBCollectionGetResults mongoDBCollection in mongoDBCollections)
                {
                    mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBCollection.Name);
                }

                foreach (MongoDBDatabaseGetResults mongoDBDatabase in mongoDBDatabases)
                {
                    mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, mongoDBDatabase.Name);
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