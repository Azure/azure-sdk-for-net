// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Micosoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageVirtualMachinesInParallelWithNetwork
{
    public class Program
    {
        /**
         * Create a virtual network with two Subnets – frontend and backend
         * Frontend allows HTTP in and denies Internet out
         * Backend denies Internet in and Internet out
         * Create m Linux virtual machines in the frontend
         * Create m Windows virtual machines in the backend.
         */
        readonly static int frontendVmCount = 10;
        readonly static int backendVmCount = 10;
        readonly static string rgName = ResourceNamer.RandomResourceName("rgCOMV", 24);
        readonly static string frontEndNSGName = ResourceNamer.RandomResourceName("fensg", 24);
        readonly static string backEndNSGName = ResourceNamer.RandomResourceName("bensg", 24);
        readonly static string networkName = ResourceNamer.RandomResourceName("vnetCOMV", 24);
        readonly static string storageAccountName = ResourceNamer.RandomResourceName("stgCOMV", 20);
        readonly static string userName = "tirekicker";
        readonly static string password = "12NewPA$$w0rd!";

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithSubscription(credentials.DefaultSubscriptionId);

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    // Create a resource group [Where all resources gets created]
                    IResourceGroup resourceGroup = azure.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Region.US_EAST)
                            .Create();

                    //============================================================
                    // Define a network security group for the front end of a subnet
                    // front end subnet contains two rules
                    // - ALLOW-SSH - allows SSH traffic into the front end subnet
                    // - ALLOW-WEB- allows HTTP traffic into the front end subnet

                    var frontEndNSGCreatable = azure.NetworkSecurityGroups
                            .Define(frontEndNSGName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .DefineRule("ALLOW-SSH")
                                .AllowInbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(22)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(100)
                                .WithDescription("Allow SSH")
                            .Attach()
                            .DefineRule("ALLOW-HTTP")
                                .AllowInbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(80)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(101)
                                .WithDescription("Allow HTTP")
                            .Attach();

                    //============================================================
                    // Define a network security group for the back end of a subnet
                    // back end subnet contains two rules
                    // - ALLOW-SQL - allows SQL traffic only from the front end subnet
                    // - DENY-WEB - denies all outbound internet traffic from the back end subnet

                    var backEndNSGCreatable = azure.NetworkSecurityGroups
                            .Define(backEndNSGName)
                                .WithRegion(Region.US_EAST)
                                .WithExistingResourceGroup(resourceGroup)
                                .DefineRule("ALLOW-SQL")
                                .AllowInbound()
                                .FromAddress("172.16.1.0/24")
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(1433)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(100)
                                .WithDescription("Allow SQL")
                            .Attach()
                            .DefineRule("DENY-WEB")
                                .DenyOutbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToAnyPort()
                                .WithAnyProtocol()
                                .WithDescription("Deny Web")
                                .WithPriority(200)
                            .Attach();

                    Console.WriteLine("Creating a security group for the front ends - allows SSH and HTTP");
                    Console.WriteLine("Creating a security group for the back ends - allows SSH and denies all outbound internet traffic");

                    var networkSecurityGroups = azure.NetworkSecurityGroups
                            .Create(frontEndNSGCreatable, backEndNSGCreatable);

                    INetworkSecurityGroup frontendNSG = networkSecurityGroups.First(n => n.Name.Equals(frontEndNSGName, StringComparison.OrdinalIgnoreCase));
                    INetworkSecurityGroup backendNSG = networkSecurityGroups.First(n => n.Name.Equals(backEndNSGName, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine("Created a security group for the front end: " + frontendNSG.Id);
                    Utilities.PrintNetworkSecurityGroup(frontendNSG);

                    Console.WriteLine("Created a security group for the back end: " + backendNSG.Id);
                    Utilities.PrintNetworkSecurityGroup(backendNSG);

                    // Create Network [Where all the virtual machines get added to]
                    var network = azure.Networks
                            .Define(networkName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("172.16.0.0/16")
                            .DefineSubnet("Front-end")
                                .WithAddressPrefix("172.16.1.0/24")
                                .WithExistingNetworkSecurityGroup(frontendNSG)
                            .Attach()
                            .DefineSubnet("Back-End")
                                .WithAddressPrefix("172.16.2.0/24")
                                .WithExistingNetworkSecurityGroup(backendNSG)
                            .Attach()
                            .Create();

                    // Prepare Creatable Storage account definition [For storing VMs disk]
                    var creatableStorageAccount = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup);

                    // Prepare a batch of Creatable Virtual Machines definitions
                    List<ICreatable<IVirtualMachine>> frontendCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                    for (int i = 0; i < frontendVmCount; i++)
                    {
                        var creatableVirtualMachine = azure.VirtualMachines
                            .Define("VM-FE-" + i)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Front-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithNewStorageAccount(creatableStorageAccount);
                        frontendCreatableVirtualMachines.Add(creatableVirtualMachine);
                    }

                    List<ICreatable<IVirtualMachine>> backendCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                    for (int i = 0; i < backendVmCount; i++)
                    {
                        var creatableVirtualMachine = azure.VirtualMachines
                            .Define("VM-BE-" + i)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Backend-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithNewStorageAccount(creatableStorageAccount);
                        backendCreatableVirtualMachines.Add(creatableVirtualMachine);
                    }

                    var startTime = DateTimeOffset.Now.UtcDateTime;
                    Console.WriteLine("Creating the virtual machines");

                    List<ICreatable<IVirtualMachine>> allCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();
                    allCreatableVirtualMachines.AddRange(frontendCreatableVirtualMachines);
                    allCreatableVirtualMachines.AddRange(backendCreatableVirtualMachines);

                    var virtualMachines = azure.VirtualMachines.Create(allCreatableVirtualMachines.ToArray());

                    var endTime = DateTimeOffset.Now.UtcDateTime;
                    Console.WriteLine("Created virtual machines");

                    foreach (var virtualMachine in virtualMachines)
                    {
                        Console.WriteLine(virtualMachine.Id);
                    }

                    Console.WriteLine($"Virtual machines create: took {(endTime - startTime).Seconds} seconds");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine($"Deleting resource group : {rgName}");
                    azure.ResourceGroups.Delete(rgName);
                    Console.WriteLine($"Deleted resource group : {rgName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
