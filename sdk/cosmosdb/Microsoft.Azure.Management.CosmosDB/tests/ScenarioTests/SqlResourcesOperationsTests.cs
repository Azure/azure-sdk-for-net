// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.Management.CosmosDB;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class SqlResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;

        public SqlResourcesOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        const string roleDefinitionId = "70580ac3-cd0b-4549-8336-2f0d55df111e";
        const string roleDefinitionId2 = "fbf74201-f33f-46f0-8234-2b8bf15ecec4";
        const string roleDefinitionId3 = "a5d92de7-1c34-481e-aafa-44f5cb03744c";
        const string roleAssignmentId = "adcb35e1-e104-41c2-b76d-70a8b03e6463";
        const string roleAssignmentId2 = "d5fcc566-a91c-4fce-8f54-138855981e63";
        const string principalId = "ed4c2395-a18c-4018-afb3-6e521e7534d2";
        const string principalId2 = "d60019b0-c5a8-4e38-beb9-fb80daa3ce90";

        const string sqlThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings";

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
        public void SqlCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var client = this.fixture.CosmosDBManagementClient.SqlResources;

                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);

                var databaseName = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                SqlDatabaseGetResults sqlDatabaseGetResults = client.CreateUpdateSqlDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults);
                Assert.Equal(databaseName, sqlDatabaseGetResults.Name);

                SqlDatabaseGetResults sqlDatabaseGetResults2 = client.GetSqlDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults2);
                Assert.Equal(databaseName, sqlDatabaseGetResults2.Name);

                VerifyEqualSqlDatabases(sqlDatabaseGetResults, sqlDatabaseGetResults2);

                var databaseName2 = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 = new SqlDatabaseCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = tags,
                    Resource = new SqlDatabaseResource { Id = databaseName2 },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                SqlDatabaseGetResults sqlDatabaseGetResults3 = client.CreateUpdateSqlDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName2,
                    sqlDatabaseCreateUpdateParameters2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabaseGetResults3);
                Assert.Equal(databaseName2, sqlDatabaseGetResults3.Name);

                IEnumerable<SqlDatabaseGetResults> sqlDatabases = client.ListSqlDatabasesWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlDatabases);

                ThroughputSettingsGetResults throughputSettingsGetResults = client.GetSqlDatabaseThroughputWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName2).GetAwaiter().GetResult().Body;
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Name);
                Assert.Equal(sqlThroughputType, throughputSettingsGetResults.Type);

                var containerName = TestUtilities.GenerateName("container");
                SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
                {
                    Resource = new SqlContainerResource
                    {
                        Id = containerName,
                        PartitionKey = new ContainerPartitionKey
                        {
                            Kind = "Hash",
                            Paths = new List<string> { "/address/zipCode" }
                        },
                        IndexingPolicy = new IndexingPolicy
                        {
                            Automatic = true,
                            IndexingMode = IndexingMode.Consistent,
                            IncludedPaths = new List<IncludedPath>
                        {
                            new IncludedPath { Path = "/*"}
                        },
                            ExcludedPaths = new List<ExcludedPath>
                        {
                            new ExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                            CompositeIndexes = new List<IList<CompositePath>>
                        {
                            new List<CompositePath>
                            {
                                new CompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                                new CompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                            },
                            new List<CompositePath>
                            {
                                new CompositePath { Path = "/orderByPath3", Order = CompositePathSortOrder.Ascending },
                                new CompositePath { Path = "/orderByPath4", Order = CompositePathSortOrder.Descending }
                            }
                        }
                        }
                    },
                    Options = new CreateUpdateOptions
                    {
                        Throughput = sampleThroughput
                    }
                };

                SqlContainerGetResults sqlContainerGetResults = client.CreateUpdateSqlContainerWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainerGetResults);

                IEnumerable<SqlContainerGetResults> sqlContainers = client.ListSqlContainersWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlContainers);

                var storedProcedureName = TestUtilities.GenerateName("storedproc");
                SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters
                {
                    Resource = new SqlStoredProcedureResource
                    {
                        Id = storedProcedureName,
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlStoredProcedureGetResults sqlStoredProcedureGetResults = client.CreateUpdateSqlStoredProcedureWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedureGetResults);
                Assert.Equal(sqlStoredProcedureGetResults.Resource.Body, sqlStoredProcedureGetResults.Resource.Body);

                IEnumerable<SqlStoredProcedureGetResults> sqlStoredProcedures = client.ListSqlStoredProceduresWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlStoredProcedures);

                foreach (SqlStoredProcedureGetResults sqlStoredProcedure in sqlStoredProcedures)
                {
                    client.DeleteSqlStoredProcedureWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, sqlStoredProcedure.Name);
                }

                var userDefinedFunctionName = TestUtilities.GenerateName("udf");
                SqlUserDefinedFunctionCreateUpdateParameters sqlUserDefinedFunctionCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters
                {
                    Resource = new SqlUserDefinedFunctionResource
                    {
                        Id = userDefinedFunctionName,
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = client.CreateUpdateSqlUserDefinedFunctionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlUserDefinedFunctionGetResults);
                Assert.Equal(sqlUserDefinedFunctionGetResults.Resource.Body, sqlUserDefinedFunctionGetResults.Resource.Body);


                IEnumerable<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = client.ListSqlUserDefinedFunctionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlUserDefinedFunctions);

                foreach (SqlUserDefinedFunctionGetResults sqlUserDefinedFunction in sqlUserDefinedFunctions)
                {
                    client.DeleteSqlUserDefinedFunctionWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, sqlUserDefinedFunction.Name);
                }

                var triggerName = TestUtilities.GenerateName("trigger");
                SqlTriggerCreateUpdateParameters sqlTriggerCreateUpdateParameters = new SqlTriggerCreateUpdateParameters
                {
                    Resource = new SqlTriggerResource
                    {
                        Id = triggerName,
                        TriggerOperation = "All",
                        TriggerType = "Pre",
                        Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
                    },
                    Options = new CreateUpdateOptions()
                };

                SqlTriggerGetResults sqlTriggerGetResults = client.CreateUpdateSqlTriggerWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlTriggerGetResults);
                Assert.Equal(sqlTriggerGetResults.Resource.TriggerType, sqlTriggerCreateUpdateParameters.Resource.TriggerType);
                Assert.Equal(sqlTriggerGetResults.Resource.TriggerOperation, sqlTriggerCreateUpdateParameters.Resource.TriggerOperation);
                Assert.Equal(sqlTriggerGetResults.Resource.Body, sqlTriggerCreateUpdateParameters.Resource.Body);

                IEnumerable<SqlTriggerGetResults> sqlTriggers = client.ListSqlTriggersWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlTriggers);

                foreach (SqlTriggerGetResults sqlTrigger in sqlTriggers)
                {
                    client.DeleteSqlTriggerWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName, sqlTrigger.Name);
                }

                foreach (SqlContainerGetResults sqlContainer in sqlContainers)
                {
                    client.DeleteSqlContainerWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, sqlContainer.Name);
                }

                foreach (SqlDatabaseGetResults sqlDatabase in sqlDatabases)
                {
                    client.DeleteSqlDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, sqlDatabase.Name);
                }
            }
        }
        

        [Fact]
        public void SqlRoleTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);
                var client = this.fixture.CosmosDBManagementClient.SqlResources;

                var databaseName = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 = new SqlDatabaseCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Resource = new SqlDatabaseResource { Id = databaseName },
                };
                client.CreateUpdateSqlDatabaseWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters2
                ).GetAwaiter().GetResult();

                SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters = new SqlRoleDefinitionCreateUpdateParameters
                {
                    RoleName = "roleName",
                    Type = RoleDefinitionType.CustomRole,
                    AssignableScopes = new List<string>
                {
                    string.Format(
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}",
                        this.fixture.CosmosDBManagementClient.SubscriptionId,
                        this.fixture.ResourceGroupName,
                        databaseAccountName),

                },
                    Permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = new List<string>
                        {
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/read"
                        }
                    }
                }
                };

                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults = client.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(roleDefinitionId, this.fixture.ResourceGroupName, databaseAccountName, sqlRoleDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleDefinitionGetResults);
                Assert.Equal(roleDefinitionId, sqlRoleDefinitionGetResults.Name);
                VerifyCreateUpdateRoleDefinition(sqlRoleDefinitionCreateUpdateParameters, sqlRoleDefinitionGetResults);

                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults2 = client.GetSqlRoleDefinitionWithHttpMessagesAsync(roleDefinitionId, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleDefinitionGetResults2);
                Assert.Equal(roleDefinitionId, sqlRoleDefinitionGetResults2.Name);

                VerifyEqualSqlRoleDefinitions(sqlRoleDefinitionGetResults, sqlRoleDefinitionGetResults2);

                SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters2 = new SqlRoleDefinitionCreateUpdateParameters
                {
                    RoleName = "roleName2",
                    Type = RoleDefinitionType.CustomRole,
                    AssignableScopes = new List<string>
                {
                    string.Format(
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}",
                        this.fixture.CosmosDBManagementClient.SubscriptionId,
                        this.fixture.ResourceGroupName,
                        databaseAccountName
                    )
                },
                    Permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = new List<string>
                        {
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/read",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/delete",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/replace"
                        }
                    }
                }
                };

                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults3 = client.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(
                    roleDefinitionId2,
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    sqlRoleDefinitionCreateUpdateParameters2
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleDefinitionGetResults3);
                Assert.Equal(roleDefinitionId2, sqlRoleDefinitionGetResults3.Name);
                VerifyCreateUpdateRoleDefinition(sqlRoleDefinitionCreateUpdateParameters2, sqlRoleDefinitionGetResults3);

                SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters3 = new SqlRoleDefinitionCreateUpdateParameters
                {
                    RoleName = "roleName3",
                    Type = RoleDefinitionType.CustomRole,
                    AssignableScopes = new List<string>
                {
                    string.Format(
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}",
                        this.fixture.CosmosDBManagementClient.SubscriptionId,
                        this.fixture.ResourceGroupName,
                        databaseAccountName
                    )
                },
                    Permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = new List<string>
                        {
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/delete",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/replace"
                        }
                    }
                }
                };

                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults4 = client.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(roleDefinitionId, this.fixture.ResourceGroupName, databaseAccountName, sqlRoleDefinitionCreateUpdateParameters3).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleDefinitionGetResults4);
                Assert.Equal(roleDefinitionId, sqlRoleDefinitionGetResults4.Name);
                VerifyCreateUpdateRoleDefinition(sqlRoleDefinitionCreateUpdateParameters3, sqlRoleDefinitionGetResults4);

                IEnumerable<SqlRoleDefinitionGetResults> sqlRoleDefinitions = client.ListSqlRoleDefinitionsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleDefinitions);
                foreach (SqlRoleDefinitionGetResults sqlRoleDefinition in sqlRoleDefinitions)
                {
                    if (sqlRoleDefinition.Name == sqlRoleDefinitionGetResults3.Name)
                    {
                        VerifyEqualSqlRoleDefinitions(sqlRoleDefinitionGetResults3, sqlRoleDefinition);
                    }
                    if (sqlRoleDefinition.Name == sqlRoleDefinitionGetResults4.Name)
                    {
                        VerifyEqualSqlRoleDefinitions(sqlRoleDefinitionGetResults4, sqlRoleDefinition);
                    }
                }

                SqlRoleAssignmentCreateUpdateParameters sqlRoleAssignmentCreateUpdateParameters = new SqlRoleAssignmentCreateUpdateParameters
                {
                    RoleDefinitionId = sqlRoleDefinitionGetResults.Id,
                    Scope = string.Format(
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}/dbs/{3}",
                        this.fixture.CosmosDBManagementClient.SubscriptionId,
                        this.fixture.ResourceGroupName,
                        databaseAccountName,
                        databaseName
                    ),
                    PrincipalId = principalId
                };

                SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults = client.CreateUpdateSqlRoleAssignmentWithHttpMessagesAsync(
                    roleAssignmentId,
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    sqlRoleAssignmentCreateUpdateParameters
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleAssignmentGetResults);
                Assert.Equal(roleAssignmentId, sqlRoleAssignmentGetResults.Name);
                VerifyCreateUpdateRoleAssignment(sqlRoleAssignmentCreateUpdateParameters, sqlRoleAssignmentGetResults);

                SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults2 = client.GetSqlRoleAssignmentWithHttpMessagesAsync(roleAssignmentId, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleAssignmentGetResults2);
                Assert.Equal(roleAssignmentId, sqlRoleAssignmentGetResults2.Name);

                VerifyEqualSqlRoleAssignments(sqlRoleAssignmentGetResults, sqlRoleAssignmentGetResults2);

                SqlRoleAssignmentCreateUpdateParameters sqlRoleAssignmentCreateUpdateParameters2 = new SqlRoleAssignmentCreateUpdateParameters
                {
                    RoleDefinitionId = sqlRoleDefinitionGetResults3.Id,
                    Scope = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}", this.fixture.CosmosDBManagementClient.SubscriptionId, this.fixture.ResourceGroupName, databaseAccountName),
                    PrincipalId = principalId2
                };

                SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults3 = client.CreateUpdateSqlRoleAssignmentWithHttpMessagesAsync(roleAssignmentId2, this.fixture.ResourceGroupName, databaseAccountName, sqlRoleAssignmentCreateUpdateParameters2).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleAssignmentGetResults3);
                Assert.Equal(roleAssignmentId2, sqlRoleAssignmentGetResults3.Name);
                VerifyCreateUpdateRoleAssignment(sqlRoleAssignmentCreateUpdateParameters2, sqlRoleAssignmentGetResults3);

                IEnumerable<SqlRoleAssignmentGetResults> sqlRoleAssignments = client.ListSqlRoleAssignmentsWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(sqlRoleAssignments);
                foreach (SqlRoleAssignmentGetResults sqlRoleAssignment in sqlRoleAssignments)
                {
                    VerifyEqualSqlRoleAssignments(sqlRoleAssignment.Name == sqlRoleAssignmentGetResults.Name ? sqlRoleAssignmentGetResults : sqlRoleAssignmentGetResults3, sqlRoleAssignment);
                }

                foreach (SqlRoleAssignmentGetResults sqlRoleAssignment in sqlRoleAssignments)
                {
                    client.DeleteSqlRoleAssignmentWithHttpMessagesAsync(sqlRoleAssignment.Name, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult();
                }

                foreach (SqlRoleDefinitionGetResults sqlRoleDefinition in sqlRoleDefinitions)
                {
                    if (sqlRoleDefinition.Name == sqlRoleDefinitionGetResults3.Name || sqlRoleDefinition.Name == sqlRoleDefinitionGetResults4.Name)
                    {
                        client.DeleteSqlRoleDefinitionWithHttpMessagesAsync(sqlRoleDefinition.Name, this.fixture.ResourceGroupName, databaseAccountName).GetAwaiter().GetResult();
                    }
                }

                const string InvalidActionName = "invalid-action-name";

                SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters4 = new SqlRoleDefinitionCreateUpdateParameters
                {
                    RoleName = "roleName4",
                    Type = RoleDefinitionType.CustomRole,
                    AssignableScopes = new List<string>
                {
                    string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDB/databaseAccounts/{2}", this.fixture.CosmosDBManagementClient.SubscriptionId, this.fixture.ResourceGroupName, databaseAccountName)
                },
                    Permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = new List<string>
                        {
                            InvalidActionName,
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/delete",
                            "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/replace"
                        }
                    }
                }
                };

                Exception exception =
                    Assert.ThrowsAnyAsync<Exception>(() =>
                        client.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(roleDefinitionId3, this.fixture.ResourceGroupName, databaseAccountName, sqlRoleDefinitionCreateUpdateParameters4))
                        .GetAwaiter().GetResult();

                Assert.Contains(InvalidActionName, exception.Message);
            }
        }

        [Fact]
        public void SqlAccountBackupPolicyTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                CosmosDBManagementClient cosmosDBManagementClient = this.fixture.CosmosDBManagementClient;
                string location = this.fixture.Location;
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Sql);
                var resourceGroupName = this.fixture.ResourceGroupName;
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Kind = DatabaseAccountKind.GlobalDocumentDB,
                        Locations = new List<Location>()
                    {
                        {new Location(locationName: location) }
                    },
                        BackupPolicy = new PeriodicModeBackupPolicy()
                        {
                            PeriodicModeProperties = new PeriodicModeProperties()
                            {
                                BackupIntervalInMinutes = 60,
                                BackupRetentionIntervalInHours = 8,
                                BackupStorageRedundancy = BackupStorageRedundancy.Geo
                            }
                        }
                    };

                    DatabaseAccountGetResults databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                    Assert.Equal(databaseAccount.Name, databaseAccountName);
                    PeriodicModeBackupPolicy backupPolicy = databaseAccount.BackupPolicy as PeriodicModeBackupPolicy;
                    Assert.Equal(60, backupPolicy.PeriodicModeProperties.BackupIntervalInMinutes);
                    Assert.Equal(8, backupPolicy.PeriodicModeProperties.BackupRetentionIntervalInHours);
                    Assert.Equal(BackupStorageRedundancy.Geo, backupPolicy.PeriodicModeProperties.BackupStorageRedundancy);
                }

                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Kind = DatabaseAccountKind.GlobalDocumentDB,
                        Locations = new List<Location>()
                    {
                        {new Location(locationName: location) }
                    },
                        BackupPolicy = new PeriodicModeBackupPolicy()
                        {
                            PeriodicModeProperties = new PeriodicModeProperties()
                            {
                                BackupIntervalInMinutes = 60,
                                BackupRetentionIntervalInHours = 12,
                                BackupStorageRedundancy = BackupStorageRedundancy.Local
                            }
                        }
                    };

                    DatabaseAccountGetResults databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                    Assert.Equal(databaseAccount.Name, databaseAccountName);
                    PeriodicModeBackupPolicy backupPolicy = databaseAccount.BackupPolicy as PeriodicModeBackupPolicy;
                    Assert.Equal(60, backupPolicy.PeriodicModeProperties.BackupIntervalInMinutes);
                    Assert.Equal(12, backupPolicy.PeriodicModeProperties.BackupRetentionIntervalInHours);
                    Assert.Equal(BackupStorageRedundancy.Local, backupPolicy.PeriodicModeProperties.BackupStorageRedundancy);
                }
            }
        }

        private void VerifySqlContainerCreation(SqlContainerGetResults sqlContainerGetResults, SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters)
        {
            Assert.Equal(sqlContainerGetResults.Resource.Id, sqlContainerCreateUpdateParameters.Resource.Id);
            Assert.Equal(sqlContainerGetResults.Resource.IndexingPolicy.IndexingMode.ToLower(), sqlContainerCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode.ToLower());
            //Assert.Equal(sqlContainerGetResults.Resource.IndexingPolicy.ExcludedPaths, sqlContainerCreateUpdateParameters.Resource.IndexingPolicy.ExcludedPaths);
            Assert.Equal(sqlContainerGetResults.Resource.PartitionKey.Kind, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.Equal(sqlContainerGetResults.Resource.PartitionKey.Paths, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.Equal(sqlContainerGetResults.Resource.DefaultTtl, sqlContainerCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualSqlDatabases(SqlDatabaseGetResults expectedValue, SqlDatabaseGetResults actualValue)
        {
            Assert.Equal(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.Equal(expectedValue.Resource._rid, actualValue.Resource._rid);
            Assert.Equal(expectedValue.Resource._ts, actualValue.Resource._ts);
            Assert.Equal(expectedValue.Resource._etag, actualValue.Resource._etag);
            Assert.Equal(expectedValue.Resource._colls, actualValue.Resource._colls);
            Assert.Equal(expectedValue.Resource._users, actualValue.Resource._users);
        }

        private void VerifyEqualSqlRoleDefinitions(SqlRoleDefinitionGetResults expectedValue, SqlRoleDefinitionGetResults actualValue)
        {
            Assert.Equal(expectedValue.Name, actualValue.Name);
            Assert.Equal(expectedValue.Id, actualValue.Id);
            Assert.Equal(expectedValue.Type, actualValue.Type);
            Assert.Equal(expectedValue.RoleName, actualValue.RoleName);
            Assert.Equal(expectedValue.AssignableScopes, actualValue.AssignableScopes);
            Assert.Equal(expectedValue.Permissions.Count, actualValue.Permissions.Count);
            for (int i = 0; i < expectedValue.Permissions.Count; i++)
            {
                Assert.Equal(expectedValue.Permissions[i].DataActions.Count, actualValue.Permissions[i].DataActions.Count);
                Assert.Equal(expectedValue.Permissions[i].NotDataActions.Count, actualValue.Permissions[i].NotDataActions.Count);
            }
        }

        private void VerifyCreateUpdateRoleDefinition(SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters, SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults)
        {
            Assert.Equal(sqlRoleDefinitionCreateUpdateParameters.RoleName, sqlRoleDefinitionGetResults.RoleName);
            Assert.Equal(sqlRoleDefinitionCreateUpdateParameters.AssignableScopes.Count, sqlRoleDefinitionGetResults.AssignableScopes.Count);
            Assert.Equal(sqlRoleDefinitionCreateUpdateParameters.Permissions.Count, sqlRoleDefinitionGetResults.Permissions.Count);
            for (int i = 0; i < sqlRoleDefinitionCreateUpdateParameters.Permissions.Count; i++)
            {
                Assert.Equal(sqlRoleDefinitionCreateUpdateParameters.Permissions[i].DataActions.Count, sqlRoleDefinitionGetResults.Permissions[i].DataActions.Count);
            }
        }

        private void VerifyEqualSqlRoleAssignments(SqlRoleAssignmentGetResults expectedValue, SqlRoleAssignmentGetResults actualValue)
        {
            Assert.Equal(expectedValue.Name, actualValue.Name);
            Assert.Equal(expectedValue.Id, actualValue.Id);
            Assert.Equal(expectedValue.Type, actualValue.Type);
            Assert.Equal(expectedValue.Scope, actualValue.Scope);
            Assert.Equal(expectedValue.PrincipalId, actualValue.PrincipalId);
        }

        private void VerifyCreateUpdateRoleAssignment(SqlRoleAssignmentCreateUpdateParameters sqlRoleAssignmentCreateUpdateParameters, SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults)
        {
            Assert.Equal(sqlRoleAssignmentCreateUpdateParameters.RoleDefinitionId, sqlRoleAssignmentGetResults.RoleDefinitionId);
            Assert.Equal(sqlRoleAssignmentCreateUpdateParameters.Scope, sqlRoleAssignmentGetResults.Scope);
            Assert.Equal(sqlRoleAssignmentCreateUpdateParameters.PrincipalId, sqlRoleAssignmentGetResults.PrincipalId);
        }
    }
}