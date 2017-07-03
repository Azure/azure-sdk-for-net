// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Renci.SshNet;
using System;
using System.Collections.Generic;

namespace CreateVirtualMachineUsingCustomImageFromVHD
{
    public class Program
    {
        private static string userName = "tirekicker";
        private static string password = "12NewPA$$w0rd!";
        private static Region region = Region.USWest;

        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create an un-managed virtual machine from PIR image with data disks
         *  - Deallocate the virtual machine
         *  - Generalize the virtual machine
         *  - Create a virtual machine custom image from OS and Data disk VHDs of virtual machine
         *  - Create a second virtual machine using the custom image
         *  - Create a second virtual machine using the custom image and configure the data disks
         *  - Deletes the custom image
         *  - Get SAS Uri to the virtual machine's managed disks.
         */
        public static void RunSample(IAzure azure)
        {
            var linuxVmName1 = SdkContext.RandomResourceName("VM1", 10);
            var linuxVmName2 = SdkContext.RandomResourceName("VM2", 10);
            var linuxVmName3 = SdkContext.RandomResourceName("VM3", 10);
            var customImageName = SdkContext.RandomResourceName("img", 10);
            var rgName = SdkContext.RandomResourceName("rgCOMV", 15);
            var publicIpDnsLabel = SdkContext.RandomResourceName("pip", 10);

            var apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh";
            var apacheInstallCommand = "bash install_apache.sh";
            var apacheInstallScriptUris = new List<string>();
            apacheInstallScriptUris.Add(apacheInstallScript);

            try
            {
                //=============================================================
                // Create a Linux VM using a PIR image with un-managed OS and data disks and customize virtual
                // machine using custom script extension

                Utilities.Log("Creating a un-managed Linux VM");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithUnmanagedDisks()
                        .DefineUnmanagedDataDisk("disk-1")
                            .WithNewVhd(100)
                            .WithLun(1)
                            .Attach()
                        .DefineUnmanagedDataDisk("disk-2")
                            .WithNewVhd(50)
                            .WithLun(2)
                            .Attach()
                        .DefineUnmanagedDataDisk("disk-3")
                            .WithNewVhd(60)
                            .WithLun(3)
                            .Attach()
                        .DefineNewExtension("CustomScriptForLinux")
                            .WithPublisher("Microsoft.OSTCExtensions")
                            .WithType("CustomScriptForLinux")
                            .WithVersion("1.4")
                            .WithMinorVersionAutoUpgrade()
                            .WithPublicSetting("fileUris", apacheInstallScriptUris)
                            .WithPublicSetting("commandToExecute", apacheInstallCommand)
                            .Attach()
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created a Linux VM with un-managed OS and data disks: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                // De-provision the virtual machine
                Utilities.DeprovisionAgentInLinuxVM(linuxVM.GetPrimaryPublicIPAddress().Fqdn, 22, userName, password);

                //=============================================================
                // Deallocate the virtual machine
                Utilities.Log("Deallocate VM: " + linuxVM.Id);

                linuxVM.Deallocate();

                Utilities.Log("De-allocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);

                //=============================================================
                // Generalize the virtual machine
                Utilities.Log("Generalize VM: " + linuxVM.Id);

                linuxVM.Generalize();

                Utilities.Log("Generalized VM: " + linuxVM.Id);

                //=============================================================
                // Create a virtual machine custom image from OS and data disks of the virtual machine

                Utilities.Log("Creating virtual machine custom image from un-managed disk VHDs: " + linuxVM.Id);

                var virtualMachineCustomImage = azure.VirtualMachineCustomImages
                        .Define(customImageName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromVhd(linuxVM.OSUnmanagedDiskVhdUri, OperatingSystemStateTypes.Generalized)
                        .DefineDataDiskImage()
                            .WithLun(linuxVM.UnmanagedDataDisks[1].Lun)
                            .FromVhd(linuxVM.UnmanagedDataDisks[1].VhdUri)
                            .Attach()
                        .DefineDataDiskImage()
                            .WithLun(linuxVM.UnmanagedDataDisks[2].Lun)
                            .FromVhd(linuxVM.UnmanagedDataDisks[2].VhdUri)
                            .Attach()
                        .DefineDataDiskImage()
                            .WithLun(linuxVM.UnmanagedDataDisks[3].Lun)
                            .FromVhd(linuxVM.UnmanagedDataDisks[3].VhdUri)
                            .WithDiskCaching(CachingTypes.ReadOnly)
                            .Attach()
                        .Create();

                Utilities.Log("Created custom image");

                Utilities.PrintVirtualMachineCustomImage(virtualMachineCustomImage);

                //=============================================================
                // Create a Linux VM using custom image

                Utilities.Log("Creating a Linux VM using custom image: " + virtualMachineCustomImage.Id);

                var linuxVM2 = azure.VirtualMachines.Define(linuxVmName2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithLinuxCustomImage(virtualMachineCustomImage.Id)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created Linux VM");
                Utilities.PrintVirtualMachine(linuxVM2);

                //=============================================================
                // Create another Linux VM using custom image and configure the data disks from image and
                // add another data disk

                var linuxVM3 = azure.VirtualMachines.Define(linuxVmName3)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithLinuxCustomImage(virtualMachineCustomImage.Id)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithNewDataDiskFromImage(1, 200, CachingTypes.ReadWrite)
                        .WithNewDataDiskFromImage(2, 100, CachingTypes.ReadOnly)
                        .WithNewDataDiskFromImage(3, 100, CachingTypes.ReadWrite)
                        .WithNewDataDisk(50)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.PrintVirtualMachine(linuxVM3);

                // Getting the SAS URIs requires virtual machines to be de-allocated
                // [Access not permitted because'disk' is currently attached to running VM]
                //
                Utilities.Log("De-allocating the virtual machine - " + linuxVM3.Id);

                linuxVM3.Deallocate();

                //=============================================================
                // Get the readonly SAS URI to the OS and data disks

                Utilities.Log("Getting OS and data disks SAS Uris");

                // OS Disk SAS Uri
                var osDisk = azure.Disks.GetById(linuxVM3.OSDiskId);

                var osDiskSasUri = osDisk.GrantAccess(24 * 60);

                Utilities.Log("OS disk SAS Uri: " + osDiskSasUri);

                // Data Disks SAS Uri
                foreach (var disk  in  linuxVM3.DataDisks.Values)
                {
                    var dataDisk = azure.Disks.GetById(disk.Id);
                    var dataDiskSasUri = dataDisk.GrantAccess(24 * 60);
                    Utilities.Log($"Data disk (lun: {disk.Lun}) SAS Uri: {dataDiskSasUri}");
                }

                //=============================================================
                // Deleting the custom image
                Utilities.Log("Deleting custom Image: " + virtualMachineCustomImage.Id);

                azure.VirtualMachineCustomImages.DeleteById(virtualMachineCustomImage.Id);

                Utilities.Log("Deleted custom image");
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
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
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
