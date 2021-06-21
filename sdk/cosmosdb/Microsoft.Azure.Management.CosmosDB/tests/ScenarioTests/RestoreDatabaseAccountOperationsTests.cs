// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CosmosDB.Tests.ScenarioTests
{
    public class RestoreDatabaseAccountOperationsTests
    {
        const string location = "eastus2";
        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string sourceDatabaseAccountName = "sqltestaccount124";

        [Fact]
        public async Task RestoreDatabaseAccountTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler1);
                string restoredatabaseAccountName = TestUtilities.GenerateName(prefix: "restoredaccountname");

                DatabaseAccountGetResults databaseAccount = null;
                bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(sourceDatabaseAccountName).GetAwaiter().GetResult().Body;
                if (!isDatabaseNameExists)
                {
                    DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters1 = new DatabaseAccountCreateUpdateParameters
                    {
                        Location = location,
                        Kind = DatabaseAccountKind.GlobalDocumentDB,
                        Locations = new List<Location> { new Location { LocationName = location } },
                        BackupPolicy = new ContinuousModeBackupPolicy(),
                    };

                    databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, sourceDatabaseAccountName, databaseAccountCreateUpdateParameters1).GetAwaiter().GetResult().Body;
                    Assert.Equal(databaseAccount.Name, sourceDatabaseAccountName);
                }
                databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, sourceDatabaseAccountName);

                DateTime restoreTs = DateTime.UtcNow;

                List<RestorableDatabaseAccountGetResult> restorableAccounts = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(location)).ToList();
                RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.AccountName.Equals(databaseAccount.Name, StringComparison.OrdinalIgnoreCase));

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Locations = new List<Location>
                    {
                        new Location(locationName: location)
                    },
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = restoreTs,
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };

                DatabaseAccountGetResults restoredDatabaseAccount = (await cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, restoredatabaseAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }

        [Fact]
        public async Task RestoreDatabaseAccountFeedTests()
        {
            RecordedDelegatingHandler handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler);

                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-sql-stage-source", ApiType.Sql, 1);
                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-mongo32-stage-source", ApiType.MongoDB, 1);
                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-mongo36-stage-source", ApiType.MongoDB, 1);
            }
        }

        private async Task RestoreDatabaseAccountFeedTestHelperAsync(
            CosmosDBManagementClient cosmosDBManagementClient,
            string sourceDatabaseAccountName,
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            DatabaseAccountGetResults sourceDatabaseAccount = await CreateDatabaseAccountIfNotExists(cosmosDBManagementClient, sourceDatabaseAccountName, location, sourceApiType);

            List<RestorableDatabaseAccountGetResult> restorableAccountsFromGlobalFeed = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(location)).ToList();

            //List<RestorableDatabaseAccountGetResult> restorableAccounts = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(westus2)).ToList();
            RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccountsFromGlobalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            List<RestorableDatabaseAccountGetResult> restorableAccountsFromRegionalFeed =
                (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(location)).ToList();

            restorableDatabaseAccount = restorableAccountsFromRegionalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            restorableDatabaseAccount =
                await cosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationAsync(location, sourceDatabaseAccount.InstanceId);

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

        private static async Task<DatabaseAccountGetResults> CreateDatabaseAccountIfNotExists(
            CosmosDBManagementClient cosmosDBManagementClient,
            string databaseAccountName,
            string armLocation,
            string kind)
        {
            bool isDatabaseNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;
            String databaseKind = null;
            List<Location> locations = null;
            if (kind == ApiType.Sql)
            {
                databaseKind = DatabaseAccountKind.GlobalDocumentDB;
                locations = new List<Location> { new Location { LocationName = "westus" }, new Location { LocationName = "eastus" }, new Location { LocationName = "eastus2" } };
            }
            else if (kind == ApiType.MongoDB)
            {
                databaseKind = DatabaseAccountKind.MongoDB;
                locations = new List<Location> { new Location { LocationName = "westus" }, new Location { LocationName = "eastus" } };
            }

            DatabaseAccountGetResults databaseAccount = null;
            if (!isDatabaseNameExists)
            {
                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = armLocation,
                    Kind = databaseKind,
                    Locations = locations,
                    BackupPolicy = new ContinuousModeBackupPolicy()
                };

                databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                Assert.Equal(databaseAccount.Name, databaseAccountName);
            }
            databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);

            return databaseAccount;
        }
    }
}
