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

        //[OneTimeSetUp]
        //public async Task GlobalSetup()
        //{
        //    //TODO
        //    return;
        //}

        //[OneTimeTearDown]
        //public async Task GlobalTeardown()
        //{
        //    //TODO
        //    return;
        //}

        //[SetUp]
        //public async Task SetUp()
        //{
        //    //TODO
        //    return;
        //}

        //[TearDown]
        //public async Task TearDown()
        //{
        //    //TODO
        //    return;
        //}

        [Test]
        [RecordedTest]
        public async Task CheckNameAvailabilityCodeSigningAccount_ChecksThatTheTrustedSigningAccountNameIsAvailable()
        {
            // Generated from example definition: specification/codesigning/resource-manager/Microsoft.CodeSigning/preview/2024-02-05-preview/examples/CodeSigningAccounts_CheckNameAvailability.json
            // this example is just showing the usage of "CodeSigningAccounts_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;

            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
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
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "tobefilled";
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
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CodeSigningAccountResource created on azure
            // for more information of creating CodeSigningAccountResource, please refer to the document of CodeSigningAccountResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
            ResourceIdentifier codeSigningAccountResourceId = CodeSigningAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            CodeSigningAccountResource codeSigningAccount = client.GetCodeSigningAccountResource(codeSigningAccountResourceId);

            // invoke the operation
            CodeSigningAccountResource result = await codeSigningAccount.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
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
            // Generated from example definition: specification/codesigning/resource-manager/Microsoft.CodeSigning/preview/2024-02-05-preview/examples/CodeSigningAccounts_Update.json
            // this example is just showing the usage of "CodeSigningAccounts_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CodeSigningAccountResource created on azure
            // for more information of creating CodeSigningAccountResource, please refer to the document of CodeSigningAccountResource
            string subscriptionId = "";
            string resourceGroupName = "";
            string accountName = "";
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

            // this example assumes you already have this CodeSigningAccountResource created on azure
            // for more information of creating CodeSigningAccountResource, please refer to the document of CodeSigningAccountResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            string accountName = "MyAccount";
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
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
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
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
            bool result = await collection.ExistsAsync(accountName);
            Assert.IsTrue(result);
        }

        [Test]
        [RecordedTest]
        public async Task GetIfExists_GetATrustedSigningAccount()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = TestEnvironment.Credential;
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
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
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "MyResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this CodeSigningAccountResource
            CodeSigningAccountCollection collection = resourceGroupResource.GetCodeSigningAccounts();

            // invoke the operation
            string accountName = "MyAccount";
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
