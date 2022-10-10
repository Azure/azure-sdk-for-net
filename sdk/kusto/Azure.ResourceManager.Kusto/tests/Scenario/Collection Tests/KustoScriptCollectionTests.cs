using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collection_Tests
{
    public class KustoScriptCollectionTests : KustoManagementTestBase
    {
        private KustoScriptCollection ScriptCollection;

        private string ScriptName;
        private KustoScriptData ScriptData;

        public KustoScriptCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async void ScriptCollectionSetup()
        {
            var cluster = await CreateCluster(ResourceGroup);
            var database = await CreateDatabase(cluster);
            ScriptCollection = database.GetKustoScripts();

            ScriptName = Recording.GenerateAssetName("script");
            ScriptData = new KustoScriptData();
        }

        [TestCase]
        [RecordedTest]
        public async Task ScriptCollectionScenario()
        {
            CreateOrUpdateAsync<KustoScriptResource, KustoScriptData> createOrUpdateAsync =
                (scriptName, scriptData) =>
                    ScriptCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await ScenarioTest(
                ScriptName, ScriptData,
                createOrUpdateAsync,
                ScriptCollection.GetAsync,
                ScriptCollection.GetAllAsync,
                ScriptCollection.ExistsAsync
            );
        }
    }
}
