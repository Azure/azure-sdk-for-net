// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DiskContainerTests : ComputeTestBase
    {
        public DiskContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiskContainer> GetDiskContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDisks();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetDiskContainerAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            Disk disk = await container.CreateOrUpdateAsync(diskName, input);
            Assert.AreEqual(diskName, disk.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetDiskContainerAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var diskOp = await container.StartCreateOrUpdateAsync(diskName, input);
            Disk disk = await diskOp.WaitForCompletionAsync();
            Assert.AreEqual(diskName, disk.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetDiskContainerAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            Disk disk1 = await container.CreateOrUpdateAsync(diskName, input);
            Disk disk2 = await container.GetAsync(diskName);
            ResourceDataHelper.AssertDisk(disk1.Data, disk2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetDiskContainerAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            Disk disk = await container.CreateOrUpdateAsync(diskName, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(diskName));
            Assert.IsFalse(await container.CheckIfExistsAsync(diskName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetDiskContainerAsync();
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDisk-"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDisk-"), input);
            int count = 0;
            await foreach (var disk in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var container = await GetDiskContainerAsync();
            var diskName1 = Recording.GenerateAssetName("testDisk-");
            var diskName2 = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await container.CreateOrUpdateAsync(diskName1, input);
            _ = await container.CreateOrUpdateAsync(diskName2, input);

            Disk disk1 = null, disk2 = null;
            await foreach (var disk in DefaultSubscription.GetDisksAsync())
            {
                if (disk.Data.Name == diskName1)
                    disk1 = disk;
                if (disk.Data.Name == diskName2)
                    disk2 = disk;
            }

            Assert.NotNull(disk1);
            Assert.NotNull(disk2);
        }
    }
}
