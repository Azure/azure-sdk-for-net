// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.StorageCache.Models;
using Azure.ResourceManager.StorageCache.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.TestCase
{
    public class StorageTargetTests: StorageCacheManagementTestBase
    {
        public StorageTargetTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        #region storage account
        public async Task<string> GetStorageAccountId()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var storageCeollection = resourceGroup.GetStorageAccounts();
            string accountName = Recording.GenerateAssetName("metrictests");
            var storageContent = ResourceDataHelpers.GetContent();
            //var storageAccount = await storageCeollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, storageContent);
            string storageAccountId;
            if (Mode == RecordedTestMode.Playback)
            {
                storageAccountId = StorageAccountResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, accountName).ToString();
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var storageAccount = await storageCeollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, storageContent);
                    storageAccountId = storageAccount.Value.Data.Id;
                }
            }
            return storageAccountId;
        }

        #endregion
        private async Task<StorageTargetCollection> GetStorageCacheCollectionAsync()
        {
            var resourcegroup = await CreateResourceGroupAsync();
            var cacheCollection = resourcegroup.GetStorageCaches();
            var cacheName = Recording.GenerateAssetName("storagecachetest-");
            var input = ResourceDataHelpers.GetStorageCacheData(new ResourceIdentifier("remenber"));
            var lro = await cacheCollection.CreateOrUpdateAsync(WaitUntil.Completed, cacheName, input);
            StorageCacheResource cache = lro.Value;
            return cache.GetStorageTargets();
        }

        [TestCase]
        public async Task StorageTargetApiTests()
        {
            //Collection
            //1.CreateOrUpdate
            var collection = await GetStorageCacheCollectionAsync();
            var name = Recording.GenerateAssetName("storagetargerttest-");
            var name2 = Recording.GenerateAssetName("storagetargettest-");
            var name3 = Recording.GenerateAssetName("storagetargettest-");
            var input = ResourceDataHelpers.GetStorageTargetData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            StorageTargetResource target1 = lro.Value;
            Assert.AreEqual(name, target1.Data.Name);
            //2.Get
            StorageTargetResource target2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertStorageTargetData(target1.Data, target2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            StorageTargetResource target3 = await target1.GetAsync();

            ResourceDataHelpers.AssertStorageTargetData(target1.Data, target3.Data);
            //6.Delete
            await target1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
