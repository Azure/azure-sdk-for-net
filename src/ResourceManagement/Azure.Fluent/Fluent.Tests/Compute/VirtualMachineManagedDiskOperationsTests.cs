// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineManagedDiskOperationsTests
    {
        private readonly Region Location = Region.USWestCentral;
        private readonly KnownLinuxVirtualMachineImage LinuxImage = KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts;

        [Fact]
        public void CanCreateVirtualMachineFromPIRImageWithManagedOsDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName1 = "myvm1";
                var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);
                var uname = "juser";
                var password = "123tEst!@|ac";
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var virtualMachine = computeManager.VirtualMachines
                            .Define(vmName1)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                            .WithPopularLinuxImage(LinuxImage)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();
                    // Ensure default to managed disk
                    //
                    Assert.True(virtualMachine.IsManagedDiskEnabled);
                    // Validate caching, size and the default storage account type set for the managed disk
                    // backing os disk
                    //
                    Assert.NotNull(virtualMachine.OSDiskStorageAccountType);
                    Assert.Equal(virtualMachine.OSDiskCachingType, CachingTypes.ReadWrite);
                    Assert.Equal(virtualMachine.Size, VirtualMachineSizeTypes.StandardD5V2);
                    // Validate the implicit managed disk created by CRP to back the os disk
                    //
                    Assert.NotNull(virtualMachine.OSDiskId);
                    var osDisk = computeManager.Disks.GetById(virtualMachine.OSDiskId);
                    Assert.True(osDisk.IsAttachedToVirtualMachine);
                    Assert.Equal(osDisk.OSType, OperatingSystemTypes.Linux);
                    // Check the auto created public ip
                    //
                    var publicIPId = virtualMachine.GetPrimaryPublicIPAddressId();
                    Assert.NotNull(publicIPId);
                    // Validates the options which are valid only for native disks
                    //
                    Assert.Null(virtualMachine.OSUnmanagedDiskVhdUri);
                    Assert.NotNull(virtualMachine.UnmanagedDataDisks);
                    Assert.True(virtualMachine.UnmanagedDataDisks.Count == 0);
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateUpdateVirtualMachineWithEmptyManagedDataDisks()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);
                var uname = "juser";
                var password = "123tEst!@|ac";
                // Create with implicit + explicit empty disks, check default and override
                //
                var vmName1 = "myvm1";
                var explicitlyCreatedEmptyDiskName1 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName2 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName3 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var creatableEmptyDisk1 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk2 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk3 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName3)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var virtualMachine = computeManager.VirtualMachines
                            .Define(vmName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                            .WithPopularLinuxImage(LinuxImage)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            // Start: Add 5 empty managed disks
                            .WithNewDataDisk(100)                                             // CreateOption: EMPTY
                            .WithNewDataDisk(100, 1, CachingTypes.ReadOnly)                  // CreateOption: EMPTY
                            .WithNewDataDisk(creatableEmptyDisk1)                             // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk2, 2, CachingTypes.None)       // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk3, 3, CachingTypes.None)       // CreateOption: ATTACH
                                                                                              // End : Add 5 empty managed disks
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.True(virtualMachine.IsManagedDiskEnabled);
                    // There should not be any un-managed data disks
                    //
                    Assert.NotNull(virtualMachine.UnmanagedDataDisks);
                    Assert.Equal(virtualMachine.UnmanagedDataDisks.Count, 0);
                    // Validate the managed data disks
                    //
                    var dataDisks = virtualMachine.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.True(dataDisks.Count == 5);
                    Assert.True(dataDisks.ContainsKey(1));
                    var dataDiskLun1 = dataDisks[1];
                    Assert.NotNull(dataDiskLun1.Id);
                    Assert.Equal(dataDiskLun1.CachingType, CachingTypes.ReadOnly);
                    Assert.Equal(dataDiskLun1.Size, 100);

                    Assert.True(dataDisks.ContainsKey(2));
                    var dataDiskLun2 = dataDisks[2];
                    Assert.NotNull(dataDiskLun2.Id);
                    Assert.Equal(dataDiskLun2.CachingType, CachingTypes.None);
                    Assert.Equal(dataDiskLun2.Size, 150);

                    Assert.True(dataDisks.ContainsKey(3));
                    var dataDiskLun3 = dataDisks[3];
                    Assert.NotNull(dataDiskLun3.Id);
                    Assert.Equal(dataDiskLun3.CachingType, CachingTypes.None);
                    Assert.Equal(dataDiskLun3.Size, 150);
                    // Validate the defaults assigned
                    //
                    foreach (var dataDisk in dataDisks.Values)
                    {
                        if (dataDisk.Lun != 1 && dataDisk.Lun != 2 && dataDisk.Lun != 3)
                        {
                            Assert.Equal(dataDisk.CachingType, CachingTypes.ReadWrite);
                            Assert.Equal(dataDisk.StorageAccountType, StorageAccountTypes.StandardLRS);
                        }
                    }

                    // Updating and adding disk as part of VM Update seems consistency failing, CRP is aware of
                    // this, hence until it is fixed comment-out the test
                    //
                    //        {
                    //            "startTime": "2017-01-26T05:48:59.9290573+00:00",
                    //                "endTime": "2017-01-26T05:49:02.2884052+00:00",
                    //                "status": "Failed",
                    //                "error": {
                    //            "code": "InternalExecutionError",
                    //                    "message": "An internal execution error occurred."
                    //        },
                    //            "name": "bc8072a7-38bb-445b-ae59-f16cf125342c"
                    //        }
                    //
                    //        virtualMachine.Deallocate();
                    //
                    //        virtualMachine.Update()
                    //                .WithDataDiskUpdated(1, 200)
                    //                .WithDataDiskUpdated(2, 200, CachingTypes.ReadWrite)
                    //                .WithNewDataDisk(60)
                    //                .Apply();
                    //
                    //        Assert.True(virtualMachine.IsManagedDiskEnabled());
                    //        // There should not be any un-managed data disks
                    //        //
                    //        Assert.NotNull(virtualMachine.UnmanagedDataDisks());
                    //        Assert.Equal(virtualMachine.UnmanagedDataDisks().Count, 0);
                    //
                    //        // Validate the managed data disks
                    //        //
                    //         dataDisks = virtualMachine.DataDisks;
                    //        Assert.NotNull(dataDisks);
                    //        Assert.True(dataDisks.Count == 6);
                    //        Assert.True(dataDisks.ContainsKey(1));
                    //        dataDiskLun1 = dataDisks[1];
                    //        Assert.NotNull(dataDiskLun1.Id);
                    //        Assert.Equal(dataDiskLun1.CachingType(), CachingTypes.ReadOnly);
                    //        Assert.Equal(dataDiskLun1.Count, 200);  // 100 -> 200
                    //
                    //        Assert.True(dataDisks.ContainsKey(2));
                    //        dataDiskLun2 = dataDisks[2];
                    //        Assert.NotNull(dataDiskLun2.Id);
                    //        Assert.Equal(dataDiskLun2.CachingType(), CachingTypes.ReadWrite); // None -> ReadWrite
                    //        Assert.Equal(dataDiskLun2.Count, 200);  // 150 -> 200
                    //
                    //        Assert.True(dataDisks.ContainsKey(3));
                    //        dataDiskLun3 = dataDisks[3];
                    //        Assert.NotNull(dataDiskLun3.Id);
                    //        Assert.Equal(dataDiskLun3.CachingType(), CachingTypes.None);
                    //        Assert.Equal(dataDiskLun3.Count, 150);
                    //
                    //        // Ensure defaults of other disks are not affected
                    //        foreach (VirtualMachineDataDisk dataDisk  in  dataDisks.Values()) {
                    //            if (dataDisk.Lun != 1 && dataDisk.Lun != 3) {
                    //                Assert.Equal(dataDisk.CachingType(), CachingTypes.ReadWrite);
                    //                Assert.Equal(dataDisk.StorageAccountType(), StorageAccountTypes.STANDARD_LRS);
                    //            }
                    //        }
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateVirtualMachineFromCustomImageWithManagedDisks()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);
                var uname = "juser";
                var password = "123tEst!@|ac";
                // Create with implicit + explicit empty disks, check default and override
                //
                var vmName1 = "myvm1";
                var explicitlyCreatedEmptyDiskName1 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName2 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName3 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var creatableEmptyDisk1 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk2 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk3 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName3)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var virtualMachine1 = computeManager.VirtualMachines
                            .Define(vmName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                            .WithPopularLinuxImage(LinuxImage)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            // Start: Add bunch of empty managed disks
                            .WithNewDataDisk(100)                                             // CreateOption: EMPTY
                            .WithNewDataDisk(100, 1, CachingTypes.ReadOnly)                   // CreateOption: EMPTY
                            .WithNewDataDisk(creatableEmptyDisk1)                             // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk2, 2, CachingTypes.None)       // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk3, 3, CachingTypes.None)       // CreateOption: ATTACH
                                                                                              // End : Add bunch of empty managed disks
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();
                    TestHelper.Delay(60 * 1000); // Wait for some time to ensure vm is publicly accessible
                    TestHelper.DeprovisionAgentInLinuxVM(virtualMachine1.GetPrimaryPublicIPAddress().Fqdn,
                            22,
                            uname,
                            password);

                    virtualMachine1.Deallocate();
                    virtualMachine1.Generalize();

                    var customImageName = SdkContext.RandomResourceName("img-", 10);
                    var customImage = computeManager.VirtualMachineCustomImages.Define(customImageName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .FromVirtualMachine(virtualMachine1)
                            .Create();
                    Assert.NotNull(customImage);
                    Assert.NotNull(customImage.SourceVirtualMachineId);
                    Assert.True(customImage.SourceVirtualMachineId.Equals(virtualMachine1.Id, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(customImage.OSDiskImage);
                    Assert.Equal(customImage.OSDiskImage.OsState, OperatingSystemStateTypes.Generalized);
                    Assert.Equal(customImage.OSDiskImage.OsType, OperatingSystemTypes.Linux);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(customImage.DataDiskImages.Count, 5);
                    foreach (ImageDataDisk imageDataDisk in customImage.DataDiskImages.Values)
                    {
                        Assert.Null(imageDataDisk.BlobUri);
                        Assert.NotNull(imageDataDisk.ManagedDisk.Id);
                    }

                    // Create virtual machine from the custom image
                    // This one relies on CRP's capability to create implicit data disks from the virtual machine
                    // image data disk images.
                    //
                    var vmName2 = "myvm2";
                    var virtualMachine2 = computeManager.VirtualMachines
                            .Define(vmName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLinuxCustomImage(customImage.Id)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            // No explicit data disks, let CRP create it from the image's data disk images
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    var dataDisks = virtualMachine2.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.Equal(dataDisks.Count, customImage.DataDiskImages.Count);
                    foreach (var imageDataDisk in customImage.DataDiskImages.Values)
                    {
                        Assert.True(dataDisks.ContainsKey(imageDataDisk.Lun));
                        var dataDisk = dataDisks[imageDataDisk.Lun];
                        Assert.Equal(dataDisk.CachingType, imageDataDisk.Caching);
                        // Fails with new service.
                        //Assert.Equal(dataDisk.Size, (long)imageDataDisk.DiskSizeGB.Value);
                    }

                    // Create virtual machine from the custom image
                    // This one override the size and caching type of data disks from data disk images and
                    // adds one additional disk
                    //

                    var vmName3 = "myvm3";
                    var creatableVirtualMachine3 = computeManager.VirtualMachines
                            .Define(vmName3)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLinuxCustomImage(customImage.Id)
                            .WithRootUsername(uname)
                            .WithRootPassword(password);
                    foreach (var dataDiskImage in customImage.DataDiskImages.Values)
                    {
                        // Explicitly override the properties of the data disks created from disk image
                        //
                        // CreateOption: FROM_IMAGE
                        var dataDisk = dataDisks[dataDiskImage.Lun];
                        creatableVirtualMachine3.WithNewDataDiskFromImage(dataDiskImage.Lun,
                                dataDisk.Size + 10,    // increase size by 10 GB
                                CachingTypes.ReadOnly);
                    }
                    var virtualMachine3 = creatableVirtualMachine3
                            .WithNewDataDisk(200)                               // CreateOption: EMPTY
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    dataDisks = virtualMachine3.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.Equal(dataDisks.Count, customImage.DataDiskImages.Count + 1 /* count one extra empty disk */);
                    foreach (var imageDataDisk in customImage.DataDiskImages.Values)
                    {
                        Assert.True(dataDisks.ContainsKey(imageDataDisk.Lun));
                        var dataDisk = dataDisks[imageDataDisk.Lun];
                        Assert.Equal(dataDisk.CachingType, CachingTypes.ReadOnly);
                        // Fails with new service.
                        //Assert.Equal(dataDisk.Size, (long)imageDataDisk.DiskSizeGB + 10);
                    }
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanUpdateVirtualMachineByAddingAndRemovingManagedDisks()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);
                var uname = "juser";
                var password = "123tEst!@|ac";
                // Create with implicit + explicit empty disks, check default and override
                //
                var vmName1 = "myvm1";
                var explicitlyCreatedEmptyDiskName1 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName2 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var explicitlyCreatedEmptyDiskName3 = SdkContext.RandomResourceName(vmName1 + "_mdisk_", 25);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {

                    var resourceGroup = resourceManager.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var creatableEmptyDisk1 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk2 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var creatableEmptyDisk3 = computeManager.Disks
                            .Define(explicitlyCreatedEmptyDiskName3)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(150);

                    var virtualMachine1 = computeManager.VirtualMachines
                            .Define(vmName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                            .WithPopularLinuxImage(LinuxImage)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            // Start: Add bunch of empty managed disks
                            .WithNewDataDisk(100)                                             // CreateOption: EMPTY
                            .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)                 // CreateOption: EMPTY
                            .WithNewDataDisk(creatableEmptyDisk1)                             // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk2, 2, CachingTypes.None)       // CreateOption: ATTACH
                            .WithNewDataDisk(creatableEmptyDisk3, 3, CachingTypes.None)       // CreateOption: ATTACH
                                                                                              // End : Add bunch of empty managed disks
                            .WithDataDiskDefaultCachingType(CachingTypes.ReadOnly)
                            .WithDataDiskDefaultStorageAccountType(StorageAccountTypes.StandardLRS)
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    virtualMachine1.Update()
                            .WithoutDataDisk(1)
                            .WithNewDataDisk(100, 6, CachingTypes.ReadWrite)                 // CreateOption: EMPTY
                            .Apply();

                    var dataDisks = virtualMachine1.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.Equal(dataDisks.Count, 5); // Removed one added another
                    Assert.True(dataDisks.ContainsKey(6));
                    Assert.False(dataDisks.ContainsKey(1));
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanCreateVirtualMachineByAttachingManagedOsDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var uname = "juser";
                var password = "123tEst!@|ac";
                var vmName = "myvm6";
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    // Creates a native virtual machine
                    //
                    var nativeVM = computeManager.VirtualMachines
                            .Define(vmName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLatestLinuxImage("Canonical", "UbuntuServer", "14.04.2-LTS")
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithUnmanagedDisks()                  /* UN-MANAGED OS and DATA DISKS */
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithNewStorageAccount(SdkContext.RandomResourceName("stg", 17))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.False(nativeVM.IsManagedDiskEnabled);
                    var osVhdUri = nativeVM.OSUnmanagedDiskVhdUri;
                    Assert.NotNull(osVhdUri);

                    computeManager.VirtualMachines.DeleteById(nativeVM.Id);

                    var diskName = SdkContext.RandomResourceName("dsk-", 15);
                    var osDisk = computeManager.Disks.Define(diskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(rgName)
                            .WithLinuxFromVhd(osVhdUri)
                            .Create();

                    // Creates a managed virtual machine
                    //
                    var managedVM = computeManager.VirtualMachines
                            .Define(vmName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithSpecializedOSDisk(osDisk, OperatingSystemTypes.Linux)
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.True(managedVM.IsManagedDiskEnabled);
                    Assert.True(managedVM.OSDiskId.Equals(osDisk.Id, StringComparison.OrdinalIgnoreCase));
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        public void CanCreateVirtualMachineWithManagedDiskInManagedAvailabilitySet()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var availSetName = SdkContext.RandomResourceName("av-", 15);
                var uname = "juser";
                var password = "123tEst!@|ac";
                var vmName = "myvm6";
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var managedVM = computeManager.VirtualMachines
                            .Define(vmName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(LinuxImage)
                            .WithRootUsername(uname)
                            .WithRootPassword(password)
                            .WithNewDataDisk(100)
                            .WithNewDataDisk(100, 1, CachingTypes.ReadOnly)
                            .WithNewDataDisk(100, 2, CachingTypes.ReadWrite, StorageAccountTypes.StandardLRS)
                            .WithNewAvailabilitySet(availSetName)           // Default to managed availability set
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.NotNull(managedVM.AvailabilitySetId);
                    var availabilitySet = computeManager.AvailabilitySets.GetById(managedVM.AvailabilitySetId);
                    Assert.True(availabilitySet.VirtualMachineIds.Count > 0);
                    Assert.Equal(availabilitySet.Sku, AvailabilitySetSkuTypes.Managed);
                }
                finally
                {
                    try
                    { 
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
