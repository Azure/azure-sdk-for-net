// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
            await BaseSetUp(cluster: true);
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

        private void ValidatePrivateLinkResource(
            string expectedFullPrivateLinkResourceName,
            KustoPrivateLinkResourceData empty,
            KustoPrivateLinkResourceData actualPrivateLinkResourceData
        )
        {
            Assert.AreEqual("cluster", actualPrivateLinkResourceData.GroupId);
            Assert.AreEqual(expectedFullPrivateLinkResourceName, actualPrivateLinkResourceData.Name);
            Assert.AreEqual(8, actualPrivateLinkResourceData.RequiredMembers.Count);
            CollectionAssert.AreEqual(
                new List<string> { "Engine", "DataManagement" },
                actualPrivateLinkResourceData.RequiredZoneNames.Take(2)
            );
            CollectionAssert.AreEqual(
                new List<string>
                {
                    $"privatelink.{TE.Location}.kusto.windows.net",
                    "privatelink.blob.core.windows.net",
                    "privatelink.queue.core.windows.net",
                    "privatelink.table.core.windows.net"
                },
                actualPrivateLinkResourceData.RequiredZoneNames
            );
        }
    }
}
