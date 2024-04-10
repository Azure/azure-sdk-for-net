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
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StandbyContainerGroupPoolCRUDTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
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

            // Delete
            await standbyContainerGroupPoolResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
