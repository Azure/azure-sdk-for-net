// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Network.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMNetworkInterfaceTests : VMTestBase
    {
        public VMNetworkInterfaceTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task TestNicVirtualMachineReference()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM;
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location)
                {
                    Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                });

            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            Subnet subnetResponse = await CreateVNET(rgName);

            NetworkInterface nicResponse = await CreateNIC(rgName, subnetResponse, null);

            string asetId = await CreateAvailabilitySet(rgName, asName);

            inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id);

            string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

            var createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(
                 rgName, inputVM.Name, inputVM));

            Assert.NotNull(createOrUpdateResponse);

            var getVMResponse = await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name);

            //Assert.True(
            //    getVMResponse.Value.AvailabilitySet.Id
            //        .ToLowerInvariant() == asetId.ToLowerInvariant());
            ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

            var getNicResponse = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse.MacAddress);
            Assert.NotNull(getNicResponse.Primary);
            Assert.True(getNicResponse.Primary != null && getNicResponse.Primary.Value);
        }

        [Test]
        [Ignore ("This case need to be tested by compute team")]
        public async Task TestEffectiveRouteAndAcls()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM;
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location)
                {
                    Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                });

            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            Subnet subnetResponse = await CreateVNET(rgName);

            NetworkSecurityGroup nsgResponse = await CreateNsg(rgName);
            NetworkInterface nicResponse = await CreateNIC(rgName, subnetResponse, null, null, nsgResponse);

            string asetId = await CreateAvailabilitySet(rgName, asName);

            inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id);

            string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

            var createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(
                 rgName, inputVM.Name, inputVM));

            Assert.NotNull(createOrUpdateResponse);

            var getVMResponse = (await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name)).Value;

            //Assert.True(
            //    getVMResponse.AvailabilitySet.Id
            //        .ToLowerInvariant() == asetId.ToLowerInvariant());
            ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

            var getNicResponse = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse.MacAddress);
            Assert.NotNull(getNicResponse.Primary);
            Assert.True(getNicResponse.Primary != null && getNicResponse.Primary.Value);

            // Get Effective RouteTable
            var getEffectiveRouteTable = (await WaitForCompletionAsync(await NetworkInterfacesOperations.StartGetEffectiveRouteTableAsync(rgName, nicResponse.Name))).Value;
            Assert.NotNull(getEffectiveRouteTable);
            //Assert.AreNotEqual(0, getEffectiveRouteTable.Value.Count);
            Assert.AreEqual(getEffectiveRouteTable.Value[0].Source, EffectiveRouteSource.Default);
            Assert.AreEqual(getEffectiveRouteTable.Value[0].State, EffectiveRouteState.Active);

            // Get Effecting NSG
            var getEffectiveNSGresponse = (await WaitForCompletionAsync(await NetworkInterfacesOperations.StartListEffectiveNetworkSecurityGroupsAsync(rgName, nicResponse.Name.ToString()))).Value;
            Assert.NotNull(getEffectiveNSGresponse);
            Assert.AreNotEqual(0, getEffectiveNSGresponse.Value.Count);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].Association);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].Association.NetworkInterface);
            Assert.Null(getEffectiveNSGresponse.Value[0].Association.Subnet);
            Assert.AreEqual(getEffectiveNSGresponse.Value[0].Association.NetworkInterface.Id, nicResponse.Id);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].NetworkSecurityGroup);
            Assert.AreEqual(getEffectiveNSGresponse.Value[0].NetworkSecurityGroup.Id, nsgResponse.Id);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules);
            Assert.AreNotEqual(0, getEffectiveNSGresponse.Value[0].EffectiveSecurityRules.Count);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].Access);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].DestinationAddressPrefix);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].DestinationPortRange);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].SourceAddressPrefix);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].SourcePortRange);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].Priority);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].Name);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].ExpandedDestinationAddressPrefix);
            Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules[0].ExpandedSourceAddressPrefix);
        }
        [Test]
        public async Task TestMultiNicVirtualMachineReference()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            string rgName = (TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM;
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location)
                {
                    Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                });

            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            Subnet subnetResponse = await CreateVNET(rgName);

            string nicname1 = Recording.GenerateAssetName(null);
            string nicname2 = Recording.GenerateAssetName(null);
            NetworkInterface nicResponse1 = await CreateNIC(rgName, subnetResponse, null, nicname1);
            NetworkInterface nicResponse2 = await CreateNIC(rgName, subnetResponse, null, nicname2);
            string asetId = await CreateAvailabilitySet(rgName, asName);

            inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.Id);

            inputVM.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
            inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

            inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
            {
                Id = nicResponse2.Id,
                Primary = true
            });

            string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

            var createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, inputVM.Name, inputVM));

            var getVMResponse = (await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name)).Value;

            //Assert.True(
            //    getVMResponse.AvailabilitySet.Id
            //        .ToLowerInvariant() == asetId.ToLowerInvariant());
            ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

            var getNicResponse1 = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse1.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse1.MacAddress);
            Assert.NotNull(getNicResponse1.Primary);
            Assert.True(getNicResponse1.Primary != null && !getNicResponse1.Primary.Value);

            var getNicResponse2 = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse2.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse2.MacAddress);
            Assert.NotNull(getNicResponse2.Primary);
            Assert.True(getNicResponse2.Primary != null && getNicResponse2.Primary.Value);
        }

        [Test]
        public async Task TestMultiIpConfigForMultiNICVM()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM;
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location)
                {
                    Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                });

            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            Subnet subnetResponse = await CreateVNET(rgName);

            string nicname1 = Recording.GenerateAssetName(null);
            string nicname2 = Recording.GenerateAssetName(null);
            NetworkInterface nicResponse1 = await CreateMultiIpConfigNIC(rgName, subnetResponse, nicname1);
            NetworkInterface nicResponse2 = await CreateMultiIpConfigNIC(rgName, subnetResponse, nicname2);
            string asetId = await CreateAvailabilitySet(rgName, asName);

            inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.Id);

            inputVM.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
            inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

            inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
            {
                Id = nicResponse2.Id,
                Primary = true
            });

            string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

            var createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, inputVM.Name, inputVM));

            var getVMResponse = (await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name)).Value;

            //Assert.True(
            //    getVMResponse.AvailabilitySet.Id
            //        .ToLowerInvariant() == asetId.ToLowerInvariant());
            ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

            var getNicResponse1 = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse1.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse1.MacAddress);
            Assert.NotNull(getNicResponse1.Primary);
            Assert.True(getNicResponse1.Primary != null && !getNicResponse1.Primary.Value);

            var getNicResponse2 = (await NetworkInterfacesOperations.GetAsync(rgName, nicResponse2.Name)).Value;
            // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
            Assert.NotNull(getNicResponse2.MacAddress);
            Assert.NotNull(getNicResponse2.Primary);
            Assert.True(getNicResponse2.Primary != null && getNicResponse2.Primary.Value);

            // multi CA Assertions
            Assert.AreEqual(2, getNicResponse1.IpConfigurations.Count);
            Assert.AreEqual(2, getNicResponse2.IpConfigurations.Count);
            Assert.IsTrue(getNicResponse1.IpConfigurations.Where(x => x.Primary == true).Count() == 1);
            Assert.IsTrue(getNicResponse2.IpConfigurations.Where(x => x.Primary == true).Count() == 1);
            //Assert.Single(getNicResponse1.IpConfigurations.Where(x => x.Primary == true));
            //Assert.Single(getNicResponse2.IpConfigurations.Where(x => x.Primary == true));
        }
    }
}
