// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.DeviceUpdate.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceUpdate.Tests
{
    public class AccountCollectionTests : DeviceUpdateManagementTestBase
    {
        public AccountCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccount account = await CreateAccount(rg, accountName);
            Assert.AreEqual(accountName, account.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetDeviceUpdateAccounts().CreateOrUpdateAsync(null, account.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetDeviceUpdateAccounts().CreateOrUpdateAsync(accountName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            _ = await CreateAccount(rg, accountName);
            int count = 0;
            await foreach (var tempAccount in rg.GetDeviceUpdateAccounts().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccount account = await CreateAccount(rg, accountName);
            int count = 0;
            await foreach (var tempAccount in subscription.GetDeviceUpdateAccountsAsync())
            {
                if (tempAccount.Data.Id == account.Data.Id)
                {
                    count++;
                }
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccount account = await CreateAccount(rg, accountName);
            DeviceUpdateAccount getAccount = await rg.GetDeviceUpdateAccounts().GetAsync(accountName);
            ResourceDataHelper.AssertValidAccount(account, getAccount);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetDeviceUpdateAccounts().GetAsync(null));
        }
    }
}
