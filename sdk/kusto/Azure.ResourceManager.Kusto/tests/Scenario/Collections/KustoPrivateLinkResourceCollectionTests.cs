using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoPrivateLinkResourceCollectionTests : KustoManagementTestBase
    {
        private KustoPrivateLinkResourceCollection _privateLinkResourceCollection;

        private string _privateLinkResourceName;
        private KustoPrivateLinkResourceData _privateLinkResourceData;

        public KustoPrivateLinkResourceCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task PrivateLinkResourceCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            _privateLinkResourceCollection = cluster.GetKustoPrivateLinkResources();

            _privateLinkResourceName = Recording.GenerateAssetName("privateLinkResource");
            _privateLinkResourceData = new KustoPrivateLinkResourceData();

            var privateLinkResourceId = KustoPrivateLinkResource.CreateResourceIdentifier(
                Subscription.Id, ResourceGroup.Data.Name, cluster.Data.Name, _privateLinkResourceName
            );
            KustoPrivateLinkResource unused = new(Client, privateLinkResourceId);
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateLinkResourceCollectionTests()
        {
            await CollectionTests(
                _privateLinkResourceName, _privateLinkResourceData,
                null,
                _privateLinkResourceCollection.GetAsync,
                _privateLinkResourceCollection.GetAllAsync,
                _privateLinkResourceCollection.ExistsAsync
            );
        }
    }
}
