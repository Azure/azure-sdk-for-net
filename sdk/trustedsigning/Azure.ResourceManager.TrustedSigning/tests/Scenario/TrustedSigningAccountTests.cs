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
            TrustedSigningAccountNameAvailabilityContent body = new TrustedSigningAccountNameAvailabilityContent(new ResourceType("Microsoft.CodeSigning/codeSigningAccounts"), accountName);
            TrustedSigningAccountNameAvailabilityResult result = await DefaultSubscription.CheckTrustedSigningAccountNameAvailabilityAsync(body);

            Assert.That(result.IsNameAvailable, Is.True);
        }

        // Get a Trusted Signing Account
        [Test]
        [RecordedTest]
        public async Task Get_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            TrustedSigningAccountResource accountResource = Client.GetTrustedSigningAccountResource(account.Id);
            TrustedSigningAccountResource result = await accountResource.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(accountName, Is.EqualTo(result.Data.Name));
            });
        }

        // Update a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Update_UpdateATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            // invoke the operation
            TrustedSigningAccountPatch patch = new TrustedSigningAccountPatch()
            {
                Tags = { ["key1"] = "value1" }
            };
            ArmOperation<TrustedSigningAccountResource> lro = await account.UpdateAsync(WaitUntil.Completed, patch);
            TrustedSigningAccountResource result = lro.Value;

            TrustedSigningAccountData resourceData = result.Data;
            Assert.Multiple(() =>
            {
                Assert.That(resourceData.Id, Is.Not.Null);
                Assert.That(patch.Tags["key1"], Is.EqualTo(resourceData.Tags["key1"]));
            });
        }

        // Delete a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Delete_DeleteATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            ArmOperation op = await account.DeleteAsync(WaitUntil.Completed);
            Assert.That(op.HasCompleted, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsTrustedSigningAccountsWithinAResourceGroup()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            bool exist = false;
            await foreach (TrustedSigningAccountResource item in collection.GetAllAsync())
            {
                Assert.That(item, Is.Not.Null);
                if (item.Id == account.Id)
                {
                    exist = true;
                    break;
                }
            }
            Assert.That(exist, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task Exists_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            bool exist = await collection.ExistsAsync(accountName);
            Assert.That(exist, Is.False);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            exist = await collection.ExistsAsync(accountName);
            Assert.That(exist, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            NullableResponse<TrustedSigningAccountResource> response = await collection.GetIfExistsAsync(accountName);
            Assert.That(response.HasValue, Is.False);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);

            response = await collection.GetIfExistsAsync(accountName);
            Assert.Multiple(() =>
            {
                Assert.That(response.HasValue, Is.True);
                Assert.That(response.Value, Is.Not.Null);
            });
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.That(account, Is.Not.Null);
        }
    }
}
