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
    public class BatchAccountPoolOperationTests : BatchManagementTestBase
    {
        public BatchAccountPoolOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountPoolResource> CreateAccountResourceAsync(string accountName)
        {
            ResourceIdentifier storageAccountId = (await GetStorageAccountResource()).Id;
            var collection = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            var poolContainer = account.GetBatchAccountPools();
            var poolInput = ResourceDataHelper.GetBatchAccountPoolData();
            var lroc = await poolContainer.CreateOrUpdateAsync(WaitUntil.Completed, accountName, poolInput);
            return lroc.Value;
        }

        [TestCase]
        public async Task PoolResourceApiTests()
        {
            //1.Get
            var poolName = Recording.GenerateAssetName("testPool-");
            var pool1 = await CreateAccountResourceAsync(poolName);
            BatchAccountPoolResource pool2 = await pool1.GetAsync();

            ResourceDataHelper.AssertPoolData(pool1.Data, pool2.Data);
            //2.Delete
            await pool1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
