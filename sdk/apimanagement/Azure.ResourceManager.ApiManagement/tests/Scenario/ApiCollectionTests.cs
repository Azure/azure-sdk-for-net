// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiCollectionTests : ApiManagementManagementTestBase
    {
        public ApiCollectionTests(bool isAsync)
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

        private async Task CreateApiService()
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
        public async Task CreateOrUpdate_GetAll_Get_Exists_Delete ()
        {
            await CreateApiService();
            var collection = ApiServiceResource.GetApis();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiCreateOrUpdateContent()
            {
                Description = "apidescription5200",
                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract()
                {
                    Header = "header4520",
                    Query = "query3037"
                },
                DisplayName = "apiname1463",
                ServiceUri = new Uri("http://newechoapi.cloudapp.net/api"),
                Path = "newapiPath",
                Protocols = { ApiOperationInvokableProtocol.Https, ApiOperationInvokableProtocol.Http }
            };
            var result = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.AreEqual(result.Data.Name, apiName);
            Assert.AreEqual(result.Data.Path, "newapiPath");
            var resultTrue = await collection.ExistsAsync(apiName);
            var resultFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);

            await foreach (var item in collection.GetAllAsync())
            {
                var newitem = (await item.GetAsync()).Value;
                Assert.NotNull(newitem.Data.DisplayName);
                await newitem.DeleteAsync(WaitUntil.Completed, ETag.All);
            }
        }
    }
}
