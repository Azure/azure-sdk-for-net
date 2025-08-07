// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;
using Polly.Contrib.WaitAndRetry;
using Polly;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ANFBackupPolicyTests : NetAppTestBase
    {
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        //public static new AzureLocation DefaultLocation = AzureLocation.EastUS2;
        public static new AzureLocation DefaultLocationString = DefaultLocation;
        internal NetAppBackupPolicyCollection _backupPolicyCollection { get => _netAppAccount.GetNetAppBackupPolicies(); }

        internal readonly NetAppBackupPolicyData _backupPolicy = new NetAppBackupPolicyData(DefaultLocation)
        {
            IsEnabled = true,
            DailyBackupsToKeep = 4,
            WeeklyBackupsToKeep = 3,
            MonthlyBackupsToKeep = 2
        };

        public ANFBackupPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location: DefaultLocation);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location: DefaultLocation))).Value;
        }

        [TearDown]
        public async Task ClearBackupPolicies()
        {
            //remove all backupPolicies under current netAppAccound and remove netAppAccount
            if (_resourceGroup != null)
            {
                List<NetAppBackupPolicyResource> backupPolicyList = await _backupPolicyCollection.GetAllAsync().ToEnumerableAsync();
                //remove backupPolicies
                foreach (NetAppBackupPolicyResource backupPolicy in backupPolicyList)
                {
                    await backupPolicy.DeleteAsync(WaitUntil.Completed);
                }
                //remove account
                await LiveDelay(40000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        //[Ignore("Permission issue, disable this case temporary")]
        [RecordedTest]
        public async Task CreateDeleteBackupPolicy()
        {
            //create backupPolicy
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource1.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource1.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource1.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.IsEnabled, backupPolicyResource1.Data.IsEnabled);
            //validate if created successfully, get from collection
            NetAppBackupPolicyResource backupPolicyResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource2.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource2.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource2.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.IsEnabled, backupPolicyResource2.Data.IsEnabled);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupPolicyCollection.GetAsync(backupPolicyName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupPolicyCollection.ExistsAsync(backupPolicyName));
            Assert.IsFalse(await _backupPolicyCollection.ExistsAsync(backupPolicyName + "1"));

            //delete backupPolicy
            await backupPolicyResource1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _backupPolicyCollection.ExistsAsync(backupPolicyName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupPolicyCollection.GetAsync(backupPolicyName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task ListBackupPolicies()
        {
            //create backupPolicy
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            var backupPolicyName2 = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            NetAppBackupPolicyResource backupPolicyResource2 = await CreateBackupPolicy(DefaultLocation, backupPolicyName2);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource1.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource1.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource1.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.IsEnabled, backupPolicyResource1.Data.IsEnabled);

            //validate if created successfully, get from collection
            NetAppBackupPolicyResource backupPolicyGetResource1 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            NetAppBackupPolicyResource backupPolicyGetResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName2);

            List<NetAppBackupPolicyResource> backupPoliciesList = await _backupPolicyCollection.GetAllAsync().ToEnumerableAsync();
            backupPoliciesList.Should().HaveCount(2);
            NetAppBackupPolicyResource backupPolicyResource3 = null;
            NetAppBackupPolicyResource backupPolicyResource4 = null;
            foreach (NetAppBackupPolicyResource backupPolicy in backupPoliciesList)
            {
                if (backupPolicy.Id.Name.Equals(backupPolicyName))
                    backupPolicyResource3 = backupPolicy;
                else if (backupPolicy.Id.Name.Equals(backupPolicyName2))
                    backupPolicyResource4 = backupPolicy;
            }
            backupPolicyResource3.Should().BeEquivalentTo(backupPolicyGetResource1);
            backupPolicyResource4.Should().BeEquivalentTo(backupPolicyGetResource2);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _backupPolicyCollection.GetAsync(backupPolicyName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _backupPolicyCollection.ExistsAsync(backupPolicyName));
            Assert.IsFalse(await _backupPolicyCollection.ExistsAsync(backupPolicyName + "1"));
        }

        [RecordedTest]
        public async Task UpdateBackupPolicy()
        {
            //create CapacityPool
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //Update with patch
            NetAppBackupPolicyPatch backupPolicyPatch = new(DefaultLocation);
            backupPolicyPatch.DailyBackupsToKeep = 2;
            NetAppBackupPolicyResource backupPolicyPatchedResource = (await backupPolicyResource1.UpdateAsync(WaitUntil.Completed, backupPolicyPatch)).Value;
            NetAppBackupPolicyResource backupPolicyPatchedResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyPatchedResource2.Id.Name);
            Assert.AreEqual(backupPolicyPatch.DailyBackupsToKeep, backupPolicyPatchedResource2.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyPatchedResource2.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyPatchedResource2.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.IsEnabled, backupPolicyPatchedResource2.Data.IsEnabled);
        }

        [RecordedTest]
        public async Task CreateVolumeWithBackupPolicy()
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} CreateVolumeWithBackupPolicyTest ");
            //Create backup vault
            NetAppBackupVaultCollection _backupVaultCollection = _netAppAccount.GetNetAppBackupVaults();
            NetAppBackupVaultData backupVaultData = new NetAppBackupVaultData(DefaultLocation);
            string backupVaultName = Recording.GenerateAssetName("backupVault-");
            ArmOperation<NetAppBackupVaultResource> lro = await _backupVaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, backupVaultName, backupVaultData);
            NetAppBackupVaultResource _backupVaultResource = lro.Value;

            //create CapacityPool
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //create capacity pool
            _capacityPool = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            //Create volume
            var volumeName = Recording.GenerateAssetName("volumeName-");
            NetAppVolumeBackupConfiguration backupPolicyProperties = new() { BackupPolicyId = backupPolicyResource1.Id, IsPolicyEnforced = false,  BackupVaultId = _backupVaultResource.Id };
            NetAppVolumeDataProtection dataProtectionProperties = new() { Backup = backupPolicyProperties};
            //create vnet for volume
            await CreateVirtualNetwork(location: DefaultLocation);
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId:DefaultSubnetId, dataProtection: dataProtectionProperties);

            //Validate if created properly
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.BackupPolicyId, backupVolumeResource.Data.DataProtection.Backup.BackupPolicyId);

            //Disable backupPolicy to avoid server side issue
            backupPolicyProperties = new() { BackupPolicyId = null, IsPolicyEnforced = false};
            NetAppVolumePatch parameters = new(DefaultLocation);
            NetAppVolumePatchDataProtection patchDataProtection = new() { Backup = backupPolicyProperties };
            parameters.DataProtection = patchDataProtection;
            volumeResource1 = (await volumeResource1.UpdateAsync(WaitUntil.Completed, parameters)).Value;
            await LiveDelay(40000);
            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            await WaitForVolumeDeleted(_volumeCollection, volumeResource1);
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            await _backupVaultResource.DeleteAsync(WaitUntil.Completed);
        }

        protected async Task<NetAppBackupPolicyResource> CreateBackupPolicy(string location, string name = "")
        {
            NetAppBackupPolicyResource backupPolicyResource = (await _backupPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, _backupPolicy)).Value;
            return backupPolicyResource;
        }

        private async Task WaitForVolumeDeleted(NetAppVolumeCollection volumeCollection, NetAppVolumeResource volumeResource = null)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Wait for volume deletion {volumeResource.Id.Name}");
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
                    bool exists = await volumeCollection.ExistsAsync(volumeResource.Id.Name);
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Check if volume {volumeResource.Id.Name} exists {exists} ");
                    if (!exists)
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
