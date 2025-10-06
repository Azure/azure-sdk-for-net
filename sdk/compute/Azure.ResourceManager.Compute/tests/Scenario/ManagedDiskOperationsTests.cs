// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2025-01-02", "2024-03-02", "2022-07-02", "2021-04-01", "2019-07-01")]
    public class ManagedDiskOperationsTests : ComputeTestBase
    {
        public ManagedDiskOperationsTests(bool isAsync, string apiVersion)
            : base(isAsync, ManagedDiskResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        private async Task<ManagedDiskResource> CreateDiskAsync(string diskName)
        {
            var collection = (await CreateResourceGroupAsync()).GetManagedDisks();
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk = await CreateDiskAsync(diskName);
            await disk.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk1 = await CreateDiskAsync(diskName);
            ManagedDiskResource disk2 = await disk1.GetAsync();

            ResourceDataHelper.AssertDisk(disk1.Data, disk2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk = await CreateDiskAsync(diskName);
            var newDiskSize = 20;
            var update = new ManagedDiskPatch()
            {
                DiskSizeGB = newDiskSize
            };
            var lro = await disk.UpdateAsync(WaitUntil.Completed, update);
            ManagedDiskResource updatedDisk = lro.Value;

            Assert.AreEqual(newDiskSize, updatedDisk.Data.DiskSizeGB);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testDisk-");
            var disk = await CreateDiskAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            ManagedDiskResource updated = await disk.SetTagsAsync(tags);

            Assert.AreEqual(tags, updated.Data.Tags);
        }
    }
}
