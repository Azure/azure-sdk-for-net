// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class DatabaseAccountOperationsTests : CosmosDBManagementClientBase
    {
        private string resourceGroupName;
        private const string databaseAccountName = "db4937";
        private const string location = "WEST US";
        private const int maxStalenessPrefix = 300;
        private const int maxIntervalInSeconds = 1000;
        private bool setupRun = false;
        public DatabaseAccountOperationsTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
            {
                await InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.Location,
                    this.resourceGroupName);
                setupRun = true;
            }
            else if (setupRun)
            {
                await initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task DatabaseAccountCreateAndUpdateTest()
        {
            var locations = new List<Location>();
            locations.Add(new Location(id: null, locationName: location, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false));
            var databaseAccountCreateOrUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountCreateOrUpdateParameters.Location = location;
            databaseAccountCreateOrUpdateParameters.Tags.Add("key1", "value1");
            databaseAccountCreateOrUpdateParameters.Tags.Add("key2", "value2");
            databaseAccountCreateOrUpdateParameters.Kind = DatabaseAccountKind.MongoDB;
            databaseAccountCreateOrUpdateParameters.ConsistencyPolicy =
                new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, maxStalenessPrefix, maxIntervalInSeconds);
            databaseAccountCreateOrUpdateParameters.IpRules.Add(new IpAddressOrRange("23.43.230.120"));
            databaseAccountCreateOrUpdateParameters.IsVirtualNetworkFilterEnabled = true;
            databaseAccountCreateOrUpdateParameters.EnableAutomaticFailover = false;
            databaseAccountCreateOrUpdateParameters.ConnectorOffer = "Small";
            databaseAccountCreateOrUpdateParameters.DisableKeyBasedMetadataWriteAccess = false;
            CosmosDBAccountResource databaseAccount1 =
                await WaitForCompletionAsync(
                    await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateOrUpdateParameters));
            var response = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(true, response.Value);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CosmosDBAccountResource databaseAccount2 = await CosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);
            VerifyCosmosDBAccount(databaseAccount1, databaseAccount2);

            var databaseAccountUpdateParameters = new DatabaseAccountUpdateParameters();
            databaseAccountUpdateParameters.Tags.Add("key3", "value3");
            databaseAccountUpdateParameters.Tags.Add("key4", "value4");
            databaseAccountUpdateParameters.IsVirtualNetworkFilterEnabled = false;
            databaseAccountUpdateParameters.EnableAutomaticFailover = true;
            databaseAccountUpdateParameters.DisableKeyBasedMetadataWriteAccess = true;
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountUpdateParameters));
            var failoverPolicyList = new List<FailoverPolicy>();
            failoverPolicyList.Add(new FailoverPolicy()
            {
                LocationName = location,
                FailoverPriority = 0
            });
            FailoverPolicies failoverPolicies = new FailoverPolicies(failoverPolicyList);
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartFailoverPriorityChangeAsync(resourceGroupName, databaseAccountName, failoverPolicies));
            CosmosDBAccountResource databaseAccount3 = await CosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);
            VerifyCosmosDBAccount(databaseAccount3, databaseAccountUpdateParameters);
            VerifyFailoverPolicies(failoverPolicyList, databaseAccount3.FailoverPolicies);
        }

        [TestCase, Order(2)]
        public async Task DatabaseAccountListBySubscriptionTest()
        {
            List<CosmosDBAccountResource> databaseAccounts = await CosmosDBManagementClient.DatabaseAccounts.ListAsync().ToEnumerableAsync();
            Assert.IsNotNull(databaseAccounts);
            bool databaseAccountFound = false;
            CosmosDBAccountResource actualDatabaseAccount = null;
            foreach (CosmosDBAccountResource databaseAccount in databaseAccounts)
            {
                if (databaseAccount.Name == databaseAccountName)
                {
                    databaseAccountFound = true;
                    actualDatabaseAccount = databaseAccount;
                }
            }
            Assert.AreEqual(true, databaseAccountFound);
            CosmosDBAccountResource expectedDatabaseAccount = await CosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);
            VerifyCosmosDBAccount(expectedDatabaseAccount, actualDatabaseAccount);
        }

        [TestCase, Order(2)]
        public async Task DatabaseAccountListByResourceGroupTest()
        {
            List<CosmosDBAccountResource> databaseAccounts = await CosmosDBManagementClient.DatabaseAccounts.ListByResourceGroupAsync(resourceGroupName).ToEnumerableAsync();
            Assert.IsNotNull(databaseAccounts);
            Assert.AreEqual(1, databaseAccounts.Count);
            CosmosDBAccountResource expectedDatabaseAccount = await CosmosDBManagementClient.DatabaseAccounts.GetAsync(resourceGroupName, databaseAccountName);
            VerifyCosmosDBAccount(expectedDatabaseAccount, databaseAccounts[0]);
        }

        [TestCase, Order(2)]
        [Ignore("Records keys")]
        public async Task DatabaseAccountListKeysAndRegenerateKeysTest()
        {
            DatabaseAccountListKeysResult databaseAccountListKeysResult = await CosmosDBManagementClient.DatabaseAccounts.ListKeysAsync(resourceGroupName, databaseAccountName);
            Assert.IsNotNull(databaseAccountListKeysResult.PrimaryMasterKey);
            Assert.IsNotNull(databaseAccountListKeysResult.PrimaryReadonlyMasterKey);
            Assert.IsNotNull(databaseAccountListKeysResult.SecondaryMasterKey);
            Assert.IsNotNull(databaseAccountListKeysResult.SecondaryReadonlyMasterKey);

            DatabaseAccountListReadOnlyKeysResult databaseAccountListReadOnlyKeysResult =
                await CosmosDBManagementClient.DatabaseAccounts.ListReadOnlyKeysAsync(resourceGroupName, databaseAccountName);
            Assert.IsNotNull(databaseAccountListReadOnlyKeysResult.PrimaryReadonlyMasterKey);
            Assert.IsNotNull(databaseAccountListReadOnlyKeysResult.SecondaryReadonlyMasterKey);

            DatabaseAccountListReadOnlyKeysResult databaseAccountGetReadOnlyKeysResult =
                await CosmosDBManagementClient.DatabaseAccounts.GetReadOnlyKeysAsync(resourceGroupName, databaseAccountName);
            Assert.IsNotNull(databaseAccountGetReadOnlyKeysResult.PrimaryReadonlyMasterKey);
            Assert.IsNotNull(databaseAccountGetReadOnlyKeysResult.SecondaryReadonlyMasterKey);

            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.
                StartRegenerateKeyAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters(new KeyKind("primary"))));
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.
                StartRegenerateKeyAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters(new KeyKind("secondary"))));
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.
                StartRegenerateKeyAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters(new KeyKind("primaryReadonly"))));
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.
                StartRegenerateKeyAsync(resourceGroupName, databaseAccountName, new DatabaseAccountRegenerateKeyParameters(new KeyKind("secondaryReadonly"))));

            DatabaseAccountListKeysResult databaseAccountListRegeneratedKeysResult =
                await CosmosDBManagementClient.DatabaseAccounts.ListKeysAsync(resourceGroupName, databaseAccountName);
            Assert.AreNotEqual(databaseAccountListKeysResult.PrimaryMasterKey, databaseAccountListRegeneratedKeysResult.PrimaryMasterKey);
            Assert.AreNotEqual(databaseAccountListKeysResult.PrimaryReadonlyMasterKey, databaseAccountListRegeneratedKeysResult.PrimaryReadonlyMasterKey);
            Assert.AreNotEqual(databaseAccountListKeysResult.SecondaryMasterKey, databaseAccountListRegeneratedKeysResult.SecondaryMasterKey);
            Assert.AreNotEqual(databaseAccountListKeysResult.SecondaryReadonlyMasterKey, databaseAccountListRegeneratedKeysResult.SecondaryReadonlyMasterKey);
        }

        [TestCase, Order(2)]
        public async Task DatabaseAccountListConnectionStringsTest()
        {
            DatabaseAccountListConnectionStringsResult databaseAccountListConnectionStringsResult =
                await CosmosDBManagementClient.DatabaseAccounts.ListConnectionStringsAsync(resourceGroupName, databaseAccountName);
            Assert.AreEqual(4, databaseAccountListConnectionStringsResult.ConnectionStrings.Count);
        }

        [TestCase, Order(2)]
        public async Task DatabaseAccountListUsageTest()
        {
            List<Usage> usages = await CosmosDBManagementClient.DatabaseAccounts.ListUsagesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(usages);
        }

        [TestCase, Order(2)]
        public async Task DatabaseAccountListMetricsDefinitionAndMetricsTest()
        {
            List<MetricDefinition> metricDefinitions =
                await CosmosDBManagementClient.DatabaseAccounts.ListMetricDefinitionsAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(metricDefinitions);

            string filter = "(name.value eq 'Total Requests') and timeGrain eq duration'PT5M'";
            var metrics = await CosmosDBManagementClient.DatabaseAccounts.ListMetricsAsync(resourceGroupName, databaseAccountName, filter).ToEnumerableAsync();
            Assert.IsNotNull(metrics);
            var regionMetrics =
                await CosmosDBManagementClient.DatabaseAccountRegion.ListMetricsAsync(resourceGroupName, databaseAccountName, "WEST US", filter).ToEnumerableAsync();
            Assert.IsNotNull(regionMetrics);
        }

        [TestCase, Order(3)]
        public async Task DatabaseAccountDeleteTest()
        {
            await WaitForCompletionAsync(await CosmosDBManagementClient.DatabaseAccounts.StartDeleteAsync(resourceGroupName, databaseAccountName));
            List<CosmosDBAccountResource> databaseAccounts = await CosmosDBManagementClient.DatabaseAccounts.ListByResourceGroupAsync(resourceGroupName).ToEnumerableAsync();
            Assert.IsNotNull(databaseAccounts);
            Assert.AreEqual(0, databaseAccounts.Count);
        }

        private void VerifyCosmosDBAccount(CosmosDBAccountResource expectedValue, CosmosDBAccountResource actualValue)
        {
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Location, actualValue.Location);
            Assert.True(expectedValue.Tags.SequenceEqual(actualValue.Tags));
            Assert.AreEqual(expectedValue.Kind, actualValue.Kind);
            Assert.AreEqual(expectedValue.ProvisioningState, actualValue.ProvisioningState);
            Assert.AreEqual(expectedValue.DocumentEndpoint, actualValue.DocumentEndpoint);
            Assert.AreEqual(expectedValue.DatabaseAccountOfferType, actualValue.DatabaseAccountOfferType);
            Assert.AreEqual(expectedValue.IpRules.Count, actualValue.IpRules.Count);
            Assert.AreEqual(expectedValue.IpRules[0].IpAddressOrRangeValue, actualValue.IpRules[0].IpAddressOrRangeValue);
            Assert.AreEqual(expectedValue.IsVirtualNetworkFilterEnabled, actualValue.IsVirtualNetworkFilterEnabled);
            Assert.AreEqual(expectedValue.EnableAutomaticFailover, actualValue.EnableAutomaticFailover);
            VerifyConsistencyPolicy(expectedValue.ConsistencyPolicy, actualValue.ConsistencyPolicy);
            Assert.AreEqual(expectedValue.Capabilities.Count, actualValue.Capabilities.Count);
            VerifyLocations(expectedValue.WriteLocations, actualValue.WriteLocations);
            VerifyLocations(expectedValue.ReadLocations, actualValue.ReadLocations);
            VerifyLocations(expectedValue.Locations, actualValue.Locations);
            VerifyFailoverPolicies(expectedValue.FailoverPolicies, actualValue.FailoverPolicies);
            Assert.AreEqual(expectedValue.VirtualNetworkRules.Count, actualValue.VirtualNetworkRules.Count);
            Assert.AreEqual(expectedValue.PrivateEndpointConnections.Count, actualValue.PrivateEndpointConnections.Count);
            Assert.AreEqual(expectedValue.EnableMultipleWriteLocations, actualValue.EnableMultipleWriteLocations);
            Assert.AreEqual(expectedValue.EnableCassandraConnector, actualValue.EnableCassandraConnector);
            Assert.AreEqual(expectedValue.ConnectorOffer, actualValue.ConnectorOffer);
            Assert.AreEqual(expectedValue.DisableKeyBasedMetadataWriteAccess, actualValue.DisableKeyBasedMetadataWriteAccess);
            Assert.AreEqual(expectedValue.KeyVaultKeyUri, actualValue.KeyVaultKeyUri);
            Assert.AreEqual(expectedValue.CustomerManagedKeyStatus, actualValue.CustomerManagedKeyStatus);
            Assert.AreEqual(expectedValue.PublicNetworkAccess, actualValue.PublicNetworkAccess);
            Assert.AreEqual(expectedValue.EnableFreeTier, actualValue.EnableFreeTier);
            Assert.AreEqual(expectedValue.ApiProperties.ServerVersion.ToString(), actualValue.ApiProperties.ServerVersion.ToString());
            Assert.AreEqual(expectedValue.EnableAnalyticalStorage, actualValue.EnableAnalyticalStorage);
            Assert.AreEqual(expectedValue.Cors.Count, actualValue.Cors.Count);
        }

        private void VerifyCosmosDBAccount(CosmosDBAccountResource databaseAccount, DatabaseAccountUpdateParameters parameters)
        {
            Assert.True(databaseAccount.Tags.SequenceEqual(parameters.Tags));
            Assert.AreEqual(databaseAccount.IsVirtualNetworkFilterEnabled, parameters.IsVirtualNetworkFilterEnabled);
            Assert.AreEqual(databaseAccount.EnableAutomaticFailover, parameters.EnableAutomaticFailover);
            Assert.AreEqual(databaseAccount.DisableKeyBasedMetadataWriteAccess, parameters.DisableKeyBasedMetadataWriteAccess);
        }

        private void VerifyLocations(IReadOnlyList<Location> expectedValue, IReadOnlyList<Location> actualValue)
        {
            Assert.AreEqual(expectedValue.Count, actualValue.Count);
            if (expectedValue.Count != 0)
            {
                foreach (Location expexctedLocation in expectedValue)
                {
                    foreach (Location actualLocation in actualValue)
                    {
                        if (expexctedLocation.Id == actualLocation.Id)
                        {
                            Assert.AreEqual(expexctedLocation.DocumentEndpoint, actualLocation.DocumentEndpoint);
                            Assert.AreEqual(expexctedLocation.FailoverPriority, actualLocation.FailoverPriority);
                            Assert.AreEqual(expexctedLocation.IsZoneRedundant, actualLocation.IsZoneRedundant);
                            Assert.AreEqual(expexctedLocation.LocationName, actualLocation.LocationName);
                            Assert.AreEqual(expexctedLocation.ProvisioningState, actualLocation.ProvisioningState);
                        }
                    }
                }
            }
        }

        private void VerifyFailoverPolicies(IReadOnlyList<FailoverPolicy> expectedValue, IReadOnlyList<FailoverPolicy> actualValue)
        {
            Assert.AreEqual(expectedValue.Count, actualValue.Count);
            if (expectedValue.Count != 0)
            {
                foreach (FailoverPolicy expexctedFailoverPolicy in expectedValue)
                {
                    foreach (FailoverPolicy actualFailoverPolicy in actualValue)
                    {
                        if (expexctedFailoverPolicy.Id == actualFailoverPolicy.Id)
                        {
                            Assert.AreEqual(expexctedFailoverPolicy.FailoverPriority, actualFailoverPolicy.FailoverPriority);
                            Assert.AreEqual(expexctedFailoverPolicy.LocationName, actualFailoverPolicy.LocationName);
                        }
                    }
                }
            }
        }

        private void VerifyConsistencyPolicy(ConsistencyPolicy expected, ConsistencyPolicy actual)
        {
            Assert.AreEqual(expected.DefaultConsistencyLevel, actual.DefaultConsistencyLevel);

            if (actual.DefaultConsistencyLevel == DefaultConsistencyLevel.BoundedStaleness)
            {
                Assert.AreEqual(expected.MaxIntervalInSeconds, actual.MaxIntervalInSeconds);
                Assert.AreEqual(expected.MaxStalenessPrefix, actual.MaxStalenessPrefix);
            }
        }
    }
}
#endif
