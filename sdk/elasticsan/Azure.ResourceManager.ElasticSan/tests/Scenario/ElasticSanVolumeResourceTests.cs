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
        public async Task Get()
        {
            _collection = await GetVolumeCollection();
            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData data = new ElasticSanVolumeData()
            {
                SizeGiB = 100
            };
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, data)).Value;
            ElasticSanVolumeResource volume2 = await volume1.GetAsync();
            Assert.AreEqual(volume1.Id.Name, volume2.Id.Name);
            Assert.AreEqual(100, volume2.Data.SizeGiB);
            Assert.IsEmpty(volume2.Data.Tags);
            Assert.IsNull(volume2.Data.CreationData.SourceUri);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume1.Data.CreationData.CreateSource);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            _collection = await GetVolumeCollection();
            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, GetDefaultElasticSanVolumeData())).Value;
            await volume1.DeleteAsync(WaitUntil.Completed);
            //Skip validation for deletion as server has an issue of still showing deleted volume as active
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            _collection = await GetVolumeCollection();
            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, GetDefaultElasticSanVolumeData())).Value;
            ElasticSanVolumePatch patch = new ElasticSanVolumePatch()
            {
                SizeGiB = 200
            };
            patch.Tags.Add("tag1", "value1");
            ElasticSanVolumeResource volume2 = (await volume1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(200, volume2.Data.SizeGiB);
            Assert.GreaterOrEqual(volume2.Data.Tags.Count, 1);
            Assert.AreEqual("value1", volume2.Data.Tags["tag1"]);
        }
    }
}
