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
using System.Linq;

namespace ManageVirtualMachine
{
    /**
     * Azure Compute sample for managing virtual machines -
     *  - Create a virtual machine
     *  - Start a virtual machine
     *  - Stop a virtual machine
     *  - Restart a virtual machine
     *  - Update a virtual machine
     *    - Expand the OS drive
     *    - Tag a virtual machine (there are many possible variations here)
     *    - Attach data disks
     *    - Detach data disks
     *  - List virtual machines
     *  - Delete a virtual machine.
     */

    public class Program
    {
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgCOMV", 24);
        private static readonly string windowsVMName = ResourceNamer.RandomResourceName("wVM", 24);
        private static readonly string linuxVMName = ResourceNamer.RandomResourceName("lVM", 24);
        private static readonly string userName = "tirekicker";
        private static readonly string password = "12NewPA$$w0rd!";
        private static readonly string dataDiskName = "disk2";

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    var startTime = DateTimeOffset.Now.UtcDateTime;

                    var windowsVM = azure.VirtualMachines.Define(windowsVMName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUsername(userName)
                            .WithAdminPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();
                    var endTime = DateTimeOffset.Now.UtcDateTime;

                    Console.WriteLine($"Created VM: took {(endTime - startTime).TotalSeconds} seconds");

                    Utilities.PrintVirtualMachine(windowsVM);

                    windowsVM.Update()
                            .WithTag("who-rocks", "open source")
                            .WithTag("where", "on azure")
                            .Apply();

                    Console.WriteLine("Tagged VM: " + windowsVM.Id);

                    //=============================================================
                    // Update - Attach data disks

                    windowsVM.Update()
                            .WithNewDataDisk(10)
                            .DefineNewDataDisk(dataDiskName)
                                .WithSizeInGB(20)
                                .WithCaching(CachingTypes.ReadWrite)
                                .Attach()
                            .Apply();

                    Console.WriteLine("Attached a new data disk" + dataDiskName + " to VM" + windowsVM.Id);
                    Utilities.PrintVirtualMachine(windowsVM);

                    windowsVM.Update()
                        .WithoutDataDisk(dataDiskName)
                        .Apply();

                    Console.WriteLine("Detached data disk " + dataDiskName + " from VM " + windowsVM.Id);

                    //=============================================================
                    // Update - Resize (expand) the data disk
                    // First, deallocate the virtual machine and then proceed with resize

                    Console.WriteLine("De-allocating VM: " + windowsVM.Id);

                    windowsVM.Deallocate();

                    Console.WriteLine("De-allocated VM: " + windowsVM.Id);

                    var dataDisk = windowsVM.DataDisks.First();

                    windowsVM.Update()
                                .UpdateDataDisk(dataDisk.Name)
                                .WithSizeInGB(30)
                                .Parent()
                            .Apply();

                    //=============================================================
                    // Update - Expand the OS drive size by 10 GB

                    int osDiskSizeInGb = windowsVM.OsDiskSize;
                    if (osDiskSizeInGb == 0)
                    {
                        // Server is not returning the OS Disk size, possible bug in server
                        Console.WriteLine("Server is not returning the OS disk size, possible bug in the server?");
                        Console.WriteLine("Assuming that the OS disk size is 256 GB");
                        osDiskSizeInGb = 256;
                    }

                    windowsVM.Update()
                            .WithOsDiskSizeInGb(osDiskSizeInGb + 10)
                            .Apply();

                    Console.WriteLine("Expanded VM " + windowsVM.Id + "'s OS disk to " + (osDiskSizeInGb + 10));

                    //=============================================================
                    // Start the virtual machine

                    Console.WriteLine("Starting VM " + windowsVM.Id);

                    windowsVM.Start();

                    Console.WriteLine("Started VM: " + windowsVM.Id + "; state = " + windowsVM.PowerState);

                    //=============================================================
                    // Restart the virtual machine

                    Console.WriteLine("Restarting VM: " + windowsVM.Id);

                    windowsVM.Restart();

                    Console.WriteLine("Restarted VM: " + windowsVM.Id + "; state = " + windowsVM.PowerState);

                    //=============================================================
                    // Stop (powerOff) the virtual machine

                    Console.WriteLine("Powering OFF VM: " + windowsVM.Id);

                    windowsVM.PowerOff();

                    Console.WriteLine("Powered OFF VM: " + windowsVM.Id + "; state = " + windowsVM.PowerState);

                    // Get the network where Windows VM is hosted
                    var network = windowsVM.GetPrimaryNetworkInterface().PrimaryIpConfiguration.GetNetwork();

                    //=============================================================
                    // Create a Linux VM in the same virtual network

                    Console.WriteLine("Creating a Linux VM in the network");

                    var linuxVM = azure.VirtualMachines.Define(linuxVMName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("subnet1") // Referencing the default subnet name when no name specified at creation
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    Console.WriteLine("Created a Linux VM (in the same virtual network): " + linuxVM.Id);
                    Utilities.PrintVirtualMachine(linuxVM);

                    //=============================================================
                    // List virtual machines in the resource group

                    var resourceGroupName = windowsVM.ResourceGroupName;

                    Console.WriteLine("Printing list of VMs =======");

                    foreach (var virtualMachine in azure.VirtualMachines.ListByGroup(resourceGroupName))
                    {
                        Utilities.PrintVirtualMachine(virtualMachine);
                    }

                    //=============================================================
                    // Delete the virtual machine
                    Console.WriteLine("Deleting VM: " + windowsVM.Id);

                    azure.VirtualMachines.DeleteById(windowsVM.Id);

                    Console.WriteLine("Deleted VM: " + windowsVM.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine($"Deleting resource group : {rgName}");
                    azure.ResourceGroups.DeleteByName(rgName);
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