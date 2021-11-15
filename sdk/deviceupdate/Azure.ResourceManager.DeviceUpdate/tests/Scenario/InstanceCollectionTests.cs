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
    public class InstanceCollectionTests : DeviceUpdateManagementTestBase
    {
        public InstanceCollectionTests(bool isAsync)
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
            Account account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            Instance instance = await CreateInstance(account, instanceName);
            Assert.AreEqual(instanceName, instance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetInstances().CreateOrUpdateAsync(null, instance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetInstances().CreateOrUpdateAsync(instanceName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            Account account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            _ = await CreateInstance(account, instanceName);
            int count = 0;
            await foreach (var tempAccount in account.GetInstances().GetAllAsync())
            {
                count++;
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
            Account account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            Instance instance = await CreateInstance(account, instanceName);
            Instance getInstance = await account.GetInstances().GetAsync(instanceName);
            ResourceDataHelper.AssertValidInstance(instance, getInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetInstances().GetAsync(null));
        }
    }
}
