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

            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse.Count, Is.EqualTo(3));

            // get first subscription
            var firstSubscription = listResponse.FirstOrDefault();

            var getResponse = (await collection.GetAsync(firstSubscription.Data.Name)).Value;

            Assert.That(getResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getResponse.Data.Name, Is.EqualTo(firstSubscription.Data.Name));
                Assert.That(getResponse.Data.NotifiesOn, Is.EqualTo(firstSubscription.Data.NotifiesOn));
                Assert.That(getResponse.Data.PrimaryKey, Is.EqualTo(firstSubscription.Data.PrimaryKey));
                Assert.That(getResponse.Data.Scope, Is.EqualTo(firstSubscription.Data.Scope));
                Assert.That(getResponse.Data.SecondaryKey, Is.EqualTo(firstSubscription.Data.SecondaryKey));
                Assert.That(getResponse.Data.StartOn, Is.EqualTo(firstSubscription.Data.StartOn));
                Assert.That(getResponse.Data.State, Is.EqualTo(firstSubscription.Data.State));
                Assert.That(getResponse.Data.StateComment, Is.EqualTo(firstSubscription.Data.StateComment));
                Assert.That(getResponse.Data.OwnerId, Is.EqualTo(firstSubscription.Data.OwnerId));
                Assert.That(getResponse.Data.CreatedOn, Is.EqualTo(firstSubscription.Data.CreatedOn));
                Assert.That(getResponse.Data.EndOn, Is.EqualTo(firstSubscription.Data.EndOn));
                Assert.That(getResponse.Data.ExpireOn, Is.EqualTo(firstSubscription.Data.ExpireOn));
            });

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

            Assert.That(subscriptionContract, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(subscriptionContract.Data.Scope, Is.EqualTo(firstSubscription.Data.Scope));
                Assert.That(subscriptionContract.Data.OwnerId, Is.EqualTo(firstSubscription.Data.OwnerId));
                Assert.That(subscriptionContract.Data.State, Is.EqualTo(newSubscriptionState));
                Assert.That(subscriptionContract.Data.DisplayName, Is.EqualTo(newSubscriptionName));
            });

            var subscriptionResponse = (await collection.GetAsync(newSubscriptionId)).Value;

            Assert.That(subscriptionResponse, Is.Not.Null);
            Assert.That(subscriptionResponse.Data.DisplayName, Is.Not.Null);

            // list product subscriptions
            var productSubscriptions = await product.GetAllProductSubscriptionDataAsync().ToEnumerableAsync();
            Assert.That(productSubscriptions, Is.Not.Null);
            Assert.That(productSubscriptions.Count, Is.EqualTo(2));

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

            Assert.That(getResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getResponse.Data.Name, Is.EqualTo(newSubscriptionId));
                Assert.That(getResponse.Data.DisplayName, Is.EqualTo(patchedName));
                Assert.That(getResponse.Data.PrimaryKey, Is.Null);
                Assert.That(getResponse.Data.SecondaryKey, Is.Null);
                Assert.That(getResponse.Data.State, Is.EqualTo(newSubscriptionState));
            });

            // regenerate primary key
            await getResponse.RegeneratePrimaryKeyAsync();

            // get the subscription to check the key
            var keysResponse = (await collection.GetAsync(newSubscriptionId)).Value;

            Assert.That(keysResponse, Is.Not.Null);
            Assert.That(keysResponse.Data.PrimaryKey, Is.Not.EqualTo(patchedPk));

            // regenerate secondary key
            await getResponse.RegenerateSecondaryKeyAsync();

            // get the subscription to check the key
            var keysHttpResponse = (await getResponse.GetAsync()).Value;

            Assert.That(keysHttpResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(keysHttpResponse.Data.PrimaryKey, Is.Not.EqualTo(patchedPk));
                Assert.That(keysHttpResponse.Data.SecondaryKey, Is.Not.EqualTo(patchedSk));
            });

            // delete the subscription
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await collection.ExistsAsync(newSubscriptionId)).Value;
            Assert.That(falseResult, Is.False);

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
            Assert.That(globalSubscriptionCreateResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(globalSubscriptionCreateResponse.Data.OwnerId, Is.Null);
                Assert.That(globalSubscriptionCreateResponse.Data.State, Is.EqualTo(SubscriptionState.Active));
                Assert.That(globalSubscriptionCreateResponse.Data.SecondaryKey, Is.Not.Null);
                Assert.That(globalSubscriptionCreateResponse.Data.PrimaryKey, Is.Not.Null);
                Assert.That(globalSubscriptionCreateResponse.Data.DisplayName, Is.EqualTo(globalSubscriptionDisplayName));
            });

            // delete the global subscription
            await globalSubscriptionCreateResponse.DeleteAsync(WaitUntil.Completed, ETag.All);

            // get the deleted subscription to make sure it was deleted
            falseResult = (await collection.ExistsAsync(globalSubscriptionId)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
