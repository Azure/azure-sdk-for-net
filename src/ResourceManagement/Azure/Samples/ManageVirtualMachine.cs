using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Linq;

namespace Samples
{
    internal class ManageVirtualMachine
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

        public static void TestVirtualMachine()
        {
            var windowsVMName = ResourceNamer.RandomResourceName("wVM", 24);
            var linuxVMName = ResourceNamer.RandomResourceName("lVM", 24);
            var rgName = ResourceNamer.RandomResourceName("rgCOMV", 24);
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";
            var dataDiskName = "disk2";

            try
            {
                //=============================================================
                // Authenticate

                var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

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
                            .WithAdminUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();
                    var endTime = DateTimeOffset.Now.UtcDateTime;

                    Console.WriteLine($"Created VM: took {(endTime - startTime).Seconds} seconds");

                    Utilities.PrintVirtualMachine(windowsVM);

                    windowsVM.Update()
                            .WithTag("who-rocks", "java")
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

                    var dataDisk = windowsVM.DataDisks().First();

                    windowsVM.Update()
                                .UpdateDataDisk(dataDisk.Name)
                                .WithSizeInGB(30)
                                .Parent()
                            .Apply();

                    //=============================================================
                    // Update - Expand the OS drive size by 10 GB

                    var osDiskSizeInGb = windowsVM.OsDiskSize.GetValueOrDefault();
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
                    var network = windowsVM.PrimaryNetworkInterface().PrimaryNetwork();

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
                            .WithRootUserName(userName)
                            .WithPassword(password)
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

                    azure.VirtualMachines.Delete(windowsVM.Id);

                    Console.WriteLine("Deleted VM: " + windowsVM.Id);
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