// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Renci.SshNet;
using System;
using System.Collections.Generic;

namespace ManageManagedDisks
{
    public class Program
    {
        /**
         * This is sample will not be published, this is just to ensure out blog is honest.
         */

        public static void RunSample(IAzure azure)
        {
            var region = Region.USEast;
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var userName = "tirekicker";
            var sshkey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

            try
            {
                // ::==Create a VM
                // Create a virtual machine with an implicit Managed OS disk and explicit Managed data disk

                Utilities.Log("Creating VM [with an implicit Managed OS disk and explicit Managed data disk]");

                var linuxVM1Name = SdkContext.RandomResourceName("vm" + "-", 18);
                var linuxVM1Pip = SdkContext.RandomResourceName("pip" + "-", 18);
                var linuxVM1 = azure.VirtualMachines
                        .Define(linuxVM1Name)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(linuxVM1Pip)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithSsh(sshkey)
                        .WithNewDataDisk(100)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [with an implicit Managed OS disk and explicit Managed data disk]");

                // Creation is simplified with implicit creation of managed disks without specifying all the disk details. You will notice that you do not require storage accounts
                // ::== Update the VM
                // Create a VMSS with implicit managed OS disks and explicit managed data disks

                Utilities.Log("Creating VMSS [with implicit managed OS disks and explicit managed data disks]");

                var vmScaleSetName = SdkContext.RandomResourceName("vmss" + "-", 18);
                var vmScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmScaleSetName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardD5v2)
                        .WithExistingPrimaryNetworkSubnet(PrepareNetwork(azure, region, rgName), "subnet1")
                        .WithExistingPrimaryInternetFacingLoadBalancer(PrepareLoadBalancer(azure, region, rgName))
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("tirekicker")
                        .WithSsh(sshkey)
                        .WithNewDataDisk(100)
                        .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                        .WithNewDataDisk(100, 2, CachingTypes.ReadOnly)
                        .WithCapacity(3)
                        .Create();

                Utilities.Log("Created VMSS [with implicit managed OS disks and explicit managed data disks]");

                // Create an empty disk and attach to a VM (Manage Virtual Machine With Disk)

                Utilities.Log("Creating empty data disk [to attach to a VM]");

                var diskName = SdkContext.RandomResourceName("dsk" + "-", 18);
                var dataDisk = azure.Disks.Define(diskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .WithSizeInGB(50)
                        .Create();

                Utilities.Log("Created empty data disk [to attach to a VM]");

                Utilities.Log("Creating VM [with new managed data disks and disk attached]");

                var linuxVM2Name = SdkContext.RandomResourceName("vm" + "-", 10);
                var linuxVM2Pip = SdkContext.RandomResourceName("pip" + "-", 18);
                var linuxVM2 = azure.VirtualMachines.Define(linuxVM2Name)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(linuxVM2Pip)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithSsh(sshkey)
                        // Begin: Managed data disks
                        .WithNewDataDisk(100)
                        .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                        .WithExistingDataDisk(dataDisk)
                        // End: Managed data disks
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [with new managed data disks and disk attached]");

                // Update a VM

                Utilities.Log("Updating VM [by detaching a disk and adding empty disk]");

                linuxVM2.Update()
                        .WithoutDataDisk(2)
                        .WithNewDataDisk(200)
                        .Apply();

                Utilities.Log("Updated VM [by detaching a disk and adding empty disk]");

                // Create a VM from an image (Create Virtual Machine Using Custom Image from VM)

                Utilities.Log("Preparing specialized virtual machine with un-managed disk");

                var linuxVM = PrepareSpecializedUnmanagedVirtualMachine(azure, region, rgName);

                Utilities.Log("Prepared specialized virtual machine with un-managed disk");

                Utilities.Log("Creating custom image from specialized virtual machine");

                var customImageName = SdkContext.RandomResourceName("cimg" + "-", 10);
                var virtualMachineCustomImage = azure.VirtualMachineCustomImages
                        .Define(customImageName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .FromVirtualMachine(linuxVM) // from a deallocated and generalized VM
                        .Create();

                Utilities.Log("Created custom image from specialized virtual machine");

                Utilities.Log("Creating VM [from custom image]");

                var linuxVM3Name = SdkContext.RandomResourceName("vm" + "-", 10);
                var linuxVM3 = azure.VirtualMachines.Define(linuxVM3Name)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithLinuxCustomImage(virtualMachineCustomImage.Id)
                        .WithRootUsername(userName)
                        .WithSsh(sshkey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [from custom image]");

                // Create a VM from a VHD (Create Virtual Machine Using Specialized VHD)

                var linuxVmName4 = SdkContext.RandomResourceName("vm" + "-", 10);
                var specializedVhd = linuxVM.OSUnmanagedDiskVhdUri;

                azure.VirtualMachines.DeleteById(linuxVM.Id);

                Utilities.Log("Creating VM [by attaching un-managed disk]");

                var linuxVM4 = azure.VirtualMachines.Define(linuxVmName4)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithSpecializedOSUnmanagedDisk(specializedVhd, OperatingSystemTypes.Linux)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [by attaching un-managed disk]");

                // Create a Snapshot (Create Virtual Machine Using Specilaized Disks from Snapshot)

                Utilities.Log("Preparing specialized virtual machine with managed disks");

                var linuxVM5 = PrepareSpecializedManagedVirtualMachine(azure, region, rgName);
                var osDisk = azure.Disks.GetById(linuxVM5.OSDiskId);
                var dataDisks = new List<IDisk>();
                foreach (var disk in linuxVM5.DataDisks.Values)
                {
                    var d = azure.Disks.GetById(disk.Id);
                    dataDisks.Add(d);
                }

                Utilities.Log("Prepared specialized virtual machine with managed disks");

                Utilities.Log("Deleting VM: " + linuxVM5.Id);
                azure.VirtualMachines.DeleteById(linuxVM5.Id);
                Utilities.Log("Deleted the VM: " + linuxVM5.Id);

                Utilities.Log("Creating snapshot [from managed OS disk]");

                // Create a managed snapshot for an OS disk
                var managedOSSnapshotName = SdkContext.RandomResourceName("snp" + "-", 10);
                var osSnapshot = azure.Snapshots.Define(managedOSSnapshotName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromDisk(osDisk)
                        .Create();

                Utilities.Log("Created snapshot [from managed OS disk]");

                Utilities.Log("Creating managed OS disk [from snapshot]");

                // Create a managed disk from the managed snapshot for the OS disk
                var managedNewOSDiskName = SdkContext.RandomResourceName("dsk" + "-", 10);
                var newOSDisk = azure.Disks.Define(managedNewOSDiskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithLinuxFromSnapshot(osSnapshot)
                        .WithSizeInGB(100)
                        .Create();

                Utilities.Log("Created managed OS disk [from snapshot]");

                Utilities.Log("Creating managed data snapshot [from managed data disk]");

                // Create a managed snapshot for a data disk
                var managedDataDiskSnapshotName = SdkContext.RandomResourceName("dsk" + "-", 10);
                var dataSnapshot = azure.Snapshots.Define(managedDataDiskSnapshotName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithDataFromDisk(dataDisks[0])
                        .WithSku(DiskSkuTypes.StandardLRS)
                        .Create();

                Utilities.Log("Created managed data snapshot [from managed data disk]");

                Utilities.Log("Creating managed data disk [from managed snapshot]");

                // Create a managed disk from the managed snapshot for the data disk
                var managedNewDataDiskName = SdkContext.RandomResourceName("dsk" + "-", 10);
                var newDataDisk = azure.Disks.Define(managedNewDataDiskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                        .FromSnapshot(dataSnapshot)
                        .Create();

                Utilities.Log("Created managed data disk [from managed snapshot]");

                Utilities.Log("Creating VM [with specialized OS managed disk]");

                var linuxVm6Name = SdkContext.RandomResourceName("vm" + "-", 10);
                var linuxVM6 = azure.VirtualMachines.Define(linuxVm6Name)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithSpecializedOSDisk(newOSDisk, OperatingSystemTypes.Linux)
                        .WithExistingDataDisk(newDataDisk)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [with specialized OS managed disk]");

                // ::== Migrate a VM to managed disks with a single reboot

                Utilities.Log("Creating VM [with un-managed disk for migration]");

                var linuxVM7Name = SdkContext.RandomResourceName("vm" + "-", 10);
                var linuxVM7Pip = SdkContext.RandomResourceName("pip" + "-", 18);
                var linuxVM7 = azure.VirtualMachines.Define(linuxVM7Name)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(linuxVM7Pip)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("tirekicker")
                        .WithSsh(sshkey)
                        .WithUnmanagedDisks() // uses storage accounts
                        .WithNewUnmanagedDataDisk(100)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created VM [with un-managed disk for migration]");

                Utilities.Log("De-allocating VM :" + linuxVM7.Id);

                linuxVM7.Deallocate();

                Utilities.Log("De-allocated VM :" + linuxVM7.Id);

                Utilities.Log("Migrating VM");

                linuxVM7.ConvertToManaged();

                Utilities.Log("Migrated VM");
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
                    Utilities.Log("Did not create any resources in IAzure. No clean up is necessary");
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

        private static IVirtualMachine PrepareSpecializedUnmanagedVirtualMachine(IAzure azure, Region region, string rgName)
        {
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";
            var linuxVmName1 = SdkContext.RandomResourceName("vm" + "-", 10);
            var publicIpDnsLabel = SdkContext.RandomResourceName("pip" + "-", 20);

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
                    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                    .Create();

            // De-provision the virtual machine
            Utilities.DeprovisionAgentInLinuxVM(linuxVM.GetPrimaryPublicIPAddress().Fqdn, 22, userName, password);
            Utilities.Log("Deallocate VM: " + linuxVM.Id);
            linuxVM.Deallocate();
            Utilities.Log("Deallocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);
            Utilities.Log("Generalize VM: " + linuxVM.Id);
            linuxVM.Generalize();
            Utilities.Log("Generalized VM: " + linuxVM.Id);
            return linuxVM;
        }

        private static IVirtualMachine PrepareSpecializedManagedVirtualMachine(IAzure azure, Region region, string rgName)
        {
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";
            var linuxVmName1 = SdkContext.RandomResourceName("vm" + "-", 10);
            var publicIpDnsLabel = SdkContext.RandomResourceName("pip" + "-", 20);

            var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword(password)
                    .WithNewDataDisk(100)
                    .WithNewDataDisk(200)
                    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                    .Create();

            // De-provision the virtual machine
            Utilities.DeprovisionAgentInLinuxVM(linuxVM.GetPrimaryPublicIPAddress().Fqdn, 22, userName, password);
            Utilities.Log("Deallocate VM: " + linuxVM.Id);
            linuxVM.Deallocate();
            Utilities.Log("Deallocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);
            Utilities.Log("Generalize VM: " + linuxVM.Id);
            linuxVM.Generalize();
            Utilities.Log("Generalized VM: " + linuxVM.Id);
            return linuxVM;
        }
        
        private static INetwork PrepareNetwork(IAzure azure, Region region, string rgName)
        {
            var vnetName = SdkContext.RandomResourceName("vnet", 24);

            var network = azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithAddressSpace("172.16.0.0/16")
                    .DefineSubnet("subnet1")
                    .WithAddressPrefix("172.16.1.0/24")
                    .Attach()
                    .Create();
            return network;
        }

        private static ILoadBalancer PrepareLoadBalancer(IAzure azure, Region region, string rgName)
        {
            var loadBalancerName1 = SdkContext.RandomResourceName("intlb" + "-", 18);
            var frontendName = loadBalancerName1 + "-FE1";
            var backendPoolName1 = loadBalancerName1 + "-BAP1";
            var backendPoolName2 = loadBalancerName1 + "-BAP2";
            var httpProbe = "httpProbe";
            var httpsProbe = "httpsProbe";
            var httpLoadBalancingRule = "httpRule";
            var httpsLoadBalancingRule = "httpsRule";
            var natPool50XXto22 = "natPool50XXto22";
            var natPool60XXto23 = "natPool60XXto23";
            var publicIpName = "pip-" + loadBalancerName1;

            var publicIpAddress = azure.PublicIPAddresses.Define(publicIpName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithLeafDomainLabel(publicIpName)
                .Create();
            var loadBalancer = azure.LoadBalancers.Define(loadBalancerName1)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    // Add two rules that uses above backend and probe
                    .DefineLoadBalancingRule(httpLoadBalancingRule)
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromFrontend(frontendName)
                        .FromFrontendPort(80)
                        .ToBackend(backendPoolName1)
                        .WithProbe(httpProbe)
                        .Attach()
                    .DefineLoadBalancingRule(httpsLoadBalancingRule)
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromFrontend(frontendName)
                        .FromFrontendPort(443)
                        .ToBackend(backendPoolName2)
                        .WithProbe(httpsProbe)
                        .Attach()
                    // Add nat pools to enable direct VM connectivity for
                    //  SSH to port 22 and TELNET to port 23
                    .DefineInboundNatPool(natPool50XXto22)
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromFrontend(frontendName)
                        .FromFrontendPortRange(5000, 5099)
                        .ToBackendPort(22)
                        .Attach()
                    .DefineInboundNatPool(natPool60XXto23)
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromFrontend(frontendName)
                        .FromFrontendPortRange(6000, 6099)
                        .ToBackendPort(23)
                        .Attach()
                    // Explicitly define the frontend
                    .DefinePublicFrontend(frontendName)
                        .WithExistingPublicIPAddress(publicIpAddress)
                        .Attach()
                    // Add two probes one per rule
                    .DefineHttpProbe(httpProbe)
                        .WithRequestPath("/")
                        .WithPort(80)
                        .Attach()
                    .DefineHttpProbe(httpsProbe)
                        .WithRequestPath("/")
                        .WithPort(443)
                        .Attach()
                    .Create();
            return loadBalancer;
        }
    }
}