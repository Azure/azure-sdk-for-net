// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ElasticSan.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanVolumeGroupResourceTests : ElasticSanTestBase
    {
        private ElasticSanVolumeGroupCollection _collection;

        public ElasticSanVolumeGroupResourceTests(bool isAsync)
             : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private async Task<ElasticSanVolumeGroupCollection> GetVolumeGroupCollection()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection collection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            return collection;
        }
        private async Task<ElasticSanVolumeCollection> GetVolumeCollection(string volumeGroupName)
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            ElasticSanVolumeGroupResource volGroup = (await volGroupCollection.GetIfExistsAsync(volumeGroupName)).Value;
            return volGroup.GetElasticSanVolumes();
        }

        [Test]
        [RecordedTest]
        public async Task GetUpdateDelete()
        {
            _collection = await GetVolumeGroupCollection();

            string volumeGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volumeGroup = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeGroupResource volumeGroup1 = (await volumeGroup.GetAsync()).Value;
            Assert.AreEqual(volumeGroupName, volumeGroup1.Id.Name);
            Assert.IsEmpty(volumeGroup1.Data.VirtualNetworkRules);
            Assert.AreEqual(ElasticSanStorageTargetType.Iscsi, volumeGroup1.Data.ProtocolType);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volumeGroup1.Data.Encryption);
            Assert.AreEqual(true, volumeGroup1.Data.EnforceDataIntegrityCheckForIscsi);

            ElasticSanVolumeGroupPatch patch = new()
            {
                ProtocolType = ElasticSanStorageTargetType.Iscsi,
                Encryption = ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                EnforceDataIntegrityCheckForIscsi = false,
            };
            var vnetResourceId = new ResourceIdentifier("/subscriptions/" + DefaultSubscription.Data.Id.Name + "/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Network/virtualNetworks/testvnet1/subnets/subnet1");
            patch.VirtualNetworkRules.Add(new ElasticSanVirtualNetworkRule(vnetResourceId));

            ElasticSanVolumeGroupResource volGroup1 = (await volumeGroup.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(volumeGroupName, volGroup1.Id.Name);
            Assert.AreEqual(ElasticSanStorageTargetType.Iscsi, volGroup1.Data.ProtocolType);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volGroup1.Data.Encryption);
            Assert.AreEqual(false, volGroup1.Data.EnforceDataIntegrityCheckForIscsi);
            Assert.AreEqual(vnetResourceId, volGroup1.Data.VirtualNetworkRules[0].VirtualNetworkResourceId);

            ElasticSanVolumeGroupPatch patch2 = new ElasticSanVolumeGroupPatch
            {
                EnforceDataIntegrityCheckForIscsi = true,
            };
            ElasticSanVolumeGroupResource volGroup2 = (await volGroup1.UpdateAsync(WaitUntil.Completed, patch2)).Value;
            Assert.AreEqual(volumeGroupName, volGroup2.Id.Name);
            Assert.AreEqual(true, volGroup2.Data.EnforceDataIntegrityCheckForIscsi);

            await volumeGroup.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await _collection.ExistsAsync(volumeGroupName));

            string volumeGroupSoftDeleteName = Recording.GenerateAssetName("testvolumegroupsd-");
            ElasticSanVolumeGroupData volumeGroupSoftDeleteData = new ElasticSanVolumeGroupData()
            {
                DeleteRetentionPolicy = new ElasticSanDeleteRetentionPolicy()
                {
                    PolicyState = ElasticSanDeleteRetentionPolicyState.Enabled,
                    RetentionPeriodDays = 1
                }
            };
            ElasticSanVolumeGroupResource volumeGroupSoftDelete = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupSoftDeleteName, volumeGroupSoftDeleteData)).Value;
            Assert.AreEqual(volumeGroupSoftDelete.Id.Name, volumeGroupSoftDeleteName);
            Assert.AreEqual(volumeGroupSoftDelete.Data.DeleteRetentionPolicy.PolicyState, ElasticSanDeleteRetentionPolicyState.Enabled);
            Assert.AreEqual(volumeGroupSoftDelete.Data.DeleteRetentionPolicy.RetentionPeriodDays, 1);
            await volumeGroupSoftDelete.DeleteAsync(WaitUntil.Completed);
            int count = 0;
            await foreach (ElasticSanVolumeGroupResource _ in _collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
        [Test]
        [RecordedTest]
        public async Task PreBackupPreRestore()
        {
            _collection = await GetVolumeGroupCollection();

            string volumeGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volumeGroup = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;

            var _volumeCollection = await GetVolumeCollection(volumeGroupName);
            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData data = new ElasticSanVolumeData(100);
            ElasticSanVolumeResource volume1 = (await _volumeCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, data)).Value;

            var volumeNameList = new ElasticSanVolumeNameListContent(new string[] { volumeName });
            var preBackup = (await volumeGroup.PreBackupVolumeAsync(WaitUntil.Completed, volumeNameList)).Value;
            Assert.AreEqual(preBackup.ValidationStatus, "Success");

            // Require a real disk snapshot id for live test
            DiskSnapshotListContent diskSnapshotList = new DiskSnapshotListContent(
                new ResourceIdentifier[] {
                    new ResourceIdentifier(
                        "/subscriptions/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa/resourceGroups/resourcegroup/providers/Microsoft.Compute/snapshots/disksnapshotid") });
            var preRestore = (await volumeGroup.PreRestoreVolumeAsync(WaitUntil.Completed, diskSnapshotList)).Value;
            Assert.AreEqual(preRestore.ValidationStatus, "Success");

            await volumeGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
