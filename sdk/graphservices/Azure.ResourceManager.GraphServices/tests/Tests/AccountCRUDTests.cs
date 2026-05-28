// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.GraphServices.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.GraphServices.Tests.Tests
{
    public class AccountCRUDTests : GraphServicesManagementTestBase
    {
        public AccountCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [LiveOnly(Reason = "ApplicationId cannot be stored in test recording.")]
        public async Task TestAccountCRUDOperations()
        {
            // Get Default Subscription
            SubscriptionResource subscription = await this.Client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            // Create Resource Group
            string resourceGroupName = "myRgName";
            ResourceGroupResource resourceGroup = await this.CreateResourceGroup(subscription, resourceGroupName, Core.AzureLocation.WestUS);
            GraphServicesAccountResourceCollection collection = resourceGroup.GetGraphServicesAccountResources();

            // Set Account Resource Values
            var resourceName = Recording.GenerateAssetName("SDKAccounts");
            string appId = TestEnvironment.ApplicationClientId;
            GraphServicesAccountResourceProperties accountResourceProperties = new GraphServicesAccountResourceProperties(appId);
            GraphServicesAccountResourceData accountResourceData = new GraphServicesAccountResourceData("global", accountResourceProperties);

            // Create Account Resource
            var createAccountOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, accountResourceData);

            Assert.IsTrue(createAccountOperation.HasCompleted);
            Assert.IsTrue(createAccountOperation.HasValue);
            Assert.AreEqual(resourceName, createAccountOperation.Value.Data.Name);
            Assert.AreEqual(appId, createAccountOperation.Value.Data.Properties.AppId);

            // Get
            Response<GraphServicesAccountResource> getAccountResponse = await collection.GetAsync(resourceName);
            GraphServicesAccountResource accountResource = getAccountResponse.Value;
            Assert.IsNotNull(accountResource);

            // Update
            var updatedAccountResponse = await accountResource.AddTagAsync("Test", "Value");
            Assert.IsNotNull(updatedAccountResponse);
            Assert.AreEqual(updatedAccountResponse.Value.Data.Tags["Test"], "Value");

            // Delete
            var accountOperation = await accountResource.DeleteAsync(WaitUntil.Completed);
            await accountOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(accountOperation.HasCompleted);
        }
    }
}
