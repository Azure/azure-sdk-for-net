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
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24576")]
    public class VirtualMachineScaleSetOperationsTests : VirtualMachineScaleSetTestBase
    {
        public VirtualMachineScaleSetOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<VirtualMachineScaleSet> CreateVirtualMachineScaleSetAsync(string vmssName)
        {
            var container = await GetVirtualMachineScaleSetContainerAsync();
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));
            var lro = await container.CreateOrUpdateAsync(vmssName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            await vmss.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            VirtualMachineScaleSet vmss2 = await vmss.GetAsync();

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
            var ppgLro = await _resourceGroup.GetProximityPlacementGroups().CreateOrUpdateAsync(ppgName, ppgData);
            ProximityPlacementGroup ppg = ppgLro.Value;
            // update PPG requires the VM to be deallocated
            await vmss.DeallocateAsync();
            var update = new VirtualMachineScaleSetUpdate()
            {
                ProximityPlacementGroup = new WritableSubResource()
                {
                    Id = ppg.Id
                }
            };
            var lro = await vmss.UpdateAsync(update);
            VirtualMachineScaleSet updatedVM = lro.Value;

            Assert.AreEqual(ppg.Id, updatedVM.Data.ProximityPlacementGroup.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task PowerOff()
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vmss = await CreateVirtualMachineScaleSetAsync(vmssName);
            await vmss.PowerOffAsync();
        }
    }
}
