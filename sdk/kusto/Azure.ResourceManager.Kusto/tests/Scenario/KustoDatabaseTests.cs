// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoDatabaseTests : KustoManagementTestBase
    {
        public KustoDatabaseTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseTests()
        {
            var databaseCollection = Cluster.GetKustoDatabases();
            var databaseDataUpdate = new KustoReadWriteDatabase
            {
                Location = KustoTestUtils.Location,
                SoftDeletePeriod = KustoTestUtils.SoftDeletePeriod2,
                HotCachePeriod = KustoTestUtils.HotCachePeriod2
            };

            Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateDatabaseAsync(string databaseName,
                KustoReadWriteDatabase databaseData) =>
                databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            await CollectionTests(
                DatabaseName,
                DatabaseData, databaseDataUpdate,
                CreateOrUpdateDatabaseAsync,
                databaseCollection.GetAsync,
                databaseCollection.GetAllAsync,
                databaseCollection.ExistsAsync,
                ValidateDatabase,
                resource: Database,
                clusterChild: true
            );

            await DeletionTest(
                DatabaseName,
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
