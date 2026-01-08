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
    public class ElasticSanSnapshotResourceTests : ElasticSanTestBase
    {
        public ElasticSanSnapshotResourceTests(bool isAsync)
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
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection volumeGroupCollection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();
            ElasticSanVolumeGroupResource volumeGroup = (await volumeGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeCollection volumeCollection = volumeGroup.GetElasticSanVolumes();
            ElasticSanVolumeResource volume = (await volumeCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, GetDefaultElasticSanVolumeData())).Value;
            ElasticSanSnapshotCollection snapshotCollection = volumeGroup.GetElasticSanSnapshots();

            ElasticSanSnapshotData data = new ElasticSanSnapshotData(new SnapshotCreationInfo(volume.Id));
            ElasticSanSnapshotResource snapshot = (await snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName1, data)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(snapshotName1, Is.EqualTo(snapshot.Id.Name));
                Assert.That(volumeName, Is.EqualTo(snapshot.Data.VolumeName));
            });
            Assert.That(snapshotName1, Is.EqualTo(snapshot.Data.Name));

            ElasticSanSnapshotResource snapshot2 = (await snapshot.GetAsync()).Value;
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.Id.Name, Is.EqualTo(snapshot2.Id.Name));
                Assert.That(snapshot.Data.VolumeName, Is.EqualTo(snapshot2.Data.VolumeName));
                Assert.That(snapshot.Data.CreationDataSourceId, Is.EqualTo(snapshot2.Data.CreationDataSourceId));
            });

            await snapshot.DeleteAsync(WaitUntil.Completed);
        }
    }
}
