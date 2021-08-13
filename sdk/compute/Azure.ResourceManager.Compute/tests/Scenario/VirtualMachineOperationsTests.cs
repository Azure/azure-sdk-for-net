// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineOperationsTests : VirtualMachineTestBase
    {
        public VirtualMachineOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<VirtualMachine> CreateVirtualMachineAsync(string vmName)
        {
            var container = await GetVirtualMachineContainerAsync();
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            return await container.CreateOrUpdateAsync(vmName, input);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            await vm.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            var deleteOp = await vm.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            VirtualMachine vm2 = await vm.GetAsync();

            ResourceDataHelper.AssertVirtualMachine(vm.Data, vm2.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("There is a bug in OperationInternals causing we cannot handle this kind of PATCH LRO right now")]
        public async Task Update()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            // Create a PPG here and add this PPG to this virtual machine using Update
            var ppgName = Recording.GenerateAssetName("testPPG-");
            var ppgData = new ProximityPlacementGroupData(DefaultLocation) { };
            ProximityPlacementGroup ppg = await _resourceGroup.GetProximityPlacementGroups().CreateOrUpdateAsync(ppgName, ppgData);
            // update PPG requires the VM to be deallocated
            await vm.DeallocateAsync();
            var update = new VirtualMachineUpdate()
            {
                ProximityPlacementGroup = new SubResource()
                {
                    Id = ppg.Id
                }
            };
            VirtualMachine updatedVM = await vm.UpdateAsync(update);

            Assert.AreEqual(ppg.Id, updatedVM.Data.ProximityPlacementGroup.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task PowerOff()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            await vm.PowerOffAsync();
        }
    }
}
