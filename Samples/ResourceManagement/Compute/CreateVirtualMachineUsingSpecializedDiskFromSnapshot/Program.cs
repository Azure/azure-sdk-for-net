// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace CreateVirtualMachineUsingSpecializedDiskFromSnapshot
{
    public class Program
    {
        private static string userName = "tirekicker";
        private static string password = "12NewPA$$w0rd!";
        private static Region region = Region.USWestCentral;

        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create an managed virtual machine from PIR image with data disks
         *  - Create snapshot from the virtual machine's OS and data disks
         *  - Create managed disks from the snapshots
         *  - Create virtual machine by attaching the managed disks
         *  - Get SAS Uri to the virtual machine's managed disks.
         */
        public static void RunSample(IAzure azure)
        {
            var linuxVmName1 = Utilities.CreateRandomName("VM1");
            var linuxVmName2 = Utilities.CreateRandomName("VM2");
            var managedOSSnapshotName = Utilities.CreateRandomName("ss-os-");
            var managedDataDiskSnapshotPrefix = Utilities.CreateRandomName("ss-data-");
            var managedNewOSDiskName = Utilities.CreateRandomName("ds-os-nw-");
            var managedNewDataDiskNamePrefix = Utilities.CreateRandomName("ds-data-nw-");

            var rgName = Utilities.CreateRandomName("rgCOMV");
            var publicIpDnsLabel = Utilities.CreateRandomName("pip");
            var apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh";
            var apacheInstallCommand = "bash install_apache.sh";

            var apacheInstallScriptUris = new List<string>();
            apacheInstallScriptUris.Add(apacheInstallScript);

            try
            {
                //=============================================================
                // Create a Linux VM using a PIR image with managed OS and data disks and customize virtual
                // machine using custom script extension

                Utilities.Log("Creating a un-managed Linux VM");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithNewPrimaryPublicIpAddress(publicIpDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithNewDataDisk(100)
                        .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .DefineNewExtension("CustomScriptForLinux")
                            .WithPublisher("Microsoft.OSTCExtensions")
                            .WithType("CustomScriptForLinux")
                            .WithVersion("1.4")
                            .WithMinorVersionAutoUpgrade()
                            .WithPublicSetting("fileUris", apacheInstallScriptUris)
                            .WithPublicSetting("commandToExecute", apacheInstallCommand)
                            .Attach()
                        .Create();

                Utilities.Log("Created a Linux VM with managed OS and data disks: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                // Gets the specialized managed OS and Data disks of the virtual machine
                //
                var osDisk = azure.Disks.GetById(linuxVM.OsDiskId);
                var dataDisks = new List<IDisk>();
                foreach (var disk in linuxVM.DataDisks.Values)
                {
                    var dataDisk = azure.Disks.GetById(disk.Id);
                    dataDisks.Add(dataDisk);
                }

                //=============================================================
                // Delete the virtual machine
                Utilities.Log("Deleting VM: " + linuxVM.Id);

                azure.VirtualMachines.DeleteById(linuxVM.Id);

                Utilities.Log("Deleted the VM");

                //=============================================================
                // Create Snapshot from the OS managed disk

                Utilities.Log($"Creating managed snapshot from the managed disk (holding specialized OS): {osDisk.Id}");

                var osSnapshot = azure.Snapshots.Define(managedOSSnapshotName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromDisk(osDisk)
                        .Create();

                Utilities.Log("Created managed snapshot holding OS: " + osSnapshot.Id);
                // Utilities.Print(osSnapshot); TODO

                //=============================================================
                // Create Managed snapshot from the Data managed disks

                var dataSnapshots = new List<ISnapshot>();
                var i = 0;
                foreach (var dataDisk in dataDisks)
                {
                    Utilities.Log($"Creating managed snapshot from the managed disk (holding data): {dataDisk.Id} ");

                    var dataSnapshot = azure.Snapshots.Define(managedDataDiskSnapshotPrefix + "-" + i)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithDataFromDisk(dataDisk)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .Create();
                    dataSnapshots.Add(dataSnapshot);

                    Utilities.Log("Created managed snapshot holding data: " + dataSnapshot.Id);
                    // Utilities.Print(dataDisk); TODO
                    i++;
                }

                //=============================================================
                // Create Managed disk from the specialized OS snapshot

                Utilities.Log(String.Format("Creating managed disk from the snapshot holding OS: %s ", osSnapshot.Id));

                var newOSDisk = azure.Disks.Define(managedNewOSDiskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromSnapshot(osSnapshot)
                        .WithSizeInGB(100)
                        .Create();

                Utilities.Log("Created managed disk holding OS: " + osDisk.Id);
                // Utilities.Print(osDisk); TODO

                //=============================================================
                // Create Managed disks from the data snapshots

                var newDataDisks = new List<IDisk>();
                i = 0;
                foreach (var dataSnapshot in dataSnapshots)
                {
                    Utilities.Log($"Creating managed disk from the Data snapshot: {dataSnapshot.Id} ");

                    var dataDisk = azure.Disks.Define(managedNewDataDiskNamePrefix + "-" + i)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithData()
                            .FromSnapshot(dataSnapshot)
                            .Create();
                    newDataDisks.Add(dataDisk);

                    Utilities.Log("Created managed disk holding data: " + dataDisk.Id);
                    // Utilities.Print(dataDisk); TODO
                    i++;
                }

                //
                //=============================================================
                // Create a Linux VM by attaching the managed disks

                Utilities.Log("Creating a Linux VM using specialized OS and data disks");

                var linuxVM2 = azure.VirtualMachines.Define(linuxVmName2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithoutPrimaryPublicIpAddress()
                        .WithSpecializedOsDisk(newOSDisk, OperatingSystemTypes.Linux)
                        .WithExistingDataDisk(newDataDisks[0])
                        .WithExistingDataDisk(newDataDisks[1], 1, CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.PrintVirtualMachine(linuxVM2);

                //=============================================================
                //
                Utilities.Log("Deleting OS snapshot - " + osSnapshot.Id);

                azure.Snapshots.DeleteById(osSnapshot.Id);

                Utilities.Log("Deleted OS snapshot");

                foreach (var dataSnapshot in dataSnapshots)
                {
                    Utilities.Log("Deleting data snapshot - " + dataSnapshot.Id);

                    azure.Snapshots.DeleteById(dataSnapshot.Id);

                    Utilities.Log("Deleted data snapshot");
                }

                // Getting the SAS URIs requires virtual machines to be de-allocated
                // [Access not permitted because'disk' is currently attached to running VM]
                //
                Utilities.Log("De-allocating the virtual machine - " + linuxVM2.Id);

                linuxVM2.Deallocate();

                //=============================================================
                // Get the readonly SAS URI to the OS and data disks

                Utilities.Log("Getting OS and data disks SAS Uris");

                // OS Disk SAS Uri
                osDisk = azure.Disks.GetById(linuxVM2.OsDiskId);

                var osDiskSasUri = osDisk.GrantAccess(24 * 60);

                Utilities.Log("OS disk SAS Uri: " + osDiskSasUri);

                // Data disks SAS Uri
                foreach (var disk in linuxVM2.DataDisks.Values)
                {
                    var dataDisk = azure.Disks.GetById(disk.Id);
                    var dataDiskSasUri = dataDisk.GrantAccess(24 * 60);
                    Utilities.Log($"Data disk (lun: {disk.Lun}) SAS Uri: {dataDiskSasUri}");
                }
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
