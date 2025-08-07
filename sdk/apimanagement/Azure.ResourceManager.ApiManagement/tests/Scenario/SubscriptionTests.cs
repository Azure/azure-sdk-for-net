// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class SubscriptionTests : ApiManagementManagementTestBase
    {
        public SubscriptionTests(bool isAsync)
                       : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Standard, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementSubscriptions();

            // list subscriptions: there should be two by default
            var listResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listResponse);
            Assert.AreEqual(3, listResponse.Count);

            // get first subscription
            var firstSubscription = listResponse.FirstOrDefault();

            var getResponse = (await collection.GetAsync(firstSubscription.Data.Name)).Value;

            Assert.NotNull(getResponse);
            Assert.AreEqual(firstSubscription.Data.Name, getResponse.Data.Name);
            Assert.AreEqual(firstSubscription.Data.NotifiesOn, getResponse.Data.NotifiesOn);
            Assert.AreEqual(firstSubscription.Data.PrimaryKey, getResponse.Data.PrimaryKey);
            Assert.AreEqual(firstSubscription.Data.Scope, getResponse.Data.Scope);
            Assert.AreEqual(firstSubscription.Data.SecondaryKey, getResponse.Data.SecondaryKey);
            Assert.AreEqual(firstSubscription.Data.StartOn, getResponse.Data.StartOn);
            Assert.AreEqual(firstSubscription.Data.State, getResponse.Data.State);
            Assert.AreEqual(firstSubscription.Data.StateComment, getResponse.Data.StateComment);
            Assert.AreEqual(firstSubscription.Data.OwnerId, getResponse.Data.OwnerId);
            Assert.AreEqual(firstSubscription.Data.CreatedOn, getResponse.Data.CreatedOn);
            Assert.AreEqual(firstSubscription.Data.EndOn, getResponse.Data.EndOn);
            Assert.AreEqual(firstSubscription.Data.ExpireOn, getResponse.Data.ExpireOn);

            // update product to accept unlimited number or subscriptions
            var product = (await ApiServiceResource.GetApiManagementProducts().GetAsync("starter")).Value;
            await product.UpdateAsync(ETag.All,
                new ApiManagementProductPatch
                {
                    SubscriptionsLimit = int.MaxValue
                });

            // add new subscription
            string newSubscriptionId = Recording.GenerateAssetName("subscription");
            string globalSubscriptionId = Recording.GenerateAssetName("globalSubscription");

            string newSubscriptionName = Recording.GenerateAssetName("newSubscription1");
            string newSubscriptionPk = Recording.GenerateAssetName("newSubscription2");
            string newSubscriptionSk = Recording.GenerateAssetName("newSubscription3");
            var newSubscriptionState = SubscriptionState.Active;

            var newSubscriptionCreate = new ApiManagementSubscriptionCreateOrUpdateContent
            {
                DisplayName = newSubscriptionName,
                Scope = firstSubscription.Data.Scope,
                OwnerId = firstSubscription.Data.OwnerId,
                PrimaryKey = newSubscriptionPk,
                SecondaryKey = newSubscriptionSk,
                State = newSubscriptionState,
            };

            var subscriptionContract = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                newSubscriptionId,
                newSubscriptionCreate)).Value;

            Assert.NotNull(subscriptionContract);
            Assert.AreEqual(firstSubscription.Data.Scope, subscriptionContract.Data.Scope);
            Assert.AreEqual(firstSubscription.Data.OwnerId, subscriptionContract.Data.OwnerId);
            Assert.AreEqual(newSubscriptionState, subscriptionContract.Data.State);
            Assert.AreEqual(newSubscriptionName, subscriptionContract.Data.DisplayName);

            var subscriptionResponse = (await collection.GetAsync(newSubscriptionId)).Value;

            Assert.NotNull(subscriptionResponse);
            Assert.NotNull(subscriptionResponse.Data.DisplayName);

            // list product subscriptions
            var productSubscriptions = await product.GetAllProductSubscriptionDataAsync().ToEnumerableAsync();
            Assert.NotNull(productSubscriptions);
            Assert.AreEqual(2, productSubscriptions.Count);

            // patch the subscription
            string patchedName = Recording.GenerateAssetName("patched1");
            string patchedPk = Recording.GenerateAssetName("patched2");
            string patchedSk = Recording.GenerateAssetName("patched3");
            var patchedExpirationDate = DateTimeOffset.Parse("2025-07-19T16:00:00.0000000Z");

            await subscriptionContract.UpdateAsync(
                ETag.All,
                new ApiManagementSubscriptionPatch
                {
                    DisplayName = patchedName,
                    PrimaryKey = patchedPk,
                    SecondaryKey = patchedSk,
                    ExpireOn = patchedExpirationDate
                });

            // get patched subscription to check it was actually patched
            getResponse = (await collection.GetAsync(newSubscriptionId)).Value;

            Assert.NotNull(getResponse);
            Assert.AreEqual(newSubscriptionId, getResponse.Data.Name);
            Assert.AreEqual(patchedName, getResponse.Data.DisplayName);
            Assert.IsNull(getResponse.Data.PrimaryKey);
            Assert.IsNull(getResponse.Data.SecondaryKey);
            Assert.AreEqual(newSubscriptionState, getResponse.Data.State);

            // regenerate primary key
            await getResponse.RegeneratePrimaryKeyAsync();

            // get the subscription to check the key
            var keysResponse = (await collection.GetAsync(newSubscriptionId)).Value;

            Assert.NotNull(keysResponse);
            Assert.AreNotEqual(patchedPk, keysResponse.Data.PrimaryKey);

            // regenerate secondary key
            await getResponse.RegenerateSecondaryKeyAsync();

            // get the subscription to check the key
            var keysHttpResponse = (await getResponse.GetAsync()).Value;

            Assert.NotNull(keysHttpResponse);
            Assert.AreNotEqual(patchedPk, keysHttpResponse.Data.PrimaryKey);
            Assert.AreNotEqual(patchedSk, keysHttpResponse.Data.SecondaryKey);

            // delete the subscription
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await collection.ExistsAsync(newSubscriptionId)).Value;
            Assert.IsFalse(falseResult);

            // create a subscription with global scope on all apis
            var globalSubscriptionDisplayName = Recording.GenerateAssetName("global");
            var globalSubscriptionCreateResponse = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                globalSubscriptionId,
                new ApiManagementSubscriptionCreateOrUpdateContent
                {
                    Scope = "/apis",
                    DisplayName = globalSubscriptionDisplayName
                })).Value;
            Assert.NotNull(globalSubscriptionCreateResponse);
            Assert.IsNull(globalSubscriptionCreateResponse.Data.OwnerId);
            Assert.AreEqual(SubscriptionState.Active, globalSubscriptionCreateResponse.Data.State);
            Assert.NotNull(globalSubscriptionCreateResponse.Data.SecondaryKey);
            Assert.NotNull(globalSubscriptionCreateResponse.Data.PrimaryKey);
            Assert.AreEqual(globalSubscriptionDisplayName, globalSubscriptionCreateResponse.Data.DisplayName);

            // delete the global subscription
            await globalSubscriptionCreateResponse.DeleteAsync(WaitUntil.Completed, ETag.All);

            // get the deleted subscription to make sure it was deleted
            falseResult = (await collection.ExistsAsync(globalSubscriptionId)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
