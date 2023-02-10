// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RestoreDatabaseAccountOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;

        public RestoreDatabaseAccountOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task RestoreSqlDatabaseAccountWithNewAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.SqlResources.BeginCreateUpdateSqlDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters
                );
                var containerName = TestUtilities.GenerateName("container");
                SqlContainerCreateUpdateParameters collectionCreateParams = new SqlContainerCreateUpdateParameters()
                {
                    Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var containerResults = await this.fixture.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    collectionCreateParams
                );

                var ts = DateTimeOffset.FromUnixTimeSeconds((int)containerResults.Resource._ts).DateTime;
                TestUtilities.Wait(10000);

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = ts.AddSeconds(1),
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("restoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);

                ContinuousModeBackupPolicy policy = restoredDatabaseAccount.BackupPolicy as ContinuousModeBackupPolicy;
                Assert.NotNull(policy.ContinuousModeProperties);
                Assert.Equal(ContinuousTier.Continuous30Days, policy.ContinuousModeProperties.Tier);
            }
        }

        [Fact]
        public async Task RestoreContinuous7DaysSqlDatabaseAccountWithNewAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Pitr7Sql);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.SqlResources.BeginCreateUpdateSqlDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters
                );
                var containerName = TestUtilities.GenerateName("container");
                SqlContainerCreateUpdateParameters collectionCreateParams = new SqlContainerCreateUpdateParameters()
                {
                    Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var containerResults = await this.fixture.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    collectionCreateParams
                );

                var ts = DateTimeOffset.FromUnixTimeSeconds((int)containerResults.Resource._ts).DateTime;
                TestUtilities.Wait(10000);

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = ts.AddSeconds(1),
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("restoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);

                ContinuousModeBackupPolicy policy = restoredDatabaseAccount.BackupPolicy as ContinuousModeBackupPolicy;
                Assert.NotNull(policy.ContinuousModeProperties);
                Assert.Equal(ContinuousTier.Continuous7Days, policy.ContinuousModeProperties.Tier);
            }
        }

        [Fact]
        public async Task RestoreMongoDBDatabaseAccountWithNewAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.MongoDBResources.BeginCreateUpdateMongoDBDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    mongoDBDatabaseCreateUpdateParameters
                );
                var collectionName = TestUtilities.GenerateName("collection");
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("partitionKey", PartitionKind.Hash.ToString());
                MongoDBCollectionCreateUpdateParameters collectionCreateParams = new MongoDBCollectionCreateUpdateParameters()
                {
                    Resource = new MongoDBCollectionResource(collectionName, shardKey: dict),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var collectionResult = await this.fixture.CosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    collectionCreateParams
                );

                var ts = restorableDatabaseAccount.CreationTime.Value.AddSeconds(60);
                TestUtilities.Wait(60 * 1000);

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "MongoDB",
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = ts.AddSeconds(1),
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("restoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreGremlinDatabaseAccountWithNewAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Gremlin);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters
                {
                    Resource = new GremlinDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.GremlinResources.BeginCreateUpdateGremlinDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    gremlinDatabaseCreateUpdateParameters
                );
                var graphName = TestUtilities.GenerateName("graphName");
                GremlinGraphCreateUpdateParameters collectionCreateParams = new GremlinGraphCreateUpdateParameters()
                {
                    Resource = new GremlinGraphResource(graphName, partitionKey: new ContainerPartitionKey(new List<String>() { "/pk" })),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var graphResult = await this.fixture.CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    graphName,
                    collectionCreateParams
                );

                var ts = DateTimeOffset.FromUnixTimeSeconds((int)graphResult.Resource._ts).DateTime;
                TestUtilities.Wait(10000);

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Capabilities = new List<Capability> { new Capability("EnableGremlin") },
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = ts.AddSeconds(1),
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("restoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreTableDatabaseAccountWithNewAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Table);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var tableName = TestUtilities.GenerateName("table");
                TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
                {
                    Resource = new TableResource { Id = tableName },
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };

                var tableResult = await this.fixture.CosmosDBManagementClient.TableResources.CreateUpdateTableAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    tableName,
                    tableCreateUpdateParameters
                );

                var ts = DateTimeOffset.FromUnixTimeSeconds((int)tableResult.Resource._ts).DateTime;
                TestUtilities.Wait(10000);

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Capabilities = new List<Capability> { new Capability("EnableTable") },
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = ts.AddSeconds(1),
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("restoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreSqlDatabaseAccountWithRestoreAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.SqlResources.BeginCreateUpdateSqlDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters
                );

                var containerName = TestUtilities.GenerateName("container");
                SqlContainerCreateUpdateParameters collectionCreateParams = new SqlContainerCreateUpdateParameters()
                {
                    Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var containerResults = await this.fixture.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    collectionCreateParams
                );

                // trigger restore on sql account
                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = DateTime.UtcNow,
                        RestoreSource = restorableDatabaseAccount.Id,
                        DatabasesToRestore = new List<DatabaseRestoreResource>
                        {
                            new DatabaseRestoreResource(databaseName, new List<string> { containerName })
                        }
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("sqlrestoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreMongoDBDatabaseAccountWithRestoreAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.MongoDBResources.BeginCreateUpdateMongoDBDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    mongoDBDatabaseCreateUpdateParameters
                );

                var collectionName = TestUtilities.GenerateName("collection");
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("partitionKey", PartitionKind.Hash.ToString());
                MongoDBCollectionCreateUpdateParameters collectionCreateParams = new MongoDBCollectionCreateUpdateParameters()
                {
                    Resource = new MongoDBCollectionResource(collectionName, shardKey: dict),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var collectionResult = await this.fixture.CosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    collectionCreateParams
                );

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Locations = new List<Location>
                        {
                            new Location(locationName: this.fixture.Location)
                        },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = DateTime.UtcNow,
                        RestoreSource = restorableDatabaseAccount.Id,
                        DatabasesToRestore = new List<DatabaseRestoreResource>
                            {
                               new DatabaseRestoreResource(databaseName, new List<string> { collectionName })
                            }
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("mongodbrestoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                   this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreGremlinDatabaseAccountWithRestoreAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Gremlin);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var databaseName = TestUtilities.GenerateName("database");
                GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters = new GremlinDatabaseCreateUpdateParameters
                {
                    Resource = new GremlinDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };
                await this.fixture.CosmosDBManagementClient.GremlinResources.BeginCreateUpdateGremlinDatabaseAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    gremlinDatabaseCreateUpdateParameters
                );
                var graphName = TestUtilities.GenerateName("graphName");
                GremlinGraphCreateUpdateParameters collectionCreateParams = new GremlinGraphCreateUpdateParameters()
                {
                    Resource = new GremlinGraphResource(graphName, partitionKey: new ContainerPartitionKey(new List<String>() { "/pk" })),
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };
                var graphResult = await this.fixture.CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    graphName,
                    collectionCreateParams
                );

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = DateTime.UtcNow,
                        RestoreSource = restorableDatabaseAccount.Id,
                        GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>()
                        {
                            new GremlinDatabaseRestoreResource()
                            {
                                DatabaseName = databaseName,
                                GraphNames = new List<string> {graphName}
                            }
                        }
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("amisigremlinpitracc1-full");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreTableDatabaseAccountWithRestoreAccountAPITests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Table);

                var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                var restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

                var tableName = TestUtilities.GenerateName("table");
                TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
                {
                    Resource = new TableResource { Id = tableName },
                    Options = new CreateUpdateOptions() { Throughput = 30000 }
                };

                var tableResult = await this.fixture.CosmosDBManagementClient.TableResources.CreateUpdateTableAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    tableName,
                    tableCreateUpdateParameters
                );

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Locations = new List<Location>
                    {
                        new Location(locationName: this.fixture.Location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = DateTime.UtcNow,
                        RestoreSource = restorableDatabaseAccount.Id,
                        TablesToRestore = new List<string>
                        {
                            tableName
                        }
                    }
                };
                var restoredAccountName = TestUtilities.GenerateName("tablerestoredaccount");

                DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestorableDatabaseAccountFeedTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);

                await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql), ApiType.Sql, 1);
                await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo32), ApiType.MongoDB, 1);
                await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36), ApiType.MongoDB, 1);
                await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Gremlin), "Gremlin, Sql", 1);
                await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Table), "Table, Sql", 1);
            }
        }

        [Fact(Skip = "True")]
        public async Task RestorableTableGremlinRestorableFeedAndRestoreTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                CosmosDBManagementClient cosmosDBManagementClient = this.fixture.CosmosDBManagementClient;
                var location = this.fixture.Location;

                string tableDatabaseAccountName = null;
                RestorableDatabaseAccountGetResult restorableTableDatabaseAccount = null;
                string tableAccountInstanceId = null;

                string gremlinDatabaseAccountName = null;
                RestorableDatabaseAccountGetResult restorableGremlinDatabaseAccount = null;
                string gremlinAccountInstanceId = null;

                string mongoDBDatabaseAccountName = null;
                RestorableDatabaseAccountGetResult restorableMongoDBDatabaseAccount = null;
                string mongoDBAccountInstanceId = null;

                string sqlDatabaseAccountName = null;
                RestorableDatabaseAccountGetResult restorableSqlDatabaseAccount = null;
                string sqlAccountInstanceId = null;

                // Validate retrieve backup information for table
                {
                    tableDatabaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Table);
                    TableCreateUpdateParameters tableCreateUpdateParameters1 = new TableCreateUpdateParameters
                    {
                        Resource = new TableResource { Id = "table1" },
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };

                    var tableResult1 = await this.fixture.CosmosDBManagementClient.TableResources.CreateUpdateTableAsync(
                        this.fixture.ResourceGroupName,
                        tableDatabaseAccountName,
                        "table1",
                        tableCreateUpdateParameters1
                    );

                    TableCreateUpdateParameters tableCreateUpdateParameters2 = new TableCreateUpdateParameters
                    {
                        Resource = new TableResource { Id = "table2" },
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };

                    var tableResult2 = await this.fixture.CosmosDBManagementClient.TableResources.CreateUpdateTableAsync(
                        this.fixture.ResourceGroupName,
                        tableDatabaseAccountName,
                        "table2",
                        tableCreateUpdateParameters2
                    );

                    ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(this.fixture.Location);

                    BackupInformation backupInformation = cosmosDBManagementClient.TableResources.RetrieveContinuousBackupInformation(
                        this.fixture.ResourceGroupName,
                        tableDatabaseAccountName,
                        "table1",
                        restoreLocation);

                    Assert.NotNull(backupInformation);
                    Assert.NotNull(backupInformation.ContinuousBackupInformation);
                    Assert.True(DateTime.TryParse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp, out _));

                    DateTime oldTime = DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);
                    backupInformation = cosmosDBManagementClient.TableResources.RetrieveContinuousBackupInformation(
                        this.fixture.ResourceGroupName,
                        tableDatabaseAccountName,
                        "table1",
                        restoreLocation);

                    Assert.NotNull(backupInformation);
                    Assert.NotNull(backupInformation.ContinuousBackupInformation);
                    Assert.True(DateTime.TryParse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp, out _));
                    Assert.True(DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) >= oldTime);

                    var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableTableDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(tableDatabaseAccountName, StringComparison.OrdinalIgnoreCase));
                    tableAccountInstanceId = restorableTableDatabaseAccount.Id.Split('/').LastOrDefault();
                    IEnumerable<RestorableTableGetResult> restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId);

                    Assert.NotNull(restorableTables);
                    Assert.True(restorableTables.Count() == 2);

                    var restorableTablesList = restorableTables.ToList();
                    restorableTablesList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(restorableTablesList[0].Resource.OwnerId == "table1");
                    Assert.True(restorableTablesList[0].Resource.OperationType == "Create");
                    Assert.True(restorableTablesList[1].Resource.OwnerId == "table2");
                    Assert.True(restorableTablesList[1].Resource.OperationType == "Create");

                    //var restorableTableResources = cosmosDBManagementClient.RestorableTableResources.List(this.fixture.Location, tableAccountInstanceId, this.fixture.Location, DateTime.UtcNow.ToString());
                    //Assert.NotNull(restorableTableResources);
                    //Assert.True(restorableTableResources.Count() == 2);

                    //var restorableTableResourcesList = restorableTableResources.ToList();
                    //restorableTableResourcesList.Sort();
                    //Assert.True(restorableTableResourcesList[0] == "table1");
                    //Assert.True(restorableTableResourcesList[1] == "table2");

                    // tables with start/end time
                    {
                        var startTime = string.Compare(restorableTablesList[0].Resource.EventTimestamp, restorableTablesList[1].Resource.EventTimestamp) <= 0 ? restorableTablesList[0].Resource.EventTimestamp : restorableTablesList[1].Resource.EventTimestamp;
                        var endTime = string.Compare(restorableTablesList[0].Resource.EventTimestamp, restorableTablesList[1].Resource.EventTimestamp) > 0 ? restorableTablesList[0].Resource.EventTimestamp : restorableTablesList[1].Resource.EventTimestamp;

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId, startTime, endTime);
                        Assert.True(restorableTables.Count() == 2);

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId);
                        Assert.True(restorableTables.Count() == 2);

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId, startTime);
                        Assert.True(restorableTables.Count() == 2);

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId, endTime: endTime);
                        Assert.True(restorableTables.Count() == 2);

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId, startTime: DateTime.UtcNow.AddDays(1).ToString());
                        Assert.True(restorableTables.Count() == 0);

                        restorableTables = cosmosDBManagementClient.RestorableTables.List(this.fixture.Location, tableAccountInstanceId, startTime, endTime: DateTime.UtcNow.AddDays(-2).ToString());
                        Assert.True(restorableTables.Count() == 0);
                    }
                }

                // Validate gremlin database account
                {
                    gremlinDatabaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Gremlin);
                    var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableGremlinDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(gremlinDatabaseAccountName, StringComparison.OrdinalIgnoreCase));

                    GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters1 = new GremlinDatabaseCreateUpdateParameters
                    {
                        Resource = new GremlinDatabaseResource { Id = "db1" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.GremlinResources.BeginCreateUpdateGremlinDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        gremlinDatabaseAccountName,
                        "db1",
                        gremlinDatabaseCreateUpdateParameters1
                    );

                    GremlinDatabaseCreateUpdateParameters gremlinDatabaseCreateUpdateParameters2 = new GremlinDatabaseCreateUpdateParameters
                    {
                        Resource = new GremlinDatabaseResource { Id = "db2" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.GremlinResources.BeginCreateUpdateGremlinDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        gremlinDatabaseAccountName,
                        "db2",
                        gremlinDatabaseCreateUpdateParameters2
                    );

                    GremlinGraphCreateUpdateParameters collectionCreateParams1 = new GremlinGraphCreateUpdateParameters()
                    {
                        Resource = new GremlinGraphResource("graph1", partitionKey: new ContainerPartitionKey(new List<String>() { "/pk" })),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var graphResult1 = await this.fixture.CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphAsync(
                        this.fixture.ResourceGroupName,
                        gremlinDatabaseAccountName,
                        "db1",
                        "graph1",
                        collectionCreateParams1
                    );

                    GremlinGraphCreateUpdateParameters collectionCreateParams2 = new GremlinGraphCreateUpdateParameters()
                    {
                        Resource = new GremlinGraphResource("graph2", partitionKey: new ContainerPartitionKey(new List<String>() { "/pk" })),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var graphResult2 = await this.fixture.CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphAsync(
                        this.fixture.ResourceGroupName,
                        gremlinDatabaseAccountName,
                        "db1",
                        "graph2",
                        collectionCreateParams2
                    );

                    ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(this.fixture.Location);
                    var backupInformation = cosmosDBManagementClient.GremlinResources.RetrieveContinuousBackupInformation(
                    this.fixture.ResourceGroupName,
                    gremlinDatabaseAccountName,
                    "db1",
                    "graph2",
                    restoreLocation);
                    Assert.NotNull(backupInformation);
                    Assert.NotNull(backupInformation.ContinuousBackupInformation);
                    Assert.True(DateTime.TryParse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp, out _));

                    restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableGremlinDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(gremlinDatabaseAccountName, StringComparison.OrdinalIgnoreCase));
                    gremlinAccountInstanceId = restorableGremlinDatabaseAccount.Id.Split('/').LastOrDefault();
                    IEnumerable<RestorableGremlinDatabaseGetResult> gremlinDatabases = cosmosDBManagementClient.RestorableGremlinDatabases.List(this.fixture.Location, gremlinAccountInstanceId);

                    Assert.NotNull(gremlinDatabases);
                    Assert.True(gremlinDatabases.Count() == 2);

                    var gremlinDatabasesList = gremlinDatabases.ToList();
                    gremlinDatabasesList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(gremlinDatabasesList[0].Resource.OwnerId == "db1");
                    Assert.True(gremlinDatabasesList[0].Resource.OperationType == "Create");
                    Assert.True(gremlinDatabasesList[1].Resource.OwnerId == "db2");
                    Assert.True(gremlinDatabasesList[1].Resource.OperationType == "Create");

                    var gremlinDatabaseRid = gremlinDatabasesList[0].Resource.OwnerResourceId;
                    IEnumerable<RestorableGremlinGraphGetResult> gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(this.fixture.Location, gremlinAccountInstanceId, gremlinDatabaseRid);
                    Assert.NotNull(gremlinGraphs);
                    Assert.True(gremlinGraphs.Count() == 2);

                    var gremlinGraphsList = gremlinGraphs.ToList();
                    gremlinGraphsList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(gremlinGraphsList[0].Resource.OwnerId == "graph1");
                    Assert.True(gremlinGraphsList[0].Resource.OperationType == "Create");
                    Assert.True(gremlinGraphsList[1].Resource.OwnerId == "graph2");
                    Assert.True(gremlinGraphsList[1].Resource.OperationType == "Create");

                    gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(this.fixture.Location, gremlinAccountInstanceId, gremlinDatabaseRid);
                    Assert.NotNull(gremlinGraphs);
                    Assert.True(gremlinGraphs.Count() == 2);

                    gremlinGraphsList = gremlinGraphs.ToList();
                    gremlinGraphsList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(gremlinGraphsList[0].Resource.OwnerId == "graph1");
                    Assert.True(gremlinGraphsList[0].Resource.OperationType == "Create");
                    Assert.True(gremlinGraphsList[1].Resource.OwnerId == "graph2");
                    Assert.True(gremlinGraphsList[1].Resource.OperationType == "Create");

                    IEnumerable<RestorableGremlinResourcesGetResult> gremlinResources = cosmosDBManagementClient.RestorableGremlinResources.List(this.fixture.Location, gremlinAccountInstanceId, this.fixture.Location, DateTime.UtcNow.ToString());
                    Assert.NotNull(gremlinResources);
                    Assert.True(gremlinResources.Count() == 2);

                    var gremlinResourcesList = gremlinResources.ToList();
                    gremlinResourcesList.Sort((p1, p2) => p1.DatabaseName.CompareTo(p2.DatabaseName));
                    var graphNames1 = gremlinResourcesList[0].GraphNames.ToList();
                    graphNames1.Sort();
                    var graphNames2 = gremlinResourcesList[0].GraphNames.ToList();
                    graphNames2.Sort();
                    Assert.True(gremlinResourcesList[0].DatabaseName == "db1");
                    Assert.True(graphNames1[0] == "graph1");
                    Assert.True(graphNames1[1] == "graph2");
                    Assert.True(gremlinResourcesList[1].DatabaseName == "db2");
                    Assert.True(graphNames2[0] == "graph1");
                    Assert.True(graphNames2[1] == "graph2");


                    // gremlin graphs with start/end time
                    {
                        var startTime = string.Compare(gremlinGraphsList[0].Resource.EventTimestamp, gremlinGraphsList[1].Resource.EventTimestamp) <= 0 ? gremlinGraphsList[0].Resource.EventTimestamp : gremlinGraphsList[1].Resource.EventTimestamp;
                        var endTime = string.Compare(gremlinGraphsList[0].Resource.EventTimestamp, gremlinGraphsList[1].Resource.EventTimestamp) > 0 ? gremlinGraphsList[0].Resource.EventTimestamp : gremlinGraphsList[1].Resource.EventTimestamp;

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid, startTime, endTime);
                        Assert.True(gremlinGraphs.Count() == 2);

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid);
                        Assert.True(gremlinGraphs.Count() == 2);

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid, startTime);
                        Assert.True(gremlinGraphs.Count() == 2);

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid, endTime: endTime);
                        Assert.True(gremlinGraphs.Count() == 2);

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid, DateTime.UtcNow.AddDays(-1).ToString());
                        Assert.True(gremlinGraphs.Count() == 2);

                        gremlinGraphs = cosmosDBManagementClient.RestorableGremlinGraphs.List(location, gremlinAccountInstanceId, gremlinDatabaseRid, startTime, endTime: DateTime.UtcNow.AddDays(-2).ToString());
                        Assert.True(gremlinGraphs.Count() == 0);
                    }
                }

                // Validate mongodb database account
                {
                    mongoDBDatabaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);
                    var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableMongoDBDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(mongoDBDatabaseAccountName, StringComparison.OrdinalIgnoreCase));

                    MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters1 = new MongoDBDatabaseCreateUpdateParameters
                    {
                        Resource = new MongoDBDatabaseResource { Id = "db1" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.MongoDBResources.BeginCreateUpdateMongoDBDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        mongoDBDatabaseAccountName,
                        "db1",
                        mongoDBDatabaseCreateUpdateParameters1
                    );

                    MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters2 = new MongoDBDatabaseCreateUpdateParameters
                    {
                        Resource = new MongoDBDatabaseResource { Id = "db2" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.MongoDBResources.BeginCreateUpdateMongoDBDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        mongoDBDatabaseAccountName,
                        "db2",
                        mongoDBDatabaseCreateUpdateParameters2
                    );

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("partitionKey", PartitionKind.Hash.ToString());
                    MongoDBCollectionCreateUpdateParameters collectionCreateParams1 = new MongoDBCollectionCreateUpdateParameters()
                    {
                        Resource = new MongoDBCollectionResource("col1", shardKey: dict),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var mongoCollectionResult1 = await this.fixture.CosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionAsync(
                        this.fixture.ResourceGroupName,
                        mongoDBDatabaseAccountName,
                        "db1",
                        "col1",
                        collectionCreateParams1
                    );

                    MongoDBCollectionCreateUpdateParameters collectionCreateParams2 = new MongoDBCollectionCreateUpdateParameters()
                    {
                        Resource = new MongoDBCollectionResource("col2", shardKey: dict),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var mongoCollectionResult2 = await this.fixture.CosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionAsync(
                        this.fixture.ResourceGroupName,
                        mongoDBDatabaseAccountName,
                        "db1",
                        "col2",
                        collectionCreateParams2
                    );

                    restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableMongoDBDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(mongoDBDatabaseAccountName, StringComparison.OrdinalIgnoreCase));
                    mongoDBAccountInstanceId = restorableMongoDBDatabaseAccount.Id.Split('/').LastOrDefault();
                    IEnumerable<RestorableMongodbDatabaseGetResult> mongoDatabases = cosmosDBManagementClient.RestorableMongodbDatabases.List(location, mongoDBAccountInstanceId);

                    Assert.NotNull(mongoDatabases);
                    Assert.True(mongoDatabases.Count() == 2);

                    var mongoDBDatabasesList = mongoDatabases.ToList();
                    mongoDBDatabasesList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(mongoDBDatabasesList[0].Resource.OwnerId == "db1");
                    Assert.True(mongoDBDatabasesList[0].Resource.OperationType == "Create");
                    Assert.True(mongoDBDatabasesList[1].Resource.OwnerId == "db2");
                    Assert.True(mongoDBDatabasesList[1].Resource.OperationType == "Create");

                    var mongoDBDatbaseRid = mongoDBDatabasesList[0].Resource.OwnerResourceId;
                    IEnumerable<RestorableMongodbCollectionGetResult> mongodbCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid);
                    Console.WriteLine(JsonConvert.SerializeObject(mongodbCollections));

                    Assert.NotNull(mongodbCollections);
                    Assert.True(mongodbCollections.Count() == 2);

                    var mongodbCollectionsList = mongodbCollections.ToList();
                    mongodbCollectionsList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(mongodbCollectionsList[0].Resource.OwnerId == "col1");
                    Assert.True(mongodbCollectionsList[0].Resource.OperationType == "Create");
                    Assert.True(mongodbCollectionsList[1].Resource.OwnerId == "col2");
                    Assert.True(mongodbCollectionsList[1].Resource.OperationType == "Create");

                    IEnumerable<RestorableMongodbResourcesGetResult> mongoDBRestorableResources = cosmosDBManagementClient.RestorableMongodbResources.List(location, mongoDBAccountInstanceId, location, DateTime.UtcNow.ToString());
                    Console.WriteLine(JsonConvert.SerializeObject(mongoDBRestorableResources));

                    Assert.NotNull(mongoDBRestorableResources);
                    Assert.True(mongoDBRestorableResources.Count() == 2);

                    var mongoDBRestorableResourcesList = mongoDBRestorableResources.ToList();
                    mongoDBRestorableResourcesList.Sort((p1, p2) => p1.DatabaseName.CompareTo(p2.DatabaseName));
                    var collectionNames = mongoDBRestorableResourcesList[0].CollectionNames.ToList();
                    collectionNames.Sort();
                    Assert.True(mongoDBRestorableResourcesList[0].DatabaseName == "db1");
                    Assert.True(collectionNames[0] == "col1");
                    Assert.True(collectionNames[1] == "col2");

                    // mongodb collections with start/end time
                    {
                        var startTime = string.Compare(mongodbCollectionsList[0].Resource.EventTimestamp, mongodbCollectionsList[1].Resource.EventTimestamp) <= 0 ? mongodbCollectionsList[0].Resource.EventTimestamp : mongodbCollectionsList[1].Resource.EventTimestamp;
                        var endTime = string.Compare(mongodbCollectionsList[0].Resource.EventTimestamp, mongodbCollectionsList[1].Resource.EventTimestamp) > 0 ? mongodbCollectionsList[0].Resource.EventTimestamp : mongodbCollectionsList[1].Resource.EventTimestamp;

                        var mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid, startTime, endTime);
                        Assert.True(mongoDBCollections.Count() == 2);

                        mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid);
                        Assert.True(mongoDBCollections.Count() == 2);

                        mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid, startTime);
                        Assert.True(mongoDBCollections.Count() == 2);

                        mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid, endTime: endTime);
                        Assert.True(mongoDBCollections.Count() == 2);

                        mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid, DateTime.UtcNow.AddDays(-1).ToString());
                        Assert.True(mongoDBCollections.Count() == 2);

                        mongoDBCollections = cosmosDBManagementClient.RestorableMongodbCollections.List(location, mongoDBAccountInstanceId, mongoDBDatbaseRid, startTime, endTime: DateTime.UtcNow.AddDays(-2).ToString());
                        Assert.True(mongoDBCollections.Count() == 0);
                    }
                }

                // Validate sql database account
                {
                    sqlDatabaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);
                    var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableSqlDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(sqlDatabaseAccountName, StringComparison.OrdinalIgnoreCase));

                    SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters1 = new SqlDatabaseCreateUpdateParameters
                    {
                        Resource = new SqlDatabaseResource { Id = "db1" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.SqlResources.BeginCreateUpdateSqlDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        sqlDatabaseAccountName,
                        "db1",
                        sqlDatabaseCreateUpdateParameters1
                    );

                    SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 = new SqlDatabaseCreateUpdateParameters
                    {
                        Resource = new SqlDatabaseResource { Id = "db2" },
                        Options = new CreateUpdateOptions()
                    };
                    await this.fixture.CosmosDBManagementClient.SqlResources.BeginCreateUpdateSqlDatabaseAsync(
                        this.fixture.ResourceGroupName,
                        sqlDatabaseAccountName,
                        "db2",
                        sqlDatabaseCreateUpdateParameters2
                    );

                    SqlContainerCreateUpdateParameters collectionCreateParams1 = new SqlContainerCreateUpdateParameters()
                    {
                        Resource = new SqlContainerResource("cont1", partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var graphResult1 = await this.fixture.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerAsync(
                        this.fixture.ResourceGroupName,
                        sqlDatabaseAccountName,
                        "db1",
                        "cont1",
                        collectionCreateParams1
                    );

                    SqlContainerCreateUpdateParameters collectionCreateParams2 = new SqlContainerCreateUpdateParameters()
                    {
                        Resource = new SqlContainerResource("cont2", partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                        Options = new CreateUpdateOptions() { Throughput = 30000 }
                    };
                    var graphResult2 = await this.fixture.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerAsync(
                        this.fixture.ResourceGroupName,
                        sqlDatabaseAccountName,
                        "db1",
                        "cont2",
                        collectionCreateParams2
                    );

                    ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(this.fixture.Location);
                    var backupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                        this.fixture.ResourceGroupName,
                        sqlDatabaseAccountName,
                        "db1",
                        "cont2",
                        restoreLocation);
                    Assert.NotNull(backupInformation);
                    Assert.NotNull(backupInformation.ContinuousBackupInformation);
                    Assert.True(DateTime.TryParse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp, out _));

                    restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
                    restorableSqlDatabaseAccount = restorableAccounts.SingleOrDefault(account => account.AccountName.Equals(sqlDatabaseAccountName, StringComparison.OrdinalIgnoreCase));
                    sqlAccountInstanceId = restorableSqlDatabaseAccount.Id.Split('/').LastOrDefault();
                    IEnumerable<RestorableSqlDatabaseGetResult> sqlDatabases = cosmosDBManagementClient.RestorableSqlDatabases.List(this.fixture.Location, sqlAccountInstanceId);

                    Assert.NotNull(sqlDatabases);
                    Assert.True(sqlDatabases.Count() == 2);

                    var sqlDatabasesList = sqlDatabases.ToList();
                    sqlDatabasesList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(sqlDatabasesList[0].Resource.OwnerId == "db1");
                    Assert.True(sqlDatabasesList[0].Resource.OperationType == "Create");
                    Assert.True(sqlDatabasesList[1].Resource.OwnerId == "db2");
                    Assert.True(sqlDatabasesList[1].Resource.OperationType == "Create");

                    var sqlDatabaseRid = sqlDatabasesList[0].Resource.OwnerResourceId;
                    IEnumerable<RestorableSqlContainerGetResult> sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(this.fixture.Location, sqlAccountInstanceId, sqlDatabaseRid);
                    Assert.NotNull(sqlContainers);
                    Assert.True(sqlContainers.Count() == 2);

                    var sqlContainersList = sqlContainers.ToList();
                    sqlContainersList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(sqlContainersList[0].Resource.OwnerId == "cont1");
                    Assert.True(sqlContainersList[0].Resource.OperationType == "Create");
                    Assert.True(sqlContainersList[1].Resource.OwnerId == "cont2");
                    Assert.True(sqlContainersList[1].Resource.OperationType == "Create");

                    sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(this.fixture.Location, sqlAccountInstanceId, sqlDatabaseRid);
                    Assert.NotNull(sqlContainers);
                    Assert.True(sqlContainers.Count() == 2);

                    sqlContainersList = sqlContainers.ToList();
                    sqlContainersList.Sort((p1, p2) => p1.Resource.OwnerId.CompareTo(p2.Resource.OwnerId));
                    Assert.True(sqlContainersList[0].Resource.OwnerId == "cont1");
                    Assert.True(sqlContainersList[0].Resource.OperationType == "Create");
                    Assert.True(sqlContainersList[1].Resource.OwnerId == "cont2");
                    Assert.True(sqlContainersList[1].Resource.OperationType == "Create");

                    IEnumerable<RestorableSqlResourcesGetResult> sqlResources = cosmosDBManagementClient.RestorableSqlResources.List(this.fixture.Location, sqlAccountInstanceId, this.fixture.Location, DateTime.UtcNow.ToString());
                    Assert.NotNull(sqlResources);
                    Assert.True(sqlResources.Count() == 2);

                    var sqlResourcesList = sqlResources.ToList();
                    sqlResourcesList.Sort((p1, p2) => p1.DatabaseName.CompareTo(p2.DatabaseName));
                    var containerNames = sqlResourcesList[0].CollectionNames.ToList();
                    containerNames.Sort();
                    Assert.True(sqlResourcesList[0].DatabaseName == "db1");
                    Assert.True(containerNames[0] == "cont1");
                    Assert.True(containerNames[1] == "cont2");


                    // sql containers with start/end time
                    {
                        var startTime = string.Compare(sqlContainersList[0].Resource.EventTimestamp, sqlContainersList[1].Resource.EventTimestamp) <= 0 ? sqlContainersList[0].Resource.EventTimestamp : sqlContainersList[1].Resource.EventTimestamp;
                        var endTime = string.Compare(sqlContainersList[0].Resource.EventTimestamp, sqlContainersList[1].Resource.EventTimestamp) > 0 ? sqlContainersList[0].Resource.EventTimestamp : sqlContainersList[1].Resource.EventTimestamp;

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid, startTime, endTime);
                        Assert.True(sqlContainers.Count() == 2);

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid);
                        Assert.True(sqlContainers.Count() == 2);

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid, startTime);
                        Assert.True(sqlContainers.Count() == 2);

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid, endTime: endTime);
                        Assert.True(sqlContainers.Count() == 2);

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid, DateTime.UtcNow.AddDays(-1).ToString());
                        Assert.True(sqlContainers.Count() == 2);

                        sqlContainers = cosmosDBManagementClient.RestorableSqlContainers.List(location, sqlAccountInstanceId, sqlDatabaseRid, startTime, endTime: DateTime.UtcNow.AddDays(-2).ToString());
                        Assert.True(sqlContainers.Count() == 0);
                    }
                }

                // trigger restore on gremlin account
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableGremlin") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableGremlinDatabaseAccount.Id,
                            GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>
                            {
                                new GremlinDatabaseRestoreResource("db1", new List<string>{"graph1", "graph2"}),
                                new GremlinDatabaseRestoreResource("db2")
                            }
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("gremlinrestoredaccount");

                    DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                    Assert.NotNull(restoredDatabaseAccount);
                    Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                    Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableGremlinDatabaseAccount.Id.ToLower());
                    Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
                }

                // trigger restore on table account
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableTable") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableTableDatabaseAccount.Id,
                            TablesToRestore = new List<string>
                            {
                               "table1", "table2"
                            }
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("tablerestoredaccount");

                    DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                    Assert.NotNull(restoredDatabaseAccount);
                    Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                    Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableTableDatabaseAccount.Id.ToLower());
                    Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
                }

                // trigger restore on sql account
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableSqlDatabaseAccount.Id,
                            DatabasesToRestore = new List<DatabaseRestoreResource>
                            {
                               new DatabaseRestoreResource("db1", new List<string> { "cont1","cont2" }),
                               new DatabaseRestoreResource("db2")
                            }
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("sqlrestoredaccount");

                    DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                    Assert.NotNull(restoredDatabaseAccount);
                    Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                    Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableSqlDatabaseAccount.Id.ToLower());
                    Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
                }

                // trigger restore on all account
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableGremlin") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableGremlinDatabaseAccount.Id,
                            TablesToRestore = new List<string>(),
                            DatabasesToRestore = new List<DatabaseRestoreResource>(),
                            GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>()
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("gremlinrestoredaccount-full1");

                    DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                    Assert.NotNull(restoredDatabaseAccount);
                    Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                    Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableGremlinDatabaseAccount.Id.ToLower());
                    Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
                }

                // trigger restore on all account
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableTable") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableTableDatabaseAccount.Id,
                            TablesToRestore = new List<string>(),
                            DatabasesToRestore = new List<DatabaseRestoreResource>(),
                            GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>()
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("tablerestoredaccount-full1");

                    DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                    Assert.NotNull(restoredDatabaseAccount);
                    Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                    Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableTableDatabaseAccount.Id.ToLower());
                    Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
                }

                // trigger restore on both gremlin and table account (bad request)
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableGremlin") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableGremlinDatabaseAccount.Id,
                            GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>
                            {
                                new GremlinDatabaseRestoreResource("db1", new List<string>{"graph1","graph2"})
                            },
                            TablesToRestore = new List<string>
                            {
                               "table1", "table2"
                            }
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("badaccountrequest");

                    try
                    {
                        DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                            this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                        Assert.True(false);
                    }
                    catch (Exception) { }
                }

                // trigger restore on both gremlin and table account (bad request)
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Locations = new List<Location>
                        {
                            new Location(locationName: location)
                        },
                        CreateMode = CreateMode.Restore,
                        Kind = "GlobalDocumentDB",
                        Capabilities = new List<Capability> { new Capability("EnableTable") },
                        RestoreParameters = new RestoreParameters()
                        {
                            RestoreMode = "PointInTime",
                            RestoreTimestampInUtc = DateTime.UtcNow,
                            RestoreSource = restorableTableDatabaseAccount.Id,
                            GremlinDatabasesToRestore = new List<GremlinDatabaseRestoreResource>
                            {
                                new GremlinDatabaseRestoreResource("db1", new List<string>{"graph1","graph2"})
                            },
                            TablesToRestore = new List<string>
                            {
                               "table1", "table2"
                            },
                            DatabasesToRestore = new List<DatabaseRestoreResource>
                            {
                               new DatabaseRestoreResource("db1", new List<string> { "col1" })
                            }
                        }
                    };
                    var restoredAccountName = TestUtilities.GenerateName("badrestoredaccount2");

                    try
                    {
                        DatabaseAccountGetResults restoredDatabaseAccount = (await this.fixture.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                            this.fixture.ResourceGroupName, restoredAccountName, databaseAccountCreateUpdateParameters)).Body;
                        Assert.True(false);
                    }
                    catch (Exception) { }
                }
            }
        }

        private async Task RestorableDatabaseAccountFeedTestHelperAsync(
            string sourceDatabaseAccountName,
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            var client = this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts;

            var restorableAccountsFromGlobalFeed = (await client.ListByLocationAsync(this.fixture.Location)).ToList();

            var sourceDatabaseAccount = await this.fixture.CosmosDBManagementClient.DatabaseAccounts.GetAsync(this.fixture.ResourceGroupName, sourceDatabaseAccountName);

            RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccountsFromGlobalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            List<RestorableDatabaseAccountGetResult> restorableAccountsFromRegionalFeed =
                (await client.ListByLocationAsync(this.fixture.Location)).ToList();

            restorableDatabaseAccount = restorableAccountsFromRegionalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            restorableDatabaseAccount =
                await client.GetByLocationAsync(this.fixture.Location, sourceDatabaseAccount.InstanceId);

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);
        }

        private static void ValidateRestorableDatabaseAccount(
            RestorableDatabaseAccountGetResult restorableDatabaseAccount,
            DatabaseAccountGetResults sourceDatabaseAccount,
            string expectedApiType,
            int expectedRestorableLocations)
        {
            Assert.Equal(expectedApiType, restorableDatabaseAccount.ApiType);
            Assert.Equal(expectedRestorableLocations, restorableDatabaseAccount.RestorableLocations.Count);
            Assert.Equal("Microsoft.DocumentDB/locations/restorableDatabaseAccounts", restorableDatabaseAccount.Type);
            Assert.Equal(sourceDatabaseAccount.Location, restorableDatabaseAccount.Location);
            Assert.Equal(sourceDatabaseAccount.Name, restorableDatabaseAccount.AccountName);
            Assert.True(restorableDatabaseAccount.CreationTime.HasValue);
            Assert.True(restorableDatabaseAccount.OldestRestorableTime.HasValue);
            Assert.True(
                restorableDatabaseAccount.OldestRestorableTime.Value >= restorableDatabaseAccount.CreationTime.Value && 
                restorableDatabaseAccount.OldestRestorableTime.Value <= DateTime.UtcNow);
        }
    }
}
