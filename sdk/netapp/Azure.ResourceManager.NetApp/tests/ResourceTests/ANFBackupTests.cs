// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using FluentAssertions;
using Polly.Contrib.WaitAndRetry;
using Polly;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ANFBackupTests : NetAppTestBase
    {
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        //public static new AzureLocation DefaultLocation = AzureLocation.WestUS2;
        //public static new AzureLocation DefaultLocation = AzureLocation.EastUS2;
        public static new AzureLocation DefaultLocationString = DefaultLocation;
        internal NetAppAccountBackupCollection _accountBackupCollection;
        internal NetAppVolumeBackupCollection _volumeBackupCollection;
        internal NetAppVolumeResource _volumeResource;

        internal NetAppBackupVaultCollection _backupVaultCollection { get => _netAppAccount.GetNetAppBackupVaults(); }
        internal NetAppBackupVaultResource _backupVaultResource;
        internal NetAppBackupVaultBackupCollection _backupCollection { get => _backupVaultResource.GetNetAppBackupVaultBackups(); }
        public ANFBackupTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location: DefaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location: DefaultLocation))).Value;
            NetAppBackupVaultData backupVaultData = new NetAppBackupVaultData(DefaultLocation);
            string backupVaultName = Recording.GenerateAssetName("backupVault-");
            ArmOperation<NetAppBackupVaultResource> lro = await _backupVaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupVaultName, backupVaultData);
            _backupVaultResource = lro.Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            var volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork(location: DefaultLocation);
            _volumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId: DefaultSubnetId);
            _accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
            _volumeBackupCollection = _volumeResource.GetNetAppVolumeBackups();
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes and backups under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null && _capacityPoolCollection != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Id.Name);
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                string lastBackupName = string.Empty;
                foreach (CapacityPoolResource pool in poolList)
                {
                    NetAppVolumeCollection volumeCollection = pool.GetNetAppVolumes();
                    List<NetAppVolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ClearVolumes run: {volumeList.Count} volumes to clear");
                    int i = 0;
                    foreach (NetAppVolumeResource volume in volumeList)
                    {
                        i++;
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ClearVolumes delete volume: {i} {volume.Id.Name}, ProvisioningState: {volume.Data.ProvisioningState}");
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    await LiveDelay(30000);
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(40000);
                //remove backups
                await foreach (NetAppBackupVaultBackupResource backup in _backupCollection.GetAllAsync())
                {
                    await backup.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(30000);
                await _backupVaultResource.DeleteAsync(WaitUntil.Completed);
                await LiveDelay(30000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        //[Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateDeleteBackup()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            var secondBackupName = Recording.GenerateAssetName("secondBackup-");
            await SetUp();
            Console.WriteLine($"{DateTime.Now} Test CreateDeleteBackup");

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(_backupVaultResource.Id, backupVolumeResource.Data.DataProtection.Backup.BackupVaultId);

            //create Backup
            NetAppBackupData backupData = new NetAppBackupData(volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_backupCollection, backupName);

            //Validate
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _backupCollection.ExistsAsync(backupName + "1"));
            await LiveDelay(5000);

            //Check status again
            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetBackupStatusAsync()).Value;
            Assert.IsNotNull(backupStatus);
            Assert.AreEqual(NetAppRelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(NetAppMirrorState.Mirrored, backupStatus.MirrorState);
            await LiveDelay(120000);

            //Delete backup
            //create another Backup
            NetAppBackupData backupData2 = new(volumeResource1.Id)
            {
                Label = "secondAdHocBackup"
            };
            NetAppBackupVaultBackupResource secondBackupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondBackupName, backupData2)).Value;
            Assert.IsNotNull(secondBackupResource1);
            Assert.AreEqual(secondBackupName, secondBackupResource1.Id.Name);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_backupCollection, secondBackupName);

            List<NetAppBackupVaultBackupResource> backupsListResult = await _backupCollection.GetAllAsync(filter:volumeResource1.Id).ToEnumerableAsync();
            backupsListResult.Should().HaveCount(2);

            //Test delete action on backup deleting the first backup
            await backupResource1.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);

            backupsListResult = await _backupCollection.GetAllAsync(filter: volumeResource1.Id).ToEnumerableAsync();
            backupsListResult.Should().HaveCount(1);

            //Check deletion
            Assert.IsFalse(await _backupCollection.ExistsAsync(backupName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupCollection.GetAsync(backupName); });
            Assert.AreEqual(404, exception.Status);
            await LiveDelay(40000);
        }

        [RecordedTest]
        public async Task UpdateBackup()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupConfiguration = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupConfiguration;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupConfiguration.BackupVaultId, backupVolumeResource.Data.DataProtection.Backup.BackupVaultId);

            //create Backup
            NetAppBackupData backupData = new(volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_backupCollection, backupName);
            //Validate
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupCollection.ExistsAsync(backupResource2.Id.Name));
            Assert.IsFalse(await _backupCollection.ExistsAsync(backupName + "1"));

            //Update backup
            NetAppBackupVaultBackupPatch backupPatch = new()
            {
                Label = "updatedLabel"
            };
            NetAppBackupVaultBackupResource backupResource3 = (await backupResource2.UpdateAsync(WaitUntil.Completed, backupPatch)).Value;
            await WaitForBackupSucceeded(_backupCollection, backupName);
            //Validate
            NetAppBackupVaultBackupResource backupResource4 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource4);
            //Currently there is a serivce side bug where label does not get updated uncomment when fixed
            //Assert.AreEqual(backupPatch.Label, backupResource4.Data.Label);
        }

        [RecordedTest]
        public async Task ListBackups()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            var backupName2 = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);

            //create Backup
            NetAppBackupData backupData = new(volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_backupCollection, backupName);
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);

            //create second Backup
            NetAppBackupData backupData2 = new(volumeResource1.Id)
            {
                Label = "adHocBackup2"
            };
            NetAppBackupVaultBackupResource backup2Resource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_backupCollection, backupName2);
            NetAppBackupVaultBackupResource backup2Resource2 = await _backupCollection.GetAsync(backupName2);

            //Validate
            List<NetAppBackupVaultBackupResource> volumeBackupList = await _backupCollection.GetAllAsync().ToEnumerableAsync();
            volumeBackupList.Should().HaveCount(2);
            NetAppBackupVaultBackupResource backupResource3 = null;
            NetAppBackupVaultBackupResource backup2Resource3 = null;
            foreach (NetAppBackupVaultBackupResource backup in volumeBackupList)
            {
                if (backup.Id.Name.Equals(backupName))
                    backupResource3 = backup;
                else if (backup.Id.Name.Equals(backupName2))
                    backup2Resource3 = backup;
            }
            backupResource3.Should().BeEquivalentTo(backupResource2);
            backup2Resource3.Should().BeEquivalentTo(backup2Resource2);
        }

        [RecordedTest]
        public async Task GetBackupStatus()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupConfiguration = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupConfiguration;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupConfiguration.BackupVaultId, backupVolumeResource.Data.DataProtection.Backup.BackupVaultId);

            //create Backup
            NetAppBackupData backupData = new(volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_backupCollection, backupName);
            //Validate
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _backupCollection.ExistsAsync(backupName + "1"));

            //Get backup status
            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetLatestStatusBackupAsync()).Value;
            Assert.IsNotNull(backupStatus);
            //we need creation to finish else we cannot cleanup
            Assert.AreEqual(NetAppRelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(NetAppMirrorState.Mirrored, backupStatus.MirrorState);
        }

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateVolumeFromBackupCheckRestoreStatus()
        {
            string newVolumeName = Recording.GenerateAssetName("restoredVolume-");
            var backupName = Recording.GenerateAssetName("backup-");
            await SetUp();
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.BackupVaultId, backupVolumeResource.Data.DataProtection.Backup.BackupVaultId);

            //create Backup
            NetAppBackupData backupData = new(volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(40000);
            await WaitForBackupSucceeded(_backupCollection, backupName);
            //Validate
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _backupCollection.ExistsAsync(backupName + "1"));

            //Restore backup
            //You can restore a backup only to a new volume. You cannot overwrite the existing volume with the backup
            NetAppVolumeResource _restoredVolumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, subnetId: DefaultSubnetId, backupId: backupResource2.Id);
            await LiveDelay(40000);
            NetAppVolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name);
            Assert.IsNotNull(newVolumeResource2.Data.OriginatingResourceId);
            Assert.AreEqual(backupResource2.Id, newVolumeResource2.Data.OriginatingResourceId);

            await WaitForVolumeSucceeded(_volumeCollection, _restoredVolumeResource);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} RestoredVolume volume: {_restoredVolumeResource.Id.Name}, ProvisioningState: {_restoredVolumeResource.Data.ProvisioningState}");
            await LiveDelay(60000);
            await WaitForRestoreStatusSucceeded(_restoredVolumeResource);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} RestoredVolume volume: {_restoredVolumeResource.Id.Name}, ProvisioningState: {_restoredVolumeResource.Data.ProvisioningState}");
            await LiveDelay(40000);
        }

        [RecordedTest]
        public async Task ListBackupsPerVolumeWithBackupVault()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            var vol2backupName = Recording.GenerateAssetName("vol2backup-");
            var volumeName2 = Recording.GenerateAssetName("volume-");
            await SetUp();

            //Create second volume
            NetAppVolumeResource volume2Resource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName2);

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                BackupVaultId = _backupVaultResource.Id
            };
            NetAppVolumePatchDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            NetAppVolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            volume2Resource = (await volume2Resource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            NetAppVolumeResource backupVolume2Resource = await _volumeCollection.GetAsync(volume2Resource.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(_backupVaultResource.Id, backupVolumeResource.Data.DataProtection.Backup.BackupVaultId);
            Assert.AreEqual(_backupVaultResource.Id, backupVolume2Resource.Data.DataProtection.Backup.BackupVaultId);

            //create Backup
            NetAppBackupData backupData = new(volumeResourceId: volumeResource1.Id)
            {
                Label = "adHocBackup"
            };
            NetAppBackupVaultBackupResource backupResource1 = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);

            //create Backup for second volume
            NetAppBackupData vol2backupData = new(volumeResourceId: volume2Resource.Id)
            {
               Label = "adHocBackup"
            };

            NetAppBackupVaultBackupResource vol2backupResource = (await _backupCollection.CreateOrUpdateAsync(WaitUntil.Completed, vol2backupName, vol2backupData)).Value;
            Assert.IsNotNull(vol2backupResource);
            Assert.AreEqual(vol2backupName, vol2backupResource.Id.Name);

            //await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            ////Validate
            NetAppBackupVaultBackupResource backupResource2 = await _backupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);

            //Validate we can get all backups in vault
            List<NetAppBackupVaultBackupResource> backupList = await _backupCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(backupList);
            backupList.Should().HaveCount(2);

            //Validate filtering for volume1
            Console.WriteLine($"GET BackupListFiltered for Backup {_volumeResource.Id}");
            List<NetAppBackupVaultBackupResource> backupListFiltered = await _backupCollection.GetAllAsync(filter: volumeResource1.Id).ToEnumerableAsync();
            Assert.IsNotNull(backupListFiltered);
            foreach (NetAppBackupVaultBackupResource backup in backupListFiltered)
            {
                Console.WriteLine($"BackupListFiltered for Backup {backup.Id}, volumeResourceId: {backup.Data.VolumeResourceId}");
            }
            backupListFiltered.Should().HaveCount(1);
            Assert.AreEqual(backupName, backupListFiltered[0].Id.Name);
            Assert.AreEqual(_volumeResource.Id, backupListFiltered[0].Data.VolumeResourceId);

            //Validate filtering for volume2
            List<NetAppBackupVaultBackupResource> backupListFilteredVol2 = await _backupCollection.GetAllAsync(filter: volume2Resource.Id).ToEnumerableAsync();
            Assert.IsNotNull(backupListFiltered);
            backupListFilteredVol2.Should().HaveCount(1);
            Assert.AreEqual(vol2backupName, backupListFilteredVol2[0].Id.Name);
            Assert.AreEqual(volume2Resource.Id, backupListFilteredVol2[0].Data.VolumeResourceId);

            await LiveDelay(30000);
            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            await volume2Resource.DeleteAsync(WaitUntil.Completed);

            //await backupResource1.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(30000);
            //Currently there is a serivce side bug where label does not get updated uncomment when fixed
            //Assert.AreEqual(backupPatch.Label, backupResource4.Data.Label);
        }

        private async Task WaitForBackupSucceeded(NetAppVolumeBackupCollection volumeBackupCollection, string backupName)
        {
            Console.WriteLine($"WaitForBackupSucceeded for Backup {volumeBackupCollection.Id}/backups/{backupName}");
            var maxDelay = TimeSpan.FromSeconds(500);
            int count = 0;
            if (Mode == RecordedTestMode.Playback)
            {
                maxDelay = TimeSpan.FromMilliseconds(50);
            }
            Console.WriteLine($"...decorrelated maxdelay {maxDelay}");
            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(20), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                    {
                        count++;
                        NetAppVolumeBackupResource backup = await volumeBackupCollection.GetAsync(backupName);
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} GetBackupStatus run: {count} provisioning state is {backup.Data.ProvisioningState}");
                        if (backup.Data.ProvisioningState.Equals("Succeeded") || backup.Data.ProvisioningState.Equals("Failed"))
                        {
                            //Check status as well
                            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetBackupStatusAsync()).Value;
                            if (backup.Data.ProvisioningState.Equals("Failed"))  //we want to report the backupStatus and FailureReason
                            {
                                //no use retrying
                                throw new Exception($"Backup failed ProvisioningState: {backup.Data.ProvisioningState} FailureReason: \"{backup.Data.FailureReason}\" BackupStatus.MirrorState: {backupStatus.MirrorState}, BackupStatus.ErrorMessage: \"{backupStatus.ErrorMessage}\",  BackupStatus.Relationship status {backupStatus.RelationshipStatus}");
                            }
                            Console.WriteLine($"Get BackupStatus state run {count} BackupStatus.MirrorState: {backupStatus.MirrorState}, BackupStatus.RelationshipStatus: {backupStatus.RelationshipStatus}");
                            if (backupStatus.MirrorState == NetAppMirrorState.Mirrored)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }

        private async Task WaitForBackupSucceeded(NetAppBackupVaultBackupCollection backupCollection, string backupName)
        {
            Console.WriteLine($"WaitForBackupSucceeded for Backup {backupCollection.Id}/backups/{backupName}");
            var maxDelay = TimeSpan.FromSeconds(500);
            int count = 0;
            if (Mode == RecordedTestMode.Playback)
            {
                maxDelay = TimeSpan.FromMilliseconds(50);
            }
            Console.WriteLine($"...decorrelated maxdelay {maxDelay}");
            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(20), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    count++;
                    NetAppBackupVaultBackupResource backup = await backupCollection.GetAsync(backupName);
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} GetBackupStatus run: {count} provisioning state is {backup.Data.ProvisioningState}");
                    if (backup.Data.ProvisioningState.Equals("Succeeded") || backup.Data.ProvisioningState.Equals("Failed"))
                    {
                        //Check status as well
                        NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetLatestStatusBackupAsync()).Value;
                        if (backup.Data.ProvisioningState.Equals("Failed"))  //we want to report the backupStatus and FailureReason
                        {
                            //no use retrying
                            throw new Exception($"Backup failed ProvisioningState: {backup.Data.ProvisioningState} FailureReason: \"{backup.Data.FailureReason}\" BackupStatus.MirrorState: {backupStatus.MirrorState}, BackupStatus.ErrorMessage: \"{backupStatus.ErrorMessage}\",  BackupStatus.Relationship status {backupStatus.RelationshipStatus}");
                        }
                        Console.WriteLine($"Get BackupStatus state run {count} BackupStatus.MirrorState: {backupStatus.MirrorState}, BackupStatus.RelationshipStatus: {backupStatus.RelationshipStatus}");
                        if (backupStatus.MirrorState == NetAppMirrorState.Mirrored)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }

        private async Task WaitForRestoreStatusSucceeded(NetAppVolumeResource volumeResource = null)
        {
            volumeResource ??= _volumeResource;
            Console.WriteLine($"WaitForRestoreStatusSucceeded for volume {volumeResource.Id}");
            var maxDelay = TimeSpan.FromSeconds(120);
            int count = 0;
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    count++;

                    //Check status as well
                    NetAppRestoreStatus restoreStatus = (await volumeResource.GetVolumeLatestRestoreStatusBackupAsync()).Value;
                    Console.WriteLine($"Get RestoreStatus state volume: {volumeResource.Id} run {count} RestoreStatus.MirrorState {restoreStatus.MirrorState}, RestoreStatus.RelationsShip status {restoreStatus.RelationshipStatus}");
                    if (restoreStatus.MirrorState == NetAppMirrorState.Mirrored)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }
        private async Task WaitForVolumeSucceeded(NetAppVolumeCollection volumeCollection, NetAppVolumeResource volumeResource = null)
        {
            if (volumeResource == null)
            {
                volumeResource = _volumeResource;
            }

            var maxDelay = TimeSpan.FromSeconds(120);
            int count = 0;
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    count++;
                    NetAppVolumeResource volume = await volumeCollection.GetAsync(volumeResource.Id.Name);
                    Console.WriteLine($"Get provisioning state for volume {volumeResource.Id.Name} run {count} provisioning state is {volume.Data.ProvisioningState}");
                    if (volume.Data.ProvisioningState.Equals("Succeeded") || volume.Data.ProvisioningState.Equals("Failed"))
                    {
                        return true;
                    }
                    else
                    {
                        //retry
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }
    }
}
