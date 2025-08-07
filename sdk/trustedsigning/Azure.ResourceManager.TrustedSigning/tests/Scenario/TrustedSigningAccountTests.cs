// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrustedSigning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.TrustedSigning.Tests.Scenario
{
    public class TrustedSigningAccountTests : TrustedSigningManagementTestBase
    {
        public TrustedSigningAccountTests(bool isAsync) : base(isAsync)
        {
        }

        public TrustedSigningAccountTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CheckNameAvailabilityCodeSigningAccount_ChecksThatTheTrustedSigningAccountNameIsAvailable()
        {
            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountNameAvailabilityContent body = new TrustedSigningAccountNameAvailabilityContent(accountName, new ResourceType("Microsoft.CodeSigning/codeSigningAccounts"));
            TrustedSigningAccountNameAvailabilityResult result = await DefaultSubscription.CheckTrustedSigningAccountNameAvailabilityAsync(body);

            Assert.IsTrue(result.IsNameAvailable);
        }

        // Get a Trusted Signing Account
        [Test]
        [RecordedTest]
        public async Task Get_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            TrustedSigningAccountResource accountResource = Client.GetTrustedSigningAccountResource(account.Id);
            TrustedSigningAccountResource result = await accountResource.GetAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data.Name, accountName);
        }

        // Update a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Update_UpdateATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            // invoke the operation
            TrustedSigningAccountPatch patch = new TrustedSigningAccountPatch()
            {
                Tags = { ["key1"] = "value1" }
            };
            ArmOperation<TrustedSigningAccountResource> lro = await account.UpdateAsync(WaitUntil.Completed, patch);
            TrustedSigningAccountResource result = lro.Value;

            TrustedSigningAccountData resourceData = result.Data;
            Assert.IsNotNull(resourceData.Id);
            Assert.AreEqual(resourceData.Tags["key1"], patch.Tags["key1"]);
        }

        // Delete a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Delete_DeleteATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            ArmOperation op = await account.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(op.HasCompleted);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsTrustedSigningAccountsWithinAResourceGroup()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            bool exist = false;
            await foreach (TrustedSigningAccountResource item in collection.GetAllAsync())
            {
                Assert.IsNotNull(item);
                if (item.Id == account.Id)
                {
                    exist = true;
                    break;
                }
            }
            Assert.IsTrue(exist);
        }

        [Test]
        [RecordedTest]
        public async Task Exists_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            bool exist = await collection.ExistsAsync(accountName);
            Assert.IsFalse(exist);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            exist = await collection.ExistsAsync(accountName);
            Assert.IsTrue(exist);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            NullableResponse<TrustedSigningAccountResource> response = await collection.GetIfExistsAsync(accountName);
            Assert.IsFalse(response.HasValue);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            response = await collection.GetIfExistsAsync(accountName);
            Assert.IsTrue(response.HasValue);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);
        }
    }
}
