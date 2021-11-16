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
    public class AccountOperationsTests : DeviceUpdateManagementTestBase
    {
        public AccountOperationsTests(bool isAsync)
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
            await account.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await account.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("ResourcePatchValidateFailed, Need more investigation")]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            Account account = await CreateAccount(rg, accountName);
            AccountUpdate updateParameters = new AccountUpdate();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await account.UpdateAsync(updateParameters);
            Account updatedAccount = lro.Value;
            ResourceDataHelper.AssertAccountUpdate(updatedAccount, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("405")]
        public async Task Head()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string accountName = Recording.GenerateAssetName("Account-");
            Account account = await CreateAccount(rg, accountName);
            Assert.IsTrue(await account.HeadAsync());
        }
    }
}
