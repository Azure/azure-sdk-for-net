// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests
{
    public class PrivateCloudCollectionTest : AvsManagementTestBase
    {
        protected ResourceGroupResource _resourceGroup;
        protected AvsPrivateCloudCollection avsPrivateCloudCollection;

        public PrivateCloudCollectionTest(bool isAsync) : base(isAsync)
        {
        }

        protected async  Task<AvsPrivateCloudCollection> GetPrivateCloudCollectionAsync()
        {
            _resourceGroup = await DefaultSubscription.GetResourceGroupAsync("avs-sdk-test");
            return _resourceGroup.GetAvsPrivateClouds();
        }

      //  [TestCase]
      //  [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await  GetPrivateCloudCollectionAsync();
            string privateCloudName = Recording.GenerateAssetName("avs-sdk-test-");
            AvsPrivateCloudData data = new AvsPrivateCloudData(DefaultLocation, new AvsSku("AV36"))
            {
                ManagementCluster = new AvsManagementCluster()
                {
                    ClusterSize = 3,
                },
                Availability = new PrivateCloudAvailabilityProperties()
                {
                    Strategy = AvailabilityStrategy.SingleZone,
                    Zone = 1,
                    SecondaryZone = 2,
                },
                NetworkBlock = "192.168.48.0/22",
                Tags =
                        {
                        },
            };

            ArmOperation<AvsPrivateCloudResource> lro = await  collection.CreateOrUpdateAsync(WaitUntil.Started, privateCloudName, data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateStretched()
        {
            var collection = await GetPrivateCloudCollectionAsync();
            string privateCloudName = Recording.GenerateAssetName("avs-sdk-test-stretched-");
            AvsPrivateCloudData data = new AvsPrivateCloudData(DefaultLocation, new AvsSku("AV36"))
            {
                ManagementCluster = new AvsManagementCluster()
                {
                    ClusterSize = 6,
                },
                Availability = new PrivateCloudAvailabilityProperties()
                {
                    Strategy = AvailabilityStrategy.DualZone,
                    Zone = 1,
                    SecondaryZone = 2,
                },
                NetworkBlock = "192.168.48.0/22",
                Tags =
                        {
                        },
            };

            ArmOperation<AvsPrivateCloudResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Started, privateCloudName, data);
            Assert.Equals(lro.Value.Data.Name, privateCloudName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetPrivateCloudCollectionAsync();
            AvsPrivateCloudResource result = await collection.GetAsync("avs-sdk-test");
            Assert.AreEqual(result.Data.Name, "avs-sdk-test");
        }
    }
}
