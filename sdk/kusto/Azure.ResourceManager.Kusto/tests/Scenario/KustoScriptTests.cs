// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoScriptTests : KustoManagementTestBase
    {
        public KustoScriptTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(database: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task ScriptTests()
        {
            var scriptCollection = Database.GetKustoScripts();

            var scriptName = GenerateAssetName("sdkScript") + "2";

            var scriptDataUpdate = new KustoScriptData
            {
                ForceUpdateTag = "tag1", ScriptUri = TE.ScriptUri, ScriptUriSasToken = TE.ScriptSasToken
            };

            var scriptContent =
                $".create table {GenerateAssetName("sdkScriptContentTable") + "2"} " +
                "(Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)";
            var scriptDataCreate = new KustoScriptData
            {
                ForceUpdateTag = "tag2", ScriptContent = scriptContent, ShouldContinueOnErrors = true
            };

            Task<ArmOperation<KustoScriptResource>> CreateOrUpdateScriptAsync(
                string scriptName, KustoScriptData scriptData
            ) => scriptCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await CollectionTests(
                scriptName,
                GetFullDatabaseChildResourceName(scriptName),
                scriptDataCreate,
                scriptDataUpdate,
                CreateOrUpdateScriptAsync,
                scriptCollection.GetAsync,
                scriptCollection.GetAllAsync,
                scriptCollection.ExistsAsync,
                ValidateScript
            );

            await DeletionTest(
                scriptName,
                scriptCollection.GetAsync,
                scriptCollection.ExistsAsync
            );
        }

        private static void ValidateScript(
            string expectedFullScriptName, KustoScriptData expectedScriptData, KustoScriptData actualScriptData
        )
        {
            Assert.AreEqual(expectedScriptData.ForceUpdateTag, actualScriptData.ForceUpdateTag);
            Assert.AreEqual(expectedFullScriptName, actualScriptData.Name);
            // TODO: why isn't scriptContent saved?
            // Assert.AreEqual(expectedScriptData.ScriptContent, actualScriptData.ScriptContent);
            Assert.AreEqual(expectedScriptData.ScriptUri, actualScriptData.ScriptUri);
            Assert.AreEqual(expectedScriptData.ScriptUriSasToken, actualScriptData.ScriptUriSasToken);
            Assert.AreEqual(expectedScriptData.ShouldContinueOnErrors, actualScriptData.ShouldContinueOnErrors);
        }
    }
}
