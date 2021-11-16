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
            Account account = await CreateAccount(rg, accountName);
            string instanceName = Recording.GenerateAssetName("Instance-");
            Instance instance = await CreateInstance(account, instanceName);
            await instance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await instance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("DeviceUpdateResourceGroup");
            Account account = await rg.GetAccounts().GetAsync("AzureDeviceUpdateAccount");
            Instance instance = await account.GetInstances().GetAsync("Instance");
            TagUpdate updateParameters = new TagUpdate();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await instance.UpdateAsync(updateParameters);
            Instance updatedInstance = lro.Value;
            ResourceDataHelper.AssertInstanceUpdate(updatedInstance, updateParameters);
            updateParameters.Tags.Clear();
            lro = await instance.UpdateAsync(updateParameters);
            updatedInstance = lro.Value;
            ResourceDataHelper.AssertInstanceUpdate(updatedInstance, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("405")]
        public async Task Head()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("DeviceUpdateResourceGroup");
            Account account = await rg.GetAccounts().GetAsync("AzureDeviceUpdateAccount");
            Instance instance = await account.GetInstances().GetAsync("Instance");
            Assert.IsTrue(await instance.HeadAsync());
        }
    }
}
