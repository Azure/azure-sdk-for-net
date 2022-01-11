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
            DeviceUpdateAccount account = await CreateAccount(rg, accountName);
            await account.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await account.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        // Temporarily remove
        //[TestCase]
        //[RecordedTest]
        //[Ignore("Need fix in OperationInternals")]
        //public async Task Update()
        //{
        //    Subscription subscription = await Client.GetDefaultSubscriptionAsync();
        //    ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("DeviceUpdateResourceGroup");
        //    DeviceUpdateAccount account = await rg.GetDeviceUpdateAccounts().GetAsync("AzureDeviceUpdateAccount");
        //    DeviceUpdateAccountUpdateOptions updateOptions = new DeviceUpdateAccountUpdateOptions()
        //    {
        //        Location = Location.WestUS2,
        //        Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None)
        //    };
        //    var lro = await account.UpdateAsync(updateOptions);
        //    DeviceUpdateAccount updatedAccount = lro.Value;
        //    ResourceDataHelper.AssertAccountUpdate(updatedAccount, updateOptions);
        //    updateOptions.Identity.Type = ManagedServiceIdentityType.SystemAssigned;
        //    lro = await account.UpdateAsync(updateOptions);
        //    updatedAccount = lro.Value;
        //    ResourceDataHelper.AssertAccountUpdate(updatedAccount, updateOptions);
        //}
    }
}
