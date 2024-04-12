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
        protected string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
        protected string resourceGroupName = "acsportal-bvt";
        protected string accountName = "sample-test-wcus";
        protected string profileName = "testProfileB";

        protected TrustedSigningAccountTests(bool isAsync) : base(isAsync)
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

            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            CheckNameAvailability body = new CheckNameAvailability("sample-account");
            CheckNameAvailabilityResult result = await subscriptionResource.CheckNameAvailabilityCodeSigningAccountAsync(body);

            Assert.IsTrue(result.NameAvailable);
        }

        [Test]
        [RecordedTest]
        public async Task GetCodeSigningAccounts_ListsTrustedSigningAccountsWithinASubscription()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (CodeSigningAccountResource item in subscriptionResource.GetCodeSigningAccountsAsync())
            {
                CodeSigningAccountData resourceData = item.Data;
                Assert.IsNotNull(resourceData.Id);
            }
        }

        // Get a Trusted Signing Account
        [Test]
        [RecordedTest]
        public async Task Get_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

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

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            TrustedSigningAccountPatch patch = new TrustedSigningAccountPatch()
            {
                Tags = { ["key1"] = "value1"}
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

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            ArmOperation op = await account.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(op.HasCompleted);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsTrustedSigningAccountsWithinAResourceGroup()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

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

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            // invoke the operation
            bool result = await collection.ExistsAsync(accountName);
            Assert.IsTrue(result);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetATrustedSigningAccount()
        {
            TrustedSigningAccountCollection collection = await GetTrustedSigningAccounts();

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);

            // invoke the operation
            NullableResponse<CodeSigningAccountResource> response = await collection.GetIfExistsAsync(accountName);
            CodeSigningAccountResource result = response.HasValue ? response.Value : null;
            CodeSigningAccountData resourceData = result.Data;
            // for demo we just print out the id
            Assert.IsNotNull(resourceData);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation
            CodeSigningAccountData data = new CodeSigningAccountData(new AzureLocation("westus"))
            {
                SkuName = TrustedSigningSkuName.Basic,
            };
            ArmOperation<CodeSigningAccountResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
            CodeSigningAccountResource result = lro.Value;

            TrustedSigningAccountResource account = await CreateTrustedSigningAccount(collection, accountName);
            Assert.IsNotNull(account);
        }
    }
}
