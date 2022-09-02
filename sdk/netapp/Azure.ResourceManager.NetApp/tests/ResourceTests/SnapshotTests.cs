// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class SnapshotTests : NetAppTestBase
    {
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        internal SnapshotCollection _snapshotCollection;
        internal VolumeResource _volumeResource;
        public SnapshotTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, ServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetVolumes();

            if (DefaultVirtualNetwork == null)
            {
                DefaultVirtualNetwork = await CreateVirtualNetwork();
            }
            _volumeResource = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, subnetId: DefaultSubnetId);
            _snapshotCollection = _volumeResource.GetSnapshots();
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Data.Name.Split('/').Last());
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    VolumeCollection volumeCollection = pool.GetVolumes();
                    List<VolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (VolumeResource volume in volumeList)
                    {
                        SnapshotCollection snapCollection = volume.GetSnapshots();
                        List<SnapshotResource> snapsshotList = await snapCollection.GetAllAsync().ToEnumerableAsync();
                        foreach (SnapshotResource snapshot in snapsshotList)
                        {
                            await snapshot.DeleteAsync(WaitUntil.Completed);
                        }
                        if (Mode != RecordedTestMode.Playback)
                        {
                            await Task.Delay(10000);
                        }
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    if (Mode != RecordedTestMode.Playback)
                    {
                        await Task.Delay(30000);
                    }
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteSnapshot()
        {
            //create snapshot
            var snapshotName = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData = new(DefaultLocation);
            SnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //Validate
            SnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotCollection.GetAsync(snapshotName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotCollection.ExistsAsync(snapshotName));
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName + "1"));

            //Delete snapshot
            await snapshotResource2.DeleteAsync(WaitUntil.Completed);

            //Check deletion
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotCollection.GetAsync(snapshotName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task ListSnapshots()
        {
            //create snapshot
            var snapshotName = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData = new(DefaultLocation);
            SnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //Create another
            var snapshotName2 = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData2 = new(DefaultLocation);
            SnapshotResource snapshotResource2 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName2, snapshotData2)).Value;

            //validate if created successfully, get from collection
            SnapshotResource snapshotGetResource1 = await _snapshotCollection.GetAsync(snapshotName);
            SnapshotResource snapshotGetResource2 = await _snapshotCollection.GetAsync(snapshotName2);
            //get list
            List<SnapshotResource> snapshotList = await _snapshotCollection.GetAllAsync().ToEnumerableAsync();
            snapshotList.Should().HaveCount(2);
            SnapshotResource snapshotResource3 = null;
            SnapshotResource snapshotResource4 = null;
            foreach (SnapshotResource snapshot in snapshotList)
            {
                if (snapshot.Id.Name.Equals(snapshotName))
                    snapshotResource3 = snapshot;
                else if (snapshot.Id.Name.Equals(snapshotName2))
                    snapshotResource4 = snapshot;
            }
            snapshotResource3.Should().BeEquivalentTo(snapshotGetResource1);
            snapshotResource4.Should().BeEquivalentTo(snapshotGetResource2);

            //Check deletion
            await snapshotResource2.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName2));
            snapshotList = await _snapshotCollection.GetAllAsync().ToEnumerableAsync();
            snapshotList.Should().HaveCount(1);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumeFromSnapshot()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData = new(DefaultLocation);
            SnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            SnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //create new volume from snapshot, we do this by calling create volume with a snapshotId
            string newVolumeName = Recording.GenerateAssetName("volume-");
            VolumeResource newVolumeResource = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, snapshotId: snapshotResource2.Id);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }
            //Validate
            VolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name.Split('/').Last());
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotCollection.GetAsync(snapshotName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotCollection.ExistsAsync(snapshotName));
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task RevertVolumeToSnapshot()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData = new(DefaultLocation);
            SnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            SnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }
            //Revert the volume to the snapshot
            VolumeRevert body = new();
            body.SnapshotId = snapshotResource2.Id;
            ArmOperation revertOperation = (await _volumeResource.RevertAsync(WaitUntil.Completed, body));
            Assert.IsTrue(revertOperation.HasCompleted);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreFilesFromSnapshotFileDoesNotExist()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            SnapshotData snapshotData = new(DefaultLocation);
            SnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            SnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }
            //Revert the volume to the snapshot
            List<string> fileList = new() { "/dir1/file1" };
            SnapshotRestoreFiles body = new(fileList);
            body.DestinationPath = "/dataStore";
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await snapshotResource2.RestoreFilesAsync(WaitUntil.Completed, body); });
            Assert.AreEqual(200, exception.Status);
            Assert.AreEqual("Conflict", exception.ErrorCode);
        }
    }
}
