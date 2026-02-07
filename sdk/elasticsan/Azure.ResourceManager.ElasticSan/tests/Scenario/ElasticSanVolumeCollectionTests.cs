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
        public async Task CreateUpdateGetExistsGet()
        {
            _collection = await GetVolumeCollection();

            string volumeName = Recording.GenerateAssetName("testvolume-");
            ElasticSanVolumeData volumeData = new ElasticSanVolumeData(100)
            {
                CreationData = new ElasticSanVolumeDataSourceInfo()
            };
            ElasticSanVolumeResource volume = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, volumeData)).Value;
            Assert.AreEqual(volume.Id.Name, volumeName);
            Assert.AreEqual(100, volume.Data.SizeGiB);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume.Data.CreationData.CreateSource);
            Assert.IsNull(volume.Data.CreationData.SourceId);

            ElasticSanVolumeResource volume2 = (await _collection.GetAsync(volumeName)).Value;
            Assert.AreEqual(volume2.Id.Name, volume.Id.Name);
            Assert.AreEqual(100, volume.Data.SizeGiB);
            Assert.AreEqual(ElasticSanVolumeCreateOption.None, volume.Data.CreationData.CreateSource);
            Assert.IsNull(volume.Data.CreationData.SourceId);

            string volumeName2 = Recording.GenerateAssetName("testvolume-");
            _ = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName2, volumeData)).Value;

            int count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);

            Assert.IsTrue(await _collection.ExistsAsync(volumeName));
            Assert.IsFalse(await _collection.ExistsAsync(volumeName + "111"));
        }
    }
}
