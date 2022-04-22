// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.DeviceUpdate.Models;
using Azure.ResourceManager.DeviceUpdate.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceUpdate.Tests
{
    public class InstanceOperationsTests : DeviceUpdateManagementTestBase
    {
        public InstanceOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            DeviceUpdateAccount account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            DeviceUpdateInstance instance = await CreateInstance(account, instanceName);
            await instance.DeleteAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await instance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("DeviceUpdateResourceGroup");
            DeviceUpdateAccount account = await rg.GetDeviceUpdateAccounts().GetAsync("AzureDeviceUpdateAccount");
            DeviceUpdateInstance instance = await account.GetDeviceUpdateInstances().GetAsync("Instance");
            TagUpdateOptions updateOptions = new TagUpdateOptions();
            updateOptions.Tags.Add("newTag", "newValue");
            DeviceUpdateInstance updatedInstance = await instance.UpdateAsync(updateOptions);
            ResourceDataHelper.AssertInstanceUpdate(updatedInstance, updateOptions);
            updateOptions.Tags.Clear();
            updatedInstance = await instance.UpdateAsync(updateOptions);
            ResourceDataHelper.AssertInstanceUpdate(updatedInstance, updateOptions);
        }
    }
}
