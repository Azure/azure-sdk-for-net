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

namespace CreateVirtualMachineUsingSpecializedDiskFromVhd
{
    public class Program
    {
        private static string userName = "tirekicker";
        private static string password = "12NewPA$$w0rd!";
        private static Region region = Region.USWestCentral;

        /**
         * Azure Compute sample for managing virtual machines.
         *  - Create an un-managed virtual machine from PIR image with data disks
         *  - Create managed disks from specialized un-managed OS and Data disk of virtual machine
         *  - Create a virtual machine by attaching the managed disks
         *  - Get SAS Uri to the virtual machine's managed disks
         */
        public static void RunSample(IAzure azure)
        {
            var linuxVmName1 = Utilities.CreateRandomName("VM1");
            var linuxVmName2 = Utilities.CreateRandomName("VM2");
            var managedOSDiskName = Utilities.CreateRandomName("ds-os-");
            var managedDataDiskNamePrefix = Utilities.CreateRandomName("ds-data-");
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var publicIpDnsLabel = Utilities.CreateRandomName("pip");

            var apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh";
            var apacheInstallCommand = "bash install_apache.sh";
            var apacheInstallScriptUris = new List<string>();
            apacheInstallScriptUris.Add(apacheInstallScript);
            try
            {
                //=============================================================
                // Create a Linux VM using an image from PIR (Platform Image Repository)

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
                        .WithUnmanagedDisks()
                        .DefineUnmanagedDataDisk("disk-1")
                            .WithNewVhd(50)
                            .WithLun(1)
                            .Attach()
                        .DefineUnmanagedDataDisk("disk-2")
                            .WithNewVhd(50)
                            .WithLun(2)
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

                // Gets the specialized OS and Data disk VHDs of the virtual machine
                //
                var specializedOSVhdUri = linuxVM.OsUnmanagedDiskVhdUri;
                var dataVhdUris = new List<string>();
                foreach (var dataDisk  in  linuxVM.UnmanagedDataDisks.Values)
                {
                    dataVhdUris.Add(dataDisk.VhdUri);
                }

                //=============================================================
                // Delete the virtual machine
                Utilities.Log("Deleting VM: " + linuxVM.Id);

                azure.VirtualMachines.DeleteById(linuxVM.Id);

                Utilities.Log("Deleted the VM");

                //=============================================================
                // Create Managed disk from the specialized OS VHD

                Utilities.Log($"Creating managed disk from the specialized OS VHD: {specializedOSVhdUri} ");

                var osDisk = azure.Disks.Define(managedOSDiskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromVhd(specializedOSVhdUri)
                        .WithSizeInGB(100)
                        .Create();

                Utilities.Log("Created managed disk holding OS: " + osDisk.Id);
                // Utilities.Print(osDisk); TODO

                //=============================================================
                // Create Managed disks from the Data VHDs

                var dataDisks = new List<IDisk>();
                var i = 0;
                foreach (String dataVhdUri  in  dataVhdUris)
                {
                    Utilities.Log($"Creating managed disk from the Data VHD: {dataVhdUri}");

                    var dataDisk = azure.Disks.Define(managedDataDiskNamePrefix + "-" + i)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithData()
                            .FromVhd(dataVhdUri)
                            .WithSizeInGB(150)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .Create();
                    dataDisks.Add(dataDisk);

                    Utilities.Log("Created managed disk holding data: " + dataDisk.Id);
                    // Utilities.Print(dataDisk); TODO
                    i++;
                }

                //=============================================================
                // Create a Linux VM by attaching the disks

                Utilities.Log("Creating a Linux VM using specialized OS and data disks");

                var linuxVM2 = azure.VirtualMachines.Define(linuxVmName2)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithoutPrimaryPublicIpAddress()
                        .WithSpecializedOsDisk(osDisk, OperatingSystemTypes.Linux)
                        .WithExistingDataDisk(dataDisks[0])
                        .WithExistingDataDisk(dataDisks[1], 1, CachingTypes.ReadWrite)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.PrintVirtualMachine(linuxVM2);

                var dataDiskIds = new List<string>();
                foreach (var disk  in  linuxVM2.DataDisks.Values)
                {
                    dataDiskIds.Add(disk.Id);
                }

                //=============================================================
                // Detach the data disks from the virtual machine

                Utilities.Log("Updating VM by detaching the data disks");

                linuxVM2.Update()
                        .WithoutDataDisk(0)
                        .WithoutDataDisk(1)
                        .Apply();

                Utilities.PrintVirtualMachine(linuxVM2);

                //=============================================================
                // Get the readonly SAS URI to the data disks
                Utilities.Log("Getting data disks SAS Uris");

                foreach (String diskId  in  dataDiskIds)
                {
                    var dataDisk = azure.Disks.GetById(diskId);
                    var dataDiskSasUri = dataDisk.GrantAccess(24 * 60);
                    Utilities.Log($"Data disk SAS Uri: {dataDiskSasUri}");
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
