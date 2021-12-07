// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class DatabaseAccountTests : CosmosDBManagementClientBase
    {
        public DatabaseAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetup()
        {
            _resourceGroup = await ArmClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            DatabaseAccount account = await DatabaseAccountCollection.GetIfExistsAsync(_databaseAccountName);
            if (account != null)
            {
                await account.Delete().WaitForCompletionResponseAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountCreateAndUpdateTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            bool ifExists = await DatabaseAccountCollection.CheckIfExistsAsync(_databaseAccountName);
            Assert.AreEqual(true, ifExists);

            DatabaseAccount account2 = await DatabaseAccountCollection.GetAsync(_databaseAccountName);
            VerifyCosmosDBAccount(account, account2);

            var updateOptions = new DatabaseAccountUpdateOptions()
            {
                IsVirtualNetworkFilterEnabled = false,
                EnableAutomaticFailover = true,
                DisableKeyBasedMetadataWriteAccess = true,
            };
            updateOptions.Tags.Add("key3", "value3");
            updateOptions.Tags.Add("key4", "value4");
            await account2.Update(updateOptions).WaitForCompletionAsync();

            var failoverPolicyList = new List<FailoverPolicy>
            {
                new FailoverPolicy()
                {
                    LocationName = Resources.Models.Location.WestUS,
                    FailoverPriority = 0
                }
            };
            FailoverPolicies failoverPolicies = new FailoverPolicies(failoverPolicyList);
            await account2.FailoverPriorityChange(new FailoverPolicies(failoverPolicyList)).WaitForCompletionResponseAsync();

            DatabaseAccount account3 = await DatabaseAccountCollection.GetAsync(_databaseAccountName);
            VerifyCosmosDBAccount(account3, updateOptions);
            VerifyFailoverPolicies(failoverPolicyList, account3.Data.FailoverPolicies);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListBySubscriptionTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            var accounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetDatabaseAccountsAsync().ToEnumerableAsync();
            Assert.IsNotNull(accounts);

            var accountInList = accounts.Single(account => account.Data.Name == _databaseAccountName);
            Assert.IsNotNull(accountInList);
            VerifyCosmosDBAccount(account, accountInList);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListByResourceGroupTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            var accounts = await DatabaseAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(accounts);
            Assert.That(accounts, Has.Count.EqualTo(1));

            VerifyCosmosDBAccount(account, accounts[0]);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListKeysAndRegenerateKeysTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            DatabaseAccountKeyList keys = await account.GetKeysAsync();
            Assert.IsNotNull(keys.PrimaryMasterKey);
            Assert.IsNotNull(keys.PrimaryReadonlyMasterKey);
            Assert.IsNotNull(keys.SecondaryMasterKey);
            Assert.IsNotNull(keys.SecondaryReadonlyMasterKey);

            DatabaseAccountReadOnlyKeyList readOnlyKeys = await account.GetReadOnlyKeysAsync();
            Assert.IsNotNull(readOnlyKeys.PrimaryReadonlyMasterKey);
            Assert.IsNotNull(readOnlyKeys.SecondaryReadonlyMasterKey);

            await account.RegenerateKey(new DatabaseAccountRegenerateKeyOptions(KeyKind.Primary)).WaitForCompletionResponseAsync();
            await account.RegenerateKey(new DatabaseAccountRegenerateKeyOptions(KeyKind.Secondary)).WaitForCompletionResponseAsync();
            await account.RegenerateKey(new DatabaseAccountRegenerateKeyOptions(KeyKind.PrimaryReadonly)).WaitForCompletionResponseAsync();
            await account.RegenerateKey(new DatabaseAccountRegenerateKeyOptions(KeyKind.SecondaryReadonly)).WaitForCompletionResponseAsync();

            DatabaseAccountKeyList regeneratedKeys = await account.GetKeysAsync();
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys.PrimaryMasterKey, regeneratedKeys.PrimaryMasterKey);
                Assert.AreNotEqual(keys.PrimaryReadonlyMasterKey, regeneratedKeys.PrimaryReadonlyMasterKey);
                Assert.AreNotEqual(keys.SecondaryMasterKey, regeneratedKeys.SecondaryMasterKey);
                Assert.AreNotEqual(keys.SecondaryReadonlyMasterKey, regeneratedKeys.SecondaryReadonlyMasterKey);
            }
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListConnectionStringsTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            DatabaseAccountConnectionStringList connectionStrings =
                await account.GetConnectionStringsAsync();
            Assert.That(connectionStrings.ConnectionStrings, Has.Count.EqualTo(4));
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListUsageTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            List<BaseUsage> usages = await account.GetUsagesAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(usages);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListMetricsDefinitionAndMetricsTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            List<MetricDefinition> metricDefinitions =
                await account.GetMetricDefinitionsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(metricDefinitions);

            const string filter = "(name.value eq 'Total Requests') and timeGrain eq duration'PT5M'";
            var metrics = await account.GetMetricsAsync(filter).ToEnumerableAsync();
            Assert.IsNotNull(metrics);

            var regionMetrics = await account.GetMetricsDatabaseAccountRegionsAsync(Resources.Models.Location.WestUS, filter).ToEnumerableAsync();
            Assert.IsNotNull(regionMetrics);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountDeleteTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB);

            await account.Delete().WaitForCompletionResponseAsync();

            List<DatabaseAccount> accounts = await DatabaseAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(accounts);
            Assert.False(accounts.Any(a => a.Id == account.Id));
        }

        private void VerifyCosmosDBAccount(DatabaseAccount expectedValue, DatabaseAccount actualValue)
        {
            var expectedData = expectedValue.Data;
            var actualData = actualValue.Data;

            Assert.AreEqual(expectedData.Name, actualData.Name);
            Assert.AreEqual(expectedData.Location, actualData.Location);
            Assert.True(expectedData.Tags.SequenceEqual(actualData.Tags));
            Assert.AreEqual(expectedData.Kind, actualData.Kind);
            Assert.AreEqual(expectedData.ProvisioningState, actualData.ProvisioningState);
            Assert.AreEqual(expectedData.DocumentEndpoint, actualData.DocumentEndpoint);
            Assert.AreEqual(expectedData.DatabaseAccountOfferType, actualData.DatabaseAccountOfferType);
            Assert.AreEqual(expectedData.IpRules.Count, actualData.IpRules.Count);
            Assert.AreEqual(expectedData.IpRules[0].IpAddressOrRangeValue, actualData.IpRules[0].IpAddressOrRangeValue);
            Assert.AreEqual(expectedData.IsVirtualNetworkFilterEnabled, actualData.IsVirtualNetworkFilterEnabled);
            Assert.AreEqual(expectedData.EnableAutomaticFailover, actualData.EnableAutomaticFailover);
            VerifyConsistencyPolicy(expectedData.ConsistencyPolicy, actualData.ConsistencyPolicy);
            Assert.AreEqual(expectedData.Capabilities.Count, actualData.Capabilities.Count);
            VerifyLocations(expectedData.WriteLocations, actualData.WriteLocations);
            VerifyLocations(expectedData.ReadLocations, actualData.ReadLocations);
            VerifyLocations(expectedData.Locations, actualData.Locations);
            VerifyFailoverPolicies(expectedData.FailoverPolicies, actualData.FailoverPolicies);
            Assert.AreEqual(expectedData.VirtualNetworkRules.Count, actualData.VirtualNetworkRules.Count);
            Assert.AreEqual(expectedData.PrivateEndpointConnections.Count, actualData.PrivateEndpointConnections.Count);
            Assert.AreEqual(expectedData.EnableMultipleWriteLocations, actualData.EnableMultipleWriteLocations);
            Assert.AreEqual(expectedData.EnableCassandraConnector, actualData.EnableCassandraConnector);
            Assert.AreEqual(expectedData.ConnectorOffer, actualData.ConnectorOffer);
            Assert.AreEqual(expectedData.DisableKeyBasedMetadataWriteAccess, actualData.DisableKeyBasedMetadataWriteAccess);
            Assert.AreEqual(expectedData.KeyVaultKeyUri, actualData.KeyVaultKeyUri);
            Assert.AreEqual(expectedData.PublicNetworkAccess, actualData.PublicNetworkAccess);
            Assert.AreEqual(expectedData.EnableFreeTier, actualData.EnableFreeTier);
            Assert.AreEqual(expectedData.ApiProperties.ServerVersion.ToString(), actualData.ApiProperties.ServerVersion.ToString());
            Assert.AreEqual(expectedData.EnableAnalyticalStorage, actualData.EnableAnalyticalStorage);
            Assert.AreEqual(expectedData.Cors.Count, actualData.Cors.Count);
        }

        private void VerifyCosmosDBAccount(DatabaseAccount databaseAccount, DatabaseAccountUpdateOptions parameters)
        {
            Assert.True(databaseAccount.Data.Tags.SequenceEqual(parameters.Tags));
            Assert.AreEqual(databaseAccount.Data.IsVirtualNetworkFilterEnabled, parameters.IsVirtualNetworkFilterEnabled);
            Assert.AreEqual(databaseAccount.Data.EnableAutomaticFailover, parameters.EnableAutomaticFailover);
            Assert.AreEqual(databaseAccount.Data.DisableKeyBasedMetadataWriteAccess, parameters.DisableKeyBasedMetadataWriteAccess);
        }

        private void VerifyLocations(IReadOnlyList<DatabaseAccountLocation> expectedData, IReadOnlyList<DatabaseAccountLocation> actualData)
        {
            Assert.AreEqual(expectedData.Count, actualData.Count);
            if (expectedData.Count != 0)
            {
                foreach (DatabaseAccountLocation expexctedLocation in expectedData)
                {
                    foreach (DatabaseAccountLocation actualLocation in actualData)
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

        private void VerifyFailoverPolicies(IReadOnlyList<FailoverPolicy> expectedData, IReadOnlyList<FailoverPolicy> actualData)
        {
            Assert.AreEqual(expectedData.Count, actualData.Count);
            if (expectedData.Count != 0)
            {
                foreach (FailoverPolicy expexctedFailoverPolicy in expectedData)
                {
                    foreach (FailoverPolicy actualFailoverPolicy in actualData)
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
