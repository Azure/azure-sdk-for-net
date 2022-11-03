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
        private readonly TimeSpan _hotCachePeriod2 = TimeSpan.FromDays(3);
        private readonly TimeSpan _softDeletePeriod1 = TimeSpan.FromDays(4);
        private readonly TimeSpan _softDeletePeriod2 = TimeSpan.FromDays(6);

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

            var databaseName = TestEnvironment.GenerateAssetName("sdkDatabase") + "2";

            var databaseDataCreate = new KustoReadWriteDatabase
            {
                Location = Location, SoftDeletePeriod = _softDeletePeriod1, HotCachePeriod = _hotCachePeriod1
            };

            var databaseDataUpdate = new KustoReadWriteDatabase
            {
                Location = Location, SoftDeletePeriod = _softDeletePeriod2, HotCachePeriod = _hotCachePeriod2
            };

            Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateDatabaseAsync(string databaseName,
                KustoReadWriteDatabase databaseData, bool create) =>
                databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            await CollectionTests(
                databaseName,
                databaseDataCreate, databaseDataUpdate,
                CreateOrUpdateDatabaseAsync,
                databaseCollection.GetAsync,
                databaseCollection.GetAllAsync,
                databaseCollection.ExistsAsync,
                ValidateDatabase,
                clusterChild: true
            );

            await DeletionTest(
                databaseName,
                databaseCollection.GetAsync,
                databaseCollection.ExistsAsync
            );
        }

        private void ValidateDatabase(
            KustoDatabaseResource database,
            string databaseName,
            KustoReadWriteDatabase databaseData
        )
        {
            var actualDatabaseData = (KustoReadWriteDatabase)database.Data;

            Assert.AreEqual(databaseName, actualDatabaseData.Name);
            Assert.AreEqual(databaseData.SoftDeletePeriod, actualDatabaseData.SoftDeletePeriod);
            Assert.AreEqual(databaseData.HotCachePeriod, actualDatabaseData.HotCachePeriod);
            Assert.IsFalse(actualDatabaseData.IsFollowed);
        }
    }
}
