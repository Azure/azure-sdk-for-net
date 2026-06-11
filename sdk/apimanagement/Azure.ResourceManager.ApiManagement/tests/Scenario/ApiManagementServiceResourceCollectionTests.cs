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
    public class ApiManagementServiceResourceCollectionTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceResourceCollectionTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private async Task<ApiManagementServiceResourceCollection> GetApiManagementServiceResourceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            VNetCollection = resourceGroup.GetVirtualNetworks();
            return resourceGroup.GetApiManagementServiceResources();
        }

        [Test]
        [Ignore("Record success, playback time out.")]
        public async Task CRUD()
        {
            var collection = await GetApiManagementServiceResourceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            var apiManagementService = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.AreEqual(apiManagementService.Data.Name, apiName);

            // TagOperation
            await apiManagementService.AddTagAsync("testkey", "testvalue");
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.IsTrue(apiManagementService.Data.Tags.ContainsKey("testkey"));
            Assert.AreEqual(apiManagementService.Data.Tags["testkey"], "testvalue");

            var tags = new Dictionary<string, string>() { { "newkey", "newvalue" } };
            await apiManagementService.SetTagsAsync(tags);
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.IsTrue(apiManagementService.Data.Tags.ContainsKey("newkey"));
            Assert.AreEqual(apiManagementService.Data.Tags["newkey"], "newvalue");

            await apiManagementService.RemoveTagAsync("newkey");
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.AreEqual(apiManagementService.Data.Tags.Count, 0);

            // Update
            var patch = new ApiManagementServiceResourcePatch() { Tags = { { "newkey", "newvalue" } } };
            var updated = await apiManagementService.UpdateAsync(WaitUntil.Completed, patch);
            Assert.IsTrue(updated.Value.Data.Tags.ContainsKey("newkey"));
            Assert.AreEqual(updated.Value.Data.Tags["newkey"], "newvalue");

            // Delete
            await apiManagementService.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Get()
        {
            ApiManagementServiceResourceCollection collection;
            var apiName = "";
            collection = await GetApiManagementServiceResourceCollectionAsync();
            apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementService = (await collection.GetAsync(apiName)).Value;
            Assert.NotNull(apiManagementService.Data.Name);
        }

        [Test]
        public async Task GetAll()
        {
            ApiManagementServiceResourceCollection collection;
            collection = await GetApiManagementServiceResourceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(apiManagementServices.Count, 1);
        }

        [Test]
        public async Task Exists()
        {
            ApiManagementServiceResourceCollection collection;
            var apiName = "";
            collection = await GetApiManagementServiceResourceCollectionAsync();
            apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            var apiManagementServiceTrue = await collection.ExistsAsync(apiName);
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(apiManagementServiceTrue);
            Assert.IsFalse(apiManagementServiceFalse);
        }
    }
}
