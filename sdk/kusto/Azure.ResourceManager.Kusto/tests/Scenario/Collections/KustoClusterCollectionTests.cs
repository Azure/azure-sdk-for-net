// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoClusterCollectionTests : KustoManagementTestBase
    {
        private KustoClusterCollection _clusterCollection;

        private string _clusterName;
        private KustoClusterData _clusterData;

        private CreateOrUpdateAsync<KustoClusterResource, KustoClusterData> _createOrUpdateAsync;

        public KustoClusterCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void ClusterCollectionSetup()
        {
            _clusterCollection = ResourceGroup.GetKustoClusters();

            _clusterName = Recording.GenerateAssetName("cluster");
            _clusterData = new KustoClusterData(Location, Sku);

            _createOrUpdateAsync = (clusterName, clusterData) =>
                _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterCollectionTests()
        {
            await CollectionTests(
                _clusterName, _clusterData,
                _createOrUpdateAsync,
                _clusterCollection.GetAsync,
                _clusterCollection.GetAllAsync,
                _clusterCollection.ExistsAsync
            );
        }
    }
}
