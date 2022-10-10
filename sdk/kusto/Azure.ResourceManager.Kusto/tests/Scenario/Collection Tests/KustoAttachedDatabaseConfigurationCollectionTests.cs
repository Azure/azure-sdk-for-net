using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoAttachedDatabaseConfigurationCollectionTests : KustoManagementTestBase
    {
        private KustoAttachedDatabaseConfigurationCollection AttachedDatabaseConfigurationCollection;

        private string AttachedDatabaseConfigurationName;
        private KustoAttachedDatabaseConfigurationData AttachedDatabaseConfigurationData;

        public KustoAttachedDatabaseConfigurationCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void AttachedDatabaseConfigurationCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            AttachedDatabaseConfigurationCollection = cluster.GetKustoAttachedDatabaseConfigurations();

            AttachedDatabaseConfigurationName = Recording.GenerateAssetName("attachedDatabaseConfiguration");
            AttachedDatabaseConfigurationData = new KustoAttachedDatabaseConfigurationData();
        }

        [TestCase]
        [RecordedTest]
        public async Task AttachedDatabaseConfigurationCollectionScenario()
        {
            CreateOrUpdateAsync<KustoAttachedDatabaseConfigurationResource, KustoAttachedDatabaseConfigurationData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    AttachedDatabaseConfigurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                AttachedDatabaseConfigurationName, AttachedDatabaseConfigurationData,
                createOrUpdateAsync,
                AttachedDatabaseConfigurationCollection.GetAsync,
                AttachedDatabaseConfigurationCollection.GetAllAsync,
                AttachedDatabaseConfigurationCollection.ExistsAsync
            );
        }
    }
}
