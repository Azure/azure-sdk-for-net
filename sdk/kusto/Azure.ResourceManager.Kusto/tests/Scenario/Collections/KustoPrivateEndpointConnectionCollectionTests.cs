using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoPrivateEndpointConnectionCollectionTests : KustoManagementTestBase
    {
        private KustoPrivateEndpointConnectionCollection _privateEndpointConnectionCollection;

        private string _privateEndpointConnectionName;
        private KustoPrivateEndpointConnectionData _privateEndpointConnectionData;

        private CreateOrUpdateAsync<KustoPrivateEndpointConnectionResource, KustoPrivateEndpointConnectionData> _createOrUpdateAsync;

        public KustoPrivateEndpointConnectionCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task PrivateEndpointConnectionCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            _privateEndpointConnectionCollection = cluster.GetKustoPrivateEndpointConnections();

            _privateEndpointConnectionName = Recording.GenerateAssetName("privateEndpointConnection");
            _privateEndpointConnectionData = new KustoPrivateEndpointConnectionData();

            _createOrUpdateAsync = (privateEndpointConnectionName, privateEndpointConnectionData) =>
                _privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, privateEndpointConnectionData);
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateEndpointConnectionCollectionTests()
        {
            await CollectionTests(
                _privateEndpointConnectionName, _privateEndpointConnectionData,
                _createOrUpdateAsync,
                _privateEndpointConnectionCollection.GetAsync,
                _privateEndpointConnectionCollection.GetAllAsync,
                _privateEndpointConnectionCollection.ExistsAsync
            );
        }
    }
}
