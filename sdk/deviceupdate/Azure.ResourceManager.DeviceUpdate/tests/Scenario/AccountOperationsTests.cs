// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
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
        [Ignore("Need to solve some bugs")]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("DeviceUpdateResourceGroup");
            Account account = await rg.GetAccounts().GetAsync("AzureDeviceUpdateAccount");
            AccountUpdate updateParameters = new AccountUpdate()
            {
                Location = Location.WestUS2,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None)
            };
            var lro = await account.UpdateAsync(updateParameters);
            Account updatedAccount = lro.Value;
            ResourceDataHelper.AssertAccountUpdate(updatedAccount, updateParameters);
            updateParameters.Identity.Type = ManagedServiceIdentityType.SystemAssigned;
            lro = await account.UpdateAsync(updateParameters);
            updatedAccount = lro.Value;
            ResourceDataHelper.AssertAccountUpdate(updatedAccount, updateParameters);
        }
    }
}
