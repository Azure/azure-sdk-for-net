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

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.Standard, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetProducts();

            var listResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listResponse);
            Assert.AreEqual(2, listResponse.Count);// there are 2 product Starter and Unlimited created by default

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
                ApprovalRequired = productApprovalRequired,
                Description = productDescription,
                State = productState,
                SubscriptionRequired = productSubscriptionRequired,
                SubscriptionsLimit = productSubscriptionsLimit,
                Terms = productTerms
            };

            var createResponse = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                productId,
                createParameters)).Value;

            Assert.NotNull(createResponse);
            Assert.AreEqual(productName, createResponse.Data.DisplayName);
            Assert.AreEqual(productApprovalRequired, createResponse.Data.ApprovalRequired);
            Assert.AreEqual(productDescription, createResponse.Data.Description);
            Assert.AreEqual(productState, createResponse.Data.State);
            Assert.AreEqual(productSubscriptionRequired, createResponse.Data.SubscriptionRequired);
            Assert.AreEqual(productSubscriptionsLimit, createResponse.Data.SubscriptionsLimit);
            Assert.AreEqual(productTerms, createResponse.Data.Terms);

            // update product
            string patchedName = Recording.GenerateAssetName("productName");
            string patchedDescription = Recording.GenerateAssetName("productDescription");
            string patchedTerms = Recording.GenerateAssetName("productTerms");
            var updateParameters = new ProductPatch
            {
                DisplayName = patchedName,
                Description = patchedDescription,
                Terms = patchedTerms
            };
            await createResponse.UpdateAsync(ETag.All.ToString(), updateParameters);

            // get to check it was updated
            var getUpdatedResponse = (await collection.GetAsync(productId)).Value;

            Assert.NotNull(getUpdatedResponse);

            Assert.AreEqual(patchedName, getUpdatedResponse.Data.DisplayName);
            Assert.AreEqual(productApprovalRequired, getUpdatedResponse.Data.ApprovalRequired);
            Assert.AreEqual(patchedDescription, getUpdatedResponse.Data.Description);
            Assert.AreEqual(productState, getUpdatedResponse.Data.State);
            Assert.AreEqual(productSubscriptionRequired, getUpdatedResponse.Data.SubscriptionRequired);
            Assert.AreEqual(productSubscriptionsLimit, getUpdatedResponse.Data.SubscriptionsLimit);
            Assert.AreEqual(patchedTerms, getUpdatedResponse.Data.Terms);

            // delete the product
            await getUpdatedResponse.DeleteAsync(WaitUntil.Completed, ETag.All.ToString(), true);
            var resultFalse = (await collection.ExistsAsync(productId)).Value;
            Assert.IsFalse(resultFalse);

            //
            // Product API test
            //
            var product = listResponse.FirstOrDefault(item => item.Data.Name.Equals("starter"));

            // list product apis: there should be 1
            var listApisResponse = await product.ProductApiGetByProductAsync().ToEnumerableAsync();

            Assert.NotNull(listApisResponse);
            Assert.AreEqual(listApisResponse.Count, 1);

            // get api
            var getResponse = listApisResponse.FirstOrDefault();
            Assert.NotNull(getResponse);

            // remove api from product
            await product.ProductApiDeleteAsync(getResponse.Data.Name);

            // list to check it was removed
            listApisResponse = await product.ProductApiGetByProductAsync().ToEnumerableAsync();

            Assert.IsEmpty(listApisResponse);

            // add the api to product
            var addResponse = product.ProductApiCreateOrUpdateAsync(getResponse.Data.Name);

            Assert.NotNull(addResponse);

            // list to check it was added
            listApisResponse = await product.ProductApiGetByProductAsync().ToEnumerableAsync();

            Assert.NotNull(listApisResponse);
            Assert.AreEqual(listApisResponse.Count, 1);

            //
            // Product Group Test
            //

            // list product groups: there sould be all three
            var listGroupsResponse = await product.ProductGroupGetByProductAsync().ToEnumerableAsync();

            Assert.NotNull(listGroupsResponse);
            Assert.AreEqual(3, listGroupsResponse.Count);

            // get group
            var getGroupResponse = (await ApiServiceResource.GetGroups().GetAsync(listGroupsResponse.FirstOrDefault().Data.Name)).Value;

            Assert.NotNull(getGroupResponse);

            // remove group from product
            await product.ProductGroupDeleteAsync(getGroupResponse.Data.Name);

            // list to check it was removed
            listGroupsResponse = await product.ProductGroupGetByProductAsync().ToEnumerableAsync();

            Assert.NotNull(listGroupsResponse);
            Assert.AreEqual(2, listGroupsResponse.Count);

            // assign the group to the product

            var addGroupResponse = (await product.ProductGroupCreateOrUpdateAsync(getGroupResponse.Data.Name)).Value;

            Assert.NotNull(addGroupResponse);

            // list to check it was added
            listGroupsResponse = await product.ProductGroupGetByProductAsync().ToEnumerableAsync();

            Assert.NotNull(listGroupsResponse);
            Assert.AreEqual(3, listGroupsResponse.Count);

            //
            // Product Subscriptions test
            //
            var listSubscriptionsResponse = await product.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listSubscriptionsResponse);
            Assert.AreEqual(listSubscriptionsResponse.Count, 1);
        }
    }
}
