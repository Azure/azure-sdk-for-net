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
            Assert.Multiple(() =>
            {
                Assert.That(volumeName, Is.EqualTo(volume.Id.Name));
                Assert.That(volume.Data.SizeGiB, Is.EqualTo(100));
                Assert.That(volume.Data.CreationData.CreateSource, Is.EqualTo(ElasticSanVolumeCreateOption.None));
                Assert.That(volume.Data.CreationData.SourceId, Is.Null);
            });

            ElasticSanVolumeResource volume2 = (await _collection.GetAsync(volumeName)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(volume.Id.Name, Is.EqualTo(volume2.Id.Name));
                Assert.That(volume.Data.SizeGiB, Is.EqualTo(100));
                Assert.That(volume.Data.CreationData.CreateSource, Is.EqualTo(ElasticSanVolumeCreateOption.None));
                Assert.That(volume.Data.CreationData.SourceId, Is.Null);
            });

            string volumeName2 = Recording.GenerateAssetName("testvolume-");
            _ = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName2, volumeData)).Value;

            int count = 0;
            await foreach (ElasticSanVolumeResource _ in _collection.GetAllAsync())
            {
                count++;
            }

            Assert.Multiple(async () =>
            {
                Assert.That(count, Is.GreaterThanOrEqualTo(2));

                Assert.That((bool)await _collection.ExistsAsync(volumeName), Is.True);
                Assert.That((bool)await _collection.ExistsAsync(volumeName + "111"), Is.False);
            });
        }
    }
}
