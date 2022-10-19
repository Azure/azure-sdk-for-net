// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// using System.Threading.Tasks;
// using Azure.Core.TestFramework;
// using NUnit.Framework;
//
// namespace Azure.ResourceManager.Kusto.Tests.Scenario
// {
//     public class KustoAttachedDatabaseConfigurationCollectionTests : KustoManagementTestBase
//     {
//         private KustoAttachedDatabaseConfigurationCollection _attachedDatabaseConfigurationCollection;
//
//         private string _attachedDatabaseConfigurationName;
//         private KustoAttachedDatabaseConfigurationData _attachedDatabaseConfigurationData;
//
//         private CreateOrUpdateAsync<KustoAttachedDatabaseConfigurationResource, KustoAttachedDatabaseConfigurationData> _createOrUpdateAsync;
//
//         public KustoAttachedDatabaseConfigurationCollectionTests(bool isAsync)
//             : base(isAsync) //, RecordedTestMode.Record)
//         {
//         }
//
//         [SetUp]
//         public async Task AttachedDatabaseConfigurationCollectionSetup()
//         {
//             var cluster = await GetCluster(ResourceGroup);
//             _attachedDatabaseConfigurationCollection = cluster.GetKustoAttachedDatabaseConfigurations();
//
//             _attachedDatabaseConfigurationName = Recording.GenerateAssetName("attachedDatabaseConfiguration");
//             _attachedDatabaseConfigurationData = new KustoAttachedDatabaseConfigurationData();
//
//             _createOrUpdateAsync = (attachedDatabaseConfigurationName, attachedDatabaseConfigurationData) =>
//                 _attachedDatabaseConfigurationCollection.CreateOrUpdateAsync(WaitUntil.Completed, attachedDatabaseConfigurationName, attachedDatabaseConfigurationData);
//         }
//
//         [TestCase]
//         [RecordedTest]
//         public async Task AttachedDatabaseConfigurationCollectionTests()
//         {
//             await CollectionTests(
//                 _attachedDatabaseConfigurationName, _attachedDatabaseConfigurationData,
//                 _createOrUpdateAsync,
//                 _attachedDatabaseConfigurationCollection.GetAsync,
//                 _attachedDatabaseConfigurationCollection.GetAllAsync,
//                 _attachedDatabaseConfigurationCollection.ExistsAsync
//             );
//         }
//     }
// }
