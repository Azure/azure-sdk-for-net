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
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanVolumeResourceTests : ElasticSanTestBase
    {
        private ElasticSanVolumeCollection _collection;

        public ElasticSanVolumeResourceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        public async Task<ElasticSanVolumeCollection> GetVolumeCollection()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            string volumeGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volGroup = (await volGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            return volGroup.GetElasticSanVolumes();
        }

        [Test]
        [RecordedTest]
        public async Task GetUpdateDelete()
        {
            _collection = await GetVolumeCollection();
            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData data = new ElasticSanVolumeData(100);
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, data)).Value;
            ElasticSanVolumeResource volume2 = await volume1.GetAsync();
            Assert.AreEqual(volume1.Id.Name, volume2.Id.Name);
            Assert.AreEqual(100, volume2.Data.SizeGiB);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume1.Data.CreationData.CreateSource);

            ElasticSanVolumePatch patch = new ElasticSanVolumePatch()
            {
                SizeGiB = 200
            };
            ElasticSanVolumeResource volume3 = (await volume1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(200, volume3.Data.SizeGiB);

            await volume1.DeleteAsync(WaitUntil.Completed, ElasticSanDeleteSnapshotsUnderVolume.True, ElasticSanForceDeleteVolume.True);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteGetRestore()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            string volumeGroupName = Recording.GenerateAssetName("testvolgroupsd-");
            var volumeGroupData = new ElasticSanVolumeGroupData();
            ElasticSanVolumeGroupResource volGroup = (await volGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, volumeGroupData)).Value;
            _collection = volGroup.GetElasticSanVolumes();

            string volumeName = Recording.GenerateAssetName("testvolumesd-");
            ElasticSanVolumeData data = new ElasticSanVolumeData(100);
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, data)).Value;

            await volume1.DeleteAsync(WaitUntil.Completed);

            ElasticSanVolumeResource softdeletedVolume = null;
            int count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                softdeletedVolume = _;
                count++;
            }
            Assert.GreaterOrEqual(count, 1);

            await volume1.DeleteAsync(WaitUntil.Completed);
            count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                softdeletedVolume = _;
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            await softdeletedVolume.DeleteAsync(WaitUntil.Completed);

            count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }
    }
}
