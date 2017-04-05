// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class ManagedDiskOperationsTests
    {
        private readonly string Location = Region.USWestCentral.Name;

        [Fact]
        public void CanOperateOnEmptyManagedDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var diskName = SdkContext.RandomResourceName("md-empty-", 20);
                var updateTo = DiskSkuTypes.StandardLRS;
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    // Create an empty managed disk
                    //
                    var disk = computeManager.Disks
                            .Define(diskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .WithSizeInGB(100)
                            // Start option
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .WithTag("tkey1", "tval1")
                            // End option
                            .Create();

                    Assert.NotNull(disk.Id);
                    Assert.True(disk.Name.Equals(diskName, StringComparison.OrdinalIgnoreCase));
                    Assert.True(disk.Sku == DiskSkuTypes.StandardLRS);
                    Assert.Equal(disk.CreationMethod, DiskCreateOption.Empty);
                    Assert.False(disk.IsAttachedToVirtualMachine);
                    Assert.Equal(disk.SizeInGB, 100);
                    Assert.Null(disk.OsType);
                    Assert.NotNull(disk.Source);
                    Assert.Equal(disk.Source.Type, CreationSourceType.Empty);
                    Assert.Null(disk.Source.SourceId());

                    // Resize and change storage account type
                    //
                    disk = disk.Update()
                            .WithSku(updateTo)
                            .WithSizeInGB(200)
                            .Apply();

                    Assert.Equal(disk.Sku, updateTo);
                    Assert.Equal(disk.SizeInGB, 200);

                    disk = computeManager.Disks.GetByResourceGroup(disk.ResourceGroupName, disk.Name);
                    Assert.NotNull(disk);

                    var myDisks = computeManager.Disks.ListByResourceGroup(disk.ResourceGroupName);
                    Assert.NotNull(myDisks);
                    Assert.True(myDisks.Count() > 0);

                    var sasUrl = disk.GrantAccess(100);
                    Assert.True(sasUrl != null && sasUrl != "");

                    // Requires access to be revoked before deleting the disk
                    //
                    disk.RevokeAccess();
                    computeManager.Disks.DeleteById(disk.Id);

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
        public void CanOperateOnManagedDiskFromDisk()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var diskName1 = SdkContext.RandomResourceName("md-1", 20);
                var diskName2 = SdkContext.RandomResourceName("md-2", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    // Create an empty  managed disk
                    //
                    var emptyDisk = computeManager.Disks
                            .Define(diskName1)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .WithSizeInGB(100)
                            .Create();

                    // Create a managed disk from existing managed disk
                    //
                    var disk = computeManager.Disks
                            .Define(diskName2)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup.Name)
                            .WithData()
                            .FromDisk(emptyDisk)
                            // Start Option
                            .WithSizeInGB(200)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            // End Option
                            .Create();

                    disk = computeManager.Disks.GetById(disk.Id);

                    Assert.NotNull(disk.Id);
                    Assert.True(disk.Name.Equals(diskName2, StringComparison.OrdinalIgnoreCase));
                    Assert.True(disk.Sku == DiskSkuTypes.StandardLRS);
                    Assert.Equal(disk.CreationMethod, DiskCreateOption.Copy);
                    Assert.False(disk.IsAttachedToVirtualMachine);
                    Assert.Equal(disk.SizeInGB, 200);
                    Assert.Null(disk.OsType);
                    Assert.NotNull(disk.Source);
                    Assert.Equal(disk.Source.Type, CreationSourceType.CopiedFromDisk);
                    Assert.True(disk.Source.SourceId().Equals(emptyDisk.Id, StringComparison.OrdinalIgnoreCase));

                    computeManager.Disks.DeleteById(emptyDisk.Id);
                    computeManager.Disks.DeleteById(disk.Id);
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
        public void CanOperateOnManagedDiskFromSnapshot()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var emptyDiskName = SdkContext.RandomResourceName("md-empty-", 20);
                var snapshotBasedDiskName = SdkContext.RandomResourceName("md-snp-", 20);
                var snapshotName = SdkContext.RandomResourceName("snp-", 20);
                var resourceManager = TestHelper.CreateRollupClient();
                var computeManager = TestHelper.CreateComputeManager();
                var rgName = TestUtilities.GenerateName("rgfluentchash-");

                try
                {
                    var resourceGroup = resourceManager
                            .ResourceGroups
                            .Define(rgName)
                            .WithRegion(Location)
                            .Create();

                    var emptyDisk = computeManager.Disks
                            .Define(emptyDiskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(100)
                            .Create();

                    var snapshot = computeManager.Snapshots
                            .Define(snapshotName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithDataFromDisk(emptyDisk)
                            .WithSizeInGB(200)
                            .WithSku(DiskSkuTypes.StandardLRS)
                            .Create();

                    Assert.NotNull(snapshot.Id);
                    Assert.True(snapshot.Name.Equals(snapshotName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(snapshot.Sku, DiskSkuTypes.StandardLRS);
                    Assert.Equal(snapshot.CreationMethod, DiskCreateOption.Copy);
                    Assert.Equal(snapshot.SizeInGB, 200);
                    Assert.Null(snapshot.OsType);
                    Assert.NotNull(snapshot.Source);
                    Assert.Equal(snapshot.Source.Type, CreationSourceType.CopiedFromDisk);
                    Assert.True(snapshot.Source.SourceId().Equals(emptyDisk.Id, StringComparison.OrdinalIgnoreCase));

                    var fromSnapshotDisk = computeManager.Disks
                            .Define(snapshotBasedDiskName)
                            .WithRegion(Location)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .FromSnapshot(snapshot)
                            .WithSizeInGB(300)
                            .Create();

                    Assert.NotNull(fromSnapshotDisk.Id);
                    Assert.True(fromSnapshotDisk.Name.Equals(snapshotBasedDiskName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(fromSnapshotDisk.Sku, DiskSkuTypes.StandardLRS);
                    Assert.Equal(fromSnapshotDisk.CreationMethod, DiskCreateOption.Copy);
                    Assert.Equal(fromSnapshotDisk.SizeInGB, 300);
                    Assert.Null(fromSnapshotDisk.OsType);
                    Assert.NotNull(fromSnapshotDisk.Source);
                    Assert.Equal(fromSnapshotDisk.Source.Type, CreationSourceType.CopiedFromSnapshot);
                    Assert.True(fromSnapshotDisk.Source.SourceId().Equals(snapshot.Id));
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
