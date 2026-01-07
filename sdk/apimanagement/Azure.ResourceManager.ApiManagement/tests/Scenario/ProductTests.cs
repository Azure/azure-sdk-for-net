// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class ProductTests : ApiManagementManagementTestBase
    {
        public ProductTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
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
            var collection = ApiServiceResource.GetApiManagementProducts();

            var listResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse.Count, Is.EqualTo(2));// there are 2 product Starter and Unlimited created by default

            string productId = Recording.GenerateAssetName("newproduct");

            string productName = Recording.GenerateAssetName("productName");
            bool? productApprovalRequired = true;
            string productDescription = Recording.GenerateAssetName("productDescription");
            ApiManagementProductState productState = ApiManagementProductState.NotPublished;
            bool? productSubscriptionRequired = true;
            int? productSubscriptionsLimit = 10;
            string productTerms = Recording.GenerateAssetName("productTerms");

            var createParameters = new ApiManagementProductData()
            {
                DisplayName = productName,
                IsApprovalRequired = productApprovalRequired,
                Description = productDescription,
                State = productState,
                IsSubscriptionRequired = productSubscriptionRequired,
                SubscriptionsLimit = productSubscriptionsLimit,
                Terms = productTerms
            };

            var createResponse = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                productId,
                createParameters)).Value;

            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.Data.DisplayName, Is.EqualTo(productName));
            Assert.That(createResponse.Data.IsApprovalRequired, Is.EqualTo(productApprovalRequired));
            Assert.That(createResponse.Data.Description, Is.EqualTo(productDescription));
            Assert.That(createResponse.Data.State, Is.EqualTo(productState));
            Assert.That(createResponse.Data.IsSubscriptionRequired, Is.EqualTo(productSubscriptionRequired));
            Assert.That(createResponse.Data.SubscriptionsLimit, Is.EqualTo(productSubscriptionsLimit));
            Assert.That(createResponse.Data.Terms, Is.EqualTo(productTerms));

            // update product
            string patchedName = Recording.GenerateAssetName("productName");
            string patchedDescription = Recording.GenerateAssetName("productDescription");
            string patchedTerms = Recording.GenerateAssetName("productTerms");
            var updateParameters = new ApiManagementProductPatch
            {
                DisplayName = patchedName,
                Description = patchedDescription,
                Terms = patchedTerms
            };
            await createResponse.UpdateAsync(ETag.All, updateParameters);

            // get to check it was updated
            var getUpdatedResponse = (await collection.GetAsync(productId)).Value;

            Assert.That(getUpdatedResponse, Is.Not.Null);

            Assert.That(getUpdatedResponse.Data.DisplayName, Is.EqualTo(patchedName));
            Assert.That(getUpdatedResponse.Data.IsApprovalRequired, Is.EqualTo(productApprovalRequired));
            Assert.That(getUpdatedResponse.Data.Description, Is.EqualTo(patchedDescription));
            Assert.That(getUpdatedResponse.Data.State, Is.EqualTo(productState));
            Assert.That(getUpdatedResponse.Data.IsSubscriptionRequired, Is.EqualTo(productSubscriptionRequired));
            Assert.That(getUpdatedResponse.Data.SubscriptionsLimit, Is.EqualTo(productSubscriptionsLimit));
            Assert.That(getUpdatedResponse.Data.Terms, Is.EqualTo(patchedTerms));

            // delete the product
            await getUpdatedResponse.DeleteAsync(WaitUntil.Completed, ETag.All, true);
            var resultFalse = (await collection.ExistsAsync(productId)).Value;
            Assert.That(resultFalse, Is.False);

            //
            // Product API test
            //
            var product = listResponse.FirstOrDefault(item => item.Data.Name.Equals("starter"));

            // list product apis: there should be 1
            var listApisResponse = await product.GetProductApisAsync().ToEnumerableAsync();

            Assert.That(listApisResponse, Is.Not.Null);
            Assert.That(listApisResponse.Count, Is.EqualTo(1));

            // get api
            var getResponse = listApisResponse.FirstOrDefault();
            Assert.That(getResponse, Is.Not.Null);

            // remove api from product
            await product.DeleteProductApiAsync(getResponse.Name);

            // list to check it was removed
            listApisResponse = await product.GetProductApisAsync().ToEnumerableAsync();

            Assert.IsEmpty(listApisResponse);

            // add the api to product
            var addResponse = product.CreateOrUpdateProductApiAsync(getResponse.Name);

            Assert.That(addResponse, Is.Not.Null);

            // list to check it was added
            listApisResponse = await product.GetProductApisAsync().ToEnumerableAsync();

            Assert.That(listApisResponse, Is.Not.Null);
            Assert.That(listApisResponse.Count, Is.EqualTo(1));

            //
            // Product Group Test
            //

            // list product groups: there sould be all three
            var listGroupsResponse = await product.GetProductGroupsAsync().ToEnumerableAsync();

            Assert.That(listGroupsResponse, Is.Not.Null);
            Assert.That(listGroupsResponse.Count, Is.EqualTo(3));

            // get group
            var getGroupResponse = (await ApiServiceResource.GetApiManagementGroups().GetAsync(listGroupsResponse.FirstOrDefault().Name)).Value;

            Assert.That(getGroupResponse, Is.Not.Null);

            // remove group from product
            await product.DeleteProductGroupAsync(getGroupResponse.Data.Name);

            // list to check it was removed
            listGroupsResponse = await product.GetProductGroupsAsync().ToEnumerableAsync();

            Assert.That(listGroupsResponse, Is.Not.Null);
            Assert.That(listGroupsResponse.Count, Is.EqualTo(2));

            // assign the group to the product

            var addGroupResponse = (await product.CreateOrUpdateProductGroupAsync(getGroupResponse.Data.Name)).Value;

            Assert.That(addGroupResponse, Is.Not.Null);

            // list to check it was added
            listGroupsResponse = await product.GetProductGroupsAsync().ToEnumerableAsync();

            Assert.That(listGroupsResponse, Is.Not.Null);
            Assert.That(listGroupsResponse.Count, Is.EqualTo(3));

            //
            // Product Subscriptions test
            //
            var listSubscriptionsResponse = await product.GetAllProductSubscriptionDataAsync().ToEnumerableAsync();

            Assert.That(listSubscriptionsResponse, Is.Not.Null);
            Assert.That(listSubscriptionsResponse.Count, Is.EqualTo(1));
        }
    }
}
