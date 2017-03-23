// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachineWithDisk
{
    public class Program
    {
        private static string userName = "tirekicker";
        private static string password = "12NewPA$$w0rd!";
        private static Region region = Region.USWestCentral;

        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create a virtual machine with
         *      - Implicit data disks
         *      - Creatable data disks
         *      - Existing data disks
         *  - Update a virtual machine
         *      - Attach data disks
         *      - Detach data disks
         *  - Stop a virtual machine
         *  - Update a virtual machine
         *      - Expand the OS disk
         *      - Expand data disks.
         */
        public static void RunSample(IAzure azure)
        {
            var linuxVmName1 = Utilities.CreateRandomName("VM1");
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var publicIpDnsLabel = Utilities.CreateRandomName("pip");

            try
            {
                // Creates an empty data disk to attach to the virtual machine
                //
                Utilities.Log("Creating an empty managed disk");

                var dataDisk1 = azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(50)
                        .Create();

                Utilities.Log("Created managed disk");

                // Prepare first creatable data disk
                //
                var dataDiskCreatable1 = azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(100);

                // Prepare second creatable data disk
                //
                var dataDiskCreatable2 = azure.Disks.Define(Utilities.CreateRandomName("dsk-"))
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(50)
                        .WithSku(DiskSkuTypes.StandardLRS);

                //======================================================================
                // Create a Linux VM using a PIR image with managed OS and Data disks

                Utilities.Log("Creating a managed Linux VM");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)

                        // Begin: Managed data disks
                        .WithNewDataDisk(100)
                        .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                        .WithNewDataDisk(dataDiskCreatable1)
                        .WithNewDataDisk(dataDiskCreatable2, 2, CachingTypes.ReadOnly)
                        .WithExistingDataDisk(dataDisk1)

                        // End: Managed data disks
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created a Linux VM with managed OS and data disks: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                //======================================================================
                // Update the virtual machine by detaching two data disks with lun 3 and 4 and adding one

                Utilities.Log("Updating Linux VM");

                var lun3DiskId = linuxVM.DataDisks[3].Id;

                linuxVM.Update()
                        .WithoutDataDisk(3)
                        .WithoutDataDisk(4)
                        .WithNewDataDisk(200)
                        .Apply();

                Utilities.Log("Updated Linux VM: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                // ======================================================================
                // Delete a managed disk

                var disk = azure.Disks.GetById(lun3DiskId);
                Utilities.Log("Delete managed disk: " + disk.Id);

                azure.Disks.DeleteByGroup(disk.ResourceGroupName, disk.Name);

                Utilities.Log("Deleted managed disk");

                //======================================================================
                // Deallocate the virtual machine

                Utilities.Log("De-allocate Linux VM");

                linuxVM.Deallocate();

                Utilities.Log("De-allocated Linux VM");

                //======================================================================
                // Resize the OS and Data Disks

                var osDisk = azure.Disks.GetById(linuxVM.OsDiskId);
                var dataDisks = new List<IDisk>();
                foreach (var vmDataDisk  in  linuxVM.DataDisks.Values)
                {
                    var dataDisk = azure.Disks.GetById(vmDataDisk.Id);
                    dataDisks.Add(dataDisk);
                }

                Utilities.Log("Update OS disk: " + osDisk.Id);

                osDisk.Update()
                        .WithSizeInGB(2 * osDisk.SizeInGB)
                        .Apply();

                Utilities.Log("OS disk updated");

                foreach (var dataDisk in dataDisks)
                {
                    Utilities.Log("Update data disk: " + dataDisk.Id);

                    dataDisk.Update()
                            .WithSizeInGB(dataDisk.SizeInGB + 10)
                            .Apply();

                    Utilities.Log("Data disk updated");
                }

                //======================================================================
                // Starting the virtual machine

                Utilities.Log("Starting Linux VM");

                linuxVM.Start();

                Utilities.Log("Started Linux VM");
                Utilities.PrintVirtualMachine(linuxVM);
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
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}
