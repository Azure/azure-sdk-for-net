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
            Assert.AreEqual(snapshot.Id.Name, snapshotName1);
            Assert.AreEqual(snapshot.Data.VolumeName, volume.Id.Name);
            Assert.AreEqual(snapshot.Data.SourceVolumeSizeGiB, volume.Data.SizeGiB);

            ElasticSanSnapshotResource snapshot2 = (await snapshotCollection.GetAsync(snapshotName1)).Value;
            Assert.AreEqual(snapshot.Id.Name, snapshot2.Id.Name);
            Assert.AreEqual(snapshot.Id.ResourceGroupName, snapshot2.Id.ResourceGroupName);
            Assert.AreEqual(snapshot.Data.Name, snapshot2.Data.Name);
            Assert.AreEqual(snapshot.Data.VolumeName, snapshot2.Data.VolumeName);
            Assert.AreEqual(snapshot.Data.CreationDataSourceId, snapshot2.Data.CreationDataSourceId);
            Assert.AreEqual(snapshot.Data.SourceVolumeSizeGiB, snapshot2.Data.SourceVolumeSizeGiB);

            int count = 0;
            await foreach (ElasticSanSnapshotResource _ in snapshotCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);

            Assert.IsTrue(await snapshotCollection.ExistsAsync(snapshotName1));
            Assert.IsFalse(await snapshotCollection.ExistsAsync(snapshotName1 + "abcd"));
        }
    }
}
