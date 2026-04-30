// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class StorageCacheCollectionTest : StorageCacheManagementTestBase
    {
        public StorageCacheCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testsc");
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache(name, verifyResult: true);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Get()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();
            StorageCacheResource result = await this.DefaultResourceGroup.GetStorageCaches().GetAsync(cacheName: scr.Id.Name);

            this.VerifyStorageCache(result, scr.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testsc");
            await AzureResourceTestHelper.TestExists<StorageCacheResource>(
                async () => await this.CreateOrUpdateStorageCache(name),
                async () => await this.DefaultResourceGroup.GetStorageCaches().ExistsAsync(name));
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetAll()
        {
            await AzureResourceTestHelper.TestGetAll<StorageCacheResource>(
                count: 2,
                async (i) => await this.CreateOrUpdateStorageCache(),
                () => this.DefaultResourceGroup.GetStorageCaches().GetAllAsync());
        }
    }
}
