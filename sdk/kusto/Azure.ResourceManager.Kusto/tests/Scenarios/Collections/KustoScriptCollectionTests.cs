using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenarios.Collections
{
    public class KustoScriptCollectionTests : KustoManagementTestBase
    {
        private KustoScriptCollection _scriptCollection;

        private string _scriptName;
        private KustoScriptData _scriptData;

        private CreateOrUpdateAsync<KustoScriptResource, KustoScriptData> _createOrUpdateAsync;

        public KustoScriptCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ScriptCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            var database = await CreateDatabase(cluster);
            _scriptCollection = database.GetKustoScripts();

            _scriptName = Recording.GenerateAssetName("script");
            _scriptData = new KustoScriptData();

            _createOrUpdateAsync = (scriptName, scriptData) =>
                _scriptCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);
        }

        [TestCase]
        [RecordedTest]
        public async Task ScriptCollectionTests()
        {
            await CollectionTests(
                _scriptName, _scriptData,
                _createOrUpdateAsync,
                _scriptCollection.GetAsync,
                _scriptCollection.GetAllAsync,
                _scriptCollection.ExistsAsync
            );
        }
    }
}
