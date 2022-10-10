using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoDatabasePrincipalAssignmentCollectionTests : KustoManagementTestBase
    {
        private KustoDatabasePrincipalAssignmentCollection DatabasePrincipalAssignmentCollection;

        private string DatabasePrincipalAssignmentName;
        private KustoDatabasePrincipalAssignmentData DatabasePrincipalAssignmentData;

        public KustoDatabasePrincipalAssignmentCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void DatabasePrincipalAssignmentCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            var database = await CreateDatabase(cluster);
            DatabasePrincipalAssignmentCollection = database.GetKustoDatabasePrincipalAssignments();

            DatabasePrincipalAssignmentName = Recording.GenerateAssetName("databasePrincipalAssignment");
            DatabasePrincipalAssignmentData = new KustoDatabasePrincipalAssignmentData();
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabasePrincipalAssignmentCollectionScenario()
        {
            CreateOrUpdateAsync<KustoDatabasePrincipalAssignmentResource, KustoDatabasePrincipalAssignmentData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    DatabasePrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                DatabasePrincipalAssignmentName, DatabasePrincipalAssignmentData,
                createOrUpdateAsync,
                DatabasePrincipalAssignmentCollection.GetAsync,
                DatabasePrincipalAssignmentCollection.GetAllAsync,
                DatabasePrincipalAssignmentCollection.ExistsAsync
            );
        }
    }
}
