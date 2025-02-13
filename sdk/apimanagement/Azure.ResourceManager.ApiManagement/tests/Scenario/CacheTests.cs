// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class CacheTests : ApiManagementManagementTestBase
    {
        public CacheTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
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
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var cacheCollection = ApiServiceResource.GetApiManagementCaches();

            // list caches: there should be none
            var cacheListResponse = await cacheCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(cacheListResponse);
            Assert.IsEmpty(cacheListResponse);

            // create new cache
            string cacheid = AzureLocation.WestUS2;
            var cacheContract = new ApiManagementCacheData()
            {
                ConnectionString = Recording.GenerateAssetName("string"),
                Description = Recording.GenerateAssetName("string"),
                UseFromLocation = Recording.GenerateAssetName("string")
            };
            var createResponse = (await cacheCollection.CreateOrUpdateAsync(WaitUntil.Completed, cacheid, cacheContract)).Value;

            Assert.NotNull(createResponse);
            Assert.AreEqual(cacheid, createResponse.Data.Name);
            Assert.AreEqual(cacheContract.Description, createResponse.Data.Description);

            // get the certificate to check is was created
            var getResponse = (await cacheCollection.GetAsync(cacheid)).Value;

            Assert.NotNull(getResponse);
            Assert.AreEqual(cacheid, getResponse.Data.Name);

            // list caches
            cacheListResponse = await cacheCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(cacheListResponse);
            Assert.AreEqual(cacheListResponse.Count, 1);

            // remove the cache
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await cacheCollection.ExistsAsync(cacheid));
            Assert.IsFalse(resultFalse);
        }
    }
}
