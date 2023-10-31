﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Threading;
using System.ComponentModel;
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class RestorableDatabaseAccountTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _restorableDatabaseAccount;
        private CosmosDBAccountResource _restoredDatabaseAccount;

        public RestorableDatabaseAccountTests(bool isAsync) : base(isAsync)
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
            if (_restorableDatabaseAccount != null)
            {
                await _restorableDatabaseAccount.DeleteAsync(WaitUntil.Completed);
            }

            if (_restoredDatabaseAccount != null)
            {
                await _restoredDatabaseAccount.DeleteAsync(WaitUntil.Completed);
            }

            _restorableDatabaseAccount = null;
            _restoredDatabaseAccount = null;
        }

        [Test]
        [RecordedTest]
        public async Task RestorableDatabaseAccountList()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB, AzureLocation.WestUS);
            await VerifyRestorableDatabaseAccount(_restorableDatabaseAccount.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableDatabaseAccountListWithContinuous7Account()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB, AzureLocation.WestUS, continuousTier: ContinuousTier.Continuous7Days);
            await VerifyRestorableDatabaseAccount(_restorableDatabaseAccount.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task RestorableDatabaseAccountListWithContinuous30Account()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB, AzureLocation.WestUS, continuousTier: ContinuousTier.Continuous30Days);
            await VerifyRestorableDatabaseAccount(_restorableDatabaseAccount.Data.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Not recorded")]
        public async Task RestorableDatabaseAccountListByLocation()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"), CosmosDBAccountKind.GlobalDocumentDB, AzureLocation.WestUS);
            CosmosDBLocationResource location = await (await ArmClient.GetDefaultSubscriptionAsync()).GetCosmosDBLocations().GetAsync(AzureLocation.WestUS);
            var restorableAccounts = await location.GetRestorableCosmosDBAccounts().GetAllAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
        }

        [Test]
        [RecordedTest]
        public async Task RestoreSqlDatabaseAccount()
        {
            _restorableDatabaseAccount = await GetDatabaseAccountForSpecificAPI(AccountType.PitrSql, AzureLocation.WestUS);
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
            RestorableCosmosDBAccountResource restorableAccount = restorableAccounts.Single(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name);

            var databaseName = Recording.GenerateAssetName("sql-database-");
            CosmosDBSqlDatabaseResource database = await CreateSqlDatabase(databaseName, null);

            var containerName = Recording.GenerateAssetName("sql-container-");
            CosmosDBSqlContainerResource container = await CreateSqlContainer(containerName, database, null);
            AddDelayInSeconds(240);

            DateTimeOffset ts = DateTimeOffset.FromUnixTimeSeconds((int)container.Data.Resource.Timestamp.Value);
            AddDelayInSeconds(240);

            CosmosDBAccountRestoreParameters restoreParameters = new CosmosDBAccountRestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreTimestampInUtc = ts.AddSeconds(230),
                RestoreSource = restorableAccount.Id.ToString(),
            };

            _restoredDatabaseAccount = await RestoreAndVerifyRestoredAccount(AccountType.PitrSql, restorableAccount, restoreParameters, AzureLocation.WestUS, AzureLocation.WestUS);
        }
        // TODO: more tests after fixing the code generation issue

        protected async Task<CosmosDBAccountResource> CreateRestorableDatabaseAccount(string name, CosmosDBAccountKind kind, AzureLocation location, bool isFreeTierEnabled = false, List<CosmosDBAccountCapability> capabilities = null, string apiVersion = null, ContinuousTier? continuousTier = null)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: location, documentEndpoint: null, provisioningState: null, failoverPriority: 0, isZoneRedundant: false)
            };

            CosmosDBAccountBackupPolicy backupPolicy;
            ContinuousTier inputContinuousTier;

            if (continuousTier.HasValue)
            {
                inputContinuousTier = continuousTier.Value;

                backupPolicy = new ContinuousModeBackupPolicy
                {
                    ContinuousModeProperties = new ContinuousModeProperties { Tier = continuousTier.Value }
                };
            }
            else
            {
                inputContinuousTier = ContinuousTier.Continuous30Days; // if ContinuousTier is not provided, then it defaults to Continuous30Days
                backupPolicy = new ContinuousModeBackupPolicy();
            }

            var createOptions = new CosmosDBAccountCreateOrUpdateContent(location, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = backupPolicy,
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

            Assert.AreEqual(inputContinuousTier, ((ContinuousModeBackupPolicy)accountLro.Value.Data.BackupPolicy).ContinuousModeTier, "Unexpected ContinuousTier");

            return accountLro.Value;
        }

        private async Task VerifyRestorableDatabaseAccount(string expectedRestorableDatabaseAccountName)
        {
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableCosmosDBAccountsAsync().ToEnumerableAsync();

            RestorableCosmosDBAccountResource restorableDBA = restorableAccounts.Where(account => account.Data.AccountName == expectedRestorableDatabaseAccountName).Single();
            Assert.AreEqual(restorableDBA.Data.ApiType, CosmosDBApiType.Sql);
            Assert.IsNotNull(restorableDBA.Data.CreatedOn);
            Assert.IsNull(restorableDBA.Data.DeletedOn, $"Actual DeletedOn: {restorableDBA.Data.DeletedOn}");
            Assert.IsNotNull(restorableDBA.Data.OldestRestorableOn);
            Assert.IsNotNull(restorableDBA.Data.RestorableLocations);
        }

        private async Task<CosmosDBAccountResource> RestoreAndVerifyRestoredAccount(AccountType accountType, RestorableCosmosDBAccountResource restorableAccount, CosmosDBAccountRestoreParameters restoreParameters, AzureLocation location, AzureLocation armLocation, bool IsFreeTierEnabled = false)
        {
            CosmosDBAccountKind kind = CosmosDBAccountKind.GlobalDocumentDB;

            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: location, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var restoredAccountName = Recording.GenerateAssetName("restoredaccount-");

            CosmosDBAccountCreateOrUpdateContent databaseAccountCreateUpdateParameters = new CosmosDBAccountCreateOrUpdateContent(armLocation, locations)
            {
                Kind = kind,
                CreateMode = CosmosDBAccountCreateMode.Restore,
                RestoreParameters = restoreParameters
            };
            databaseAccountCreateUpdateParameters.Tags.Add("key1", "value1");
            databaseAccountCreateUpdateParameters.Tags.Add("key2", "value2");

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

        internal async Task<CosmosDBSqlDatabaseResource> CreateSqlDatabase(string databaseName, AutoscaleSettings autoscale)
        {
            return await CreateSqlDatabase(databaseName, autoscale, _restorableDatabaseAccount.GetCosmosDBSqlDatabases());
        }

        internal static async Task<CosmosDBSqlDatabaseResource> CreateSqlDatabase(string name, AutoscaleSettings autoscale, CosmosDBSqlDatabaseCollection collection)
        {
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlDatabaseCreateOrUpdateContent(AzureLocation.WestCentralUS,
                new Models.CosmosDBSqlDatabaseResourceInfo(name))
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var databaseLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, sqlDatabaseCreateUpdateOptions);
            return databaseLro.Value;
        }

        internal async Task<CosmosDBSqlContainerResource> CreateSqlContainer(string containerName, CosmosDBSqlDatabaseResource database,  AutoscaleSettings autoscale)
        {
            return await CreateSqlContainer(containerName, autoscale, database.GetCosmosDBSqlContainers());
        }

        internal static async Task<CosmosDBSqlContainerResource> CreateSqlContainer(string name, AutoscaleSettings autoscale, CosmosDBSqlContainerCollection sqlContainerCollection)
        {
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlContainerCreateOrUpdateContent(AzureLocation.WestCentralUS,
                new Models.CosmosDBSqlContainerResourceInfo(name)
                {
                    PartitionKey = new CosmosDBContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null, false)
                    {
                        Kind = new CosmosDBPartitionKind("Hash")
                    },
                    IndexingPolicy = new CosmosDBIndexingPolicy(
                        true,
                        CosmosDBIndexingMode.Consistent,
                        new List<CosmosDBIncludedPath>
                        {
                            new CosmosDBIncludedPath { Path = "/*"}
                        },
                        new List<CosmosDBExcludedPath>
                        {
                            new CosmosDBExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                        new List<IList<CosmosDBCompositePath>>
                        {
                            new List<CosmosDBCompositePath>
                            {
                                new CosmosDBCompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                                new CosmosDBCompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                            }
                        },
                        new List<SpatialSpec>
                        {
                            new SpatialSpec
                            (
                                    "/*",
                                    new List<CosmosDBSpatialType>
                                    {
                                        new CosmosDBSpatialType("Point")
                                    }
                            ),
                        }
                    )
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await sqlContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        public enum AccountType
        {
            PitrSql,
            Pitr7Sql,
            Sql
        }

        public async Task<CosmosDBAccountResource> GetDatabaseAccountForSpecificAPI(AccountType accountType, AzureLocation location)
        {
            CosmosDBAccountResource account = null;
            string accountName = Recording.GenerateAssetName("r-database-account-");

            if (accountType == AccountType.PitrSql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    location: location
                );
            }
            if (accountType == AccountType.Pitr7Sql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    location: location,
                    isFreeTierEnabled: true
                );
            }
            else if (accountType == AccountType.Sql)
            {
                account = await CreateRestorableDatabaseAccount(
                    name: accountName,
                    kind: CosmosDBAccountKind.GlobalDocumentDB,
                    location: location
                );
            }

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
