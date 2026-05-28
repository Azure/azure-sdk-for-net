// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiManagementServiceResourceTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceResourceTests(bool isAsync)
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

        private async Task<ApiManagementServiceResource> GetApiManagementServiceAsync()
        {
            var collection = await GetApiManagementServiceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Premium, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task ApplyNetworkConfigurationUpdates()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var networkConfigurationContent = new ApiManagementServiceApplyNetworkConfigurationContent();
            // Test API is in Updating State
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.ApplyNetworkConfigurationUpdatesAsync(WaitUntil.Completed, networkConfigurationContent));
        }

        [Test]
        public async Task Backup_Restore()
        {
            // Backup
            var apiManagementService = await GetApiManagementServiceAsync();
            var backupContent = new ApiManagementServiceBackupRestoreContent("apiteststorageaccount", "apiblob", "backup5")
            {
                AccessType = StorageAccountAccessType.SystemAssignedManagedIdentity
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.BackupAsync(WaitUntil.Completed, backupContent));

            // Restore
            var restoreContent = new ApiManagementServiceBackupRestoreContent("apiteststorageaccount", "apiblob", "backup5")
            {
                AccessType = StorageAccountAccessType.SystemAssignedManagedIdentity
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.RestoreAsync(WaitUntil.Completed, restoreContent));
        }

        [Test]
        public async Task Get()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            apiManagementService = await apiManagementService.GetAsync();
            Assert.NotNull(apiManagementService.Data.Name);
        }

        [Test]
        public async Task GetAvailableApiManagementServiceSkus()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetAvailableApiManagementServiceSkusAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatusByLocation()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.GetNetworkStatusByLocationAsync(AzureLocation.WestUS2.DisplayName);
            Assert.GreaterOrEqual(status.Value.ConnectivityStatus.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatuses()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.GetNetworkStatusesAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(status.Count, 0);
        }

        [Test]
        public async Task GetOutboundNetworkDependenciesEndpoints()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetOutboundNetworkDependenciesEndpointsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetPolicyDescriptions()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.DoesNotThrow(() => apiManagementService.GetPolicyDescriptionsAsync());
        }

        [Test]
        public async Task GetPortalSettings()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.DoesNotThrow(()=>apiManagementService.GetPortalSettingsAsync());
        }

        [Test]
        public async Task GetProductsByTags()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetProductsByTagsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetQuotaByCounterKeys()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetQuotaByCounterKeysAsync("foo").ToEnumerableAsync());
        }

        [Test]
        public async Task GetQuotaByPeriodKey()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetQuotaByPeriodKeyAsync("foo", "foo"));
        }

        [Test]
        public async Task GetRegions()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetRegionsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByApi()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByApiAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByGeo()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByGeoAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByOperation()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByOperationAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByProduct()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByProductAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByRequest()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByRequestAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsBySubscription()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsBySubscriptionAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByTime()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByTimeAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'", TimeSpan.FromMinutes(15)).ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByUser()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByUserAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetSsoToken()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = (await apiManagementService.GetSsoTokenAsync()).Value;
            Assert.NotNull(result.RedirectUri);
        }

        [Test]
        public async Task GetTagResources()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetTagResourcesAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetTenantAccessInfo()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = (await apiManagementService.GetTenantAccessInfoAsync(AccessName.TenantAccess)).Value;
            Assert.NotNull(result.Data.Name);
        }

        [Test]
        public async Task GetTenantConfigurationSyncState()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetTenantConfigurationSyncStateAsync("foo"));
        }

        [Test]
        [Ignore("Functionality not supported")]
        public async Task PerformConnectivityCheckAsync()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var source = new ConnectivityCheckRequestSource("eastus");
            var destination = new ConnectivityCheckRequestDestination("8.8.8.8", 53);
            var content = new ConnectivityCheckContent(source, destination)
            {
                PreferredIPVersion = PreferredIPVersion.IPv4
            };
            await apiManagementService.PerformConnectivityCheckAsyncAsync(WaitUntil.Completed, content);
        }

        [Test]
        public async Task TenantConfiguration_Deploy_Save_Get()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var configName = Recording.GenerateAssetName("testconfig-");
            var deploy = new ConfigurationDeployContent() { Branch = "master" };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.ValidateTenantConfigurationAsync(WaitUntil.Completed, configName, deploy));
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.DeployTenantConfigurationAsync(WaitUntil.Completed, configName, deploy));
            var content = new ConfigurationSaveContent() { Branch = "master" };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.SaveTenantConfigurationAsync(WaitUntil.Completed, configName, content));
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetTenantConfigurationSyncStateAsync(configName));
        }

        [Test]
        public async Task UpdateQuotaByCounterKeys()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var updateContent = new QuotaCounterValueUpdateContent()
            {
                CallsCount = 0,
                KbTransferred = 2.5630078125
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.UpdateQuotaByCounterKeysAsync("ba", updateContent).ToEnumerableAsync());
        }

        [Test]
        public async Task UpdateQuotaByPeriodKey()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var updateContent = new QuotaCounterValueUpdateContent()
            {
                CallsCount = 0,
                KbTransferred = 0
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.UpdateQuotaByPeriodKeyAsync("ba", "0_P3Y6M4DT12H30M5S", updateContent));
        }
    }
}
