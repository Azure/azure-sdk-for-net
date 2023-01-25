// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

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
                fixture.Location = "west us 2";
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

        [Fact]
        public void MongoPartitionMergeTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                this.fixture.ResourceGroupName = "cosmosTest";
                var databaseAccountName = "mergetest3";

                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");                
                string collectionName = TestUtilities.GenerateName(prefix: "mongoCollection");

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);

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
                    {
                        Throughput = 14000
                    }
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionGetResults, mongoDBCollectionCreateUpdateParameters);

                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = mongoClient.ListMongoDBCollectionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollections);

                PhysicalPartitionStorageInfoCollection physicalPartitionStorageInfoCollection =
                    mongoClient.ListMongoDBCollectionPartitionMerge(fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, new MergeParameters(isDryRun: true));

                Assert.True(physicalPartitionStorageInfoCollection.PhysicalPartitionStorageInfoCollectionProperty.Count > 1);

                mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName);                
                mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName);
                
            }
        }

        [Fact]
        public async Task MongoInAccountRestoreTestsAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Location = "west us";
                fixture.Init(context);
                string databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo32);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;
                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
                string collectionName = TestUtilities.GenerateName(prefix: "mongoCollection");

                //create db
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);

                //get db
                MongoDBDatabaseGetResults mongoDBDatabaseGetResults1 = mongoClient.GetMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults1);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults1.Name);

                VerifyEqualMongoDBDatabases(mongoDBDatabaseGetResults, mongoDBDatabaseGetResults1);

                //create prov collection
                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionGetResults, mongoDBCollectionCreateUpdateParameters);
                DateTime restoreTimestampInUtc = DateTime.UtcNow;
                String restoreSource = restorableDatabaseAccount.Id;

                //restore collection
                await mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBCollectionGetResults.Name);
                Thread.Sleep(5000);

                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParametersForRestore = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = restoreTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBCollectionGetResults mongoDBCollectionRestoreResults;

                mongoDBCollectionRestoreResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body;

                Assert.NotNull(mongoDBCollectionRestoreResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionRestoreResults, mongoDBCollectionCreateUpdateParameters);

                //restore database
                await mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName);
                Thread.Sleep(5000);

                try { mongoDBCollectionRestoreResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body; }
                catch (Exception ex)
                {
                    Assert.Contains("Could not find the database", ex.Message);
                }
                DateTime currentTimestampInUtc = DateTime.UtcNow;
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParametersForRestoreWithInvalidTimestamp = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource
                    {
                        Id = databaseName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = currentTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseRestoreResults;
                try { mongoDBDatabaseRestoreResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParametersForRestoreWithInvalidTimestamp).GetAwaiter().GetResult().Body; }
                catch (Exception ex)
                {
                    Assert.Contains("No databases or collections found in the source account at the restore timestamp provided", ex.Message);
                }

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParametersForRestore = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource
                    {
                        Id = databaseName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = restoreTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                mongoDBDatabaseRestoreResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseRestoreResults);
                Assert.Equal(databaseName, mongoDBDatabaseRestoreResults.Name);

                mongoDBCollectionCreateUpdateParametersForRestore = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = restoreTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                mongoDBCollectionRestoreResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body;

                Assert.NotNull(mongoDBCollectionRestoreResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionRestoreResults, mongoDBCollectionCreateUpdateParameters);

                Thread.Sleep(10000);

                //list collections
                IEnumerable<MongoDBCollectionGetResults> restoredMongoDBCollections = mongoClient.ListMongoDBCollectionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(restoredMongoDBCollections);

                foreach (MongoDBCollectionGetResults mongoDBCollection in restoredMongoDBCollections)
                {
                    await mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBCollection.Name);
                }

                //list databases
                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = mongoClient.ListMongoDBDatabasesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);

                foreach (MongoDBDatabaseGetResults mongoDBDatabase in mongoDBDatabases)
                {
                    await mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, mongoDBDatabase.Name);
                }
            }
        }

        [Fact]
        public async Task MongoInAccountRestoreForSharedResourcesTestsAsync()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Location = "west us";
                fixture.Init(context);
                string databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo32);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;
                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
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

                //create shared db
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                MongoDBDatabaseGetResults mongoDBDatabaseCreateResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseCreateResults);
                Assert.Equal(databaseName, mongoDBDatabaseCreateResults.Name);

                //get db
                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.GetMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);

                ThroughputSettingsGetResults throughputSettingsGetResults = mongoClient.GetMongoDBDatabaseThroughputWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
                Assert.Equal(mongoDatabaseThroughputType, throughputSettingsGetResults.Type);

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("partitionKey", PartitionKind.Hash.ToString());

                //create shared ru collection
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

                DateTime restoreTimestampInUtc = DateTime.UtcNow;
                String restoreSource = restorableDatabaseAccount.Id;

                Thread.Sleep(10000);

                //restore collection
                await mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBCollectionGetResults.Name);
                Thread.Sleep(5000);

                MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParametersForRestore = new MongoDBCollectionCreateUpdateParameters
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = restoreTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBCollectionGetResults mongoDBCollectionRestoreResults;

                try
                {
                    mongoDBCollectionRestoreResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(
                  this.fixture.ResourceGroupName,
                  databaseAccountName,
                  databaseName,
                  collectionName,
                  mongoDBCollectionCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body;
                }
                catch (Exception ex)
                {
                    Assert.Contains("InAccount restore of individual shared database collections is not supported. Please restore shared database to restore its collections that shared the throughput.", ex.Message);
                }

                //restore database
                await mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName);
                Thread.Sleep(5000);

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParametersForRestore = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource
                    {
                        Id = databaseName,
                        RestoreParameters = new ResourceRestoreParameters
                        {
                            RestoreSource = restoreSource,
                            RestoreTimestampInUtc = restoreTimestampInUtc
                        },
                        CreateMode = CreateMode.Restore
                    },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseRestoreResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParametersForRestore).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseRestoreResults);
                Assert.Equal(databaseName, mongoDBDatabaseRestoreResults.Name);

                Thread.Sleep(10000);

                //list shared ru collections
                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = mongoClient.ListMongoDBCollectionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollections);

                foreach (MongoDBCollectionGetResults mongoDBCollection in mongoDBCollections)
                {
                    await mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBCollection.Name);
                }

                //list databases
                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = mongoClient.ListMongoDBDatabasesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);
                foreach (MongoDBDatabaseGetResults mongoDBDatabase in mongoDBDatabases)
                {
                    await mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, mongoDBDatabase.Name);
                }
            }
        }

        [Fact]
        public void MongoPartitionRedistributionTests()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;
                this.fixture.ResourceGroupName = "cosmosTest";
                var databaseAccountName = "adrutest3";

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
                string collectionName = TestUtilities.GenerateName(prefix: "mongoCollection");

                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    mongoDBDatabaseCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);

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
                    {
                        Throughput = 15000
                    }
                };

                MongoDBCollectionGetResults mongoDBCollectionGetResults = mongoClient.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollectionGetResults);
                VerfiyMongoCollectionCreation(mongoDBCollectionGetResults, mongoDBCollectionCreateUpdateParameters);

                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = mongoClient.ListMongoDBCollectionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBCollections);

                RetrieveThroughputParameters retrieveThroughputParameters = new RetrieveThroughputParameters();
                var retrieveThroughputPropertiesResource = new RetrieveThroughputPropertiesResource();
                retrieveThroughputPropertiesResource.PhysicalPartitionIds = new List<PhysicalPartitionId>();
                for (int j = 0; j < 3; j++)
                {
                    PhysicalPartitionId physicalPartitionId = new PhysicalPartitionId()
                    {
                        Id = j.ToString()
                    };
                    retrieveThroughputPropertiesResource.PhysicalPartitionIds.Add(physicalPartitionId);
                }
                retrieveThroughputParameters.Resource = retrieveThroughputPropertiesResource;
                PhysicalPartitionThroughputInfoResult physicalPartitionThroughputInfoResult = mongoClient.MongoDBContainerRetrieveThroughputDistribution(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    retrieveThroughputParameters);

                Assert.Equal(3, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);
                for (int j = 0; j < 3; j++)
                {
                    if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "0")
                    {
                        Assert.Equal(5000, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput);
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "1")
                    {
                        Assert.Equal(5000, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput);
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "2")
                    {
                        Assert.Equal(5000, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput);
                    }
                    else
                    {
                        Assert.True(false, "unexpected id");
                    }
                }

                RedistributeThroughputParameters redistributeThroughputParameters = new RedistributeThroughputParameters();
                redistributeThroughputParameters.Resource = new RedistributeThroughputPropertiesResource();
                redistributeThroughputParameters.Resource.ThroughputPolicy = ThroughputPolicyType.Custom;

                redistributeThroughputParameters.Resource.SourcePhysicalPartitionThroughputInfo = new List<PhysicalPartitionThroughputInfoResource>();
                redistributeThroughputParameters.Resource.SourcePhysicalPartitionThroughputInfo.Add(new PhysicalPartitionThroughputInfoResource("0", 0));

                redistributeThroughputParameters.Resource.TargetPhysicalPartitionThroughputInfo = new List<PhysicalPartitionThroughputInfoResource>();
                redistributeThroughputParameters.Resource.TargetPhysicalPartitionThroughputInfo.Add(new PhysicalPartitionThroughputInfoResource("1", 7000));

                physicalPartitionThroughputInfoResult = mongoClient.MongoDBContainerRedistributeThroughput(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    redistributeThroughputParameters);
                Assert.Equal(2, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);

                for (int j = 0; j < 2; j++)
                {
                    if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "0")
                    {
                        Assert.Equal(3000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "1")
                    {
                        Assert.Equal(7000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[0].Throughput));
                    }
                    else
                    {
                        Assert.True(false, "unexpected id");
                    }
                }

                physicalPartitionThroughputInfoResult = mongoClient.MongoDBContainerRetrieveThroughputDistribution(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    retrieveThroughputParameters);

                Assert.Equal(3, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);
                for (int j = 0; j < 3; j++)
                {
                    if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "0")
                    {
                        Assert.Equal(3000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "1")
                    {
                        Assert.Equal(7000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == "2")
                    {
                        Assert.Equal(5000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else
                    {
                        Assert.True(false, "unexpected id");
                    }
                }

                mongoClient.DeleteMongoDBCollectionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName).Wait();
                mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).Wait();
            }
        }

        [Fact]
        public void MongoSharedThroughputPartitionRedistributionTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;
                this.fixture.ResourceGroupName = "cosmosTest";
                var databaseAccountName = "adrutest3";

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = 24000
                    }
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    mongoDBDatabaseCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabaseGetResults);
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);

                RetrieveThroughputParameters retrieveThroughputParameters = new RetrieveThroughputParameters();
                var retrieveThroughputPropertiesResource = new RetrieveThroughputPropertiesResource();
                retrieveThroughputPropertiesResource.PhysicalPartitionIds = new List<PhysicalPartitionId>();
                retrieveThroughputPropertiesResource.PhysicalPartitionIds.Add(new PhysicalPartitionId("-1"));
                retrieveThroughputParameters.Resource = retrieveThroughputPropertiesResource;
                PhysicalPartitionThroughputInfoResult physicalPartitionThroughputInfoResult = mongoClient.MongoDBDatabaseRetrieveThroughputDistribution(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    retrieveThroughputParameters);

                Assert.Equal(3, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);
                List<string> physicalPartitionIds = new List<string>();
                for (int j = 0; j < 3; j++)
                {
                    physicalPartitionIds.Add(physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id);
                    Assert.Equal(8000, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput);
                }

                RedistributeThroughputParameters redistributeThroughputParameters = new RedistributeThroughputParameters();
                redistributeThroughputParameters.Resource = new RedistributeThroughputPropertiesResource();
                redistributeThroughputParameters.Resource.ThroughputPolicy = ThroughputPolicyType.Custom;

                redistributeThroughputParameters.Resource.SourcePhysicalPartitionThroughputInfo = new List<PhysicalPartitionThroughputInfoResource>();
                redistributeThroughputParameters.Resource.SourcePhysicalPartitionThroughputInfo.Add(new PhysicalPartitionThroughputInfoResource(physicalPartitionIds[0], 0));

                redistributeThroughputParameters.Resource.TargetPhysicalPartitionThroughputInfo = new List<PhysicalPartitionThroughputInfoResource>();
                redistributeThroughputParameters.Resource.TargetPhysicalPartitionThroughputInfo.Add(new PhysicalPartitionThroughputInfoResource(physicalPartitionIds[1], 10000));

                physicalPartitionThroughputInfoResult = mongoClient.MongoDBDatabaseRedistributeThroughput(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    redistributeThroughputParameters);
                Assert.Equal(2, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);

                for (int j = 0; j < 2; j++)
                {
                    if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == physicalPartitionIds[0])
                    {
                        Assert.Equal(6000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == physicalPartitionIds[1])
                    {
                        Assert.Equal(10000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else
                    {
                        Assert.True(false, "unexpected id");
                    }
                }

                physicalPartitionThroughputInfoResult = mongoClient.MongoDBDatabaseRetrieveThroughputDistribution(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    retrieveThroughputParameters);

                Assert.Equal(3, physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo.Count);
                for (int j = 0; j < 3; j++)
                {
                    if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == physicalPartitionIds[0])
                    {
                        Assert.Equal(6000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == physicalPartitionIds[1])
                    {
                        Assert.Equal(10000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else if (physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Id == physicalPartitionIds[2])
                    {
                        Assert.Equal(8000, Math.Round((double)physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo[j].Throughput));
                    }
                    else
                    {
                        Assert.True(false, "unexpected id");
                    }
                }

                mongoClient.DeleteMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).Wait();
            }
        }

        [Fact]
        public void MongoUsersAndRolesTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Location = "west us 2";
                fixture.Init(context);
                string databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);
                var mongoClient = this.fixture.CosmosDBManagementClient.MongoDBResources;

                string databaseName = TestUtilities.GenerateName(prefix: "mongoDb");
                string databaseName2 = TestUtilities.GenerateName(prefix: "mongoDb");
                string collectionName = TestUtilities.GenerateName(prefix: "mongoCollection");

                string roleName1 = "role1";
                string roleName2 = "role2";
                string roleId1 = databaseName + "." + roleName1;
                string roleId2 = databaseName + "." + roleName2;
                string userName1 = "testuser1";

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
                    Options = new CreateUpdateOptions(),
                    Location = "west us 2"
                };

                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = mongoClient.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseName, mongoDBDatabaseGetResults.Name);
                Assert.NotNull(mongoDBDatabaseGetResults);

                MongoRoleDefinitionCreateUpdateParameters mongoRoleDefinitionCreateUpdateParameters1 = new MongoRoleDefinitionCreateUpdateParameters
                {
                    RoleName = roleName1,
                    DatabaseName = databaseName,
                    Type = MongoRoleDefinitionType.CustomRole,
                    Privileges = new List<Privilege>
                {
                    new Privilege
                    {
                        Resource = new PrivilegeResource
                        {
                            Db = databaseName,
                            Collection = "test"
                        },
                        Actions = new List<string>
                        {
                            "insert"
                        }
                    }

                }
                };

                // Create Role Definition
                MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults = mongoClient.CreateUpdateMongoRoleDefinitionWithHttpMessagesAsync(roleId1, this.fixture.ResourceGroupName, databaseAccountName, mongoRoleDefinitionCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionGetResults);
                Assert.Equal(roleName1, mongoRoleDefinitionGetResults.Name);
                VerifyCreateUpdateRoleDefinition(mongoRoleDefinitionCreateUpdateParameters1, mongoRoleDefinitionGetResults);

                // Get Role Definition
                MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults2 = mongoClient.GetMongoRoleDefinitionWithHttpMessagesAsync(roleId1, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionGetResults2);
                Assert.Equal(roleName1, mongoRoleDefinitionGetResults2.Name);

                VerifyEqualMongoRoleDefinitions(mongoRoleDefinitionGetResults, mongoRoleDefinitionGetResults2);

                // Create role definition using inherited role
                MongoRoleDefinitionCreateUpdateParameters mongoRoleDefinitionCreateUpdateParameters2 = new MongoRoleDefinitionCreateUpdateParameters
                {
                    RoleName = roleName2,
                    DatabaseName = databaseName,
                    Type = MongoRoleDefinitionType.CustomRole,
                    Privileges = new List<Privilege>
                    {
                        new Privilege
                        {
                            Resource = new PrivilegeResource
                            {
                                Db = databaseName,
                                Collection = "test"
                            },
                            Actions = new List<string>
                            {
                                "find"
                            }
                        }

                    },
                    Roles = new List<Role>
                    {   new Role
                        {
                            Db = databaseName,
                            RoleProperty = roleName1

                        }
                    }
                };

                MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults3 = mongoClient.CreateUpdateMongoRoleDefinitionWithHttpMessagesAsync(roleId2, this.fixture.ResourceGroupName, databaseAccountName, mongoRoleDefinitionCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionGetResults3);
                Assert.Equal(roleName2, mongoRoleDefinitionGetResults3.Name);
                VerifyCreateUpdateRoleDefinition(mongoRoleDefinitionCreateUpdateParameters2, mongoRoleDefinitionGetResults3);

                MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults4 = mongoClient.GetMongoRoleDefinitionWithHttpMessagesAsync(roleId2, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionGetResults4);
                Assert.Equal(roleName2, mongoRoleDefinitionGetResults4.Name);

                VerifyEqualMongoRoleDefinitions(mongoRoleDefinitionGetResults3, mongoRoleDefinitionGetResults4);

                // Update existing role definition
                mongoRoleDefinitionCreateUpdateParameters2.Privileges[0].Actions.Add("remove");
                mongoRoleDefinitionGetResults3 = mongoClient.CreateUpdateMongoRoleDefinitionWithHttpMessagesAsync(roleId2, this.fixture.ResourceGroupName, databaseAccountName, mongoRoleDefinitionCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionGetResults3);
                Assert.Equal(roleName2, mongoRoleDefinitionGetResults3.Name);
                VerifyCreateUpdateRoleDefinition(mongoRoleDefinitionCreateUpdateParameters2, mongoRoleDefinitionGetResults3);

                // List Role Definition
                IEnumerable<MongoRoleDefinitionGetResults> mongoRoleDefinitionList = mongoClient.ListMongoRoleDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionList);
                List<string> roleDefNames = new List<string>();
                roleDefNames.Add(roleName1);
                roleDefNames.Add(roleName2);
                verifyRoleDefinitionListResponse(mongoRoleDefinitionList, roleDefNames);

                // User Definition
                MongoUserDefinitionCreateUpdateParameters mongoUserDefinitionCreateUpdateParameters1 = new MongoUserDefinitionCreateUpdateParameters
                {
                    UserName = "testuser1",
                    Password = "test",
                    DatabaseName = databaseName,
                    CustomData = "test",
                    Mechanisms = "SCRAM-SHA-256",
                    Roles = new List<Role>
                    {   new Role
                        {
                            Db = databaseName,
                            RoleProperty = roleName1

                        }
                    }
                };

                MongoUserDefinitionGetResults mongoUserDefinitionGetResults = mongoClient.CreateUpdateMongoUserDefinitionWithHttpMessagesAsync(databaseName + ".testuser1", this.fixture.ResourceGroupName, databaseAccountName, mongoUserDefinitionCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoUserDefinitionGetResults);
                Assert.Equal("testuser1", mongoUserDefinitionGetResults.UserName);
                Assert.Equal(mongoUserDefinitionCreateUpdateParameters1.Roles.Count, mongoUserDefinitionGetResults.Roles.Count);
                Assert.Equal(roleName1, mongoUserDefinitionGetResults.Roles[0].RoleProperty);

                MongoUserDefinitionGetResults mongoUserDefinitionGetResults2 = mongoClient.GetMongoUserDefinitionWithHttpMessagesAsync(databaseName + ".testuser1", this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoUserDefinitionGetResults2);
                Assert.Equal("testuser1", mongoUserDefinitionGetResults2.UserName);
                Assert.Equal(mongoUserDefinitionGetResults2.Roles.Count, mongoUserDefinitionGetResults.Roles.Count);

                // Update existing user definition
                mongoUserDefinitionCreateUpdateParameters1.Roles[0].RoleProperty = roleName2;
                mongoUserDefinitionGetResults = mongoClient.CreateUpdateMongoUserDefinitionWithHttpMessagesAsync(databaseName + ".testuser1", this.fixture.ResourceGroupName, databaseAccountName, mongoUserDefinitionCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoUserDefinitionGetResults);
                Assert.Equal("testuser1", mongoUserDefinitionGetResults.UserName);
                Assert.Equal(mongoUserDefinitionCreateUpdateParameters1.Roles.Count, mongoUserDefinitionGetResults.Roles.Count);
                Assert.Equal(roleName2, mongoUserDefinitionGetResults.Roles[0].RoleProperty);

                // List User Definition
                IEnumerable<MongoUserDefinitionGetResults> mongoUserDefinitionList = mongoClient.ListMongoUserDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoUserDefinitionList);
                List<string> userNames = new List<string>();
                userNames.Add(userName1);
                
                verifyUserDefinitionListResponse(mongoUserDefinitionList, userNames);

                // Delete User Definition
                mongoClient.DeleteMongoUserDefinitionWithHttpMessagesAsync(databaseName + "." + userName1, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult();
                mongoUserDefinitionList = mongoClient.ListMongoUserDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoUserDefinitionList);
                Assert.True(mongoUserDefinitionList.Count() == 0);

                // Delete Role Definition
                mongoClient.DeleteMongoRoleDefinitionWithHttpMessagesAsync(roleId2, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult();

                mongoRoleDefinitionList = mongoClient.ListMongoRoleDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionList);
                Assert.True(mongoRoleDefinitionList.Count() == 1);

                mongoClient.DeleteMongoRoleDefinitionWithHttpMessagesAsync(roleId1, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult();

                mongoRoleDefinitionList = mongoClient.ListMongoRoleDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoRoleDefinitionList);
                Assert.True(mongoRoleDefinitionList.Count() == 0);

                IEnumerable<MongoDBDatabaseGetResults> mongoDBDatabases = mongoClient.ListMongoDBDatabasesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(mongoDBDatabases);

                
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

        private void verifyRoleDefinitionListResponse(IEnumerable<MongoRoleDefinitionGetResults> roleDefList, List<string> roleDefNames)
        {
            Assert.True(roleDefList != null && roleDefNames != null);
            Assert.True(roleDefList.Count() == roleDefNames.Count);
            int found = 0;
            foreach (MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults in roleDefList)
            {
                string retrievedRoleDefName = mongoRoleDefinitionGetResults.Name;

                foreach (string roleDefName in roleDefNames)
                {
                    if (string.Equals(roleDefName, retrievedRoleDefName))
                    {
                        found++;
                        break;
                    }
                }
            }

            Assert.Equal(roleDefNames.Count, found);
        }

        private void verifyUserDefinitionListResponse(IEnumerable<MongoUserDefinitionGetResults> UserDefList, List<string> userNames)
        {
            Assert.True(UserDefList != null && userNames != null);
            Assert.True(UserDefList.Count() == userNames.Count);
            int found = 0;
            foreach (MongoUserDefinitionGetResults mongoUserDefinitionGetResults in UserDefList)
            {
                string retrievedUserName = mongoUserDefinitionGetResults.UserName;

                foreach (string userName in userNames)
                {
                    if (string.Equals(userName, retrievedUserName))
                    {
                        found++;
                        break;
                    }
                }
            }

            Assert.Equal(userNames.Count, found);
        }

        private void VerifyCreateUpdateRoleDefinition(MongoRoleDefinitionCreateUpdateParameters mongoRoleDefinitionCreateUpdateParameters, MongoRoleDefinitionGetResults mogoRoleDefinitionGetResults)
        {
            Assert.Equal(mongoRoleDefinitionCreateUpdateParameters.RoleName, mogoRoleDefinitionGetResults.RoleName);
            Assert.Equal(mongoRoleDefinitionCreateUpdateParameters.Privileges.Count, mogoRoleDefinitionGetResults.Privileges.Count);
            
            for (int i = 0; i < mongoRoleDefinitionCreateUpdateParameters.Privileges.Count; i++)
            {
                Assert.Equal(mogoRoleDefinitionGetResults.Privileges[i].Actions.Count, mogoRoleDefinitionGetResults.Privileges[i].Actions.Count);
            }
        }

        private void VerifyEqualMongoRoleDefinitions(MongoRoleDefinitionGetResults expectedValue, MongoRoleDefinitionGetResults actualValue)
        {
            Assert.Equal(expectedValue.Name, actualValue.Name);
            Assert.Equal(expectedValue.Id, actualValue.Id);
            Assert.Equal(expectedValue.Type, actualValue.Type);
            Assert.Equal(expectedValue.RoleName, actualValue.RoleName);
            Assert.Equal(expectedValue.Privileges.Count, actualValue.Privileges.Count);
            for (int i = 0; i < expectedValue.Privileges.Count; i++)
            {
                Assert.Equal(expectedValue.Privileges[i].Actions.Count, actualValue.Privileges[i].Actions.Count);
            }
        }
    }
}