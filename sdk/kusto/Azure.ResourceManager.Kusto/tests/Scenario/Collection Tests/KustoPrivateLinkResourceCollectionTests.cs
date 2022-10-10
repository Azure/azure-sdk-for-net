using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoPrivateLinkResourceCollectionTests : KustoManagementTestBase
    {
        private KustoPrivateLinkResourceCollection PrivateLinkResourceCollection;

        private string PrivateLinkResourceName;
        private KustoPrivateLinkResourceData PrivateLinkResourceData;

        public KustoPrivateLinkResourceCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void PrivateLinkResourceCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            PrivateLinkResourceCollection = cluster.GetKustoPrivateLinkResources();

            PrivateLinkResourceName = Recording.GenerateAssetName("privateLinkResource");
            PrivateLinkResourceData = new KustoPrivateLinkResourceData();

            new KustoPrivateLinkResource(Client, PrivateLinkResourceData);
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateLinkResourceCollectionScenario()
        {
            await ScenarioTest(
                PrivateLinkResourceName, PrivateLinkResourceData,
                null,
                PrivateLinkResourceCollection.GetAsync,
                PrivateLinkResourceCollection.GetAllAsync,
                PrivateLinkResourceCollection.ExistsAsync,
                withCreateOrUpdate: false
            );
        }
    }
}
