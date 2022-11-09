// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchApplicationCollectionTests : BatchManagementTestBase
    {
        public BatchApplicationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchApplicationCollection> GetApplicationCollectionAsync()
        {
            ResourceIdentifier storageAccountId = (await GetStorageAccountResource()).Id;
            var collection = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            return account.GetBatchApplications();
        }

        [TestCase]
        public async Task ApplicationCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetApplicationCollectionAsync();
            var name = Recording.GenerateAssetName("Application-");
            var name2 = Recording.GenerateAssetName("Application-");
            var name3 = Recording.GenerateAssetName("Application-");
            var input = ResourceDataHelper.GetBatchApplicationData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchApplicationResource application1 = lro.Value;
            Assert.AreEqual(name, application1.Data.Name);
            //2.Get
            BatchApplicationResource application2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertApplicationData(application1.Data, application2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
