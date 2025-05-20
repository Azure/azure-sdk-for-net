// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StandbyPool.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    public class StandbyContainerGroupPoolCRUDTests : StandbyContainerGroupPoolTestBase
    {
        public StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties;

        public StandbyContainerGroupPoolCRUDTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StandbyContainerGroupPoolCRUDTest()
        {
            // Setup - Initialize testProperties
            standbyContainerGroupPoolTestProperties = await InitializeStandbyContainerGroupPoolTestProperties();

            // Create
            StandbyContainerGroupPoolResource standbyContainerGroupPoolResource = await CreateStandbyContainerGroupPoolResourceAndVerify(standbyContainerGroupPoolTestProperties);

            // Get
            await GetStandbyContainerGroupPoolResourceAndVerify(standbyContainerGroupPoolResource, standbyContainerGroupPoolTestProperties);

            // GetRuntimeView
            await GetStandbyVirtualMachineRuntimeViewAndVerify(standbyContainerGroupPoolTestProperties);

            // Update - Increase MaxReadyCapacity
            await UpdateStandbyContainerGroupPoolResourceAndVerify(standbyContainerGroupPoolResource, maxReadyCapacity: 0, standbyContainerGroupPoolTestProperties);

            // Delete
            await standbyContainerGroupPoolResource.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<StandbyContainerGroupPoolResource> CreateStandbyContainerGroupPoolResourceAndVerify(StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties)
        {
            StandbyContainerGroupPoolResource standbyContainerGroupPoolResource =
                await this.CreateContainerGroupPoolResource(standbyContainerGroupPoolTestProperties.ResourceGroup,
                standbyContainerGroupPoolTestProperties.StandbyPoolName,
                standbyContainerGroupPoolTestProperties.MaxReadyCapacity,
                location,
                standbyContainerGroupPoolTestProperties.ContainerGroupProfile,
                standbyContainerGroupPoolTestProperties.SubnetId);

            VerifyStandbyContainerGroupPool(standbyContainerGroupPoolTestProperties, standbyContainerGroupPoolResource);
            return standbyContainerGroupPoolResource;
        }

        private async Task GetStandbyContainerGroupPoolResourceAndVerify(StandbyContainerGroupPoolResource standbyContainerGroupPoolResource, StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties)
        {
            standbyContainerGroupPoolTestProperties.Id = standbyContainerGroupPoolResource.Id;
            VerifyStandbyContainerGroupPool(standbyContainerGroupPoolTestProperties, await standbyContainerGroupPoolResource.GetAsync());
        }

        private async Task GetStandbyVirtualMachineRuntimeViewAndVerify(StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties, string runtimeViewName = "latest")
        {
            StandbyContainerGroupPoolRuntimeViewResource standbyContainerGroupPool_RUNTIMEVIEW =
                await Client.GetStandbyContainerGroupPoolRuntimeViewResource(standbyContainerGroupPoolTestProperties.StandbyContainerGroupPoolRuntimeViewResourceId).GetAsync();

            Assert.AreEqual(runtimeViewName, standbyContainerGroupPool_RUNTIMEVIEW.Data.Name);
            Assert.IsTrue(standbyContainerGroupPool_RUNTIMEVIEW.Data.Properties.InstanceCountSummary.Count > 0);
            Assert.IsTrue(standbyContainerGroupPool_RUNTIMEVIEW.Data.Properties.InstanceCountSummary[0].StandbyContainerGroupInstanceCountsByState.Count > 0);
            Assert.IsNotNull(standbyContainerGroupPool_RUNTIMEVIEW.Data.Properties.Status);

            // Prediction is not available in the response. This field is only populated for StandbyPools that record scale out activity over a period of time.
            // However, this assertion verifies that the prediction field is available in the response for the StandbyContainerGroupPoolRuntimeViewResource.
            Assert.IsNull(standbyContainerGroupPool_RUNTIMEVIEW.Data.Properties.Prediction);
        }

        private async Task UpdateStandbyContainerGroupPoolResourceAndVerify(StandbyContainerGroupPoolResource standbyContainerGroupPoolResource, long maxReadyCapacity, StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties)
        {
            var standbyContainerGroupPoolResource_UPDATE =
                await standbyContainerGroupPoolResource.UpdateAsync(
                    new StandbyContainerGroupPoolPatch()
                    {
                        Properties = new StandbyContainerGroupPoolUpdateProperties()
                        {
                            ElasticityProfile = new StandbyContainerGroupPoolElasticityProfile()
                            {
                                MaxReadyCapacity = maxReadyCapacity,
                            }
                        }
                    }
                );

            standbyContainerGroupPoolTestProperties.MaxReadyCapacity = maxReadyCapacity;
            VerifyStandbyContainerGroupPool(standbyContainerGroupPoolTestProperties, standbyContainerGroupPoolResource_UPDATE);
        }

        private void VerifyStandbyContainerGroupPool(StandbyContainerGroupPoolTestProperties expected, StandbyContainerGroupPoolResource actual)
        {
            Assert.AreEqual(expected.StandbyPoolName, actual.Data.Name);
            Assert.AreEqual(expected.MaxReadyCapacity, actual.Data.Properties.ElasticityProfile.MaxReadyCapacity);

            if (expected.Id != null)
            {
                Assert.AreEqual(expected.Id, actual.Data.Id);
            }
        }

        private async Task<StandbyContainerGroupPoolTestProperties> InitializeStandbyContainerGroupPoolTestProperties()
        {
            // StandbyPool
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            string standbyPoolName = Recording.GenerateAssetName("standbyCGPool-");
            StandbyContainerGroupPoolTestProperties standbyContainerGroupPoolTestProperties = new StandbyContainerGroupPoolTestProperties();
            standbyContainerGroupPoolTestProperties.StandbyPoolName = standbyPoolName;
            standbyContainerGroupPoolTestProperties.MaxReadyCapacity = 1;
            standbyContainerGroupPoolTestProperties.ResourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);

            // Resources
            GenericResource virtualNetwork = await this.CreateVirtualNetwork(standbyContainerGroupPoolTestProperties.ResourceGroup, _genericResourceCollection, location);
            standbyContainerGroupPoolTestProperties.SubnetId = GetSubnetId(virtualNetwork);
            standbyContainerGroupPoolTestProperties.ContainerGroupProfile = await this.CreateContainerGroupProfile(standbyContainerGroupPoolTestProperties.ResourceGroup, _genericResourceCollection, location);

            // RuntimeView
            standbyContainerGroupPoolTestProperties.StandbyContainerGroupPoolRuntimeViewResourceId = StandbyContainerGroupPoolRuntimeViewResource.CreateResourceIdentifier(subscription.Data.SubscriptionId, resourceGroupName, standbyPoolName, "latest");

            return standbyContainerGroupPoolTestProperties;
        }

        public class StandbyContainerGroupPoolTestProperties
        {
            public long MaxReadyCapacity { get; set; }
            public ResourceIdentifier Id { get; set; }
            public ResourceIdentifier StandbyContainerGroupPoolRuntimeViewResourceId { get; set; }
            public ResourceIdentifier SubnetId { get; set; }
            public string StandbyPoolName { get; set; }
            public ResourceGroupResource ResourceGroup { get; set; }
            public GenericResource ContainerGroupProfile { get; set; }

            public StandbyContainerGroupPoolTestProperties()
            {
            }
        }
    }
}
