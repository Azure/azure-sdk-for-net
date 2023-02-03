// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.GraphServices.Tests.Helpers;
using Azure.ResourceManager.GraphServices;
using Azure.ResourceManager.GraphServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.GraphServices.Tests.Tests
{
    [TestFixture]
    public class AccountCRUDTests : GraphServicesManagementTestBase
    {
        public AccountCRUDTests() : base(true)
        {
        }

        [SetUp]
        public void ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                CreateCommonClient();
            }
        }

        [TestCase]
        public async Task TestAccountCRUDOperations()
        {
            // Get Default Subscription
            SubscriptionResource subscription = await this.Client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            // Create Resource Group
            string resourceGroupName = "myRgName";
            ResourceGroupData resourceGroupData = new ResourceGroupData("westus");
            ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroupResource resourceGroup = operation.Value;

            AccountResourceCollection collection = resourceGroup.GetAccountResources();

            // Set Account Resource Values
            var resourceName = Recording.GenerateAssetName("SDKAccounts");
            string appId = new AccountTestEnvironment().ApplicationIDClient;
            AccountResourceProperties accountResourceProperties = new AccountResourceProperties(appId);
            AccountResourceData accountResourceData = new AccountResourceData("global", accountResourceProperties);

            // Create Account Resource
            var createAccountOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, accountResourceData);

            Assert.IsTrue(createAccountOperation.HasCompleted);
            Assert.IsTrue(createAccountOperation.HasValue);

            // Get
            Response<AccountResource> getAccountResponse = await collection.GetAsync(resourceName);
            AccountResource accountResource = getAccountResponse.Value;
            Assert.IsNotNull(accountResource);

            // Update
            var updateResource = await accountResource.AddTagAsync("Test","Value");
            var getAccountResponse_Update = await collection.GetAsync(resourceName);
            AccountResource accountResource_Get_Update = getAccountResponse_Update.Value;
            Assert.IsNotNull(accountResource_Get_Update);

            // Delete
            var accountOperation = await accountResource.DeleteAsync(WaitUntil.Completed);
            await accountOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(accountOperation.HasCompleted);

            await resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
