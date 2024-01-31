// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class RunbookTests : AutomationManagementTestBase
    {
        public RunbookTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationRunbookCollection> GetRunbookCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetAutomationRunbooks();
        }

        [TestCase]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/36058")]
        public async Task RunbookApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetRunbookCollectionAsync();
            var name = Recording.GenerateAssetName("runbook");
            var name2 = Recording.GenerateAssetName("runbook");
            var name3 = Recording.GenerateAssetName("runbook");
            var input = ResourceDataHelpers.GetRunbookData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationRunbookResource runbook = lro.Value;
            Assert.AreEqual(name, runbook.Data.Name);
            //2.Get
            AutomationRunbookResource runbook2 = await runbook.GetAsync();
            ResourceDataHelpers.AssertRunbook(runbook.Data, runbook2.Data);
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
            AutomationRunbookResource runbook3 = await runbook.GetAsync();
            ResourceDataHelpers.AssertRunbook(runbook.Data, runbook3.Data);
            //6.Delete
            await runbook.DeleteAsync(WaitUntil.Completed);
        }
    }
}
