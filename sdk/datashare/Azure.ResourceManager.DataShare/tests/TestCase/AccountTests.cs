// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DataShare.Models;
using Azure.ResourceManager.DataShare.Tests.Helper;
using NUnit.Framework;

namespace Azure.ResourceManager.DataShare.Tests.TestCase
{
    public class AccountTests : DataShareManagementTestBase
    {
        public AccountTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataShareAccountCollection> GetAccountCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            return collection;
        }

        private async Task<DataShareAccountResource> GetAccountResourceAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            return lroa.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task ShareAccountCollectionTests()
        {
            //1.CreateorUpdate
            var collection = await GetAccountCollectionAsync();
            var name = Recording.GenerateAssetName("TestAccount-");
            var name2 = Recording.GenerateAssetName("TestAccount-");
            var name3 = Recording.GenerateAssetName("TestAccount-");
            var input = ResourceDataHelpers.GetAccount();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataShareAccountResource account1 = lro.Value;
            Assert.AreEqual(name, account1.Data.Name);
            //2.Get
            DataShareAccountResource account2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertAccount(account1.Data, account2.Data);
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
            //ResourceTests
            //5.Get
            DataShareAccountResource account3 = await account1.GetAsync();
            ResourceDataHelpers.AssertAccount(account1.Data, account2.Data);
            //6.Delete
            await account1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
