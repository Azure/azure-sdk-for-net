// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPTestsBase : VMTestBase
    {
        protected const string DiskNamePrefix = "diskrp";
        private string DiskRPLocation = ComputeManagementTestUtilities.DefaultLocation.ToLower();

        #region Execution
        protected void Disk_CRUD_Execute(DiskCreateOption diskCreateOption, string methodName, int? diskSizeGB = null, string location = null, IList<string> zones = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(diskCreateOption, rgName, diskSizeGB, zones);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group, unless create option is import in which case resource group will be created with vm
                    if (diskCreateOption != DiskCreateOption.Import)
                    {
                        m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    }

                    // **********
                    // TEST
                    // **********
                    // Put
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Validate(disk, diskOut, DiskRPLocation);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, DiskRPLocation);

                    // Get disk access
                    AccessUri accessUri = m_CrpClient.Disks.GrantAccess(rgName, diskName, AccessDataDefault);
                    Assert.NotNull(accessUri.AccessSAS);

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, DiskRPLocation);

                    // Patch
                    // TODO: Bug 9865640 - DiskRP doesn't follow patch semantics for zones: skip this for zones
                    if (zones == null)
                    {
                        const string tagKey = "tageKey";
                        var updatedisk = new DiskUpdate();
                        updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                        diskOut = m_CrpClient.Disks.Update(rgName, diskName, updatedisk);
                        Validate(disk, diskOut, DiskRPLocation);
                    }

                    // Get
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, DiskRPLocation);

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
        protected void Snapshot_CRUD_Execute(DiskCreateOption diskCreateOption, string methodName, int? diskSizeGB = null, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk sourceDisk = GenerateDefaultDisk(diskCreateOption, rgName, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    // Put disk
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, sourceDisk);
                    Validate(sourceDisk, diskOut, DiskRPLocation);

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
        protected void Disk_List_Execute(DiskCreateOption diskCreateOption, string methodName, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskName2 = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk1 = GenerateDefaultDisk(diskCreateOption, rgName1, diskSizeGB);
                Disk disk2 = GenerateDefaultDisk(diskCreateOption, rgName2, diskSizeGB);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource groups, unless create option is import in which case resource group will be created with vm
                    if (diskCreateOption != DiskCreateOption.Import)
                    {
                        m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName1, new ResourceGroup { Location = DiskRPLocation });
                        m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup { Location = DiskRPLocation });
                    }

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

        protected void Snapshot_List_Execute(DiskCreateOption diskCreateOption, string methodName, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, methodName))
            {
                EnsureClientsInitialized(context);

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskName2 = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName2 = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk1 = GenerateDefaultDisk(diskCreateOption, rgName1, diskSizeGB);
                Disk disk2 = GenerateDefaultDisk(diskCreateOption, rgName2, diskSizeGB);

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

        protected Disk GenerateDefaultDisk(DiskCreateOption diskCreateOption, string rgName, int? diskSizeGB = null, IList<string> zones = null)
        {
            Disk disk;

            switch (diskCreateOption)
            {
                case DiskCreateOption.Empty:
                    disk = GenerateBaseDisk(diskCreateOption);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                case DiskCreateOption.Import:
                    disk = GenerateImportDisk(diskCreateOption, rgName);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("diskCreateOption", diskCreateOption, "Unsupported option provided.");
            }

            return disk;
        }

        /// <summary>
        /// Generates a disk used when the DiskCreateOption is Import
        /// </summary>
        /// <returns></returns>
        private Disk GenerateImportDisk(DiskCreateOption diskCreateOption, string rgName)
        {
            // Create a VM, so we can use its OS disk for creating the image
            string storageAccountName = ComputeManagementTestUtilities.GenerateName(DiskNamePrefix);
            string asName = ComputeManagementTestUtilities.GenerateName("as");
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
            VirtualMachine inputVM = null;

            // Create Storage Account
            var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

            // Create the VM, whose OS disk will be used in creating the image
            var createdVM = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);
            var listResponse = m_CrpClient.VirtualMachines.ListAll();
            Assert.True(listResponse.Count() >= 1);
            string[] id = createdVM.Id.Split('/');
            string subscription = id[2];
            var uri = createdVM.StorageProfile.OsDisk.Vhd.Uri;

            m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
            m_CrpClient.VirtualMachines.Delete(rgName, createdVM.Name);

            Disk disk = GenerateBaseDisk(diskCreateOption);
            disk.CreationData.SourceUri = uri;
            disk.CreationData.StorageAccountId = "subscriptions/" + subscription + "/resourceGroups/" + rgName + "/providers/Microsoft.Storage/storageAccounts/" + storageAccountName;
            return disk;
        }

        private Disk GenerateBaseDisk(DiskCreateOption diskCreateOption)
        {
            var disk = new Disk
            {
                Location = DiskRPLocation,
            };
            disk.Sku = new DiskSku()
            {
                Name = StorageAccountTypes.StandardLRS
            };
            disk.CreationData = new CreationData()
            {
                CreateOption = diskCreateOption,
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
            snapshot.Sku = new DiskSku()
            {
                Name = StorageAccountTypes.StandardLRS
            };
            snapshot.CreationData = new CreationData()
            {
                CreateOption = DiskCreateOption.Copy,
                SourceResourceId = sourceDiskId,
            };

            return snapshot;
        }
        #endregion

        #region Validation

        private void Validate(Snapshot snapshotExpected, Snapshot snapshotActual, bool diskHydrated = false)
        {
            // snapshot resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "snapshots"), snapshotActual.Type);
            Assert.NotNull(snapshotActual.Name);
            Assert.Equal(DiskRPLocation, snapshotActual.Location);

            // snapshot properties
            Assert.Equal(snapshotExpected.Sku.Name, snapshotActual.Sku.Name);
            Assert.True(snapshotActual.ManagedBy == null);
            Assert.NotNull(snapshotActual.ProvisioningState);
            if (snapshotExpected.OsType != null) //these properties are not mandatory for the client
            {
                Assert.Equal(snapshotExpected.OsType, snapshotActual.OsType);
            }

            if (snapshotExpected.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.Equal(snapshotExpected.DiskSizeGB, snapshotActual.DiskSizeGB);
            }


            // Creation data
            CreationData creationDataExp = snapshotExpected.CreationData;
            CreationData creationDataAct = snapshotActual.CreationData;

            Assert.Equal(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.Equal(creationDataExp.SourceUri, creationDataAct.SourceUri);
            Assert.Equal(creationDataExp.SourceResourceId, creationDataAct.SourceResourceId);
            Assert.Equal(creationDataExp.StorageAccountId, creationDataAct.StorageAccountId);

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

        protected void Validate(Disk diskExpected, Disk diskActual, string location, bool diskHydrated = false)
        {
            // disk resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "disks"), diskActual.Type);
            Assert.NotNull(diskActual.Name);
            Assert.Equal(location, diskActual.Location);

            // disk properties
            Assert.Equal(diskExpected.Sku.Name, diskActual.Sku.Name);
            Assert.NotNull(diskActual.ProvisioningState);
            Assert.Equal(diskExpected.OsType, diskActual.OsType);

            if (diskExpected.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.Equal(diskExpected.DiskSizeGB, diskActual.DiskSizeGB);
            }


            // Creation data
            CreationData creationDataExp = diskExpected.CreationData;
            CreationData creationDataAct = diskActual.CreationData;

            Assert.Equal(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.Equal(creationDataExp.SourceUri, creationDataAct.SourceUri);
            Assert.Equal(creationDataExp.SourceResourceId, creationDataAct.SourceResourceId);
            Assert.Equal(creationDataExp.StorageAccountId, creationDataAct.StorageAccountId);

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

            // Zones
            IList<string> zonesExp = diskExpected.Zones;
            IList<string> zonesAct = diskActual.Zones;
            if (zonesExp != null)
            {
                Assert.Equal(zonesExp.Count, zonesAct.Count);
                foreach (string zone in zonesExp)
                {
                    Assert.Contains(zone, zonesAct, StringComparer.OrdinalIgnoreCase);
                }
            }
            else
            {
                Assert.Null(zonesAct);
            }
        }
        #endregion

    }
}