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

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ANFBackupPolicyTests : NetAppTestBase
    {
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
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            _netAppAccount = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
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
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
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

        [Test]
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

        [Test]
        [RecordedTest]
        public async Task UpdateBackupPolicy()
        {
            //create CapacityPool
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //Update with patch
            NetAppBackupPolicyPatch backupPolicyPatch = new(DefaultLocation);
            backupPolicyPatch.DailyBackupsToKeep = 1;
            NetAppBackupPolicyResource backupPolicyPatchedResource = (await backupPolicyResource1.UpdateAsync(WaitUntil.Completed, backupPolicyPatch)).Value;
            NetAppBackupPolicyResource backupPolicyPatchedResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyPatchedResource2.Id.Name);
            Assert.AreEqual(backupPolicyPatch.DailyBackupsToKeep, backupPolicyPatchedResource2.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyPatchedResource2.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyPatchedResource2.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.IsEnabled, backupPolicyPatchedResource2.Data.IsEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumeWithBackupPolicy()
        {
            //create CapacityPool
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            NetAppBackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //create capacity pool
            _capacityPool = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);
            _volumeCollection = _capacityPool.GetNetAppVolumes();

            //Create volume
            if (DefaultVirtualNetwork == null)
            {
                DefaultVirtualNetwork = await CreateVirtualNetwork();
            }
            //backupPolicyResource1.Id, false, true
            //NetAppVolumeBackupConfiguration backupPolicyProperties = new(backupPolicyResource1.Id, false, true);
            //NetAppVolumeDataProtection dataProtectionProperties = new NetAppVolumeDataProtection(backup: backupPolicyProperties, null, null);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            NetAppVolumeBackupConfiguration backupPolicyProperties = new() { BackupPolicyId = backupPolicyResource1.Id, IsPolicyEnforced = false, IsBackupEnabled = true };
            NetAppVolumeDataProtection dataProtectionProperties = new() { Backup = backupPolicyProperties};
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, subnetId:DefaultSubnetId, dataProtection: dataProtectionProperties);

            //Validate if created properly
            NetAppVolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(backupVolumeResource.Data.DataProtection);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Snapshot);
            Assert.IsNull(backupVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(backupPolicyProperties.BackupPolicyId, backupVolumeResource.Data.DataProtection.Backup.BackupPolicyId);

            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
        }

        protected async Task<NetAppBackupPolicyResource> CreateBackupPolicy(string location, string name = "")
        {
            NetAppBackupPolicyResource backupPolicyResource = (await _backupPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, _backupPolicy)).Value;
            return backupPolicyResource;
        }
    }
}
