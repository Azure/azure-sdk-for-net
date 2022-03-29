// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace CosmosDB.Tests.ScenarioTests
{
    public class DatabaseAccountOperationsTests : IClassFixture<TestFixture>
    {
        public TestFixture fixture;

        public DatabaseAccountOperationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void DatabaseAccountCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);

                var databaseAccountName = TestUtilities.GenerateName(prefix: "accountname");
                var accountClient = this.fixture.CosmosDBManagementClient.DatabaseAccounts;

                // Create and check
                var parameters = new DatabaseAccountCreateUpdateParameters
                {
                    Location = this.fixture.Location,
                    Tags = new Dictionary<string, string>
                     {
                        {"key1","value1"},
                        {"key2","value2"}
                     },
                    Kind = "MongoDB",
                    ConsistencyPolicy = new ConsistencyPolicy
                    {
                        DefaultConsistencyLevel = DefaultConsistencyLevel.BoundedStaleness,
                        MaxStalenessPrefix = 300,
                        MaxIntervalInSeconds = 1000
                    },
                    Locations = new List<Location> { new Location(locationName: this.fixture.Location) },
                    IpRules = new List<IpAddressOrRange>
                    {
                        new IpAddressOrRange("23.43.230.120")
                    },
                    IsVirtualNetworkFilterEnabled = true,
                    EnableAutomaticFailover = false,
                    EnableMultipleWriteLocations = true,
                    DisableKeyBasedMetadataWriteAccess = false,
                    NetworkAclBypass = NetworkAclBypass.AzureServices,
                    NetworkAclBypassResourceIds = new List<string>
                    {
                        "/subscriptions/subId/resourcegroups/rgName/providers/Microsoft.Synapse/workspaces/workspaceName"
                    },
                    CreateMode = CreateMode.Default
                };

                var databaseAccount = accountClient.CreateOrUpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    parameters
                ).GetAwaiter().GetResult().Body;
                VerifyCosmosDBAccount(databaseAccount, parameters);
                Assert.Equal(databaseAccountName, databaseAccount.Name);

                // Read and check
                var readDatabaseAccount = accountClient.GetWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                VerifyCosmosDBAccount(readDatabaseAccount, parameters);
                Assert.Equal(databaseAccountName, readDatabaseAccount.Name);

                // Update and check
                var databaseAccountUpdateParameters = new DatabaseAccountUpdateParameters
                {
                    Location = this.fixture.Location,
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
                    Locations = new List<Location> { new Location(locationName: this.fixture.Location) },
                    IpRules = new List<IpAddressOrRange>
                    {
                        new IpAddressOrRange("23.43.230.120")
                    },
                    IsVirtualNetworkFilterEnabled = false,
                    EnableAutomaticFailover = true,
                    DisableKeyBasedMetadataWriteAccess = true,
                    NetworkAclBypass = NetworkAclBypass.AzureServices,
                    NetworkAclBypassResourceIds = new List<string>
                    {
                        "/subscriptions/subId/resourcegroups/rgName/providers/Microsoft.Synapse/workspaces/workspaceName",
                        "/subscriptions/subId/resourcegroups/rgName/providers/Microsoft.Synapse/workspaces/workspaceName2"
                    }
                };

                var updatedDatabaseAccount = accountClient.UpdateWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    databaseAccountUpdateParameters
                ).GetAwaiter().GetResult().Body;
                VerifyCosmosDBAccount(updatedDatabaseAccount, databaseAccountUpdateParameters);
                Assert.Equal(databaseAccountName, databaseAccount.Name);

                // List database accounts, should not be empty
                var databaseAccounts = accountClient.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccounts);

                var databaseAccountsByResourceGroupName = accountClient.ListByResourceGroupWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountsByResourceGroupName);

                var databaseAccountListKeysResult = accountClient.ListKeysWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;

                Assert.NotNull(databaseAccountListKeysResult.PrimaryMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.SecondaryMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.PrimaryReadonlyMasterKey);
                Assert.NotNull(databaseAccountListKeysResult.SecondaryReadonlyMasterKey);

                var databaseAccountListConnectionStringsResult = accountClient.ListConnectionStringsWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountListConnectionStringsResult);

                var databaseAccountGetReadOnlyKeysResult = accountClient.GetReadOnlyKeysWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountGetReadOnlyKeysResult);

                var databaseAccountListReadOnlyKeysResult = accountClient.ListReadOnlyKeysWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;
                Assert.NotNull(databaseAccountListReadOnlyKeysResult);

                accountClient.RegenerateKeyWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    new DatabaseAccountRegenerateKeyParameters { KeyKind = "primary" }
                );
                accountClient.RegenerateKeyWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    new DatabaseAccountRegenerateKeyParameters { KeyKind = "secondary" }
                );
                accountClient.RegenerateKeyWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    new DatabaseAccountRegenerateKeyParameters { KeyKind = "primaryReadonly" }
                );
                accountClient.RegenerateKeyWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName,
                    new DatabaseAccountRegenerateKeyParameters { KeyKind = "secondaryReadonly" }
                );

                var databaseAccountListRegeneratedKeysResult = accountClient.ListKeysWithHttpMessagesAsync(
                    this.fixture.ResourceGroupName,
                    databaseAccountName
                ).GetAwaiter().GetResult().Body;

                accountClient.DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, databaseAccountName);
            }
        }

        [Fact]
        public void DatabaseAccountLocationsTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                fixture.Init(context);
                IEnumerable<LocationGetResult> locationGetResults = this.fixture.CosmosDBManagementClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                Assert.True(locationGetResults.Count() > 0);
                string locationName = "";
                foreach (LocationGetResult locationGetResult in locationGetResults)
                {
                    Assert.NotNull(locationGetResult.Name);
                    Assert.NotNull(locationGetResult.Properties.BackupStorageRedundancies);
                    Assert.NotNull(locationGetResult.Properties.IsResidencyRestricted);
                    Assert.NotNull(locationGetResult.Properties.SupportsAvailabilityZone);
                    locationName = locationGetResult.Name;
                }

                LocationGetResult currentLocationGetResult = this.fixture.CosmosDBManagementClient.Locations.GetWithHttpMessagesAsync(locationName).GetAwaiter().GetResult().Body;
                Assert.NotNull(currentLocationGetResult.Name);
                Assert.NotNull(currentLocationGetResult.Properties.BackupStorageRedundancies);
                Assert.NotNull(currentLocationGetResult.Properties.IsResidencyRestricted);
                Assert.NotNull(currentLocationGetResult.Properties.SupportsAvailabilityZone);
            }
        }

        private static void VerifyCosmosDBAccount(DatabaseAccountGetResults databaseAccount, DatabaseAccountCreateUpdateParameters parameters)
        {
            Assert.Equal(databaseAccount.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(databaseAccount.Tags.Count, parameters.Tags.Count);
            Assert.True(databaseAccount.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(databaseAccount.Kind, parameters.Kind);
            VerifyConsistencyPolicy(databaseAccount.ConsistencyPolicy, parameters.ConsistencyPolicy);
            Assert.Equal(databaseAccount.IsVirtualNetworkFilterEnabled, parameters.IsVirtualNetworkFilterEnabled);
            Assert.Equal(databaseAccount.EnableAutomaticFailover, parameters.EnableAutomaticFailover);
            Assert.Equal(databaseAccount.EnableMultipleWriteLocations, parameters.EnableMultipleWriteLocations);
            Assert.Equal(databaseAccount.DisableKeyBasedMetadataWriteAccess, parameters.DisableKeyBasedMetadataWriteAccess);
            Assert.Equal(databaseAccount.NetworkAclBypassResourceIds.Count, parameters.NetworkAclBypassResourceIds.Count);
        }

        private static void VerifyCosmosDBAccount(DatabaseAccountGetResults databaseAccount, DatabaseAccountUpdateParameters parameters)
        {
            Assert.Equal(databaseAccount.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(databaseAccount.Tags.Count, parameters.Tags.Count);
            Assert.True(databaseAccount.Tags.SequenceEqual(parameters.Tags));
            VerifyConsistencyPolicy(databaseAccount.ConsistencyPolicy, parameters.ConsistencyPolicy);
            Assert.Equal(databaseAccount.IsVirtualNetworkFilterEnabled, parameters.IsVirtualNetworkFilterEnabled);
            Assert.Equal(databaseAccount.EnableAutomaticFailover, parameters.EnableAutomaticFailover);
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