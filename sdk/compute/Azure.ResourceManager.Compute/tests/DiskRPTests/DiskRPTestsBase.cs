// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPTestsBase : VMTestBase
    {
        public DiskRPTestsBase(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }
        protected const string DiskNamePrefix = "diskrp";
        private string DiskRPLocation = "southeastasia";

        #region Execution
        protected async Task Disk_CRUD_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null, IList<string> zones = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            DiskRPLocation = location ?? DiskRPLocation;

            // Data
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(diskCreateOption, rgName, diskSizeGB, zones, location);
            // **********
            // SETUP
            // **********
            // Create resource group, unless create option is import in which case resource group will be created with vm,
            // or copy in which casethe resource group will be created with the original disk.
            if (diskCreateOption != DiskCreateOption.Import && diskCreateOption != DiskCreateOption.Copy)
            {
                await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            }

            // **********
            // TEST
            // **********
            // Put
            Disk diskOut = await WaitForCompletionAsync((await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk)));
            Validate(disk, diskOut, DiskRPLocation);

            // Get
            diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, DiskRPLocation);
            //string resourceGroupName, string diskName, AccessLevel access, int durationInSeconds, CancellationToken cancellationToken = default
            // Get disk access
            AccessUri accessUri = await WaitForCompletionAsync(await DisksOperations.StartGrantAccessAsync(rgName, diskName, new GrantAccessData(AccessDataDefault.Access, AccessDataDefault.DurationInSeconds)));
            Assert.NotNull(accessUri.AccessSAS);

            // Get
            diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, DiskRPLocation);

            // Patch
            // TODO: Bug 9865640 - DiskRP doesn't follow patch semantics for zones: skip this for zones
            if (zones == null)
            {
                const string tagKey = "tageKey";
                var updatedisk = new DiskUpdate();
                updatedisk.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
                diskOut = await WaitForCompletionAsync(await DisksOperations.StartUpdateAsync(rgName, diskName, updatedisk));
                Validate(disk, diskOut, DiskRPLocation);
            }

            // Get
            diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, DiskRPLocation);

            // End disk access
            await WaitForCompletionAsync(await DisksOperations.StartRevokeAccessAsync(rgName, diskName));

            // Delete
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));

            try
            {
                // Ensure it was really deleted
                await DisksOperations.GetAsync(rgName, diskName);
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                //Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }
        protected async Task Snapshot_CRUD_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null, bool incremental = false)
        {
            EnsureClientsInitialized(DefaultLocation);
            DiskRPLocation = location ?? DiskRPLocation;

            // Data
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            var snapshotName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk sourceDisk = await GenerateDefaultDisk(diskCreateOption, rgName, diskSizeGB);
            // **********
            // SETUP
            // **********
            // Create resource group
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));

            // Put disk
            Disk diskOut = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, sourceDisk));
            Validate(sourceDisk, diskOut, DiskRPLocation);

            // Generate snapshot using disk info
            Snapshot snapshot = GenerateDefaultSnapshot(diskOut.Id, incremental: incremental);

            // **********
            // TEST
            // **********
            // Put
            Snapshot snapshotOut = await WaitForCompletionAsync(await SnapshotsOperations.StartCreateOrUpdateAsync(rgName, snapshotName, snapshot));
            Validate(snapshot, snapshotOut, incremental: incremental);

            // Get
            snapshotOut = (await SnapshotsOperations.GetAsync(rgName, snapshotName)).Value;
            Validate(snapshot, snapshotOut, incremental: incremental);

            // Get access
            AccessUri accessUri = await WaitForCompletionAsync((await SnapshotsOperations.StartGrantAccessAsync(rgName, snapshotName, new GrantAccessData(AccessDataDefault.Access, AccessDataDefault.DurationInSeconds))));
            Assert.NotNull(accessUri.AccessSAS);

            // Get
            snapshotOut = (await SnapshotsOperations.GetAsync(rgName, snapshotName)).Value;
            Validate(snapshot, snapshotOut, incremental: incremental);

            // Patch
            var updatesnapshot = new SnapshotUpdate();
            const string tagKey = "tageKey";
            updatesnapshot.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
            snapshotOut = await WaitForCompletionAsync(await SnapshotsOperations.StartUpdateAsync(rgName, snapshotName, updatesnapshot));
            Validate(snapshot, snapshotOut, incremental: incremental);

            // Get
            snapshotOut = (await SnapshotsOperations.GetAsync(rgName, snapshotName)).Value;
            Validate(snapshot, snapshotOut, incremental: incremental);

            // End access
            await WaitForCompletionAsync(await SnapshotsOperations.StartRevokeAccessAsync(rgName, snapshotName));

            // Delete
            await WaitForCompletionAsync(await SnapshotsOperations.StartDeleteAsync(rgName, snapshotName));

            try
            {
                // Ensure it was really deleted
                await SnapshotsOperations.GetAsync(rgName, snapshotName);
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                //Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }

        protected async Task DiskEncryptionSet_CRUD_Execute(string methodName, string location = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            DiskRPLocation = location ?? DiskRPLocation;

            // Data
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var desName = Recording.GenerateAssetName(DiskNamePrefix);
            DiskEncryptionSet des = GenerateDefaultDiskEncryptionSet(DiskRPLocation);
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));

            // Put DiskEncryptionSet
            DiskEncryptionSet desOut = await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartCreateOrUpdateAsync(rgName, desName, des));
            Validate(des, desOut, desName);

            // Get DiskEncryptionSet
            desOut = await DiskEncryptionSetsOperations.GetAsync(rgName, desName);
            Validate(des, desOut, desName);

            // Patch DiskEncryptionSet
            const string tagKey = "tageKey";
            var updateDes = new DiskEncryptionSetUpdate();
            updateDes.Tags = new Dictionary<string, string>() { { tagKey, "tagvalue" } };
            desOut = await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartUpdateAsync(rgName, desName, updateDes));
            Validate(des, desOut, desName);
            Assert.AreEqual(1, desOut.Tags.Count);

            // Delete DiskEncryptionSet
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartDeleteAsync(rgName, desName));

            try
            {
                // Ensure it was really deleted
                await DiskEncryptionSetsOperations.GetAsync(rgName, desName);
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                //Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }

        protected async Task Disk_List_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null, string location = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            DiskRPLocation = location ?? DiskRPLocation;

            // Data
            var rgName1 = Recording.GenerateAssetName(TestPrefix);
            var rgName2 = Recording.GenerateAssetName(TestPrefix);
            var diskName1 = Recording.GenerateAssetName(DiskNamePrefix);
            var diskName2 = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk1 = await GenerateDefaultDisk(diskCreateOption, rgName1, diskSizeGB, location: location);
            Disk disk2 = await GenerateDefaultDisk(diskCreateOption, rgName2, diskSizeGB, location: location);

            // **********
            // SETUP
            // **********
            // Create resource groups, unless create option is import in which case resource group will be created with vm
            if (diskCreateOption != DiskCreateOption.Import)
            {
                await ResourceGroupsOperations.CreateOrUpdateAsync(rgName1, new ResourceGroup(DiskRPLocation));
                await ResourceGroupsOperations.CreateOrUpdateAsync(rgName2, new ResourceGroup(DiskRPLocation));
            }

            // Put 4 disks, 2 in each resource group
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName1, diskName1, disk1));
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName1, diskName2, disk2));
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName2, diskName1, disk1));
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName2, diskName2, disk2));

            // **********
            // TEST
            // **********
            // List disks under resource group
            var disksOut = await DisksOperations.ListByResourceGroupAsync(rgName1).ToEnumerableAsync();
            //Page<Disk> disksOut = (await DisksClient.ListByResourceGroupAsync(rgName1)).ToEnumerableAsync;
            Assert.AreEqual(2, disksOut.Count());
            //Assert.Null(disksOut.NextPageLink);

            disksOut = await DisksOperations.ListByResourceGroupAsync(rgName2).ToEnumerableAsync();
            Assert.AreEqual(2, disksOut.Count());
            //Assert.Null(disksOut.NextPageLink);

            // List disks under subscription
            disksOut = await DisksOperations.ListAsync().ToEnumerableAsync();
            Assert.True(disksOut.Count() >= 4);
            //if (disksOut.NextPageLink != null)
            //{
            //    disksOut = await DisksClient.ListNext(disksOut.NextPageLink);
            //    Assert.True(disksOut.Any());
            //}
        }

        protected async Task Snapshot_List_Execute(string diskCreateOption, string methodName, int? diskSizeGB = null)
        {
            EnsureClientsInitialized(DefaultLocation);

            // Data
            var rgName1 = Recording.GenerateAssetName(TestPrefix);
            var rgName2 = Recording.GenerateAssetName(TestPrefix);
            var diskName1 = Recording.GenerateAssetName(DiskNamePrefix);
            var diskName2 = Recording.GenerateAssetName(DiskNamePrefix);
            var snapshotName1 = Recording.GenerateAssetName(DiskNamePrefix);
            var snapshotName2 = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk1 = await GenerateDefaultDisk(diskCreateOption, rgName1, diskSizeGB);
            Disk disk2 = await GenerateDefaultDisk(diskCreateOption, rgName2, diskSizeGB);

            // **********
            // SETUP
            // **********
            // Create resource groups
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName1, new ResourceGroup(DiskRPLocation));
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName2, new ResourceGroup(DiskRPLocation));

            // Put 4 disks, 2 in each resource group
            Disk diskOut11 = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName1, diskName1, disk1));
            Disk diskOut12 = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName1, diskName2, disk2));
            Disk diskOut21 = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName2, diskName1, disk1));
            Disk diskOut22 = await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName2, diskName2, disk2));

            // Generate 4 snapshots using disks info
            Snapshot snapshot11 = GenerateDefaultSnapshot(diskOut11.Id);
            Snapshot snapshot12 = GenerateDefaultSnapshot(diskOut12.Id, SnapshotStorageAccountTypes.StandardZRS.ToString());
            Snapshot snapshot21 = GenerateDefaultSnapshot(diskOut21.Id);
            Snapshot snapshot22 = GenerateDefaultSnapshot(diskOut22.Id);

            // Put 4 snapshots, 2 in each resource group
            await WaitForCompletionAsync(await SnapshotsOperations.StartCreateOrUpdateAsync(rgName1, snapshotName1, snapshot11));
            await WaitForCompletionAsync(await SnapshotsOperations.StartCreateOrUpdateAsync(rgName1, snapshotName2, snapshot12));
            await WaitForCompletionAsync(await SnapshotsOperations.StartCreateOrUpdateAsync(rgName2, snapshotName1, snapshot21));
            await WaitForCompletionAsync(await SnapshotsOperations.StartCreateOrUpdateAsync(rgName2, snapshotName2, snapshot22));

            // **********
            // TEST
            // **********
            // List snapshots under resource group
            //IPage<Snapshot> snapshotsOut = await SnapshotsClient.ListByResourceGroupAsync(rgName1);
            var snapshotsOut = await SnapshotsOperations.ListByResourceGroupAsync(rgName1).ToEnumerableAsync();
            Assert.AreEqual(2, snapshotsOut.Count());
            //Assert.Null(snapshotsOut.NextPageLink);

            snapshotsOut = await SnapshotsOperations.ListByResourceGroupAsync(rgName2).ToEnumerableAsync();
            Assert.AreEqual(2, snapshotsOut.Count());
            //Assert.Null(snapshotsOut.NextPageLink);

            // List snapshots under subscription
            snapshotsOut = await SnapshotsOperations.ListAsync().ToEnumerableAsync();
            Assert.True(snapshotsOut.Count() >= 4);
            //if (snapshotsOut.NextPageLink != null)
            //{
            //    snapshotsOut = await SnapshotsClient.ListNext(snapshotsOut.NextPageLink);
            //    Assert.True(snapshotsOut.Any());
            //}
        }

        protected async Task DiskEncryptionSet_List_Execute(string methodName, string location = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            DiskRPLocation = location ?? DiskRPLocation;

            // Data
            var rgName1 = Recording.GenerateAssetName(TestPrefix);
            var rgName2 = Recording.GenerateAssetName(TestPrefix);
            var desName1 = Recording.GenerateAssetName(DiskNamePrefix);
            var desName2 = Recording.GenerateAssetName(DiskNamePrefix);
            DiskEncryptionSet des1 = GenerateDefaultDiskEncryptionSet(DiskRPLocation);
            DiskEncryptionSet des2 = GenerateDefaultDiskEncryptionSet(DiskRPLocation);

            // **********
            // SETUP
            // **********
            // Create resource groups
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName1, new ResourceGroup(DiskRPLocation));
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName2, new ResourceGroup(DiskRPLocation));

            // Put 4 diskEncryptionSets, 2 in each resource group
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartCreateOrUpdateAsync(rgName1, desName1, des1));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartCreateOrUpdateAsync(rgName1, desName2, des2));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartCreateOrUpdateAsync(rgName2, desName1, des1));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartCreateOrUpdateAsync(rgName2, desName2, des2));

            // **********
            // TEST
            // **********
            // List diskEncryptionSets under resource group
            //IPage<DiskEncryptionSet> dessOut = await DiskEncryptionSetsClient.ListByResourceGroupAsync(rgName1).ToEnumerableAsync();
            var dessOut = await DiskEncryptionSetsOperations.ListByResourceGroupAsync(rgName1).ToEnumerableAsync();
            Assert.AreEqual(2, dessOut.Count());
            //Assert.Null(dessOut.NextPageLink);

            dessOut = await DiskEncryptionSetsOperations.ListByResourceGroupAsync(rgName2).ToEnumerableAsync();
            Assert.AreEqual(2, dessOut.Count());
            //Assert.Null(dessOut.NextPageLink);

            // List diskEncryptionSets under subscription
            dessOut = await DiskEncryptionSetsOperations.ListAsync().ToEnumerableAsync();
            Assert.True(dessOut.Count() >= 4);
            //if (dessOut.NextPageLink != null)
            //{
            //    dessOut = await DiskEncryptionSetsClient.ListNext(dessOut.NextPageLink);
            //    Assert.True(dessOut.Any());
            //}

            // Delete diskEncryptionSets
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartDeleteAsync(rgName1, desName1));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartDeleteAsync(rgName1, desName2));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartDeleteAsync(rgName2, desName1));
            await WaitForCompletionAsync(await DiskEncryptionSetsOperations.StartDeleteAsync(rgName2, desName2));
        }

        protected async Task DiskEncryptionSet_CreateDisk_Execute(string methodName, string location = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            var desName = "longlivedSwaggerDES";
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.Location = location;

            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(location));
            // Get DiskEncryptionSet
            DiskEncryptionSet desOut = await DiskEncryptionSetsOperations.GetAsync("longrunningrg-southeastasia", desName);
            Assert.NotNull(desOut);
            disk.Encryption = new Encryption
            {
                Type = EncryptionType.EncryptionAtRestWithCustomerKey.ToString(),
                DiskEncryptionSetId = desOut.Id
            };
            //Put Disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(desOut.Id.ToLower(), diskOut.Encryption.DiskEncryptionSetId.ToLower());
            Assert.AreEqual(EncryptionType.EncryptionAtRestWithCustomerKey, diskOut.Encryption.Type);

            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        protected async Task DiskEncryptionSet_UpdateDisk_Execute(string methodName, string location = null)
        {
            EnsureClientsInitialized(DefaultLocation);
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            var desName = "longlivedSwaggerDES";
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.Location = location;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(location));
            // Put Disk with PlatformManagedKey
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Validate(disk, diskOut, disk.Location);
            Assert.Null(diskOut.Encryption.DiskEncryptionSetId);
            Assert.AreEqual(EncryptionType.EncryptionAtRestWithPlatformKey, diskOut.Encryption.Type);

            // Update Disk with CustomerManagedKey
            DiskEncryptionSet desOut = await DiskEncryptionSetsOperations.GetAsync("longrunningrg-southeastasia", desName);
            Assert.NotNull(desOut);
            disk.Encryption = new Encryption
            {
                Type = EncryptionType.EncryptionAtRestWithCustomerKey.ToString(),
                DiskEncryptionSetId = desOut.Id
            };
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Assert.AreEqual(desOut.Id.ToLower(), diskOut.Encryption.DiskEncryptionSetId.ToLower());
            Assert.AreEqual(EncryptionType.EncryptionAtRestWithCustomerKey, diskOut.Encryption.Type);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        #endregion

        #region Generation
        public static readonly GrantAccessData AccessDataDefault = new GrantAccessData(AccessLevel.Read, 1000);

        protected async Task<Disk> GenerateDefaultDisk(string diskCreateOption, string rgName, int? diskSizeGB = null, IList<string> zones = null, string location = null)
        {
            Disk disk;

            switch (diskCreateOption)
            {
                case "Upload":
                    disk = GenerateBaseDisk(diskCreateOption);
                    disk.CreationData.UploadSizeBytes = (long)(diskSizeGB ?? 10) * 1024 * 1024 * 1024 + 512;
                    break;
                case "Empty":
                    disk = GenerateBaseDisk(diskCreateOption);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                case "Import":
                    disk = await GenerateImportDisk(diskCreateOption, rgName, location);
                    disk.DiskSizeGB = diskSizeGB;
                    disk.Zones = zones;
                    break;
                case "Copy":
                    disk = await GenerateCopyDisk(rgName, diskSizeGB ?? 10, location);
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
        private async Task<Disk> GenerateImportDisk(string diskCreateOption, string rgName, string location)
        {
            // Create a VM, so we can use its OS disk for creating the image
            string storageAccountName = Recording.GenerateAssetName(DiskNamePrefix);
            string asName = Recording.GenerateAssetName("as");
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            VirtualMachine inputVM = null;
            m_location = location;

            // Create Storage Account
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            // Create the VM, whose OS disk will be used in creating the image
            var returnTwovm = await CreateVM(rgName, asName, storageAccountOutput, imageRef);
            var createdVM = returnTwovm.Item1;
            inputVM = returnTwovm.Item2;
            var listResponse = await VirtualMachinesOperations.ListAllAsync().ToEnumerableAsync();
            Assert.True(listResponse.Count() >= 1);
            string[] id = createdVM.Id.Split('/');
            string subscription = id[2];
            var uri = createdVM.StorageProfile.OsDisk.Vhd.Uri;

            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, createdVM.Name));

            Disk disk = GenerateBaseDisk(diskCreateOption);
            disk.CreationData.SourceUri = uri;
            disk.CreationData.StorageAccountId = "/subscriptions/" + subscription + "/resourceGroups/" + rgName + "/providers/Microsoft.Storage/storageAccounts/" + storageAccountName;
            return disk;
        }

        /// <summary>
        /// Generates a disk used when the DiskCreateOption is Copy
        /// </summary>
        /// <returns></returns>
        private async Task<Disk> GenerateCopyDisk(string rgName, int diskSizeGB, string location)
        {
            // Create an empty disk
            Disk originalDisk = await GenerateDefaultDisk("Empty", rgName, diskSizeGB: diskSizeGB);
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(location));
            Disk diskOut = await WaitForCompletionAsync((await DisksOperations.StartCreateOrUpdateAsync(rgName, Recording.GenerateAssetName(DiskNamePrefix + "_original"), originalDisk)));

            Snapshot snapshot = GenerateDefaultSnapshot(diskOut.Id);
            Snapshot snapshotOut = await WaitForCompletionAsync((await SnapshotsOperations.StartCreateOrUpdateAsync(rgName, "snapshotswaaggertest", snapshot)));

            Disk copyDisk = GenerateBaseDisk("Import");
            copyDisk.CreationData.SourceResourceId = snapshotOut.Id;
            return copyDisk;
        }

        protected DiskEncryptionSet GenerateDefaultDiskEncryptionSet(string location)
        {
            string testVaultId = @"/subscriptions/" + TestEnvironment.SubscriptionId + "/resourcegroups/swagger/providers/Microsoft.KeyVault/vaults/swaggervault";
            string encryptionKeyUri = @"https://swaggervault.vault.azure.net/keys/diskRPSSEKey/4780bcaf12384596b75cf63731f2046c";
            var des = new DiskEncryptionSet(
                                            null, null, null, location, null,
                                            new EncryptionSetIdentity
                                            (ResourceIdentityType.SystemAssigned.ToString(), null, null),
                                            new KeyVaultAndKeyReference
                                            (new SourceVault(testVaultId), encryptionKeyUri), null, null);
            return des;
        }

        public Disk GenerateBaseDisk(string diskCreateOption)
        {
            var disk = new Disk(DiskRPLocation)
            {
                Location = DiskRPLocation,
            };
            disk.Sku = new DiskSku()
            {
                Name = StorageAccountTypes.StandardLRS.ToString()
            };
            disk.CreationData = new CreationData(diskCreateOption);
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
            var snapshot = new Snapshot(null, null, null, DiskRPLocation, null, null, null, null, null, null, null, null, null, null, null, null, incremental, null);
            snapshot.Sku = new SnapshotSku()
            {
                Name = snapshotStorageAccountTypes ?? SnapshotStorageAccountTypes.StandardLRS
            };
            snapshot.CreationData = new CreationData(DiskCreateOption.Copy, null, null, null, null, sourceDiskId, null, null);
            return snapshot;
        }
        #endregion

        #region Validation

        private void Validate(DiskEncryptionSet diskEncryptionSetExpected, DiskEncryptionSet diskEncryptionSetActual, string expectedDESName)
        {
            Assert.AreEqual(expectedDESName, diskEncryptionSetActual.Name);
            Assert.AreEqual(diskEncryptionSetExpected.Location, diskEncryptionSetActual.Location);
            Assert.AreEqual(diskEncryptionSetExpected.ActiveKey.SourceVault.Id, diskEncryptionSetActual.ActiveKey.SourceVault.Id);
            Assert.AreEqual(diskEncryptionSetExpected.ActiveKey.KeyUrl, diskEncryptionSetActual.ActiveKey.KeyUrl);
            Assert.NotNull(diskEncryptionSetActual.Identity);
            Assert.AreEqual(ResourceIdentityType.SystemAssigned.ToString(), diskEncryptionSetActual.Identity.Type);
        }

        private void Validate(Snapshot snapshotExpected, Snapshot snapshotActual, bool diskHydrated = false, bool incremental = false)
        {
            // snapshot resource
            Assert.AreEqual(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "snapshots"), snapshotActual.Type);
            Assert.NotNull(snapshotActual.Name);
            Assert.AreEqual(DiskRPLocation, snapshotActual.Location);

            // snapshot properties
            Assert.AreEqual(snapshotExpected.Sku.Name, snapshotActual.Sku.Name);
            Assert.True(snapshotActual.ManagedBy == null);
            Assert.NotNull(snapshotActual.ProvisioningState);
            Assert.AreEqual(incremental, snapshotActual.Incremental);
            Assert.NotNull(snapshotActual.CreationData.SourceUniqueId);
            if (snapshotExpected.OsType != null) //these properties are not mandatory for the client
            {
                Assert.AreEqual(snapshotExpected.OsType, snapshotActual.OsType);
            }

            if (snapshotExpected.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.AreEqual(snapshotExpected.DiskSizeGB, snapshotActual.DiskSizeGB);
            }

            // Creation data
            CreationData creationDataExp = snapshotExpected.CreationData;
            CreationData creationDataAct = snapshotActual.CreationData;

            Assert.AreEqual(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.AreEqual(creationDataExp.SourceUri, creationDataAct.SourceUri);
            Assert.AreEqual(creationDataExp.SourceResourceId, creationDataAct.SourceResourceId);
            Assert.AreEqual(creationDataExp.StorageAccountId, creationDataAct.StorageAccountId);

            // Image reference
            ImageDiskReference imgRefExp = creationDataExp.GalleryImageReference ?? creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.GalleryImageReference ?? creationDataAct.ImageReference;
            if (imgRefExp != null)
            {
                Assert.AreEqual(imgRefExp.Id, imgRefAct.Id);
                Assert.AreEqual(imgRefExp.Lun, imgRefAct.Lun);
            }
            else
            {
                Assert.Null(imgRefAct);
            }
        }

        protected void Validate(Disk diskExpected, Disk diskActual, string location, bool diskHydrated = false, bool update = false)
        {
            // disk resource
            Assert.AreEqual(string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, "disks"), diskActual.Type);
            Assert.NotNull(diskActual.Name);
            Assert.AreEqual(location, diskActual.Location);

            // disk properties
            Assert.AreEqual(diskExpected.Sku.Name, diskActual.Sku.Name);
            Assert.NotNull(diskActual.ProvisioningState);
            Assert.AreEqual(diskExpected.OsType, diskActual.OsType);
            Assert.NotNull(diskActual.UniqueId);

            if (diskExpected.DiskSizeGB != null)
            {
                // Disk resizing
                Assert.AreEqual(diskExpected.DiskSizeGB, diskActual.DiskSizeGB);
                Assert.NotNull(diskActual.DiskSizeBytes);
            }

            if (!update)
            {
                if (diskExpected.DiskIopsReadWrite != null)
                {
                    Assert.AreEqual(diskExpected.DiskIopsReadWrite, diskActual.DiskIopsReadWrite);
                }

                if (diskExpected.DiskMBpsReadWrite != null)
                {
                    Assert.AreEqual(diskExpected.DiskMBpsReadWrite, diskActual.DiskMBpsReadWrite);
                }
                if (diskExpected.DiskIopsReadOnly != null)
                {
                    Assert.AreEqual(diskExpected.DiskIopsReadOnly, diskActual.DiskIopsReadOnly);
                }
                if (diskExpected.DiskMBpsReadOnly != null)
                {
                    Assert.AreEqual(diskExpected.DiskMBpsReadOnly, diskActual.DiskMBpsReadOnly);
                }
                if (diskExpected.MaxShares != null)
                {
                    Assert.AreEqual(diskExpected.MaxShares, diskActual.MaxShares);
                }
            }

            // Creation data
            CreationData creationDataExp = diskExpected.CreationData;
            CreationData creationDataAct = diskActual.CreationData;

            Assert.AreEqual(creationDataExp.CreateOption, creationDataAct.CreateOption);
            Assert.AreEqual(creationDataExp.SourceUri, creationDataAct.SourceUri);
            Assert.AreEqual(creationDataExp.SourceResourceId, creationDataAct.SourceResourceId);
            Assert.AreEqual(creationDataExp.StorageAccountId, creationDataAct.StorageAccountId);

            // Image reference
            ImageDiskReference imgRefExp = creationDataExp.GalleryImageReference ?? creationDataExp.ImageReference;
            ImageDiskReference imgRefAct = creationDataAct.GalleryImageReference ?? creationDataAct.ImageReference;
            if (imgRefExp != null)
            {
                Assert.AreEqual(imgRefExp.Id, imgRefAct.Id);
                Assert.AreEqual(imgRefExp.Lun, imgRefAct.Lun);
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
                Assert.AreEqual(zonesExp.Count, zonesAct.Count);
                foreach (string zone in zonesExp)
                {
                    ////TODO
                    //Assert.Contains(zone, zonesAct.First());
                    //Assert.Contains(zone, zonesAct, StringComparer.OrdinalIgnoreCase);
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
