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
using ResourceIdentityType = Microsoft.Azure.Management.ResourceManager.Models.ResourceIdentityType;
using NM = Microsoft.Azure.Management.Network.Models;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPTestsBase : VMTestBase
    {
        protected const string DiskNamePrefix = "diskrp";
        private string DiskRPLocation = ComputeManagementTestUtilities.DefaultLocation.ToLower();

        #region Execution
        protected void Disk_CRUD_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null, IList<string> zones = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(diskCreateOption, rgName, diskSizeGB, zones, location);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group, unless create option is import in which case resource group will be created with vm,
                    // or copy in which casethe resource group will be created with the original disk.
                    if (diskCreateOption != DiskCreateOption.Import && diskCreateOption != DiskCreateOption.Copy)
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
        protected void Snapshot_CRUD_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null, bool incremental = false)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
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
                    Snapshot snapshot = GenerateDefaultSnapshot(diskOut.Id, incremental: incremental);

                    // **********
                    // TEST
                    // **********
                    // Put
                    Snapshot snapshotOut = m_CrpClient.Snapshots.CreateOrUpdate(rgName, snapshotName, snapshot);
                    Validate(snapshot, snapshotOut, incremental: incremental);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut, incremental: incremental);

                    // Get access
                    AccessUri accessUri = m_CrpClient.Snapshots.GrantAccess(rgName, snapshotName, AccessDataDefault);
                    Assert.NotNull(accessUri.AccessSAS);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut, incremental: incremental);

                    // Patch
                    var updatesnapshot = new SnapshotUpdate();
                    const string tagKey = "tageKey";
                    updatesnapshot.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    snapshotOut = m_CrpClient.Snapshots.Update(rgName, snapshotName, updatesnapshot);
                    Validate(snapshot, snapshotOut, incremental: incremental);

                    // Get
                    snapshotOut = m_CrpClient.Snapshots.Get(rgName, snapshotName);
                    Validate(snapshot, snapshotOut, incremental: incremental);

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

        protected void DiskEncryptionSet_CRUD_Execute(string methodName, string encryptionType, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var desName = TestUtilities.GenerateName(DiskNamePrefix);
                DiskEncryptionSet des = GenerateDefaultDiskEncryptionSet(DiskRPLocation, encryptionType);

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    // Put DiskEncryptionSet
                    DiskEncryptionSet desOut = m_CrpClient.DiskEncryptionSets.CreateOrUpdate(rgName, desName, des);
                    Validate(des, desOut, desName, encryptionType);

                    // Get DiskEncryptionSet
                    desOut = m_CrpClient.DiskEncryptionSets.Get(rgName, desName);
                    Validate(des, desOut, desName, encryptionType);

                    // Patch DiskEncryptionSet
                    const string tagKey = "tageKey";
                    var updateDes = new DiskEncryptionSetUpdate();
                    updateDes.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    desOut = m_CrpClient.DiskEncryptionSets.Update(rgName, desName, updateDes);
                    Validate(des, desOut, desName, encryptionType);
                    Assert.Equal(1, desOut.Tags.Count);

                    // Delete DiskEncryptionSet
                    m_CrpClient.DiskEncryptionSets.Delete(rgName, desName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.DiskEncryptionSets.Get(rgName, desName);
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

        protected void DiskAccess_CRUD_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskAccessName = TestUtilities.GenerateName(DiskNamePrefix);
                DiskAccess diskAccess = GenerateDefaultDiskAccess(DiskRPLocation);

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    
                    // Put DiskAccess
                    DiskAccess diskAccessOut = m_CrpClient.DiskAccesses.CreateOrUpdate(rgName, diskAccessName, diskAccess);
                    Validate(diskAccess, diskAccessOut, diskAccessName);

                    // Get DiskAccess
                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);
                    Validate(diskAccess, diskAccessOut, diskAccessName);

                    // Patch DiskAccess
                    const string tagKey = "tagKey";
                    Dictionary<string, string> tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    diskAccessOut = m_CrpClient.DiskAccesses.Update(rgName, diskAccessName, tags);
                    Validate(diskAccess, diskAccessOut, diskAccessName);
                    Assert.Equal(1, diskAccessOut.Tags.Count);

                    PrivateLinkResourceListResult privateLinkResources = m_CrpClient.DiskAccesses.GetPrivateLinkResources(rgName, diskAccessName);
                    Validate(privateLinkResources);

                    // Delete DiskAccess
                    m_CrpClient.DiskAccesses.Delete(rgName, diskAccessName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);
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

        protected void DiskAccess_WithPrivateEndpoint_CRUD_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskAccessName = TestUtilities.GenerateName(DiskNamePrefix);
                var privateEndpointName = TestUtilities.GenerateName(DiskNamePrefix);
                DiskAccess diskAccess = GenerateDefaultDiskAccess(DiskRPLocation);

                m_location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    // Put DiskAccess
                    DiskAccess diskAccessOut = m_CrpClient.DiskAccesses.CreateOrUpdate(rgName, diskAccessName, diskAccess);
                    Validate(diskAccess, diskAccessOut, diskAccessName);

                    // Get DiskAccess
                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);
                    Validate(diskAccess, diskAccessOut, diskAccessName);

                    // Create VNet with Subnet
                    NM.Subnet subnet = CreateVNET(rgName, disablePEPolicies: true);

                    // Put Private Endpoint associating it with disk access
                    NM.PrivateEndpoint privateEndpoint = CreatePrivateEndpoint(rgName, privateEndpointName, diskAccessOut.Id, subnet.Id);

                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);
                    Validate(diskAccess, diskAccessOut, diskAccessName, privateEndpoint.Id);

                    // Patch DiskAccess
                    const string tagKey = "tagKey";
                    Dictionary<string, string> tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                    diskAccessOut = m_CrpClient.DiskAccesses.Update(rgName, diskAccessName, tags);
                    Validate(diskAccess, diskAccessOut, diskAccessName);
                    Assert.Equal(1, diskAccessOut.Tags.Count);

                    PrivateLinkResourceListResult privateLinkResources = m_CrpClient.DiskAccesses.GetPrivateLinkResources(rgName, diskAccessName);
                    Validate(privateLinkResources);

                    m_NrpClient.PrivateEndpoints.DeleteWithHttpMessagesAsync(rgName, privateEndpointName).GetAwaiter().GetResult();

                    // Delete DiskAccess
                    m_CrpClient.DiskAccesses.Delete(rgName, diskAccessName);

                    try
                    {
                        // Ensure it was really deleted
                        m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);
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

        protected void Disk_List_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskName2 = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk1 = GenerateDefaultDisk(diskCreateOption, rgName1, diskSizeGB, location: location);
                Disk disk2 = GenerateDefaultDisk(diskCreateOption, rgName2, diskSizeGB, location: location);

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

        protected void Snapshot_List_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
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
                    Snapshot snapshot12 = GenerateDefaultSnapshot(diskOut12.Id, SnapshotStorageAccountTypes.StandardZRS);
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

        protected void DiskEncryptionSet_List_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var desName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var desName2 = TestUtilities.GenerateName(DiskNamePrefix);
                DiskEncryptionSet des1 = GenerateDefaultDiskEncryptionSet(DiskRPLocation);
                DiskEncryptionSet des2 = GenerateDefaultDiskEncryptionSet(DiskRPLocation);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource groups
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName1, new ResourceGroup { Location = DiskRPLocation });
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup { Location = DiskRPLocation });

                    // Put 4 diskEncryptionSets, 2 in each resource group
                    m_CrpClient.DiskEncryptionSets.CreateOrUpdate(rgName1, desName1, des1);
                    m_CrpClient.DiskEncryptionSets.CreateOrUpdate(rgName1, desName2, des2);
                    m_CrpClient.DiskEncryptionSets.CreateOrUpdate(rgName2, desName1, des1);
                    m_CrpClient.DiskEncryptionSets.CreateOrUpdate(rgName2, desName2, des2);

                    // **********
                    // TEST
                    // **********
                    // List diskEncryptionSets under resource group
                    IPage<DiskEncryptionSet> dessOut = m_CrpClient.DiskEncryptionSets.ListByResourceGroup(rgName1);
                    Assert.Equal(2, dessOut.Count());
                    Assert.Null(dessOut.NextPageLink);

                    dessOut = m_CrpClient.DiskEncryptionSets.ListByResourceGroup(rgName2);
                    Assert.Equal(2, dessOut.Count());
                    Assert.Null(dessOut.NextPageLink);

                    // List diskEncryptionSets under subscription
                    dessOut = m_CrpClient.DiskEncryptionSets.List();
                    Assert.True(dessOut.Count() >= 4);
                    if (dessOut.NextPageLink != null)
                    {
                        dessOut = m_CrpClient.DiskEncryptionSets.ListNext(dessOut.NextPageLink);
                        Assert.True(dessOut.Any());
                    }

                    // Delete diskEncryptionSets
                    m_CrpClient.DiskEncryptionSets.Delete(rgName1, desName1);
                    m_CrpClient.DiskEncryptionSets.Delete(rgName1, desName2);
                    m_CrpClient.DiskEncryptionSets.Delete(rgName2, desName1);
                    m_CrpClient.DiskEncryptionSets.Delete(rgName2, desName2);
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName1);
                    m_ResourcesClient.ResourceGroups.Delete(rgName2);
                }
            }
        }

        protected void DiskAccess_List_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType(), methodName))
            {
                EnsureClientsInitialized(context);
                DiskRPLocation = location ?? DiskRPLocation;

                // Data
                var rgName1 = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var diskAccessName1 = TestUtilities.GenerateName(DiskNamePrefix);
                var diskAccessName2 = TestUtilities.GenerateName(DiskNamePrefix);
                DiskAccess diskAccess1 = GenerateDefaultDiskAccess(DiskRPLocation);
                DiskAccess diskAccess2 = GenerateDefaultDiskAccess(DiskRPLocation);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource groups
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName1, new ResourceGroup { Location = DiskRPLocation });
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName2, new ResourceGroup { Location = DiskRPLocation });

                    // Put 4 diskAccesses, 2 in each resource group
                    m_CrpClient.DiskAccesses.CreateOrUpdate(rgName1, diskAccessName1, diskAccess1);
                    m_CrpClient.DiskAccesses.CreateOrUpdate(rgName1, diskAccessName2, diskAccess2);
                    m_CrpClient.DiskAccesses.CreateOrUpdate(rgName2, diskAccessName1, diskAccess1);
                    m_CrpClient.DiskAccesses.CreateOrUpdate(rgName2, diskAccessName2, diskAccess2);

                    // **********
                    // TEST
                    // **********
                    // List diskAccesses under resource group
                    IPage<DiskAccess> diskAccessesOut = m_CrpClient.DiskAccesses.ListByResourceGroup(rgName1);
                    Assert.Equal(2, diskAccessesOut.Count());
                    Assert.Null(diskAccessesOut.NextPageLink);

                    diskAccessesOut = m_CrpClient.DiskAccesses.ListByResourceGroup(rgName2);
                    Assert.Equal(2, diskAccessesOut.Count());
                    Assert.Null(diskAccessesOut.NextPageLink);

                    // List diskAccesses under subscription
                    diskAccessesOut = m_CrpClient.DiskAccesses.List();
                    Assert.True(diskAccessesOut.Count() >= 4);
                    if (diskAccessesOut.NextPageLink != null)
                    {
                        diskAccessesOut = m_CrpClient.DiskAccesses.ListNext(diskAccessesOut.NextPageLink);
                        Assert.True(diskAccessesOut.Any());
                    }

                    // Delete diskAccesses
                    m_CrpClient.DiskAccesses.Delete(rgName1, diskAccessName1);
                    m_CrpClient.DiskAccesses.Delete(rgName1, diskAccessName2);
                    m_CrpClient.DiskAccesses.Delete(rgName2, diskAccessName1);
                    m_CrpClient.DiskAccesses.Delete(rgName2, diskAccessName2);
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName1);
                    m_ResourcesClient.ResourceGroups.Delete(rgName2);
                }
            }
        }

        protected void DiskEncryptionSet_CreateDisk_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var desName = "longlivedSwaggerDES";
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                disk.Location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    // Get DiskEncryptionSet
                    DiskEncryptionSet desOut = m_CrpClient.DiskEncryptionSets.Get("longrunningrg-centraluseuap", desName);
                    Assert.NotNull(desOut);
                    disk.Encryption = new Encryption
                    {
                        Type = EncryptionType.EncryptionAtRestWithCustomerKey.ToString(),
                        DiskEncryptionSetId = desOut.Id
                    };
                    //Put Disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(desOut.Id.ToLower(), diskOut.Encryption.DiskEncryptionSetId.ToLower());
                    Assert.Equal(EncryptionType.EncryptionAtRestWithCustomerKey, diskOut.Encryption.Type);

                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        protected void DiskAccess_CreateDisk_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var diskAccessName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                DiskAccess diskAccess = GenerateDefaultDiskAccess(location);
                disk.Location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    DiskAccess diskAccessOut = m_CrpClient.DiskAccesses.CreateOrUpdate(rgName, diskAccessName, diskAccess);

                    //Get DiskAccess
                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);

                    disk.DiskAccessId = diskAccessOut.Id;

                    //Put Disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(diskAccessOut.Id.ToLower(), diskOut.DiskAccessId.ToLower());

                    m_CrpClient.Disks.Delete(rgName, diskName);

                    m_CrpClient.DiskAccesses.Delete(rgName, diskAccessName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        protected void DiskEncryptionSet_UpdateDisk_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var desName = "longlivedSwaggerDES";
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                disk.Location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    // Put Disk with PlatformManagedKey
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Null(diskOut.Encryption.DiskEncryptionSetId);
                    Assert.Equal(EncryptionType.EncryptionAtRestWithPlatformKey, diskOut.Encryption.Type);

                    // Update Disk with CustomerManagedKey
                    DiskEncryptionSet desOut = m_CrpClient.DiskEncryptionSets.Get("longrunningrg-centraluseuap", desName);
                    Assert.NotNull(desOut);
                    disk.Encryption = new Encryption
                    {
                        Type = EncryptionType.EncryptionAtRestWithCustomerKey.ToString(),
                        DiskEncryptionSetId = desOut.Id
                    };
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Assert.Equal(desOut.Id.ToLower(), diskOut.Encryption.DiskEncryptionSetId.ToLower());
                    Assert.Equal(EncryptionType.EncryptionAtRestWithCustomerKey, diskOut.Encryption.Type);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        protected void DiskAccess_UpdateDisk_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var diskAccessName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                DiskAccess diskAccess = GenerateDefaultDiskAccess(location);
                disk.Location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    // Put Disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, disk.Location);
                    Assert.Null(diskOut.DiskAccessId);

                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    DiskAccess diskAccessOut = m_CrpClient.DiskAccesses.CreateOrUpdate(rgName, diskAccessName, diskAccess);

                    //Get DiskAccess
                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);

                    //Update Disk with DiskAccess
                    DiskUpdate diskUpdate = new DiskUpdate
                    {
                        DiskAccessId = diskAccessOut.Id
                    };

                    m_CrpClient.Disks.Update(rgName, diskName, diskUpdate);
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Assert.Equal(diskAccessOut.Id.ToLower(), diskOut.DiskAccessId.ToLower());
                    Assert.Equal(NetworkAccessPolicy.AllowPrivate, diskOut.NetworkAccessPolicy);

                    m_CrpClient.Disks.Delete(rgName, diskName);
                    m_CrpClient.DiskAccesses.Delete(rgName, diskAccessName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        protected void DiskAccess_UpdateDisk_RemoveDiskAccess_Execute(string methodName, string location = null)
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var diskAccessName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                DiskAccess diskAccess = GenerateDefaultDiskAccess(location);
                disk.Location = location;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    // Put Disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);
                    Validate(disk, diskOut, disk.Location);
                    Assert.Null(diskOut.DiskAccessId);

                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    DiskAccess diskAccessOut = m_CrpClient.DiskAccesses.CreateOrUpdate(rgName, diskAccessName, diskAccess);

                    //Get DiskAccess
                    diskAccessOut = m_CrpClient.DiskAccesses.Get(rgName, diskAccessName);

                    //Update Disk with DiskAccess
                    DiskUpdate diskUpdate = new DiskUpdate
                    {
                        DiskAccessId = diskAccessOut.Id
                    };

                    m_CrpClient.Disks.Update(rgName, diskName, diskUpdate);
                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Assert.Equal(diskAccessOut.Id.ToLower(), diskOut.DiskAccessId.ToLower());

                    //Set network access policy to AllowAll to remove diskAccess from Disk
                    diskUpdate.DiskAccessId = null;
                    diskUpdate.NetworkAccessPolicy = NetworkAccessPolicy.AllowAll;
                    m_CrpClient.Disks.Update(rgName, diskName, diskUpdate);

                    diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Assert.Null(diskOut.DiskAccessId);
                    Assert.Equal(NetworkAccessPolicy.AllowAll, diskOut.NetworkAccessPolicy);

                    m_CrpClient.Disks.Delete(rgName, diskName);
                    m_CrpClient.DiskAccesses.Delete(rgName, diskAccessName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        #endregion

        #region Generation
        public static readonly GrantAccessData AccessDataDefault = new GrantAccessData { Access = AccessLevel.Read, DurationInSeconds = 1000 };

        protected Disk GenerateDefaultDisk(string diskCreateOption, string rgName, int? diskSizeGB = null, IList<string> zones = null, string location = null)
        {
            Disk disk;

            switch (diskCreateOption)
            {
                case "Upload":
                    disk = GenerateBaseDisk(diskCreateOption);
                    disk.CreationData.UploadSizeBytes = (long) (diskSizeGB ?? 10) * 1024 * 1024 * 1024 + 512;
                    break;
                case "Empty":
                    disk = GenerateBaseDisk(diskCreateOption);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                case "Import":
                    disk = GenerateImportDisk(diskCreateOption, rgName, location);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                case "Copy":
                    disk = GenerateCopyDisk(rgName, diskSizeGB ?? 10, location);
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
        private Disk GenerateImportDisk(string diskCreateOption, string rgName, string location)
        {
            // Create a VM, so we can use its OS disk for creating the image
            string storageAccountName = ComputeManagementTestUtilities.GenerateName(DiskNamePrefix);
            string asName = ComputeManagementTestUtilities.GenerateName("as");
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
            VirtualMachine inputVM = null;
            m_location = location;

            // Create Storage Account
            var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

            // Create the VM, whose OS disk will be used in creating the image
            var createdVM = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM);
            var listResponse = m_CrpClient.VirtualMachines.ListAll();
            Assert.True(listResponse.Count() >= 1);
            string[] id = createdVM.Id.Split('/');
            string subscription = id[2];
            var uri = createdVM.StorageProfile.OsDisk.Vhd.Uri;

            m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
            m_CrpClient.VirtualMachines.Delete(rgName, createdVM.Name);

            Disk disk = GenerateBaseDisk(diskCreateOption);
            disk.CreationData.SourceUri = uri;
            disk.CreationData.StorageAccountId = "/subscriptions/" + subscription + "/resourceGroups/" + rgName + "/providers/Microsoft.Storage/storageAccounts/" + storageAccountName;
            return disk;
        }

        /// <summary>
        /// Generates a disk used when the DiskCreateOption is Copy
        /// </summary>
        /// <returns></returns>
        private Disk GenerateCopyDisk(string rgName, int diskSizeGB, string location)
        {
            // Create an empty disk
            Disk originalDisk = GenerateDefaultDisk("Empty", rgName, diskSizeGB: diskSizeGB);
            m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
            Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(rgName, TestUtilities.GenerateName(DiskNamePrefix + "_original"), originalDisk);

            Snapshot snapshot = GenerateDefaultSnapshot(diskOut.Id);
            Snapshot snapshotOut = m_CrpClient.Snapshots.CreateOrUpdate(rgName, "snapshotswaaggertest", snapshot);

            Disk copyDisk = GenerateBaseDisk("Import");
            copyDisk.CreationData.SourceResourceId = snapshotOut.Id;
            return copyDisk;
        }

        protected DiskEncryptionSet GenerateDefaultDiskEncryptionSet(string location, string encryptionType = EncryptionType.EncryptionAtRestWithCustomerKey)
        {
            string testVaultId = @"/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourcegroups/swagger/providers/Microsoft.KeyVault/vaults/swaggervault";
            string encryptionKeyUri = @"https://swaggervault.vault.azure.net/keys/diskRPSSEKey/4780bcaf12384596b75cf63731f2046c";

            var des = new DiskEncryptionSet
            {
                Identity = new EncryptionSetIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned.ToString()
                },
                Location = location,
                ActiveKey = new KeyVaultAndKeyReference
                {
                    SourceVault = new SourceVault
                    {
                        Id = testVaultId
                    },
                    KeyUrl = encryptionKeyUri
                },
                EncryptionType = encryptionType
            };
            return des;
        }

        protected DiskAccess GenerateDefaultDiskAccess(string location)
        {
            var diskAccess = new DiskAccess
            {
                Location = location
            };
            return diskAccess;
        }

        public Disk GenerateBaseDisk(string diskCreateOption)
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
            disk.OsType = OperatingSystemTypes.Linux;

            return disk;
        }

        protected Snapshot GenerateDefaultSnapshot(string sourceDiskId, string snapshotStorageAccountTypes = "Standard_LRS", bool incremental = false)
        {
            Snapshot snapshot = GenerateBaseSnapshot(sourceDiskId, snapshotStorageAccountTypes, incremental);
            return snapshot;
        }

        private Snapshot GenerateBaseSnapshot(string sourceDiskId, string snapshotStorageAccountTypes, bool incremental = false)
        {
            var snapshot = new Snapshot()
            {
                Location = DiskRPLocation,
                Incremental = incremental
            };
            snapshot.Sku = new SnapshotSku()
            {
                Name = snapshotStorageAccountTypes ?? SnapshotStorageAccountTypes.StandardLRS
            };
            snapshot.CreationData = new CreationData()
            {
                CreateOption = DiskCreateOption.Copy,
                SourceResourceId = sourceDiskId,
            };

            return snapshot;
        }
        #endregion

        #region Helpers

        protected NM.PrivateEndpoint CreatePrivateEndpoint(string rgName, string peName, string diskAccessId, string subnetId)
        {
            string plsConnectionName = TestUtilities.GenerateName("pls");
            NM.PrivateEndpoint privateEndpoint = new NM.PrivateEndpoint
            {
                Subnet = new NM.Subnet
                {
                    Id = subnetId
                },
                Location = m_location,
                PrivateLinkServiceConnections = new List<NM.PrivateLinkServiceConnection>
                {
                    new NM.PrivateLinkServiceConnection
                    {
                        GroupIds = new List<string> { "disks" },
                        Name = plsConnectionName,
                        PrivateLinkServiceId = diskAccessId
                    }
                }
            };

            NM.PrivateEndpoint privateEndpointOut = m_NrpClient.PrivateEndpoints.CreateOrUpdateWithHttpMessagesAsync(rgName, peName, privateEndpoint).GetAwaiter().GetResult().Body;

            return privateEndpointOut;
        }

        #endregion

        #region Validation

        private void Validate(DiskEncryptionSet diskEncryptionSetExpected, DiskEncryptionSet diskEncryptionSetActual, string expectedDESName, string expectedEncryptionType)
        {
            Assert.Equal(expectedDESName, diskEncryptionSetActual.Name);
            Assert.Equal(diskEncryptionSetExpected.Location, diskEncryptionSetActual.Location);
            Assert.Equal(diskEncryptionSetExpected.ActiveKey.SourceVault.Id, diskEncryptionSetActual.ActiveKey.SourceVault.Id);
            Assert.Equal(diskEncryptionSetExpected.ActiveKey.KeyUrl, diskEncryptionSetActual.ActiveKey.KeyUrl);
            Assert.NotNull(diskEncryptionSetActual.Identity);
            Assert.Equal(ResourceIdentityType.SystemAssigned.ToString(), diskEncryptionSetActual.Identity.Type);
            Assert.Equal(expectedEncryptionType, diskEncryptionSetActual.EncryptionType);
        }

        private void Validate(DiskAccess diskAccessExpected, DiskAccess diskAccessActual, string expectedDiskAccessName, string privateEndpointId = null)
        {
            Assert.Equal(expectedDiskAccessName, diskAccessActual.Name);
            Assert.Equal(diskAccessExpected.Location, diskAccessActual.Location);
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "diskAccesses"), diskAccessActual.Type);
            Assert.Equal("Succeeded", diskAccessActual.ProvisioningState);
            if (privateEndpointId != null)
            {
                // since private endpoint is specified we expect there to be private endpoint connections
                Assert.NotNull(diskAccessActual.PrivateEndpointConnections);
                Assert.Equal(string.Format("{0}/{1}/{2}", ApiConstants.ResourceProviderNamespace, "diskAccesses", "PrivateEndpointConnections"), diskAccessActual.PrivateEndpointConnections[0].Type);
                Assert.Equal(privateEndpointId, diskAccessActual.PrivateEndpointConnections[0].PrivateEndpoint.Id);
                Assert.Equal("Approved", diskAccessActual.PrivateEndpointConnections[0].PrivateLinkServiceConnectionState.Status);
                Assert.Equal("None", diskAccessActual.PrivateEndpointConnections[0].PrivateLinkServiceConnectionState.ActionsRequired);
                Assert.Equal(PrivateEndpointConnectionProvisioningState.Succeeded, diskAccessActual.PrivateEndpointConnections[0].ProvisioningState);
            }
        }

        private void Validate(PrivateLinkResourceListResult privateLinkResources)
        {
            Assert.Equal(1, privateLinkResources.Value.Count);
            Assert.Equal(string.Format("{0}/{1}/{2}", ApiConstants.ResourceProviderNamespace, "diskAccesses", "privateLinkResources"), privateLinkResources.Value[0].Type);
            Assert.Equal("disks", privateLinkResources.Value[0].GroupId);
            Assert.Equal(1, privateLinkResources.Value[0].RequiredMembers.Count);
            Assert.Equal("diskAccess_1", privateLinkResources.Value[0].RequiredMembers[0]);
            Assert.Equal("privatelink.blob.core.windows.net", privateLinkResources.Value[0].RequiredZoneNames[0]);
        }

        private void Validate(Snapshot snapshotExpected, Snapshot snapshotActual, bool diskHydrated = false, bool incremental = false)
        {
            // snapshot resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "snapshots"), snapshotActual.Type);
            Assert.NotNull(snapshotActual.Name);
            Assert.Equal(DiskRPLocation, snapshotActual.Location);

            // snapshot properties
            Assert.Equal(snapshotExpected.Sku.Name, snapshotActual.Sku.Name);
            Assert.True(snapshotActual.ManagedBy == null);
            Assert.NotNull(snapshotActual.ProvisioningState);
            Assert.Equal(incremental, snapshotActual.Incremental);
            Assert.NotNull(snapshotActual.CreationData.SourceUniqueId);
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
            ImageDiskReference imgRefExp = creationDataExp.GalleryImageReference ?? creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.GalleryImageReference ?? creationDataAct.ImageReference;
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

        protected void Validate(Disk diskExpected, Disk diskActual, string location, bool diskHydrated = false, bool update = false)
        {
            // disk resource
            Assert.Equal(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "disks"), diskActual.Type);
            Assert.NotNull(diskActual.Name);
            Assert.Equal(location, diskActual.Location);

            // disk properties
            Assert.Equal(diskExpected.Sku.Name, diskActual.Sku.Name);
            Assert.NotNull(diskActual.ProvisioningState);
            Assert.Equal(diskExpected.OsType, diskActual.OsType);
            Assert.NotNull(diskActual.UniqueId);

            if (diskExpected.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.Equal(diskExpected.DiskSizeGB, diskActual.DiskSizeGB);
                Assert.NotNull(diskActual.DiskSizeBytes);
            }

            if (!update)
            {
                if (diskExpected.DiskIOPSReadWrite != null)
                {
                    Assert.Equal(diskExpected.DiskIOPSReadWrite, diskActual.DiskIOPSReadWrite);
                }

                if (diskExpected.DiskMBpsReadWrite != null)
                {
                    Assert.Equal(diskExpected.DiskMBpsReadWrite, diskActual.DiskMBpsReadWrite);
                }
                if (diskExpected.DiskIOPSReadOnly != null)
                {
                    Assert.Equal(diskExpected.DiskIOPSReadOnly, diskActual.DiskIOPSReadOnly);
                }
                if (diskExpected.DiskMBpsReadOnly != null)
                {
                    Assert.Equal(diskExpected.DiskMBpsReadOnly, diskActual.DiskMBpsReadOnly);
                }
                if (diskExpected.MaxShares != null)
                {
                    Assert.Equal(diskExpected.MaxShares, diskActual.MaxShares);
                }
            }

            // Creation data
            CreationData creationDataExp = diskExpected.CreationData;
            CreationData creationDataAct = diskActual.CreationData;

            Assert.Equal(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.Equal(creationDataExp.SourceUri, creationDataAct.SourceUri);
            Assert.Equal(creationDataExp.SourceResourceId, creationDataAct.SourceResourceId);
            Assert.Equal(creationDataExp.StorageAccountId, creationDataAct.StorageAccountId);

            // Image reference
            ImageDiskReference imgRefExp = creationDataExp.GalleryImageReference ?? creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.GalleryImageReference ?? creationDataAct.ImageReference;
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
