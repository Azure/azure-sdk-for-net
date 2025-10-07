// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maps.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maps.Tests
{
    public class MapsAccountTests : MapsManagementTestBase
    {
        public MapsAccountTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task MapsAccountCreateTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            // Prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            Thread.Sleep(30000);
            var newAccount = (await mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, MapsSkuName.G2);

            // Now get the account
            Thread.Sleep(30000);
            var account = (await mapCollection.GetAsync(accountName)).Value;
            VerifyAccountProperties(account.Data, true, MapsSkuName.G2);

            // Now delete the account
            await account.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await mapCollection.ExistsAsync(accountName)).Value;
            Assert.IsFalse(falseResult);
        }

        [RecordedTest]
        public async Task MapsAccountUpdateTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            // Prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, MapsSkuName.G2);

            // Create new parameters which are almost the same, but have different tags
            var newParameters = GetDefaultMapsAccountData();
            newParameters.Tags.Clear();
            newParameters.Tags.Add("key3", "value3");
            newParameters.Tags.Add("key4", "value4");
            Thread.Sleep(30000);
            var updatedAccount = (await mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, newParameters)).Value;
            Assert.AreEqual(2, updatedAccount.Data.Tags.Count);
            Assert.AreEqual("value3", updatedAccount.Data.Tags["key3"]);
            Assert.AreEqual("value4", updatedAccount.Data.Tags["key4"]);
        }

        [RecordedTest]
        public async Task MapsAccountDeleteTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            // Delete an account which does not exist
            var id = MapsAccountResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, resourceGroup.Data.Name, "missingaccount");
            var falseAccount = Client.GetMapsAccountResource(id);
            await falseAccount.DeleteAsync(WaitUntil.Completed);

            // Create account
            var newAccount = await CreateDefaultMapsAccount(mapCollection);

            // Delete an account
            Thread.Sleep(30000);
            await newAccount.DeleteAsync(WaitUntil.Completed);

            // Delete an account which was just deleted
            await newAccount.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task MapsAccountListByResourceGroupTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            var accounts = await mapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(accounts.Count, 0);

            // Create accounts
            await CreateDefaultMapsAccount(mapCollection);
            await CreateDefaultMapsAccount(mapCollection);

            accounts = await mapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, accounts.Count);

            VerifyAccountProperties(accounts.First().Data, true, MapsSkuName.G2);
            VerifyAccountProperties(accounts.Skip(1).First().Data, true, MapsSkuName.G2);
        }

        [RecordedTest]
        public async Task MapsAccountListBySubscriptionTest()
        {
            // Create account
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();
            var accountName1 = await CreateDefaultMapsAccount(mapCollection);

            // Create different resource group and account
            var resourceGroup2 = await CreateResourceGroupAsync();
            var mapCollection2 = resourceGroup2.GetMapsAccounts();
            var accountName2 = await CreateDefaultMapsAccount(mapCollection2);

            var accounts = await DefaultSubscription.GetMapsAccountsAsync().ToEnumerableAsync();

            Assert.GreaterOrEqual(accounts.Count, 2);

            var account1 = accounts.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.Data.Name, accountName1.Data.Name));
            VerifyAccountProperties(account1.Data, true, MapsSkuName.G2);

            var account2 = accounts.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.Data.Name, accountName2.Data.Name));
            VerifyAccountProperties(account2.Data, true, MapsSkuName.G2);
        }

        [RecordedTest]
        public async Task MapsAccountListKeysTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            // Create account
            var newAccount = await CreateDefaultMapsAccount(mapCollection);

            // List keys
            var keys = (await newAccount.GetKeysAsync()).Value;
            Assert.NotNull(keys);

            // Validate Key1
            Assert.NotNull(keys.PrimaryKey);

            // Validate Key2
            Assert.NotNull(keys.SecondaryKey);
        }

        [RecordedTest]
        public async Task MapsAccountRegenerateKeyTest()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var mapCollection = resourceGroup.GetMapsAccounts();

            // Create account
            var newAccount = await CreateDefaultMapsAccount(mapCollection);

            // List keys
            var keys = (await newAccount.GetKeysAsync()).Value;
            Assert.NotNull(keys);
            var key2 = keys.SecondaryKey;
            Assert.NotNull(key2);

            // Regenerate keys and verify that keys change
            var regenKeys = (await newAccount.RegenerateKeysAsync(new MapsKeySpecification(MapsKeyType.Secondary))).Value;
            var key2Regen = regenKeys.SecondaryKey;
            Assert.NotNull(key2Regen);

            // Validate key was regenerated
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(key2, key2Regen);
            }
        }
    }
}
