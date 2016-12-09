// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageNetworkInterface
{
    /**
     * Azure Network sample for managing network interfaces -
     *  - Create a virtual machine with multiple network interfaces
     *  - Configure a network interface
     *  - List network interfaces
     *  - Delete a network interface.
     */

    public class Program
    {
        private static readonly string vnetName = ResourceNamer.RandomResourceName("vnet", 24);
        private static readonly string networkInterfaceName1 = ResourceNamer.RandomResourceName("nic1", 24);
        private static readonly string networkInterfaceName2 = ResourceNamer.RandomResourceName("nic2", 24);
        private static readonly string networkInterfaceName3 = ResourceNamer.RandomResourceName("nic3", 24);
        private static readonly string publicIpAddressLeafDNS1 = ResourceNamer.RandomResourceName("pip1", 24);
        private static readonly string publicIpAddressLeafDNS2 = ResourceNamer.RandomResourceName("pip2", 24);

        // TODO adjust the length of vm name from 8 to 24
        private static readonly string vmName = ResourceNamer.RandomResourceName("vm", 8);

        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMI", 24);
        private static readonly string userName = "tirekicker";
        private static readonly string password = "12NewPA$$w0rd!";

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    //============================================================
                    // Create a virtual machine with multiple network interfaces

                    // Define a virtual network for the VMs in this availability set

                    Console.WriteLine("Creating a virtual network ...");

                    var network = azure.Networks
                            .Define(vnetName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAddressSpace("172.16.0.0/16")
                            .DefineSubnet("Front-end")
                                .WithAddressPrefix("172.16.1.0/24")
                                .Attach()
                            .DefineSubnet("Mid-tier")
                                .WithAddressPrefix("172.16.2.0/24")
                                .Attach()
                            .DefineSubnet("Back-end")
                                .WithAddressPrefix("172.16.3.0/24")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a virtual network: " + network.Id);
                    Utilities.PrintVirtualNetwork(network);

                    Console.WriteLine("Creating multiple network interfaces");
                    Console.WriteLine("Creating network interface 1");

                    var networkInterface1 = azure.NetworkInterfaces.Define(networkInterfaceName1)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Front-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(publicIpAddressLeafDNS1)
                            .WithIpForwarding()
                            .Create();

                    Console.WriteLine("Created network interface 1");
                    Utilities.PrintNetworkInterface(networkInterface1);
                    Console.WriteLine("Creating network interface 2");

                    var networkInterface2 = azure.NetworkInterfaces.Define(networkInterfaceName2)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Mid-tier")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .Create();

                    Console.WriteLine("Created network interface 2");
                    Utilities.PrintNetworkInterface(networkInterface2);

                    Console.WriteLine("Creating network interface 3");

                    var networkInterface3 = azure.NetworkInterfaces.Define(networkInterfaceName3)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Back-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .Create();

                    Console.WriteLine("Created network interface 3");
                    Utilities.PrintNetworkInterface(networkInterface3);

                    //=============================================================
                    // Create a virtual machine with multiple network interfaces

                    Console.WriteLine("Creating a Windows VM");

                    var t1 = DateTime.UtcNow;

                    var vm = azure.VirtualMachines.Define(vmName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetworkInterface(networkInterface1)
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUsername(userName)
                            .WithAdminPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithExistingSecondaryNetworkInterface(networkInterface2)
                            .WithExistingSecondaryNetworkInterface(networkInterface3)
                            .Create();

                    var t2 = DateTime.UtcNow;
                    Console.WriteLine("Created VM: (took "
                            + (t2 - t1).TotalSeconds + " seconds) " + vm.Id);
                    // Print virtual machine details
                    Utilities.PrintVirtualMachine(vm);

                    // ===========================================================
                    // Configure a network interface
                    Console.WriteLine("Updating the first network interface");
                    networkInterface1.Update()
                            .WithNewPrimaryPublicIpAddress(publicIpAddressLeafDNS2)
                            .Apply();

                    Console.WriteLine("Updated the first network interface");
                    Utilities.PrintNetworkInterface(networkInterface1);
                    Console.WriteLine();

                    //============================================================
                    // List network interfaces

                    Console.WriteLine("Walking through network inter4faces in resource group: " + rgName);
                    var networkInterfaces = azure.NetworkInterfaces.ListByGroup(rgName);
                    foreach (var networkInterface in networkInterfaces)
                    {
                        Utilities.PrintNetworkInterface(networkInterface);
                    }

                    //============================================================
                    // Delete a network interface

                    Console.WriteLine("Deleting a network interface: " + networkInterface2.Id);
                    Console.WriteLine("First, deleting the vm");
                    azure.VirtualMachines.DeleteById(vm.Id);
                    Console.WriteLine("Second, deleting the network interface");
                    azure.NetworkInterfaces.DeleteById(networkInterface2.Id);
                    Console.WriteLine("Deleted network interface");

                    Console.WriteLine("============================================================");
                    Console.WriteLine("Remaining network interfaces are ...");
                    networkInterfaces = azure.NetworkInterfaces.ListByGroup(rgName);
                    foreach (var networkInterface in networkInterfaces)
                    {
                        Utilities.PrintNetworkInterface(networkInterface);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}