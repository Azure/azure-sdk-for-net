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
        //public static new AzureLocation DefaultLocation = AzureLocation.WestUS2;
        public static new AzureLocation DefaultLocation = AzureLocation.EastUS2;
        public static new AzureLocation DefaultLocationString = DefaultLocation;
        internal NetAppAccountBackupCollection _accountBackupCollection;
        internal NetAppVolumeBackupCollection _volumeBackupCollection;
        internal NetAppVolumeResource _volumeResource;

        public ANFBackupTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location:DefaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location:DefaultLocation))).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            var volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork(location:DefaultLocation);
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
                        if (volume.Data.DataProtection?.Backup?.IsBackupEnabled == true)
                        {
                            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ClearVolumes volume: {i} backups is enabled, disabeling {volume.Data.ProvisioningState}, {volume.Data.DataProtection.Backup.IsBackupEnabled}");
                            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
                            {
                                IsBackupEnabled = false
                            };
                            NetAppVolumePatchDataProtection dataProtectionProperties = new();
                            dataProtectionProperties.Backup = backupPolicyProperties;
                            NetAppVolumePatch volumePatch = new(DefaultLocation);
                            volumePatch.DataProtection = dataProtectionProperties;
                            await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch);
                            await WaitForVolumeSucceeded(volumeCollection, volume);
                        }
                        await LiveDelay(30000);
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ClearVolumes volume: {i} {volume.Id.Name} provisioning state is {volume.Data.ProvisioningState}");
                        if (volume.Data.ProvisioningState.Equals("Succeeded") || volume.Data.ProvisioningState.Equals("Failed"))
                        {
                            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ClearVolumes delete volume: {i} {volume.Id.Name}");
                            await volume.DeleteAsync(WaitUntil.Completed);
                        }
                        else
                        {
                            await WaitForVolumeSucceeded(volumeCollection, volume);
                            await volume.DeleteAsync(WaitUntil.Completed);
                        }
                    }
                    await LiveDelay(30000);
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(40000);
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                //await LiveDelay(40000);
                NetAppAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
                if (!string.IsNullOrWhiteSpace(lastBackupName))
                {
                    NetAppAccountBackupResource backupResource = await accountBackupCollection.GetAsync(lastBackupName);
                    await backupResource.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(20000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
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
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(60000);
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
            await LiveDelay(5000);

            //Check status again
            NetAppVolumeBackupStatus backupStatus = (await _volumeResource.GetBackupStatusAsync()).Value;
            Assert.IsNotNull(backupStatus);
            Assert.AreEqual(NetAppRelationshipStatus.Idle, backupStatus.RelationshipStatus);
            Assert.AreEqual(NetAppMirrorState.Mirrored, backupStatus.MirrorState);
            await LiveDelay(120000);

            //Delete backup
            //create another Backup
            NetAppBackupData backupData2 = new(DefaultLocation);
            backupData.Label = "secondAdHocBackup";
            NetAppVolumeBackupResource secondBackupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondBackupName, backupData2)).Value;
            Assert.IsNotNull(secondBackupResource1);
            Assert.AreEqual(secondBackupName, secondBackupResource1.Id.Name);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_volumeBackupCollection, secondBackupName);
            //Test delete action on backup deleting the first backup
            await backupResource2.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);

            //we cannot delete last backup of existing volume need to delete volume first, or disable backups
            //await _volumeResource.DeleteAsync(WaitUntil.Completed);
            //await LiveDelay(40000);

            dataProtectionProperties.Backup.IsBackupEnabled = false;
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResourceUpdated = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            ////Then we can delete from Account level
            NetAppAccountBackupCollection accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
            //NetAppAccountBackupResource backupResource = await accountBackupCollection.GetAsync(backupName);
            //await backupResource.DeleteAsync(WaitUntil.Completed);
            //await LiveDelay(5000);

            //Check deletion
            Assert.IsFalse(await accountBackupCollection.ExistsAsync(backupName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await accountBackupCollection.GetAsync(backupName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task UpdateBackup()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
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
            NetAppVolumeBackupPatch backupPatch = new();
            backupPatch.Label = "updatedLabel";
            NetAppVolumeBackupResource backupResource3 = (await backupResource2.UpdateAsync(WaitUntil.Completed, backupPatch)).Value;
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            //Validate
            NetAppVolumeBackupResource backupResource4 = await _volumeBackupCollection.GetAsync(backupName);
            Assert.IsNotNull(backupResource4);
            //Currently there is a serivce side bug where label does not get updated uncomment when fixed
            //Assert.AreEqual(backupPatch.Label, backupResource4.Data.Label);
        }

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task ListBackups()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            var backupName2 = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);

            //create second Backup
            NetAppBackupData backupData2 = new(DefaultLocation);
            backupData.Label = "adHocBackup2";
            NetAppVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            await LiveDelay(60000);
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

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task ListAccountBackups()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            var backupName2 = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            NetAppVolumeBackupResource backupResource2 = await _volumeBackupCollection.GetAsync(backupName);
            await LiveDelay(60000);
            await WaitForBackupSucceeded(_volumeBackupCollection, backupName);

            //create second Backup
            NetAppBackupData backupData2 = new(DefaultLocation);
            backupData2.Label = "adHocBackup2";
            NetAppVolumeBackupResource backup2Resource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName2, backupData2)).Value;
            Assert.IsNotNull(backup2Resource1);
            Assert.AreEqual(backupName2, backup2Resource1.Id.Name);
            Assert.AreEqual(backupData2.Label, backup2Resource1.Data.Label);
            NetAppVolumeBackupResource backup2Resource2 = await _volumeBackupCollection.GetAsync(backupName2);
            await LiveDelay(60000);
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

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task GetBackupStatus()
        {
            var backupName = Recording.GenerateAssetName("backup-");
            await SetUp();

            //Update volume to enable backups
            NetAppVolumeBackupConfiguration backupPolicyProperties = new()
            {
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation);
            backupData.Label = "adHocBackup";
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
                IsBackupEnabled = true
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
            Assert.AreEqual(backupPolicyProperties.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //create Backup
            NetAppBackupData backupData = new(DefaultLocation)
            {
                Label = "adHocBackup"
            };
            NetAppVolumeBackupResource backupResource1 = (await _volumeBackupCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupName, backupData)).Value;
            Assert.IsNotNull(backupResource1);
            Assert.AreEqual(backupName, backupResource1.Id.Name);
            await LiveDelay(40000);
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
            NetAppVolumeResource _restoredVolumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, subnetId: DefaultSubnetId, backupId: backupResource2.Id);
            await LiveDelay(40000);
            NetAppVolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name);
            await WaitForVolumeSucceeded(_volumeCollection, _restoredVolumeResource);
            await LiveDelay(40000);

            dataProtectionProperties.Backup.IsBackupEnabled = false;
            volumePatch.DataProtection = dataProtectionProperties;
            NetAppVolumeResource volumeResourceUpdated = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            Assert.IsNotNull(volumeResourceUpdated);
            await LiveDelay(80000);
            //Get restore status
            //await WaitForRestoreStatusSucceeded(_volumeBackupCollection, backupResource2.Id.Name,  )

            //NetAppRestoreStatus restoreStatus = (await backupVolumeResource.GetRestoreStatusAsync()).Value;
            //Assert.IsNotNull(restoreStatus);

            //Console.WriteLine($"{DateTime.Now.ToLongTimeString()} RestoreStatus volume: {_restoredVolumeResource.Id.Name} is {restoreStatus.MirrorState}");
            //await WaitForRestoreStatusSucceeded(_volumeBackupCollection, backupName, volumeResource: _restoredVolumeResource);
            //await _restoredVolumeResource.DeleteAsync(WaitUntil.Completed);
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

        private async Task WaitForRestoreStatusSucceeded(NetAppVolumeBackupCollection volumeBackupCollection, string backupName, NetAppVolumeResource volumeResource = null)
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
                    NetAppVolumeBackupResource backup = await volumeBackupCollection.GetAsync(backupName);
                    Console.WriteLine($"Get provisioning state for backup {backupName} run {count} provisioning state is {backup.Data.ProvisioningState}");
                    if (backup.Data.ProvisioningState.Equals("Succeeded") || backup.Data.ProvisioningState.Equals("Failed"))
                    {
                        //Check status as well
                        NetAppRestoreStatus restoreStatus = (await volumeResource.GetRestoreStatusAsync()).Value;
                        Console.WriteLine($"Get RestoreStatus state volume: {volumeResource} run {count} RestoreStatus.MirrorState {restoreStatus.MirrorState}, RestoreStatus.RelationsShip status {restoreStatus.RelationshipStatus}");
                        if (restoreStatus.MirrorState == NetAppMirrorState.Mirrored)
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
