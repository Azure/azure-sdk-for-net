using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoDataConnectionCollectionTests : KustoManagementTestBase
    {
        private KustoDataConnectionCollection DataConnectionCollection;

        private string DataConnectionName;
        private KustoDataConnectionData DataConnectionData;

        public KustoDataConnectionCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void DataConnectionCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            var database = await CreateDatabase(cluster);
            DataConnectionCollection = database.GetKustoDataConnections();

            DataConnectionName = Recording.GenerateAssetName("dataConnection");
            DataConnectionData = new KustoDataConnectionData();
        }

        [TestCase]
        [RecordedTest]
        public async Task DataConnectionCollectionScenario()
        {
            CreateOrUpdateAsync<KustoDataConnectionResource, KustoDataConnectionData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    DataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                DataConnectionName, DataConnectionData,
                createOrUpdateAsync,
                DataConnectionCollection.GetAsync,
                DataConnectionCollection.GetAllAsync,
                DataConnectionCollection.ExistsAsync
            );
        }
    }
}
