// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoClusterPrincipalAssignmentCollectionTests : KustoManagementTestBase
    {
        private KustoClusterPrincipalAssignmentCollection _clusterPrincipalAssignmentCollection;

        private string _clusterPrincipalAssignmentName;
        private KustoClusterPrincipalAssignmentData _clusterPrincipalAssignmentData;

        private CreateOrUpdateAsync<KustoClusterPrincipalAssignmentResource, KustoClusterPrincipalAssignmentData> _createOrUpdateAsync;

        public KustoClusterPrincipalAssignmentCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClusterPrincipalAssignmentCollectionSetup()
        {
            var cluster = await GetCluster(ResourceGroup);
            _clusterPrincipalAssignmentCollection = cluster.GetKustoClusterPrincipalAssignments();

            _clusterPrincipalAssignmentName = Recording.GenerateAssetName("clusterPrincipalAssignment");
            _clusterPrincipalAssignmentData = new KustoClusterPrincipalAssignmentData();

            _createOrUpdateAsync = (clusterPrincipalAssignmentName, clusterPrincipalAssignmentData) =>
                _clusterPrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterPrincipalAssignmentName, clusterPrincipalAssignmentData);
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterPrincipalAssignmentCollectionTests()
        {
            await CollectionTests(
                _clusterPrincipalAssignmentName, _clusterPrincipalAssignmentData,
                _createOrUpdateAsync,
                _clusterPrincipalAssignmentCollection.GetAsync,
                _clusterPrincipalAssignmentCollection.GetAllAsync,
                _clusterPrincipalAssignmentCollection.ExistsAsync
            );
        }
    }
}
