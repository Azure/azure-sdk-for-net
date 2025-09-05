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
        private static NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        private readonly string _pool1Name = "pool1";
        internal NetAppVolumeSnapshotCollection _snapshotCollection;
        internal NetAppVolumeResource _volumeResource;
        public SnapshotTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();

            await CreateVirtualNetwork();
            _volumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, subnetId: DefaultSubnetId, volumeName: volumeName);
            _snapshotCollection = _volumeResource.GetNetAppVolumeSnapshots();
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                _ = await _capacityPoolCollection.ExistsAsync(_capacityPool.Id.Name);
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    NetAppVolumeCollection volumeCollection = pool.GetNetAppVolumes();
                    List<NetAppVolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (NetAppVolumeResource volume in volumeList)
                    {
                        NetAppVolumeSnapshotCollection snapCollection = volume.GetNetAppVolumeSnapshots();
                        List<NetAppVolumeSnapshotResource> snapsshotList = await snapCollection.GetAllAsync().ToEnumerableAsync();
                        foreach (NetAppVolumeSnapshotResource snapshot in snapsshotList)
                        {
                            await snapshot.DeleteAsync(WaitUntil.Completed);
                        }
                        await LiveDelay(10000);
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    await LiveDelay(30000);
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(40000);
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                //await LiveDelay(40000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [RecordedTest]
        public async Task CreateDeleteSnapshot()
        {
            //create snapshot
            var snapshotName = Recording.GenerateAssetName("snapshot-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //Validate
            NetAppVolumeSnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
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
            await LiveDelay(10000);
        }

        [RecordedTest]
        public async Task ListSnapshots()
        {
            //create snapshot
            var snapshotName = Recording.GenerateAssetName("snapshot-");
            var snapshotName2 = Recording.GenerateAssetName("snapshot-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //Create another
            NetAppVolumeSnapshotData snapshotData2 = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource2 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName2, snapshotData2)).Value;

            //validate if created successfully, get from collection
            NetAppVolumeSnapshotResource snapshotGetResource1 = await _snapshotCollection.GetAsync(snapshotName);
            NetAppVolumeSnapshotResource snapshotGetResource2 = await _snapshotCollection.GetAsync(snapshotName2);
            //get list
            List<NetAppVolumeSnapshotResource> snapshotList = await _snapshotCollection.GetAllAsync().ToEnumerableAsync();
            snapshotList.Should().HaveCount(2);
            NetAppVolumeSnapshotResource snapshotResource3 = null;
            NetAppVolumeSnapshotResource snapshotResource4 = null;
            foreach (NetAppVolumeSnapshotResource snapshot in snapshotList)
            {
                if (snapshot.Id.Name.Equals(snapshotName))
                    snapshotResource3 = snapshot;
                else if (snapshot.Id.Name.Equals(snapshotName2))
                    snapshotResource4 = snapshot;
            }
            snapshotResource3.Should().BeEquivalentTo(snapshotGetResource1);
            snapshotResource4.Should().BeEquivalentTo(snapshotGetResource2);
            await LiveDelay(20000);
            //Check deletion
            await snapshotResource2.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(20000);
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName2));
            snapshotList = await _snapshotCollection.GetAllAsync().ToEnumerableAsync();
            snapshotList.Should().HaveCount(1);
            await LiveDelay(20000);
        }

        [RecordedTest]
        public async Task CreateVolumeFromSnapshot()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            string newVolumeName = Recording.GenerateAssetName("volume-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            NetAppVolumeSnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //create new volume from snapshot, we do this by calling create volume with a snapshotId
            NetAppVolumeResource newVolumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, snapshotId: snapshotResource2.Id);
            await LiveDelay(20000);
            //Validate
            NetAppVolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name.Split('/').Last());
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotCollection.GetAsync(snapshotName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotCollection.ExistsAsync(snapshotName));
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName + "1"));
            await LiveDelay(10000);
        }

        [RecordedTest]
        public async Task CreateShortTermCloneVolumeFromSnapshot()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            string newVolumeName = Recording.GenerateAssetName("volume-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            NetAppVolumeSnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            //create new clone volume from snapshot, we do this by calling create volume with a snapshotId
            NetAppVolumeResource newVolumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: newVolumeName, snapshotId: snapshotResource2.Id, volumeType: "ShortTermClone", growPool: AcceptGrowCapacityPoolForShortTermCloneSplit.Accepted.ToString());
            await LiveDelay(8000);
            //Validate
            NetAppVolumeResource newVolumeResource2 = await _volumeCollection.GetAsync(newVolumeName);
            Assert.IsNotNull(newVolumeResource2);
            Assert.AreEqual(newVolumeName, newVolumeResource2.Id.Name.Split('/').Last());
            //check if exists
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _snapshotCollection.GetAsync(snapshotName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _snapshotCollection.ExistsAsync(snapshotName));
            Assert.IsFalse(await _snapshotCollection.ExistsAsync(snapshotName + "1"));

            // invoke the SplitCloneFromParentAsync operation
            await newVolumeResource2.SplitCloneFromParentAsync(WaitUntil.Completed);
            await LiveDelay(60000);
        }

        [RecordedTest]
        public async Task RevertVolumeToSnapshot()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            NetAppVolumeSnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            await LiveDelay(20000);
            //Revert the volume to the snapshot
            NetAppVolumeRevertContent body = new()
            {
                SnapshotId = snapshotResource2.Id
            };
            ArmOperation revertOperation = (await _volumeResource.RevertAsync(WaitUntil.Completed, body));
            Assert.IsTrue(revertOperation.HasCompleted);
            await LiveDelay(40000);
        }

        [RecordedTest]
        [Ignore("The specified filePath /dir1/file1 does not exist in the snapshot")]
        public async Task RestoreFilesFromSnapshotFileDoesNotExist()
        {
            //create snapshot
            string snapshotName = Recording.GenerateAssetName("snapshot-");
            await SetUp();
            NetAppVolumeSnapshotData snapshotData = new(DefaultLocation);
            NetAppVolumeSnapshotResource snapshotResource1 = (await _snapshotCollection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            // get and check the snapshot
            NetAppVolumeSnapshotResource snapshotResource2 = await _snapshotCollection.GetAsync(snapshotName);
            Assert.IsNotNull(snapshotResource1);
            Assert.AreEqual(snapshotName, snapshotResource1.Id.Name);

            await LiveDelay(20000);
            //Revert the volume to the snapshot
            List<string> fileList = new() { "/dir1/file1" };
            NetAppVolumeSnapshotRestoreFilesContent body = new(fileList)
            {
                DestinationPath = "/dataStore"
            };
            //RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await snapshotResource2.RestoreFilesAsync(WaitUntil.Completed, body); });
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(async () => { await snapshotResource2.RestoreFilesAsync(WaitUntil.Completed, body); });
            //StringAssert.Contains("SingleFileSnapshotRestoreInvalidStatusForOperation", exception.Message);
        }
    }
}
