// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Collections.Generic;
using Xunit;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RetrieveSqlContainerBackupInformationTests
    {
        const string location = "eastus";
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string databaseAccountName = "sqltestaccount125";
        const string databaseName = "TestDB1";
        const string containerName = "TestContainer2";

        [Fact]
        public void RetrieveContinuousBackupInfoTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(location);

                SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters()
                {
                    Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                    Options = new CreateUpdateOptions
                    {
                        Throughput = 400
                    }
                };

                SqlContainerGetResults createContainerResult = cosmosDBManagementClient.SqlResources.CreateUpdateSqlContainer(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    sqlContainerCreateUpdateParameters);
                Assert.NotNull(createContainerResult);
                Assert.NotNull(createContainerResult.Id);

                BackupInformation backupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(Int32.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) > 0);
                int prevRestoreTime = Int32.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);

                ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters()
                {
                    Resource = new ThroughputSettingsResource()
                    {
                        Throughput = 4000
                    }
                };
                ThroughputSettingsGetResults throughputSettingsGetResults = cosmosDBManagementClient.SqlResources.UpdateSqlContainerThroughput(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    throughputSettingsUpdateParameters);
                Assert.NotNull(throughputSettingsGetResults);
                Assert.NotNull(throughputSettingsGetResults.Id);

                backupInformation = cosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    restoreLocation);

                Assert.NotNull(backupInformation);
                Assert.NotNull(backupInformation.ContinuousBackupInformation);
                Assert.True(Int32.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) >= prevRestoreTime);

                cosmosDBManagementClient.SqlResources.DeleteSqlContainer(resourceGroupName, databaseAccountName, databaseName, containerName);
            }
        }
    }
}
