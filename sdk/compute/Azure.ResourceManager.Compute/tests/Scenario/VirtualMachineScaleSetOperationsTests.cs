// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2022-08-01", "2021-04-01", "2020-06-01", "2022-11-01", "2023-03-01", "2023-07-01", "2023-09-01")]
    public class VirtualMachineScaleSetOperationsTests : VirtualMachineScaleSetTestBase
    {
        public VirtualMachineScaleSetOperationsTests(bool isAsync, string apiVersion)
            : base(isAsync, VirtualMachineScaleSetResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        private async Task<VirtualMachineScaleSetResource> CreateVirtualMachineScaleSetAsync(string vmssName)
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmssName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            await vmss.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            VirtualMachineScaleSetResource vmss2 = await vmss.GetAsync();

            ResourceDataHelper.AssertVirtualMachineScaleSet(vmss.Data, vmss2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            // Create a PPG here and add this PPG to this virtual machine using Update
            var ppgName = Recording.GenerateAssetName("testPPG-");
            var ppgData = new ProximityPlacementGroupData(DefaultLocation) { };
            var ppgLro = await _resourceGroup.GetProximityPlacementGroups().CreateOrUpdateAsync(WaitUntil.Completed, ppgName, ppgData);
            ProximityPlacementGroupResource ppg = ppgLro.Value;
            // update PPG requires the VM to be deallocated
            await vmss.DeallocateAsync(WaitUntil.Completed);
            var update = new VirtualMachineScaleSetPatch()
            {
                ProximityPlacementGroup = new WritableSubResource()
                {
                    Id = ppg.Id
                }
            };
            var lro = await vmss.UpdateAsync(WaitUntil.Completed, update);
            VirtualMachineScaleSetResource updatedVM = lro.Value;

            Assert.AreEqual(ppg.Id, updatedVM.Data.ProximityPlacementGroup.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task PowerOff()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            await vmss.PowerOffAsync(WaitUntil.Completed);
        }
    }
}
