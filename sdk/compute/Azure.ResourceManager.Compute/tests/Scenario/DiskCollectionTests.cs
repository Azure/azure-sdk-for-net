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
    public class DiskCollectionTests : ComputeTestBase
    {
        public DiskCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiskCollection> GetDiskCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDisks();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(diskName, input);
            Disk disk = lro.Value;
            Assert.AreEqual(diskName, disk.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(diskName, input);
            Disk disk1 = lro.Value;
            Disk disk2 = await collection.GetAsync(diskName);
            ResourceDataHelper.AssertDisk(disk1.Data, disk2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(diskName, input);
            Disk disk = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(diskName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(diskName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDiskCollectionAsync();
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDisk-"), input);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDisk-"), input);
            int count = 0;
            await foreach (var disk in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName1 = Recording.GenerateAssetName("testDisk-");
            var diskName2 = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await collection.CreateOrUpdateAsync(diskName1, input);
            _ = await collection.CreateOrUpdateAsync(diskName2, input);

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
