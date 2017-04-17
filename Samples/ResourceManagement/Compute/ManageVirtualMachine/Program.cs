// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageVirtualMachine
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create a virtual machine with managed OS Disk
         *  - Start a virtual machine
         *  - Stop a virtual machine
         *  - Restart a virtual machine
         *  - Update a virtual machine
         *    - Tag a virtual machine (there are many possible variations here)
         *    - Attach data disks
         *    - Detach data disks
         *  - List virtual machines
         *  - Delete a virtual machine.
         */
        public static void RunSample(IAzure azure)
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
                var dataDisk = azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(50)
                        .Create();

                Utilities.Log("Creating a Windows VM");

                var t1 = new DateTime();

                var windowsVM = azure.VirtualMachines.Define(windowsVmName)
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
                        .Create();

                var t2 = new DateTime();
                Utilities.Log($"Created VM: (took {(t2 - t1).TotalSeconds} seconds) " + windowsVM.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(windowsVM);

                //=============================================================
                // Update - Tag the virtual machine

                windowsVM.Update()
                        .WithTag("who-rocks", "java")
                        .WithTag("where", "on azure")
                        .Apply();

                Utilities.Log("Tagged VM: " + windowsVM.Id);

                //=============================================================
                // Update - Add data disk

                windowsVM.Update()
                        .WithNewDataDisk(10)
                        .Apply();

                Utilities.Log("Added a data disk to VM" + windowsVM.Id);
                Utilities.PrintVirtualMachine(windowsVM);

                //=============================================================
                // Update - detach data disk

                windowsVM.Update()
                        .WithoutDataDisk(0)
                        .Apply();

                Utilities.Log("Detached data disk at lun 0 from VM " + windowsVM.Id);

                //=============================================================
                // Restart the virtual machine

                Utilities.Log("Restarting VM: " + windowsVM.Id);

                windowsVM.Restart();

                Utilities.Log("Restarted VM: " + windowsVM.Id + "; state = " + windowsVM.PowerState);

                //=============================================================
                // Stop (powerOff) the virtual machine

                Utilities.Log("Powering OFF VM: " + windowsVM.Id);

                windowsVM.PowerOff();

                Utilities.Log("Powered OFF VM: " + windowsVM.Id + "; state = " + windowsVM.PowerState);

                // Get the network where Windows VM is hosted
                var network = windowsVM.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();

                //=============================================================
                // Create a Linux VM in the same virtual network

                Utilities.Log("Creating a Linux VM in the network");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName)
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
                        .Create();

                Utilities.Log("Created a Linux VM (in the same virtual network): " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                //=============================================================
                // List virtual machines in the resource group

                var resourceGroupName = windowsVM.ResourceGroupName;

                Utilities.Log("Printing list of VMs =======");

                foreach (var virtualMachine in azure.VirtualMachines.ListByResourceGroup(resourceGroupName))
                {
                    Utilities.PrintVirtualMachine(virtualMachine);
                }

                //=============================================================
                // Delete the virtual machine
                Utilities.Log("Deleting VM: " + windowsVM.Id);

                azure.VirtualMachines.DeleteById(windowsVM.Id);

                Utilities.Log("Deleted VM: " + windowsVM.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
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
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}