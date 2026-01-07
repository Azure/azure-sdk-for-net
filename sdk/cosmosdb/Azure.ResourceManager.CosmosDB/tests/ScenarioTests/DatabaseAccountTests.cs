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
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class DatabaseAccountTests : CosmosDBManagementClientBase
    {
        public DatabaseAccountTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await DatabaseAccountCollection.ExistsAsync(_databaseAccountName))
                {
                    var id = DatabaseAccountCollection.Id;
                    id = CosmosDBAccountResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, _databaseAccountName);
                    CosmosDBAccountResource account = this.ArmClient.GetCosmosDBAccountResource(id);
                    await account.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountCreateAndUpdateTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            bool ifExists = await DatabaseAccountCollection.ExistsAsync(_databaseAccountName);
            Assert.That(ifExists, Is.EqualTo(true));

            CosmosDBAccountResource account2 = await DatabaseAccountCollection.GetAsync(_databaseAccountName);
            VerifyCosmosDBAccount(account, account2);

            var updateOptions = new CosmosDBAccountPatch()
            {
                IsVirtualNetworkFilterEnabled = false,
                EnableAutomaticFailover = true,
                DisableKeyBasedMetadataWriteAccess = true,
                EnableBurstCapacity = true,
                EnablePriorityBasedExecution = true,
                DefaultPriorityLevel = DefaultPriorityLevel.Low,
                EnablePerRegionPerPartitionAutoscale = true
            };
            updateOptions.Tags.Add("key3", "value3");
            updateOptions.Tags.Add("key4", "value4");
            await account2.UpdateAsync(WaitUntil.Completed, updateOptions);

            var failoverPolicyList = new List<CosmosDBFailoverPolicy>
            {
                new CosmosDBFailoverPolicy()
                {
                    LocationName = AzureLocation.WestUS,
                    FailoverPriority = 0
                }
            };
            CosmosDBFailoverPolicies failoverPolicies = new CosmosDBFailoverPolicies(failoverPolicyList);
            await account2.FailoverPriorityChangeAsync(WaitUntil.Completed, failoverPolicies);

            CosmosDBAccountResource account3 = await DatabaseAccountCollection.GetAsync(_databaseAccountName);
            VerifyCosmosDBAccount(account3, updateOptions);
            VerifyFailoverPolicies(failoverPolicyList, account3.Data.FailoverPolicies);
        }

        [Test]
        [RecordedTest]
        [Ignore("Flaky test: Need diagnose that the test is not generating the recordings by RP team")]
        public async Task DatabaseAccountListBySubscriptionTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            var accounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(accounts, Is.Not.Null);

            var accountInList = accounts.Single(account => account.Data.Name == _databaseAccountName);
            Assert.That(accountInList, Is.Not.Null);
            VerifyCosmosDBAccount(account, accountInList);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListByResourceGroupTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            var accounts = await DatabaseAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(accounts);
            Assert.That(accounts, Has.Count.EqualTo(1));

            VerifyCosmosDBAccount(account, accounts[0]);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListKeysAndRegenerateKeysTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            CosmosDBAccountKeyList keys = await account.GetKeysAsync();
            Assert.That(keys.PrimaryMasterKey, Is.Not.Null);
            Assert.That(keys.PrimaryReadonlyMasterKey, Is.Not.Null);
            Assert.That(keys.SecondaryMasterKey, Is.Not.Null);
            Assert.That(keys.SecondaryReadonlyMasterKey, Is.Not.Null);

            CosmosDBAccountReadOnlyKeyList readOnlyKeys = await account.GetReadOnlyKeysAsync();
            Assert.That(readOnlyKeys.PrimaryReadonlyMasterKey, Is.Not.Null);
            Assert.That(readOnlyKeys.SecondaryReadonlyMasterKey, Is.Not.Null);

            await account.RegenerateKeyAsync(WaitUntil.Completed, new CosmosDBAccountRegenerateKeyContent(CosmosDBAccountKeyKind.Primary));
            await account.RegenerateKeyAsync(WaitUntil.Completed, new CosmosDBAccountRegenerateKeyContent(CosmosDBAccountKeyKind.Secondary));
            await account.RegenerateKeyAsync(WaitUntil.Completed, new CosmosDBAccountRegenerateKeyContent(CosmosDBAccountKeyKind.PrimaryReadonly));
            await account.RegenerateKeyAsync(WaitUntil.Completed, new CosmosDBAccountRegenerateKeyContent(CosmosDBAccountKeyKind.SecondaryReadonly));

            CosmosDBAccountKeyList regeneratedKeys = await account.GetKeysAsync();
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(regeneratedKeys.PrimaryMasterKey, Is.Not.EqualTo(keys.PrimaryMasterKey));
                Assert.That(regeneratedKeys.PrimaryReadonlyMasterKey, Is.Not.EqualTo(keys.PrimaryReadonlyMasterKey));
                Assert.That(regeneratedKeys.SecondaryMasterKey, Is.Not.EqualTo(keys.SecondaryMasterKey));
                Assert.That(regeneratedKeys.SecondaryReadonlyMasterKey, Is.Not.EqualTo(keys.SecondaryReadonlyMasterKey));
            }
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListConnectionStringsTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            var connectionStrings = await account.GetConnectionStringsAsync().ToEnumerableAsync();
            Assert.That(connectionStrings, Has.Count.EqualTo(4));

            foreach (var item in connectionStrings)
            {
                Assert.That(item.KeyKind, Is.Not.Null);
                Assert.That(item.KeyType, Is.Not.Null);
            }
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListUsageTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            List<CosmosDBBaseUsage> usages = await account.GetUsagesAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(usages);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountListMetricsDefinitionAndMetricsTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            List<CosmosDBMetricDefinition> metricDefinitions =
                await account.GetMetricDefinitionsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(metricDefinitions);

            const string filter = "(name.value eq 'Total Requests') and timeGrain eq duration'PT5M'";
            var metrics = await account.GetMetricsAsync(filter).ToEnumerableAsync();
            Assert.That(metrics, Is.Not.Null);

            var regionMetrics = await account.GetMetricsDatabaseAccountRegionsAsync(AzureLocation.WestUS, filter).ToEnumerableAsync();
            Assert.That(regionMetrics, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseAccountDeleteTest()
        {
            var account = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB);

            await account.DeleteAsync(WaitUntil.Completed);

            List<CosmosDBAccountResource> accounts = await DatabaseAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accounts, Is.Not.Null);
            Assert.That(accounts.Any(a => a.Id == account.Id), Is.False);
        }

        private void VerifyCosmosDBAccount(CosmosDBAccountResource expectedValue, CosmosDBAccountResource actualValue)
        {
            var expectedData = expectedValue.Data;
            var actualData = actualValue.Data;

            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Location, Is.EqualTo(expectedData.Location));
            Assert.That(expectedData.Tags.SequenceEqual(actualData.Tags), Is.True);
            Assert.That(actualData.Kind, Is.EqualTo(expectedData.Kind));
            Assert.That(actualData.ProvisioningState, Is.EqualTo(expectedData.ProvisioningState));
            Assert.That(actualData.DocumentEndpoint, Is.EqualTo(expectedData.DocumentEndpoint));
            Assert.That(actualData.DatabaseAccountOfferType, Is.EqualTo(expectedData.DatabaseAccountOfferType));
            Assert.That(actualData.IPRules.Count, Is.EqualTo(expectedData.IPRules.Count));
            Assert.That(actualData.IPRules[0].IPAddressOrRange, Is.EqualTo(expectedData.IPRules[0].IPAddressOrRange));
            Assert.That(actualData.IsVirtualNetworkFilterEnabled, Is.EqualTo(expectedData.IsVirtualNetworkFilterEnabled));
            Assert.That(actualData.EnableAutomaticFailover, Is.EqualTo(expectedData.EnableAutomaticFailover));
            VerifyConsistencyPolicy(expectedData.ConsistencyPolicy, actualData.ConsistencyPolicy);
            Assert.That(actualData.Capabilities.Count, Is.EqualTo(expectedData.Capabilities.Count));
            VerifyLocations(expectedData.WriteLocations, actualData.WriteLocations);
            VerifyLocations(expectedData.ReadLocations, actualData.ReadLocations);
            VerifyLocations(expectedData.Locations, actualData.Locations);
            VerifyFailoverPolicies(expectedData.FailoverPolicies, actualData.FailoverPolicies);
            Assert.That(actualData.VirtualNetworkRules.Count, Is.EqualTo(expectedData.VirtualNetworkRules.Count));
            Assert.That(actualData.PrivateEndpointConnections.Count, Is.EqualTo(expectedData.PrivateEndpointConnections.Count));
            Assert.That(actualData.EnableMultipleWriteLocations, Is.EqualTo(expectedData.EnableMultipleWriteLocations));
            Assert.That(actualData.EnableCassandraConnector, Is.EqualTo(expectedData.EnableCassandraConnector));
            Assert.That(actualData.ConnectorOffer, Is.EqualTo(expectedData.ConnectorOffer));
            Assert.That(actualData.DisableKeyBasedMetadataWriteAccess, Is.EqualTo(expectedData.DisableKeyBasedMetadataWriteAccess));
            Assert.That(actualData.KeyVaultKeyUri, Is.EqualTo(expectedData.KeyVaultKeyUri));
            Assert.That(actualData.CustomerManagedKeyStatus, Is.EqualTo(expectedData.CustomerManagedKeyStatus));
            Assert.That(actualData.PublicNetworkAccess, Is.EqualTo(expectedData.PublicNetworkAccess));
            Assert.That(actualData.IsFreeTierEnabled, Is.EqualTo(expectedData.IsFreeTierEnabled));
            Assert.That(actualData.ApiProperties.ServerVersion.ToString(), Is.EqualTo(expectedData.ApiProperties.ServerVersion.ToString()));
            Assert.That(actualData.IsAnalyticalStorageEnabled, Is.EqualTo(expectedData.IsAnalyticalStorageEnabled));
            Assert.That(actualData.Cors.Count, Is.EqualTo(expectedData.Cors.Count));
            Assert.That(actualData.EnableBurstCapacity, Is.EqualTo(expectedData.EnableBurstCapacity));
            Assert.That(actualData.EnablePriorityBasedExecution, Is.EqualTo(expectedData.EnablePriorityBasedExecution));
            Assert.That(actualData.DefaultPriorityLevel, Is.EqualTo(expectedData.DefaultPriorityLevel));
            Assert.That(actualData.EnablePerRegionPerPartitionAutoscale, Is.EqualTo(expectedData.EnablePerRegionPerPartitionAutoscale));
        }

        private void VerifyCosmosDBAccount(CosmosDBAccountResource databaseAccount, CosmosDBAccountPatch parameters)
        {
            Assert.That(databaseAccount.Data.Tags.SequenceEqual(parameters.Tags), Is.True);
            Assert.That(parameters.IsVirtualNetworkFilterEnabled, Is.EqualTo(databaseAccount.Data.IsVirtualNetworkFilterEnabled));
            Assert.That(parameters.EnableAutomaticFailover, Is.EqualTo(databaseAccount.Data.EnableAutomaticFailover));
            Assert.That(parameters.DisableKeyBasedMetadataWriteAccess, Is.EqualTo(databaseAccount.Data.DisableKeyBasedMetadataWriteAccess));
            Assert.That(parameters.EnableBurstCapacity, Is.EqualTo(databaseAccount.Data.EnableBurstCapacity));
            Assert.That(parameters.EnablePriorityBasedExecution, Is.EqualTo(databaseAccount.Data.EnablePriorityBasedExecution));
            Assert.That(parameters.DefaultPriorityLevel, Is.EqualTo(databaseAccount.Data.DefaultPriorityLevel));
            Assert.That(parameters.EnablePerRegionPerPartitionAutoscale, Is.EqualTo(databaseAccount.Data.EnablePerRegionPerPartitionAutoscale));
        }

        private void VerifyLocations(IReadOnlyList<CosmosDBAccountLocation> expectedData, IReadOnlyList<CosmosDBAccountLocation> actualData)
        {
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            if (expectedData.Count != 0)
            {
                foreach (CosmosDBAccountLocation expexctedLocation in expectedData)
                {
                    foreach (CosmosDBAccountLocation actualLocation in actualData)
                    {
                        if (expexctedLocation.Id == actualLocation.Id)
                        {
                            Assert.That(actualLocation.DocumentEndpoint, Is.EqualTo(expexctedLocation.DocumentEndpoint));
                            Assert.That(actualLocation.FailoverPriority, Is.EqualTo(expexctedLocation.FailoverPriority));
                            Assert.That(actualLocation.IsZoneRedundant, Is.EqualTo(expexctedLocation.IsZoneRedundant));
                            Assert.That(actualLocation.LocationName, Is.EqualTo(expexctedLocation.LocationName));
                            Assert.That(actualLocation.ProvisioningState, Is.EqualTo(expexctedLocation.ProvisioningState));
                        }
                    }
                }
            }
        }

        private void VerifyFailoverPolicies(IReadOnlyList<CosmosDBFailoverPolicy> expectedData, IReadOnlyList<CosmosDBFailoverPolicy> actualData)
        {
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            if (expectedData.Count != 0)
            {
                foreach (CosmosDBFailoverPolicy expexctedFailoverPolicy in expectedData)
                {
                    foreach (CosmosDBFailoverPolicy actualFailoverPolicy in actualData)
                    {
                        if (expexctedFailoverPolicy.Id == actualFailoverPolicy.Id)
                        {
                            Assert.That(actualFailoverPolicy.FailoverPriority, Is.EqualTo(expexctedFailoverPolicy.FailoverPriority));
                            Assert.That(actualFailoverPolicy.LocationName, Is.EqualTo(expexctedFailoverPolicy.LocationName));
                        }
                    }
                }
            }
        }

        private void VerifyConsistencyPolicy(ConsistencyPolicy expected, ConsistencyPolicy actual)
        {
            Assert.That(actual.DefaultConsistencyLevel, Is.EqualTo(expected.DefaultConsistencyLevel));

            if (actual.DefaultConsistencyLevel == DefaultConsistencyLevel.BoundedStaleness)
            {
                Assert.That(actual.MaxIntervalInSeconds, Is.EqualTo(expected.MaxIntervalInSeconds));
                Assert.That(actual.MaxStalenessPrefix, Is.EqualTo(expected.MaxStalenessPrefix));
            }
        }
    }
}
