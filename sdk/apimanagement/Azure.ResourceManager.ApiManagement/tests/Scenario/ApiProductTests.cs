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
    public class ApiProductTests : ApiManagementManagementTestBase
    {
        public ApiProductTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.BasicV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();

            var list = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);

            var productCollections = ApiServiceResource.GetProducts();
            var listResponse = await productCollections.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listResponse);
            Assert.AreEqual(0, listResponse.Count());

            var productId = Recording.GenerateAssetName("prod-");
            var data = new ApiManagementProductData()
            {
                Description = "product",
                DisplayName = productId,
                SubscriptionRequired = true,
            };
            var product = (await productCollections.CreateOrUpdateAsync(WaitUntil.Completed, productId, data)).Value;
            var name = product.Data.Name;
            var result = (await product.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.AreEqual(name, result.Data.Name);

            var getResult = await productCollections.GetAsync(name);
            Assert.NotNull(getResult);
            var boolResult = await productCollections.ExistsAsync(name);
            Assert.IsTrue(boolResult);
        }
    }
}
