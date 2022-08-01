// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiManagementServiceResourceTests : ApiManagementManagementTestBase
    {
        public ApiManagementServiceResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        // For playback
        private async Task<ApiManagementServiceResource> GetApiManagementServiceAsync()
        {
            var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
            var collection = resourceGroup.Value.GetApiManagementServices();
            return (await collection.GetAsync("sdktestapi")).Value;
        }

        [Test]
        public async Task ApplyNetworkConfigurationUpdates()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var networkConfigurationContent = new ApiManagementServiceApplyNetworkConfigurationContent();
            // Test API is in Updating State
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.ApplyNetworkConfigurationUpdatesAsync(WaitUntil.Completed, networkConfigurationContent));
        }

        [Test]
        public async Task Backup_Restore()
        {
            // Please create the resource first.
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
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            apiManagementService = await apiManagementService.GetAsync();
            Assert.NotNull(apiManagementService.Data.Name);
        }

        [Test]
        public async Task GetAvailableApiManagementServiceSkus()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetAvailableApiManagementServiceSkusAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatusByLocation()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.GetNetworkStatusByLocationAsync(AzureLocation.EastUS.DisplayName);
            Assert.GreaterOrEqual(status.Value.ConnectivityStatus.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatuses()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.GetNetworkStatusesAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(status.Count, 0);
        }

        [Test]
        public async Task GetOutboundNetworkDependenciesEndpoints()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetOutboundNetworkDependenciesEndpointsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetPolicyDescriptions()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetPolicyDescriptionsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetPortalSettings()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetPortalSettingsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetProductsByTags()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetProductsByTagsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetQuotaByCounterKeys()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetQuotaByCounterKeysAsync("foo").ToEnumerableAsync());
        }

        [Test]
        public async Task GetQuotaByPeriodKey()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetQuotaByPeriodKeyAsync("foo", "foo"));
        }

        [Test]
        public async Task GetRegions()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetRegionsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByApi()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByApiAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByGeo()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByGeoAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByOperation()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByOperationAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByProduct()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByProductAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByRequest()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByRequestAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsBySubscription()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsBySubscriptionAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByTime()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByTimeAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'", TimeSpan.FromMinutes(15)).ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByUser()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetReportsByUserAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetSsoToken()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = (await apiManagementService.GetSsoTokenAsync()).Value;
            Assert.NotNull(result.RedirectUri);
        }

        [Test]
        public async Task GetTagResources()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetTagResourcesAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetTenantAccessInfo()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = (await apiManagementService.GetTenantAccessInfoAsync(AccessName.TenantAccess)).Value;
            Assert.NotNull(result.Data.Name);
        }

        [Test]
        public async Task GetTenantConfigurationSyncState()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetTenantConfigurationSyncStateAsync("foo"));
        }

        [Test]
        public async Task PerformConnectivityCheckAsync()
        {
            // Please create the resource first.
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
            // Please create the resource first.
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
            // Please create the resource first.
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
            // Please create the resource first.
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
