// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
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
        private const string LOCATION = "southcentralus";
        private const string VMNAME = "chashvm";

        [Fact]
        public void CanCreateVirtualMachine()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                var computeManager = TestHelper.CreateComputeManager();
                var resourceManager = TestHelper.CreateResourceManager();

                try
                {
                    // Create
                    var vm = computeManager.VirtualMachines
                        .Define(VMNAME)
                        .WithRegion(LOCATION)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithoutPrimaryPublicIpAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_DATACENTER)
                        .WithAdminUsername("Foo12")
                        .WithAdminPassword("BaR@12!Foo")
                        .WithSize(VirtualMachineSizeTypes.StandardD3)
                        .WithOsDiskCaching(CachingTypes.ReadWrite)
                        .WithOsDiskName("javatest")
                        .Create();

                    var foundedVM = computeManager.VirtualMachines.ListByGroup(rgName)
                        .FirstOrDefault(v => v.Name.Equals(VMNAME, StringComparison.OrdinalIgnoreCase));

                    Assert.NotNull(foundedVM);
                    Assert.Equal(LOCATION, foundedVM.RegionName);
                    // Get
                    foundedVM = computeManager.VirtualMachines.GetByGroup(rgName, VMNAME);
                    Assert.NotNull(foundedVM);
                    Assert.Equal(LOCATION, foundedVM.RegionName);

                    // Fetch instance view
                    PowerState powerState = foundedVM.PowerState;
                    Assert.True(powerState == PowerState.RUNNING);
                    VirtualMachineInstanceView instanceView = foundedVM.InstanceView;
                    Assert.NotNull(instanceView);
                    Assert.NotNull(instanceView.Statuses.Count > 0);

                    // Capture the VM [Requires VM to be Poweroff and generalized]
                    foundedVM.PowerOff();
                    foundedVM.Generalize();
                    var jsonResult = foundedVM.Capture("capturedvhds", "cpt", true);
                    Assert.NotNull(jsonResult);

                    // Delete VM
                    computeManager.VirtualMachines.DeleteById(foundedVM.Id);
                }
                finally
                {
                    resourceManager.ResourceGroups.DeleteByName(rgName);
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
                var publicIpNamePrefix = TestUtilities.GenerateName("pip-");
                var networkNamePrefix = TestUtilities.GenerateName("vnet-");

                var region = Region.US_EAST;
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
                    var publicIpCreatableKeys = new List<string>();
                    var virtualMachineCreatables = new List<ICreatable<IVirtualMachine>>();
                    for (int i = 0; i < count; i++)
                    {
                        var networkCreatable = azure.Networks
                                .Define($"{networkNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithAddressSpace("10.0.0.0/28");
                        networkCreatableKeys.Add(networkCreatable.Key);

                        var publicIpAddressCreatable = azure.PublicIpAddresses
                                .Define($"{publicIpNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable);
                        publicIpCreatableKeys.Add(publicIpAddressCreatable.Key);

                        var virtualMachineCreatable = azure.VirtualMachines
                                .Define($"{vmNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithNewResourceGroup(resourceGroupCreatable)
                                .WithNewPrimaryNetwork(networkCreatable)
                                .WithPrimaryPrivateIpAddressDynamic()
                                .WithNewPrimaryPublicIpAddress(publicIpAddressCreatable)
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                                .WithRootUsername("tirekicker")
                                .WithRootPassword("BaR@12!#")
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

                    HashSet<string> publicIpAddressNames = new HashSet<string>();
                    for (int i = 0; i < count; i++)
                    {
                        publicIpAddressNames.Add($"{publicIpNamePrefix}-{i}");
                    }

                    foreach (string publicIpCreatableKey in publicIpCreatableKeys)
                    {
                        var createdPublicIpAddress = (IPublicIpAddress)createdVirtualMachines.CreatedRelatedResource(publicIpCreatableKey);
                        Assert.NotNull(createdPublicIpAddress);
                        Assert.True(publicIpAddressNames.Contains(createdPublicIpAddress.Name));
                    }
                }
                catch (Exception exception)
                {
                    Assert.True(false, exception.Message);
                }
                finally
                {
                    azure.ResourceGroups.DeleteByName(resourceGroupName);
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
                var publicIpDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.US_EAST;
                var cloudInitEncodedString = Convert.ToBase64String(Encoding.ASCII.GetBytes("#cloud-config\r\npackages:\r\n - pwgen"));

                var azure = TestHelper.CreateRollupClient();

                var publicIpAddress = azure.PublicIpAddresses.Define(publicIpDnsLabel)
                    .WithRegion(region)
                    .WithNewResourceGroup()
                    .WithLeafDomainLabel(publicIpDnsLabel)
                    .Create();

                var virtualMachine = azure.VirtualMachines.Define(vmName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(publicIpAddress.ResourceGroupName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIpAddressDynamic()
                    .WithExistingPrimaryPublicIpAddress(publicIpAddress)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                    .WithRootUsername(username)
                    .WithRootPassword(password)
                    .WithCustomData(cloudInitEncodedString)
                    .Create();

                publicIpAddress.Refresh();
                Assert.True(publicIpAddress.HasAssignedNetworkInterface);

                ConnectionInfo connectionInfo = new ConnectionInfo(publicIpAddress.Fqdn, 22, username,
                    new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(username, password)
                    });
                using (var sshClient = new SshClient(connectionInfo))
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

        [Fact]
        public void CanSShConnectToVirtualMachine()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rg");
                var vmName = TestUtilities.GenerateName("vm");
                var username = "testuser";
                var password = "12NewPA$$w0rd!";
                var publicIpDnsLabel = TestUtilities.GenerateName("abc");
                var region = Region.US_EAST;

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var virtualMachine = azure.VirtualMachines.Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithNewPrimaryPublicIpAddress(publicIpDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                        .WithRootUsername(username)
                        .WithRootPassword(password)
                        .Create();

                    var publicIpAddress = virtualMachine.GetPrimaryPublicIpAddress();

                    ConnectionInfo connectionInfo = new ConnectionInfo(publicIpAddress.Fqdn, 22, username,
                        new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(username, password)
                        });
                    using (var sshClient = new SshClient(connectionInfo))
                    {
                        try
                        {
                            sshClient.Connect();
                            sshClient.Disconnect();
                        }
                        catch (Exception exception)
                        {
                            Assert.False(true, $"Ssh connection failure to {publicIpAddress.Fqdn}, {exception.Message}");
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