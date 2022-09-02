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
    public class ANFBackupTests: NetAppTestBase
    {
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        public static new AzureLocation DefaultLocation = AzureLocation.EastUS;
        internal NetAppAccountAccountBackupCollection _accountBackupCollection;
        internal NetAppAccountCapacityPoolVolumeBackupCollection _volumeBackupCollection;
        internal VolumeResource _volumeResource;
        public ANFBackupTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location:DefaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location:DefaultLocation))).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, ServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetVolumes();

            if (DefaultVirtualNetwork == null)
            {
                DefaultVirtualNetwork = await CreateVirtualNetwork(location:DefaultLocation);
            }
            _volumeResource = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, subnetId: DefaultSubnetId);
            _accountBackupCollection = _netAppAccount.GetNetAppAccountAccountBackups();
            _volumeBackupCollection = _volumeResource.GetNetAppAccountCapacityPoolVolumeBackups();
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes and backups under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null && _capacityPoolCollection != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Data.Name.Split('/').Last());
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                string lastBackupName = string.Empty;
                foreach (CapacityPoolResource pool in poolList)
                {
                    VolumeCollection volumeCollection = pool.GetVolumes();
                    List<VolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (VolumeResource volume in volumeList)
                    {
                        NetAppAccountCapacityPoolVolumeBackupCollection volumeBackupCollection = volume.GetNetAppAccountCapacityPoolVolumeBackups();
                        List<NetAppAccountCapacityPoolVolumeBackupResource> volumeBackupList = await volumeBackupCollection.GetAllAsync().ToEnumerableAsync();
                        int count = volumeBackupList.Count;
                        foreach (NetAppAccountCapacityPoolVolumeBackupResource backup in volumeBackupList)
                        {
                            //we cannot delete the last backup for a volume, the volume has to be deleted first and backup deleted on the accountlevel
                            if (count > 1)
                            {
                                await backup.DeleteAsync(WaitUntil.Completed);
                                count--;
                            }
                            else
                            {
                                lastBackupName = backup.Id.Name;
                            }
                        }
                        if (Mode != RecordedTestMode.Playback)
                        {
                            await Task.Delay(30000);
                        }
                        if (volume.Data.ProvisioningState.Equals("Succeeded") || volume.Data.ProvisioningState.Equals("Failed"))
                        {
                            await volume.DeleteAsync(WaitUntil.Completed);
                        }
                        else
                        {
                            await WaitForVolumeSucceeded(volumeCollection, volume);
                            await volume.DeleteAsync(WaitUntil.Completed);
                        }
                    }
                    if (Mode != RecordedTestMode.Playback)
                    {
                        await Task.Delay(30000);
                    }
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                NetAppAccountAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountAccountBackups();
                if (!string.IsNullOrWhiteSpace(lastBackupName))
                {
                    NetAppAccountAccountBackupResource backupResource = await accountBackupCollection.GetAsync(lastBackupName);
                    await backupResource.DeleteAsync(WaitUntil.Completed);
                }
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(20000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteBackup()
        {
            Console.WriteLine($"{DateTime.Now} Test CreateDeleteBackup");
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);

            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);

            //Validate
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            //Check status again
            BackupStatus backupStatus = (await _volumeResource.GetStatusBackupAsync()).Value;
            Assert.IsNotNull(backupStatus);
            Assert.AreEqual(RelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(MirrorState.Mirrored, backupStatus.MirrorState);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            //Delete backup
            //we cannot delete last backup of existing volume need to delete volume first
            await _volumeResource.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            //Then we can delete from Account level
            NetAppAccountAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountAccountBackups();
            NetAppAccountAccountBackupResource backupResource = await accountBackupCollection.GetAsync(backupName);
            await backupResource.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Check deletion
            Assert.IsFalse(await accountBackupCollection.ExistsAsync(backupName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await accountBackupCollection.GetAsync(backupName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateBackup()
        {
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);

            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name.Split('/').Last());
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupResource2.Id.Name));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Update backup
            NetAppAccountCapacityPoolVolumeBackupPatch backupPatch = new();
            backupPatch.Label = "updatedLabel";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource3 = (await backupResource2.UpdateAsync(WaitUntil.Completed, backupPatch)).Value;
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppAccountCapacityPoolVolumeBackupResource backupResource4 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource4);
            //Currently there is a serivce side bug where label does not get updated uncomment when fixed
            //Assert.AreEqual(backupPatch.Label, backupResource4.Data.Label);
        }

        [Test]
        [RecordedTest]
        public async Task ListBackups()
        {
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);

            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);

            //create second Backup
            var backupName2 = Recording.GenerateAssetName("backup-");
            BackupData backupData2 = new(DefaultLocation);
            backupData.Label = "adHocBackup2";
            NetAppAccountCapacityPoolVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName2);
            NetAppAccountCapacityPoolVolumeBackupResource backup2Resource2 = await _volumeBackupCollection.GetAsync(backupName2);

            //Validate
            List<NetAppAccountCapacityPoolVolumeBackupResource> volumeBackupList = await _volumeBackupCollection.GetAllAsync().ToEnumerableAsync();
            volumeBackupList.Should().HaveCount(2);
            NetAppAccountCapacityPoolVolumeBackupResource backupResource3 = null;
            NetAppAccountCapacityPoolVolumeBackupResource backup2Resource3 = null;
            foreach (NetAppAccountCapacityPoolVolumeBackupResource backup in volumeBackupList)
            {
                if (backup.Id.Name.Equals(backupName))
                    backupResource3 = backup;
                else if (backup.Id.Name.Equals(backupName2))
                    backup2Resource3 = backup;
            }
            backupResource3.Should().BeEquivalentTo(backupResource2);
            backup2Resource3.Should().BeEquivalentTo(backup2Resource2);
        }

        [Test]
        [RecordedTest]
        public async Task ListAccountBackups()
        {
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);

            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);

            //create second Backup
            var backupName2 = Recording.GenerateAssetName("backup-");
            BackupData backupData2 = new(DefaultLocation);
            backupData2.Label = "adHocBackup2";
            NetAppAccountCapacityPoolVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            NetAppAccountCapacityPoolVolumeBackupResource backup2Resource2 = await _volumeBackupCollection.GetAsync(backupName2);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName2);

            //Validate AccountBackups
            List<NetAppAccountAccountBackupResource> accountBackupList = await _accountBackupCollection.GetAllAsync().ToEnumerableAsync();
            accountBackupList.Should().HaveCountGreaterOrEqualTo(2);
            //get backups from account
            NetAppAccountAccountBackupResource accountBackupResource2 = await _accountBackupCollection.GetAsync(backupName);
            Assert.NotNull(accountBackupResource2);
            NetAppAccountAccountBackupResource accountBackup2Resource2 = await _accountBackupCollection.GetAsync(backupName2);
            Assert.NotNull(accountBackup2Resource2);
            NetAppAccountAccountBackupResource accountBackupResource3 = null;
            NetAppAccountAccountBackupResource accountBackup2Resource3 = null;
            foreach (NetAppAccountAccountBackupResource backup in accountBackupList)
            {
                if (backup.Id.Name.Equals(backupName))
                    accountBackupResource3 = backup;
                else if (backup.Id.Name.Equals(backupName2))
                    accountBackup2Resource3 = backup;
            }
            accountBackupResource3.Should().BeEquivalentTo(accountBackupResource2);
            accountBackup2Resource3.Should().BeEquivalentTo(accountBackup2Resource2);
        }

        [Test]
        [RecordedTest]
        public async Task GetBackupStatus()
        {
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);

            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Get backup status
            BackupStatus backupStatus = (await _volumeResource.GetStatusBackupAsync()).Value;
            Assert.IsNotNull(backupStatus);
            //we need creation to finish else we cannot cleanup
            Assert.AreEqual(RelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(MirrorState.Mirrored, backupStatus.MirrorState);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumeFromBackupCheckRestoreStatus()
        {
            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);
            //Update volume to enable backups
            VolumeBackupProperties backupPolicyProperties = new(null, false, vault.Id, true);
            VolumePatchPropertiesDataProtection dataProtectionProperties = new();
            dataProtectionProperties.Backup = backupPolicyProperties;
            VolumePatch volumePatch = new(DefaultLocation);
            volumePatch.DataProtection = dataProtectionProperties;
            VolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);

            //Validate volume is backup enabled
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.BackupEnabled, backupVolumeResource.Data.DataProtection.Backup.BackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            BackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppAccountCapacityPoolVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppAccountCapacityPoolVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Restore backup
            //You can restore a backup only to a new volume. You cannot overwrite the existing volume with the backup
            string newVolumeName = Recording.GenerateAssetName("volume-");
            VolumeResource _restoredVolumeResource = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, subnetId: DefaultSubnetId, backupId: backupResource2.Data.BackupId);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            VolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name.Split('/').Last());
            await WaitForVolumeSucceeded(_volumeCollection, _restoredVolumeResource);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            //Get restore status
            //RestoreStatus restoreStatus = (await newVolumeResource2.GetVolumeRestoreStatusBackupAsync()).Value;
            //Assert.IsNotNull(restoreStatus);
            //await WaitForRestoreStatusSucceeded(_volumeBackupCollection, backupName, volumeResource: newVolumeResource2);
        }

        private async Task WaitForBackupSucceeded(NetAppAccountCapacityPoolVolumeBackupCollection volumeBackupCollection, string backupName)
        {
            Console.WriteLine($"WaitForBackupSucceeded for Backup {volumeBackupCollection.Id}/backups/{backupName}");
            var maxDelay = TimeSpan.FromSeconds(120);
            int count = 0;
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            IEnumerable <TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                    {
                        count++;
                        NetAppAccountCapacityPoolVolumeBackupResource backup = await volumeBackupCollection.GetAsync(backupName);
                        Console.WriteLine($"run {count} provisioning state is {backup.Data.ProvisioningState}");
                        if (backup.Data.ProvisioningState.Equals("Succeeded") || backup.Data.ProvisioningState.Equals("Failed"))
                        {
                            //Check status as well
                            BackupStatus backupStatus = (await _volumeResource.GetStatusBackupAsync()).Value;
                            if (backup.Data.ProvisioningState.Equals("Failed"))
                            {
                                //no use retrying
                                throw new Exception($"Backup failed provisioning state {backup.Data.ProvisioningState} failurReason \"{backup.Data.FailureReason}\" BackupStatus.MirrorState {backupStatus.MirrorState}, BackupStatus.ErrorMessage \"{backupStatus.ErrorMessage}\",  BackupStatus.Relationship status {backupStatus.RelationshipStatus}");
                            }
                            Console.WriteLine($"Get BackupStatus state run {count} BackupStatus.MirrorState {backupStatus.MirrorState}, BackupStatus.RelationsShipt status {backupStatus.RelationshipStatus}");
                            if (backupStatus.MirrorState == MirrorState.Mirrored)
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

        private async Task WaitForRestoreStatusSucceeded(NetAppAccountCapacityPoolVolumeBackupCollection volumeBackupCollection, string backupName, VolumeResource volumeResource = null)
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
                    NetAppAccountCapacityPoolVolumeBackupResource backup = await volumeBackupCollection.GetAsync(backupName);
                    Console.WriteLine($"Get provisioning state for backup {backupName} run {count} provisioning state is {backup.Data.ProvisioningState}");
                    if (backup.Data.ProvisioningState.Equals("Succeeded") || backup.Data.ProvisioningState.Equals("Failed"))
                    {
                        //Check status as well
                        RestoreStatus restoreStatus = (await volumeResource.GetVolumeRestoreStatusBackupAsync()).Value;
                        Console.WriteLine($"Get RestoreStatus state volume: {volumeResource} run {count} BackupStatus.MirrorState {restoreStatus.MirrorState}, BackupStatus.RelationsShipt status {restoreStatus.RelationshipStatus}");
                        if (restoreStatus.MirrorState == MirrorState.Mirrored)
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
        private async Task WaitForVolumeSucceeded(VolumeCollection volumeCollection, VolumeResource volumeResource = null)
        {
            if (volumeResource == null)
            {
                volumeResource = _volumeResource;
            }
            string volumeName = volumeResource.Id.Name.Split('/').Last();
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
                    VolumeResource volume = await volumeCollection.GetAsync(volumeName);
                    Console.WriteLine($"Get provisioning state for volume {volumeName} run {count} provisioning state is {volume.Data.ProvisioningState}");
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
