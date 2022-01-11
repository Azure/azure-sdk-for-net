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
            var collection = await GetVirtualMachineCollectionAsync();
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(vmName, input);
            return lro.Value;
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
        public async Task Get()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            VirtualMachine vm2 = await vm.GetAsync();

            ResourceDataHelper.AssertVirtualMachine(vm.Data, vm2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var vmName = Recording.GenerateAssetName("testVM-");
            var vm = await CreateVirtualMachineAsync(vmName);
            //// Create a PPG here and add this PPG to this virtual machine using Update
            //var ppgName = Recording.GenerateAssetName("testPPG-");
            //var ppgData = new ProximityPlacementGroupData(DefaultLocation) { };
            //var ppgLRO = await _resourceGroup.GetProximityPlacementGroups().CreateOrUpdateAsync(ppgName, ppgData);
            //var ppg = ppgLRO.Value;
            // update PPG requires the VM to be deallocated
            await vm.DeallocateAsync();
            var update = new VirtualMachineUpdate()
            {
                HardwareProfile = new HardwareProfile
                {
                    VmSize = VirtualMachineSizeTypes.StandardF1
                }
            };
            var lro = await vm.UpdateAsync(update);
            VirtualMachine updatedVM = lro.Value;

            Assert.AreEqual(VirtualMachineSizeTypes.StandardF1, updatedVM.Data.HardwareProfile.VmSize);
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
