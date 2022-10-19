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
        private KustoDatabaseCollection _databaseCollection;

        private string _databaseName;
        private KustoReadWriteDatabase _databaseDataCreate;
        private KustoReadWriteDatabase _databaseDataUpdate;

        private CreateOrUpdateAsync<KustoDatabaseResource, KustoReadWriteDatabase> _createOrUpdateDatabaseAsync;

        public KustoDatabaseTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task DatabaseSetup()
        {
            var cluster = await GetCluster(ResourceGroup);
            _databaseCollection = cluster.GetKustoDatabases();

            _databaseName = Recording.GenerateAssetName("sdkTestDatabase");
            _databaseDataCreate = new KustoReadWriteDatabase
            {
                Location = Location, SoftDeletePeriod = SoftDeletePeriod1, HotCachePeriod = HotCachePeriod1
            };
            _databaseDataUpdate = new KustoReadWriteDatabase
            {
                Location = Location, SoftDeletePeriod = SoftDeletePeriod2, HotCachePeriod = HotCachePeriod2
            };

            _createOrUpdateDatabaseAsync = (databaseName, databaseData) =>
                _databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseTests()
        {
            await CollectionTests(
                _databaseName, $"{ClusterName}/{_databaseName}",
                _databaseDataCreate, _databaseDataUpdate,
                _createOrUpdateDatabaseAsync,
                _databaseCollection.GetAsync,
                _databaseCollection.GetAllAsync,
                _databaseCollection.ExistsAsync,
                ValidateDatabase
            );

            KustoDatabaseResource database;
            bool exists;

            database = (await _databaseCollection.GetAsync(_databaseName)).Value;

            await database.DeleteAsync(WaitUntil.Completed);
            exists = await _databaseCollection.ExistsAsync(_databaseName);
            Assert.AreEqual(false, exists);
        }

        private void ValidateDatabase(
            KustoDatabaseResource database,
            string databaseName,
            KustoReadWriteDatabase databaseData
        )
        {
            Assert.AreEqual(databaseName, database.Data.Name);
            Assert.AreEqual(databaseData.SoftDeletePeriod, ((KustoReadWriteDatabase)database.Data).SoftDeletePeriod);
            Assert.AreEqual(databaseData.HotCachePeriod, ((KustoReadWriteDatabase)database.Data).HotCachePeriod);
        }
    }
}
