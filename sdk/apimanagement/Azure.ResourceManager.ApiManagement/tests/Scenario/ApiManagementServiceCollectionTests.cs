// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiManagementServiceCollectionTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceCollectionTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private async Task<ApiManagementServiceCollection> GetApiManagementServiceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            VNetCollection = resourceGroup.GetVirtualNetworks();
            return resourceGroup.GetApiManagementServices();
        }

        [Test]
        [Ignore("Record success, playback time out.")]
        public async Task CRUD()
        {
            var collection = await GetApiManagementServiceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var apiManagementService = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.That(apiName, Is.EqualTo(apiManagementService.Data.Name));

            // TagOperation
            await apiManagementService.AddTagAsync("testkey", "testvalue");
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.That(apiManagementService.Data.Tags.ContainsKey("testkey"), Is.True);
            Assert.That(apiManagementService.Data.Tags["testkey"], Is.EqualTo("testvalue"));

            var tags = new Dictionary<string, string>() { { "newkey", "newvalue" } };
            await apiManagementService.SetTagsAsync(tags);
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.That(apiManagementService.Data.Tags.ContainsKey("newkey"), Is.True);
            Assert.That(apiManagementService.Data.Tags["newkey"], Is.EqualTo("newvalue"));

            await apiManagementService.RemoveTagAsync("newkey");
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.That(apiManagementService.Data.Tags.Count, Is.EqualTo(0));

            // Update
            var patch = new ApiManagementServicePatch() { Tags = { { "newkey", "newvalue" } } };
            var updated = await apiManagementService.UpdateAsync(WaitUntil.Completed, patch);
            Assert.That(updated.Value.Data.Tags.ContainsKey("newkey"), Is.True);
            Assert.That(updated.Value.Data.Tags["newkey"], Is.EqualTo("newvalue"));

            // Delete
            await apiManagementService.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Get()
        {
            ApiManagementServiceCollection collection;
            var apiName = "";
            collection = await GetApiManagementServiceCollectionAsync();
            apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementService = (await collection.GetAsync(apiName)).Value;
            Assert.That(apiManagementService.Data.Name, Is.Not.Null);
        }

        [Test]
        public async Task GetAll()
        {
            ApiManagementServiceCollection collection;
            collection = await GetApiManagementServiceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(apiManagementServices.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task Exists()
        {
            ApiManagementServiceCollection collection;
            var apiName = "";
            collection = await GetApiManagementServiceCollectionAsync();
            apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementServiceTrue = await collection.ExistsAsync(apiName);
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.That((bool)apiManagementServiceTrue, Is.True);
            Assert.That((bool)apiManagementServiceFalse, Is.False);
        }
    }
}
