// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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

        public KustoDatabaseTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(cluster: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseTests()
        {
            var databaseCollection = Cluster.GetKustoDatabases();

            var databaseName = GenerateAssetName("sdkDatabase") + "2";

            var databaseDataCreate = new KustoReadWriteDatabase
            {
                HotCachePeriod = _hotCachePeriod1, SoftDeletePeriod = _softDeletePeriod1
            };

            var databaseDataUpdate = new KustoReadWriteDatabase
            {
                HotCachePeriod = _hotCachePeriod2, SoftDeletePeriod = _softDeletePeriod2
            };

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
            KustoReadWriteDatabase expectedDatabaseData, KustoReadWriteDatabase actualDatabaseData
        )
        {
            Assert.AreEqual(expectedDatabaseData.HotCachePeriod, actualDatabaseData.HotCachePeriod);
            Assert.IsFalse(actualDatabaseData.IsFollowed);
            Assert.AreEqual(KustoKind.ReadWrite, actualDatabaseData.Kind);
            Assert.AreEqual(expectedFullDatabaseName, actualDatabaseData.Name);
            Assert.AreEqual(expectedDatabaseData.SoftDeletePeriod, actualDatabaseData.SoftDeletePeriod);
        }
    }
}
