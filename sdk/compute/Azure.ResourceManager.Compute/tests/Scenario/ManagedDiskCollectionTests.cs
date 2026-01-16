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
    [ClientTestFixture(true, "2025-01-02", "2024-03-02", "2022-07-02", "2021-04-01", "2019-07-01")]
    public class ManagedDiskCollectionTests : ComputeTestBase
    {
        public ManagedDiskCollectionTests(bool isAsync, string apiVersion)
            : base(isAsync, ManagedDiskResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        private async Task<ManagedDiskCollection> GetDiskCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetManagedDisks();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName, input);
            var disk = lro.Value;
            Assert.That(disk.Data.Name, Is.EqualTo(diskName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName, input);
            ManagedDiskResource disk1 = lro.Value;
            ManagedDiskResource disk2 = await collection.GetAsync(diskName);
            ResourceDataHelper.AssertDisk(disk1.Data, disk2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName, input);
            ManagedDiskResource disk = lro.Value;
            Assert.That((bool)await collection.ExistsAsync(diskName), Is.True);
            Assert.That((bool)await collection.ExistsAsync(diskName + "1"), Is.False);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDiskCollectionAsync();
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDisk-"), input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDisk-"), input);
            int count = 0;
            await foreach (var disk in collection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(2));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetDiskCollectionAsync();
            var diskName1 = Recording.GenerateAssetName("testDisk-");
            var diskName2 = Recording.GenerateAssetName("testDisk-");
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName1, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName2, input);

            ManagedDiskResource disk1 = null, disk2 = null;
            await foreach (var disk in DefaultSubscription.GetManagedDisksAsync())
            {
                if (disk.Data.Name == diskName1)
                    disk1 = disk;
                if (disk.Data.Name == diskName2)
                    disk2 = disk;
            }

            Assert.That(disk1, Is.Not.Null);
            Assert.That(disk2, Is.Not.Null);
        }
    }
}
