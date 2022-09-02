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
    public class BatchAccountCollectionTests : BatchManagementTestBase
    {
        public BatchAccountCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountCollection> GetAccountCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetBatchAccounts();
        }

        [TestCase]
        public async Task AccountCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetAccountCollectionAsync();
            var name = Recording.GenerateAssetName("account");
            var input = ResourceDataHelper.GetBatchAccountData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountResource account1 = lro.Value;
            Assert.AreEqual(name, account1.Data.Name);
            //2.Get
            BatchAccountResource account2 = await container.GetAsync(name);
            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
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
