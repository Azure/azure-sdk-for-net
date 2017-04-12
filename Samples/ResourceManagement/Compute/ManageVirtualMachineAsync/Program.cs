// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Threading.Tasks;

namespace ManageVirtualMachineAsync
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create a virtual machine with managed OS Disk based on Windows OS image
         *  - Once Network is created start creation of virtual machine based on Linux OS image in the same network
         *  - Update both virtual machines
         *    - for Linux based:
         *      - add Tag
         *    - for Windows based:
         *      - deallocate the virtual machine
         *      - add a data disk
         *      - start the virtual machine
         *  - List virtual machines and print details
         *  - Delete all virtual machines.
         */
        public async static Task RunSampleAsync(IAzure azure)
        {
            var region = Region.USWestCentral;
            var windowsVmName = Utilities.CreateRandomName("wVM");
            var linuxVmName = Utilities.CreateRandomName("lVM");
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";

            try
            {
                //=============================================================
                // Create a Windows virtual machine

                // Prepare a creatable data disk for VM
                //
                var dataDiskCreatable = azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(100);

                // Create a data disk to attach to VM
                //
                var dataDisk = await azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(50)
                        .CreateAsync();

                Utilities.Log("Creating a Windows VM");

                var t1 = new DateTime();

                var windowsVM = await azure.VirtualMachines.Define(windowsVmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername(userName)
                        .WithAdminPassword(password)
                        .WithNewDataDisk(10)
                        .WithNewDataDisk(dataDiskCreatable)
                        .WithExistingDataDisk(dataDisk)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .CreateAsync();

                var t2 = new DateTime();
                Utilities.Log($"Created VM: (took {(t2 - t1).TotalSeconds} seconds) " + windowsVM.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(windowsVM);

                // Get the network where Windows VM is hosted
                var network = windowsVM.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();

                //=============================================================
                // Create a Linux VM in the same virtual network

                Utilities.Log("Creating a Linux VM in the network");

                var linuxVM = await azure.VirtualMachines.Define(linuxVmName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("subnet1") // Referencing the default subnet name when no name specified at creation
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .CreateAsync();

                Utilities.Log("Created a Linux VM (in the same virtual network): " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                //=============================================================
                // Update - Tag the virtual machine

                await linuxVM.Update()
                        .WithTag("who-rocks-on-linux", "java")
                        .WithTag("where", "on azure")
                        .ApplyAsync();

                Utilities.Log("Tagged Linux VM: " + linuxVM.Id);

                //=============================================================
                // Update - Add a data disk on Windows VM.

                await windowsVM.Update()
                        .WithNewDataDisk(200)
                        .ApplyAsync();

                Utilities.Log("Expanded VM " + windowsVM.Id + "'s OS and data disks");
                Utilities.PrintVirtualMachine(windowsVM);
                
                //=============================================================
                // List virtual machines in the resource group

                var resourceGroupName = windowsVM.ResourceGroupName;

                Utilities.Log("Printing list of VMs =======");

                foreach (var virtualMachine in await azure.VirtualMachines.ListByResourceGroupAsync(resourceGroupName))
                {
                    Utilities.PrintVirtualMachine(virtualMachine);
                }

                //=============================================================
                // Delete the virtual machine
                Utilities.Log("Deleting VM: " + windowsVM.Id);

                await azure.VirtualMachines.DeleteByIdAsync(windowsVM.Id);

                Utilities.Log("Deleted VM: " + windowsVM.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    await azure.ResourceGroups.DeleteByNameAsync(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSampleAsync(azure).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}