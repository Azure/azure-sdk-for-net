// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// using System.Threading.Tasks;
// using Azure.Core.TestFramework;
// using NUnit.Framework;
//
// namespace Azure.ResourceManager.Kusto.Tests.Scenario
// {
//     public class KustoDatabasePrincipalAssignmentCollectionTests : KustoManagementTestBase
//     {
//         private KustoDatabasePrincipalAssignmentCollection _databasePrincipalAssignmentCollection;
//
//         private string _databasePrincipalAssignmentName;
//         private KustoDatabasePrincipalAssignmentData _databasePrincipalAssignmentData;
//
//         private CreateOrUpdateAsync<KustoDatabasePrincipalAssignmentResource, KustoDatabasePrincipalAssignmentData> _createOrUpdateAsync;
//
//         public KustoDatabasePrincipalAssignmentCollectionTests(bool isAsync)
//             : base(isAsync) //, RecordedTestMode.Record)
//         {
//         }
//
//         [SetUp]
//         public async Task DatabasePrincipalAssignmentCollectionSetup()
//         {
//             var cluster = await GetCluster(ResourceGroup);
//             var database = await GetDatabase(cluster);
//             _databasePrincipalAssignmentCollection = database.GetKustoDatabasePrincipalAssignments();
//
//             _databasePrincipalAssignmentName = Recording.GenerateAssetName("databasePrincipalAssignment");
//             _databasePrincipalAssignmentData = new KustoDatabasePrincipalAssignmentData();
//
//             _createOrUpdateAsync = (databasePrincipalAssignmentName, databasePrincipalAssignmentData) =>
//                 _databasePrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, databasePrincipalAssignmentName, databasePrincipalAssignmentData);
//         }
//
//         [TestCase]
//         [RecordedTest]
//         public async Task DatabasePrincipalAssignmentCollectionTests()
//         {
//             await CollectionTests(
//                 _databasePrincipalAssignmentName, _databasePrincipalAssignmentData,
//                 _createOrUpdateAsync,
//                 _databasePrincipalAssignmentCollection.GetAsync,
//                 _databasePrincipalAssignmentCollection.GetAllAsync,
//                 _databasePrincipalAssignmentCollection.ExistsAsync
//             );
//         }
//     }
// }
