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

        private async Task<ApiManagementServiceResourceCollection> GetApiManagementServiceResourceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            VNetCollection = resourceGroup.GetVirtualNetworks();
            return resourceGroup.GetApiManagementServiceResources();
        }

        private async Task<ApiManagementServiceResource> GetApiManagementServiceAsync()
        {
            var collection = await GetApiManagementServiceResourceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.Premium, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
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
                AccessType = AccessType.SystemAssignedManagedIdentity
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.BackupAsync(WaitUntil.Completed, backupContent));

            // Restore
            var restoreContent = new ApiManagementServiceBackupRestoreContent("apiteststorageaccount", "apiblob", "backup5")
            {
                AccessType = AccessType.SystemAssignedManagedIdentity
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
            var list = await apiManagementService.GetAvailableServiceSkusAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatusByLocation()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.GetByLocationAsync(AzureLocation.WestUS2.DisplayName);
            Assert.GreaterOrEqual(status.Value.ConnectivityStatus.Count, 0);
        }

        [Test]
        public async Task GetNetworkStatuses()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var status = await apiManagementService.NetworkStatusGetByServiceAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(status.Count, 0);
        }

        [Test]
        public async Task GetOutboundNetworkDependenciesEndpoints()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = await apiManagementService.OutboundNetworkDependenciesEndpointsGetByServiceAsync();
            Assert.GreaterOrEqual(result.Value.Value.Count, 0);
        }

        [Test]
        public async Task GetPolicyDescriptions()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = await apiManagementService.GetByServiceAsync((PolicyScopeContract?)null);
        }

        [Test]
        public async Task GetPortalSettings()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = await apiManagementService.PortalSettingsGetByServiceAsync();
            Assert.NotNull(result.Value);
        }

        [Test]
        public async Task GetProductsByTags()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.ProductGetByTagsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetQuotaByCounterKeys()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetByServiceAsync("foo", default(CancellationToken)));
        }

        [Test]
        public async Task GetQuotaByPeriodKey()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.GetAsync("foo", "foo"));
        }

        [Test]
        public async Task GetRegions()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.RegionGetByServiceAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByApi()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByApiAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByGeo()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByGeoAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByOperation()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByOperationAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByProduct()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByProductAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByRequest()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByRequestAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsBySubscription()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetBySubscriptionAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByTime()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByTimeAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'", TimeSpan.FromMinutes(15)).ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetReportsByUser()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var list = await apiManagementService.GetByUserAsync("timestamp ge datetime'2017-06-01T00:00:00' and timestamp le datetime'2017-06-04T00:00:00'").ToEnumerableAsync();
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
            var list = await apiManagementService.GetByServiceAsync(filter: null).ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [Test]
        public async Task GetTenantAccessInfo()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var result = (await apiManagementService.GetTenantAccessInfoAsync(AccessIdName.Access)).Value;
            Assert.NotNull(result.Data.Name);
        }

        [Test]
        public async Task GetTenantConfigurationSyncState()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var tenantAccess = (await apiManagementService.GetTenantAccessInfoAsync(AccessIdName.Access)).Value;
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await tenantAccess.GetSyncStateAsync());
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
            var tenantAccess = (await apiManagementService.GetTenantAccessInfoAsync(AccessIdName.Access)).Value;
            var deploy = new ConfigurationDeployContent();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await tenantAccess.ValidateAsync(WaitUntil.Completed, deploy));
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await tenantAccess.DeployAsync(WaitUntil.Completed, deploy));
            var content = new ConfigurationSaveContent();
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await tenantAccess.SaveAsync(WaitUntil.Completed, content));
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await tenantAccess.GetSyncStateAsync());
        }

        [Test]
        public async Task UpdateQuotaByCounterKeys()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var updateContent = new QuotaCounterValueUpdateContract()
            {
                CallsCount = 0,
                KbTransferred = 2.5630078125
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.UpdateAsync("ba", updateContent));
        }

        [Test]
        public async Task UpdateQuotaByPeriodKey()
        {
            var apiManagementService = await GetApiManagementServiceAsync();
            var updateContent = new QuotaCounterValueUpdateContract()
            {
                CallsCount = 0,
                KbTransferred = 0
            };
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await apiManagementService.UpdateAsync("ba", "0_P3Y6M4DT12H30M5S", updateContent));
        }
    }
}
