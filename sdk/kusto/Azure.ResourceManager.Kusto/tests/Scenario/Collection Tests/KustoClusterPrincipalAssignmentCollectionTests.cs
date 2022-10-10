using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoClusterPrincipalAssignmentCollectionTests : KustoManagementTestBase
    {
        private KustoClusterPrincipalAssignmentCollection ClusterPrincipalAssignmentCollection;

        private string ClusterPrincipalAssignmentName;
        private KustoClusterPrincipalAssignmentData ClusterPrincipalAssignmentData;

        public KustoClusterPrincipalAssignmentCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void ClusterPrincipalAssignmentCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            ClusterPrincipalAssignmentCollection = cluster.GetKustoClusterPrincipalAssignments();

            ClusterPrincipalAssignmentName = Recording.GenerateAssetName("clusterPrincipalAssignment");
            ClusterPrincipalAssignmentData = new KustoClusterPrincipalAssignmentData();
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterPrincipalAssignmentCollectionScenario()
        {
            CreateOrUpdateAsync<KustoClusterPrincipalAssignmentResource, KustoClusterPrincipalAssignmentData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    ClusterPrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                ClusterPrincipalAssignmentName, ClusterPrincipalAssignmentData,
                createOrUpdateAsync,
                ClusterPrincipalAssignmentCollection.GetAsync,
                ClusterPrincipalAssignmentCollection.GetAllAsync,
                ClusterPrincipalAssignmentCollection.ExistsAsync
            );
        }
    }
}
