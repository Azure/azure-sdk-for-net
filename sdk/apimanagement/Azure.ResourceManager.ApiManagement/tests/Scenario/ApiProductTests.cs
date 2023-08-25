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
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
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
            Assert.GreaterOrEqual(list.Count, 1);
            var api = list.Single();

            var productCollections = ApiServiceResource.GetApiManagementProducts();
            var listResponse = await productCollections.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listResponse);
            Assert.AreEqual(2, listResponse.Count());

            var product = listResponse.FirstOrDefault();
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
