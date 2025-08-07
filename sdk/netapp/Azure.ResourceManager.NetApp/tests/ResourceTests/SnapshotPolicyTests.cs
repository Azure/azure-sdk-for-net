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
    public class SnapshotPolicyTests : NetAppTestBase
    {
        internal SnapshotPolicyCollection _snapshotPolicyCollection { get => _netAppAccount.GetSnapshotPolicies(); }
        // Create basic policy records with a selection of data
        private readonly SnapshotPolicyHourlySchedule _hourlySchedule = new SnapshotPolicyHourlySchedule
        {
            SnapshotsToKeep = 2,
            Minute = 50
        };

        private readonly SnapshotPolicyDailySchedule _dailySchedule = new SnapshotPolicyDailySchedule
        {
            SnapshotsToKeep = 4,
            Hour = 14,
            Minute = 30
        };

        private readonly SnapshotPolicyWeeklySchedule _weeklySchedule = new()
        {
            SnapshotsToKeep = 3,
            Day = "Wednesday",
            Hour = 14,
            Minute = 45
        };

        private readonly SnapshotPolicyMonthlySchedule _monthlySchedule = new SnapshotPolicyMonthlySchedule
        {
            SnapshotsToKeep = 5,
            DaysOfMonth = "10,11,12",
            Hour = 14,
            Minute = 15
        };

        public SnapshotPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(location: DefaultLocationString);
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocationString);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            _netAppAccount = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
        }

        [TearDown]
        public async Task ClearSnapshotPolicies()
        {
            //remove all SnapshotPolicies under current netAppAccound and remove netAppAccount
            if (_resourceGroup != null)
            {
                List<SnapshotPolicyResource> snapshotPolicyList = await _snapshotPolicyCollection.GetAllAsync().ToEnumerableAsync();
                //remove snapshotPolicies
                foreach (SnapshotPolicyResource snapshotPolicy in snapshotPolicyList)
                {
                    await snapshotPolicy.DeleteAsync(WaitUntil.Completed);
                }
                //remove account
                await LiveDelay(40000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [RecordedTest]
        public async Task CreateDeleteSnapshotPolicy()
        {
            //create snapshotPolicy
            var snapshotPolicyName = Recording.GenerateAssetName("snapshotPolicy-");
            SnapshotPolicyResource snapshotPolicyResource1 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName);
            Assert.AreEqual(snapshotPolicyName, snapshotPolicyResource1.Id.Name);
            snapshotPolicyResource1.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);
            snapshotPolicyResource1.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);
            snapshotPolicyResource1.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);

            //validate if created successfully, get from collection
            SnapshotPolicyResource snapshotPolicyResource2 = await _snapshotPolicyCollection.GetAsync(snapshotPolicyName);
            snapshotPolicyResource2.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);
            snapshotPolicyResource2.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);
            snapshotPolicyResource2.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotPolicyCollection.GetAsync(snapshotPolicyName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotPolicyCollection.ExistsAsync(snapshotPolicyName));
            Assert.IsFalse(await _snapshotPolicyCollection.ExistsAsync(snapshotPolicyName + "1"));

            //delete snapshotPolicy
            await snapshotPolicyResource1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _snapshotPolicyCollection.ExistsAsync(snapshotPolicyName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotPolicyCollection.GetAsync(snapshotPolicyName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task ListSnapshotPolicies()
        {
            //create snapshotPolicy
            var snapshotPolicyName = Recording.GenerateAssetName("snapshotPolicy-");
            var snapshotPolicyName2 = Recording.GenerateAssetName("snapshotPolicy-");
            SnapshotPolicyResource snapshotPolicyResource1 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicyResource2 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName2);
            Assert.AreEqual(snapshotPolicyName, snapshotPolicyResource1.Id.Name);
            snapshotPolicyResource1.Data.HourlySchedule.Should().BeEquivalentTo(_hourlySchedule);
            snapshotPolicyResource1.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);
            snapshotPolicyResource1.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);

            //validate if created successfully, get from collection
            SnapshotPolicyResource snapshotPolicyGetResource1 = await _snapshotPolicyCollection.GetAsync(snapshotPolicyName);
            SnapshotPolicyResource snapshotPolicyGetResource2 = await _snapshotPolicyCollection.GetAsync(snapshotPolicyName2);
            List<SnapshotPolicyResource> snapshotPoliciesList = await _snapshotPolicyCollection.GetAllAsync().ToEnumerableAsync();
            snapshotPoliciesList.Should().HaveCount(2);
            SnapshotPolicyResource snapshotPolicyResource3 = null;
            SnapshotPolicyResource snapshotPolicyResource4 = null;
            foreach (SnapshotPolicyResource snapshotPolicy in snapshotPoliciesList)
            {
                if (snapshotPolicy.Id.Name.Equals(snapshotPolicyName))
                    snapshotPolicyResource3 = snapshotPolicy;
                else if (snapshotPolicy.Id.Name.Equals(snapshotPolicyName2))
                    snapshotPolicyResource4 = snapshotPolicy;
            }
            snapshotPolicyResource3.Should().BeEquivalentTo(snapshotPolicyGetResource1);
            snapshotPolicyResource4.Should().BeEquivalentTo(snapshotPolicyGetResource2);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotPolicyCollection.GetAsync(snapshotPolicyName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotPolicyCollection.ExistsAsync(snapshotPolicyName));
            Assert.IsFalse(await _snapshotPolicyCollection.ExistsAsync(snapshotPolicyName + "1"));
        }

        [RecordedTest]
        public async Task UpdateSnapshotPolicy()
        {
            //create CapacityPool
            var snapshotPolicyName = Recording.GenerateAssetName("snapshotPolicy-");
            SnapshotPolicyResource snapshotPolicyResource1 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName);
            Assert.AreEqual(snapshotPolicyName, snapshotPolicyResource1.Id.Name);
            snapshotPolicyResource1.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);

            //Update with patch
            SnapshotPolicyPatch snapshotPolicyPatch = new(DefaultLocationString);
            SnapshotPolicyDailySchedule patchDailySchedule = new()
            {
                SnapshotsToKeep = 2,
                Hour = 10,
                Minute = 25
            };
            snapshotPolicyPatch.DailySchedule = patchDailySchedule;
            SnapshotPolicyResource snapshotPolicyPatchedResource = (await snapshotPolicyResource1.UpdateAsync(WaitUntil.Completed, snapshotPolicyPatch)).Value;
            SnapshotPolicyResource snapshotPolicyPatchedResource2 = await _snapshotPolicyCollection.GetAsync(snapshotPolicyName);
            snapshotPolicyPatchedResource2.Data.DailySchedule.Should().BeEquivalentTo(patchDailySchedule);
            snapshotPolicyPatchedResource2.Data.HourlySchedule.Should().BeEquivalentTo(_hourlySchedule);
            snapshotPolicyPatchedResource2.Data.MonthlySchedule.Should().BeEquivalentTo(_monthlySchedule);
        }

        [RecordedTest]
        public async Task CreateVolumeWithSnapshotPolicy()
        {
            //create CapacityPool
            var snapshotPolicyName = Recording.GenerateAssetName("snapshotPolicy-");
            SnapshotPolicyResource snapshotPolicyResource1 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName);
            Assert.AreEqual(snapshotPolicyName, snapshotPolicyResource1.Id.Name);
            snapshotPolicyResource1.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);
            //create capacity pool
            _capacityPool = await CreateCapacityPool(DefaultLocationString, NetAppFileServiceLevel.Premium, _poolSize);
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            //Create volume
            var volumeName = Recording.GenerateAssetName("volumeName-");
            VolumeSnapshotProperties snapshotPolicyProperties = new(snapshotPolicyResource1.Id, serializedAdditionalRawData: null);
            NetAppVolumeDataProtection dataProtectionProperties = new() {Snapshot = snapshotPolicyProperties };
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocationString, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId: DefaultSubnetId, dataProtection: dataProtectionProperties);

            //Validate if created properly
            NetAppVolumeResource snapshotVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(snapshotVolumeResource.Data.DataProtection);
            Assert.IsNull(snapshotVolumeResource.Data.DataProtection.Backup);
            Assert.IsNull(snapshotVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(snapshotPolicyProperties.SnapshotPolicyId, snapshotVolumeResource.Data.DataProtection.Snapshot.SnapshotPolicyId);

            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task ListVolumesWithSnapshotPolicy()
        {
            //create CapacityPool
            var snapshotPolicyName = Recording.GenerateAssetName("snapshotPolicy-");
            SnapshotPolicyResource snapshotPolicyResource1 = await CreateSnapshotPolicy(DefaultLocationString, snapshotPolicyName);
            Assert.AreEqual(snapshotPolicyName, snapshotPolicyResource1.Id.Name);
            snapshotPolicyResource1.Data.DailySchedule.Should().BeEquivalentTo(_dailySchedule);
            //create capacity pool
            _capacityPool = await CreateCapacityPool(DefaultLocationString, NetAppFileServiceLevel.Premium, _poolSize);
            _volumeCollection = _capacityPool.GetNetAppVolumes();
            //Create volume
            var volumeName = Recording.GenerateAssetName("volumeName-");
            VolumeSnapshotProperties snapshotPolicyProperties = new(snapshotPolicyResource1.Id, serializedAdditionalRawData: null);
            NetAppVolumeDataProtection dataProtectionProperties = new() { Snapshot = snapshotPolicyProperties };
            await CreateVirtualNetwork(DefaultLocationString);
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocationString, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName, subnetId: DefaultSubnetId, dataProtection: dataProtectionProperties);

            //Validate if created properly
            NetAppVolumeResource snapshotVolumeResource = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            Assert.IsNotNull(snapshotVolumeResource.Data.DataProtection);
            Assert.IsNull(snapshotVolumeResource.Data.DataProtection.Backup);
            Assert.IsNull(snapshotVolumeResource.Data.DataProtection.Replication);
            Assert.AreEqual(snapshotPolicyProperties.SnapshotPolicyId, snapshotVolumeResource.Data.DataProtection.Snapshot.SnapshotPolicyId);

            //List volumes
            //List<SnapshotPolicyResource> snapshotPoliciesList = await _snapshotPolicyCollection.GetAllAsync().ToEnumerableAsync();
            List<NetAppVolumeResource> volumesList = await snapshotPolicyResource1.GetVolumesAsync().ToEnumerableAsync();
            Assert.IsNotNull(volumesList);
            volumesList.Should().HaveCount(1);
            volumesList[0].Id.Should().BeEquivalentTo(snapshotVolumeResource.Id);
            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(30000);
        }

        protected async Task<SnapshotPolicyResource> CreateSnapshotPolicy(string location, string name = "")
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }
            SnapshotPolicyData snapshotPolicy = new SnapshotPolicyData(location)
            {
                IsEnabled = true,
                HourlySchedule = _hourlySchedule,
                DailySchedule = _dailySchedule,
                WeeklySchedule = _weeklySchedule,
                MonthlySchedule =_monthlySchedule
            };
            SnapshotPolicyResource snapshotPolicyResource = (await _snapshotPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, snapshotPolicy)).Value;
            return snapshotPolicyResource;
        }
    }
}
