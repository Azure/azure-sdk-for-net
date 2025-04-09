// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2024-03-01", "2024-11-01")]
    public class VirtualMachineAnyZoneCapabilityTest : VirtualMachineTestBase
    {
        public VirtualMachineAnyZoneCapabilityTest(bool async, string apiVersion)
            : base(async, VirtualMachineResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string vmName = Recording.GenerateAssetName("testVM-");
            var collection = await GetVirtualMachineCollectionAsync();
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            input.Placement = new VirtualMachinePlacement() { ZonePlacementPolicy = "Any" };
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource virtualMachine = lro.Value;
            Assert.AreEqual(vmName, virtualMachine.Data.Name);
        }
    }
}
