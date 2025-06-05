// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Network;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class GatewayResourceTests : ApiManagementManagementTestBase
    {
        public GatewayResourceTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private async Task<ApiGatewayCollection> GetGatewayResourceCollectionsAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            VNetCollection = resourceGroup.GetVirtualNetworks();
            return resourceGroup.GetApiGateways();
        }

        [Test]
        [Ignore("Sku limite")]
        public async Task CRUD()
        {
            var collection = await GetGatewayResourceCollectionsAsync();
            var gatewaName = Recording.GenerateAssetName("gateway-");
            var data = new ApiGatewayData(AzureLocation.WestUS2, new ApiManagementGatewaySkuProperties(ApiGatewaySkuType.WorkspaceGatewayPremium));
            var apiManagementService = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, gatewaName, data)).Value;
            Assert.AreEqual(apiManagementService.Data.Name, gatewaName);
        }

        [Test]
        [Ignore("Sku limite")]
        public async Task Get()
        {
            ApiGatewayCollection collection;
            var apiName = "";
            if (Mode != RecordedTestMode.Playback)
            {
                collection = await GetGatewayResourceCollectionsAsync();
                apiName = Recording.GenerateAssetName("gateway-");
                var data = new ApiGatewayData(AzureLocation.WestUS2, new ApiManagementGatewaySkuProperties(ApiGatewaySkuType.WorkspaceGatewayPremium));
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            }
            else
            {
                apiName = "sdktestapi";
                var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
                collection = resourceGroup.Value.GetApiGateways();
            }
            var gatewayResource = (await collection.GetAsync(apiName)).Value;
            Assert.NotNull(gatewayResource.Data.Name);
        }

        [Test]
        [Ignore("Sku limite")]
        public async Task GetAll()
        {
            ApiGatewayCollection collection;
            if (Mode != RecordedTestMode.Playback)
            {
                collection = await GetGatewayResourceCollectionsAsync();
                var apiName = Recording.GenerateAssetName("gateway-");
                var data = new ApiGatewayData(AzureLocation.WestUS2, new ApiManagementGatewaySkuProperties(ApiGatewaySkuType.WorkspaceGatewayPremium));
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            }
            else
            {
                var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
                collection = resourceGroup.Value.GetApiGateways();
            }
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(apiManagementServices.Count, 1);
        }

        [Test]
        [Ignore("Sku limite")]
        public async Task Exists()
        {
            ApiGatewayCollection collection;
            var apiName = "";
            if (Mode != RecordedTestMode.Playback)
            {
                collection = await GetGatewayResourceCollectionsAsync();
                apiName = Recording.GenerateAssetName("gateway-");
                var data = new ApiGatewayData(AzureLocation.WestUS2, new ApiManagementGatewaySkuProperties(ApiGatewaySkuType.WorkspaceGatewayPremium));
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data);
            }
            else
            {
                apiName = "sdktestapi";
                var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
                collection = resourceGroup.Value.GetApiGateways();
            }
            var apiManagementServiceTrue = await collection.ExistsAsync(apiName);
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(apiManagementServiceTrue);
            Assert.IsFalse(apiManagementServiceFalse);
        }
    }
}
