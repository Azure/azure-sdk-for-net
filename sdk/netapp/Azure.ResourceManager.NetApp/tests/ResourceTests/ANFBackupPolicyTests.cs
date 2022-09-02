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
        internal BackupPolicyCollection _backupPolicyCollection { get => _netAppAccount.GetBackupPolicies(); }

        internal readonly BackupPolicyData _backupPolicy = new BackupPolicyData(DefaultLocation)
        {
            Enabled = true,
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
                List<BackupPolicyResource> backupPolicyList = await _backupPolicyCollection.GetAllAsync().ToEnumerableAsync();
                //remove backupPolicies
                foreach (BackupPolicyResource backupPolicy in backupPolicyList)
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
            BackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource1.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource1.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource1.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.Enabled, backupPolicyResource1.Data.Enabled);
            //validate if created successfully, get from collection
            BackupPolicyResource backupPolicyResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource2.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource2.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource2.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.Enabled, backupPolicyResource2.Data.Enabled);

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
            BackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            BackupPolicyResource backupPolicyResource2 = await CreateBackupPolicy(DefaultLocation, backupPolicyName2);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);
            Assert.AreEqual(_backupPolicy.DailyBackupsToKeep, backupPolicyResource1.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyResource1.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyResource1.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.Enabled, backupPolicyResource1.Data.Enabled);

            //validate if created successfully, get from collection
            BackupPolicyResource backupPolicyGetResource1 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            BackupPolicyResource backupPolicyGetResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName2);

            List<BackupPolicyResource> backupPoliciesList = await _backupPolicyCollection.GetAllAsync().ToEnumerableAsync();
            backupPoliciesList.Should().HaveCount(2);
            BackupPolicyResource backupPolicyResource3 = null;
            BackupPolicyResource backupPolicyResource4 = null;
            foreach (BackupPolicyResource backupPolicy in backupPoliciesList)
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
            BackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //Update with patch
            BackupPolicyPatch backupPolicyPatch = new(DefaultLocation);
            backupPolicyPatch.DailyBackupsToKeep = 1;
            BackupPolicyResource backupPolicyPatchedResource = (await backupPolicyResource1.UpdateAsync(WaitUntil.Completed, backupPolicyPatch)).Value;
            BackupPolicyResource backupPolicyPatchedResource2 = await _backupPolicyCollection.GetAsync(backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyPatchedResource2.Id.Name);
            Assert.AreEqual(backupPolicyPatch.DailyBackupsToKeep, backupPolicyPatchedResource2.Data.DailyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.WeeklyBackupsToKeep, backupPolicyPatchedResource2.Data.WeeklyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.MonthlyBackupsToKeep, backupPolicyPatchedResource2.Data.MonthlyBackupsToKeep);
            Assert.AreEqual(_backupPolicy.Enabled, backupPolicyPatchedResource2.Data.Enabled);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumeWithBackupPolicy()
        {
            //create CapacityPool
            var backupPolicyName = Recording.GenerateAssetName("backupPolicy-");
            BackupPolicyResource backupPolicyResource1 = await CreateBackupPolicy(DefaultLocation, backupPolicyName);
            Assert.AreEqual(backupPolicyName, backupPolicyResource1.Id.Name);

            //getVault id
            List<Vault> vaults = await _netAppAccount.GetVaultsAsync().ToEnumerableAsync();
            vaults.Should().HaveCount(1);
            Vault vault = vaults.FirstOrDefault();
            Assert.IsNotNull(vault);
            //create capacity pool
            _capacityPool = await CreateCapacityPool(DefaultLocation, ServiceLevel.Premium, _poolSize);
            _volumeCollection = _capacityPool.GetVolumes();

            //Create volume
            if (DefaultVirtualNetwork == null)
            {
                DefaultVirtualNetwork = await CreateVirtualNetwork();
            }
            VolumeBackupProperties backupPolicyProperties = new(backupPolicyResource1.Id, false, vault.Id, true);
            VolumePropertiesDataProtection dataProtectionProperties = new VolumePropertiesDataProtection(backup: backupPolicyProperties, null,null);
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, subnetId:DefaultSubnetId, dataProtection: dataProtectionProperties);

            //Validate if created properly
            VolumeResource backupVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
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

        protected async Task<BackupPolicyResource> CreateBackupPolicy(string location, string name = "")
        {
            BackupPolicyResource backupPolicyResource = (await _backupPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, _backupPolicy)).Value;
            return backupPolicyResource;
        }
    }
}
