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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccountResource account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            DeviceUpdateInstanceResource instance = await CreateInstance(account, instanceName);
            Assert.AreEqual(instanceName, instance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(WaitUntil.Completed, null, instance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(WaitUntil.Completed, instanceName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccountResource account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            _ = await CreateInstance(account, instanceName);
            int count = 0;
            await foreach (var tempInstance in account.GetDeviceUpdateInstances().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccountResource account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            DeviceUpdateInstanceResource instance = await CreateInstance(account, instanceName);
            DeviceUpdateInstanceResource getInstance = await account.GetDeviceUpdateInstances().GetAsync(instanceName);
            ResourceDataHelper.AssertValidInstance(instance, getInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await account.GetDeviceUpdateInstances().GetAsync(null));
        }
    }
}
