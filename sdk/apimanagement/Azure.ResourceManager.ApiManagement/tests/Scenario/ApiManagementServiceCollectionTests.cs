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
        public async Task Create_Get_GetAll_Exists()
        {
            // Create
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

            // Get
            var apiManagementService2 = (await collection.GetAsync(apiName)).Value;
            Assert.AreEqual(apiManagementService2.Data.Name, apiManagementService.Data.Name);

            // GetAll
            var apiManagementServices = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(apiManagementServices.FirstOrDefault().Data.Name, apiName);
            Assert.GreaterOrEqual(apiManagementServices.Count, 1);

            // Exists
            var apiManagementServiceTrue = await collection.ExistsAsync(apiName);
            var apiManagementServiceFalse = await collection.ExistsAsync("foo");
            Assert.IsTrue(apiManagementServiceTrue);
            Assert.IsFalse(apiManagementServiceFalse);

            // Add Tag
            await apiManagementService.AddTagAsync("testkey", "testvalue");
            apiManagementService = (await apiManagementService.GetAsync()).Value;
            Assert.AreEqual(apiManagementService.Data.Tags.FirstOrDefault().Key, "testkey");
            Assert.AreEqual(apiManagementService.Data.Tags.FirstOrDefault().Value, "testvalue");

            // ApplyNetworkConfigurationUpdates
            var networkConfigurationContent = new ApiManagementServiceApplyNetworkConfigurationContent();
            // Test API is in Updating State
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.ApplyNetworkConfigurationUpdatesAsync(WaitUntil.Completed, networkConfigurationContent));

            // Backup
            var backupRestoreContent = new ApiManagementServiceBackupRestoreContent("contosorpstorage", "apim-backups", "backup5")
            {
                AccessType = StorageAccountAccessType.SystemAssignedManagedIdentity
            };
            Assert.DoesNotThrowAsync(async () => await apiManagementService.BackupAsync(WaitUntil.Completed, backupRestoreContent));
        }
    }
}
