// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    [ClientTestFixture]
    public class StandbyContainerGroupPoolCollectionTests : StandbyContainerGroupPoolTestBase
    {
        public StandbyContainerGroupPoolCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        private async Task CreateResources(ResourceGroupResource resourceGroup)
        {
            var vnet = this.CreateVirtualNetwork(resourceGroup, _genericResourceCollection, location);
            ResourceIdentifier subnetId = GetSubnetId(vnet.Result);
            var resource = await this.CreateContainerGroupProfile(resourceGroup, _genericResourceCollection, location);
            string standbyContainerGoupPoolName = Recording.GenerateAssetName("standbyCG-");
            _ = await this.CreateContainerGroupPoolResource(resourceGroup, standbyContainerGoupPoolName, 1, location, resource, subnetId);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListStandbyContainerGroupPoolBySubscription()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            await this.CreateResources(resourceGroup);

            AsyncPageable<StandbyContainerGroupPoolResource> standbyContainerGroupPools = StandbyPoolExtensions.GetStandbyContainerGroupPoolsAsync(subscription);
            List<StandbyContainerGroupPoolResource> standbyContainerGroupPoolResults = await standbyContainerGroupPools.ToEnumerableAsync();

            Assert.NotNull(standbyContainerGroupPoolResults);
            Assert.IsTrue(standbyContainerGroupPoolResults.Count > 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListStandbyContainerGroupPoolByResourceGroup()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            await this.CreateResources(resourceGroup);
            await this.CreateResources(resourceGroup);
            List<StandbyContainerGroupPoolResource> standbyContainerGroupPoolCollection = await resourceGroup.GetStandbyContainerGroupPools().ToEnumerableAsync();
            Assert.AreEqual(2, standbyContainerGroupPoolCollection.Count);
        }
    }
}
