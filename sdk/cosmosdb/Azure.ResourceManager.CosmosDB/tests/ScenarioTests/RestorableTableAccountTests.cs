// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class RestorableTableAccountTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _restorableDatabaseAccount;
        private CosmosDBAccountResource _restoredDatabaseAccount;

        public RestorableTableAccountTests(bool isAsync) : base(isAsync)
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
            _restorableDatabaseAccount = null;
            _restoredDatabaseAccount = null;
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_restorableDatabaseAccount != null)
                {
                    await _restorableDatabaseAccount.DeleteAsync(WaitUntil.Completed);
                }

                if (_restoredDatabaseAccount != null)
                {
                    await _restoredDatabaseAccount.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task TableRetrieveContinuousBackupInformation()
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
            Resources.SubscriptionResource subscriptionResource = await ArmClient.GetDefaultSubscriptionAsync();
            var restorableAccounts = await subscriptionResource.GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var tableName = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table = await CreateTable(tableName, null);
            ContinuousBackupRestoreLocation restoreLocation = new ContinuousBackupRestoreLocation()
            {
                Location = restorableAccount.Data.Location
            };
            var backupInformation = await table.RetrieveContinuousBackupInformationAsync(WaitUntil.Completed, restoreLocation);

            DateTime? oldTime = _restorableDatabaseAccount.Data.SystemData.CreatedOn.Value.DateTime;
            Assert.NotNull(oldTime);

            Assert.NotNull(backupInformation);
            Assert.NotNull(backupInformation.Value.ContinuousBackupInformation);
            Assert.True(backupInformation.Value.ContinuousBackupInformation.LatestRestorableTimestamp.Value.DateTime > oldTime);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreTableDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var tableName = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table = await CreateTable(tableName, null);
            AddDelayInSeconds(60);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)table.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(60);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(60),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            _restoredDatabaseAccount = await RestoreAndVerifyRestoredAccount(restorableAccount, restoreParameters);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreTable()
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();

            var tableName1 = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table1 = await CreateTable(tableName1, null);
            AddDelayInSeconds(60);

            var tableName2 = Recording.GenerateAssetName("table-");
            CosmosDBTableResource table2 = await CreateTable(tableName2, null);
            AddDelayInSeconds(60);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)table1.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(60);

            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            // Fetching restorable tables
            var restorableTables = await restorableAccount.GetRestorableTablesAsync().ToEnumerableAsync();
            Assert.True(restorableTables.Count == 2);

            // Building restore parameter to restore table1
            RestorableTable restorableTable = restorableTables.Single(table => table.Resource.TableName == tableName1);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreSource = restorableAccount.Id.ToString(),
                RestoreTimestampInUtc = ts.AddSeconds(60)
            };

            restoreParameters.TablesToRestore.Add(restorableTable.Resource.TableName);

            _restoredDatabaseAccount = await RestoreAndVerifyRestoredAccount(restorableAccount, restoreParameters);

            // verifying restored table
            CosmosDBTableResource restoredTable = await _restoredDatabaseAccount.GetCosmosDBTableAsync(restorableTable.Resource.TableName);
            Assert.NotNull(restoredTable);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableTableDatabaseAccountFeed()
        {
            await RestorableDatabaseAccountFeedTestHelperAsync("Table, Sql", 1);
        }

        protected async Task<CosmosDBAccountResource> CreateRestorableDatabaseAccount(string name, CosmosDBAccountKind kind, bool isFreeTierEnabled = false, List<CosmosDBAccountCapability> capabilities = null, string apiVersion = null)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds, null),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120", null) },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = new ContinuousModeBackupPolicy(),
                IsFreeTierEnabled = isFreeTierEnabled,
            };

            if (capabilities != null)
            {
                capabilities.ForEach(x => createOptions.Capabilities.Add(x));
            }

            if (apiVersion != null)
            {
                createOptions.ApiServerVersion = apiVersion;
            }

            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseAccountName, createOptions);
            return accountLro.Value;
        }

        private async Task<CosmosDBAccountResource> RestoreAndVerifyRestoredAccount(RestorableCosmosDBAccountResource restorableAccount, CosmosDBAccountRestoreParameters restoreParameters, bool IsFreeTierEnabled = false)
        {
            CosmosDBAccountKind kind = CosmosDBAccountKind.GlobalDocumentDB;

            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var restoredAccountName = Recording.GenerateAssetName("restoredaccount-");

            CosmosDBAccountCreateOrUpdateContent databaseAccountCreateUpdateParameters = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS, locations)
            {
                Kind = kind,
                CreateMode = CosmosDBAccountCreateMode.Restore,
                RestoreParameters = restoreParameters
            };
            databaseAccountCreateUpdateParameters.Tags.Add("key1", "value1");
            databaseAccountCreateUpdateParameters.Tags.Add("key2", "value2");
            databaseAccountCreateUpdateParameters.Capabilities.Add(new CosmosDBAccountCapability("EnableTable", null));

            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, restoredAccountName, databaseAccountCreateUpdateParameters);
            CosmosDBAccountResource restoredDatabaseAccount = accountLro.Value;
            Assert.NotNull(restoredDatabaseAccount);
            Assert.NotNull(restoredDatabaseAccount.Data.RestoreParameters);
            Assert.AreEqual(restoredDatabaseAccount.Data.RestoreParameters.RestoreSource.ToLower(), restorableAccount.Id.ToString().ToLower());
            Assert.True(restoredDatabaseAccount.Data.BackupPolicy is ContinuousModeBackupPolicy);

            ContinuousModeBackupPolicy policy = restoredDatabaseAccount.Data.BackupPolicy as ContinuousModeBackupPolicy;
            Assert.AreEqual(_restorableDatabaseAccount.Data.BackupPolicy.BackupPolicyType, policy.BackupPolicyType);
            Assert.AreEqual(IsFreeTierEnabled, restoredDatabaseAccount.Data.IsFreeTierEnabled);

            return restoredDatabaseAccount;
        }

        private async Task RestorableDatabaseAccountFeedTestHelperAsync(
            string sourceApiType,
            int expectedRestorableLocationCount)
        {
            _restorableDatabaseAccount = await GetDatabaseAccount();
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);
            ValidateRestorableDatabaseAccount(restorableAccount, sourceApiType, expectedRestorableLocationCount);
        }

        private void ValidateRestorableDatabaseAccount(
            RestorableCosmosDBAccountResource restorableDatabaseAccount,
            string expectedApiType,
            int expectedRestorableLocations)
        {
            Assert.AreEqual(expectedApiType, restorableDatabaseAccount.Data.ApiType.Value.ToString());
            Assert.AreEqual(expectedRestorableLocations, restorableDatabaseAccount.Data.RestorableLocations.Count);
            Assert.AreEqual("Microsoft.DocumentDB/locations/restorableDatabaseAccounts", restorableDatabaseAccount.Data.ResourceType.ToString());
            Assert.AreEqual(_restorableDatabaseAccount.Data.Location, restorableDatabaseAccount.Data.Location);
            Assert.AreEqual(_restorableDatabaseAccount.Data.Name, restorableDatabaseAccount.Data.AccountName);
            Assert.True(restorableDatabaseAccount.Data.CreatedOn.HasValue);
        }

        internal async Task<CosmosDBTableResource> CreateTable(string tableName, AutoscaleSettings autoscale)
        {
            return await CreateTable(tableName, autoscale, _restorableDatabaseAccount.GetCosmosDBTables());
        }

        internal static async Task<CosmosDBTableResource> CreateTable(string name, AutoscaleSettings autoscale, CosmosDBTableCollection collection)
        {
            var mongoDBDatabaseCreateUpdateOptions = new CosmosDBTableCreateOrUpdateContent(AzureLocation.WestUS,
                new CosmosDBTableResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, mongoDBDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        public async Task<CosmosDBAccountResource> GetDatabaseAccount()
        {
            string accountName = Recording.GenerateAssetName("r-table-account-");

            CosmosDBAccountResource account = await CreateRestorableDatabaseAccount(
                name: accountName,
                kind: CosmosDBAccountKind.GlobalDocumentDB,
                capabilities: new List<CosmosDBAccountCapability> { new CosmosDBAccountCapability("EnableTable", null) }
                );

            return account;
        }

        private void AddDelayInSeconds(int delayInSeconds)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Thread.Sleep(delayInSeconds * 1000);
            }
        }
    }
}
