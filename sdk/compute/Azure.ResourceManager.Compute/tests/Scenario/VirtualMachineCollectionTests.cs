// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2022-08-01", "2021-04-01", "2020-06-01", "2022-11-01", "2023-03-01", "2023-07-01", "2023-09-01")]
    public class VirtualMachineCollectionTests : VirtualMachineTestBase
    {
        public VirtualMachineCollectionTests(bool async, string apiVersion)
            : base(async, VirtualMachineResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string vmName = Recording.GenerateAssetName("testVM-");
            VirtualMachineResource virtualMachine = await CreateVirtualMachineAsync(vmName);
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
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource vm1 = lro.Value;
            VirtualMachineResource vm2 = await collection.GetAsync(vmName);

            ResourceDataHelper.AssertVirtualMachine(vm1.Data, vm2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetVirtualMachineCollectionAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource vm = lro.Value;
            Assert.IsTrue(await collection.ExistsAsync(vmName));
            Assert.IsFalse(await collection.ExistsAsync(vmName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName1, input1);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName2, input2);
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName1, input1);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName2, input2);

            VirtualMachineResource vm1 = null, vm2 = null;
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
