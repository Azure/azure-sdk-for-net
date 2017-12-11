// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMNetworkInterfaceTests : VMTestBase
    {
        [Fact]
        public void TestNicVirtualMachineReference()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;
                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    NetworkInterface nicResponse = CreateNIC(rgName, subnetResponse, null);

                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id);

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(
                         rgName, inputVM.Name, inputVM);

                    Assert.NotNull(createOrUpdateResponse);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse.MacAddress);
                    Assert.NotNull(getNicResponse.Primary);
                    Assert.True(getNicResponse.Primary != null && getNicResponse.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void TestEffectiveRouteAndAcls()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;
                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    NetworkSecurityGroup nsgResponse = CreateNsg(rgName);
                    NetworkInterface nicResponse = CreateNIC(rgName, subnetResponse, null, null, nsgResponse);

                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id);

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(
                         rgName, inputVM.Name, inputVM);

                    Assert.NotNull(createOrUpdateResponse);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse.MacAddress);
                    Assert.NotNull(getNicResponse.Primary);
                    Assert.True(getNicResponse.Primary != null && getNicResponse.Primary.Value);

                    // Get Effective RouteTable
                    var getEffectiveRouteTable = m_NrpClient.NetworkInterfaces.GetEffectiveRouteTable(rgName, nicResponse.Name);
                    Assert.NotNull(getEffectiveRouteTable);
                    Assert.NotEqual(0, getEffectiveRouteTable.Value.Count);
                    Assert.Equal(getEffectiveRouteTable.Value[0].Source, EffectiveRouteSource.Default);
                    Assert.Equal(getEffectiveRouteTable.Value[0].State, EffectiveRouteState.Active);

                    // Get Effecting NSG
                    var getEffectiveNSGresponse = m_NrpClient.NetworkInterfaces.ListEffectiveNetworkSecurityGroups(rgName, nicResponse.Name);
                    Assert.NotNull(getEffectiveNSGresponse);
                    Assert.NotEqual(0, getEffectiveNSGresponse.Value.Count);
                    Assert.NotNull(getEffectiveNSGresponse.Value[0].Association);
                    Assert.NotNull(getEffectiveNSGresponse.Value[0].Association.NetworkInterface);
                    Assert.Null(getEffectiveNSGresponse.Value[0].Association.Subnet);
                    Assert.Equal(getEffectiveNSGresponse.Value[0].Association.NetworkInterface.Id, nicResponse.Id);
                    Assert.NotNull(getEffectiveNSGresponse.Value[0].NetworkSecurityGroup);
                    Assert.Equal(getEffectiveNSGresponse.Value[0].NetworkSecurityGroup.Id, nsgResponse.Id);
                    Assert.NotNull(getEffectiveNSGresponse.Value[0].EffectiveSecurityRules);
                    Assert.NotEqual(0, getEffectiveNSGresponse.Value[0].EffectiveSecurityRules.Count);
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
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void TestMultiNicVirtualMachineReference()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;

                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    string nicname1 = ComputeManagementTestUtilities.GenerateName(null);
                    string nicname2 = ComputeManagementTestUtilities.GenerateName(null);
                    NetworkInterface nicResponse1 = CreateNIC(rgName, subnetResponse, null, nicname1);
                    NetworkInterface nicResponse2 = CreateNIC(rgName, subnetResponse, null, nicname2);
                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.Id);

                    inputVM.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                    inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

                    inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
                    {
                        Id = nicResponse2.Id,
                        Primary = true
                    });

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse1 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse1.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse1.MacAddress);
                    Assert.NotNull(getNicResponse1.Primary);
                    Assert.True(getNicResponse1.Primary != null && !getNicResponse1.Primary.Value);

                    var getNicResponse2 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse2.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse2.MacAddress);
                    Assert.NotNull(getNicResponse2.Primary);
                    Assert.True(getNicResponse2.Primary != null && getNicResponse2.Primary.Value);
                }
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void TestMultiIpConfigForMultiNICVM()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM;

                try
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = m_location,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Subnet subnetResponse = CreateVNET(rgName);

                    string nicname1 = ComputeManagementTestUtilities.GenerateName(null);
                    string nicname2 = ComputeManagementTestUtilities.GenerateName(null);
                    NetworkInterface nicResponse1 = CreateMultiIpConfigNIC(rgName, subnetResponse, nicname1);
                    NetworkInterface nicResponse2 = CreateMultiIpConfigNIC(rgName, subnetResponse, nicname2);
                    string asetId = CreateAvailabilitySet(rgName, asName);

                    inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse1.Id);

                    inputVM.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                    inputVM.NetworkProfile.NetworkInterfaces[0].Primary = false;

                    inputVM.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference
                    {
                        Id = nicResponse2.Id,
                        Primary = true
                    });

                    string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                    var createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);

                    Assert.True(
                        getVMResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    ValidateVM(inputVM, getVMResponse, expectedVMReferenceId);

                    var getNicResponse1 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse1.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse1.MacAddress);
                    Assert.NotNull(getNicResponse1.Primary);
                    Assert.True(getNicResponse1.Primary != null && !getNicResponse1.Primary.Value);

                    var getNicResponse2 = m_NrpClient.NetworkInterfaces.Get(rgName, nicResponse2.Name);
                    // TODO AutoRest: Recording Passed, but these assertions failed in Playback mode
                    Assert.NotNull(getNicResponse2.MacAddress);
                    Assert.NotNull(getNicResponse2.Primary);
                    Assert.True(getNicResponse2.Primary != null && getNicResponse2.Primary.Value);

                    // multi CA Assertions
                    Assert.Equal(2, getNicResponse1.IpConfigurations.Count);
                    Assert.Equal(2, getNicResponse2.IpConfigurations.Count);
                    Assert.Single(getNicResponse1.IpConfigurations.Where(x => x.Primary == true));
                    Assert.Single(getNicResponse2.IpConfigurations.Where(x => x.Primary == true));
                }
                finally
                {
                    // Cleanup the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}