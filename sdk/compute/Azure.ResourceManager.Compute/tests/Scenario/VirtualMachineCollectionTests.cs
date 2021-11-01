// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineCollectionTests : VirtualMachineTestBase
    {
        public VirtualMachineCollectionTests(bool async)
            : base(async)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(vmName, input);
            VirtualMachine virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(vmName, input);
            VirtualMachine vm1 = lro.Value;
            VirtualMachine vm2 = await collection.GetAsync(vmName);

            ResourceDataHelper.AssertVirtualMachine(vm1.Data, vm2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(vmName, input);
            VirtualMachine vm = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(vmName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(vmName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName1 = Recording.GenerateAssetName("testVM-");
            var vmName2 = Recording.GenerateAssetName("testVM-");
            var nic1 = await CreateBasicDependenciesOfVirtualMachineAsync();
            var nic2 = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input1 = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName1, nic1.Id);
            var input2 = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName2, nic2.Id);
            _ = await collection.CreateOrUpdateAsync(vmName1, input1);
            _ = await collection.CreateOrUpdateAsync(vmName2, input2);
            int count = 0;
            await foreach (var vm in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName1 = Recording.GenerateAssetName("testVM-");
            var vmName2 = Recording.GenerateAssetName("testVM-");
            var nic1 = await CreateBasicDependenciesOfVirtualMachineAsync();
            var nic2 = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input1 = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName1, nic1.Id);
            var input2 = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName2, nic2.Id);
            _ = await collection.CreateOrUpdateAsync(vmName1, input1);
            _ = await collection.CreateOrUpdateAsync(vmName2, input2);

            VirtualMachine vm1 = null, vm2 = null;
            await foreach (var vm in DefaultSubscription.GetVirtualMachinesAsync())
            {
                if (vm.Data.Name == vmName1)
                    vm1 = vm;
                if (vm.Data.Name == vmName2)
                    vm2 = vm;
            }

            Assert.NotNull(vm1);
            Assert.NotNull(vm2);
        }
    }
}
