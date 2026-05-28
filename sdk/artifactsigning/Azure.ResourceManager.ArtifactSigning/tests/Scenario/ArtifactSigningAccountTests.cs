// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ArtifactSigning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ArtifactSigning.Tests.Scenario
{
    public class ArtifactSigningAccountTests : ArtifactSigningManagementTestBase
    {
        public ArtifactSigningAccountTests(bool isAsync) : base(isAsync)
        {
        }

        public ArtifactSigningAccountTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CheckNameAvailabilityArtifactSigningAccount()
        {
            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountNameAvailabilityContent body = new ArtifactSigningAccountNameAvailabilityContent(new ResourceType("Microsoft.CodeSigning/codeSigningAccounts"), accountName);
            ArtifactSigningAccountNameAvailabilityResult result = await DefaultSubscription.CheckArtifactSigningAccountNameAvailabilityAsync(body);

            Assert.IsTrue(result.IsNameAvailable);
        }

        // Get a Artifact Signing Account
        [Test]
        [RecordedTest]
        public async Task Get_GetAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            ArtifactSigningAccountResource accountResource = Client.GetArtifactSigningAccountResource(account.Id);
            ArtifactSigningAccountResource result = await accountResource.GetAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data.Name, accountName);
        }

        // Update a Artifact Signing account.
        [Test]
        [RecordedTest]
        public async Task Update_UpdateAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            // invoke the operation
            ArtifactSigningAccountPatch patch = new ArtifactSigningAccountPatch()
            {
                Tags = { ["key1"] = "value1" }
            };
            ArmOperation<ArtifactSigningAccountResource> lro = await account.UpdateAsync(WaitUntil.Completed, patch);
            ArtifactSigningAccountResource result = lro.Value;

            ArtifactSigningAccountData resourceData = result.Data;
            Assert.IsNotNull(resourceData.Id);
            Assert.AreEqual(resourceData.Tags["key1"], patch.Tags["key1"]);
        }

        // Delete a Artifact Signing account.
        [Test]
        [RecordedTest]
        public async Task Delete_DeleteAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            ArmOperation op = await account.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(op.HasCompleted);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsArtifactSigningAccountsWithinAResourceGroup()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            bool exist = false;
            await foreach (ArtifactSigningAccountResource item in collection.GetAllAsync())
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
        public async Task Exists_GetAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            bool exist = await collection.ExistsAsync(accountName);
            Assert.IsFalse(exist);

            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            exist = await collection.ExistsAsync(accountName);
            Assert.IsTrue(exist);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");
            NullableResponse<ArtifactSigningAccountResource> response = await collection.GetIfExistsAsync(accountName);
            Assert.IsFalse(response.HasValue);

            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            response = await collection.GetIfExistsAsync(accountName);
            Assert.IsTrue(response.HasValue);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateAArtifactSigningAccount()
        {
            ArtifactSigningAccountCollection collection = await GetArtifactSigningAccounts();

            string accountName = Recording.GenerateAssetName("account-");

            ArtifactSigningAccountResource account = await CreateArtifactSigningAccount(collection, accountName);
            Assert.IsNotNull(account);
        }
    }
}
