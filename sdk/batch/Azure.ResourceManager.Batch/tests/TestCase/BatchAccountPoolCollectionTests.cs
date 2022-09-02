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
    public class BatchAccountPoolCollectionTests : BatchManagementTestBase
    {
        public BatchAccountPoolCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountPoolCollection> GetPoolCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            return account.GetBatchAccountPools();
        }

        [TestCase]
        public async Task PoolCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetPoolCollectionAsync();
            var name = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountPoolResource pool1 = lro.Value;
            Assert.AreEqual(name, pool1.Data.Name);
            //2.Get
            BatchAccountPoolResource pool2 = await container.GetAsync(name);
            ResourceDataHelper.AssertPoolData(pool1.Data, pool2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var account in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
