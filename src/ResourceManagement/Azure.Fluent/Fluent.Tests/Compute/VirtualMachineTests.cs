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

namespace Fluent.Tests.Compute
{
    public class VirtualMachineTests
    {
        private const string Location = "southcentralus";
        private const string VMName = "chashvm";

        [Fact]
        public void CanCreateVirtualMachine()
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
                        .WithOsDiskName("javatest")
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
        public void CanCreateVirtualMachinesAndRelatedResourcesInParallel()
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
        public void CanCreateVirtualMachineWithCustomData()
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
                    using (var sshClient = new SshClient(publicIPAddress.Fqdn, 22, username, password))
                    {
                        sshClient.Connect();
                        var commandToExecute = "pwgen;";
                        using (var command = sshClient.CreateCommand(commandToExecute))
                        {
                            var commandOutput = command.Execute();
                            Assert.False(commandOutput.ToLowerInvariant().Contains("the program 'pwgen' is currently not installed"));
                        }
                        sshClient.Disconnect();
                    }
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
                        using (var sshClient = new SshClient(publicIPAddress.Fqdn, 22, username, password))
                        {
                            sshClient.Connect();
                            sshClient.Disconnect();
                        }
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

        private string TrySsh(ConnectionInfo connectionInfo, string commandToExecute, TimeSpan backoffTime, int retryCount)
        {
            string commandOutput = null;
            while (retryCount > 0)
            {
                TestHelper.Delay(backoffTime);
                using (var sshClient = new SshClient(connectionInfo))
                {
                    try
                    {
                        sshClient.Connect();
                        if (commandToExecute != null)
                        {
                            using (var command = sshClient.CreateCommand(commandToExecute))
                            {
                                commandOutput = command.Execute();
                            }
                        }
                        break;
                    }
                    catch (Exception exception)
                    {
                        retryCount--;
                        if (retryCount == 0)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        try
                        {
                            sshClient.Disconnect();
                        }
                        catch { }
                    }
                }
            }
            return commandOutput;
        }
    }
}