// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests
{
    public class PrivateCloudClusterCollectionTest : AvsManagementTestBase
    {
        protected ResourceGroupResource _resourceGroup;
        protected AvsPrivateCloudCollection avsPrivateCloudCollection;

        public PrivateCloudClusterCollectionTest(bool isAsync) : base(isAsync)
        {
        }

        protected async Task<AvsPrivateCloudClusterCollection> GetPrivateCloudClusterCollectionAsync()
        {
            var privateCloudResource = await getAvsPrivateCloudResource();
            var clusters = privateCloudResource.GetAvsPrivateCloudClusters();
            return clusters;
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetPrivateCloudClusterCollectionAsync();
            AvsPrivateCloudClusterResource result = await collection.GetAsync(CLUSTER1_NAME);
            Assert.AreEqual(result.Data.Name, CLUSTER1_NAME);
        }

        [TestCase]
        [RecordedTest]
        [AsyncOnly]
        public async Task CreateOrUpdate()
        {
            var collection = await GetPrivateCloudClusterCollectionAsync();
            AvsPrivateCloudClusterData data = new AvsPrivateCloudClusterData(new AvsSku("AV36"))
            {
                ClusterSize = 3,
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Started, CLUSTER2_NAME, data);
        }
    }
}
