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
    public class DiskOperationsTests : ComputeTestBase
    {
        public DiskOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<Disk> CreateDiskAsync(string diskName)
        {
            var collection = (await CreateResourceGroupAsync()).GetDisks();
            var input = ResourceDataHelper.GetEmptyDiskData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            var lro = await collection.CreateOrUpdateAsync(diskName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk = await CreateDiskAsync(diskName);
            await disk.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk1 = await CreateDiskAsync(diskName);
            Disk disk2 = await disk1.GetAsync();

            ResourceDataHelper.AssertDisk(disk1.Data, disk2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var diskName = Recording.GenerateAssetName("testDisk-");
            var disk = await CreateDiskAsync(diskName);

            var newDiskSize = 20;
            var update = new DiskUpdate()
            {
                DiskSizeGB = newDiskSize
            };
            var lro = await disk.UpdateAsync(update);
            Disk updatedDisk = lro.Value;

            Assert.AreEqual(newDiskSize, updatedDisk.Data.DiskSizeGB);
        }
    }
}
