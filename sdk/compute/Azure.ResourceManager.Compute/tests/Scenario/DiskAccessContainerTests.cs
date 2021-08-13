// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DiskAccessContainerTests : ComputeTestBase
    {
        public DiskAccessContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiskAccessContainer> GetDiskAccessContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDiskAccesses();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetDiskAccessContainerAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            DiskAccess access = await container.CreateOrUpdateAsync(name, input);
            Assert.AreEqual(name, access.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetDiskAccessContainerAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var op = await container.StartCreateOrUpdateAsync(name, input);
            DiskAccess access = await op.WaitForCompletionAsync();
            Assert.AreEqual(name, access.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetDiskAccessContainerAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            DiskAccess access1 = await container.CreateOrUpdateAsync(name, input);
            DiskAccess access2 = await container.GetAsync(name);
            ResourceDataHelper.AssertDiskAccess(access1.Data, access2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetDiskAccessContainerAsync();
            var name = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            DiskAccess access = await container.CreateOrUpdateAsync(name, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(name));
            Assert.IsFalse(await container.CheckIfExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetDiskAccessContainerAsync();
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDA"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDA"), input);
            int count = 0;
            await foreach (var access in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var container = await GetDiskAccessContainerAsync();
            var name1 = Recording.GenerateAssetName("testDA");
            var name2 = Recording.GenerateAssetName("testDA");
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(name1, input);
            _ = await container.CreateOrUpdateAsync(name2, input);

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
