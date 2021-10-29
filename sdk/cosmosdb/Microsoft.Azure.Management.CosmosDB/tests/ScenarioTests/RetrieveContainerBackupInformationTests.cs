// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RetrieveContainerBackupInformationTests : IClassFixture<TestFixture>
    {
        public TestFixture fixture;

        public RetrieveContainerBackupInformationTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void RetrieveSqlContainerContinuousBackupInfoTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                CosmosDBManagementClient cosmosDBManagementClient = this.fixture.CosmosDBManagementClient;
                var resourceGroupName = this.fixture.ResourceGroupName;
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.PitrSql);
                string location = this.fixture.Location;
                var databaseName = TestUtilities.GenerateName("database");
                var containerName = TestUtilities.GenerateName("container");
                ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(location);

                var result = this.CreateSQLResources(cosmosDBManagementClient, databaseAccountName, databaseName, containerName);

                DateTime oldTime = DateTimeOffset.FromUnixTimeSeconds((int)result.Resource._ts).DateTime.AddSeconds(-1);
                BackupInformation backupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);

                oldTime = DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);
                BackupInformation sqlbackupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    restoreLocation);

                Assert.NotNull(sqlbackupInformation);
                Assert.NotNull(sqlbackupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(sqlbackupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) >= oldTime);
            }
        }

        [Fact]
        public void RetrieveMongoCollectionContinuousBackupInfoTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                CosmosDBManagementClient cosmosDBManagementClient = this.fixture.CosmosDBManagementClient;
                var resourceGroupName = this.fixture.ResourceGroupName;
                var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36);
                string location = this.fixture.Location;
                var databaseName = TestUtilities.GenerateName("database");
                var collectionName = TestUtilities.GenerateName("collection");
                ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(location);

                this.CreateMongoDBResources(cosmosDBManagementClient, databaseAccountName, databaseName, collectionName);

                var result = cosmosDBManagementClient.DatabaseAccounts.Get(this.fixture.ResourceGroupName, databaseAccountName);

                DateTime? oldTime = result.SystemData.CreatedAt;
                Assert.NotNull(oldTime);
                BackupInformation backupInformation = cosmosDBManagementClient.MongoDBResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);

                oldTime = DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);
                BackupInformation mongobackupInformation = cosmosDBManagementClient.MongoDBResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    restoreLocation);

                Assert.NotNull(mongobackupInformation);
                Assert.NotNull(mongobackupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(mongobackupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);
            }
        }

        private DatabaseAccountGetResults CreateDatabaseAccount(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName, string kind = DatabaseAccountKind.GlobalDocumentDB)
        {
            DatabaseAccountGetResults databaseAccount;
            try
            {
                DatabaseAccountGetResults databaseAccountGetResult = cosmosDBManagementClient.DatabaseAccounts.Get(this.fixture.ResourceGroupName, databaseAccountName);
                if (databaseAccountGetResult != null)
                {
                    return databaseAccountGetResult;
                }
            }
            catch (Exception) { }

            bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;
            if (!isDatabaseNameExists)
            {
                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters1 = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Kind = kind,
                    Locations = new List<Location> { new Location { LocationName = this.fixture.Location } },
                    BackupPolicy = new ContinuousModeBackupPolicy(),
                };

                databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseAccount.Name, databaseAccountName);
            }
            databaseAccount = cosmosDBManagementClient.DatabaseAccounts.Get(this.fixture.ResourceGroupName, databaseAccountName);

            return databaseAccount;
        }

        private SqlContainerGetResults CreateSQLResources(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName, string databaseName, string containerName)
        {
            SqlDatabaseGetResults databaseGetResults = null;
            try
            {
                databaseGetResults = cosmosDBManagementClient.SqlResources.GetSqlDatabase(this.fixture.ResourceGroupName, databaseAccountName, databaseName);
            }
            catch (Exception) { }

            if (databaseGetResults == null)
            {
                SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
                {
                    Resource = new SqlDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                databaseGetResults = cosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabase(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    sqlDatabaseCreateUpdateParameters);
            }

            SqlContainerGetResults collectionGetResult = null;
            try
            {
                collectionGetResult = cosmosDBManagementClient.SqlResources.GetSqlContainer(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName);
            }
            catch (Exception) { }

            if (collectionGetResult == null)
            {
                SqlContainerCreateUpdateParameters collectionCreateParams = new SqlContainerCreateUpdateParameters()
                {
                    Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                    Options = new CreateUpdateOptions()
                    {
                        Throughput = 30000
                    }
                };
                collectionGetResult = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainer(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    collectionCreateParams);
            }

            return collectionGetResult;
        }

        private MongoDBCollectionGetResults CreateMongoDBResources(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName, string databaseName, string collectionName)
        {
            MongoDBDatabaseGetResults databaseGetResults = null;
            try
            {
                databaseGetResults = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabase(this.fixture.ResourceGroupName, databaseAccountName, databaseName);
            }
            catch (Exception) { }

            if (databaseGetResults == null)
            {
                MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
                {
                    Resource = new MongoDBDatabaseResource { Id = databaseName },
                    Options = new CreateUpdateOptions()
                };

                databaseGetResults = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBDatabase(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    mongoDBDatabaseCreateUpdateParameters);
            }

            MongoDBCollectionGetResults collectionGetResult = null;
            try
            {
                collectionGetResult = cosmosDBManagementClient.MongoDBResources.GetMongoDBCollection(this.fixture.ResourceGroupName, databaseAccountName, databaseName, collectionName);
            }
            catch (Exception) { }
            if (collectionGetResult == null)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("partitionKey", PartitionKind.Hash.ToString());
                MongoDBCollectionCreateUpdateParameters collectionCreateParams = new MongoDBCollectionCreateUpdateParameters()
                {
                    Resource = new MongoDBCollectionResource
                    {
                        Id = collectionName,
                        ShardKey = dict
                    },
                    Options = new CreateUpdateOptions()
                    {
                        Throughput = 30000
                    }
                };
                collectionGetResult = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollection(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    collectionCreateParams);
            }

            return collectionGetResult;
        }
    }
}
