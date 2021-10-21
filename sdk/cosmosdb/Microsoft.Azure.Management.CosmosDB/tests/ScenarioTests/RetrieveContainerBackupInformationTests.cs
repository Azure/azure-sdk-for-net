// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RetrieveContainerBackupInformationTests
    {
        private string location = TestConstants.Location1;
        private string resourceGroupName = "CosmosDBResourceGroup3668";
        private string sqlDatabaseAccountName = "sqltestaccount1234";
        private string mongoDatabaseAccountName = "mongotestaccount1234";
        private string databaseName = "db1";
        private string containerName = "col1";

        [Fact]
        public void RetrieveSqlContainerContinuousBackupInfoTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(location);

                this.CreateDatabaseAccount(cosmosDBManagementClient, this.sqlDatabaseAccountName);
                this.CreateSQLResources(cosmosDBManagementClient, this.sqlDatabaseAccountName);

                DateTime oldTime = DateTime.UtcNow.AddSeconds(-1);
                BackupInformation backupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    this.resourceGroupName,
                    this.sqlDatabaseAccountName,
                    this.databaseName,
                    this.containerName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);

                oldTime = DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);
                BackupInformation sqlbackupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    this.resourceGroupName,
                    this.sqlDatabaseAccountName,
                    this.databaseName,
                    this.containerName,
                    restoreLocation);

                Assert.NotNull(sqlbackupInformation);
                Assert.NotNull(sqlbackupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(sqlbackupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) >= oldTime);
            }
        }

        [Fact]
        public void RetrieveMongoCollectionContinuousBackupInfoTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(location);

                this.CreateDatabaseAccount(cosmosDBManagementClient, this.mongoDatabaseAccountName, DatabaseAccountKind.MongoDB);
                this.CreateMongDBResources(cosmosDBManagementClient, this.mongoDatabaseAccountName);

                DateTime oldTime = DateTime.UtcNow.AddSeconds(-200);
                BackupInformation backupInformation = cosmosDBManagementClient.MongoDBResources.RetrieveContinuousBackupInformation(
                    this.resourceGroupName,
                    this.mongoDatabaseAccountName,
                    this.databaseName,
                    this.containerName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);

                oldTime = DateTime.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);
                BackupInformation mongobackupInformation = cosmosDBManagementClient.MongoDBResources.RetrieveContinuousBackupInformation(
                    this.resourceGroupName,
                    this.mongoDatabaseAccountName,
                    this.databaseName,
                    this.containerName,
                    restoreLocation);

                Assert.NotNull(mongobackupInformation);
                Assert.NotNull(mongobackupInformation.ContinuousBackupInformation);
                Assert.True(DateTime.Parse(mongobackupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > oldTime);
            }
        }

        private DatabaseAccountGetResults CreateDatabaseAccount(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName, string kind = DatabaseAccountKind.GlobalDocumentDB)
        {
            DatabaseAccountGetResults databaseAccount = null;
            try
            {
                DatabaseAccountGetResults databaseAccountGetResult = cosmosDBManagementClient.DatabaseAccounts.Get(this.resourceGroupName, databaseAccountName);
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
                    Location = location,
                    Kind = kind,
                    Locations = new List<Location> { new Location { LocationName = location } },
                    BackupPolicy = new ContinuousModeBackupPolicy(),
                };

                databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseAccount.Name, databaseAccountName);
            }
            databaseAccount = cosmosDBManagementClient.DatabaseAccounts.Get(resourceGroupName, databaseAccountName);

            return databaseAccount;
        }

        private SqlContainerGetResults CreateSQLResources(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName)
        {
            SqlDatabaseGetResults databaseGetResults = null;
            try
            {
                databaseGetResults = cosmosDBManagementClient.SqlResources.GetSqlDatabase(this.resourceGroupName, databaseAccountName, this.databaseName);
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
                    resourceGroupName,
                    databaseAccountName,
                    this.databaseName,
                    sqlDatabaseCreateUpdateParameters);
            }

            SqlContainerGetResults collectionGetResult = null;
            try
            {
                collectionGetResult = cosmosDBManagementClient.SqlResources.GetSqlContainer(resourceGroupName, databaseAccountName, this.databaseName, this.containerName);
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
                    resourceGroupName,
                    databaseAccountName,
                    this.databaseName,
                    this.containerName,
                    collectionCreateParams);
            }

            return collectionGetResult;
        }

        private MongoDBCollectionGetResults CreateMongDBResources(CosmosDBManagementClient cosmosDBManagementClient, string databaseAccountName)
        {
            MongoDBDatabaseGetResults databaseGetResults = null;
            try
            {
                databaseGetResults = cosmosDBManagementClient.MongoDBResources.GetMongoDBDatabase(this.resourceGroupName, databaseAccountName, this.databaseName);
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
                    resourceGroupName,
                    databaseAccountName,
                    this.databaseName,
                    mongoDBDatabaseCreateUpdateParameters);
            }

            MongoDBCollectionGetResults collectionGetResult = null;
            try
            {
                collectionGetResult = cosmosDBManagementClient.MongoDBResources.GetMongoDBCollection(resourceGroupName, databaseAccountName, this.databaseName, this.containerName);
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
                        Id = this.containerName,
                        ShardKey = dict
                    },
                    Options = new CreateUpdateOptions()
                    {
                        Throughput = 30000
                    }
                };
                collectionGetResult = cosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollection(
                    resourceGroupName,
                    databaseAccountName,
                    this.databaseName,
                    this.containerName,
                    collectionCreateParams);
            }

            return collectionGetResult;
        }
    }
}
