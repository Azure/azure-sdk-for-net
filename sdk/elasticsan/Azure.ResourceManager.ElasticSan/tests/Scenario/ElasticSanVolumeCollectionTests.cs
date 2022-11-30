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
    public class ElasticSanVolumeCollectionTests : ElasticSanTestBase
    {
        private ElasticSanVolumeCollection _collection;

        public ElasticSanVolumeCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        public async Task<ElasticSanVolumeCollection> GetVolumeCollection()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            string volGroupName = Recording.GenerateAssetName("testvolgroup-");
            ElasticSanVolumeGroupResource volGroup = (await volGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeCollection collection = volGroup.GetElasticSanVolumes();
            return collection;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            _collection = await GetVolumeCollection();

            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData volumeData = new ElasticSanVolumeData()
            {
                SizeGiB = 100,
                CreationData = new Models.ElasticSanVolumeDataSourceInfo()
            };
            volumeData.CreationData.SourceUri = new Uri("http://abc.com");
            volumeData.Tags.Add("tag1", "value1");
            volumeData.Tags.Add("tag2", "value2");
            ElasticSanVolumeResource volume = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, volumeData)).Value;
            Assert.AreEqual(volume.Id.Name, volumeName);
            Assert.AreEqual(100, volume.Data.SizeGiB);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume.Data.CreationData.CreateSource);
            Assert.AreEqual("http://abc.com/", volume.Data.CreationData.SourceUri.ToString());
            Assert.GreaterOrEqual(volume.Data.Tags.Count, 2);
            Assert.AreEqual("value1", volume.Data.Tags["tag1"]);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            _collection = await GetVolumeCollection();

            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData volumeData = new ElasticSanVolumeData()
            {
                SizeGiB = 100,
            };
            volumeData.Tags.Add("tag1", "value1");
            ElasticSanVolumeResource volume1 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, volumeData)).Value;
            ElasticSanVolumeResource volume2 = (await _collection.GetAsync(volumeName)).Value;
            Assert.AreEqual(volume2.Id.Name, volume1.Id.Name);
            Assert.AreEqual(100, volume1.Data.SizeGiB);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume1.Data.CreationData.CreateSource);
            Assert.IsNull(volume1.Data.CreationData.SourceUri);
            Assert.AreEqual("value1", volume1.Data.Tags["tag1"]);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            _collection = await GetVolumeCollection();

            string volumeName1 = Recording.GenerateAssetName("testvolume-");
            string volumeName2 = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData volumeData = new ElasticSanVolumeData()
            {
                SizeGiB = 100
            };
            _ = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName1, volumeData)).Value;
            _ = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName2, volumeData)).Value;

            int count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            _collection = await GetVolumeCollection();

            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData volumeData = new ElasticSanVolumeData()
            {
                SizeGiB = 100
            };
            _ = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, volumeData)).Value;
            Assert.IsTrue(await _collection.ExistsAsync(volumeName));
            Assert.IsFalse(await _collection.ExistsAsync(volumeName + "111"));
        }
    }
}
