// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    [Collection("TestCollection")]
    public class RestoreDatabaseAccountOperationsTests
    {
        public readonly TestFixture fixture;

        public RestoreDatabaseAccountOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task RestoreDatabaseAccountTests()
        {
            var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Sql);

            var restorableAccounts = (await this.fixture.CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(this.fixture.Location)).ToList();
            var restorableDatabaseAccount = restorableAccounts.
                SingleOrDefault(account => account.AccountName.Equals(databaseAccountName, StringComparison.OrdinalIgnoreCase));

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
                    RestoreTimestampInUtc = DateTime.UtcNow,
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

        [Fact]
        public async Task RestorableDatabaseAccountFeedTests()
        {
            await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Sql), ApiType.Sql, 1);
            await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo32), ApiType.MongoDB, 1);
            await RestorableDatabaseAccountFeedTestHelperAsync(this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Mongo36), ApiType.MongoDB, 1);
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
        }


        [Fact]
        public void RetrieveContinuousBackupInfoTest()
        {
            var client = this.fixture.CosmosDBManagementClient.SqlResources;

            ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation(this.fixture.Location);
            var databaseAccountName = this.fixture.GetDatabaseAccountName(TestFixture.AccountType.Sql);

            var databaseName = TestUtilities.GenerateName("sqlDatabase");
            client.BeginCreateUpdateSqlDatabaseWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName, databaseName, new SqlDatabaseCreateUpdateParameters
            {
                Resource = new SqlDatabaseResource { Id = databaseName },
                Options = new CreateUpdateOptions()
            });

            var containerName = TestUtilities.GenerateName("sqlContainer");
                        SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters()
            {
                Resource = new SqlContainerResource(containerName, partitionKey: new ContainerPartitionKey(new List<String>() { "/id" })),
                Options = new CreateUpdateOptions
                {
                    Throughput = 400
                }
            };
            SqlContainerGetResults createContainerResult = client.CreateUpdateSqlContainer(
                this.fixture.ResourceGroupName,
                databaseAccountName,
                databaseName,
                containerName,
                sqlContainerCreateUpdateParameters);
            Assert.NotNull(createContainerResult);
            Assert.NotNull(createContainerResult.Id);

            BackupInformation backupInformation = client.RetrieveContinuousBackupInformation(
                this.fixture.ResourceGroupName,
                databaseAccountName,
                databaseName,
                containerName,
                restoreLocation);

            Assert.NotNull(backupInformation);
            Assert.NotNull(backupInformation.ContinuousBackupInformation);
            var lastRestorableTimestampString = backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp;
            Assert.True(Int32.TryParse(lastRestorableTimestampString, out int lastRestorableTimestamp), String.Format("LastRestorableTimestamp '{0}' is not an integer.", lastRestorableTimestampString));
            Assert.True(lastRestorableTimestamp > 0);
            int prevRestoreTime = Int32.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp);

            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters()
            {
                Resource = new ThroughputSettingsResource()
                {
                    Throughput = 4000
                }
            };
            ThroughputSettingsGetResults throughputSettingsGetResults = client.UpdateSqlContainerThroughput(
                this.fixture.ResourceGroupName,
                databaseAccountName,
                databaseName,
                containerName,
                throughputSettingsUpdateParameters);
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Id);

            backupInformation = client.RetrieveContinuousBackupInformation(
                this.fixture.ResourceGroupName,
                databaseAccountName,
                databaseName,
                containerName,
                restoreLocation);

            Assert.NotNull(backupInformation);
            Assert.NotNull(backupInformation.ContinuousBackupInformation);
            lastRestorableTimestampString = backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp;
            Assert.True(Int32.TryParse(lastRestorableTimestampString, out lastRestorableTimestamp), String.Format("LastRestorableTimestamp '{}' is not an integer.", lastRestorableTimestampString));
            Assert.True(lastRestorableTimestamp > 0);

            Assert.True(Int32.Parse(backupInformation.ContinuousBackupInformation.LatestRestorableTimestamp) >= prevRestoreTime);

            client.DeleteSqlContainer(this.fixture.ResourceGroupName, databaseAccountName, databaseName, containerName);
        }
    }
}
