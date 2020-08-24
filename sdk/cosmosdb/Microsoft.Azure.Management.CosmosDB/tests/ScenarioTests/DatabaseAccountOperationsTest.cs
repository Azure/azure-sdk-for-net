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

namespace CosmosDB.Tests.ScenarioTests
{
    public class DatabaseAccountOperationsTests
    {
        const string location = "EAST US 2";

        [Fact]
        public void DatabaseAccountCRUDTests()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient = CosmosDBTestUtilities.GetCosmosDBClient(context, handler1);
                ResourceManagementClient resourcesClient = CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = CosmosDBTestUtilities.CreateResourceGroup(resourcesClient);
                string databaseAccountName = TestUtilities.GenerateName(prefix: "accountname");

                List<Location> locations = new List<Location>();
                locations.Add(new Location(locationName: location));
                DefaultRequestDatabaseAccountCreateUpdateProperties databaseAccountCreateUpdateProperties = new DefaultRequestDatabaseAccountCreateUpdateProperties
                {
                    ConsistencyPolicy = new ConsistencyPolicy
                    {
                        DefaultConsistencyLevel = DefaultConsistencyLevel.BoundedStaleness,
                        MaxStalenessPrefix = 300,
                        MaxIntervalInSeconds = 1000
                    },
                    Locations = locations,
                    IpRules = new List<IpAddressOrRange>
                    {
                        new IpAddressOrRange("23.43.230.120")
                    },
                    IsVirtualNetworkFilterEnabled = true,
                    EnableAutomaticFailover = false,
                    EnableMultipleWriteLocations = true,
                    EnableCassandraConnector = true,
                    ConnectorOffer = "Small",
                    DisableKeyBasedMetadataWriteAccess = false
                };

                DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    Kind = "MongoDB",
                    Properties = databaseAccountCreateUpdateProperties
                };

                DatabaseAccountGetResults databaseAccount = cosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;

                VerifyCosmosDBAccount(databaseAccount, databaseAccountCreateUpdateParameters);
                Assert.Equal(databaseAccountName, databaseAccount.Name);

                DatabaseAccountGetResults readDatabaseAccount = cosmosDBManagementClient.DatabaseAccounts.GetWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                VerifyCosmosDBAccount(readDatabaseAccount, databaseAccountCreateUpdateParameters);
                Assert.Equal(databaseAccountName, readDatabaseAccount.Name);

