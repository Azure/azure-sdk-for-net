// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountCollectionTests : BatchManagementTestBase
    {
        public BatchAccountCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task AccountCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = ResourceGroup.GetBatchAccounts();
            var name = Recording.GenerateAssetName("account");
            var name2 = Recording.GenerateAssetName("account");
            var name3 = Recording.GenerateAssetName("account");
            var input = ResourceDataHelper.GetBatchAccountData(StorageAccountIdentifier);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountResource account1 = lro.Value;
            Assert.AreEqual(name, account1.Data.Name);
            //2.Get
            BatchAccountResource account2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
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
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
