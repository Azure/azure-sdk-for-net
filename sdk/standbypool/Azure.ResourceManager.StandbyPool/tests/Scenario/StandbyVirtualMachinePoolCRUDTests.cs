// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StandbyPool.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    [ClientTestFixture]
    public class StandbyVirtualMachinePoolCRUDTests : StandbyVirtualMachinePoolTestBase
    {
        protected long originalMaxReadyCapacity = 2;
        protected long originalMinReadyCapacity = 2;
        protected long increasedMaxReadyCapacity = 3;
        protected StandbyVirtualMachineState vmState = StandbyVirtualMachineState.Running;

        public StandbyVirtualMachinePoolCRUDTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
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
            string runtimeView = "latest";
            // Create
            var standbyVirtualMachinePool = await this.CreateStandbyVirtualMachinePoolResource(
                resourceGroup: resourceGroup,
                standbyVirtualMachinePoolName: standbyPoolName,
                maxReadyCapacity: originalMaxReadyCapacity,
                location: location,
                vmssId: createVirtualMachineScaleSet.Result.Id,
                minReadyCapacity: originalMinReadyCapacity,
                virtualMachineState: vmState.ToString());

            Assert.AreEqual(standbyPoolName, standbyVirtualMachinePool.Data.Name);
            Assert.AreEqual(originalMaxReadyCapacity, standbyVirtualMachinePool.Data.Properties.ElasticityProfile.MaxReadyCapacity);
            Assert.AreEqual(originalMinReadyCapacity, standbyVirtualMachinePool.Data.Properties.ElasticityProfile.MinReadyCapacity);

            // Get
            var standbyVirtualMachinePool2 = await standbyVirtualMachinePool.GetAsync();
            Assert.AreEqual(standbyVirtualMachinePool.Id, standbyVirtualMachinePool2.Value.Id);
            Assert.AreEqual(originalMaxReadyCapacity, standbyVirtualMachinePool.Data.Properties.ElasticityProfile.MaxReadyCapacity);
            Assert.AreEqual(originalMinReadyCapacity, standbyVirtualMachinePool.Data.Properties.ElasticityProfile.MinReadyCapacity);
            Assert.AreEqual(createVirtualMachineScaleSet.Result.Id, standbyVirtualMachinePool.Data.Properties.AttachedVirtualMachineScaleSetId);
            Assert.AreEqual(vmState, standbyVirtualMachinePool.Data.Properties.VirtualMachineState);

            // GetRunTimeview
            ResourceIdentifier standbyVirtualMachinePoolRuntimeViewResourceId = StandbyVirtualMachinePoolRuntimeViewResource.CreateResourceIdentifier(subscription.Data.SubscriptionId, resourceGroupName, standbyPoolName, runtimeView);

            StandbyVirtualMachinePoolRuntimeViewResource standbyVirtualMachinePoolRuntimeViewResource = Client.GetStandbyVirtualMachinePoolRuntimeViewResource(standbyVirtualMachinePoolRuntimeViewResourceId);

            // invoke the operation
            StandbyVirtualMachinePoolRuntimeViewResource result = await standbyVirtualMachinePoolRuntimeViewResource.GetAsync();
            Assert.AreEqual(runtimeView, result.Data.Name);
            Assert.IsTrue(result.Data.Properties.InstanceCountSummary.Count > 0);
            Assert.IsTrue(result.Data.Properties.InstanceCountSummary[0].InstanceCountsByState.Count > 0);

            // Update
            var standbyVirtualMachinePoolUpdate =
                await standbyVirtualMachinePool.UpdateAsync(new StandbyVirtualMachinePoolPatch() { Properties = new StandbyVirtualMachinePoolUpdateProperties() { ElasticityProfile = new StandbyVirtualMachinePoolElasticityProfile() { MaxReadyCapacity = increasedMaxReadyCapacity } } });
            Assert.AreEqual(increasedMaxReadyCapacity, standbyVirtualMachinePoolUpdate.Value.Data.Properties.ElasticityProfile.MaxReadyCapacity);
            Assert.AreEqual(standbyPoolName, standbyVirtualMachinePool.Data.Name);
            Assert.AreEqual(originalMinReadyCapacity, standbyVirtualMachinePool.Data.Properties.ElasticityProfile.MinReadyCapacity);
            Assert.AreEqual(createVirtualMachineScaleSet.Result.Id, standbyVirtualMachinePool.Data.Properties.AttachedVirtualMachineScaleSetId);
            Assert.AreEqual(vmState, standbyVirtualMachinePool.Data.Properties.VirtualMachineState);

            // Delete
            await standbyVirtualMachinePool.DeleteAsync(WaitUntil.Completed);
        }
    }
}
