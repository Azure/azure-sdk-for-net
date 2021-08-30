// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineExtensionVirtualMachineOperationsTests : VirtualMachineTestBase
    {
        public VirtualMachineExtensionVirtualMachineOperationsTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<VirtualMachineExtensionVirtualMachine> CreateVirtualMachineExtensionAsync(string vmeName)
        {
            var container = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVirtualMachine = await container.CreateOrUpdateAsync(vmName, input);
            VirtualMachine virtualMachine = lroVirtualMachine.Value;
            var vmeContainer = virtualMachine.GetVirtualMachineExtensionVirtualMachines();
            var vmeInput = ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
            var lroVme1 = await vmeContainer.CreateOrUpdateAsync(vmeName, vmeInput);
            VirtualMachineExtensionVirtualMachine vme = lroVme1.Value;
            return vme;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var vmeName = Recording.GenerateAssetName("testVME-");
            var vme = await CreateVirtualMachineExtensionAsync(vmeName);
            await vme.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmeName = Recording.GenerateAssetName("testVME-");
            var vme = await CreateVirtualMachineExtensionAsync(vmeName);
            VirtualMachineExtensionVirtualMachine vme2 = await vme.GetAsync();

            ResourceDataHelper.AssertVirtualMachineExtention(vme.Data, vme2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var vmeName = Recording.GenerateAssetName("testVME-");
            var vme = await CreateVirtualMachineExtensionAsync(vmeName);
            var forceUpdateTag = "git";
            var update = new VirtualMachineExtensionUpdate()
            {
                ForceUpdateTag = forceUpdateTag
            };
            var lro = await vme.UpdateAsync(update);
            VirtualMachineExtensionVirtualMachine updatedVME = lro.Value;

            Assert.AreEqual(forceUpdateTag, updatedVME.Data.ForceUpdateTag);
        }
    }
}
