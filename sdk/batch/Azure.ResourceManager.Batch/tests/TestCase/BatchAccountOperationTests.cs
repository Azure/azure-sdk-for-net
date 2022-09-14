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
    public class BatchAccountOperationTests : BatchManagementTestBase
    {
        public BatchAccountOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountResource> CreateAccountResourceAsync(string accountName)
        {
            ResourceIdentifier storageAccountId = (await GetStorageAccountResource()).Id;
            var collection = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AccountResourceApiTests()
        {
            //1.Get
            var accountName = Recording.GenerateAssetName("testaccount");
            var account1 = await CreateAccountResourceAsync(accountName);
            BatchAccountResource account2 = await account1.GetAsync();

            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
            //2.Delete
            await account1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
