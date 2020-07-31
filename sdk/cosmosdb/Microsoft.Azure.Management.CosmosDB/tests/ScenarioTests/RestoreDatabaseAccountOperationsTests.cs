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
        const int sampleThroughput = 400;
        // using an existing DB account, since Account provisioning takes 10-15 minutes
        const string resourceGroupName = "CosmosDBResourceGroup3668";
        const string sourceDatabaseAccountName = "db1024";
        const string restoreTimestamp = "2020-07-21T18:22:33+0000";

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

                DatabaseAccountGetResults databaseAccount = await cosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, sourceDatabaseAccountName);
                DateTime restoreTs = DateTime.Parse(restoreTimestamp);

                List<RestorableDatabaseAccountGetResult> restorableAccounts = (await cosmosDBManagementClient.RestorableDatabaseAccounts.ListAsync()).ToList();
                RestorableDatabaseAccountGetResult restorableDatabaseAccount = restorableAccounts.
                    SingleOrDefault(account => account.Name.Equals(databaseAccount.InstanceId, StringComparison.OrdinalIgnoreCase));

                List<Location> locations = new List<Location>
                {
                    new Location(locationName: location)
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
                    Location = location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "GlobalDocumentDB",
                    Properties = databaseAccountCreateUpdateProperties
                };

                DatabaseAccountGetResults restoredDatabaseAccount = (await cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, restoredatabaseAccountName, databaseAccountCreateUpdateParameters)).Body;
                Assert.NotNull(restoredDatabaseAccount);
                Assert.NotNull(restoredDatabaseAccount.RestoreParameters);
                Assert.Equal(restoredDatabaseAccount.RestoreParameters.RestoreSource.ToLower(), restorableDatabaseAccount.Id.ToLower());
                Assert.True(restoredDatabaseAccount.BackupPolicy is ContinuousModeBackupPolicy);
            }
        }
    }
}
