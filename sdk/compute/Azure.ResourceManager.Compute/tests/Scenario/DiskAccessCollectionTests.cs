// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DiskAccessCollectionTests : ComputeTestBase
    {
        public DiskAccessCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiskAccessCollection> GetDiskAccessCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDiskAccesses();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetDiskAccessCollectionAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            DiskAccess access = lro.Value;
            Assert.AreEqual(name, access.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDiskAccessCollectionAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            DiskAccess access1 = lro.Value;
            DiskAccess access2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertDiskAccess(access1.Data, access2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var collection = await GetDiskAccessCollectionAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            DiskAccess access = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(name));
            Assert.IsFalse(await collection.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDiskAccessCollectionAsync();
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDA"), input);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDA"), input);
            int count = 0;
            await foreach (var access in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetDiskAccessCollectionAsync();
            var name1 = Recording.GenerateAssetName("testDA");
            var name2 = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            _ = await collection.CreateOrUpdateAsync(name1, input);
            _ = await collection.CreateOrUpdateAsync(name2, input);

            DiskAccess access1 = null, access2 = null;
            await foreach (var access in DefaultSubscription.GetDiskAccessesAsync())
            {
                if (access.Data.Name == name1)
                    access1 = access;
                if (access.Data.Name == name2)
                    access2 = access;
            }

            Assert.NotNull(access1);
            Assert.NotNull(access2);
        }
    }
}
