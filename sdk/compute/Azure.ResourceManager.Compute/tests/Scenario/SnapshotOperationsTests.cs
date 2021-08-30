// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class SnapshotOperationsTests : ComputeTestBase
    {
        public SnapshotOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var _resourceGroup = await CreateResourceGroupAsync();
            var container = _resourceGroup.GetSnapshots();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lroDisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lroDisk.Value;
            var diskID = _disk.Id;
            var createOption = new DiskCreateOption("copy");
            var input = ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            var lro = await container.CreateOrUpdateAsync(ssName, input);
            Snapshot ss = lro.Value;
            await ss.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var _resourceGroup = await CreateResourceGroupAsync();
            var container = _resourceGroup.GetSnapshots();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lroDisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lroDisk.Value;
            var diskID = _disk.Id;
            var createOption = new DiskCreateOption("copy");
            var input = ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            var lro = await container.CreateOrUpdateAsync(ssName, input);
            Snapshot ss1 = lro.Value;
            Snapshot ss2 = await ss1.GetAsync();

            ResourceDataHelper.AssertSnapshot(ss1.Data, ss2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var _resourceGroup = await CreateResourceGroupAsync();
            var container = _resourceGroup.GetSnapshots();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lroDisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lroDisk.Value;
            var diskID = _disk.Id;
            var createOption = new DiskCreateOption("copy");
            var input = ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            var lro = await container.CreateOrUpdateAsync(ssName, input);
            Snapshot ss = lro.Value;

            var newDiskSize = 20;
            var snapupdate = new SnapshotUpdate()
            {
                DiskSizeGB = newDiskSize
            };
            var lroUpdate = await ss.UpdateAsync(snapupdate);
            Snapshot updatedss = lroUpdate.Value;

            Assert.AreEqual(newDiskSize, updatedss.Data.DiskSizeGB);
        }
    }
}
