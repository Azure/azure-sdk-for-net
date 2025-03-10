// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoDatabaseTests : KustoManagementTestBase
    {
        private readonly TimeSpan _hotCachePeriod1 = TimeSpan.FromDays(2);
        private readonly TimeSpan _softDeletePeriod1 = TimeSpan.FromDays(3);
        private readonly TimeSpan _hotCachePeriod2 = TimeSpan.FromDays(4);
        private readonly TimeSpan _softDeletePeriod2 = TimeSpan.FromDays(5);

        private Uri KeyVaultUri { get; set; }
        private string KeyName { get; set; }
        private string KeyVersion { get; set; }
        private ResourceIdentifier UserAssignedIdentityId { get; set; }

        public KustoDatabaseTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();

            KeyVaultUri = TE.KeyVaultUri;
            KeyName = TE.KeyName;
            KeyVersion = TE.KeyVersion;
            UserAssignedIdentityId = TE.UserAssignedIdentityId;
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseTests()
        {
            var databaseDataCreate = new KustoReadWriteDatabase {Location = Location, HotCachePeriod = _hotCachePeriod1, SoftDeletePeriod = _softDeletePeriod1};
            var databaseDataUpdate = new KustoReadWriteDatabase {Location = Location, HotCachePeriod = _hotCachePeriod2, SoftDeletePeriod = _softDeletePeriod2};
            await RunDatabaseTests("sdkRWDatabase", databaseDataCreate, databaseDataUpdate);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseCmkTests()
        {
            var keyVaultProperties = new KustoKeyVaultProperties {KeyName = KeyName, KeyVaultUri = KeyVaultUri, KeyVersion = KeyVersion, UserIdentity = UserAssignedIdentityId};
            var databaseDataCreate = new KustoReadWriteDatabase {Location = Location, HotCachePeriod = _hotCachePeriod1, SoftDeletePeriod = _softDeletePeriod1, KeyVaultProperties = keyVaultProperties};
            var databaseDataUpdate = new KustoReadWriteDatabase {Location = Location, HotCachePeriod = _hotCachePeriod2, SoftDeletePeriod = _softDeletePeriod2, KeyVaultProperties = keyVaultProperties};
            await RunDatabaseTests("sdkCMKDatabase", databaseDataCreate, databaseDataUpdate);
        }

        private async Task RunDatabaseTests(string databaseNamePrefix, KustoReadWriteDatabase databaseDataCreate, KustoReadWriteDatabase databaseDataUpdate)
        {
            var databaseCollection = Cluster.GetKustoDatabases();

            var databaseName = GenerateAssetName(databaseNamePrefix);

            Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateDatabaseAsync(
                string databaseName, KustoReadWriteDatabase databaseData
            ) => databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            await CollectionTests(
                databaseName,
                GetFullClusterChildResourceName(databaseName),
                databaseDataCreate,
                databaseDataUpdate,
                CreateOrUpdateDatabaseAsync,
                databaseCollection.GetAsync,
                databaseCollection.GetAllAsync,
                databaseCollection.ExistsAsync,
                ValidateReadWriteDatabase
            );

            await DeletionTest(
                databaseName,
                databaseCollection.GetAsync,
                databaseCollection.ExistsAsync
            );
        }

        private static void ValidateReadWriteDatabase(
            string expectedFullDatabaseName,
            KustoReadWriteDatabase expectedDatabaseData,
            KustoReadWriteDatabase actualDatabaseData)
        {
            AssertEquality(expectedDatabaseData.HotCachePeriod, actualDatabaseData.HotCachePeriod);
            Assert.IsFalse(actualDatabaseData.IsFollowed);
            AssertEquality(KustoKind.ReadWrite, actualDatabaseData.Kind);
            AssertEquality(expectedDatabaseData.Location, actualDatabaseData.Location);
            AssertEquality(expectedFullDatabaseName, actualDatabaseData.Name);
            AssertEquality(expectedDatabaseData.SoftDeletePeriod, actualDatabaseData.SoftDeletePeriod);
        }
    }
}
