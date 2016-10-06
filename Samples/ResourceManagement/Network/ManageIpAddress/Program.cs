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

namespace ManageIpAddress
{
    /**
     * Azure Network sample for managing IP address -
     *  - Assign a public IP address for a virtual machine during its creation
     *  - Assign a public IP address for a virtual machine through an virtual machine update action
     *  - Get the associated public IP address for a virtual machine
     *  - Get the assigned public IP address for a virtual machine
     *  - Remove a public IP address from a virtual machine.
     */

    public class Program
    {
        private static readonly string publicIpAddressName1 = ResourceNamer.RandomResourceName("pip1", 20);
        private static readonly string publicIpAddressName2 = ResourceNamer.RandomResourceName("pip2", 20);
        private static readonly string publicIpAddressLeafDNS1 = ResourceNamer.RandomResourceName("pip1", 20);
        private static readonly string publicIpAddressLeafDNS2 = ResourceNamer.RandomResourceName("pip2", 20);
        private static readonly string vmName = ResourceNamer.RandomResourceName("vm", 8);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMP", 24);
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
                    // Assign a public IP address for a VM during its creation

                    // Define a public IP address to be used during VM creation time

                    Console.WriteLine("Creating a public IP address...");

                    var publicIpAddress = azure.PublicIpAddresses
                            .Define(publicIpAddressName1)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithLeafDomainLabel(publicIpAddressLeafDNS1)
                            .Create();

                    Console.WriteLine("Created a public IP address");
                    // Print public IP address details
                    Utilities.PrintIpAddress(publicIpAddress);

                    // Use the pre-created public IP for the new VM

                    Console.WriteLine("Creating a Windows VM");

                    var t1 = DateTime.UtcNow;

                    var vm = azure.VirtualMachines.Define(vmName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithExistingPrimaryPublicIpAddress(publicIpAddress)
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    var t2 = DateTime.UtcNow;
                    Console.WriteLine("Created VM: (took "
                            + (t2 - t1).TotalSeconds + " seconds) " + vm.Id);
                    // Print virtual machine details
                    Utilities.PrintVirtualMachine(vm);

                    //============================================================
                    // Gets the public IP address associated with the VM's primary NIC

                    Console.WriteLine("Public IP address associated with the VM's primary NIC [After create]");
                    // Print the public IP address details
                    Utilities.PrintIpAddress(vm.GetPrimaryPublicIpAddress());

                    //============================================================
                    // Assign a new public IP address for the VM

                    // Define a new public IP address

                    var publicIpAddress2 = azure.PublicIpAddresses
                            .Define(publicIpAddressName2)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithLeafDomainLabel(publicIpAddressLeafDNS2)
                            .Create();

                    // Update VM's primary NIC to use the new public IP address

                    Console.WriteLine("Updating the VM's primary NIC with new public IP address");

                    var primaryNetworkInterface = vm.GetPrimaryNetworkInterface();
                    primaryNetworkInterface
                            .Update()
                            .WithExistingPrimaryPublicIpAddress(publicIpAddress2)
                            .Apply();

                    //============================================================
                    // Gets the updated public IP address associated with the VM

                    // Get the associated public IP address for a virtual machine
                    Console.WriteLine("Public IP address associated with the VM's primary NIC [After Update]");
                    vm.Refresh();
                    Utilities.PrintIpAddress(vm.GetPrimaryPublicIpAddress());

                    //============================================================
                    // Remove public IP associated with the VM

                    Console.WriteLine("Removing public IP address associated with the VM");
                    vm.Refresh();
                    primaryNetworkInterface = vm.GetPrimaryNetworkInterface();
                    publicIpAddress = primaryNetworkInterface.PrimaryIpConfiguration.GetPublicIpAddress();
                    primaryNetworkInterface.Update()
                            .WithoutPrimaryPublicIpAddress()
                            .Apply();

                    Console.WriteLine("Removed public IP address associated with the VM");

                    //============================================================
                    // Delete the public ip
                    Console.WriteLine("Deleting the public IP address");
                    azure.PublicIpAddresses.Delete(publicIpAddress.Id);
                    Console.WriteLine("Deleted the public IP address");
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
                        azure.ResourceGroups.Delete(rgName);
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