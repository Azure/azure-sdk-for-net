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
        const string eastus2 = "eastus2";
        const string westus2 = "westus2";
        const string resourceGroupName = "pitr-stage-rg";
        const string restoreTimestamp = "2020-12-16T00:00:00+0000";
        // const string sourceDatabaseAccountName = "pitr-sql-stage-source";

        [Fact]
        public async Task RestoreDatabaseAccountFeedTests()
        {
            RecordedDelegatingHandler handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler);

                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-sql-stage-source", westus2, ApiType.Sql, 3);
                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-mongo32-stage-source", eastus2, ApiType.MongoDB, 2);
                await RestoreDatabaseAccountFeedTestHelperAsync(cosmosDBManagementClient, "pitr-mongo36-stage-source", eastus2, ApiType.MongoDB, 2);
            }
        }

        private async Task RestoreDatabaseAccountFeedTestHelperAsync(
            CosmosDBManagementClient cosmosDBManagementClient,
            string sourceDatabaseAccountName,
            string sourceARMLocation,
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            DatabaseAccountGetResults sourceDatabaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, sourceDatabaseAccountName);

            List<RestorableDatabaseAccountGetResult> restorableAccountsFromGlobalFeed = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListAsync()).ToList();

            //List<RestorableDatabaseAccountGetResult> restorableAccounts = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(westus2)).ToList();
            RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccountsFromGlobalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            List<RestorableDatabaseAccountGetResult> restorableAccountsFromRegionalFeed = 
                (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationAsync(sourceARMLocation)).ToList();

            restorableDatabaseAccount = restorableAccountsFromRegionalFeed.
                Single(account => account.Name.Equals(sourceDatabaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

            ValidateRestorableDatabaseAccount(restorableDatabaseAccount, sourceDatabaseAccount, sourceApiType, expectedRestorableLocationCount);

            restorableDatabaseAccount = 
                await cosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationAsync(sourceARMLocation, sourceDatabaseAccount.InstanceId);

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
        public async Task RestoreDatabaseAccountTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);

                DatabaseAccountGetResults databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, "pitr-sql-stage-source");
                DateTime restoreTs = DateTime.Parse(restoreTimestamp);
                string restoredatabaseAccountName = TestUtilities.GenerateName(prefix: "restoredaccountname");

                List<RestorableDatabaseAccountGetResult> restorableAccounts = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListAsync()).ToList();
                RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.Name.Equals(databaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

                List<Location> locations = new List<Location>
                {
                    new Location(locationName: westus2)
                };

                RestoreReqeustDatabaseAccountCreateUpdateProperties databaseAccountCreateUpdateProperties = new RestoreReqeustDatabaseAccountCreateUpdateProperties
                {
                    Locations = locations,
                    RestoreParameters = new RestoreParameters()
                    {
                        RestoreMode = "PointInTime",
                        RestoreTimestampInUtc = restoreTs,
                        RestoreSource = restorableDatabaseAccount.Id
                    }
                };

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = westus2,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Properties = databaseAccountCreateUpdateProperties
                };

                DatabaseAccountGetResults restoredDatabaseAccount = 
                    (await cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                        resourceGroupName, restoredatabaseAccountName, databaseAccountCreateUpdateParameters)).Body;

                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }
    }
}