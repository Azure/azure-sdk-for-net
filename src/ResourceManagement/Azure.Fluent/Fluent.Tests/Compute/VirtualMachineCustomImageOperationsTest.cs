// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineCustomImageOperationsTest
    {
        private readonly Region Location = Region.USWestCentral;

        [Fact]
        public void CanCreateImageFromNativeVhd()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vhdBasedImageName = SdkContext.RandomResourceName("img", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var linuxVM = PrepareGeneralizedVmWith2EmptyDataDisks(rgName,
                            SdkContext.RandomResourceName("muldvm", 15),
                            Location,
                            computeManager);
                    //
                    var creatableDisk = computeManager
                            .VirtualMachineCustomImages
                            .Define(vhdBasedImageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromVhd(linuxVM.OsUnmanagedDiskVhdUri, OperatingSystemStateTypes.Generalized)
                            .WithOSDiskCaching(linuxVM.OsDiskCachingType);
                    foreach (var disk in linuxVM.UnmanagedDataDisks.Values)
                    {
                        creatableDisk.DefineDataDiskImage()
                                .WithLun(disk.Lun)
                                .FromVhd(disk.VhdUri)
                                .WithDiskCaching(disk.CachingType)
                                .WithDiskSizeInGB(disk.Size + 10) // Resize each data disk image by +10GB
                                .Attach();
                    }
                    var customImage = creatableDisk.Create();
                    Assert.NotNull(customImage.Id);
                    Assert.Equal(customImage.Name, vhdBasedImageName);
                    Assert.False(customImage.IsCreatedFromVirtualMachine);
                    Assert.Null(customImage.SourceVirtualMachineId);
                    Assert.NotNull(customImage.OsDiskImage);
                    Assert.NotNull(customImage.OsDiskImage.BlobUri);
                    Assert.Equal(customImage.OsDiskImage.Caching, CachingTypes.ReadWrite);
                    Assert.Equal(customImage.OsDiskImage.OsState, OperatingSystemStateTypes.Generalized);
                    Assert.Equal(customImage.OsDiskImage.OsType, OperatingSystemTypes.Linux);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(customImage.DataDiskImages.Count, linuxVM.UnmanagedDataDisks.Count);
                    foreach (ImageDataDisk diskImage in customImage.DataDiskImages.Values)
                    {
                        IVirtualMachineUnmanagedDataDisk matchedDisk = null;
                        foreach (var vmDisk in linuxVM.UnmanagedDataDisks.Values)
                        {
                            if (vmDisk.Lun == diskImage.Lun)
                            {
                                matchedDisk = vmDisk;
                                break;
                            }
                        }
                        Assert.NotNull(matchedDisk);
                        Assert.Equal(matchedDisk.CachingType, diskImage.Caching);
                        Assert.Equal(matchedDisk.VhdUri, diskImage.BlobUri);
                        Assert.Equal((long)matchedDisk.Size + 10, (long)diskImage.DiskSizeGB);
                    }
                    var image = computeManager
                            .VirtualMachineCustomImages
                            .GetByGroup(rgName, vhdBasedImageName);
                    Assert.NotNull(image);
                    var images = computeManager
                            .VirtualMachineCustomImages
                            .ListByGroup(rgName);
                    Assert.True(images.Count > 0);

                    // Create virtual machine from custom image
                    //
                    var virtualMachine = computeManager.VirtualMachines
                            .Define(SdkContext.RandomResourceName("cusvm", 15))
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithLinuxCustomImage(image.Id)
                            .WithRootUsername("javauser")
                            .WithRootPassword("12NewPA$$w0rd!")
                            .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    var dataDisks = virtualMachine.DataDisks;
                    Assert.NotNull(dataDisks);
                    Assert.Equal(dataDisks.Count, image.DataDiskImages.Count);
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
        public void CanCreateImageByCapturingVM()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = SdkContext.RandomResourceName("vm67-", 20);
                var imageName = SdkContext.RandomResourceName("img", 15);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                var vm = PrepareGeneralizedVmWith2EmptyDataDisks(rgName, vmName, Location, computeManager);

                try
                {

                    var customImage = computeManager.VirtualMachineCustomImages
                            .Define(imageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .FromVirtualMachine(vm.Id)
                            .Create();

                    Assert.True(customImage.Name.Equals(imageName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(customImage.OsDiskImage);
                    Assert.Equal(customImage.OsDiskImage.OsState, OperatingSystemStateTypes.Generalized);
                    Assert.Equal(customImage.OsDiskImage.OsType, OperatingSystemTypes.Linux);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(customImage.DataDiskImages.Count, 2);
                    Assert.NotNull(customImage.SourceVirtualMachineId);
                    Assert.True(customImage.SourceVirtualMachineId.Equals(vm.Id, StringComparison.OrdinalIgnoreCase));

                    foreach (var vmDisk in vm.UnmanagedDataDisks.Values)
                    {
                        Assert.True(customImage.DataDiskImages.ContainsKey(vmDisk.Lun));
                        var diskImage = customImage.DataDiskImages[vmDisk.Lun];
                        Assert.Equal(diskImage.Caching, vmDisk.CachingType);
                        Assert.Equal((long)diskImage.DiskSizeGB, vmDisk.Size);
                        Assert.NotNull(diskImage.BlobUri);
                        diskImage.BlobUri.Equals(vmDisk.VhdUri, StringComparison.OrdinalIgnoreCase);
                    }

                    customImage = computeManager.VirtualMachineCustomImages.GetByGroup(rgName, imageName);
                    Assert.NotNull(customImage);
                    Assert.NotNull(customImage.Inner);
                    computeManager.VirtualMachineCustomImages.DeleteById(customImage.Id);
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
        public void CanCreateImageFromManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var vmName = SdkContext.RandomResourceName("vm7-", 20);
                var uname = "juser";
                var password = "123tEst!@|ac";
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");
                try
                {
                    var nativeVm = computeManager.VirtualMachines
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
                            .DefineUnmanagedDataDisk("disk1")
                                .WithNewVhd(100)
                                .WithCaching(CachingTypes.ReadWrite)
                                .Attach()
                            .WithNewUnmanagedDataDisk(100)
                            .WithSize(VirtualMachineSizeTypes.StandardDS5V2)
                            .WithNewStorageAccount(SdkContext.RandomResourceName("stg", 17))
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    Assert.False(nativeVm.IsManagedDiskEnabled);
                    var osVhdUri = nativeVm.OsUnmanagedDiskVhdUri;
                    Assert.NotNull(osVhdUri);
                    var dataDisks = nativeVm.UnmanagedDataDisks;
                    Assert.Equal(dataDisks.Count, 2);

                    computeManager.VirtualMachines.DeleteById(nativeVm.Id);

                    var osDiskName = SdkContext.RandomResourceName("dsk", 15);
                    // Create managed disk with Os from vm's Os disk
                    //
                    var managedOsDisk = computeManager.Disks.Define(osDiskName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromVhd(osVhdUri)
                            .Create();

                    // Create managed disk with Data from vm's lun0 data disk
                    //
                    var dataDiskName1 = SdkContext.RandomResourceName("dsk", 15);
                    var vmNativeDataDisk1 = dataDisks[0];
                    var managedDataDisk1 = computeManager.Disks.Define(dataDiskName1)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithData()
                            .FromVhd(vmNativeDataDisk1.VhdUri)
                            .Create();

                    // Create managed disk with Data from vm's lun1 data disk
                    //
                    var dataDiskName2 = SdkContext.RandomResourceName("dsk", 15);
                    var vmNativeDataDisk2 = dataDisks[1];
                    var managedDataDisk2 = computeManager.Disks.Define(dataDiskName2)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithData()
                            .FromVhd(vmNativeDataDisk2.VhdUri)
                            .Create();

                    // Create an image from the above managed disks
                    // Note that this is not a direct user scenario, but including this as per CRP team request
                    //
                    var imageName = SdkContext.RandomResourceName("img", 15);
                    var customImage = computeManager.VirtualMachineCustomImages.Define(imageName)
                            .WithRegion(Location)
                            .WithNewResourceGroup(rgName)
                            .WithLinuxFromDisk(managedOsDisk, OperatingSystemStateTypes.Generalized)
                            .DefineDataDiskImage()
                                .WithLun(vmNativeDataDisk1.Lun)
                                .FromManagedDisk(managedDataDisk1)
                                .WithDiskCaching(vmNativeDataDisk1.CachingType)
                                .WithDiskSizeInGB(vmNativeDataDisk1.Size + 10)
                                .Attach()
                            .DefineDataDiskImage()
                                .WithLun(vmNativeDataDisk2.Lun)
                                .FromManagedDisk(managedDataDisk2)
                                .WithDiskSizeInGB(vmNativeDataDisk2.Size + 10)
                                .Attach()
                            .Create();

                    Assert.NotNull(customImage);
                    Assert.True(customImage.Name.Equals(imageName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(customImage.OsDiskImage);
                    Assert.Equal(customImage.OsDiskImage.OsState, OperatingSystemStateTypes.Generalized);
                    Assert.Equal(customImage.OsDiskImage.OsType, OperatingSystemTypes.Linux);
                    Assert.NotNull(customImage.DataDiskImages);
                    Assert.Equal(customImage.DataDiskImages.Count, 2);
                    Assert.Null(customImage.SourceVirtualMachineId);

                    Assert.True(customImage.DataDiskImages.ContainsKey(vmNativeDataDisk1.Lun));
                    Assert.Equal(customImage.DataDiskImages[vmNativeDataDisk1.Lun].Caching, vmNativeDataDisk1.CachingType);
                    Assert.True(customImage.DataDiskImages.ContainsKey(vmNativeDataDisk2.Lun));
                    Assert.Equal(customImage.DataDiskImages[vmNativeDataDisk2.Lun].Caching, CachingTypes.None);

                    foreach (var vmDisk in dataDisks.Values)
                    {
                        Assert.True(customImage.DataDiskImages.ContainsKey(vmDisk.Lun));
                        var diskImage = customImage.DataDiskImages[vmDisk.Lun];
                        Assert.Equal((long)diskImage.DiskSizeGB, vmDisk.Size + 10);
                        Assert.Null(diskImage.BlobUri);
                        Assert.NotNull(diskImage.ManagedDisk);
                        Assert.True(diskImage.ManagedDisk.Id.Equals(managedDataDisk1.Id, StringComparison.OrdinalIgnoreCase)
                                || diskImage.ManagedDisk.Id.Equals(managedDataDisk2.Id, StringComparison.OrdinalIgnoreCase));
                    }
                    computeManager.Disks.DeleteById(managedOsDisk.Id);
                    computeManager.Disks.DeleteById(managedDataDisk1.Id);
                    computeManager.Disks.DeleteById(managedDataDisk2.Id);
                    computeManager.VirtualMachineCustomImages.DeleteById(customImage.Id);
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

        private IVirtualMachine PrepareGeneralizedVmWith2EmptyDataDisks(string rgName,
                                                     string vmName,
                                                     Region Location,
                                                     IComputeManager computeManager)
        {
            var uname = "javauser";
            var password = "12NewPA$$w0rd!";
            KnownLinuxVirtualMachineImage linuxImage = KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts;
            var publicIPDnsLabel = SdkContext.RandomResourceName("pip", 20);

            var virtualMachine = computeManager.VirtualMachines
                    .Define(vmName)
                    .WithRegion(Location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(publicIPDnsLabel)
                    .WithPopularLinuxImage(linuxImage)
                    .WithRootUsername(uname)
                    .WithRootPassword(password)
                    .WithUnmanagedDisks()
                    .DefineUnmanagedDataDisk("disk-1")
                        .WithNewVhd(30)
                        .WithCaching(CachingTypes.ReadWrite)
                        .Attach()
                    .DefineUnmanagedDataDisk("disk-2")
                        .WithNewVhd(60)
                        .WithCaching(CachingTypes.ReadOnly)
                        .Attach()
                    .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                    .WithNewStorageAccount(SdkContext.RandomResourceName("stg", 17))
                    .WithOSDiskCaching(CachingTypes.ReadWrite)
                    .Create();
            //
            TestHelper.DeprovisionAgentInLinuxVM(virtualMachine.GetPrimaryPublicIPAddress().Fqdn, 22, uname, password);
            virtualMachine.Deallocate();
            virtualMachine.Generalize();
            return virtualMachine;
        }
    }
}
