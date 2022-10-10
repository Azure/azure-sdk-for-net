using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoPrivateEndpointConnectionCollectionTests : KustoManagementTestBase
    {
        private KustoPrivateEndpointConnectionCollection PrivateEndpointConnectionCollection;

        private string PrivateEndpointConnectionName;
        private KustoPrivateEndpointConnectionData PrivateEndpointConnectionData;

        public KustoPrivateEndpointConnectionCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void PrivateEndpointConnectionCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            PrivateEndpointConnectionCollection = cluster.GetKustoPrivateEndpointConnections();

            PrivateEndpointConnectionName = Recording.GenerateAssetName("privateEndpointConnection");
            PrivateEndpointConnectionData = new KustoPrivateEndpointConnectionData();
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateEndpointConnectionCollectionScenario()
        {
            CreateOrUpdateAsync<KustoPrivateEndpointConnectionResource, KustoPrivateEndpointConnectionData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    PrivateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                PrivateEndpointConnectionName, PrivateEndpointConnectionData,
                createOrUpdateAsync,
                PrivateEndpointConnectionCollection.GetAsync,
                PrivateEndpointConnectionCollection.GetAllAsync,
                PrivateEndpointConnectionCollection.ExistsAsync
            );
        }
    }
}
