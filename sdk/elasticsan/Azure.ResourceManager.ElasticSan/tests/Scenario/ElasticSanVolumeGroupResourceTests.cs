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
using Azure.ResourceManager.Resources;
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
        public async Task Get()
        {
            _collection = await GetVolumeGroupCollection();

            string volumeGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volumeGroup = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeGroupResource volumeGroup1 = (await volumeGroup.GetAsync()).Value;
            Assert.AreEqual(volumeGroupName, volumeGroup1.Id.Name);
            Assert.IsEmpty(volumeGroup1.Data.Tags);
            Assert.IsEmpty(volumeGroup1.Data.VirtualNetworkRules);
            Assert.AreEqual(StorageTargetType.Iscsi, volumeGroup1.Data.ProtocolType);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volumeGroup1.Data.Encryption);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            _collection = await GetVolumeGroupCollection();
            string volumeGroupName = Recording.GenerateAssetName("testvolumegroup-");
            ElasticSanVolumeGroupResource volumeGroup = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            await volumeGroup.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await _collection.ExistsAsync(volumeGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            _collection = await GetVolumeGroupCollection();
            string volumeGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volGroup = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;

            ElasticSanVolumeGroupPatch patch = new ElasticSanVolumeGroupPatch()
            {
                ProtocolType = StorageTargetType.Iscsi,
                Encryption = ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey
            };
            patch.Tags.Add("tag1", "value1");
            var vnetResourceId = new ResourceIdentifier("/subscriptions/" + DefaultSubscription.Data.Id.Name + "/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/subnet1");
            patch.VirtualNetworkRules.Add(new ElasticSanVirtualNetworkRule(vnetResourceId));

            ElasticSanVolumeGroupResource volGroup1 = (await volGroup.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(volumeGroupName, volGroup1.Id.Name);
            Assert.AreEqual(StorageTargetType.Iscsi, volGroup1.Data.ProtocolType);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volGroup1.Data.Encryption);
            Assert.AreEqual(vnetResourceId, volGroup1.Data.VirtualNetworkRules[0].VirtualNetworkResourceId);
            Assert.AreEqual("value1", volGroup1.Data.Tags["tag1"]);
        }
    }
}
