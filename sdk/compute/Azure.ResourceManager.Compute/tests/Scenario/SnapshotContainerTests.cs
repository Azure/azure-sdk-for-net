// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class SnapshotContainerTests : ComputeTestBase
    {
        public SnapshotContainerTests(bool isAsync)
    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<SnapshotContainer> GetSnapshotContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetSnapshots();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetSnapshotContainerAsync();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var _resourceGroup = await CreateResourceGroupAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lroDisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lroDisk.Value;
            var diskID = _disk.Id;
            var createoption = new DiskCreateOption("copy");
            var input =  ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            var lro = await container.CreateOrUpdateAsync(ssName, input);
            Snapshot ss = lro.Value;
            Assert.AreEqual(ssName, ss.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetSnapshotContainerAsync();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var _resourceGroup = await CreateResourceGroupAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lrodisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lrodisk.Value;
            var diskID = _disk.Id;
            var createoption = new DiskCreateOption("copy");
            var input = ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            var lro = await container.CreateOrUpdateAsync(ssName, input);
            Snapshot ss1 = lro.Value;
            Snapshot ss2 = await container.GetAsync(ssName);
            ResourceDataHelper.AssertSnapshot(ss1.Data, ss2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetSnapshotContainerAsync();
            var ssName = Recording.GenerateAssetName("testSnapshot-");
            var _resourceGroup = await CreateResourceGroupAsync();
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
            Assert.IsTrue(await container.CheckIfExistsAsync(ssName));
            Assert.IsFalse(await container.CheckIfExistsAsync(ssName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetSnapshotContainerAsync();
            var _resourceGroup = await CreateResourceGroupAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lroDisk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            Disk _disk = lroDisk.Value;
            var diskID = _disk.Id;
            var createoption = new DiskCreateOption("copy");
            var input = ResourceDataHelper.GetBasicSnapshotData(DefaultLocation, createoption, diskID);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testSnapshot-"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testSnapshot-"), input);
            int count = 0;
            await foreach (var snapshot in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
