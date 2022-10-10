using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoClusterCollectionTests : KustoManagementTestBase
    {
        private KustoClusterCollection ClusterCollection;

        private string ClusterName;
        private KustoClusterData ClusterData;

        public KustoClusterCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void ClusterCollectionSetup()
        {
            ClusterCollection = ResourceGroup.GetKustoClusters();

            ClusterName = Recording.GenerateAssetName("cluster");
            ClusterData = new KustoClusterData(Location, Sku);
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterCollectionScenario()
        {
            CreateOrUpdateAsync<KustoClusterResource, KustoClusterData> createOrUpdateAsync =
                (clusterName, clusterData) =>
                    ClusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);

            await ScenarioTest(
                ClusterName, ClusterData,
                createOrUpdateAsync,
                ClusterCollection.GetAsync,
                ClusterCollection.GetAllAsync,
                ClusterCollection.ExistsAsync
            );
        }
    }
}
