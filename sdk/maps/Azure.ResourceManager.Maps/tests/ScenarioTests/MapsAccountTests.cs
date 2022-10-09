// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
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

        private ResourceGroupResource ResourceGroup { get; set; }

        private MapsAccountCollection MapCollection { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            MapCollection = ResourceGroup.GetMapsAccounts();
        }

        [Test]
        public async Task MapsAccountCreateTest()
        {
            await SetCollection();

            // prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, Name.S0);

            // now get the account
            var account = (await MapCollection.GetAsync(accountName)).Value;
            VerifyAccountProperties(account.Data, true, Name.S0);

            // now delete the account
            await account.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await MapCollection.ExistsAsync(accountName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task MapsAccountUpdateTest()
        {
            await SetCollection();

            // prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, Name.S0);

            // create new parameters which are almost the same, but have different tags
            var newParameters = GetDefaultMapsAccountData();
            newParameters.Tags.Clear();
            newParameters.Tags.Add("key3", "value3");
            newParameters.Tags.Add("key4", "value4");
            newParameters.Sku.Name = Name.S1;
            var updatedAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, newParameters)).Value;
            VerifyAccountProperties(updatedAccount.Data, false, skuName: Name.S1);
            Assert.AreEqual(2, updatedAccount.Data.Tags.Count);
            Assert.AreEqual("value3", updatedAccount.Data.Tags["key3"]);
            Assert.AreEqual("value4", updatedAccount.Data.Tags["key4"]);
        }

        [Test]
        public async Task MapsAccountDeleteTest()
        {
            await SetCollection();

            // Delete an account which does not exist
            var id = MapsAccountResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, "missingaccount");
            var falseAccount = new MapsAccountResource(Client, id);
            await falseAccount.DeleteAsync(WaitUntil.Completed);

            // prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            // Delete an account
            await newAccount.DeleteAsync(WaitUntil.Completed);

            // Delete an account which was just deleted
            await newAccount.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task MapsAccountListByResourceGroupTest()
        {
            await SetCollection();

            var accounts = await MapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(accounts.Count, 0);

            // Create accounts
            var accountName1 = await CreateDefaultMapsAccount(MapCollection, ResourceGroup.Data.Name);
            var accountName2 = await CreateDefaultMapsAccount(MapCollection, ResourceGroup.Data.Name);

            accounts = await MapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, accounts.Count);

            VerifyAccountProperties(accounts.First().Data, true, Name.S0);
            VerifyAccountProperties(accounts.Skip(1).First().Data, true, Name.S0);
        }

        [Test]
        public async Task MapsAccountListBySubscriptionTest()
        {
            // Create account
            await SetCollection();
            var accountName1 = await CreateDefaultMapsAccount(MapCollection, ResourceGroup.Data.Name);

            // Create different resource group and account
            var rg2 = await CreateResourceGroupAsync();
            var mapCollection2 = rg2.GetMapsAccounts();
            var accountName2 = await CreateDefaultMapsAccount(mapCollection2, rg2.Data.Name);

            var accounts = await DefaultSubscription.GetMapsAccountsAsync().ToEnumerableAsync();

            Assert.GreaterOrEqual(accounts.Count, 2);

            var account1 = accounts.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.Data.Name, accountName1));
            VerifyAccountProperties(account1.Data, true, Name.S0);

            var account2 = accounts.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.Data.Name, accountName2));
            VerifyAccountProperties(account2.Data, true, Name.S0);
        }

        [Test]
        public async Task MapsAccountListKeysTest()
        {
            await SetCollection();

            // prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, Name.S0);

            // List keys
            var keys = (await newAccount.GetKeysAsync()).Value;
            Assert.NotNull(keys);

            // Validate Key1
            Assert.NotNull(keys.PrimaryKey);

            // Validate Key2
            Assert.NotNull(keys.SecondaryKey);
        }

        [Test]
        public async Task MapsAccountRegenerateKeyTest()
        {
            await SetCollection();

            // prepare account properties
            string accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();

            // Create account
            var newAccount = (await MapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, Name.S0);

            // List keys
            var keys = (await newAccount.GetKeysAsync()).Value;
            Assert.NotNull(keys);
            var key2 = keys.SecondaryKey;
            Assert.NotNull(key2);

            // Regenerate keys and verify that keys change
            var regenKeys = (await newAccount.RegenerateKeysAsync(new MapsKeySpecification(KeyType.Secondary))).Value;
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
