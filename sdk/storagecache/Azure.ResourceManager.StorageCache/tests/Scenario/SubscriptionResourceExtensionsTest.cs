// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class SubscriptionResourceExtensionsTest : StorageCacheManagementTestBase
    {
        public SubscriptionResourceExtensionsTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetStorageCacheSkus()
        {
            AsyncPageable<StorageCacheSku> pagedList = this.DefaultSubscription.GetStorageCacheSkusAsync();

            int count = 0;
            await foreach (var item in pagedList)
            {
                count++;
            }
            Assert.IsTrue(count > 0);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetStorageCacheUsages()
        {
            AsyncPageable<StorageCacheUsage> pagedList = this.DefaultSubscription.GetStorageCacheUsagesAsync(this.DefaultLocation);

            int count = 0;
            await foreach (var item in pagedList)
            {
                count++;
            }
            Assert.IsTrue(count > 0);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetUsageModels()
        {
            AsyncPageable<StorageCacheUsageModel> pagedList = this.DefaultSubscription.GetUsageModelsAsync();

            int count = 0;
            await foreach (var item in pagedList)
            {
                count++;
            }
            Assert.IsTrue(count > 0);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetStorageCaches()
        {
            var scr = await this.CreateOrUpdateStorageCache();

            AsyncPageable<StorageCacheResource> pagedList = this.DefaultSubscription.GetStorageCachesAsync();

            int count = 0;
            bool found = false;
            await foreach (var item in pagedList)
            {
                if (item.Id == scr.Id)
                    found = true;
                count++;
            }
            Assert.IsTrue(count > 0);
            Assert.IsTrue(found);
        }
    }
}
