// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
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
        public StandbyVirtualMachinePoolTestProperties standbyVirtualMachinePoolTestProperties;

        public StandbyVirtualMachinePoolCRUDTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StandbyVirtualMachinePoolCRUDTest()
        {
            // Setup - Initialize testProperties
            standbyVirtualMachinePoolTestProperties = await InitializeStandbyVirtualMachinePoolTestProperties();

            // Create
            StandbyVirtualMachinePoolResource standbyVirtualMachinePool_CREATE = await CreateStandbyVirtualMachineStateAndVerify(standbyVirtualMachinePoolTestProperties);

            // Get
            await GetStandbyVirtualMachineStateAndVerify(standbyVirtualMachinePool_CREATE, standbyVirtualMachinePoolTestProperties);

            // GetRuntimeView
            await GetStandbyVirtualMachineRuntimeViewAndVerify(standbyVirtualMachinePoolTestProperties);

            // Update - Hibernated
            await UpdateStandbyVirtualMachineStateAndVerify(standbyVirtualMachinePool_CREATE, StandbyVirtualMachineState.Hibernated, standbyVirtualMachinePoolTestProperties);

            // Update - Deallocated
            await UpdateStandbyVirtualMachineStateAndVerify(standbyVirtualMachinePool_CREATE, StandbyVirtualMachineState.Deallocated, standbyVirtualMachinePoolTestProperties);

            // Delete
            await standbyVirtualMachinePool_CREATE.DeleteAsync(WaitUntil.Completed);
        }

        private void VerifyStandbyVirtualMachinePool(StandbyVirtualMachinePoolTestProperties expected, StandbyVirtualMachinePoolResource actual)
        {
            Assert.AreEqual(expected.StandbyPoolName, actual.Data.Name);
            Assert.AreEqual(expected.MaxReadyCapacity, actual.Data.Properties.ElasticityProfile.MaxReadyCapacity);
            Assert.AreEqual(expected.MinReadyCapacity, actual.Data.Properties.ElasticityProfile.MinReadyCapacity);
            Assert.AreEqual(expected.AttachedVirtualMachineScaleSetId, actual.Data.Properties.AttachedVirtualMachineScaleSetId);

            if (expected.Id != null)
            {
                Assert.AreEqual(expected.Id, actual.Data.Id);
            }

            Assert.AreEqual(expected.StandbyVirtualMachineState, actual.Data.Properties.VirtualMachineState);
        }

        private async Task GetStandbyVirtualMachineRuntimeViewAndVerify(StandbyVirtualMachinePoolTestProperties expectedStandbyVirtualMachinePoolTestProperties, string runtimeViewName = "latest")
        {
            StandbyVirtualMachinePoolRuntimeViewResource standbyVirtualMachinePool_RUNTIMEVIEW =
                await Client.GetStandbyVirtualMachinePoolRuntimeViewResource(expectedStandbyVirtualMachinePoolTestProperties.StandbyVirtualMachinePoolRuntimeViewResourceId).GetAsync();

            Assert.AreEqual(runtimeViewName, standbyVirtualMachinePool_RUNTIMEVIEW.Data.Name);
            Assert.IsTrue(standbyVirtualMachinePool_RUNTIMEVIEW.Data.Properties.InstanceCountSummary.Count > 0);
            Assert.IsTrue(standbyVirtualMachinePool_RUNTIMEVIEW.Data.Properties.InstanceCountSummary[0].StandbyVirtualMachineInstanceCountsByState.Count > 0);
            Assert.IsNotNull(standbyVirtualMachinePool_RUNTIMEVIEW.Data.Properties.Status);

            // Prediction is not available in the response. This field is only populated for StandbyPools that record scale out activity over a period of time.
            // However, this assertion verifies that the prediction field is available in the response for the StandbyVirtualMachinePoolRuntimeViewResource.
            Assert.IsNull(standbyVirtualMachinePool_RUNTIMEVIEW.Data.Properties.Prediction);
        }

        private async Task<StandbyVirtualMachinePoolResource> CreateStandbyVirtualMachineStateAndVerify(StandbyVirtualMachinePoolTestProperties standbyVirtualMachinePoolResourceProperties)
        {
            var standbyVirtualMachinePool_CREATE = await this.CreateStandbyVirtualMachinePoolResource(
                resourceGroup: standbyVirtualMachinePoolResourceProperties.ResourceGroup,
                standbyVirtualMachinePoolName: standbyVirtualMachinePoolResourceProperties.StandbyPoolName,
                maxReadyCapacity: standbyVirtualMachinePoolResourceProperties.MaxReadyCapacity,
                location: location,
                vmssId: standbyVirtualMachinePoolResourceProperties.AttachedVirtualMachineScaleSetId,
                minReadyCapacity: standbyVirtualMachinePoolResourceProperties.MinReadyCapacity,
                virtualMachineState: standbyVirtualMachinePoolResourceProperties.StandbyVirtualMachineState.ToString());

            VerifyStandbyVirtualMachinePool(standbyVirtualMachinePoolResourceProperties, standbyVirtualMachinePool_CREATE);

            return standbyVirtualMachinePool_CREATE;
        }

        private async Task UpdateStandbyVirtualMachineStateAndVerify(StandbyVirtualMachinePoolResource standbyVirtualMachinePool, StandbyVirtualMachineState standbyVirtualMachineState, StandbyVirtualMachinePoolTestProperties expectedStandbyVirtualMachinePoolResourceProperties)
        {
            var standbyVirtualMachinePool_UPDATE =
                await standbyVirtualMachinePool.UpdateAsync(
                    new StandbyVirtualMachinePoolPatch()
                    {
                        Properties = new StandbyVirtualMachinePoolUpdateProperties()
                        {
                            VirtualMachineState = standbyVirtualMachineState,
                        }
                    }
                );

            expectedStandbyVirtualMachinePoolResourceProperties.StandbyVirtualMachineState = standbyVirtualMachineState;
            VerifyStandbyVirtualMachinePool(expectedStandbyVirtualMachinePoolResourceProperties, standbyVirtualMachinePool_UPDATE);
        }

        private async Task GetStandbyVirtualMachineStateAndVerify(StandbyVirtualMachinePoolResource standbyVirtualMachinePool, StandbyVirtualMachinePoolTestProperties expectedStandbyVirtualMachinePoolResourceProperties)
        {
            expectedStandbyVirtualMachinePoolResourceProperties.Id = standbyVirtualMachinePool.Id;
            VerifyStandbyVirtualMachinePool(expectedStandbyVirtualMachinePoolResourceProperties, await standbyVirtualMachinePool.GetAsync());
        }

        private async Task<StandbyVirtualMachinePoolTestProperties> InitializeStandbyVirtualMachinePoolTestProperties()
        {
            // StandbyPool
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            string standbyPoolName = Recording.GenerateAssetName("standbyVMPool-");
            StandbyVirtualMachinePoolTestProperties standbyVirtualMachinePoolResourceProperties = new StandbyVirtualMachinePoolTestProperties();
            standbyVirtualMachinePoolResourceProperties.StandbyPoolName = standbyPoolName;
            standbyVirtualMachinePoolResourceProperties.MaxReadyCapacity = 2;
            standbyVirtualMachinePoolResourceProperties.MinReadyCapacity = 2;
            standbyVirtualMachinePoolResourceProperties.StandbyVirtualMachineState = StandbyVirtualMachineState.Running;
            standbyVirtualMachinePoolResourceProperties.ResourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);

            // Virtual Machine Scale Set
            Compute.VirtualMachineScaleSetResource virtualMachineScaleSet = await this.CreateDependencyResourcs(standbyVirtualMachinePoolResourceProperties.ResourceGroup, _genericResourceCollection, location);
            standbyVirtualMachinePoolResourceProperties.AttachedVirtualMachineScaleSetId = virtualMachineScaleSet.Id;

            // RuntimeView
            standbyVirtualMachinePoolResourceProperties.StandbyVirtualMachinePoolRuntimeViewResourceId = StandbyVirtualMachinePoolRuntimeViewResource.CreateResourceIdentifier(subscription.Data.SubscriptionId, resourceGroupName, standbyPoolName, "latest");

            return standbyVirtualMachinePoolResourceProperties;
        }

        public class StandbyVirtualMachinePoolTestProperties
        {
            public long MaxReadyCapacity { get; set; }
            public long MinReadyCapacity { get; set; }
            public ResourceIdentifier Id { get; set; }
            public ResourceIdentifier AttachedVirtualMachineScaleSetId { get; set; }
            public ResourceIdentifier StandbyVirtualMachinePoolRuntimeViewResourceId { get; set; }
            public StandbyVirtualMachineState StandbyVirtualMachineState { get; set; }
            public string StandbyPoolName { get; set; }
            public ResourceGroupResource ResourceGroup { get; set; }

            public StandbyVirtualMachinePoolTestProperties()
            {
            }
        }
    }
}
