// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoDatabaseCollectionTests : KustoManagementTestBase
    {
        private KustoDatabaseCollection _databaseCollection;

        private string _databaseName;
        private KustoDatabaseData _databaseData;

        private CreateOrUpdateAsync<KustoDatabaseResource, KustoDatabaseData> _createOrUpdateAsync;

        public KustoDatabaseCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task DatabaseCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            _databaseCollection = cluster.GetKustoDatabases();

            _databaseName = Recording.GenerateAssetName("database");
            _databaseData = new KustoDatabaseData();

            _createOrUpdateAsync = (databaseName, databaseData) =>
                _databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseCollectionTests()
        {
            await CollectionTests(
                _databaseName, _databaseData,
                _createOrUpdateAsync,
                _databaseCollection.GetAsync,
                _databaseCollection.GetAllAsync,
                _databaseCollection.ExistsAsync
            );
        }
    }
}
