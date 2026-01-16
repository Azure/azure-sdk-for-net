// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ElasticSan.Models;
using Azure.ResourceManager.Models;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanSnapshotCollectionTests : ElasticSanTestBase
    {
        public ElasticSanSnapshotCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetExists()
        {
            string volumeGroupName = Recording.GenerateAssetName("testsnapshotvg-");
            string volumeName = Recording.GenerateAssetName("testsnapshotvol-");
            string snapshotName1 = Recording.GenerateAssetName("testsnapshot1-");
            string snapshotName2 = Recording.GenerateAssetName("testsnapshot2-");
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volumeGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            ElasticSanVolumeGroupResource volumeGroup = (await volumeGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeCollection volumeCollection = volumeGroup.GetElasticSanVolumes();
            ElasticSanVolumeResource volume = (await volumeCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, GetDefaultElasticSanVolumeData())).Value;
            ElasticSanSnapshotCollection snapshotCollection = volumeGroup.GetElasticSanSnapshots();

            ElasticSanSnapshotData data = new ElasticSanSnapshotData(new SnapshotCreationInfo(volume.Id));
            ElasticSanSnapshotResource snapshot = (await snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName1, data)).Value;
            _ = (await snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName2, data)).Value;
            Assert.That(snapshotName1, Is.EqualTo(snapshot.Id.Name));
            Assert.That(volume.Id.Name, Is.EqualTo(snapshot.Data.VolumeName));
            Assert.That(volume.Data.SizeGiB, Is.EqualTo(snapshot.Data.SourceVolumeSizeGiB));

            ElasticSanSnapshotResource snapshot2 = (await snapshotCollection.GetAsync(snapshotName1)).Value;
            Assert.That(snapshot2.Id.Name, Is.EqualTo(snapshot.Id.Name));
            Assert.That(snapshot2.Id.ResourceGroupName, Is.EqualTo(snapshot.Id.ResourceGroupName));
            Assert.That(snapshot2.Data.Name, Is.EqualTo(snapshot.Data.Name));
            Assert.That(snapshot2.Data.VolumeName, Is.EqualTo(snapshot.Data.VolumeName));
            Assert.That(snapshot2.Data.CreationDataSourceId, Is.EqualTo(snapshot.Data.CreationDataSourceId));
            Assert.That(snapshot2.Data.SourceVolumeSizeGiB, Is.EqualTo(snapshot.Data.SourceVolumeSizeGiB));

            int count = 0;
            await foreach (ElasticSanSnapshotResource _ in snapshotCollection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(2));

            Assert.That((bool)await snapshotCollection.ExistsAsync(snapshotName1), Is.True);
            Assert.That((bool)await snapshotCollection.ExistsAsync(snapshotName1 + "abcd"), Is.False);
        }
    }
}