                DatabaseAccountUpdateParameters databaseAccountUpdateParameters = new DatabaseAccountUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"}
                    },
                    ConsistencyPolicy = new ConsistencyPolicy
                    {
                        DefaultConsistencyLevel = DefaultConsistencyLevel.Session,
                        MaxStalenessPrefix = 1300,
                        MaxIntervalInSeconds = 12000
                    },
                    Locations = locations,
                    IpRules = new List<IpAddressOrRange>
                    {
                        new IpAddressOrRange("23.43.230.120")
                    },
                    IsVirtualNetworkFilterEnabled = false,
                    EnableAutomaticFailover = true,
                    EnableCassandraConnector = true,
                    ConnectorOffer = "Small",
                    DisableKeyBasedMetadataWriteAccess = true
                };

                DatabaseAccountGetResults updatedDatabaseAccount = cosmosDBManagementClient.DatabaseAccounts.UpdateWithHttpMessagesAsync(resourceGroupName, databaseAccountName, databaseAccountUpdateParameters).GetAwaiter().GetResult().Body;

                VerifyCosmosDBAccount(updatedDatabaseAccount, databaseAccountUpdateParameters);
                Assert.Equal(databaseAccountName, databaseAccount.Name);

                IEnumerable<DatabaseAccountGetResults> databaseAccounts = cosmosDBManagementClient.DatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccounts);

                IEnumerable<DatabaseAccountGetResults> databaseAccountsByResourceGroupName = cosmosDBManagementClient.DatabaseAccounts.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountsByResourceGroupName);

                DatabaseAccountListKeysResult databaseAccountListKeysResult = cosmosDBManagementClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                
                Assert.NotNull(databaseAccountListKeysResult.PrimaryMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.SecondaryMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.PrimaryReadonlyMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.SecondaryReadonlyMasterKey);

                DatabaseAccountListConnectionStringsResult databaseAccountListConnectionStringsResult = cosmosDBManagementClient.DatabaseAccounts.ListConnectionStringsWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountListConnectionStringsResult);

                DatabaseAccountListReadOnlyKeysResult databaseAccountGetReadOnlyKeysResult = cosmosDBManagementClient.DatabaseAccounts.GetReadOnlyKeysWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountGetReadOnlyKeysResult);

                DatabaseAccountListReadOnlyKeysResult databaseAccountListReadOnlyKeysResult = cosmosDBManagementClient.DatabaseAccounts.ListReadOnlyKeysWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountListReadOnlyKeysResult);

                cosmosDBManagementClient.DatabaseAccounts.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters { KeyKind = "primary" });
                cosmosDBManagementClient.DatabaseAccounts.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters { KeyKind = "secondary" });
                cosmosDBManagementClient.DatabaseAccounts.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters { KeyKind = "primaryReadonly" });
                cosmosDBManagementClient.DatabaseAccounts.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters { KeyKind = "secondaryReadonly" });

                DatabaseAccountListKeysResult databaseAccountListRegeneratedKeysResult = cosmosDBManagementClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(resourceGroupName, databaseAccountName).GetAwaiter().GetResult().Body;

                bool isNameExists = cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsWithHttpMessagesAsync(databaseAccountName).GetAwaiter().GetResult().Body;
                Assert.True(isNameExists);

                cosmosDBManagementClient.DatabaseAccounts.DeleteWithHttpMessagesAsync(resourceGroupName, databaseAccountName);
            }
        }

        private static void VerifyCosmosDBAccount(DatabaseAccountGetResults databaseAccount, DatabaseAccountCreateUpdateParameters parameters)
        {
            Assert.Equal(databaseAccount.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(databaseAccount.Tags.Count, parameters.Tags.Count);
            Assert.True(databaseAccount.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(databaseAccount.Kind, parameters.Kind);
            VerifyConsistencyPolicy(databaseAccount.ConsistencyPolicy, parameters.Properties.ConsistencyPolicy);
            Assert.Equal(databaseAccount.IsVirtualNetworkFilterEnabled, parameters.Properties.IsVirtualNetworkFilterEnabled);
            Assert.Equal(databaseAccount.EnableAutomaticFailover, parameters.Properties.EnableAutomaticFailover);
            Assert.Equal(databaseAccount.EnableMultipleWriteLocations, parameters.Properties.EnableMultipleWriteLocations);
            Assert.Equal(databaseAccount.EnableCassandraConnector, parameters.Properties.EnableCassandraConnector);
            Assert.Equal(databaseAccount.ConnectorOffer, parameters.Properties.ConnectorOffer);
            Assert.Equal(databaseAccount.DisableKeyBasedMetadataWriteAccess, parameters.Properties.DisableKeyBasedMetadataWriteAccess);
        }

        private static void VerifyCosmosDBAccount(DatabaseAccountGetResults databaseAccount, DatabaseAccountUpdateParameters parameters)
        {
            Assert.Equal(databaseAccount.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(databaseAccount.Tags.Count, parameters.Tags.Count);
            Assert.True(databaseAccount.Tags.SequenceEqual(parameters.Tags));
            VerifyConsistencyPolicy(databaseAccount.ConsistencyPolicy, parameters.ConsistencyPolicy);
            Assert.Equal(databaseAccount.IsVirtualNetworkFilterEnabled, parameters.IsVirtualNetworkFilterEnabled);
            Assert.Equal(databaseAccount.EnableAutomaticFailover, parameters.EnableAutomaticFailover);
            Assert.Equal(databaseAccount.EnableCassandraConnector, parameters.EnableCassandraConnector);
            Assert.Equal(databaseAccount.ConnectorOffer, parameters.ConnectorOffer);
            Assert.Equal(databaseAccount.DisableKeyBasedMetadataWriteAccess, parameters.DisableKeyBasedMetadataWriteAccess);
        }

        private static void VerifyConsistencyPolicy(ConsistencyPolicy actualValue, ConsistencyPolicy expectedValue)
        {
            Assert.Equal(actualValue.DefaultConsistencyLevel, expectedValue.DefaultConsistencyLevel);

            if (actualValue.DefaultConsistencyLevel == DefaultConsistencyLevel.BoundedStaleness)
            { 
                Assert.Equal(actualValue.MaxIntervalInSeconds, expectedValue.MaxIntervalInSeconds);
                Assert.Equal(actualValue.MaxStalenessPrefix, expectedValue.MaxStalenessPrefix);
            }
        }
    }
}
