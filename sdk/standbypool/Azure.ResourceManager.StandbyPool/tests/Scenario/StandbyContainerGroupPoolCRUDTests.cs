// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    public class StandbyContainerGroupPoolCRUDTests : StandbyContainerGroupPoolTestBase
    {
        public StandbyContainerGroupPoolCRUDTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StandbyContainerGroupPoolCRUDTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            string runtimeView = "latest";
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            var vnet = this.CreateVirtualNetwork(resourceGroup, _genericResourceCollection, location);
            ResourceIdentifier subnetId = GetSubnetId(vnet.Result);
            var resource = await this.CreateContainerGroupProfile(resourceGroup, _genericResourceCollection, location);

            // Create
            string standbyContainerGoupPoolName = Recording.GenerateAssetName("standbyCG-");
            StandbyContainerGroupPoolResource standbyContainerGroupPoolResource = await this.CreateContainerGroupPoolResource(resourceGroup, standbyContainerGoupPoolName, 1, location, resource, subnetId);
            Assert.AreEqual(standbyContainerGoupPoolName, standbyContainerGroupPoolResource.Data.Name);

            // Get
            StandbyContainerGroupPoolResource standbyContainerGroupPoolResource1 = await standbyContainerGroupPoolResource.GetAsync();
            Assert.AreEqual(standbyContainerGroupPoolResource.Id, standbyContainerGroupPoolResource1.Id);

            // runtimeview
            ResourceIdentifier standbyContainerGroupPoolRuntimeViewResourceId = StandbyContainerGroupPoolRuntimeViewResource.CreateResourceIdentifier(subscription.Data.SubscriptionId, resourceGroupName, standbyContainerGoupPoolName, runtimeView);
            StandbyContainerGroupPoolRuntimeViewResource standbyContainerGroupPoolRuntimeViewResource = Client.GetStandbyContainerGroupPoolRuntimeViewResource(standbyContainerGroupPoolRuntimeViewResourceId);
            // invoke the operation
            StandbyContainerGroupPoolRuntimeViewResource result = await standbyContainerGroupPoolRuntimeViewResource.GetAsync();
            Assert.AreEqual(runtimeView, result.Data.Name);
            Assert.IsTrue(result.Data.Properties.InstanceCountSummary.Count > 0);
            Assert.IsTrue(result.Data.Properties.InstanceCountSummary[0].InstanceCountsByState.Count > 0);

            // Delete
            await standbyContainerGroupPoolResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
