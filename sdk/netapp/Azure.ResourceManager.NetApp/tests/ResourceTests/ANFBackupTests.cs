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
        private static NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        private readonly AzureLocation _defaultLocation = AzureLocation.WestUS2;
        //private new readonly AzureLocation _defaultLocationString = _defaultLocation;
        internal NetAppAccountBackupCollection _accountBackupCollection;
        internal NetAppVolumeBackupCollection _volumeBackupCollection;
        internal NetAppVolumeResource _volumeResource;

        public ANFBackupTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location:_defaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, _defaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location:_defaultLocation))).Value;

            CapacityPoolData capactiyPoolData = new(_defaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();

            DefaultVirtualNetwork = await CreateVirtualNetwork(location:_defaultLocation);
            _volumeResource = await CreateVolume(_defaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, subnetId: DefaultSubnetId);
            _accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
            _volumeBackupCollection = _volumeResource.GetNetAppVolumeBackups();
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes and backups under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null && _capacityPoolCollection != null)
            {
                _ = await _capacityPoolCollection.ExistsAsync(_capacityPool.Id.Name);
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                string lastBackupName = string.Empty;
                foreach (CapacityPoolResource pool in poolList)
                {
                    NetAppVolumeCollection volumeCollection = pool.GetNetAppVolumes();
                    List<NetAppVolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (NetAppVolumeResource volume in volumeList)
                    {
                        //NetAppVolumeBackupCollection volumeBackupCollection = volume.GetNetAppVolumeBackups();
                        //List<NetAppVolumeBackupResource> volumeBackupList = await volumeBackupCollection.GetAllAsync().ToEnumerableAsync();
                        //int count = volumeBackupList.Count;
                        //foreach (NetAppVolumeBackupResource backup in volumeBackupList)
                        //{
                        //    //we cannot delete the last backup for a volume, the volume has to be deleted first and backup deleted on the accountlevel
                        //    if (count > 1)
                        //    {
                        //        await backup.DeleteAsync(WaitUntil.Completed);
                        //        count--;
                        //    }
                        //    else
                        //    {
                        //        lastBackupName = backup.Id.Name;
                        //    }
                        //}
                        //disable backups if enabled
                        if (volume.Data.DataProtection?.Backup?.IsBackupEnabled == true)
                        {
                            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, false);
                            NetAppVolumePatchDataProtection dataProtectionProperties = new()
                            {
                                Backup = backupPolicyProperties
                            };
                            NetAppVolumePatch volumePatch = new(_defaultLocation)
                            {
                                DataProtection = dataProtectionProperties
                            };
                            await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch);
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
                NetAppAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
                if (!string.IsNullOrWhiteSpace(lastBackupName))
                {
                    NetAppAccountBackupResource backupResource = await accountBackupCollection.GetAsync(lastBackupName);
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
        //[Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateDeleteBackup()
        {
            Console.WriteLine($"{DateTime.Now} Test CreateDeleteBackup");
            //Update volume to enable backups, this one tests vaultid for backwards compat (null, false, true
            NetAppVolumeBackupConfiguration backupConfiguration = new() { IsPolicyEnforced = true };
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupConfiguration
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupConfiguration.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);

            //Validate
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
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
            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetBackupStatusAsync()).Value;
            Assert.IsNotNull(backupStatus);
            Assert.AreEqual(NetAppRelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(NetAppMirrorState.Mirrored, backupStatus.MirrorState);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(120000);
            }

            //Delete backup
            //create another Backup
            var secondBackupName = Recording.GenerateAssetName("secondBackup-");
            NetAppBackupData backupData2 = new(_defaultLocation);
            backupData.Label = "secondAdHocBackup";
            NetAppVolumeBackupResource secondBackupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondBackupName, backupData2)).Value;
            Assert.IsNotNull(secondBackupResource1);
            Assert.AreEqual(secondBackupName, secondBackupResource1.Id.Name);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, secondBackupName);

            //Test delete action on backup deleting the second backup
            await backupResource2.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }

            //we cannot delete last backup of existing volume need to delete volume first, or disable backups
            //await _volumeResource.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            dataProtectionProperties.Backup.IsBackupEnabled = false;
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResourceUpdated = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            ////Then we can delete from Account level
            NetAppAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
            //NetAppAccountBackupResource backupResource = await accountBackupCollection.GetAsync(backupName);
            //await backupResource.DeleteAsync(WaitUntil.Completed);
            //if (Mode != RecordedTestMode.Playback)
            //{
            //    await Task.Delay(5000);
            //}
            //Check deletion
            Assert.IsFalse(await accountBackupCollection.ExistsAsync(backupName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await accountBackupCollection.GetAsync(backupName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumWithBackupConfigWithVaultIdShouldWorkUsing2022_05_01()
        {
            List<NetAppVault> _vaults;
            NetAppVault _vault;
            _vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            _vault = _vaults.FirstOrDefault();
            _vaults.Should().HaveCount(1);
            Assert.IsNotNull(_vault);

            NetAppVolumeBackupConfiguration backupConfiguration = new() { IsPolicyEnforced = true, VaultId = _vault.Id };
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupConfiguration
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            //Assert.AreEqual(backupConfiguration.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupConfiguration.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);
        }

        [Test]
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task UpdateBackup()
        {
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupResource2.Id.Name));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Update backup
            NetAppVolumeBackupPatch backupPatch = new()
            {
                Label = "updatedLabel"
            };
            NetAppVolumeBackupResource backupResource3 = (await backupResource2.UpdateAsync(WaitUntil.Completed, backupPatch)).Value;
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource4 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource4);
            //Currently there is a serivce side bug where label does not get updated uncomment when fixed
            //Assert.AreEqual(backupPatch.Label, backupResource4.Data.Label);
        }

        [Test]
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task ListBackups()
        {
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);

            //create second Backup
            var backupName2 = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData2 = new(_defaultLocation);
            backupData.Label = "adHocBackup2";
            NetAppVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName2);
            NetAppVolumeBackupResource backup2Resource2 = await _volumeBackupCollection.GetAsync(backupName2);

            //Validate
            List<NetAppVolumeBackupResource> volumeBackupList = await _volumeBackupCollection.GetAllAsync().ToEnumerableAsync();
            volumeBackupList.Should().HaveCount(2);
            NetAppVolumeBackupResource backupResource3 = null;
            NetAppVolumeBackupResource backup2Resource3 = null;
            foreach (NetAppVolumeBackupResource backup in volumeBackupList)
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
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task ListAccountBackups()
        {
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            //NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);

            //create second Backup
            var backupName2 = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData2 = new(_defaultLocation)
            {
                Label = "adHocBackup2"
            };
            NetAppVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            //NetAppVolumeBackupResource backup2Resource2 = await _volumeBackupCollection.GetAsync(backupName2);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName2);

            //Validate AccountBackups
            List<NetAppAccountBackupResource> accountBackupList = await _accountBackupCollection.GetAllAsync().ToEnumerableAsync();
            accountBackupList.Should().HaveCountGreaterOrEqualTo(2);
            //get backups from account
            NetAppAccountBackupResource accountBackupResource2 = await _accountBackupCollection.GetAsync(backupName);
            Assert.NotNull(accountBackupResource2);
            NetAppAccountBackupResource accountBackup2Resource2 = await _accountBackupCollection.GetAsync(backupName2);
            Assert.NotNull(accountBackup2Resource2);
            NetAppAccountBackupResource accountBackupResource3 = null;
            NetAppAccountBackupResource accountBackup2Resource3 = null;
            foreach (NetAppAccountBackupResource backup in accountBackupList)
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
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task GetBackupStatus()
        {
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Get backup status
            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetBackupStatusAsync()).Value;
            Assert.IsNotNull(backupStatus);
            //we need creation to finish else we cannot cleanup
            Assert.AreEqual(NetAppRelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(NetAppMirrorState.Mirrored, backupStatus.MirrorState);
        }

        [Test]
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task RestoreFilesNoFiles()
        {
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Restore Files
            BackupRestoreFiles body = new BackupRestoreFiles(
                fileList: new string[]
                {
                    "/dir1/customer1.db","/dir1/customer2.db"
                },
                destinationVolumeId: volumeResource1.Id.ToString()
            );
            InvalidOperationException restoreException = Assert.ThrowsAsync<InvalidOperationException>(async () => { await backupResource1.RestoreFilesAsync(WaitUntil.Completed, body); });
            //StringAssert.Contains("SingleFileSnapshotRestoreInvalidStatusForOperation", restoreException.Message);
        }

        [Test]
        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateVolumeFromBackupCheckRestoreStatus()
        {
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);
            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new(null, false, true);
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupPolicyProperties
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            await WaitForVolumeSucceeded(_volumeCollection, _volumeResource);

            //Validate volume is backup enabled
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.VaultId, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            var backupName = Recording.GenerateAssetName("backup-");
            NetAppBackupData backupData = new(_defaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource2);
            Assert.AreEqual(backupName, backupResource2.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeBackupCollection.GetAsync(backupName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeBackupCollection.ExistsAsync(backupName));
            Assert.IsFalse(await _volumeBackupCollection.ExistsAsync(backupName + "1"));

            //Restore backup
            //You can restore a backup only to a new volume. You cannot overwrite the existing volume with the backup
            string newVolumeName = Recording.GenerateAssetName("restoredVolume-");
            NetAppVolumeResource _restoredVolumeResource = await CreateVolume(_defaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, subnetId: DefaultSubnetId, backupId: backupResource2.Id);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            NetAppVolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name);
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
            IEnumerable <TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(20), retryCount: 500)
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

        private async Task WaitForVolumeSucceeded(NetAppVolumeCollection volumeCollection, NetAppVolumeResource volumeResource = null)
        {
            volumeResource ??= _volumeResource;

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
