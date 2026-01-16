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

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.BasicV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();

            var list = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(0));

            var productCollections = ApiServiceResource.GetApiManagementProducts();
            var listResponse = await productCollections.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse.Count(), Is.EqualTo(0));

            var productId = Recording.GenerateAssetName("prod-");
            var data = new ApiManagementProductData()
            {
                Description = "product",
                DisplayName = productId,
                IsSubscriptionRequired = true,
            };
            var product = (await productCollections.CreateOrUpdateAsync(WaitUntil.Completed, productId, data)).Value;
            var name = product.Data.Name;
            var result = (await product.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Name, Is.EqualTo(name));

            var getResult = await productCollections.GetAsync(name);
            Assert.That(getResult, Is.Not.Null);
            var boolResult = await productCollections.ExistsAsync(name);
            Assert.That((bool)boolResult, Is.True);
        }
    }
}
