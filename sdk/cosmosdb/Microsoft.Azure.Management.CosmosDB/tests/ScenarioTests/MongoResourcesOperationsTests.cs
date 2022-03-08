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