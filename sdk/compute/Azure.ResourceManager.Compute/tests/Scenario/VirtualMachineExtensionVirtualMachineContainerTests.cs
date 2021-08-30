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
            : base(async)// , RecordedTestMode.Record)
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
            var lroVirtualMachine = await container.CreateOrUpdateAsync(vmName, input);
            VirtualMachine virtualMachine = lroVirtualMachine.Value;
            return virtualMachine.GetVirtualMachineExtensionVirtualMachines();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var lroVirtualMachine = await container.CreateOrUpdateAsync(vmeName, BasicVirtualMachineExtensionData);
            VirtualMachineExtensionVirtualMachine virtualMachine = lroVirtualMachine.Value;
            Assert.AreEqual(vmeName, virtualMachine.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
            var lroVme1 = await container.CreateOrUpdateAsync(vmeName, input);
            VirtualMachineExtensionVirtualMachine vme1 = lroVme1.Value;
            VirtualMachineExtensionVirtualMachine vme2 = await container.GetAsync(vmeName);

            ResourceDataHelper.AssertVirtualMachineExtention(vme1.Data, vme2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineExtensionData(DefaultLocation);
            var  lroVme = await container.CreateOrUpdateAsync(vmeName, input);
            VirtualMachineExtensionVirtualMachine vme = lroVme.Value;
            Assert.IsTrue(await container.CheckIfExistsAsync(vmeName));
            Assert.IsFalse(await container.CheckIfExistsAsync(vmeName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetVirtualMachineExtensionVirtualMachineContainerAsync();
            var vmeName = Recording.GenerateAssetName("testVME-");
            var input = BasicVirtualMachineExtensionData;
            _ = await container.CreateOrUpdateAsync(vmeName, input);
            _ = await container.CreateOrUpdateAsync(vmeName, input);
            int count = 0;
            foreach (var vme in (await container.GetAllAsync()).Value)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
