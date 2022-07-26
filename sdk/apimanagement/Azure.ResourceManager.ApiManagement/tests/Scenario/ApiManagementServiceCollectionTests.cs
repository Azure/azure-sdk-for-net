// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests.Scenario
{
    public class ApiManagementServiceCollectionTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceCollectionTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ApiManagementServiceCollection> GetApiManagementServiceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetApiManagementServices();
        }

        [Test]
        public async Task Create_Get_GetAll_Exists()
        {
            // Create
            var collection = await GetApiManagementServiceCollectionAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample");
            var apiManagementService = await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            Assert.AreEqual(apiManagementService.Value.Data.Name, apiName);

            // Get
            var apiManagementService2 = await collection.GetAsync(apiName);
            Assert.AreEqual(apiManagementService2.Value.Data.Name, apiManagementService.Value.Data.Name);

            // GetAll
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(apiManagementServices.FirstOrDefault().Data.Name, apiName);
            Assert.GreaterOrEqual(apiManagementServices.Count, 1);

            //Exists
            var apiManagementServiceTrue = await collection.ExistsAsync(apiName);
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(apiManagementServiceTrue);
            Assert.IsFalse(apiManagementServiceFalse);
        }
    }
}
