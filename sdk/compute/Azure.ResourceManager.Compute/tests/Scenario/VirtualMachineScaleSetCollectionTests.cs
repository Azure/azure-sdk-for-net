// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineScaleSetCollectionTests : VirtualMachineScaleSetTestBase
    {
        public VirtualMachineScaleSetCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));
            var lro = await collection.CreateOrUpdateAsync(vmssName, input);
            VirtualMachineScaleSet vmss = lro.Value;
            Assert.AreEqual(vmssName, vmss.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));
            var lro = await collection.CreateOrUpdateAsync(vmssName, input);
            VirtualMachineScaleSet vmss1 = lro.Value;
            VirtualMachineScaleSet vmss2 = await collection.GetAsync(vmssName);

            ResourceDataHelper.AssertVirtualMachineScaleSet(vmss1.Data, vmss2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));
            var lro = await collection.CreateOrUpdateAsync(vmssName, input);
            VirtualMachineScaleSet vmss = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(vmssName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(vmssName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName1 = Recording.GenerateAssetName("testVMSS-");
            var vmssName2 = Recording.GenerateAssetName("testVMSS-");
            var vnet1 = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var vnet2 = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input1 = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName1, GetSubnetId(vnet1));
            var input2 = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName2, GetSubnetId(vnet2));
            _ = await collection.CreateOrUpdateAsync(vmssName1, input1);
            _ = await collection.CreateOrUpdateAsync(vmssName2, input2);
            int count = 0;
            await foreach (var vmss in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName1 = Recording.GenerateAssetName("testVMSS-");
            var vmssName2 = Recording.GenerateAssetName("testVMSS-");
            var vnet1 = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var vnet2 = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input1 = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName1, GetSubnetId(vnet1));
            var input2 = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName2, GetSubnetId(vnet2));
            _ = await collection.CreateOrUpdateAsync(vmssName1, input1);
            _ = await collection.CreateOrUpdateAsync(vmssName2, input2);

            VirtualMachineScaleSet vmss1 = null, vmss2 = null;
            await foreach (var vmss in DefaultSubscription.GetVirtualMachineScaleSetsAsync())
            {
                if (vmss.Data.Name == vmssName1)
                    vmss1 = vmss;
                if (vmss.Data.Name == vmssName2)
                    vmss2 = vmss;
            }

            Assert.NotNull(vmss1);
            Assert.NotNull(vmss2);
        }
    }
}
