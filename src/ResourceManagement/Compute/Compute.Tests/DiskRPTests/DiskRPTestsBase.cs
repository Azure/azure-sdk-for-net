// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPTestsBase : VMTestBase
    {
        protected const string DiskNamePrefix = "diskrp";
        private static string DiskRPLocation = "westus";

        #region Execution
        protected void Disk_CRUD_Execute(DiskCreateOption diskCreateOption, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(diskCreateOption, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    // **********
                    // TEST
                    // **********
                    // Put
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Validate(disk, diskOut);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut);

                    // Get disk access
                    AccessUri accessUri = m_CrpClient.Disks.GrantAccess(rgName, diskName, AccessDataDefault);
                    Assert.NotNull(accessUri.AccessSAS);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut);

                    // Patch
                    const string tagKey = "tageKey";
                    var updatedisk = new DiskUpdate();
                    updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    diskOut = m_CrpClient.Disks.Update(rgName, diskName, updatedisk);
                    Validate(disk, diskOut);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut);

                    // End disk access
                    m_CrpClient.Disks.RevokeAccess(rgName, diskName);

                    // Delete
                    m_CrpClient.Disks.Delete(rgName, diskName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.Disks.Get(rgName, diskName);
                        Assert.False(true);
                    }
                    catch(CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }

        }
        protected void Snapshot_CRUD_Execute(DiskCreateOption diskCreateOption, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk sourceDisk = GenerateDefaultDisk(diskCreateOption, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    // Put disk
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, sourceDisk);
                    Validate(sourceDisk, diskOut);

                    // Generate snapshot using disk info
                    Snapshot snapshot = GenerateDefaultSnapshot(diskOut.Id);

                    // **********
                    // TEST
                    // **********
                    // Put
                    Snapshot snapshotOut = m_CrpClient.Snapshots.CreateOrUpdate(rgName, snapshotName, snapshot);
                    Validate(snapshot, snapshotOut);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut);

                    // Get access
                    AccessUri accessUri = m_CrpClient.Snapshots.GrantAccess(rgName, snapshotName, AccessDataDefault);
                    Assert.NotNull(accessUri.AccessSAS);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut);

                    // Patch
                    var updatesnapshot = new SnapshotUpdate();
                    const string tagKey = "tageKey";
                    updatesnapshot.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    snapshotOut = m_CrpClient.Snapshots.Update(rgName, snapshotName, updatesnapshot);
                    Validate(snapshot, snapshotOut);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut);

                    // End access
                    m_CrpClient.Snapshots.RevokeAccess(rgName, snapshotName);

                    // Delete
                    m_CrpClient.Snapshots.Delete(rgName, snapshotName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.Snapshots.Get(rgName, snapshotName);
                        Assert.False(true);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }

        }
        protected void Disk_List_Execute(DiskCreateOption diskCreateOption, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskName2 = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk1 = GenerateDefaultDisk(diskCreateOption, diskSizeGB);
                Disk disk2 = GenerateDefaultDisk(diskCreateOption, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource groups
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName1, new ResourceGroup {Location = DiskRPLocation});
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup {Location = DiskRPLocation});

                    // Put 4 disks, 2 in each resource group
                    m_CrpClient.Disks.CreateOrUpdate(rgName1, diskName1, disk1);
                    m_CrpClient.Disks.CreateOrUpdate(rgName1, diskName2, disk2);
                    m_CrpClient.Disks.CreateOrUpdate(rgName2, diskName1, disk1);
                    m_CrpClient.Disks.CreateOrUpdate(rgName2, diskName2, disk2);

                    // **********
                    // TEST
                    // **********
                    // List disks under resource group
                    IPage<Disk> disksOut = m_CrpClient.Disks.ListByResourceGroup(rgName1);
                    Assert.Equal(2, disksOut.Count());
                    Assert.Null(disksOut.NextPageLink);

                    disksOut = m_CrpClient.Disks.ListByResourceGroup(rgName2);
                    Assert.Equal(2, disksOut.Count());
                    Assert.Null(disksOut.NextPageLink);

                    // List disks under subscription
                    disksOut = m_CrpClient.Disks.List();
                    Assert.True(disksOut.Count() >= 4);
                    if (disksOut.NextPageLink != null)
                    {
                        disksOut = m_CrpClient.Disks.ListNext(disksOut.NextPageLink);
                        Assert.True(disksOut.Any());
                    }
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName1);
                    m_ResourcesClient.ResourceGroups.Delete(rgName2);
                }

            }
        }

        protected void Snapshot_List_Execute(DiskCreateOption diskCreateOption, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskName2 = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName2 = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk1 = GenerateDefaultDisk(diskCreateOption, diskSizeGB);
                Disk disk2 = GenerateDefaultDisk(diskCreateOption, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource groups
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName1, new ResourceGroup { Location = DiskRPLocation });
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup { Location = DiskRPLocation });

                    // Put 4 disks, 2 in each resource group
                    Disk diskOut11 = m_CrpClient.Disks.CreateOrUpdate(rgName1, diskName1, disk1);
                    Disk diskOut12 = m_CrpClient.Disks.CreateOrUpdate(rgName1, diskName2, disk2);
                    Disk diskOut21 = m_CrpClient.Disks.CreateOrUpdate(rgName2, diskName1, disk1);
                    Disk diskOut22 = m_CrpClient.Disks.CreateOrUpdate(rgName2, diskName2, disk2);

                    // Generate 4 snapshots using disks info
                    Snapshot snapshot11 = GenerateDefaultSnapshot(diskOut11.Id);
                    Snapshot snapshot12 = GenerateDefaultSnapshot(diskOut12.Id);
                    Snapshot snapshot21 = GenerateDefaultSnapshot(diskOut21.Id);
                    Snapshot snapshot22 = GenerateDefaultSnapshot(diskOut22.Id);

                    // Put 4 snapshots, 2 in each resource group
                    m_CrpClient.Snapshots.CreateOrUpdate(rgName1, snapshotName1, snapshot11);
                    m_CrpClient.Snapshots.CreateOrUpdate(rgName1, snapshotName2, snapshot12);
                    m_CrpClient.Snapshots.CreateOrUpdate(rgName2, snapshotName1, snapshot21);
                    m_CrpClient.Snapshots.CreateOrUpdate(rgName2, snapshotName2, snapshot22);

                    // **********
                    // TEST
                    // **********
                    // List snapshots under resource group
                    IPage<Snapshot> snapshotsOut = m_CrpClient.Snapshots.ListByResourceGroup(rgName1);
                    Assert.Equal(2, snapshotsOut.Count());
                    Assert.Null(snapshotsOut.NextPageLink);

                    snapshotsOut = m_CrpClient.Snapshots.ListByResourceGroup(rgName2);
                    Assert.Equal(2, snapshotsOut.Count());
                    Assert.Null(snapshotsOut.NextPageLink);

                    // List snapshots under subscription
                    snapshotsOut = m_CrpClient.Snapshots.List();
                    Assert.True(snapshotsOut.Count() >= 4);
                    if (snapshotsOut.NextPageLink != null)
                    {
                        snapshotsOut = m_CrpClient.Snapshots.ListNext(snapshotsOut.NextPageLink);
                        Assert.True(snapshotsOut.Any());
                    }
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName1);
                    m_ResourcesClient.ResourceGroups.Delete(rgName2);
                }

            }
        }

        #endregion

        #region Generation
        public static readonly GrantAccessData AccessDataDefault = new GrantAccessData { Access = AccessLevel.Read, DurationInSeconds = 1000 };

        protected Disk GenerateDefaultDisk(DiskCreateOption diskCreateOption, int? diskSizeGB = null)
        {
            Disk disk = GenerateBaseDisk(diskCreateOption);

            switch (diskCreateOption)
            {
                case DiskCreateOption.Empty:
                    disk.DiskSizeGB = diskSizeGB;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("diskCreateOption", diskCreateOption, "Unsupported option provided.");
            }

            return disk;
        }

        private Disk GenerateBaseDisk(DiskCreateOption diskCreateOption)
        {
            var disk = new Disk
            {
                Location = DiskRPLocation,
            };

            disk.AccountType =  StorageAccountTypes.StandardLRS;
            disk.CreationData = new CreationData()
            {
                CreateOption = diskCreateOption
            };
            disk.OsType = OperatingSystemTypes.Windows;

            return disk;
        }

        protected Snapshot GenerateDefaultSnapshot(string sourceDiskId)
        {
            Snapshot snapshot = GenerateBaseSnapshot(sourceDiskId);
            return snapshot;
        }

        private Snapshot GenerateBaseSnapshot(string sourceDiskId)
        {
            var snapshot = new Snapshot()
            {
                Location = DiskRPLocation
            };

            snapshot.AccountType = StorageAccountTypes.StandardLRS;
            snapshot.CreationData = new CreationData()
            {
                CreateOption = DiskCreateOption.Copy,
                SourceUri = sourceDiskId,
            };

            return snapshot;
        }
        #endregion

        #region Validation

        private void Validate(Snapshot snapshotExpexted, Snapshot snapshotActual, bool diskHydrated = false)
        {
            // snapshot resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "snapshots"), snapshotActual.Type);
            Assert.NotNull(snapshotActual.Name);
            Assert.Equal(DiskRPLocation, snapshotActual.Location);

            // disk properties
            Assert.Equal(snapshotExpexted.AccountType, snapshotActual.AccountType);
            Assert.NotNull(snapshotActual.ProvisioningState);
            Assert.Equal(snapshotExpexted.OsType, snapshotActual.OsType);

            if (snapshotExpexted.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.Equal(snapshotExpexted.DiskSizeGB, snapshotActual.DiskSizeGB);
            }


            // Creation data
            CreationData creationDataExp = snapshotExpexted.CreationData;
            CreationData creationDataAct = snapshotActual.CreationData;

            Assert.Equal(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.Equal(creationDataExp.SourceUri, creationDataAct.SourceUri);

            // Image reference
            ImageDiskReference imgRefExp = creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.ImageReference;
            if (imgRefExp != null)
            {
                Assert.Equal(imgRefExp.Id, imgRefAct.Id);
                Assert.Equal(imgRefExp.Lun, imgRefAct.Lun);
            }
            else
            {
                Assert.Null(imgRefAct);
            }

        }

        private void Validate(Disk diskExpexted, Disk diskActual, bool diskHydrated = false)
        {
            // disk resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "disks"), diskActual.Type);
            Assert.NotNull(diskActual.Name);
            Assert.Equal(DiskRPLocation, diskActual.Location);

            // disk properties
            Assert.Equal(diskExpexted.AccountType, diskActual.AccountType);
            Assert.NotNull(diskActual.ProvisioningState);
            Assert.Equal(diskExpexted.OsType, diskActual.OsType);

            if (diskExpexted.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.Equal(diskExpexted.DiskSizeGB, diskActual.DiskSizeGB);
            }


            // Creation data
            CreationData creationDataExp = diskExpexted.CreationData;
            CreationData creationDataAct = diskActual.CreationData;

            Assert.Equal(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.Equal(creationDataExp.SourceUri, creationDataAct.SourceUri);

            // Image reference
            ImageDiskReference imgRefExp = creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.ImageReference;
            if (imgRefExp != null)
            {
                Assert.Equal(imgRefExp.Id, imgRefAct.Id);
                Assert.Equal(imgRefExp.Lun, imgRefAct.Lun);
            }
            else
            {
                Assert.Null(imgRefAct);
            }
        }
        #endregion

    }
}