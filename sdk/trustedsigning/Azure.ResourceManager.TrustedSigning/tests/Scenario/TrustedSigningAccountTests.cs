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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            TrustedSigningAccountNameAvailabilityContent body = new TrustedSigningAccountNameAvailabilityContent("sample-account");
            TrustedSigningAccountNameAvailabilityResult result = await subscriptionResource.CheckTrustedSigningAccountNameAvailabilityAsync(body);

            Assert.IsTrue(result.IsNameAvailable);
        }

        [Test]
        [RecordedTest]
        public async Task GetCodeSigningAccounts_ListsTrustedSigningAccountsWithinASubscription()
        {
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (TrustedSigningAccountResource item in subscriptionResource.GetTrustedSigningAccountsAsync())
            {
                TrustedSigningAccountData resourceData = item.Data;
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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = TrustedSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            TrustedSigningAccountResource codeSigningAccount = client.GetTrustedSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            TrustedSigningAccountResource result = await codeSigningAccount.GetAsync();

            TrustedSigningAccountData resourceData = result.Data;
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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "";
            string accountName = "";
            ResourceIdentifier codeSigningAccountResourceId = TrustedSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            TrustedSigningAccountResource codeSigningAccount = client.GetTrustedSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            TrustedSigningAccountPatch patch = new TrustedSigningAccountPatch()
            { Tags = { ["key1"] = "value1", }, };

            ArmOperation<TrustedSigningAccountResource> lro = await codeSigningAccount.UpdateAsync(WaitUntil.Completed, patch);
            TrustedSigningAccountResource result = lro.Value;

            TrustedSigningAccountData resourceData = result.Data;
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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = TrustedSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            TrustedSigningAccountResource codeSigningAccount = client.GetTrustedSigningAccountResource(codeSigningAccountResourceId);

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
            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this TrustedSigningAccountResource
            TrustedSigningAccountCollection collection = resourceGroupResource.GetTrustedSigningAccounts();

            // invoke the operation and iterate over the result
            await foreach (TrustedSigningAccountResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                TrustedSigningAccountData resourceData = item.Data;

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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this TrustedSigningAccountResource
            TrustedSigningAccountCollection collection = resourceGroupResource.GetTrustedSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
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

            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this TrustedSigningAccountResource
            TrustedSigningAccountCollection collection = resourceGroupResource.GetTrustedSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
            NullableResponse<TrustedSigningAccountResource> response = await collection.GetIfExistsAsync(accountName);
            TrustedSigningAccountResource result = response.HasValue ? response.Value : null;
            TrustedSigningAccountData resourceData = result.Data;
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
            string subscriptionId = "76a1b60e-e087-45e5-be6e-8cdeeaee8e77";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this TrustedSigningAccountResource
            TrustedSigningAccountCollection collection = resourceGroupResource.GetTrustedSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
            TrustedSigningAccountData data = new TrustedSigningAccountData(new AzureLocation("westus"))
            {
                SkuName = TrustedSigningSkuName.Basic,
            };
            ArmOperation<TrustedSigningAccountResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
            TrustedSigningAccountResource result = lro.Value;

            TrustedSigningAccountData resourceData = result.Data;
            Assert.IsNotNull(resourceData);
        }
    }
}
