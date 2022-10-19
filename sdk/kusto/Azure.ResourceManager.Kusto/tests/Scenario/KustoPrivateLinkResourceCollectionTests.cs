// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// using System.Threading.Tasks;
// using Azure.Core.TestFramework;
// using NUnit.Framework;
//
// namespace Azure.ResourceManager.Kusto.Tests.Scenario
// {
//     public class KustoPrivateLinkResourceCollectionTests : KustoManagementTestBase
//     {
//         private KustoPrivateLinkResourceCollection _privateLinkResourceCollection;
//
//         private string _privateLinkResourceName;
//         private KustoPrivateLinkResourceData _privateLinkResourceData;
//
//         public KustoPrivateLinkResourceCollectionTests(bool isAsync)
//             : base(isAsync) //, RecordedTestMode.Record)
//         {
//         }
//
//         [SetUp]
//         public async Task PrivateLinkResourceCollectionSetup()
//         {
//             var cluster = await GetCluster(ResourceGroup);
//             _privateLinkResourceCollection = cluster.GetKustoPrivateLinkResources();
//
//             _privateLinkResourceName = Recording.GenerateAssetName("privateLinkResource");
//             _privateLinkResourceData = new KustoPrivateLinkResourceData();
//
//             var privateLinkResourceId = KustoPrivateLinkResource.CreateResourceIdentifier(
//                 Subscription.Id, ResourceGroupName, ClusterName, _privateLinkResourceName
//             );
//             KustoPrivateLinkResource unused = new(Client, privateLinkResourceId);
//         }
//
//         [TestCase]
//         [RecordedTest]
//         public async Task PrivateLinkResourceCollectionTests()
//         {
//             await CollectionTests(
//                 _privateLinkResourceName, _privateLinkResourceData,
//                 null,
//                 _privateLinkResourceCollection.GetAsync,
//                 _privateLinkResourceCollection.GetAllAsync,
//                 _privateLinkResourceCollection.ExistsAsync
//             );
//         }
//     }
// }
