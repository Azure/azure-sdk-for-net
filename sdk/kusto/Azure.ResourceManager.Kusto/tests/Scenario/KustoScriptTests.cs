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
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task ScriptTests()
        {
            var scriptCollection = Database.GetKustoScripts();

            var scriptName = GenerateAssetName("sdkScript");

            var scriptDataUpdate = new KustoScriptData
            {
                ForceUpdateTag = "tag1", ScriptUri = TE.ScriptUri, ScriptUriSasToken = TE.StorageAccountSasToken
            };

            var scriptContent =
                $".create table {GenerateAssetName("sdkScriptContentTable")} " +
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
            AssertEquality(expectedScriptData.ForceUpdateTag, actualScriptData.ForceUpdateTag);
            AssertEquality(expectedFullScriptName, actualScriptData.Name);
            Assert.IsNull(actualScriptData.ScriptContent);
            AssertEquality(expectedScriptData.ScriptUri, actualScriptData.ScriptUri);
            Assert.IsNull(actualScriptData.ScriptUriSasToken);
            AssertEquality(expectedScriptData.ShouldContinueOnErrors ?? false, actualScriptData.ShouldContinueOnErrors);
        }
    }
}
