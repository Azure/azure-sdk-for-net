// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    [ClientTestFixture]
    public class StandbyVirtualMachinePoolCollectionTests : StandbyVirtualMachinePoolTestBase
    {
        public StandbyVirtualMachinePoolCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        private async Task CreateResources(ResourceGroupResource resourceGroup)
        {
            string standbyPoolName = Recording.GenerateAssetName("standbyVM-");
            var createVirtualMachineScaleSet = this.CreateDependencyResourcs(resourceGroup, _genericResourceCollection, location);
            _ = await this.CreateStandbyVirtualMachinePoolResource(resourceGroup, standbyPoolName, 11, location, createVirtualMachineScaleSet.Result.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListStandbyVirtualMachinePoolBySubscription()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            await this.CreateResources(resourceGroup);

            AsyncPageable<StandbyVirtualMachinePoolResource> standbyVirtualMachinePools = StandbyPoolExtensions.GetStandbyVirtualMachinePoolsAsync(subscription);
            List<StandbyVirtualMachinePoolResource> standbyVirtualMachinePoolResults = await standbyVirtualMachinePools.ToEnumerableAsync();

            Assert.NotNull(standbyVirtualMachinePoolResults);
            Assert.IsTrue(standbyVirtualMachinePoolResults.Count > 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListStandbyVirtualMachinePoolByResourcGroup()
        {
            string resourceGroupName = Recording.GenerateAssetName("standbyPoolRG-");
            ResourceGroupResource resourceGroup = await CreateResourceGroup(subscription, resourceGroupName, location);
            await this.CreateResources(resourceGroup);
            await this.CreateResources(resourceGroup);
            List<StandbyVirtualMachinePoolResource> standbyVirtualMachinePoolCollection = await resourceGroup.GetStandbyVirtualMachinePools().ToEnumerableAsync();
            Assert.AreEqual(2, standbyVirtualMachinePoolCollection.Count);
        }
    }
}
