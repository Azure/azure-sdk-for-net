using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoManagedPrivateEndpointCollectionTests : KustoManagementTestBase
    {
        private KustoManagedPrivateEndpointCollection ManagedPrivateEndpointCollection;

        private string ManagedPrivateEndpointName;
        private KustoManagedPrivateEndpointData ManagedPrivateEndpointData;

        public KustoManagedPrivateEndpointCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void ManagedPrivateEndpointCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            ManagedPrivateEndpointCollection = cluster.GetKustoManagedPrivateEndpoints();

            ManagedPrivateEndpointName = Recording.GenerateAssetName("managedPrivateEndpoint");
            ManagedPrivateEndpointData = new KustoManagedPrivateEndpointData();
        }

        [TestCase]
        [RecordedTest]
        public async Task ManagedPrivateEndpointCollectionScenario()
        {
            CreateOrUpdateAsync<KustoManagedPrivateEndpointResource, KustoManagedPrivateEndpointData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    ManagedPrivateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                ManagedPrivateEndpointName, ManagedPrivateEndpointData,
                createOrUpdateAsync,
                ManagedPrivateEndpointCollection.GetAsync,
                ManagedPrivateEndpointCollection.GetAllAsync,
                ManagedPrivateEndpointCollection.ExistsAsync
            );
        }
    }
}
