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

        protected TrustedSigningAccountTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CheckNameAvailabilityCodeSigningAccount_ChecksThatTheTrustedSigningAccountNameIsAvailable()
        {
            TokenCredential cred = TestEnvironment.Credential;

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
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            CodeSigningAccountResource result = await codeSigningAccount.GetAsync();

            CodeSigningAccountData resourceData = result.Data;
            // for demo we just print out the id
            Assert.IsNotNull(resourceData);
            Assert.AreEqual(resourceData.Name, accountName);
        }

        // Update a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Update_UpdateATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            CodeSigningAccountPatch patch = new CodeSigningAccountPatch()
            { Tags = { ["key1"] = "value1", }, };

            ArmOperation<CodeSigningAccountResource> lro = await codeSigningAccount.UpdateAsync(WaitUntil.Completed, patch);
            CodeSigningAccountResource result = lro.Value;

            CodeSigningAccountData resourceData = result.Data;
            Assert.IsNotNull(resourceData.Id);
        }

        // Delete a trusted signing account.
        [Test]
        [RecordedTest]
        public async Task Delete_DeleteATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            var t = await codeSigningAccount.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(t.Id);
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

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation and iterate over the result
            await foreach (CodeSigningAccountResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                CodeSigningAccountData resourceData = item.Data;

                Assert.IsNotNull(resourceData);
                Assert.IsNotNull(resourceData.Name);
            }
        }

        [Test]
        [RecordedTest]
        public async Task Exists_GetATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation
            bool result = await collection.ExistsAsync(accountName);
            Assert.IsTrue(result);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetATrustedSigningAccount()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

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

            CodeSigningAccountData resourceData = result.Data;
            Assert.IsNotNull(resourceData);
        }
    }
}
