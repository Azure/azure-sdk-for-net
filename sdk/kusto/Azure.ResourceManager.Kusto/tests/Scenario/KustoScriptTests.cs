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

            var scriptName = "sdkScript";

            var scriptDataCreate = new KustoScriptData
            {
                ScriptContent =
                    ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)",
                ForceUpdateTag = "tag2",
                ShouldContinueOnErrors = false
            };

            var scriptDataUpdate = new KustoScriptData
            {
                ScriptUri = TestEnvironment.ScriptUri,
                ScriptUriSasToken = TestEnvironment.ScriptSasToken,
                ForceUpdateTag = "tag1",
                ShouldContinueOnErrors = true
            };

            Task<ArmOperation<KustoScriptResource>> CreateOrUpdateScriptAsync(string scriptName,
                KustoScriptData scriptData, bool create) =>
                scriptCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);

            await CollectionTests(
                scriptName, scriptDataCreate, scriptDataUpdate,
                CreateOrUpdateScriptAsync,
                scriptCollection.GetAsync,
                scriptCollection.GetAllAsync,
                scriptCollection.ExistsAsync,
                ValidateScript,
                databaseChild: true
            );

            await DeletionTest(
                scriptName,
                scriptCollection.GetAsync,
                scriptCollection.ExistsAsync
            );

            /*
            * TODO:
            * add database resource script tests
            */
        }

        private void ValidateScript(KustoScriptResource script, string scriptName, KustoScriptData scriptData)
        {
            Assert.AreEqual(scriptName, script.Data.Name);
            Assert.AreEqual(scriptData.ScriptUri, script.Data.ScriptUri);
            Assert.AreEqual(scriptData.ScriptUriSasToken, script.Data.ScriptUriSasToken);
            Assert.AreEqual(scriptData.ScriptContent, script.Data.ScriptContent);
            Assert.AreEqual(scriptData.ForceUpdateTag, script.Data.ForceUpdateTag);
            Assert.AreEqual(scriptData.ShouldContinueOnErrors, script.Data.ShouldContinueOnErrors);
        }
    }
}
