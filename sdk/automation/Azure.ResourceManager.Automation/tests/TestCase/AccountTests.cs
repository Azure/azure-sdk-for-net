// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class AccountTests : AutomationManagementTestBase
    {
        public AccountTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationAccountCollection> GetAccountCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAutomationAccounts();
        }

        [TestCase]
        public async Task AccountApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetAccountCollection();
            var name = Recording.GenerateAssetName("account");
            var name2 = Recording.GenerateAssetName("account");
            var name3 = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationAccountResource account = lro.Value;
            Assert.AreEqual(name, account.Data.Name);
            //2.Get
            AutomationAccountResource account2 = await account.GetAsync();
            ResourceDataHelpers.AssertAccount(account.Data, account2.Data);
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
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            AutomationAccountResource account3 = await account.GetAsync();
            ResourceDataHelpers.AssertAccount(account.Data, account3.Data);
            //6.Delete
            await account.DeleteAsync(WaitUntil.Completed);
        }
    }
}
