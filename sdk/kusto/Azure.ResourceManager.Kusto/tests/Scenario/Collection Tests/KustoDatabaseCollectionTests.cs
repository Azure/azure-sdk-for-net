using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoDatabaseCollectionTests : KustoManagementTestBase
    {
        private KustoDatabaseCollection DatabaseCollection;

        private string DatabaseName;
        private KustoDatabaseData DatabaseData;

        public KustoDatabaseCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void DatabaseCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            DatabaseCollection = cluster.GetKustoDatabases();

            DatabaseName = Recording.GenerateAssetName("database");
            DatabaseData = new KustoDatabaseData();
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabaseCollectionScenario()
        {
            CreateOrUpdateAsync<KustoDatabaseResource, KustoDatabaseData> createOrUpdateAsync =
                (databaseName, databaseData) =>
                    DatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            await ScenarioTest(
                DatabaseName, DatabaseData,
                createOrUpdateAsync,
                DatabaseCollection.GetAsync,
                DatabaseCollection.GetAllAsync,
                DatabaseCollection.ExistsAsync
            );
        }
    }
}
