// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StandbyPool.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    [ClientTestFixture]
    public class StandbyVirtualMachinePoolCRUDTests : StandbyVirtualMachinePoolTestBase
    {
        protected long originalMaxReadyCapacity = 2;
        protected long increasedMaxReadyCapacity = 3;

        public StandbyVirtualMachinePoolCRUDTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StandbyVirtualMachinePoolCRUDTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            string standbyPoolName = Recording.GenerateAssetName("standbyVM-");
            var createVirtualMachineScaleSet = this.CreateDependencyResourcs(resourceGroup, _genericResourceCollection, location);
            // Create
            var standbyVirtualMachinePool = await this.CreateStandbyVirtualMachinePoolResource(resourceGroup, standbyPoolName, originalMaxReadyCapacity, location,  createVirtualMachineScaleSet.Result.Id);
            Assert.AreEqual(standbyPoolName, standbyVirtualMachinePool.Data.Name);

            // Get
            var standbyVirtualMachinePool2 = await standbyVirtualMachinePool.GetAsync();
            Assert.AreEqual(standbyVirtualMachinePool.Id, standbyVirtualMachinePool2.Value.Id);

            // Update
            var standbyVirtualMachinePoolUpdate =
                await standbyVirtualMachinePool.UpdateAsync(new StandbyVirtualMachinePoolPatch() { ElasticityMaxReadyCapacity = increasedMaxReadyCapacity });
            Assert.AreEqual(increasedMaxReadyCapacity, standbyVirtualMachinePoolUpdate.Value.Data.ElasticityMaxReadyCapacity);
            Assert.AreEqual(standbyPoolName, standbyVirtualMachinePool.Data.Name);

            // Delete
            await standbyVirtualMachinePool.DeleteAsync(WaitUntil.Completed);
        }
    }
}
