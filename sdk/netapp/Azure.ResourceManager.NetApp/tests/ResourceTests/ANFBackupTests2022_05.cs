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
    /// <summary>
    /// This test class specificly targets api-version 2022-05-01 to test vault and vaultId that were deprecated in 2022-09-01
    /// but will continue to be supproted in previous api-versions.
    /// </summary>
    [ClientTestFixture(true, "2022-05-01")]
    public class ANFBackupTests2022_05 : NetAppTestBase
    {
        private static NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        private readonly AzureLocation _defaultLocation = AzureLocation.WestUS2;
        //private new readonly AzureLocation _defaultLocationString = _defaultLocation;
        internal NetAppAccountBackupCollection _accountBackupCollection;
        internal NetAppVolumeBackupCollection _volumeBackupCollection;
        internal NetAppVolumeResource _volumeResource;

        public ANFBackupTests2022_05(bool isAsync, string apiVersion) : base(isAsync, NetAppVolumeResource.ResourceType, apiVersion)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            _resourceGroup = await CreateResourceGroupAsync(location:_defaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, _defaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location:_defaultLocation))).Value;

            CapacityPoolData capactiyPoolData = new(_defaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            var volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork(location:_defaultLocation);
            _volumeResource = await CreateVolume(_defaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId: DefaultSubnetId);
            _accountBackupCollection = _netAppAccount.GetNetAppAccountBackups();
            _volumeBackupCollection = _volumeResource.GetNetAppVolumeBackups();
            watch.Stop();
            TestContext.WriteLine($"Setup elapsed time {watch.ElapsedMilliseconds} ms {watch.Elapsed}");
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
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
                        if (volume.Data.DataProtection?.Backup?.IsBackupEnabled == true)
                        {
                            NetAppVolumeBackupConfiguration backupPolicyProperties = new() { IsBackupEnabled = false };
                            NetAppVolumePatchDataProtection dataProtectionProperties = new()
                            {
                                Backup = backupPolicyProperties
                            };
                            NetAppVolumePatch volumePatch = new(_defaultLocation)
                            {
                                DataProtection = dataProtectionProperties
                            };
                            await volume.UpdateAsync(WaitUntil.Completed, volumePatch);
                        }
                        await LiveDelay(30000);
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
            watch.Stop();
            TestContext.WriteLine($"TearDown elapsed time {watch.ElapsedMilliseconds} ms {watch.Elapsed}");
            _resourceGroup = null;
        }

        [Ignore("Ignore for now due to service side issue, re-enable when service side issue is fixed")]
        [RecordedTest]
        public async Task CreateVolumWithBackupConfigWithVaultIdShouldWorkUsing2022_05_01()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<NetAppVault> _vaults;
            NetAppVault _vault;
            _vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            _vault = _vaults.FirstOrDefault();
            _vaults.Should().HaveCount(1);
            Assert.IsNotNull(_vault);

            //Update volume to enable backups, this one tests vaultid for backwards compatability
            NetAppVolumeBackupConfiguration backupConfiguration = new() { IsBackupEnabled = true, VaultId = _vault.Id };
            NetAppVolumePatchDataProtection dataProtectionProperties = new()
            {
                Backup = backupConfiguration
            };
            NetAppVolumePatch volumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            NetAppVolumeResource volumeResource1 = (await _volumeResource.UpdateAsync(WaitUntil.Completed, volumePatch)).Value;
            await LiveDelay(5000);

            //Validate 2022-05-01 volume after update
            NetAppVolumeResource getVolumeResource2022_05 = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            watch.Stop();
            TestContext.WriteLine($"GET 2022-05-01 volume: elapsed time {watch.ElapsedMilliseconds} ms {watch.Elapsed}");

            Assert.IsNotNull(getVolumeResource2022_05.Data.DataProtection);
            Assert.IsNull(getVolumeResource2022_05.Data.DataProtection.Snapshot);
            Assert.IsNull(getVolumeResource2022_05.Data.DataProtection.Replication);
           // Assert.AreEqual(backupConfiguration.VaultId, getVolumeResource2022_05.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupConfiguration.IsBackupEnabled, getVolumeResource2022_05.Data.DataProtection.Backup.IsBackupEnabled);

            //Validate volume is backup enabled, api-version 2022-09-01
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.NotNull(backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(_vault.Id, backupVolumeResource.Data.DataProtection.Backup.VaultId);
            Assert.AreEqual(backupConfiguration.IsBackupEnabled, backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);

            //Disable the backup
            backupConfiguration.IsBackupEnabled = false;
            backupConfiguration.VaultId = _vault.Id;
            dataProtectionProperties.Backup = backupConfiguration;
            NetAppVolumePatch disableBackupVolumePatch = new(_defaultLocation)
            {
                DataProtection = dataProtectionProperties
            };
            watch.Restart();
            NetAppVolumeResource disabledBackupVolumeResource = (await backupVolumeResource.UpdateAsync(WaitUntil.Completed, disableBackupVolumePatch)).Value;
            TestContext.WriteLine($"Disable: elapsed time {watch.ElapsedMilliseconds} ms {watch.Elapsed}");
            // Assert.IsFalse(backupVolumeResource.Data.DataProtection.Backup.IsBackupEnabled);
            getVolumeResource2022_05 = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            Assert.IsFalse(getVolumeResource2022_05.Data.DataProtection.Backup.IsBackupEnabled);
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
