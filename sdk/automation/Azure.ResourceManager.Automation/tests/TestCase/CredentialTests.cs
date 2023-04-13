// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class CredentialTests : AutomationManagementTestBase
    {
        public CredentialTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationCredentialCollection> GetCredentialCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetAutomationCredentials();
        }

        [TestCase]
        public async Task CredentialApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetCredentialCollectionAsync();
            var name = Recording.GenerateAssetName("credential");
            var name2 = Recording.GenerateAssetName("credential");
            var name3 = Recording.GenerateAssetName("credential");
            var input = ResourceDataHelpers.GetCredentialData(name);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationCredentialResource credential = lro.Value;
            Assert.AreEqual(name, credential.Data.Name);
            //2.Get
            AutomationCredentialResource credential2 = await credential.GetAsync();
            ResourceDataHelpers.AssertCredential(credential.Data, credential2.Data);
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
            AutomationCredentialResource credential3 = await credential.GetAsync();
            ResourceDataHelpers.AssertCredential(credential.Data, credential3.Data);
            //6.Delete
            await credential.DeleteAsync(WaitUntil.Completed);
        }
    }
}
