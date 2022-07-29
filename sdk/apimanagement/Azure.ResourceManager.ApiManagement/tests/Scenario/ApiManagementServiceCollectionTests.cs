// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiManagementServiceCollectionTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceCollectionTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
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
        public async Task Create_Delete()
        {
            // Create vnet First
            var collection = await GetApiManagementServiceCollectionAsync();
            var vnetName = Recording.GenerateAssetName("testvnet-");
            var vnetData = new VirtualNetworkData()
            {
                Location = AzureLocation.EastUS,
                AddressPrefixes = { "10.0.0.0/16" },
                Subnets = { new SubnetData() { Name = "testsubnet", AddressPrefix = "10.0.1.0/24", } }
            };
            var vnet = (await VNetCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData)).Value;
            var virtualNetworkConfiguration = new VirtualNetworkConfiguration() { SubnetResourceId = new ResourceIdentifier(vnet.Data.Subnets.FirstOrDefault().Id) };

            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned),
                VirtualNetworkType = VirtualNetworkType.Internal,
                VirtualNetworkConfiguration = virtualNetworkConfiguration
            };
            var apiManagementService = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.AreEqual(apiManagementService.Data.Name, apiName);

            // DeployTenantConfiguration
            var contentName = Recording.GenerateAssetName("testcontent-");
            var contentData = new ConfigurationDeployContent() { Branch = "", Force = true};
            await apiManagementService.DeployTenantConfigurationAsync(WaitUntil.Completed, contentName, contentData);

            // Delete
            await apiManagementService.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Get()
        {
            // Please create the resource first.
            var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
            var collection = resourceGroup.Value.GetApiManagementServices();
            var apiManagementService = (await collection.GetAsync("sdktestapi")).Value;
            Assert.NotNull(apiManagementService.Data.Name);
        }

        [Test]
        public async Task GetAll()
        {
            // Please create the resource first.
            var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
            var collection = resourceGroup.Value.GetApiManagementServices();
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(apiManagementServices.Count, 1);
        }

        [Test]
        public async Task Exists()
        {
            // Please create the resource first.
            var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
            var collection = resourceGroup.Value.GetApiManagementServices();
            var apiManagementServiceTrue = await collection.ExistsAsync("sdktestapi");
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(apiManagementServiceTrue);
            Assert.IsFalse(apiManagementServiceFalse);
        }
    }
}
