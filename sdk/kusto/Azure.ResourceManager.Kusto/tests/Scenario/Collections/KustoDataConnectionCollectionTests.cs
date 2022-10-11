using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoDataConnectionCollectionTests : KustoManagementTestBase
    {
        private KustoDataConnectionCollection _dataConnectionCollection;

        private string _dataConnectionName;
        private KustoDataConnectionData _dataConnectionData;

        private CreateOrUpdateAsync<KustoDataConnectionResource, KustoDataConnectionData> _createOrUpdateAsync;

        public KustoDataConnectionCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task DataConnectionCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            var database = await CreateDatabase(cluster);
            _dataConnectionCollection = database.GetKustoDataConnections();

            _dataConnectionName = Recording.GenerateAssetName("dataConnection");
            _dataConnectionData = new KustoDataConnectionData();

            _createOrUpdateAsync = (dataConnectionName, dataConnectionData) =>
                _dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, dataConnectionName, dataConnectionData);
        }

        [TestCase]
        [RecordedTest]
        public async Task DataConnectionCollectionTests()
        {
            await CollectionTests(
                _dataConnectionName, _dataConnectionData,
                _createOrUpdateAsync,
                _dataConnectionCollection.GetAsync,
                _dataConnectionCollection.GetAllAsync,
                _dataConnectionCollection.ExistsAsync
            );
        }
    }
}
