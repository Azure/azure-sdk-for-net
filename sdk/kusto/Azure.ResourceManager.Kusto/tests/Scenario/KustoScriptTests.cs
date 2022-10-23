// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        [TestCase]
        [RecordedTest]
        public async Task ScriptTests()
        {
            var scriptCollection = Database.GetKustoScripts();
            var scriptName = Recording.GenerateAssetName("sdkTestScript");
            var scriptUri = new Uri("https://dortest.blob.core.windows.net/dor/df.txt");
            var scriptUriSasToken = Environment.GetEnvironmentVariable("SCRIPTSASTOKEN");
            var scriptDataCreate = new KustoScriptData
            {
                ScriptUri = scriptUri,
                ScriptUriSasToken = scriptUriSasToken,
                ForceUpdateTag = "tag1",
                ShouldContinueOnErrors = false
            };
            var scriptDataUpdate = new KustoScriptData
            {
                ScriptUri = null,
                ScriptUriSasToken = null,
                ScriptContent =
                    ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)",
                ForceUpdateTag = "tag2",
                ShouldContinueOnErrors = false
            };

            Task<ArmOperation<KustoScriptResource>> CreateOrUpdateScriptAsync(string scriptName,
                KustoScriptData scriptData) =>
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
