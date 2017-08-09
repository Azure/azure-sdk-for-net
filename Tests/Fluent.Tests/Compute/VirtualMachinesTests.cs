// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class VirtualMachine
    {
        private const string Location = "southcentralus";
        private const string VMName = "chashvm";

        [Fact]
        public void CanCreateWithNetworking()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("rgfluentchash-");
                var NsgName = TestUtilities.GenerateName("nsg");
                var NetworkName = TestUtilities.GenerateName("net");
                var VMName = TestUtilities.GenerateName("vm");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();
                var networkManager = TestHelper.CreateNetworkManager();

                try
                {
                   var nsg = networkManager.NetworkSecurityGroups.Define(NsgName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(GroupName)
                        .DefineRule("rule1")
                            .AllowInbound()
                            .FromAnyAddress()
                            .FromPort(80)
                            .ToAnyAddress()
                            .ToPort(80)
                            .WithProtocol("tcp")
                            .Attach()
                        .Create();

                    ICreatable<INetwork> networkDefinition = networkManager.Networks.Define(NetworkName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(GroupName)
                        .WithAddressSpace("10.0.0.0/28")
                        .DefineSubnet("subnet1")
                            .WithAddressPrefix("10.0.0.0/29")
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Attach();

                    // Create  
                    IVirtualMachine vm = computeManager.VirtualMachines.Define(VMName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(GroupName)
                        .WithNewPrimaryNetwork(networkDefinition)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .Create();

                    var primaryNic = vm.GetPrimaryNetworkInterface();
                    Assert.NotNull(primaryNic);
                    var primaryIpConfig = primaryNic.PrimaryIPConfiguration;
                    Assert.NotNull(primaryIpConfig);

                    // Fetch the NSG the way before v1.2  
                    Assert.NotNull(primaryIpConfig.NetworkId);
                    var network = primaryIpConfig.GetNetwork();
                    Assert.NotNull(primaryIpConfig.SubnetName);
                    ISubnet subnet = null;
                    network.Subnets.TryGetValue(primaryIpConfig.SubnetName, out subnet);
                    Assert.NotNull(subnet);
                    nsg = subnet.GetNetworkSecurityGroup();
                    Assert.NotNull(nsg);
                    Assert.Equal(NsgName, nsg.Name);
                    Assert.Equal(1, nsg.SecurityRules.Count);

                    // Fetch the NSG the v1.2 way  
                    nsg = primaryIpConfig.GetNetworkSecurityGroup();
                    Assert.Equal(NsgName, nsg.Name);

                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("rgfluentchash-");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    // Create
                    var vm = computeManager.VirtualMachines
                        .Define(VMName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(GroupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                        .WithAdminUsername("Foo12")
                        .WithAdminPassword("BaR@12!Foo")
                        .WithUnmanagedDisks()
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.StandardD3)
                        .WithOSDiskName("javatest")
                        .Create();

                    var foundedVM = computeManager.VirtualMachines.ListByResourceGroup(GroupName)
                        .FirstOrDefault(v => v.Name.Equals(VMName, StringComparison.OrdinalIgnoreCase));

                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);
                    // Get
                    foundedVM = computeManager.VirtualMachines.GetByResourceGroup(GroupName, VMName);
                    Assert.NotNull(foundedVM);
                    Assert.Equal(Location, foundedVM.RegionName);

                    // Fetch instance view
                    PowerState powerState = foundedVM.PowerState;
                    Assert.True(powerState == PowerState.Running);
                    VirtualMachineInstanceView instanceView = foundedVM.InstanceView;
                    Assert.NotNull(instanceView);
                    Assert.NotNull(instanceView.Statuses.Count > 0);

                    // Capture the VM [Requires VM to be Poweroff and generalized]
                    foundedVM.PowerOff();
                    foundedVM.Generalize();
                    var jsonResult = foundedVM.Capture("captured-vhds", "cpt", true);
                    Assert.NotNull(jsonResult);

                    // Delete VM
                    computeManager.VirtualMachines.DeleteById(foundedVM.Id);
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(GroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithRelatedResourcesInParallel()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var resourceGroupName = TestUtilities.GenerateName("rgvmtest-");
                var vmNamePrefix = "vmz";
                var publicIPNamePrefix = TestUtilities.GenerateName("pip-");
                var networkNamePrefix = TestUtilities.GenerateName("vnet-");

                var region = Region.USEast;
                int count = 5;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var resourceGroupCreatable = azure.ResourceGroups
                    .Define(resourceGroupName)
                    .WithRegion(region);

                    var storageAccountCreatable = azure.StorageAccounts
                        .Define(TestUtilities.GenerateName("stg"))
                        .WithRegion(region)
                        .WithNewResourceGroup(resourceGroupCreatable);

                    var networkCreatableKeys = new List<string>();
                    var publicIPCreatableKeys = new List<string>();
                    var virtualMachineCreatables = new List<ICreatable<IVirtualMachine>>();
                    for (int i = 0; i < count; i++)
                    {
                        var networkCreatable = azure.Networks
                                .Define($"{networkNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithAddressSpace("10.0.0.0/28");
                        networkCreatableKeys.Add(networkCreatable.Key);

                        var publicIPAddressCreatable = azure.PublicIPAddresses
                                .Define($"{publicIPNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable);
                        publicIPCreatableKeys.Add(publicIPAddressCreatable.Key);

                        var virtualMachineCreatable = azure.VirtualMachines
                                .Define($"{vmNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithNewPrimaryNetwork(networkCreatable)
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithNewPrimaryPublicIPAddress(publicIPAddressCreatable)
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername("tirekicker")
                                .WithRootPassword("BaR@12!#")
                                .WithUnmanagedDisks()
                                .WithNewStorageAccount(storageAccountCreatable);
                        virtualMachineCreatables.Add(virtualMachineCreatable);
                    }

                    var createdVirtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables.ToArray());
                    Assert.True(createdVirtualMachines.Count() == count);

                    HashSet<string> virtualMachineNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        virtualMachineNames.Add($"{vmNamePrefix}-{i}");
                    }

                    foreach (var virtualMachine in createdVirtualMachines)
                    {
                        Assert.True(virtualMachineNames.Contains(virtualMachine.Name));
                        Assert.NotNull(virtualMachine.Id);
                    }

                    var networkNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        networkNames.Add($"{networkNamePrefix}-{i}");
                    }

                    foreach (var networkCreatableKey in networkCreatableKeys)
                    {
                        var createdNetwork = (INetwork)createdVirtualMachines.CreatedRelatedResource(networkCreatableKey);
                        Assert.NotNull(createdNetwork);
                        Assert.True(networkNames.Contains(createdNetwork.Name));
                    }

                    HashSet<string> publicIPAddressNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        publicIPAddressNames.Add($"{publicIPNamePrefix}-{i}");
                    }

                    foreach (string publicIPCreatableKey in publicIPCreatableKeys)
                    {
                        var createdPublicIPAddress = (IPublicIPAddress)createdVirtualMachines.CreatedRelatedResource(publicIPCreatableKey);
                        Assert.NotNull(createdPublicIPAddress);
                        Assert.True(publicIPAddressNames.Contains(createdPublicIPAddress.Name));
                    }
                }
                finally
                {
                    try
                    { 
                        azure.ResourceGroups.DeleteByName(resourceGroupName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateWithCustomData()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = TestUtilities.GenerateName("vm");
                var username = "testuser";
                var password = "12NewPA$$w0rd!";
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;
                var cloudInitEncodedString = Convert.ToBase64String(Encoding.ASCII.GetBytes("#cloud-config\r\npackages:\r\n - pwgen"));

                var azure = TestHelper.CreateRollupClient();

                var publicIPAddress = azure.PublicIPAddresses.Define(publicIPDnsLabel)
                    .WithRegion(region)
                    .WithNewResourceGroup()
                    .WithLeafDomainLabel(publicIPDnsLabel)
                    .Create();

                var virtualMachine = azure.VirtualMachines.Define(vmName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(publicIPAddress.ResourceGroupName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername(username)
                    .WithRootPassword(password)
                    .WithUnmanagedDisks()
                    .WithCustomData(cloudInitEncodedString)
                    .Create();

                publicIPAddress.Refresh();
                Assert.True(publicIPAddress.HasAssignedNetworkInterface);
                Assert.NotNull(publicIPAddress.Fqdn);

                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    var commandOutput = TestHelper.TrySsh(publicIPAddress.Fqdn, 22, username, password, "pwgen;");

                    Assert.False(commandOutput.ToLowerInvariant().Contains("the program 'pwgen' is currently not installed"));
                }
            }
        }

        [Fact]
        public void CanSShConnectToVirtualMachine()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vmName = TestUtilities.GenerateName("vm");
                var username = "testuser";
                var password = "12NewPA$$w0rd!";
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .WithUnmanagedDisks()
                        .Create();

                    var publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Fqdn);

                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        TestHelper.TrySsh(publicIPAddress.Fqdn, 22, username, password, "pwgen;");
                    }
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanCreateWithExistingNetworkAndNewPIP()
        {
            // Test for https://github.com/Azure/azure-sdk-for-net/issues/3359
            //
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vnetName = TestUtilities.GenerateName("vnet");
                var vmName = TestUtilities.GenerateName("vm");
                var pipName = TestUtilities.GenerateName("pip");
                var username = "testuser";
                var password = "12NewPA$$w0rd!";
                var publicIPDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.USEast;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var network = azure.Networks.Define(vnetName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28")
                        .Create();

                    var subnet = network.Subnets.Values.FirstOrDefault();
                    Assert.NotNull(subnet);

                    var pipCreatable = azure.PublicIPAddresses.Define(pipName)
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .WithDynamicIP()
                                .WithLeafDomainLabel(publicIPDnsLabel);

                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet(subnet.Name)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipCreatable)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .WithSize(VirtualMachineSizeTypes.StandardA0)
                        .Create();

                    var publicIPAddress = virtualMachine.GetPrimaryPublicIPAddress();
                    Assert.NotNull(publicIPAddress.Fqdn);
                    var nic = virtualMachine.GetPrimaryNetworkInterface();
                    Assert.NotNull(nic);
                    Assert.NotNull(nic.PrimaryIPConfiguration.NetworkId);
                    Assert.Equal(nic.PrimaryIPConfiguration.NetworkId, network.Id);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanSetStorageAccountForUnmanagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgfluentchash-");
                var storageName = TestUtilities.GenerateName("stg");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();
                var storageManager = TestHelper.CreateStorageManager();

                // Create a premium storage account for virtual machine data disk
                //
                var storageAccount = storageManager.StorageAccounts.Define(storageName)
                        .WithRegion(Location)
                        .WithNewResourceGroup(groupName)
                        .WithSku(Microsoft.Azure.Management.Storage.Fluent.Models.SkuName.PremiumLRS)
                        .Create();

                // Creates a virtual machine with an unmanaged data disk that gets stored in the above
                // premium storage account
                //
                var virtualMachine = computeManager.VirtualMachines
                        .Define(VMName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithUnmanagedDisks()
                        .DefineUnmanagedDataDisk("disk1")
                            .WithNewVhd(100)
                            .WithLun(2)
                            .StoreAt(storageAccount.Name, "diskvhds", "datadisk1vhd.vhd")
                            .Attach()
                        .DefineUnmanagedDataDisk("disk2")
                            .WithNewVhd(100)
                            .WithLun(3)
                            .StoreAt(storageAccount.Name, "diskvhds", "datadisk2vhd.vhd")
                            .Attach()
                        .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .Create();

                // Validate the unmanaged data disks
                //
                var unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                Assert.NotNull(unmanagedDataDisks);
                Assert.Equal(2, unmanagedDataDisks.Count);
                var firstUnmanagedDataDisk = unmanagedDataDisks[2];
                Assert.NotNull(firstUnmanagedDataDisk);
                var secondUnmanagedDataDisk = unmanagedDataDisks[3];
                Assert.NotNull(secondUnmanagedDataDisk);
                var createdVhdUri1 = firstUnmanagedDataDisk.VhdUri;
                var createdVhdUri2 = secondUnmanagedDataDisk.VhdUri;
                Assert.NotNull(createdVhdUri1);
                Assert.NotNull(createdVhdUri2);

                computeManager.VirtualMachines.DeleteById(virtualMachine.Id);
                // Creates another virtual machine by attaching existing unmanaged data disk detached from the
                // above virtual machine.
                //
                virtualMachine = computeManager.VirtualMachines
                        .Define(VMName)
                        .WithRegion(Location)
                        .WithExistingResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithUnmanagedDisks()
                        .WithExistingUnmanagedDataDisk(storageAccount.Name, "diskvhds", "datadisk1vhd.vhd")
                        .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                        .Create();
                // Gets the vm
                //
                virtualMachine = computeManager.VirtualMachines.GetById(virtualMachine.Id);
                // Validate the unmanaged data disks
                //
                unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                Assert.NotNull(unmanagedDataDisks);
                Assert.Equal(1, unmanagedDataDisks.Count);
                firstUnmanagedDataDisk = unmanagedDataDisks.First().Value;
                Assert.NotNull(firstUnmanagedDataDisk.VhdUri);
                Assert.True(firstUnmanagedDataDisk.VhdUri.Equals(createdVhdUri1, StringComparison.OrdinalIgnoreCase));
                // Update the VM by attaching another existing data disk
                //
                virtualMachine.Update()
                        .WithExistingUnmanagedDataDisk(storageAccount.Name, "diskvhds", "datadisk2vhd.vhd")
                        .Apply();
                // Gets the vm
                //
                virtualMachine = computeManager.VirtualMachines.GetById(virtualMachine.Id);
                // Validate the unmanaged data disks
                //
                unmanagedDataDisks = virtualMachine.UnmanagedDataDisks;
                Assert.NotNull(unmanagedDataDisks);
                Assert.Equal(2, unmanagedDataDisks.Count);
            }
        }
    }
}