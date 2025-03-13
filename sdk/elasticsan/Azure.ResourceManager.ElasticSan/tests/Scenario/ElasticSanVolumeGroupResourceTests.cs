// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        }
    }
}
