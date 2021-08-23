// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineExtensionVirtualMachineContainerTests : VirtualMachineTestBase
    {
        public VirtualMachineExtensionVirtualMachineContainerTests(bool async)
            : base(async , RecordedTestMode.Record)
        {
        }

        private VirtualMachineExtensionData BasicVirtualMachineExtensionData
        {
           get
           {
                return ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
           }
        }

        private async Task<VirtualMachineExtensionVirtualMachineContainer> GetVirtualMachineExtensionVirtualMachineContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var Iro_virtualMachine = await container.CreateOrUpdateAsync(vmName, input);
            VirtualMachine virtualMachine = Iro_virtualMachine.Value;
            return virtualMachine.GetVirtualMachineExtensionVirtualMachines();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var Iro_virtualMachine = await container.CreateOrUpdateAsync(vmeName, BasicVirtualMachineExtensionData);
            VirtualMachineExtensionVirtualMachine virtualMachine = Iro_virtualMachine.Value;
            Assert.AreEqual(vmeName, virtualMachine.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
            var Iro_vme1 = await container.CreateOrUpdateAsync(vmeName, input);
            VirtualMachineExtensionVirtualMachine vme1 = Iro_vme1.Value;
            VirtualMachineExtensionVirtualMachine vme2 = await container.GetAsync(vmeName);

            ResourceDataHelper.AssertVirtualMachineEXtention(vme1.Data, vme2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
            var  Iro_vme = await container.CreateOrUpdateAsync(vmeName, input);
            VirtualMachineExtensionVirtualMachine vme = Iro_vme.Value;
            Assert.IsTrue(await container.CheckIfExistsAsync(vmeName));
            Assert.IsFalse(await container.CheckIfExistsAsync(vmeName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName1 = Recording.GenerateAssetName("testVME-");
            var vmeName2 = Recording.GenerateAssetName("testVME-");
            var input1 = BasicVirtualMachineExtensionData;
            var input2 = BasicVirtualMachineExtensionData;
            _ = await container.CreateOrUpdateAsync(vmeName1, input1);
            _ = await container.CreateOrUpdateAsync(vmeName2, input2);
            int count = 0;
            foreach (var vme in (await container.GetAllAsync()).Value)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
