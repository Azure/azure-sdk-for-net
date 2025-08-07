// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoPrivateLinkResourceTests : KustoManagementTestBase
    {
        public KustoPrivateLinkResourceTests(bool isAsync)
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
        public async Task PrivateLinkResourceTests()
        {
            var privateLinkResourceCollection = Cluster.GetKustoPrivateLinkResources();

            var privateLinkResourceName = "cluster";

            await CollectionTests<KustoPrivateLinkResource, KustoPrivateLinkResourceData>(
                privateLinkResourceName,
                GetFullClusterChildResourceName(privateLinkResourceName),
                null,
                null,
                null,
                privateLinkResourceCollection.GetAsync,
                privateLinkResourceCollection.GetAllAsync,
                privateLinkResourceCollection.ExistsAsync,
                ValidatePrivateLinkResource
            );
        }

        private static void ValidatePrivateLinkResource(
            string expectedFullPrivateLinkResourceName,
            KustoPrivateLinkResourceData expectedPrivateLinkResourceData,
            KustoPrivateLinkResourceData actualPrivateLinkResourceData
        )
        {
            AssertEquality(expectedFullPrivateLinkResourceName, actualPrivateLinkResourceData.Name);
        }
    }
}
