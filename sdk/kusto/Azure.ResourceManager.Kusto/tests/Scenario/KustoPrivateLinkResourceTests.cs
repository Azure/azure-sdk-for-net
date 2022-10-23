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

        [TestCase]
        [RecordedTest]
        public async Task PrivateLinkResourceTests()
        {
            var privateLinkResourceCollection = Cluster.GetKustoPrivateLinkResources();

            await CollectionTests<KustoPrivateLinkResource, KustoPrivateLinkResourceData>(
                "cluster", null, null,
                null,
                privateLinkResourceCollection.GetAsync,
                privateLinkResourceCollection.GetAllAsync,
                privateLinkResourceCollection.ExistsAsync,
                ValidatePrivateLinkResource,
                clusterChild: true
            );
        }

        private void ValidatePrivateLinkResource(KustoPrivateLinkResource privateLinkResource,
            string privateLinkResourceName, KustoPrivateLinkResourceData privateLinkResourceData)
        {
            Assert.IsTrue(true);
        }
    }
}
