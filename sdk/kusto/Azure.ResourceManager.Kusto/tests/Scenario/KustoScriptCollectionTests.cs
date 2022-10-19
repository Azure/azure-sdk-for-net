// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// using System.Threading.Tasks;
// using Azure.Core.TestFramework;
// using NUnit.Framework;
//
// namespace Azure.ResourceManager.Kusto.Tests.Scenario
// {
//     public class KustoScriptCollectionTests : KustoManagementTestBase
//     {
//         public string scriptUrl = "https://dortest.blob.core.windows.net/dor/df.txt";
//         private string scriptUrlSasToken = "todo"; // TODO: when running in recording mode - use actual sas token (just token).
//         public string forceUpdateTag = "tag1";
//         public string forceUpdateTag2 = "tag2";
//         public bool continueOnErrors = false;
//
//         private KustoScriptCollection _scriptCollection;
//
//         private string _scriptName;
//         private KustoScriptData _scriptData;
//
//         private CreateOrUpdateAsync<KustoScriptResource, KustoScriptData> _createOrUpdateAsync;
//
//         public KustoScriptCollectionTests(bool isAsync)
//             : base(isAsync) //, RecordedTestMode.Record)
//         {
//         }
//
//         [SetUp]
//         public async Task ScriptCollectionSetup()
//         {
//             var cluster = await GetCluster(ResourceGroup);
//             var database = await GetDatabase(cluster);
//             _scriptCollection = database.GetKustoScripts();
//
//             _scriptName = Recording.GenerateAssetName("script");
//             _scriptData = new KustoScriptData();
//
//             _createOrUpdateAsync = (scriptName, scriptData) =>
//                 _scriptCollection.CreateOrUpdateAsync(WaitUntil.Completed, scriptName, scriptData);
//         }
//
//         [TestCase]
//         [RecordedTest]
//         public async Task ScriptCollectionTests()
//         {
//             await CollectionTests(
//                 _scriptName, _scriptData,
//                 _createOrUpdateAsync,
//                 _scriptCollection.GetAsync,
//                 _scriptCollection.GetAllAsync,
//                 _scriptCollection.ExistsAsync
//             );
//         }
//     }
// }
